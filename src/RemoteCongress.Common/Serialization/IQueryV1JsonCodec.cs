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
using RemoteCongress.Common.Repositories.Queries;
using System;

namespace RemoteCongress.Common.Serialization
{
    /// <summary>
    /// An <see cref="ICodec{TData}"/> for a version 1 json representation of a <see cref="IQuery"/>.
    /// </summary>
    public class IQueryV1JsonCodec: BaseJsonCodec<IQuery>
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
        public IQueryV1JsonCodec(ILogger<IQueryV1JsonCodec> logger):
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
                "remotecongress.query",
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
        /// Decodes a <paramref name="data"/> into a <see cref="IQuery"/>.
        /// </summary>
        /// <param name="mediaType">
        /// The <see cref="RemoteCongressMediaType"/> to decode the data from.
        /// </param>
        /// <param name="data">
        /// The <see cref="JToken"/> to decode data from.
        /// </param>
        /// <returns>
        /// The <see cref="IQuery"/> from <paramref name="data"/>.
        /// </returns>
        protected override IQuery DecodeJson(RemoteCongressMediaType mediaType, JToken data) =>
            data.Value<string>("_type") switch
            {
                "billId" => new BillIdQuery(
                    data.Value<string>("billId")
                ),
                "publicKey" => new PublicKeyQuery(
                    data.Value<string>("publicKey")
                ),
                "chamber" => new ChamberQuery(
                    data.Value<string>("chamber")
                ),
                "opinion" => new OpinionQuery(
                    data.Value<bool>("opinion")
                ),
                "null" => new NullQuery(),
                _ => new NullQuery()
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
        protected override JToken EncodeJson(RemoteCongressMediaType mediaType, IQuery data)
        {
            JObject jObject = new JObject();

            switch(data)
            {
                case BillIdQuery billIdQuery:
                    jObject["_type"] = "billId";
                    jObject["billId"] = billIdQuery.BillId;
                    break;
                case PublicKeyQuery publicKeyQuery:
                    jObject["_type"] = "publicKey";
                    jObject["publicKey"] = publicKeyQuery.PublicKey;
                    break;
                case ChamberQuery chamberQuery:
                    jObject["_type"] = "chamber";
                    jObject["chamber"] = chamberQuery.Chamber;
                    break;
                case OpinionQuery opinionQuery:
                    jObject["_type"] = "opinion";
                    jObject["opinion"] = opinionQuery.Opinion;
                    break;
                case NullQuery _:
                    jObject["_type"] = "null";
                    break;
                default:
                    jObject["_type"] = "null";
                    break;
            }

            return jObject;
        }
    }
}