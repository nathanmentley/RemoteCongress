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
using System.Collections.Generic;
using System.Linq;
using RemoteCongress.Common;

namespace RemoteCongress.Util.FilteredVoteGenerator
{
    /// <summary>
    /// 
    /// </summary>
    public class PageModel
    {
        /// <summary>
        /// The <see cref="BillResult"/>s loaded for this page model to render.
        /// </summary>
        public IEnumerable<BillResult> Bills { get; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Member> IllegitamteMembers { get; }

        /// <summary>
        /// 
        /// </summary>
        public PageModel(IEnumerable<BillResult> bills, IEnumerable<Member> illegitamteMembers)
        {
            Bills = bills?.OrderBy(bill => bill.Bill.Code) ??
                throw new ArgumentNullException(nameof(bills));

            IllegitamteMembers = illegitamteMembers ??
                throw new ArgumentNullException(nameof(illegitamteMembers));
        }
    }
}