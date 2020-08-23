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
using RemoteCongress.Common.Exceptions;
using RemoteCongress.Common.Logging;
using RemoteCongress.Common.Serialization;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Common.Repositories
{
    /// <summary>
    /// </summary>
    public class ImmutableDataRepository<TData>: IImmutableDataRepository<TData>
    {
        private readonly ILogger<IImmutableDataRepository<TData>> _logger;
        private readonly IDataClient _client;
        private readonly ICodec<TData> _codec;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">
        /// An <see cref="ILogger"/> instance to log against.
        /// </param>
        /// <param name="client">
        /// A <see cref="IDataClient"/> instance to use to communicate with the server.
        /// </param>
        /// <param name="codec">
        /// 
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="config"/> is null.
        /// </excpetion>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="httpClient"/> is null.
        /// </excpetion>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="builder"/> is null.
        /// </excpetion>
        public ImmutableDataRepository(
            ILogger<IImmutableDataRepository<TData>> logger,
            IDataClient client,
            ICodec<TData> codec
        )
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));

            _client = client ??
                throw _logger.LogException(
                    LogLevel.Debug,
                    new ArgumentNullException(nameof(client))
                );

            _codec = codec ??
                throw _logger.LogException(
                    LogLevel.Debug,
                    new ArgumentNullException(nameof(codec))
                );
        }

        /// <summary>
        /// Creates and persist the signed and verified <paramref name="instance"/>.
        /// </summary>
        /// <param name="instance">
        /// A signed and verified instance of type <see cref="Bill"/> to persist.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation requests.
        /// </param>
        /// <returns>
        /// The persisted <paramref name="instance"/> model.
        /// </returns>
        /// <exception cref="BlockNotStorableException">
        /// Thrown if the <paramref name="model"/> cannot be stored.
        /// </exception>
        /// <exception cref="OperationCanceledException">
        /// Thrown if the <paramref name="cancellationToken"/> is cancelled.
        /// </exception>
        public async Task<VerifiedData<TData>> Create(VerifiedData<TData> model, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            string id = await _client.AppendToChain(model, cancellationToken);

            if (string.IsNullOrWhiteSpace(id))
                throw _logger.LogException(
                    LogLevel.Debug,
                    new BlockNotStorableException()
                );

            return new VerifiedData<TData>(id, model, model.Data);
        }

        /// <summary>
        /// Fetches a persisted instance of <see cref="Bill"/> that has an <see cref="IIdentifiable.Id"/> that
        ///     matches <paramref name="id"/>.
        /// </summary>
        /// <param name="id">
        /// The unique <see cref="IIdentifiable.Id"/> of an <typeparamref name="TBlock"/> instance to fetch.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation requests.
        /// </param>
        /// <returns>
        /// The immutable, and verified <see cref="Bill"/> instance with an <see cref="IIdentifiable.Id"/>
        ///     of <paramref name="id"/>.
        /// </returns>
        /// <exception cref="BlockNotFoundException">
        /// Thrown if a block with an id of <paramref name="id"/> cannot be fetched.
        /// </exception>
        /// <exception cref="OperationCanceledException">
        /// Thrown if the <paramref name="cancellationToken"/> is cancelled.
        /// </exception>
        public async Task<VerifiedData<TData>> Fetch(string id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            ISignedData block = await _client.FetchFromChain(id, cancellationToken);

            if (block is null)
                throw _logger.LogException(
                    LogLevel.Debug,
                    new BlockNotFoundException()
                );

            if (!_codec.CanHandle(block.MediaType))
                throw _logger.LogException(
                    LogLevel.Debug,
                    new UnknownBlockMediaTypeException()
                );

            TData data = await _codec.DecodeFromString(block.MediaType, block.BlockContent);

            return new VerifiedData<TData>(id, block, data);
        }
    }
}