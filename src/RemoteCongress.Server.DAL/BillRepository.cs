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
using RemoteCongress.Common;
using RemoteCongress.Common.Repositories;

namespace RemoteCongress.Server.DAL
{
    /// <summary>
    /// An abstraction layer implementing <see cref="IBillRepository"/> that fetches and creates
    ///     <see cref="Bill"/> instances.
    /// </summary>
    public class BillRepository: BaseBlockchainRepository<Bill>, IBillRepository
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="client">
        /// An <see cref="IBlockchainClient"/> implementation to be used to store and fetch <see cref="ISignedData"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="client"/> is null.
        /// </exception>
        public BillRepository(IBlockchainClient client):
            base(client, (id, data) => new Bill(id, data)) {}
    }
}