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
    /// An <see cref="ICodec{TData}"/> for a version 1 json representation of a <see cref="Bill"/>.
    /// </summary>
    public class BillV1JsonCodec: BaseJsonCodec<Bill>
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
        public BillV1JsonCodec(ILogger<BillV1JsonCodec> logger):
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
                "remotecongress.content.bill", 
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
        /// Decodes a <paramref name="data"/> into a <see cref="Bill"/>.
        /// </summary>
        /// <param name="mediaType">
        /// The <see cref="RemoteCongressMediaType"/> to decode the data from.
        /// </param>
        /// <param name="data">
        /// The <see cref="JToken"/> to decode data from.
        /// </param>
        /// <returns>
        /// The <see cref="Bill"/> from <paramref name="data"/>.
        /// </returns>
        protected override Bill DecodeJson(RemoteCongressMediaType mediaType, JToken data) =>
            new Bill()
            {
                Title = data.Value<string>("title"),
                Content = data.Value<string>("content"),
                Chamber = data.Value<string>("chamber"),
                Code = data.Value<string>("code"),
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
        protected override JToken EncodeJson(RemoteCongressMediaType mediaType, Bill data) =>
            new JObjectBuilder()
                .WithData("title", data.Title)
                .WithData("content", data.Content)
                .WithData("chamber", data.Chamber)
                .WithData("code", data.Code)
                .Build();
    }
}