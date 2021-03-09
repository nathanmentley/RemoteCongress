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
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace RemoteCongress.Common.Serialization
{
    /// <summary>
    /// An <see cref="ICodec{TData}"/> for a version 1 json representation of a collection of <see cref="SignedData"/>.
    /// </summary>
    public class SignedDataCollectionV1JsonCodec: BaseJsonCodec<IEnumerable<SignedData>>
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
        public SignedDataCollectionV1JsonCodec(ILogger<SignedDataCollectionV1JsonCodec> logger):
            base(logger)
        {
        }

        /// <summary>
        /// The <see cref="RemoteCongressMediaType"/> handled by this codec.
        /// </summary>
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
        public override RemoteCongressMediaType GetPreferredMediaType() =>
            MediaType;

        /// <summary>
        /// Decodes a <paramref name="data"/> into a <see cref="SignedData"/> collection.
        /// </summary>
        /// <param name="mediaType">
        /// The <see cref="RemoteCongressMediaType"/> to decode the data from.
        /// </param>
        /// <param name="data">
        /// The <see cref="JToken"/> to decode data from.
        /// </param>
        /// <returns>
        /// The <see cref="SignedData"/> collection from <paramref name="data"/>.
        /// </returns>
        protected override IEnumerable<SignedData> DecodeJson(
            RemoteCongressMediaType mediaType,
            JToken data
        )
        {
            foreach(JObject jObject in (data["data"] as JArray))
            {
                yield return new SignedData(
                    jObject.Value<string>("publicKey"),
                    jObject.Value<string>("blockContent"),
                    Convert.FromBase64String(jObject.Value<string>("signature")),
                    RemoteCongressMediaType.Parse(jObject.Value<string>("mediaType"))
                )
                {
                    Id = jObject["id"].Value<string>()
                };
            }
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
        /// A <see cref="JToken"/> containing the encoded data.
        /// </returns>
        protected override JToken EncodeJson(
            RemoteCongressMediaType mediaType,
            IEnumerable<SignedData> data
        )
        {
            JArray records = new JArray();

            foreach(SignedData signedData in data)
            {
                JObject record = new JObject()
                {
                    ["id"] = signedData.Id,
                    ["publicKey"] = signedData.PublicKey,
                    ["blockContent"] = signedData.BlockContent,
                    ["signature"] = Convert.ToBase64String(signedData.Signature),
                    ["mediaType"] = signedData.MediaType.ToString()
                };

                records.Add(record);
            }

            JObject jObject = new JObject()
            {
                ["count"] = records.Count,
                ["data"] = records
            };

            return jObject;
        }
    }
}