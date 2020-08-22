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

namespace RemoteCongress.Common
{
    /// <summary>
    /// </summary>
    public class RemoteCongressMediaType
    {
        /// <summary>
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// </summary>
        public string SubType { get; }

        /// <summary>
        /// </summary>
        public string Structure { get; }

        /// <summary>
        /// </summary>
        public int Version { get; }

        /// <summary>
        /// </summary>
        /// <param name="type">
        /// </param>
        /// <param name="subtype">
        /// </param>
        /// <param name="structure">
        /// </param>
        /// <param name="version">
        /// </param>
        public RemoteCongressMediaType(
            string type,
            string subType,
            string structure,
            int version
        )
        {
            Type = type;
            SubType = subType;
            Structure = structure;
            Version = version;
        }

        public override bool Equals(object obj) =>
            obj is RemoteCongressMediaType &&
            string.Equals(ToString(), obj.ToString(), StringComparison.OrdinalIgnoreCase);

        public override int GetHashCode() =>
            ToString().ToLower().GetHashCode();

        public override string ToString() =>
            $"{Type}/{SubType}; structure={Structure}; version={Version}";
    }
}