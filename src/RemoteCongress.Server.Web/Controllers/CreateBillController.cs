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
    /// Exposes an endpoint to persist <see cref="Bill"/>s.
    /// </summary>
    [ApiController]
    [Route("bill")]
    public class CreateBillController
    {
        private readonly ILogger _logger;
        private readonly IBillRepository _billRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="billRepository">
        /// An <see cref="IBillRepository"/> instance.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="billRepository"/> is null.
        /// </exception>
        public CreateBillController(
            ILogger<CreateBillController> logger,
            IBillRepository billRepository
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
        /// Persists a <see cref="Bill"/>.
        /// </summary>
        /// <param name="bill">
        /// The <see cref="Bill"/> to persist.
        /// </param>
        /// <returns>
        /// The persisted, signed, and validiated <see cref="Bill"/>.
        /// </returns>
        [HttpPost]
        public async Task<Bill> Post([FromBody] Bill bill, CancellationToken cancellationToken)
        {
            Validate(bill, cancellationToken);

            _logger.LogTrace(
                "{controller}.{endpoint} called with {bill}",
                nameof(CreateBillController),
                nameof(Post),
                bill
            );

            return await _billRepository.Create(bill, cancellationToken);
        }

        /// <summary>
        /// Ensures that a create bill request is valid.
        /// </summary>
        /// <param name="bill">
        /// A <see cref="Bill"/> to persist.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="bill"/> is null.
        /// </exception>
        /// <exception cref="OperationCanceledException">
        /// Thrown if <paramref name="cancellationToken"/> is null.
        /// </exception>
        private void Validate(Bill bill, CancellationToken cancellationToken)
        {
            if (bill is null)
                throw _logger.LogException(
                    LogLevel.Debug,
                    new MissingBodyException()
                );

            cancellationToken.ThrowIfCancellationRequested();
        }
    }
}