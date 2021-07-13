/*
    RemoteCongress - A platform for conducting small secure public elections
    Copyright (C) 2021  Nathan Mentley

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU Affero General Public License as published
    by the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Affero General Public License for more details.

    You should have received a copy of the GNU Affero General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/
using Flurl;
using Microsoft.Extensions.Logging;
using RemoteCongress.Common;
using RemoteCongress.Common.Exceptions;
using RemoteCongress.Common.Logging;
using RemoteCongress.Common.Repositories;
using RemoteCongress.Common.Repositories.Queries;
using RemoteCongress.Common.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Client.DAL.Http
{
    /// <summary>
    /// An <see cref="IDataClient"/> that operates over http.
    /// </summary>
    public class HttpDataClient: IDataClient
    {
        private readonly static string AcceptHeaderKey = "Accept";
        private readonly static string ContentTypeHeaderKey = "Content-Type";
        private readonly static string QueryKey = "query";

        private readonly ILogger<HttpDataClient> _logger;
        private readonly ClientConfig _config;
        private readonly HttpClient _httpClient;
        private readonly ICodec<IQuery> _queryCodec;
        private readonly IEnumerable<ICodec<SignedData>> _codecs;
        private readonly IEnumerable<ICodec<IEnumerable<SignedData>>> _collectionCodecs;
        private readonly string _endpoint;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">
        /// An <see cref="ILogger"/> to log against.
        /// </param>
        /// <param name="config">
        /// A <see cref="ClientConfig"/> instance that holds configuration data on connecting to the server.
        /// </param>
        /// <param name="httpClient">
        /// A <see cref="HttpClient"/> instance to use to communicate with the server.
        /// </param>
        /// <param name="queryCodec">
        /// A <see cref="ICodec{ICodec}"/> instance to use.
        /// </param>
        /// <param name="codecs">
        /// An <see cref="ICodec{TData}"/> for <see cref="SignedData"/>.
        /// </param>
        /// <param name="collectionCodecs">
        /// An <see cref="ICodec{TData}"/> for a collection of <see cref="SignedData"/>s.
        /// </param>
        /// <param name="endpoint">
        /// The endpoint to this client should hit.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="logger"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="config"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="httpClient"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="queryCodec"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="codecs"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="collectionCodecs"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="endpoint"/> is null.
        /// </exception>
        public HttpDataClient(
            ILogger<HttpDataClient> logger,
            ClientConfig config,
            HttpClient httpClient,
            ICodec<IQuery> queryCodec,
            IEnumerable<ICodec<SignedData>> codecs,
            IEnumerable<ICodec<IEnumerable<SignedData>>> collectionCodecs,
            string endpoint
        )
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));

            _config = config ??
                throw _logger.LogException(
                    new ArgumentNullException(nameof(config)),
                    LogLevel.Debug
                );

            _httpClient = httpClient ??
                throw _logger.LogException(
                    new ArgumentNullException(nameof(httpClient)),
                    LogLevel.Debug
                );

            _queryCodec = queryCodec ??
                throw _logger.LogException(
                    new ArgumentNullException(nameof(queryCodec)),
                    LogLevel.Debug
                );

            _codecs = codecs ??
                throw _logger.LogException(
                    new ArgumentNullException(nameof(codecs)),
                    LogLevel.Debug
                );

            _collectionCodecs = collectionCodecs ??
                throw _logger.LogException(
                    new ArgumentNullException(nameof(collectionCodecs)),
                    LogLevel.Debug
                );

            _endpoint = endpoint ??
                throw _logger.LogException(
                    new ArgumentNullException(nameof(endpoint)),
                    LogLevel.Debug
                );
        }

        /// <summary>
        /// Creates a new block containing the verified content in <paramref name="data"/> in the blockchain.
        /// </summary>
        /// <param name="data">
        /// The signed and verified data structure to store in the blockchain.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation requests.
        /// </param>
        /// <returns>
        /// The unique id of the stored block.
        /// </returns>
        /// <exception cref="OperationCanceledException">
        /// Thrown if <paramref name="cancellationToken"/> is cancelled.
        /// </exception>
        /// <exception cref="UnknownBlockMediaTypeException">
        /// Thrown if <see cref="SignedDataV1JsonCodec.MediaType"/> doesn't have a registered <see cref="ICodec{TModel}"/>.
        /// </exception>
        public async Task<string> AppendToChain(ISignedData data, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            ICodec<SignedData> codec = GetSignedDataForMediaType(SignedDataV1JsonCodec.MediaType);

            using Stream stream = await codec.Encode(
                codec.GetPreferredMediaType(),
                new SignedData(data)
            );
            using StreamContent streamContent = new StreamContent(stream)
            {
                Headers = {
                    { ContentTypeHeaderKey, codec.GetPreferredMediaType().ToString() }
                }
            };

            Url url = new Url($"{_config.Protocol}://{_config.ServerHostName}")
                .AppendPathSegment(_endpoint);

            using HttpRequestMessage request = new HttpRequestMessage(
                HttpMethod.Post,
                url
            )
            {
                Headers = {
                    //TODO: pass all acceptable media types
                    { AcceptHeaderKey, codec.GetPreferredMediaType().ToString() }
                },
                Content = streamContent
            };

            using HttpResponseMessage response = await SendAsync(request, cancellationToken);
            using Stream responseBodyStream = await response.Content.ReadAsStreamAsync();

            //TODO: Get MediaType from response
            SignedData result = await codec.Decode(codec.GetPreferredMediaType(), responseBodyStream);

            return result.Id;
        }

        /// <summary>
        /// Fetches the verified data in the form of <see cref="ISignedData"/> from the blockchain by block id.
        /// </summary>
        /// <param name="id">
        /// The unique block id to pull verified data from.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation requests.
        /// </param>
        /// <returns>
        /// An <see cref="ISignedData"/> instance containing the block data.
        /// </returns>
        /// <exception cref="OperationCanceledException">
        /// Thrown if <paramref name="cancellationToken"/> is cancelled.
        /// </exception>
        /// <exception cref="UnknownBlockMediaTypeException">
        /// Thrown if <see cref="SignedDataV1JsonCodec.MediaType"/> doesn't have a registered <see cref="ICodec{TModel}"/>.
        /// </exception>
        public async Task<ISignedData> FetchFromChain(string id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            ICodec<SignedData> codec = GetSignedDataForMediaType(SignedDataV1JsonCodec.MediaType);

            Url url = new Url($"{_config.Protocol}://{_config.ServerHostName}")
                .AppendPathSegment(_endpoint)
                .AppendPathSegment(id);

            using HttpRequestMessage request = new HttpRequestMessage(
                HttpMethod.Get,
                url
            )
            {
                Headers = {
                    //TODO: pass all acceptable media types
                    { AcceptHeaderKey, codec.GetPreferredMediaType().ToString() }
                }
            };

            using HttpResponseMessage response = await SendAsync(request, cancellationToken);
            using Stream body = await response.Content.ReadAsStreamAsync();

            //TODO: Get MediaType from response
            return await codec.Decode(codec.GetPreferredMediaType(), body);
        }

        /// <summary>
        /// Fetches all matching verified data in the form of <see cref="ISignedData"/> from the blockchain.
        /// </summary>
        /// <param name="queries">
        /// The query to pull data by.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation requests.
        /// </param>
        /// <returns>
        /// An <see cref="ISignedData"/> instance containing the block data.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="queries"/> is null.
        /// </exception>
        /// <exception cref="OperationCanceledException">
        /// Thrown if <paramref name="cancellationToken"/> is cancelled.
        /// </exception>
        /// <exception cref="UnknownBlockMediaTypeException">
        /// Thrown if <see cref="SignedDataCollectionV1JsonCodec.MediaType"/> doesn't have a registered <see cref="ICodec{TModel}"/>.
        /// </exception>
        public async IAsyncEnumerable<ISignedData> FetchAllFromChain(
            IEnumerable<IQuery> queries,
            [EnumeratorCancellation] CancellationToken cancellationToken
        )
        {
            if (queries is null)
                throw _logger.LogException(
                    new ArgumentNullException(nameof(queries)),
                    LogLevel.Debug
                );

            cancellationToken.ThrowIfCancellationRequested();

            ICodec<IEnumerable<SignedData>> codec =
                GetSignedDataCollectionForMediaType(SignedDataCollectionV1JsonCodec.MediaType);

            Url url = new Url($"{_config.Protocol}://{_config.ServerHostName}")
                .AppendPathSegment(_endpoint);

            IList<string> encodedQueries = new List<string>();
            foreach(IQuery query in queries)
            {
                string queryData = await _queryCodec.EncodeToString(
                    _queryCodec.GetPreferredMediaType(),
                    query
                );
                encodedQueries.Add(queryData);
            }
            url.SetQueryParam(QueryKey, encodedQueries);

            using HttpRequestMessage request = new HttpRequestMessage(
                HttpMethod.Get,
                url
            )
            {
                Headers = {
                    //TODO: pass all acceptable media types
                    { AcceptHeaderKey, codec.GetPreferredMediaType().ToString() }
                }
            };

            using HttpResponseMessage response = await SendAsync(request, cancellationToken);
            using Stream body = await response.Content.ReadAsStreamAsync();

            //TODO: Get MediaType from response
            foreach(SignedData data in await codec.Decode(codec.GetPreferredMediaType(), body))
            {
                cancellationToken.ThrowIfCancellationRequested();

                yield return data;
            }
        }

        private async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            return await _httpClient.SendAsync(request, cancellationToken);
        }

        /// <summary>
        /// Fetches the codec for a collection data for a mediatype
        /// </summary>
        /// <param name="mediaType">
        /// The media type to fetch a collection codec for
        /// </param>
        /// <returns>
        /// The codec
        /// </returns>
        /// <exception cref="UnknownBlockMediaTypeException">
        /// Thrown if <paramref name="mediaType"/> doesn't have a registered <see cref="ICodec{TModel}"/>.
        /// </exception>
        private ICodec<IEnumerable<SignedData>> GetSignedDataCollectionForMediaType(
            RemoteCongressMediaType mediaType
        ) =>
            _collectionCodecs.FirstOrDefault(
                codec => codec.CanHandle(mediaType)
            ) ??
                throw _logger.LogException(
                    new UnknownBlockMediaTypeException(
                        $"{mediaType.ToString()} is not supported."
                    ),
                    LogLevel.Debug
                );

        /// <summary>
        /// Fetches the codec for a mediatype
        /// </summary>
        /// <param name="mediaType">
        /// The media type to fetch a codec for
        /// </param>
        /// <returns>
        /// The codec
        /// </returns>
        /// <exception cref="UnknownBlockMediaTypeException">
        /// Thrown if <paramref name="mediaType"/> doesn't have a registered <see cref="ICodec{TModel}"/>.
        /// </exception>
        private ICodec<SignedData> GetSignedDataForMediaType(
            RemoteCongressMediaType mediaType
        ) =>
            _codecs.FirstOrDefault(
                codec => codec.CanHandle(mediaType)
            ) ??
                throw _logger.LogException(
                    new UnknownBlockMediaTypeException(
                        $"{mediaType.ToString()} is not supported."
                    ),
                    LogLevel.Debug
                );
    }
}