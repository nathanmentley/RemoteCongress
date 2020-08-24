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
using System.Collections.Generic;
using System.Linq;
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
        private readonly IEnumerable<ICodec<SignedData>> _codecs;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="coreApi">
        /// A <see cref="ICoreApi"/> to use to interact with IPFS
        /// </param>
        /// <param name="config">
        /// The IPFS configuration data.
        /// </param>
        /// <param name="codecs">
        /// The <see cref="ICodec"/> to use for <see cref="SignedData"/> data.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="coreApi"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="config"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="codecs"/> is null.
        /// </exception>
        public IpfsBlockchainClient(
            ICoreApi coreApi,
            IpfsBlockchainConfig config,
            IEnumerable<ICodec<SignedData>> codecs
        )
        {
            if (coreApi is null)
                throw new ArgumentNullException(nameof(coreApi));

            if (config is null)
                throw new ArgumentNullException(nameof(config));

            _codecs = codecs ??
                throw new ArgumentNullException(nameof(codecs));

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

            ICodec<SignedData> codec = _codecs.FirstOrDefault();

            if (codec is null)
                throw new UnknownBlockMediaTypeException(
                    $"Cannot encode {typeof(SignedData)}"
                );

            string blockContent = await codec.EncodeToString(
                codec.GetPreferredMediaType(),
                new SignedData(data)
            );

            Block block = await _blockchain.AppendToChain(
                blockContent,
                codec.GetPreferredMediaType(),
                cancellationToken
            );

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

            ICodec<SignedData> codec = _codecs.FirstOrDefault(
                codec => codec.CanHandle(block.MediaType)
            );

            if (codec is null)
                throw new UnknownBlockMediaTypeException(
                    $"Cannot handle {block.MediaType}"
                );

            return await codec.DecodeFromString(codec.GetPreferredMediaType(), block.Content);
        }
    }
}