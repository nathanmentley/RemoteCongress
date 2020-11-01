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
using RemoteCongress.Common.Repositories.Queries;
using RemoteCongress.Server.Web.Exceptions;
using RemoteCongress.Server.Web.ModelBinders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Server.Web.Controllers.Base
{
    /// <summary>
    /// Exposes an endpoint to fetch a <see cref="TModel"/>.
    /// </summary>
    public abstract class BaseFetchCollectionController<TModel>
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
        /// Thrown if <paramref name="logger"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="repository"/> is null.
        /// </exception>
        protected BaseFetchCollectionController(
            ILogger<BaseFetchCollectionController<TModel>> logger,
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
        /// Fetches all <see cref="TModel"/>s.
        /// </summary>
        /// <returns>
        /// The persisted, signed, and validiated <see cref="TModel"/>s.
        /// </returns>
        [HttpGet]
        public async Task<IEnumerable<VerifiedData<TModel>>> Get(
            [BuildFromQuery] IList<IQuery> query,
            CancellationToken cancellationToken
        )
        {
            Validate(query, cancellationToken);

            _logger.LogDebug(
                "{controller}.{endpoint}",
                GetType(),
                nameof(Get)
            );

            return await _repository.Fetch(query, cancellationToken).ToListAsync();
        }

        private void Validate(IList<IQuery> query, CancellationToken cancellationToken)
        {
            if (query is null)
            {
                throw _logger.LogException(
                    new MissingBodyException()
                );
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }
}