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
using System.Linq;

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

        public static RemoteCongressMediaType Parse(string mediaType)
        {
            if (string.IsNullOrWhiteSpace(mediaType))
                throw new ArgumentNullException(nameof(mediaType));

            IEnumerable<string> parts = mediaType.Split(";").Select(part => part.Trim());

            IEnumerable<string> typeParts = parts.First().Split("/").Select(part => part.Trim());

            if (typeParts.Count() != 2)
                throw new ArgumentException(
                    "invalid media type format",
                    nameof(mediaType)
                );
            
            string type = typeParts.First();
            string subtype = typeParts.Last();
            string structure = string.Empty;
            int version = 0;

            foreach(string param in parts.Skip(1))
            {
                IEnumerable<string> paramParts = param.Split("=").Select(part => part.Trim());

                if (paramParts.Count() != 2)
                    throw new ArgumentException(
                        "invalid media type format",
                        nameof(mediaType)
                    );

                if (string.Equals(paramParts.First(), "structure", StringComparison.OrdinalIgnoreCase))
                    structure = paramParts.Last();

                if (string.Equals(paramParts.First(), "version", StringComparison.OrdinalIgnoreCase))
                    version = Convert.ToInt32(paramParts.Last());
            }

            return new RemoteCongressMediaType(type, subtype, structure, version);
        }

        public static RemoteCongressMediaType None =>
            new RemoteCongressMediaType(
                string.Empty,
                string.Empty,
                string.Empty,
                0
            );
    }
}