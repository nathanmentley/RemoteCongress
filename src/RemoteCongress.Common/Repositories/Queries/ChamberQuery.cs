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

using System;
using System.Diagnostics.CodeAnalysis;

namespace RemoteCongress.Common.Repositories.Queries
{
    /// <summary>
    /// An <see cref="IQuery"/> to filter on Chamber.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ChamberQuery: IQuery
    {
        /// <summary>
        /// The Chamber to filter on.
        /// </summary>
        public string Chamber { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="chamber">
        /// The Chamber to filter on.
        /// </param>
        public ChamberQuery(string chamber)
        {
            if (string.IsNullOrWhiteSpace(chamber))
            {
                throw new ArgumentNullException(nameof(chamber));
            }

            Chamber = chamber;
        }
    }
}