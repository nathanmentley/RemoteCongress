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

namespace RemoteCongress.Common.Repositories.Queries
{
    /// <summary>
    /// An <see cref="IQuery"/> to filter on Opinion.
    /// </summary>
    public class OpinionQuery: IQuery
    {
        /// <summary>
        /// The opinion to filter on.
        /// </summary>
        public bool Opinion { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="opinion">
        /// The opinion to filter on.
        /// </param>
        public OpinionQuery(bool opinion)
        {
            Opinion = opinion;
        }
    }
}