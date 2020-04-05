/*
    PublicVote - A platform for conducting small secure public elections
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
using PublicVote.Common;

namespace PublicVote.Server.Web.Formatters
{
    /// <summary>
    /// Reads and validates a signed <see cref="Vote"/> from the input.
    /// </summary>
    public class VoteInputFormatter: BaseInputFormatter<Vote>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public VoteInputFormatter(): base() {}

        /// <summary>
        /// Converts from a <see cref="SignedData"/> to a <see cref="Vote"/>.
        /// </summary>
        /// <param name="data">
        /// The <see cref="SignedData"/> containing the data to convert.
        /// </param>
        /// <returns>
        /// The validated, and signed <see cref="Vote"/>.
        /// </returns>
        protected override Vote FromSignedData(SignedData data) => new Vote(data);
    }
}