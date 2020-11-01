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
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RemoteCongress.Common.Repositories.Queries
{
    /// <summary>
    /// Query processing logic for <see cref="Vote"/>s.
    /// </summary>
    public class VoteQueryProcessor: IQueryProcessor<Vote>
    {
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
        public bool BlockMatchesQuery(IList<IQuery> query, SignedData signedData, Vote data)
        {
            foreach(IQuery clause in query)
            {
                bool result = clause switch {
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

                if (!result)
                {
                    return false;
                }
            }

            return true;
        }
    }
}