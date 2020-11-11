/*
    RemoteCongress - A platform for conducting small secure public elections
    Copyright (C) 2020  Nathan Mentley

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

namespace RemoteCongress.Client
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
        /// </excpetion>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="config"/> is null.
        /// </excpetion>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="httpClient"/> is null.
        /// </excpetion>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="queryCodec"/> is null.
        /// </excpetion>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="codecs"/> is null.
        /// </excpetion>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="collectionCodecs"/> is null.
        /// </excpetion>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="endpoint"/> is null.
        /// </excpetion>
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
                    new ArgumentNullException(nameof(config))
                );

            _httpClient = httpClient ??
                throw _logger.LogException(
                    new ArgumentNullException(nameof(httpClient))
                );

            _queryCodec = queryCodec ??
                throw _logger.LogException(
                    new ArgumentNullException(nameof(queryCodec))
                );

            _codecs = codecs ??
                throw _logger.LogException(
                    new ArgumentNullException(nameof(codecs))
                );

            _collectionCodecs = collectionCodecs ??
                throw _logger.LogException(
                    new ArgumentNullException(nameof(collectionCodecs))
                );

            _endpoint = endpoint ??
                throw _logger.LogException(
                    new ArgumentNullException(nameof(endpoint))
                );
        }

        /// <summary>
        /// Creates a new block containing the verified content in <paramref="data"/> in the blockchain.
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
        public async Task<string> AppendToChain(ISignedData data, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            ICodec<SignedData> jsonCodec = GetSignedDataForMediaType(SignedDataV1JsonCodec.MediaType);

            using Stream jsonStream = await jsonCodec.Encode(
                jsonCodec.GetPreferredMediaType(),
                new SignedData(data)
            );
            using StreamContent streamContent = new StreamContent(jsonStream)
            {
                Headers = {
                    { ContentTypeHeaderKey, jsonCodec.GetPreferredMediaType().ToString() }
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
                    { AcceptHeaderKey, jsonCodec.GetPreferredMediaType().ToString() }
                },
                Content = streamContent
            };

            using HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            using Stream body = await response.Content.ReadAsStreamAsync();

            SignedData result = await jsonCodec.Decode(jsonCodec.GetPreferredMediaType(), body);

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
                    { AcceptHeaderKey, codec.GetPreferredMediaType().ToString() }
                }
            };

            using HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            using Stream body = await response.Content.ReadAsStreamAsync();

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
        public async IAsyncEnumerable<ISignedData> FetchAllFromChain(
            IList<IQuery> queries,
            [EnumeratorCancellation] CancellationToken cancellationToken
        )
        {
            if (queries is null)
                throw _logger.LogException(
                    new ArgumentNullException(nameof(queries))
                );

            cancellationToken.ThrowIfCancellationRequested();

            ICodec<IEnumerable<SignedData>> codec =
                GetSignedDataCollectionForMediaType(SignedDataCollectionV1JsonCodec.MediaType);

            Url url = new Url($"{_config.Protocol}://{_config.ServerHostName}")
                .AppendPathSegment(_endpoint);

            foreach(IQuery query in queries)
            {
                string queryData = await _queryCodec.EncodeToString(
                    _queryCodec.GetPreferredMediaType(),
                    query
                );
                url.SetQueryParam(QueryKey, queryData);
            }

            using HttpRequestMessage request = new HttpRequestMessage(
                HttpMethod.Get,
                url
            )
            {
                Headers = {
                    { AcceptHeaderKey, codec.GetPreferredMediaType().ToString() }
                }
            };

            using HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            using Stream body = await response.Content.ReadAsStreamAsync();

            foreach(SignedData data in await codec.Decode(codec.GetPreferredMediaType(), body))
            {
                yield return data;
            }
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
        private ICodec<IEnumerable<SignedData>> GetSignedDataCollectionForMediaType(RemoteCongressMediaType mediaType) =>
            _collectionCodecs.FirstOrDefault(
                codec => codec.CanHandle(mediaType)
            ) ??
                throw _logger.LogException(
                    new UnknownBlockMediaTypeException(
                        $"{mediaType.ToString()} is not supported."
                    )
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
        private ICodec<SignedData> GetSignedDataForMediaType(RemoteCongressMediaType mediaType) =>
            _codecs.FirstOrDefault(
                codec => codec.CanHandle(mediaType)
            ) ??
                throw _logger.LogException(
                    new UnknownBlockMediaTypeException(
                        $"{mediaType.ToString()} is not supported."
                    )
                );
    }
}