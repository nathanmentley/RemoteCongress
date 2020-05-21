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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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

        /// <summary>
        /// A <see cref="Blockchain"/> is valid if:
        ///     * Every <see cref="Blockchain"/>'s <see cref="Blockchain.IsValid"/> is true
        ///     * Every <see cref="Blockchain"/>'s <see cref="Blockchain.LastBlockHash"/> matches the
        ///         previous <see cref="Blockchain"/>'s <see cref="Blockchain.Hash"/>.
        /// </summary>
        public bool IsValid => !_blocks.Any(block => !block.IsValid);

        /// <summary>
        /// Ctor
        /// </summary>
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
                genisysBlock = await PersistBlock(genisysBlock);
                _blocks.Add(genisysBlock);
            }
            else
            {
                await LoadPreviousBlockIntoChain(config.LastBlockId);
            }
        }

        /// <summary>
        /// Loads a <see cref="Block"/> into the first position of the <see cref="Blockchain"/> by <paramref name="id"/>.
        /// </summary>
        /// <param name="id">
        /// The previous <see cref="Block"/>'s <see cref="Block.Id"/>.
        /// </param>
        private async Task LoadPreviousBlockIntoChain(string id)
        {
            string result = await _engine.FileSystem.ReadAllTextAsync(id);
            Block block = FromString(result);

            block.Id = id;
            _blocks.Insert(0, block);

            if (!string.IsNullOrWhiteSpace(block.LastBlockId))
                await LoadPreviousBlockIntoChain(block.LastBlockId);
        }

        /// <summary>
        /// Appends data to the blockchain.
        /// </summary>
        /// <param name="content">
        /// The raw content to append to the blockchain.
        /// </param>
        /// <returns>
        /// The created <see cref="Block"/> that contains <paramref name="content"/>.
        /// </returns>
        internal async Task<Block> AppendToChain(string content)
        {
            Block block = new Block(_blocks.Last(), content);
            block = await PersistBlock(block);

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

        /// <summary>"
        /// Persists a <see cref="Block"/> inside the <see cref="Blockchain"/>.
        /// </summary>
        /// <param name="block">
        /// The <see cref="Block"/> to persist in the chain
        /// </param>
        /// <returns>
        /// The peristed version of <paramref name="block"/>.
        /// </returns>
        private async Task<Block> PersistBlock(Block block)
        {
            string content = FromBlock(block);
            IFileSystemNode result = await _engine.FileSystem.AddTextAsync(content);

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
        private static Block FromString(string data) => 
            JsonSerializer.Deserialize<Block>(data, new JsonSerializerOptions());

        /// <summary>
        /// </summary>
        /// <param name="data">
        /// </param>
        /// <returns>
        /// </returns>
        private static string FromBlock(Block data) => 
            JsonSerializer.Serialize<Block>(data);
    }
}