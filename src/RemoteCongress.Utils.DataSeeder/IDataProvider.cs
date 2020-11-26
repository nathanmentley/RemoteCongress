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
using RemoteCongress.Common;
using System.Collections.Generic;
using System.Threading;

namespace RemoteCongress.Utils.DataSeeder
{
    /// <summary>
    /// An interface that defines a type that's able to provide data for seeding
    /// </summary>
    public interface IDataProvider
    {
        /// <summary>
        /// Fetches all <see cref="Member"/>s to seed.
        /// </summary>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> that triggers a cancellation.
        /// </param>
        /// <returns>
        /// A collection of <see cref="Member"/>s to seed.
        /// </returns>
        IAsyncEnumerable<Member> GetMembers(CancellationToken cancellationToken);

        /// <summary>
        /// Fetches all <see cref="Bill"/>s to seed.
        /// </summary>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> that triggers a cancellation.
        /// </param>
        /// <returns>
        /// A collection of <see cref="Bill"/>s to seed.
        /// </returns>
        IAsyncEnumerable<(Bill, string)> GetBills(CancellationToken cancellationToken);

        /// <summary>
        /// Fetches all <see cref="Vote"/>s for a <see cref="Bill"/> to seed.
        /// </summary>
        /// <param name="id">
        /// The unique id of the bill.
        /// </param>
        /// <param name="bill">
        /// The seeded <see cref="Bill"/> wrapped in a <see cref="VerifiedData{TModel}"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> that triggers a cancellation.
        /// </param>
        /// <returns>
        /// A collection of <see cref="Vote"/>s to seed.
        /// </returns>
        IAsyncEnumerable<(Vote vote, string memberPrivateKey, string memberPublicKey)> GetVotes(
            string id,
            VerifiedData<Bill> bill,
            CancellationToken cancellationToken
        );
    }
}