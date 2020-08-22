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
using RemoteCongress.Common;
using RemoteCongress.Common.Exceptions;
using RemoteCongress.Common.Repositories;
using RemoteCongress.Common.Serialization;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Server.DAL.InMemory
{
    /// <summary>
    /// An In Memory implementation of <see cref="IBlockchainClient"/> for testing.
    /// </summary>
    /// <remarks>
    /// This data store is not distributed, and since it's in memory it's also not immutable.
    ///     It is only useful for testing code and validating the layers above this.
    ///     It should not be used for a production version.
    /// 
    ///     This implementation is also pretty naive. It's really only useful for development testing.
    /// </remarks>
    public class InMemoryBlockchainClient: IDataClient
    {
        private readonly InMemoryBlockchain _blockchain =
            new InMemoryBlockchain();

        private readonly ICodec<SignedData> _codec =
            new SignedDataV1JsonCodec();

        /// <summary>
        /// Creates a new block containing the verified content in <paramref="data"/> in the blockchain.
        /// </summary>
        /// <param name="data">
        /// The signed and verified data structure to store in the blockchain.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation requests.
        /// </param>
        /// <returns>
        /// The unique id of the stored block.
        /// </returns>
        public async Task<string> AppendToChain(ISignedData data, CancellationToken cancellationToken)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            cancellationToken.ThrowIfCancellationRequested();

            string blockContent = await _codec.EncodeToString(
                _codec.PreferredMediaType,
                new SignedData(data)
            );
            InMemoryBlock block = _blockchain.AppendToChain(blockContent);

            return block.Id;
        }

        /// <summary>
        /// Fetches the verified data in the form of <see cref="ISignedData"/> from the blockchain by block id.
        /// </summary>
        /// <param name="id">
        /// The unique block id to pull verified data from.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation requests.
        /// </param>
        /// <returns>
        /// An <see cref="ISignedData"/> instance containing the block data.
        /// </returns>
        public async Task<ISignedData> FetchFromChain(string id, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            cancellationToken.ThrowIfCancellationRequested();

            InMemoryBlock block = _blockchain.FetchFromChain(id);

            if (block is null)
                throw new BlockNotFoundException(
                    $"Could not fetch block with id[{id}] from {nameof(InMemoryBlockchainClient)}"
                );

            return await _codec.DecodeFromString(_codec.PreferredMediaType, block.Content);
        }
    }
}