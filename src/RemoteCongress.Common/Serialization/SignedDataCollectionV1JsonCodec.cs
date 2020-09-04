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
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteCongress.Common.Serialization
{
    /// <summary>
    /// An <see cref="ICodec"/> for a version 1 json representation of a collection of <see cref="SignedData"/>.
    /// </summary>
    public class SignedDataCollectionV1JsonCodec: ICodec<IEnumerable<SignedData>>
    {
        public readonly static RemoteCongressMediaType MediaType =
            new RemoteCongressMediaType(
                "application",
                "json",
                "remotecongress.signeddatacollection",
                1
            );

        /// <summary>
        /// Gets the preferred <see cref="RemoteCongressMediaType"/> for the codec.
        /// </summary>
        /// <returns>
        /// The preferred <see cref="RemoteCongressMediaType"/>.
        /// </returns>
        public RemoteCongressMediaType GetPreferredMediaType() =>
            MediaType;

        /// <summary>
        /// Checks if <paramref name="mediaType"/> can be handled by the codec.
        /// </summary>
        /// <param name="mediaType">
        /// The <see cref="RemoteCongressMediaType"/> to check if it can be handled.
        /// </param>
        /// <returns>
        /// True if <paramref name="mediaType"/> can be handled.
        /// </returns>
        public bool CanHandle(RemoteCongressMediaType mediaType) =>
            MediaType.Equals(mediaType);

        /// <summary>
        /// Decodes a <paramref name="data"/> into a <typeparamref name="TData"/>.
        /// </summary>
        /// <param name="mediaType">
        /// The <see cref="RemoteCongressMediaType"/> to decode the data from.
        /// </param>
        /// <param name="data">
        /// The <see cref="Stream"/> to decode dat from.
        /// </param>
        /// <returns>
        /// The <typeparamref name="TData"/> from <paramref name="data"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"/>
        /// Thrown if <paramref name="mediaType"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException"/>
        /// Thrown if <paramref name="data"/> is null.
        /// </exception>
        /// <exception cref="InvalidOperationException"/>
        /// Thrown if the <paramref name="mediaType"/> cannot be handled.
        /// </exception>
        public async Task<IEnumerable<SignedData>> Decode(RemoteCongressMediaType mediaType, Stream data)
        {
            if (mediaType is null)
                throw new ArgumentNullException(nameof(mediaType));

            if (data is null)
                throw new ArgumentNullException(nameof(data));

            if (!CanHandle(mediaType))
                throw new InvalidOperationException(
                    $"{GetType()} cannot handle {mediaType}"
                );

            using StreamReader sr = new StreamReader(data);
            string json = await sr.ReadToEndAsync();

            List<SignedData> ret = new List<SignedData>();

            JObject root = JObject.Parse(json);
            foreach(JObject jObject in (root["data"] as JArray))
            {
                string publicKey = jObject.Value<string>("publicKey");
                string blockContent = jObject.Value<string>("blockContent");
                string blockMediaType = jObject.Value<string>("mediaType");
                IList<byte> signature = new List<byte>();
                JArray signatureJson = jObject["signature"] as JArray;

                if (!(signatureJson is null))
                {
                    foreach(JToken token in signatureJson)
                    {
                        signature.Add(token.Value<byte>());
                    }
                }

                ret.Add(
                    new SignedData(
                        publicKey,
                        blockContent,
                        signature.ToArray(),
                        RemoteCongressMediaType.Parse(blockMediaType)
                    )
                    {
                        Id = jObject["id"].Value<string>()
                    }
                );
            }

            return ret;
        }

        /// <summary>
        /// Encodes <paramref name="data"/> into <paramref name="mediaType"/>.
        /// </summary>
        /// <param name="mediaType">
        /// The <see cref="RemoteCongressMediaType"/> to encode the data to.
        /// </param>
        /// <param name="data">
        /// The data to encode.
        /// </param>
        /// <returns>
        /// A <see cref="Stream"/> containing the encoded data.
        /// </returns>
        /// <exception cref="ArgumentNullException"/>
        /// Thrown if <paramref name="mediaType"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException"/>
        /// Thrown if <paramref name="data"/> is null.
        /// </exception>
        /// <exception cref="InvalidOperationException"/>
        /// Thrown if the <paramref name="mediaType"/> cannot be handled.
        /// </exception>
        public Task<Stream> Encode(RemoteCongressMediaType mediaType, IEnumerable<SignedData> data)
        {
            if (mediaType is null)
                throw new ArgumentNullException(nameof(mediaType));

            if (data is null)
                throw new ArgumentNullException(nameof(data));

            if (!CanHandle(mediaType))
                throw new InvalidOperationException(
                    $"{GetType()} cannot handle {mediaType}"
                );

            JArray records = new JArray();

            foreach(SignedData signedData in data)
            {
                JArray signature = new JArray();

                foreach(byte signatureByte in signedData.Signature)
                {
                    signature.Add(signatureByte);
                }

                JObject record = new JObject()
                {
                    ["id"] = signedData.Id,
                    ["publicKey"] = signedData.PublicKey,
                    ["blockContent"] = signedData.BlockContent,
                    ["signature"] = signature,
                    ["mediaType"] = signedData.MediaType.ToString()
                };

                records.Add(record);
            }

            JObject jObject = new JObject()
            {
                ["count"] = records.Count,
                ["data"] = records
            };

            byte[] jsonBytes = Encoding.UTF8.GetBytes(jObject.ToString());

            return Task.FromResult(new MemoryStream(jsonBytes) as Stream);
        }
    }
}