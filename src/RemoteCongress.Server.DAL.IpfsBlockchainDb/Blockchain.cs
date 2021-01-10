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
using Ipfs.CoreApi;
using Nito.AsyncEx;
using RemoteCongress.Common;
using RemoteCongress.Common.Repositories.Queries;
using RemoteCongress.Common.Serialization;
using RemoteCongress.Server.DAL.IpfsBlockchainDb.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Server.DAL.IpfsBlockchainDb
{
    /// <summary>
    /// A simple proof of concept blockchain implementation that is persisted in Ipfs.
    /// </summary>
    /// <remarks>
    /// This is not production ready code. It's fine for a proof of concept, but it needs to be
    ///     updating and to be much better thoughtout before it is really ready to be running
    ///     production level data.
    /// </remarks>
    internal class Blockchain
    {
        private readonly ICoreApi _engine;
        private readonly IList<Block> _blocks;
        private readonly ICodec<Block> _codec =
            new BlockV1JsonCodec();

        /// <summary>
        /// A <see cref="Blockchain"/> is valid if:
        ///     * Every <see cref="Blockchain"/>'s <see cref="Blockchain.IsValid"/> is true
        ///     * Every <see cref="Blockchain"/>'s <see cref="Block.LastBlockHash"/> matches the
        ///         previous <see cref="Blockchain"/>'s <see cref="Block.Hash"/>.
        /// </summary>
        public bool IsValid => !_blocks.Any(block => !block.IsValid);

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="coreApi">
        /// The IPFS api interface
        /// </param>
        /// <param name="config">
        /// An <see cref="IpfsBlockchainConfig"/> instance to use to configure Ipfs
        /// </param>
        internal Blockchain(ICoreApi coreApi, IpfsBlockchainConfig config)
        {
            if (coreApi is null)
                throw new ArgumentNullException(nameof(coreApi));

            _engine = coreApi;//new IpfsEngine(config.Password.ToCharArray());
            _blocks = new List<Block>();

            AsyncContext.Run(async () => await InitializeIpfs(config));
        }

        /// <summary>
        /// Sets the absolute path for Ipfs, and starts the the ipfs engine.
        /// </summary>
        private async Task InitializeIpfs(IpfsBlockchainConfig config)
        {
            // Setup blockchain from previous latest in node. or create a new chain.
            if (string.IsNullOrWhiteSpace(config.LastBlockId))
            {
                Block genisysBlock = Block.CreateGenisysBlock();
                genisysBlock = await PersistBlock(genisysBlock, CancellationToken.None);
                _blocks.Add(genisysBlock);
            }
            else
            {
                await LoadPreviousBlockIntoChain(config.LastBlockId, CancellationToken.None);
            }
        }

        /// <summary>
        /// Loads a <see cref="Block"/> into the first position of the <see cref="Blockchain"/> by <paramref name="id"/>.
        /// </summary>
        /// <param name="id">
        /// The previous <see cref="Block"/>'s <see cref="Block.Id"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation.
        /// </param>
        internal async Task LoadPreviousBlockIntoChain(string id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            string result = await _engine.FileSystem.ReadAllTextAsync(id, cancellationToken);
            Block block = await FromString(result);

            block.Id = id;
            _blocks.Insert(0, block);

            if (!string.IsNullOrWhiteSpace(block.LastBlockId))
                await LoadPreviousBlockIntoChain(block.LastBlockId, cancellationToken);
        }

        /// <summary>
        /// Appends data to the blockchain.
        /// </summary>
        /// <param name="content">
        /// The raw content to append to the blockchain.
        /// </param>
        /// <param name="mediaType">
        /// The <see cref="RemoteCongressMediaType"/> of the block to append.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation.
        /// </param>
        /// <returns>
        /// The created <see cref="Block"/> that contains <paramref name="content"/>.
        /// </returns>
        internal async Task<Block> AppendToChain(
            string content,
            RemoteCongressMediaType mediaType,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();

            Block block = new Block(_blocks.Last(), content, mediaType);
            block = await PersistBlock(block, cancellationToken);

            _blocks.Add(block);

            return block;
        }

        /// <summary>
        /// Fetches a <see cref="Block"/> by <paramref name="id"/>.
        /// </summary>
        /// <param name="id">
        /// The unique identifier to look up the <see cref="Block"/> by.
        /// </param>
        /// <returns>
        /// The matching <see cref="Block"/>, or null if it's not found.
        /// </returns>
        internal Block FetchFromChain(string id) =>
            _blocks.FirstOrDefault(block => block.Id.Equals(id));


        /// <summary>
        /// </summary>
        /// <param name="query">
        /// </param>
        /// <param name="cancellationToken">
        /// </param>
        /// <returns>
        /// </returns>
        #pragma warning disable CS1998
        internal async IAsyncEnumerable<Block> FetchAllFromChain(
            IEnumerable<IQuery> query,
            [EnumeratorCancellation] CancellationToken cancellationToken
        )
        {
            foreach(Block block in _blocks.Skip(1))
            {
                cancellationToken.ThrowIfCancellationRequested();

                yield return block;
            }
        }

        #pragma warning restore CS1998

        /// <summary>"
        /// Persists a <see cref="Block"/> inside the <see cref="Blockchain"/>.
        /// </summary>
        /// <param name="block">
        /// The <see cref="Block"/> to persist in the chain
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation.
        /// </param>
        /// <returns>
        /// The peristed version of <paramref name="block"/>.
        /// </returns>
        private async Task<Block> PersistBlock(Block block, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            string content = await FromBlock(block);
            IFileSystemNode result = await _engine.FileSystem.AddTextAsync(
                content,
                null,
                cancellationToken
            );

            block.Id = (string)result.Id;

            return block;
        }

        /// <summary>
        /// Generates a <see cref="Block"/> from a <see cref="string"/>.
        /// </summary>
        /// <param name="data">
        /// </param>
        /// <returns>
        /// </returns>
        private async Task<Block> FromString(string data) =>
            await _codec.DecodeFromString(_codec.GetPreferredMediaType(), data);

        /// <summary>
        /// </summary>
        /// <param name="data">
        /// </param>
        /// <returns>
        /// </returns>
        private async Task<string> FromBlock(Block data) => 
            await _codec.EncodeToString(_codec.GetPreferredMediaType(), data);
    }
}