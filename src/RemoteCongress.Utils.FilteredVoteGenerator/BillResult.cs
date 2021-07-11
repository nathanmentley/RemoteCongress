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
using System.Linq;
using RemoteCongress.Common;

namespace RemoteCongress.Util.FilteredVoteGenerator
{
    /// <summary>
    /// 
    /// </summary>
    public class BillResult
    {
        private IList<VoteResult> _votes = new List<VoteResult>();

        /// <summary>
        /// 
        /// </summary>
        public string BillId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Bill Bill { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vote">
        /// 
        /// </param>
        public void AddVote(VoteResult vote)
        {
            _votes.Add(vote);
        }

        /// <summary>
        /// 
        /// </summary>
        public bool BillPassed =>
            (ValidYays + InvalidYays) > (ValidNays + InvalidNays);

        /// <summary>
        /// 
        /// </summary>
        public bool BillLegitimatelyPassed =>
            (ValidYays) > (ValidNays);

        /// <summary>
        /// 
        /// </summary>
        public int ValidYays =>
            _votes.Count(vote => 
                !vote.IsInvalid &&
                vote.Opinion == true
            );

        /// <summary>
        /// 
        /// </summary>
        public int ValidNays =>
            _votes.Count(vote => 
                !vote.IsInvalid &&
                vote.Opinion == false
            );

        /// <summary>
        /// 
        /// </summary>
        public int ValidPresents =>
            _votes.Count(vote => 
                !vote.IsInvalid &&
                vote.Opinion is null
            );

        /// <summary>
        /// 
        /// </summary>
        public int InvalidYays =>
            _votes.Count(vote => 
                vote.IsInvalid &&
                vote.Opinion == true
            );

        /// <summary>
        /// 
        /// </summary>
        public int InvalidNays =>
            _votes.Count(vote => 
                vote.IsInvalid &&
                vote.Opinion == false
            );

        /// <summary>
        /// 
        /// </summary>
        public int InvalidPresents =>
            _votes.Count(vote => 
                vote.IsInvalid &&
                vote.Opinion is null
            );
    }
}