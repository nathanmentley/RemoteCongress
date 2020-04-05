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

namespace PublicVote.Server.DAL.Ipfs
{
    /// <summary>
    /// Configuration data for Ipfs.
    /// </summary>
    public class IpfsConfig
    {
        /// <summary>
        /// The url used to connect to Ipfs.
        /// </summary>
        /// <remarks>
        /// This will default to http://localhost:5001/
        /// </remarks>
        public string Url { get; set; } =
            "http://localhost:5001/";
    }
}