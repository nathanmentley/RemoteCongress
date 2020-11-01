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
using RemoteCongress.Common.Repositories.Queries;
using RemoteCongress.Common.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Common.Repositories
{
    /// <summary>
    /// An immutable data repository for <see cref="TData"/>.
    /// </summary>
    public class ImmutableDataRepository<TData>: IImmutableDataRepository<TData>
    {
        /// <summary>
        /// An <see cref="ILogger"/> instance to log against.
        /// </summary>
        private readonly ILogger<IImmutableDataRepository<TData>> _logger;

        /// <summary>
        /// An <see cref="IDataClient"/> to interact with data against.
        /// </summary>
        private readonly IDataClient _client;

        /// <summary>
        /// A collection of <see cref="ICodec{TData}"/>s to use to decode data.
        /// </summary>
        private readonly IEnumerable<ICodec<TData>> _codecs;

        /// <summary>
        /// 
        /// </summary>
        private readonly IQueryProcessor<TData> _queryProcessor;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">
        /// An <see cref="ILogger"/> instance to log against.
        /// </param>
        /// <param name="client">
        /// A <see cref="IDataClient"/> instance to use to communicate with the data store.
        /// </param>
        /// <param name="codecs">
        /// <see cref="ICodec"/>s for <typeparamref name="TData"/> to process block content.
        /// </param>
        /// <param name="queryProcessor">
        /// <see cref="IQueryProcessor{TData}"/> to filter <typeparamref name="TData"/> on for queries.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="logger"/> is null.
        /// </excpetion>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="client"/> is null.
        /// </excpetion>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="codec"/> is null.
        /// </excpetion>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="queryProcessor"/> is null.
        /// </excpetion>
        public ImmutableDataRepository(
            ILogger<IImmutableDataRepository<TData>> logger,
            IDataClient client,
            IEnumerable<ICodec<TData>> codecs,
            IQueryProcessor<TData> queryProcessor
        )
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));

            _client = client ??
                throw _logger.LogException(
                    new ArgumentNullException(nameof(client))
                );

            _codecs = codecs ??
                throw _logger.LogException(
                    new ArgumentNullException(nameof(codecs))
                );

            _queryProcessor = queryProcessor ??
                throw _logger.LogException(
                    new ArgumentNullException(nameof(queryProcessor))
                );
        }

        /// <summary>
        /// Creates and persist the signed and verified <paramref name="instance"/>.
        /// </summary>
        /// <param name="instance">
        /// A signed and verified instance of type <typeparamref cref="TData"/> to persist.
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
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="model"/> is null.
        /// </exception>
        public async Task<VerifiedData<TData>> Create(
            VerifiedData<TData> model,
            CancellationToken cancellationToken
        )
        {
            if (model is null)
            {
                throw _logger.LogException(
                    new ArgumentNullException(nameof(model))
                );
            }

            cancellationToken.ThrowIfCancellationRequested();

            string id = await _client.AppendToChain(model, cancellationToken);

            if (string.IsNullOrWhiteSpace(id))
            {
                throw _logger.LogException(
                    new BlockNotStorableException()
                );
            }

            return new VerifiedData<TData>(id, model, model.Data);
        }

        /// <summary>
        /// Fetches a persisted instance of <typeparamref name="TData"/> that has an <see cref="IIdentifiable.Id"/> that
        ///     matches <paramref name="id"/>.
        /// </summary>
        /// <param name="id">
        /// The unique <see cref="IIdentifiable.Id"/> of an <typeparamref name="TBlock"/> instance to fetch.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation requests.
        /// </param>
        /// <returns>
        /// The immutable, and verified <typeparamref name="TData"/> instance with an <see cref="IIdentifiable.Id"/>
        ///     of <paramref name="id"/>.
        /// </returns>
        /// <exception cref="BlockNotFoundException">
        /// Thrown if a block with an id of <paramref name="id"/> cannot be fetched.
        /// </exception>
        /// <exception cref="UnknownBlockMediaTypeException">
        /// Thrown if a block has a <see cref="RemoteCongressMediaType"/> cannot be decoded.
        /// </exception>
        /// <exception cref="OperationCanceledException">
        /// Thrown if the <paramref name="cancellationToken"/> is cancelled.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="id"/> is null.
        /// </exception>
        public async Task<VerifiedData<TData>> Fetch(string id, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw _logger.LogException(
                    new ArgumentNullException(nameof(id))
                );
            }

            cancellationToken.ThrowIfCancellationRequested();

            ISignedData block = await _client.FetchFromChain(id, cancellationToken);

            if (block is null)
            {
                throw _logger.LogException(
                    new BlockNotFoundException()
                );
            }

            ICodec<TData> codec = _codecs.FirstOrDefault(
                codec => codec.CanHandle(block.MediaType)
            );

            if (codec is null)
            {
                throw _logger.LogException(
                    new UnknownBlockMediaTypeException()
                );
            }

            TData data = await codec.DecodeFromString(block.MediaType, block.BlockContent);

            return new VerifiedData<TData>(id, block, data);
        }

        /// <summary>
        /// Fetches all matching verified data in the form of <see cref="ISignedData"/> from the blockchain.
        /// </summary>
        /// <param name="query">
        /// The query to pull data by.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation requests.
        /// </param>
        /// <returns>
        /// An <see cref="ISignedData"/> instance containing the block data.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="query"/> is null.
        /// </exception>
        public async IAsyncEnumerable<VerifiedData<TData>> Fetch(
            IList<IQuery> query,
            [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            if (query is null)
            {
                throw _logger.LogException(
                    new ArgumentNullException(nameof(query))
                );
            }

            cancellationToken.ThrowIfCancellationRequested();

            await foreach(ISignedData block in _client.FetchAllFromChain(query, cancellationToken))
            {
                if (block is SignedData signedData)
                {
                    ICodec<TData> codec = _codecs.FirstOrDefault(
                        codec => codec.CanHandle(block.MediaType)
                    );

                    if (codec is null)
                    {
                        continue;
                    }

                    TData data = await codec.DecodeFromString(block.MediaType, block.BlockContent);

                    if (!_queryProcessor.BlockMatchesQuery(query, signedData, data))
                    {
                        continue;
                    }

                    yield return new VerifiedData<TData>(signedData.Id, block, data);
                }
            }
        }
    }
}