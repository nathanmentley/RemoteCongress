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
namespace RemoteCongress.Server.DAL.IpfsBlockchainDb
{
    /// <summary>
    /// Configuration data for 
    /// </summary>
    public class IpfsBlockchainConfig
    {
        /// <summary>
        /// The ending <see cref="Block.Id"/>  of the <see cref="Blockchain" />
        /// </summary>
        public string LastBlockId { get; set; }

        /// <summary>
        /// The ipfs node password
        /// </summary>
        public string Password { get; set; }
    }
}