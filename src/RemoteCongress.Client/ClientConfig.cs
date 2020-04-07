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

namespace RemoteCongress.Client
{
    /// <summary>
    /// Configuration data defining how to connect to the RemoteCongress api server.
    /// </summary>
    public class ClientConfig
    {
        /// <summary>
        /// The hostname of the server running the RemoteCongress Api
        /// </summary>
        public string ServerHostName { get; }
        /// <summary>
        /// Protocol to use to connect to the Api.
        /// </summary>
        /// <remarks>
        /// Currently it's hardcoded to https.
        /// </remarks>
        public string Protocol =>
            "https";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serverHostName">
        /// The hostname of the server running the RemoteCongress Api
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="serverHostName"/> is null.
        /// </exception>
        public ClientConfig(string serverHostName)
        {
            if (string.IsNullOrWhiteSpace(serverHostName))
                throw new ArgumentNullException(nameof(serverHostName));

            ServerHostName = serverHostName;
        }
    }
}