using System;
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
using RemoteCongress.Common.Exceptions;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace RemoteCongress.Common
{
    /// <summary>
    /// A simple data transfer object that contains signed data.
    /// </summary>
    /// <remarks>
    /// This class just contains the signed data. It's not gareneteed to be valid and untampered.
    /// If you're using data in a way you want it to be validated you must convert this to a type
    ///     that inherits from <see cref="BaseBlockModel"/>.
    /// 
    /// This class is meant to be used to pull raw data from the persistence layer or to pull data
    ///     from the api. It should be transfered to a verifiable, and immutable type right away.
    /// </remarks>
    [ExcludeFromCodeCoverage]
    public class SignedData: ISignedData, IIdentifiable
    {
        /// <summary>
        /// The unique identifier of the contained data.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The string representation of the data producer's public key.
        /// </summary>
        public string PublicKey { get; set; }

        /// <summary>
        /// The content of the data.
        /// </summary>
        public string BlockContent { get; set; }

        /// <summary>
        /// The signature of the <see cref="BlockContent"/> that can be verified with <see cref="PublicKey"/>.
        /// </summary>
        public byte[] Signature { get; set; }

        /// <summary>
        /// The <see cref="RemoteCongressMediaType"/> of <see cref="BlockContent"/>
        /// </summary>
        public RemoteCongressMediaType MediaType { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="publicKey">
        /// The string representation of the data producer's public key.
        /// </param>
        /// <param name="blockContent">
        /// The content of the data.
        /// </param>
        /// <param name="signature">
        /// The signature of the <see cref="BlockContent"/> that can be verified with <see cref="PublicKey"/>.
        /// </param>
        /// <param name="mediaType">
        /// The <see cref="RemoteCongressMediaType"/> of <see cref="BlockContent"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="publicKey"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="blockContent"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="signature"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="mediaType"/> is null.
        /// </exception>
        /// <remarks>
        /// The data isn't validated, and could be in an invalid state.
        /// </remarks>
        public SignedData(
            string publicKey,
            string blockContent,
            byte[] signature,
            RemoteCongressMediaType mediaType
        )
        {
            if(string.IsNullOrWhiteSpace(publicKey))
            {
                throw new ArgumentNullException(nameof(publicKey));
            }

            if(string.IsNullOrWhiteSpace(blockContent))
            {
                throw new ArgumentNullException(nameof(blockContent));
            }

            if(signature is null)
            {
                throw new ArgumentNullException(nameof(signature));
            }

            PublicKey = publicKey;
            BlockContent = blockContent;
            Signature = signature.ToArray();
            MediaType = mediaType;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">
        /// An <see cref="ISignedData"/> instance to populate data from.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="data"/> is null.
        /// </exception>
        /// <exception cref="InvalidBlockSignatureException">
        /// Thrown if <paramref name="data"/> contains non verifiable data.
        /// </exception>
        /// <remarks>
        /// Since <paramref name="data"/> is a <see cref="ISignedData"/> instance we validate it before populating
        ///     data from it. So the created <see cref="SignedData"/> instance will be valid when created, but
        ///     since it's mutable it may not stay that way.
        /// </remarks>
        public SignedData(ISignedData data)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (!data.IsValid)
            {
                throw new InvalidBlockSignatureException(
                    $"Invalid signature[{data.Signature}] for content[{data.BlockContent}] " +
                        $"using public key[{data.PublicKey}]"
                );
            }

            PublicKey = data.PublicKey;
            BlockContent = data.BlockContent;
            Signature = data.Signature.ToArray();
            MediaType = data.MediaType;

            if (data is IIdentifiable identifiable)
            {
                Id = identifiable.Id;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>
        /// The <see cref="SignedData"/> is created in an invalid state, and must be populated with valid data.
        /// </remarks>
        public SignedData()
        {
            Id = string.Empty;

            PublicKey = string.Empty;
            BlockContent = string.Empty;
            Signature = new byte[] {};
            MediaType = RemoteCongressMediaType.None;
        }
    }
}