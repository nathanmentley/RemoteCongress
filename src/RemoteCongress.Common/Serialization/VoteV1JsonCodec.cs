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
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace RemoteCongress.Common.Serialization
{
    public class VoteV1JsonCodec: ICodec<Vote>
    {
        public readonly static RemoteCongressMediaType MediaType =
            new RemoteCongressMediaType("application", "json", "remotecongress.vote", 1);

        public RemoteCongressMediaType GetPreferredMediaType() =>
            MediaType;

        public bool CanHandle(RemoteCongressMediaType mediaType) =>
            MediaType.Equals(mediaType);

        public async Task<Vote> Decode(RemoteCongressMediaType mediaType, Stream data)
        {
            using StreamReader sr = new StreamReader(data);
            string json = await sr.ReadToEndAsync();

            JObject jObject = JObject.Parse(json);

            //TODO: Check media type
            string publicKey = jObject.Value<string>("publicKey");
            string blockContent = jObject.Value<string>("blockContent");
            string blockMediaType = jObject.Value<string>("mediaType");

            throw new NotImplementedException();
        }

        public Task<Stream> Encode(RemoteCongressMediaType mediaType, Vote data)
        {
            JObject jObject = new JObject()
            {
                ["id"] = data.Id,
            };

            byte[] jsonBytes = Encoding.UTF8.GetBytes(jObject.ToString());

            return Task.FromResult(new MemoryStream(jsonBytes) as Stream);
        }
    }
}