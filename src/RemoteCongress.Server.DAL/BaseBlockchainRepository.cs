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
using RemoteCongress.Common;
using RemoteCongress.Common.Repositories;
using RemoteCongress.Server.DAL.Exceptions;
using System;
using System.Threading.Tasks;

namespace RemoteCongress.Server.DAL
{
    /// <summary>
    /// An abstraction layer implementing <see cref="IBillRepository"/> that fetches and creates
    ///     <see cref="Bill"/> instances.
    /// </summary>
    /// <remarks>
    /// This implementation of <see cref="IBillRepository"/> of the repository is built for directly connecting to a
    ///     persistence layer. In this case the passed in <see cref="IBlockchainClient"/> is used for the storage,
    ///     and this class is mainly just converting <see cref="ISignedData"/> instances to <see cref="Bill"/> instances.
    /// </remarks>
    public abstract class BaseBlockchainRepository<T>: IImmutableDataRepository<T> where T: BaseBlockModel
    {
        private readonly IBlockchainClient _client;
        private readonly Func<string, ISignedData, T> _creator;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="client">
        /// An <see cref="IBlockchainClient"/> implementation to be used to store and fetch <see cref="ISignedData"/>.
        /// </param>
        /// <param name="creator">
        /// Injected logic to construct an instance of <typeparamref name="T"/> from an Id, and <see cref="ISignedData"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="client"/> is null.
        /// </exception>
        protected BaseBlockchainRepository(
            IBlockchainClient client,
            Func<string, ISignedData, T> creator
        )
        {
            _client = client ??
                throw new ArgumentNullException(nameof(client));

            _creator = creator ??
                throw new ArgumentNullException(nameof(creator));
        }

        /// <summary>
        /// Creates and persist the signed and verified <paramref name="instance"/>.
        /// </summary>
        /// <param name="instance">
        /// A signed and verified instance of type <see cref="Bill"/> to persist.
        /// </param>
        /// <returns>
        /// The persisted <paramref name="instance"/> model.
        /// </returns>
        /// <exception cref="BlockNotStorableException">
        /// Thrown if the <paramref name="model"/> cannot be stored.
        /// </exception>
        public async Task<T> Create(T model)
        {
            var id = await _client.AppendToChain(model);

            if (string.IsNullOrWhiteSpace(id))
                throw new BlockNotStorableException();

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
        /// <returns>
        /// The immutable, and verified <see cref="Bill"/> instance with an <see cref="IIdentifiable.Id"/>
        ///     of <paramref name="id"/>.
        /// </returns>
        /// <exception cref="BlockNotFoundException">
        /// Thrown if a block with an id of <paramref name="id"/> cannot be fetched.
        /// </exception>
        public async Task<T> Fetch(string id)
        {
            var block = await _client.FetchFromChain(id);

            if (block is null)
                throw new BlockNotFoundException();

            //Since the _creator should be calling a ctor of a BaseBlockModel
            // we can be sure that this model's signature hash is valid against 
            // the data.
            return _creator(id, block);
        }
    }
}