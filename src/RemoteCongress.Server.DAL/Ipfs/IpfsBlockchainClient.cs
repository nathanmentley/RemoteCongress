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
using Ipfs;
using Ipfs.Http;
using Newtonsoft.Json;
using RemoteCongress.Common;
using RemoteCongress.Server.DAL.Exceptions;
using System;
using System.Text;
using System.Threading.Tasks;

namespace RemoteCongress.Server.DAL.Ipfs
{
    /// <summary>
    /// Ipfs client implementation of <see cref="BlockchainClient"/> for persisting vote and bill data.
    /// </summary>
    /// <remarks>
    /// While this data store is immutable and decentralized it is not a true blockchain. So the data is immutable, but we
    ///     don't have an immutable history. We can build a blockchain on top of Ipfs, but that is overkill for a proof of
    ///     concept like this since that has been done many times.
    /// 
    ///     This system might be a bit better suited for use something like BigchainDb if it was to be used
    ///     in a less Proof Of Concept manner.
    /// </remarks>
    public class IpfsBlockchainClient: IBlockchainClient
    {
        private readonly IpfsConfig _config;
        private readonly IpfsClient _client;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="config">
        /// An <see cref="IpfsConfig"/> instance that has configuration data for Ipfs.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="config"/> is null.
        /// </exception>
        public IpfsBlockchainClient(IpfsConfig config)
        {
            _config = config ??
                throw new ArgumentNullException(nameof(config));

            _client = new IpfsClient();
            _client.ApiUri = new Uri(_config.Url);
        }

        /// <summary>
        /// Creates a new block containing the verified content in <paramref="data"/> in the blockchain.
        /// </summary>
        /// <param name="data">
        /// The signed and verified data structure to store in the blockchain.
        /// </param>
        /// <returns>
        /// The unique id of the stored block.
        /// </returns>
        public async Task<string> AppendToChain(ISignedData data)
        {
            //convert data.
            var rawData = ToBytes(data);

            //store the data and collect the id.
            Cid cid = await _client.Block.PutAsync(rawData);

            //return a string version of the id.
            return cid.Encode();
        }

        /// <summary>
        /// Fetches the verified data in the form of <see cref="ISignedData"/> from the blockchain by block id.
        /// </summary>
        /// <param name="id">
        /// The unique block id to pull verified data from.
        /// </param>
        /// <returns>
        /// An <see cref="ISignedData"/> instance containing the block data.
        /// </returns>
        public async Task<ISignedData> FetchFromChain(string id)
        {
            //try to get an Ipfs format of the id from our string.
            var cid = Cid.Decode(id);

            // get the block from the id.
            var result = await _client.Block.GetAsync(cid);

            // if we didn't find anything throw a not found exception.
            if (result is null)
                throw new BlockNotFoundException(
                    $"Could not fetch block with id[{id}] from {nameof(IpfsBlockchainClient)}"
                );

            // if we have our data, lets convert it, and return it.
            return FromBytes(result.DataBytes);
        }

        /// <summary>
        /// Converts an <see cerf="ISignedData"/> instance to a <see cref="byte[]"/> for persisting.
        /// </summary>
        private static byte[] ToBytes(ISignedData data)
        {
            var encoding = GetEncoding();

            //convert to a concrete type and jsonify it.
            var signedData = new SignedData(data);
            var json = JsonConvert.SerializeObject(signedData);

            //Encode it into bytes
            return encoding.GetBytes(json);
        }

        /// <summary>
        /// Converts a raw <see cref="byte[]"/> from a persisted block back into an <see cref="ISignedData"/>.
        /// </summary>
        private static ISignedData FromBytes(byte[] data)
        {
            var encoding = GetEncoding();

            //Get json as a string from the byte array
            var json = encoding.GetString(data);

            // try to get our concrete SignedData out of the json.
            return JsonConvert.DeserializeObject<SignedData>(json);
        }

        /// <summary>
        /// Gets a common <see cref="Encoding"/> to use for this layer.
        /// </summary>
        /// <returns>
        /// <see cref="Encoding.Unicode"/>
        /// </returns>
        /// <remarks>
        /// In a non proof of concept system we'd want this to be more intelligent.
        /// </remarks>
        private static Encoding GetEncoding() =>
            Encoding.Unicode;
    }
}