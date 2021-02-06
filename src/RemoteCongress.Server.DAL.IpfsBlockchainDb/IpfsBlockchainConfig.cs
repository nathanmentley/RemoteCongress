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
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace RemoteCongress.Server.DAL.IpfsBlockchainDb
{
    /// <summary>
    /// Configuration data for Ipfs
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class IpfsBlockchainConfig
    {
        private readonly static string BaseDirectoryPath = 
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        private readonly static string RelativeDataDirectoryPath =
            ".remote_congress/ipfs";

        /// <summary>
        /// </summary>
        public readonly string AbsoluteDataDirectoryPath =
            Path.Combine(
                BaseDirectoryPath,
                RelativeDataDirectoryPath
            );


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