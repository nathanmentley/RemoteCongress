/*
    RemoteCongress - A platform for conducting small secure public elections
    Copyright (C) 2021  Nathan Mentley

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
using RemoteCongress.Server.Api.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Server.Api.Controllers.Base
{
    /// <summary>
    /// Exposes an endpoint to persist <typeparamref name="TModel"/>s.
    /// </summary>
    public abstract class BaseCreateController<TModel>
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
        protected BaseCreateController(
            ILogger<BaseCreateController<TModel>> logger,
            IImmutableDataRepository<TModel> repository
        )
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));

            _repository = repository ??
                throw _logger.LogException(
                    new ArgumentNullException(nameof(repository)),
                    LogLevel.Debug
                );
        }

        /// <summary>
        /// Persists a <typeparamref name="TModel"/>.
        /// </summary>
        /// <param name="model">
        /// The <typeparamref name="TModel"/> to persist.
        /// </param>
        /// <returns>
        /// The persisted, signed, and validiated <typeparamref name="TModel"/>.
        /// </returns>
        [HttpPost]
        public async Task<VerifiedData<TModel>> Post(
            [FromBody] VerifiedData<TModel> model,
            CancellationToken cancellationToken
        )
        {
            Validate(model, cancellationToken);

            _logger.LogDebug(
                "{controller}.{endpoint} called with {model}",
                GetType(),
                nameof(Post),
                model
            );

            return await _repository.Create(model, cancellationToken);
        }

        /// <summary>
        /// Ensures that a create model request is valid.
        /// </summary>
        /// <param name="model">
        /// A <typeparamref name="TModel"/> to persist.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="model"/> is null.
        /// </exception>
        /// <exception cref="OperationCanceledException">
        /// Thrown if <paramref name="cancellationToken"/> is null.
        /// </exception>
        private void Validate(
            VerifiedData<TModel> model,
            CancellationToken cancellationToken
        )
        {
            if (model is null)
            {
                throw _logger.LogException(
                    new MissingBodyException(),
                    LogLevel.Debug
                );
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }
}