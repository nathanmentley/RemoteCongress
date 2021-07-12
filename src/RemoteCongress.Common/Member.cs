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
using System.Diagnostics.CodeAnalysis;

namespace RemoteCongress.Common
{
    /// <summary>
    /// A model representing a voting member
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class Member
    {
        /// <summary>
        /// The member's identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The member's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The member's last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The member's seat
        /// </summary>
        public string Seat { get; set; }

        /// <summary>
        /// The Chamber related to this <see cref="Member"/>.
        /// </summary>
        public string Chamber { get; set; }

        /// <summary>
        /// The member's party
        /// </summary>
        public string Party { get; set; }

        /// <summary>
        /// The member's public key
        /// </summary>
        public string PublicKey { get; set; }
    }
}