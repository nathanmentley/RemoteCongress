/*
    PublicVote - A platform for conducting small secure public elections
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
using Ipfs;
using Ipfs.Http;
using Newtonsoft.Json;
using PublicVote.Common;
using System;
using System.Text;
using System.Threading.Tasks;

namespace PublicVote.Server.DAL.Ipfs
{
    public class IpfsBlockchainClient: IBlockchainClient, IDisposable
    {
        private readonly IpfsConfig _config;
        private readonly IpfsClient _client;

        public IpfsBlockchainClient(IpfsConfig config)
        {
            _config = config ??
                throw new ArgumentNullException(nameof(config));

            _client = new IpfsClient();
            _client.ApiUri = new Uri(_config.Url);
        }

        public async Task<string> AppendToChain(ISignedData data)
        {
            Cid cid = await _client.Block.PutAsync(ToBytes(data));

            return cid.Encode();
        }

        public async Task<ISignedData> FetchFromChain(string id)
        {
            var cid = Cid.Decode(id);

            var result = await _client.Block.GetAsync(cid);

            return FromBytes(result.DataBytes);
        }

        private static byte[] ToBytes(ISignedData data)
        {
            var encoding = GetEncoding();

            var signedData = new SignedData(data);
            var json = JsonConvert.SerializeObject(signedData);

            return encoding.GetBytes(json);
        }

        private static ISignedData FromBytes(byte[] data)
        {
            var encoding = GetEncoding();

            var json = encoding.GetString(data);

            return JsonConvert.DeserializeObject<SignedData>(json);
        }

        private static Encoding GetEncoding() =>
            Encoding.Unicode;

        protected virtual void Dispose(bool disposing) {}

        public void Dispose() => Dispose(true);
    }
}