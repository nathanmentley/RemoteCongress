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
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Utils.DataSeeder
{
    /// <summary>
    /// An interface that abstracts the generation of key pairs.
    /// </summary>
    public interface IKeyGenerator
    {
        /// <summary>
        /// Generates a public and private key pair.
        /// </summary>
        /// <param name="bit">
        /// How many bits should the key be.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation.
        /// </param>
        Task<(string privateKey, string publicKey)> GenerateKeys(
            int bit,
            CancellationToken cancellationToken = default
        );
    }
}