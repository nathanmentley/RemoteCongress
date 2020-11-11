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
using Microsoft.Extensions.Logging;
using RemoteCongress.Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoteCongress.Common.Repositories.Queries
{
    /// <summary>
    /// Query processing logic for <see cref="Vote"/>s.
    /// </summary>
    public class VoteQueryProcessor: IQueryProcessor<Vote>
    {
        private readonly ILogger<VoteQueryProcessor> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">
        /// An <see cref="ILogger"/> to use for logging.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="logger"/> is null.
        /// </exception>
        public VoteQueryProcessor(ILogger<VoteQueryProcessor> logger)
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query">
        /// 
        /// </param>
        /// <param name="signedData">
        /// 
        /// </param>
        /// <param name="data">
        /// 
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="query"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="signedData"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="data"/> is null.
        /// </exception>
        public bool BlockMatchesQuery(IEnumerable<IQuery> query, SignedData signedData, Vote data)
        {
            if (query is null)
            {
                throw _logger.LogException(new ArgumentNullException(nameof(query)));
            }

            if (signedData is null)
            {
                throw _logger.LogException(new ArgumentNullException(nameof(signedData)));
            }

            if (data is null)
            {
                throw _logger.LogException(new ArgumentNullException(nameof(data)));
            }

            return !query.Any(clause => !BlockMatchesQuery(clause, signedData, data));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query">
        /// 
        /// </param>
        /// <param name="signedData">
        /// 
        /// </param>
        /// <param name="data">
        /// 
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        private static bool BlockMatchesQuery(IQuery query, SignedData signedData, Vote data) =>
            query switch {
                null =>
                    true,
                NullQuery _ =>
                    true,
                PublicKeyQuery publicKey =>
                    string.Equals(publicKey.PublicKey, signedData.PublicKey, StringComparison.Ordinal),
                BillIdQuery billIdQuery =>
                    string.Equals(billIdQuery.BillId, data.BillId, StringComparison.OrdinalIgnoreCase),
                OpinionQuery opinionQuery =>
                    data.Opinion == opinionQuery.Opinion,
                _ =>
                    false
            };
    }
}