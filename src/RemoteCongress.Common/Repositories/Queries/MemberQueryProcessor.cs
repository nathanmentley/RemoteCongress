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
    public class MemberQueryProcessor: IQueryProcessor<Member>
    {
        private readonly ILogger<MemberQueryProcessor> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">
        /// An <see cref="ILogger"/> to use for logging.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="logger"/> is null.
        /// </exception>
        public MemberQueryProcessor(ILogger<MemberQueryProcessor> logger)
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Tests if a block defined by <paramref name="data"/> and <paramref name="signedData"/> mataches everything defined <paramref name="query"/>.
        /// </summary>
        /// <param name="query">
        /// A collection of <see cref="IQuery"/>s to filter on.
        /// </param>
        /// <param name="signedData">
        /// The <see cref="SignedData"/> to test against <paramref name="query"/> against.
        /// </param>
        /// <param name="data">
        /// The <see cref="Member"/> to test against <paramref name="query"/> against.
        /// </param>
        /// <returns>
        /// <list>
        ///     <item>true, if the block matches everything in <paramref name="query"/>.</item>
        ///     <item>false, if the block does not matches everything in <paramref name="query"/>.</item>
        /// </list>
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
        public bool BlockMatchesQuery(IEnumerable<IQuery> query, SignedData signedData, Member data)
        {
            if (query is null)
            {
                throw _logger.LogException(
                    new ArgumentNullException(nameof(query)),
                    LogLevel.Debug
                );
            }

            if (signedData is null)
            {
                throw _logger.LogException(
                    new ArgumentNullException(nameof(signedData)),
                    LogLevel.Debug
                );
            }

            if (data is null)
            {
                throw _logger.LogException(
                    new ArgumentNullException(nameof(data)),
                    LogLevel.Debug
                );
            }

            return !query.Any(clause => !BlockMatchesQuery(clause, signedData, data));
        }

        /// <summary>
        /// Tests if a block defined by <paramref name="data"/> and <paramref name="signedData"/> mataches <paramref name="query"/>.
        /// </summary>
        /// <param name="query">
        /// An <see cref="IQuery"/> to filter on.
        /// </param>
        /// <param name="signedData">
        /// The <see cref="SignedData"/> to test against <paramref name="query"/> against.
        /// </param>
        /// <param name="data">
        /// The <see cref="Member"/> to test against <paramref name="query"/> against.
        /// </param>
        /// <returns>
        /// <list>
        ///     <item>true, if the block matches <paramref name="query"/>.</item>
        ///     <item>false, if the block does not matches <paramref name="query"/>.</item>
        /// </list>
        /// </returns>
        private static bool BlockMatchesQuery(IQuery query, SignedData signedData, Member data) =>
            query switch {
                null =>
                    true,
                NullQuery _ =>
                    true,
                PublicKeyQuery publicKey =>
                    string.Equals(publicKey.PublicKey, signedData.PublicKey, StringComparison.Ordinal),
                BillIdQuery _ =>
                    false,
                OpinionQuery _ =>
                    false,
                _ =>
                    false
            };
    }
}