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

namespace RemoteCongress.Common.Serialization
{
    /// <summary>
    /// An <see cref="ICodec{TData}"/> for a version 1 json representation of a <see cref="Vote"/>.
    /// </summary>
    public class VoteV1JsonCodec: BaseJsonCodec<Vote>
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
        public VoteV1JsonCodec(ILogger<VoteV1JsonCodec> logger):
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
                "remotecongress.content.vote",
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
        /// Decodes a <paramref name="data"/> into a <see cref="Vote"/>.
        /// </summary>
        /// <param name="mediaType">
        /// The <see cref="RemoteCongressMediaType"/> to decode the data from.
        /// </param>
        /// <param name="data">
        /// The <see cref="JToken"/> to decode data from.
        /// </param>
        /// <returns>
        /// The <see cref="Vote"/> from <paramref name="data"/>.
        /// </returns>
        protected override Vote DecodeJson(RemoteCongressMediaType mediaType, JToken data) =>
            new Vote()
            {
                BillId = data.Value<string>("billId"),
                Message = data.Value<string>("message"),
                Opinion = data.Value<bool?>("opinion"),
            };

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
        protected override JToken EncodeJson(RemoteCongressMediaType mediaType, Vote data)
        {
            JObject jObject = new JObject()
            {
                ["billId"] = data.BillId,
                ["message"] = data.Message,
                ["opinion"] = data.Opinion
            };

            return jObject;
        }
    }
}