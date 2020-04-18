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
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;

namespace RemoteCongress.Client
{
    /// <summary>
    /// An abstraction layer implementing <see cref="IBillRepository"/> that fetches and creates
    ///     <see cref="Bill"/> instances.
    /// </summary>
    /// <remarks>
    /// This implementation of <see cref="IBillRepository"/> of the repository is built for connecting over an http
    ///     conntection. It's expecting to send <see cref="SignedData"/> instances to a web server.
    /// </remarks>
    [ExcludeFromCodeCoverage]
    public class BillRepository: BaseHttpRepository<Bill>, IBillRepository
    {
        /// <summary>
        /// The endpoint to hit with the repository.
        /// </summary>
        protected override string Endpoint => "bill";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config">
        /// A <see cref="ClientConfig"/> instance that holds configuration data on connecting to the server.
        /// </param>
        /// <param name="httpClient">
        /// A <see cref="HttpClient"/> instance to use to communicate with the server.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="config"/> is null.
        /// </excpetion>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="httpClient"/> is null.
        /// </excpetion>
        public BillRepository(ClientConfig config, HttpClient httpClient):
            base(config, httpClient, (id, data) => new Bill(id, data)) {}
    }
}