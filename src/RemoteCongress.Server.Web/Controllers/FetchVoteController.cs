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
using Microsoft.AspNetCore.Mvc;
using RemoteCongress.Common;
using RemoteCongress.Common.Repositories;
using System;
using System.Threading.Tasks;

namespace RemoteCongress.Controllers
{
    /// <summary>
    /// Exposes an endpoint to fetch a <see cref="Vote"/>.
    /// </summary>
    [ApiController]
    [Route("vote/{id}")]
    public class FetchVoteController
    {
        private readonly IVoteRepository _voteRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="voteRepository">
        /// An <see cref="IVoteRepository"/> instance.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="logger"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="voteRepository"/> is null.
        /// </exception>
        public FetchVoteController(
            IVoteRepository voteRepository
        )
        {
            _voteRepository = voteRepository ??
                throw new ArgumentNullException(nameof(voteRepository));
        }

        /// <summary>
        /// Fetches a <see cref="Vote"/>.
        /// </summary>
        /// <param name="id">
        /// The <see cref="IIdentifiable.Id"/> of the <see cref="Vote"/> to fetch.
        /// </param>
        /// <returns>
        /// The persisted, signed, and validiated <see cref="Vote"/>.
        /// </returns>
        [HttpGet]
        public async Task<Vote> Get([FromRoute] string id) =>
            await _voteRepository.Fetch(id);
    }
}