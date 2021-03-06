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
using System.Collections.Generic;

namespace RemoteCongress.Common.Repositories.Queries
{
    /// <summary>
    /// Query processing logic for <typeparmref name="TData"/>.
    /// </summary>
    public interface IQueryProcessor<TData>
    {
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
        /// The <typeparamref name="TData"/> to test against <paramref name="query"/> against.
        /// </param>
        /// <returns>
        /// <list>
        ///     <item>true, if the block matches everything in <paramref name="query"/>.</item>
        ///     <item>false, if the block does not matches everything in <paramref name="query"/>.</item>
        /// </list>
        /// </returns>
        bool BlockMatchesQuery(IEnumerable<IQuery> query, SignedData signedData, TData data);
    }
}