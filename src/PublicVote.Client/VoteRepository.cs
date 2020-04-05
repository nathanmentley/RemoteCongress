/*
    PublicVote - A platform for conducting small secure public elections
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
using PublicVote.Common;
using PublicVote.Common.Repositories;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PublicVote.Client
{
    /// <summary>
    /// An abstraction layer implementing <see cref="IBillRepository"/> that fetches and creates
    ///     <see cref="Bill"/> instances.
    /// </summary>
    /// <remarks>
    /// This implementation of <see cref="IBillRepository"/> of the repository is built for connecting over an http
    ///     conntection. It's expecting to send <see cref="SignedData"/> instances to a web server.
    /// </remarks>
    public class VoteRepository: IVoteRepository
    {
        private readonly static string Endpoint = "vote";
        private readonly HttpRepository _httpRepository;

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
        public VoteRepository(ClientConfig config, HttpClient httpClient)
        {
            if (config is null)
                throw new ArgumentNullException(nameof(config));

            if (httpClient is null)
                throw new ArgumentNullException(nameof(httpClient));

            _httpRepository = new HttpRepository(config, httpClient);
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
        public async Task<Vote> Create(Vote instance)
        {
            var signedData = await _httpRepository.CreateSignedData(
                Endpoint,
                new SignedData(instance)
            );

            return new Vote(signedData.Id, signedData);
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
        public async Task<Vote> Fetch(string id)
        {
            var signedData = await _httpRepository.FetchSignedData(Endpoint, id);

            return new Vote(id, signedData);
        }
    }
}
