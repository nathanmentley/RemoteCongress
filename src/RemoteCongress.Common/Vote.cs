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
using System.Diagnostics.CodeAnalysis;

namespace RemoteCongress.Common
{
    /// <summary>
    /// A model representing a vote
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class Vote
    {
        /// <summary>
        /// The <see cref="IIdentifiable.Id"/> of the <see cref="Bill"/> being voted on.
        /// </summary>
        public string BillId { get; set; }
        
        /// <summary>
        /// The opinion of the <see cref="Vote"/>. True if voting yes, False if voting no, and null if present.
        /// </summary>
        public bool? Opinion { get; set; }
        
        /// <summary>
        /// A short optional message explaining the <see cref="Opinion"/>.
        /// </summary>
        public string Message { get; set; }
    }
}