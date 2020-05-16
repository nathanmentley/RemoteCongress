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
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Controllers
{
    /// <summary>
    /// Exposes an endpoint to persist <see cref="Bill"/>s.
    /// </summary>
    [ApiController]
    [Route("bill")]
    public class CreateBillController
    {
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
            IBillRepository billRepository
        ) =>
            _billRepository = billRepository ??
                throw new ArgumentNullException(nameof(billRepository));

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
        public async Task<Bill> Post([FromBody] Bill bill, CancellationToken cancellationToken) =>
            await _billRepository.Create(bill, cancellationToken);
    }
}