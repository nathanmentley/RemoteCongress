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
using Ipfs.CoreApi;
using RemoteCongress.Common;
using RemoteCongress.Common.Exceptions;
using RemoteCongress.Common.Repositories;
using RemoteCongress.Common.Serialization;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Server.DAL.IpfsBlockchainDb
{
    /// <summary>
    /// An Ipfs Blockchain implementation of <see cref="IBlockchainClient"/>.
    /// </summary>
    /// <remarks>
    /// This implementation is also pretty naive. It's really meant for a proof of concept.
    /// </remarks>
    public class IpfsBlockchainClient: IDataClient
    {
        private readonly Blockchain _blockchain;
        private readonly ICodec<SignedData> _codec =
            new SignedDataV1JsonCodec();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config">
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public IpfsBlockchainClient(ICoreApi coreApi, IpfsBlockchainConfig config)
        {
            if (coreApi is null)
                throw new ArgumentNullException(nameof(coreApi));

            if (config is null)
                throw new ArgumentNullException(nameof(config));

            _blockchain = new Blockchain(coreApi, config);
        }

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

            string blockContent = await FromSignedData(data);
            Block block = await _blockchain.AppendToChain(blockContent, cancellationToken);

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

            Block block = _blockchain.FetchFromChain(id);

            if (block is null)
                throw new BlockNotFoundException(
                    $"Could not fetch block with id[{id}] from {nameof(IpfsBlockchainClient)}"
                );

            return await FromString(block.Content);
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
        private async Task<ISignedData> FromString(string data) => 
            await _codec.DecodeFromString(_codec.GetPreferredMediaType(), data);

        /// <summary>
        /// Transforms a <see cref="ISignedData"/> into a <see cref="string"/>.
        /// </summary>
        /// <param name="data">
        /// The <see cref="ISignedData"/> to transform.
        /// </param>
        /// <returns>
        /// The <see cref="string"/> representation.
        /// </returns>
        private async Task<string> FromSignedData(ISignedData data) =>
            await _codec.EncodeToString(_codec.GetPreferredMediaType(), new SignedData(data));
    }
}