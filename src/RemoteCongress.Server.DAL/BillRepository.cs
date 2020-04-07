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
using System;
using System.Threading.Tasks;
using RemoteCongress.Common;
using RemoteCongress.Common.Repositories;

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
    public class BillRepository: IBillRepository
    {
        private readonly IBlockchainClient _client;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="client">
        /// An <see cref="IBlockchainClient"/> implementation to be used to store and fetch <see cref="ISignedData"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="client"/> is null.
        /// </exception>
        public BillRepository(IBlockchainClient client)
        {
            _client = client ??
                throw new ArgumentNullException(nameof(client));
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
        public async Task<Bill> Create(Bill bill)
        {
            // store the bill in whatever blockchain stroage is configured in the app
            var id = await _client.AppendToChain(bill);

            // Create a new bill with the id we just got back.
            return new Bill(id, bill);  //by creating a new instance of Bill we're re validating that the data is signed.
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
        public async Task<Bill> Fetch(string id) =>
            //fetch a a bill from it's id.
            new Bill(id, await _client.FetchFromChain(id)); //Since we're creating an instance of bill,
                                                            // we're revaliding the signature before returning it.
    }
}