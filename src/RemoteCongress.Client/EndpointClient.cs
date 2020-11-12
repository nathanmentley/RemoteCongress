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
using Microsoft.Extensions.Logging;
using RemoteCongress.Common;
using RemoteCongress.Common.Encryption;
using RemoteCongress.Common.Exceptions;
using RemoteCongress.Common.Logging;
using RemoteCongress.Common.Repositories;
using RemoteCongress.Common.Repositories.Queries;
using RemoteCongress.Common.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Client
{
    /// <summary>
    /// A client used to interact an endpoint of the api.
    /// </summary>
    public class EndpointClient<TModel>: IEndpointClient<TModel>
    {
        /// <summary>
        /// An <see cref="ILogger"/> instance to log against.
        /// </summary>
        private readonly ILogger<EndpointClient<TModel>> _logger;

        /// <summary>
        /// A collection of codecs to endode and decode data.
        /// </summary>
        private readonly IEnumerable<ICodec<TModel>> _codecs;

        /// <summary>
        /// A repository to interact with data.
        /// </summary>
        private readonly IImmutableDataRepository<TModel> _repository;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="logger">
        /// An <see cref="ILogger"/> to log against.
        /// </param>
        /// <param name="codecs">
        /// An <see cref="ICodec"/> for <see cref="TModel"/>s.
        /// </param>
        /// <param name="repository">
        /// An <see cref="IImmutableDataRepository<TModelData>"/> instance to use to interact with <see cref="TModel"/>s.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="logger"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="codecs"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="repository"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="codecs"/> contains zero <see cref="ICodec{TModel}"/>s.
        /// </exception>
        public EndpointClient(
            ILogger<EndpointClient<TModel>> logger,
            IEnumerable<ICodec<TModel>> codecs,
            IImmutableDataRepository<TModel> repository
        )
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));

            _codecs = codecs ??
                throw _logger.LogException(
                    new ArgumentNullException(nameof(codecs))
                );

            _repository = repository ??
                throw _logger.LogException(
                    new ArgumentNullException(nameof(repository))
                );

            if (_codecs.Count() < 1)
            {
                throw _logger.LogException(
                    new ArgumentException(
                        $"{nameof(codecs)} must contain atleast one {nameof(ICodec<TModel>)}.",
                        nameof(codecs)
                    )
                );
            }
        }

        /// <summary>
        /// Creates, signs, and persists a <see cref="TModel"/> instance.
        /// </summary>
        /// <param name="privateKey">
        /// The private key to use to generate the <see cref="ISignedData.Signature"/> of the <see cref="TModel"/>.
        /// </param>
        /// <param name="publicKey">
        /// The public key that matches <paramref name="privateKey"/> to link the immutable <see cref="TModel"/> to
        ///     the producing individual.
        /// </param>
        /// <param name="data">
        /// The <see cref="TModel"/> data to persist.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation requests.
        /// </param>
        /// <returns>
        /// The persisted <see cref="TModel"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="privateKey"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="publicKey"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="data"/> is null.
        /// </exception>
        /// <exception cref="OperationCanceledException">
        /// Thrown if <paramref name="cancellationToken"/> is null.
        /// </exception>
        public async Task<VerifiedData<TModel>> Create(
            string privateKey,
            string publicKey,
            TModel data,
            CancellationToken cancellationToken
        )
        {
            if (string.IsNullOrWhiteSpace(privateKey))
            {
                throw _logger.LogException(
                    new ArgumentNullException(nameof(privateKey))
                );
            }

            if (string.IsNullOrWhiteSpace(publicKey))
            {
                throw _logger.LogException(
                    new ArgumentNullException(nameof(publicKey))
                );
            }

            if (data is null)
            {
                throw _logger.LogException(
                    new ArgumentNullException(nameof(data))
                );
            }

            cancellationToken.ThrowIfCancellationRequested();

            ICodec<TModel> codec = GetTModelCodec(GetPreferredMediaType());

            string blockContent = await codec.EncodeToString(
                codec.GetPreferredMediaType(),
                data
            );

            SignedData signedData = new SignedData(
                publicKey,
                blockContent,
                RsaUtils.GenerateSignature(privateKey, blockContent),
                codec.GetPreferredMediaType()
            );

            VerifiedData<TModel> vote = new VerifiedData<TModel>(signedData, data);

            return await _repository.Create(vote, cancellationToken);
        }

        /// <summary>
        /// Fetches a signed, and verified <see cref="TModel"/> by it's <see cref="IIdentifiable.Id"/>.
        /// </summary>
        /// <param name="id">
        /// The <see cref="IIdentifiable.Id"/> of the <see cref="TModel"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation requests.
        /// </param>
        /// <returns>
        /// The persisted <see cref="TModel"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="id"/> is null.
        /// </exception>
        /// <exception cref="OperationCanceledException">
        /// Thrown if <paramref name="cancellationToken"/> is null.
        /// </exception>
        public Task<VerifiedData<TModel>> Get(string id, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw _logger.LogException(
                    new ArgumentNullException(nameof(id))
                );
            }

            cancellationToken.ThrowIfCancellationRequested();

            return _repository.Fetch(id, cancellationToken);
        }

        /// <summary>
        /// Fetches a collection of signed, and verified <see cref="TModel"/>s by <paramref name="query"/>.
        /// </summary>
        /// <param name="query">
        /// A collection of <see cref="IQuery"/>s to filter <see cref="TModel"/> by.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation requests.
        /// </param>
        /// <returns>
        /// A collection of persisted <see cref="TModel"/> that matches <paramref name="query"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="query"/> is null.
        /// </exception>
        /// <exception cref="OperationCanceledException">
        /// Thrown if <paramref name="cancellationToken"/> is null.
        /// </exception>
        public IAsyncEnumerable<VerifiedData<TModel>> Get(
            IList<IQuery> query,
            CancellationToken cancellationToken
        )
        {
            if (query is null)
            {
                throw _logger.LogException(
                    new ArgumentNullException(nameof(query))
                );
            }

            cancellationToken.ThrowIfCancellationRequested();

            return _repository.Fetch(query, cancellationToken);
        }

        /// <summary>
        /// Gets the primary media type for the client.
        /// </summary>
        /// <returns>
        /// The primary media type.
        /// </returns>
        private RemoteCongressMediaType GetPreferredMediaType() =>
            _codecs.First().GetPreferredMediaType();

        /// <summary>
        /// Fetches the codec for a media type.
        /// </summary>
        /// <param name="mediaType">
        /// The media type to find a codec for
        /// </param>
        /// <returns>
        /// The codec.
        /// </returns>
        /// <exception cref="UnknownBlockMediaTypeException">
        /// Thrown if a codec could not be found for the media type.
        /// </exception>
        private ICodec<TModel> GetTModelCodec(RemoteCongressMediaType mediaType) =>
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