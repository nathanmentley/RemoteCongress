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

namespace RemoteCongress.Server.Web.Controllers.Base
{
    /// <summary>
    /// Exposes an endpoint to fetch a <typeparamref name="TModel"/>.
    /// </summary>
    public class BaseFetchController<TModel>
    {
        private readonly ILogger _logger;
        private readonly IImmutableDataRepository<TModel> _repository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository">
        /// An <see cref="IImmutableDataRepository<TModelData>"/> instance.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="repository"/> is null.
        /// </exception>
        protected BaseFetchController(
            ILogger<BaseFetchController<TModel>> logger,
            IImmutableDataRepository<TModel> repository
        )
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));

            _repository = repository ??
                throw _logger.LogException(
                    new ArgumentNullException(nameof(repository))
                );
        }

        /// <summary>
        /// Fetches a <typeparamref name="TModel"/>.
        /// </summary>
        /// <param name="id">
        /// The <see cref="IIdentifiable.Id"/> of the <typeparamref name="TModel"/> to fetch.
        /// </param>
        /// <returns>
        /// The persisted, signed, and validiated <typeparamref name="TModel"/>.
        /// </returns>
        [HttpGet]
        public async Task<VerifiedData<TModel>> Get(
            [FromRoute] string id,
            CancellationToken cancellationToken
        )
        {
            Validate(id, cancellationToken);

            _logger.LogDebug(
                "{controller}.{endpoint} called with {id}",
                GetType(),
                nameof(Get),
                id
            );

            return await _repository.Fetch(id, cancellationToken);
        }

        /// <summary>
        /// Ensures that a fetch model request is valid.
        /// </summary>
        /// <param name="id">
        /// An id of a <typeparamref name="TModel"/> to fetch.
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
            {
                throw _logger.LogException(
                    new MissingPathParameterException()
                );
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }
}