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
using Avro.IO;
using Microsoft.Extensions.Logging;
using System;

namespace RemoteCongress.Common.Serialization
{
    /// <summary>
    /// An <see cref="ICodec{TData}"/> for a version 1 avro representation of a <see cref="SignedData"/>.
    /// </summary>
    public class SignedDataV1AvroCodec: BaseAvroCodec<SignedData>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">
        /// An <see cref="ILogger"/> instance to log against.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="logger"/> is null.
        /// </exception>
        public SignedDataV1AvroCodec(ILogger<SignedDataV1AvroCodec> logger):
            base(logger)
        {
        }

        /// <summary>
        /// The <see cref="RemoteCongressMediaType"/> handled by this codec.
        /// </summary>
        public readonly static RemoteCongressMediaType MediaType =
            new RemoteCongressMediaType(
                "application",
                "avro",
                "remotecongress.signeddata",
                1
            );

        /// <summary>
        /// Gets the preferred <see cref="RemoteCongressMediaType"/> for the codec.
        /// </summary>
        /// <returns>
        /// The preferred <see cref="RemoteCongressMediaType"/>.
        /// </returns>
        public override RemoteCongressMediaType GetPreferredMediaType() =>
            MediaType;

        /// <summary>
        /// Decodes a <paramref name="decoder"/> into a <see cref="SignedData"/>.
        /// </summary>
        /// <param name="mediaType">
        /// The <see cref="RemoteCongressMediaType"/> to decode the data from.
        /// </param>
        /// <param name="decoder">
        /// The <see cref="Decoder"/> to decode data from.
        /// </param>
        /// <returns>
        /// The <see cref="SignedData"/> from <paramref name="decoder"/>.
        /// </returns>
        protected override SignedData DecodeAvro(
            RemoteCongressMediaType mediaType,
            Decoder decoder
        )
        {
            string id = decoder.ReadString();
            string publicKey = decoder.ReadString();
            string blockContent = decoder.ReadString();
            string blockMediaType = decoder.ReadString();
            byte[] signature =  decoder.ReadBytes();

            return new SignedData(
                publicKey,
                blockContent,
                signature,
                RemoteCongressMediaType.Parse(blockMediaType)
            )
            {
                Id = id
            };
        }

        /// <summary>
        /// Encodes <paramref name="data"/> into <paramref name="mediaType"/>.
        /// </summary>
        /// <param name="encoder">
        /// The <see cref="Encoder"/> to encode data to.
        /// </param>
        /// <param name="mediaType">
        /// The <see cref="RemoteCongressMediaType"/> to encode the data to.
        /// </param>
        /// <param name="data">
        /// The data to encode.
        /// </param>
        protected override void EncodeAvro(
            Encoder encoder,
            RemoteCongressMediaType mediaType,
            SignedData data
        )
        {
            encoder.WriteString(data.Id ?? string.Empty);
            encoder.WriteString(data.PublicKey);
            encoder.WriteString(data.BlockContent);
            encoder.WriteString(data.MediaType.ToString());
            encoder.WriteBytes(data.Signature);
        }
    }
}