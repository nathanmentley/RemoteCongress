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
using Microsoft.Extensions.Logging;
using RemoteCongress.Common;
using RemoteCongress.Common.Logging;
using RemoteCongress.Common.Repositories;
using RemoteCongress.Server.Web.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Server.Web.Controllers
{
    /// <summary>
    /// Exposes an endpoint to fetch a <see cref="Vote"/>.
    /// </summary>
    [ApiController]
    [Route("vote/{id}")]
    public class FetchVoteController
    {
        private readonly ILogger _logger;
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
            ILogger<FetchVoteController> logger,
            IVoteRepository voteRepository
        )
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));

            _voteRepository = voteRepository ??
                throw _logger.LogException(
                    LogLevel.Debug,
                    new ArgumentNullException(nameof(voteRepository))
                );
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
        public async Task<Vote> Get([FromRoute] string id, CancellationToken cancellationToken)
        {
            Validate(id, cancellationToken);

            _logger.LogTrace(
                "{controller}.{endpoint} called with {id}",
                nameof(FetchVoteController),
                nameof(Get),
                id
            );

            return await _voteRepository.Fetch(id, cancellationToken);
        }

        /// <summary>
        /// Ensures that a fetch vote request is valid.
        /// </summary>
        /// <param name="id">
        /// An id of a <see cref="Vote"/> to fetch.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="id"/> is null.
        /// </exception>
        /// <exception cref="OperationCanceledException">
        /// Thrown if <paramref name="cancellationToken"/> is null.
        /// </exception>
        private void Validate(string id, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw _logger.LogException(
                    LogLevel.Debug,
                    new MissingPathParameterException()
                );

            cancellationToken.ThrowIfCancellationRequested();
        }
    }
}