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

namespace RemoteCongress.Common.Repositories.Queries
{
    /// <summary>
    /// Query processing logic for <see cref="Vote"/>s.
    /// </summary>
    public class BillQueryProcessor: IQueryProcessor<Bill>
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
        public bool BlockMatchesQuery(IList<IQuery> query, SignedData signedData, Bill data)
        {
            bool result = true;

            foreach(IQuery clause in query)
            {
                result &= clause switch {
                    NullQuery _ =>
                        true,
                    PublicKeyQuery publicKey =>
                        string.Equals(publicKey.PublicKey, signedData.PublicKey, StringComparison.Ordinal),
                    BillIdQuery billIdQuery =>
                        string.Equals(billIdQuery.BillId, billIdQuery.BillId, StringComparison.OrdinalIgnoreCase),
                    OpinionQuery _ =>
                        false,
                    _ =>
                        false
                };

                if (!result)
                {
                    break;
                }
            }

            return result;
        }
    }
}