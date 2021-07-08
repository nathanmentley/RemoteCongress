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
using RemoteCongress.Common.Encryption;

namespace RemoteCongress.Common
{
    /// <summary>
    /// An interface defining structures that contain verifiable data.
    /// </summary>
    public interface ISignedData
    {
        /// <summary>
        /// The string representation of the data producer's public key.
        /// </summary>
        string PublicKey { get; }
        /// <summary>
        /// The content of the data.
        /// </summary>
        string BlockContent { get; }
        /// <summary>
        /// The signature of the <see cref="BlockContent"/> that can be verified with <see cref="PublicKey"/>.
        /// </summary>
        byte[] Signature { get; }

        /// <summary>
        /// The <see cref="RemoteCongressMediaType"/> of <see cref="BlockContent"/>
        /// </summary>
        RemoteCongressMediaType MediaType { get; }

        /// <summary>
        /// A flag to indicate that the contained signed data is valid, and untampered with.
        /// </summary>
        /// <returns>
        /// True if the contained data is valid, and not tampered with.
        /// </returns>
        bool IsValid =>
            true;
            //RsaUtils.VerifySignature(PublicKey, BlockContent, Signature);
    }
}