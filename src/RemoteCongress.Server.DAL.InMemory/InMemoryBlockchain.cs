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
using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoteCongress.Server.DAL.InMemory
{
    /// <summary>
    /// A simple proof of concept in memory blockchain implementation.
    /// </summary>
    internal class InMemoryBlockchain
    {
        private readonly IList<InMemoryBlock> _blocks =
            new List<InMemoryBlock>()
            {
                InMemoryBlock.CreateGenisysBlock()
            };

        /// <summary>
        /// A <see cref="InMemoryBlockchain"/> is valid if:
        ///     * Every <see cref="InMemoryBlockchain"/>'s <see cref="InMemoryBlockchain.IsValid"/> is true
        ///     * Every <see cref="InMemoryBlockchain"/>'s <see cref="InMemoryBlockchain.LastBlockHash"/> matches the
        ///         previous <see cref="InMemoryBlockchain"/>'s <see cref="InMemoryBlockchain.Hash"/>.
        /// </summary>
        public bool IsValid => !_blocks.Any(block => !block.IsValid);

        /// <summary>
        /// Appends data to the blockchain.
        /// </summary>
        /// <param name="content">
        /// The raw content to append to the blockchain.
        /// </param>
        /// <returns>
        /// The created <see cref="InMemoryBlock"/> that contains <paramref name="content"/>.
        /// </returns>
        internal InMemoryBlock AppendToChain(string content)
        {
            var block = new InMemoryBlock(_blocks.Last(), content);

            _blocks.Add(block);

            return block;
        }

        /// <summary>
        /// Fetches a <see cref="InMemoryBlock"/> by <paramref name="id"/>.
        /// </summary>
        /// <param name="id">
        /// The unique identifier to look up the <see cref="InMemoryBlock"/> by.
        /// </param>
        /// <returns>
        /// The matching <see cref="InMemoryBlock"/>, or null if it's not found.
        /// </returns>
        internal InMemoryBlock FetchFromChain(string id) =>
            _blocks.FirstOrDefault(block => block.Id.Equals(id));
    }
}