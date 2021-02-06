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

namespace RemoteCongress.Common.Repositories.Queries
{
    /// <summary>
    /// An <see cref="IQuery"/> to filter on Public Key.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class PublicKeyQuery: IQuery
    {
        /// <summary>
        /// The Public Key to filter on.
        /// </summary>
        public string PublicKey { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="publicKey">
        /// The Public Key to filter on.
        /// </param>
        public PublicKeyQuery(string publicKey)
        {
            if (string.IsNullOrWhiteSpace(publicKey))
            {
                throw new ArgumentNullException(nameof(publicKey));
            }

            PublicKey = publicKey;
        }
    }
}