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
    /// A class that defines a mime MediaType
    /// </summary>
    public struct RemoteCongressMediaType
    {
        /// <summary>
        /// The key used for the structure parameterr in the media type.
        /// </summary>
        /// <value>
        /// structure
        /// </value>
        private readonly static string StructureKey =
            "structure";
        
        /// <summary>
        /// The key used for the version parameterr in the media type.
        /// </summary>
        /// <value>
        /// version
        /// </value>
        private readonly static string VersionKey =
            "version";

        /// <summary>
        /// The minimum version number a media type can represent
        /// </summary>
        /// <value>
        /// 1
        /// </value>
        private static readonly int MinVersionValue = 1;

        /// <summary>
        /// The mediatype type
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// The mediatype sub-type
        /// </summary>
        public string SubType { get; }

        /// <summary>
        /// The structure defined by the type
        /// </summary>
        public string Structure { get; }

        /// <summary>
        /// The version of the structure defined by the type.
        /// </summary>
        public int Version { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">
        /// The mediatype type
        /// </param>
        /// <param name="subtype">
        /// The mediatype subtype
        /// </param>
        /// <param name="structure">
        /// The mediatype structure
        /// </param>
        /// <param name="version">
        /// The mediatype version
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="type"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="subType"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="structure"/> is null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="version"/> is less than <see cref="MinVersionValue"/>.
        /// </exception>
        public RemoteCongressMediaType(
            string type,
            string subType,
            string structure,
            int version
        )
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (subType is null)
            {
                throw new ArgumentNullException(nameof(subType));
            }

            if (structure is null)
            {
                throw new ArgumentNullException(nameof(structure));
            }

            if (version < MinVersionValue)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(version),
                    version,
                    $"{nameof(version)} cannot be less than {MinVersionValue}"
                );
            }

            Type = type;
            SubType = subType;
            Structure = structure;
            Version = version;
        }

        /// <summary>
        /// Tests if an instance is equal to this instance.
        /// </summary>
        /// <param name="obj">
        /// Instance to compare against
        /// </param>
        /// <returns>
        /// If <paramref name="obj"/> is equal true is returned.
        /// </returns>
        public override bool Equals(object obj) =>
            obj is RemoteCongressMediaType &&
            string.Equals(ToString(), obj.ToString(), StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Fetches a unique hash code for the value of this instance.
        /// </summary>
        public override int GetHashCode() =>
            ToString().ToLower().GetHashCode();

        /// <summary>
        /// Fetches a string representation of this instance.
        /// </summary>
        public override string ToString() =>
            $"{Type}/{SubType}; structure={Structure}; version={Version}";

        /// <summary>
        /// Fetches a <see cref="RemoteCongressMediaType"/> to represent <paramref name="mediaType"/>.
        /// </summary>
        /// <param name="mediaType">
        /// A string mediatype
        /// </param>
        /// <returns>
        /// The <see cref="RemoteCongressMediaType"/> representation
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="mediaType"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="mediaType"/> is invalid.
        /// </exception>
        public static RemoteCongressMediaType Parse(string mediaType)
        {
            if (string.IsNullOrWhiteSpace(mediaType))
            {
                throw new ArgumentNullException(nameof(mediaType));
            }

            IEnumerable<string> parts = mediaType.Split(";").Select(part => part.Trim());

            IEnumerable<string> typeParts = parts.First().Split("/").Select(part => part.Trim());

            if (typeParts.Count() != 2)
            {
                throw new ArgumentException(
                    "invalid media type format",
                    nameof(mediaType)
                );
            }
            
            string type = typeParts.First();
            string subtype = typeParts.Last();
            string structure = string.Empty;
            int version = 0;

            foreach(string param in parts.Skip(1))
            {
                IEnumerable<string> paramParts = param.Split("=").Select(part => part.Trim());

                if (paramParts.Count() != 2)
                {
                    throw new ArgumentException(
                        "invalid media type format",
                        nameof(mediaType)
                    );
                }

                if (string.Equals(paramParts.First(), StructureKey, StringComparison.OrdinalIgnoreCase))
                {
                    structure = paramParts.Last();
                }

                if (string.Equals(paramParts.First(), VersionKey, StringComparison.OrdinalIgnoreCase))
                {
                    version = Convert.ToInt32(paramParts.Last());
                }
            }

            return new RemoteCongressMediaType(type, subtype, structure, version);
        }

        /// <summary>
        /// A <see cref="RemoteCongressMediaType"/> representing no value.
        /// </summary>
        public static RemoteCongressMediaType None =>
            new RemoteCongressMediaType(
                string.Empty,
                string.Empty,
                string.Empty,
                1
            );
    }
}