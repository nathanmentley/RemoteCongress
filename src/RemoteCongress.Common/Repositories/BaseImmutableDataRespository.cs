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
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Common.Repositories
{
    /// <summary>
    /// </summary>
    public abstract class BaseImmutableDataRepository<T>: IImmutableDataRepository<T> where T: BaseBlockModel
    {
        private readonly ILogger _logger;
        private readonly IDataClient _client;
        private readonly Func<string, ISignedData, T> _creator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">
        /// An <see cref="ILogger"/> instance to log against.
        /// </param>
        /// <param name="client">
        /// A <see cref="IDataClient"/> instance to use to communicate with the server.
        /// </param>
        /// <param name="creator">
        /// Injected logic to construct an instance of <typeparamref name="T"/> from an Id, and <see cref="ISignedData"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="config"/> is null.
        /// </excpetion>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="httpClient"/> is null.
        /// </excpetion>
        protected BaseImmutableDataRepository(
            ILogger logger,
            IDataClient client,
            Func<string, ISignedData, T> creator
        )
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));

            _client = client ??
                throw _logger.LogException(
                    LogLevel.Debug,
                    new ArgumentNullException(nameof(client))
                );

            _creator = creator ??
                throw _logger.LogException(
                    LogLevel.Debug,
                    new ArgumentNullException(nameof(creator))
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
        public async Task<T> Create(T model, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            string id = await _client.AppendToChain(model, cancellationToken);

            if (string.IsNullOrWhiteSpace(id))
                throw _logger.LogException(
                    LogLevel.Debug,
                    new BlockNotStorableException()
                );

            //Since the _creator should be calling a ctor of a BaseBlockModel
            // we can be sure that this model's signature hash is valid against 
            // the data.
            return _creator(id, model);
        }

        /// <summary>
        /// Fetches a persisted instance of <see cref="Bill"/> that has an <see cref="IIdentifiable.Id"/> that
        ///     matches <paramref name="id"/>.
        /// </summary>
        /// <param name="id">
        /// The unique <see cref="IIdentifiable.Id"/> of an <typeparamref name="T"/> instance to fetch.
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
        public async Task<T> Fetch(string id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            ISignedData block = await _client.FetchFromChain(id, cancellationToken);

            if (block is null)
                throw _logger.LogException(
                    LogLevel.Debug,
                    new BlockNotFoundException()
                );

            //Since the _creator should be calling a ctor of a BaseBlockModel
            // we can be sure that this model's signature hash is valid against 
            // the data.
            return _creator(id, block);
        }
    }
}