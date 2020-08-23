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
    /// Exposes an endpoint to fetch a <see cref="Bill"/>.
    /// </summary>
    [ApiController]
    [Route("bill/{id}")]
    public class FetchBillController
    {
        private readonly ILogger _logger;
        private readonly IImmutableDataRepository<Bill> _billRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="billRepository">
        /// An <see cref="IImmutableDataRepository<BillData>"/> instance.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="billRepository"/> is null.
        /// </exception>
        public FetchBillController(
            ILogger<FetchBillController> logger,
            IImmutableDataRepository<Bill> billRepository
        )
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));

            _billRepository = billRepository ??
                throw _logger.LogException(
                    LogLevel.Debug,
                    new ArgumentNullException(nameof(billRepository))
                );
        }

        /// <summary>
        /// Fetches a <see cref="Bill"/>.
        /// </summary>
        /// <param name="id">
        /// The <see cref="IIdentifiable.Id"/> of the <see cref="Bill"/> to fetch.
        /// </param>
        /// <returns>
        /// The persisted, signed, and validiated <see cref="Bill"/>.
        /// </returns>
        [HttpGet]
        public async Task<VerifiedData<Bill>> Get(
            [FromRoute] string id,
            CancellationToken cancellationToken
        )
        {
            Validate(id, cancellationToken);

            _logger.LogTrace(
                "{controller}.{endpoint} called with {id}",
                nameof(FetchBillController),
                nameof(Get),
                id
            );

            return await _billRepository.Fetch(id, cancellationToken);
        }

        /// <summary>
        /// Ensures that a fetch bill request is valid.
        /// </summary>
        /// <param name="id">
        /// An id of a <see cref="Bill"/> to fetch.
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
        private void Validate(
            string id,
            CancellationToken cancellationToken
        )
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