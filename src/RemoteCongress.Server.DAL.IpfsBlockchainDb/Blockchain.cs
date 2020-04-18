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
using Ipfs.Engine;
using Newtonsoft.Json;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteCongress.Server.DAL.IpfsBlockchainDb
{
    /// <summary>
    /// A simple proof of concept in memory blockchain implementation.
    /// </summary>
    internal class Blockchain
    {
        private readonly IpfsEngine _engine =
            new IpfsEngine("pass".ToCharArray());

        private readonly IList<Block> _blocks = 
            new List<Block>();

        /// <summary>
        /// A <see cref="Blockchain"/> is valid if:
        ///     * Every <see cref="Blockchain"/>'s <see cref="Blockchain.IsValid"/> is true
        ///     * Every <see cref="Blockchain"/>'s <see cref="Blockchain.LastBlockHash"/> matches the
        ///         previous <see cref="Blockchain"/>'s <see cref="Blockchain.Hash"/>.
        /// </summary>
        public bool IsValid
        {
            get
            {
                foreach(var i in Enumerable.Range(1, _blocks.Count))
                {
                    var current = _blocks.ElementAt(i);
                    var previous = _blocks.ElementAt(i - 1);

                    if (!current.IsValid) return false;

                    if (
                        !string.Equals(
                            current.LastBlockHash,
                            previous.Hash,
                            StringComparison.InvariantCulture
                        )
                    )
                        return false;
                }

                return true;
            }
        }

        internal Blockchain(string latestBlockAddress) =>
            AsyncContext.Run(async () =>
                {
                    await InitializeIpfs();

                    if (string.IsNullOrWhiteSpace(latestBlockAddress))
                    {
                        var block = await PersistBlock(Block.CreateGenisysBlock());

                        _blocks.Add(block);
                    }
                    else
                    {
                        await LoadPreviousBlock(latestBlockAddress);
                    }
                }
            );

        private async Task InitializeIpfs()
        {
            // Set the repository
            _engine.Options.Repository.Folder = "myapp-ipfs";

            // Start the engine.
            await _engine.StartAsync();
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
            var block = new Block(_blocks.Last(), content);
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

        private async Task LoadPreviousBlock(string id)
        {
            var result = await _engine.FileSystem.ReadAllTextAsync(id);
            var block = FromString(result);
            _blocks.Insert(0, block);

            if(!string.IsNullOrWhiteSpace(block.LastBlockId))
                await LoadPreviousBlock(block.LastBlockId);
        }

        private async Task<Block> PersistBlock(Block block)
        {
            var result = await _engine.FileSystem.AddTextAsync(FromBlock(block));

            block.Id = (string)result.Id;

            return block;
        }

        private static Block FromString(string data) => 
            JsonConvert.DeserializeObject<Block>(data);

        private static string FromBlock(Block data) => 
            JsonConvert.SerializeObject(data);
    }
}