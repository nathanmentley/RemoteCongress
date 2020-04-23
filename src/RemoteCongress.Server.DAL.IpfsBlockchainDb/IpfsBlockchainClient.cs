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
using Newtonsoft.Json;
using RemoteCongress.Common;
using RemoteCongress.Common.Exceptions;
using RemoteCongress.Common.Repositories;
using System.Threading.Tasks;

namespace RemoteCongress.Server.DAL.IpfsBlockchainDb
{
    /// <summary>
    /// An In Memory implementation of <see cref="IBlockchainClient"/> for testing.
    /// </summary>
    /// <remarks>
    /// This data store is not distributed, and since it's in memory it's also not immutable.
    ///     It is only useful for testing code and validating the layers above this.
    ///     It should not be used for a production version.
    /// 
    ///     This implementation is also pretty naive. It's not thread-safe, and it's using
    ///         a true linked-list. So after a point it'll become wildly too slow.
    /// </remarks>
    public class IpfsBlockchainClient: IDataClient
    {
        private readonly Blockchain _blockchain;

        public IpfsBlockchainClient(IpfsBlockchainConfig config)
        {
            _blockchain = new Blockchain(config);
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
            var block = await _blockchain.AppendToChain(FromSignedData(data));

            return block.Id;
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
        public Task<ISignedData> FetchFromChain(string id)
        {
            var block = _blockchain.FetchFromChain(id);

            if (block is null)
                throw new BlockNotFoundException(
                    $"Could not fetch block with id[{id}] from {nameof(IpfsBlockchainClient)}"
                );

            return Task.FromResult(FromString(block.Content));
        }

        /// <summary>
        /// Transforms a <see cref="string"/> into a <see cref="ISignedData"/>.
        /// </summary>
        /// <param name="data">
        /// The <see cref="string"/> to transform.
        /// </param>
        /// <returns>
        /// The <see cref="ISignedData"/> representation.
        /// </returns>
        private static ISignedData FromString(string data) => 
            JsonConvert.DeserializeObject<SignedData>(data);

        /// <summary>
        /// Transforms a <see cref="ISignedData"/> into a <see cref="string"/>.
        /// </summary>
        /// <param name="data">
        /// The <see cref="ISignedData"/> to transform.
        /// </param>
        /// <returns>
        /// The <see cref="string"/> representation.
        /// </returns>
        private static string FromSignedData(ISignedData data) => 
            JsonConvert.SerializeObject(new SignedData(data));
    }
}