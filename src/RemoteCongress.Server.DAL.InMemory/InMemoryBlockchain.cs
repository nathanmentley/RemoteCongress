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
using RemoteCongress.Server.DAL.Blockchain;

namespace RemoteCongress.Server.DAL.InMemory
{
    /// <summary>
    /// A simple proof of concept in memory blockchain implementation.
    /// </summary>
    internal class InMemoryBlockchain: BaseBlockchain<InMemoryBlock>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        internal InMemoryBlockchain(): base() {}

        /// <summary>
        /// Creates a genisys block
        /// </summary>
        /// <returns>
        /// The genisys block
        /// </returns>
        protected override InMemoryBlock GenerateGenisysBlock() =>
            InMemoryBlock.CreateGenisysBlock();

        /// <summary>
        /// Creates a new block
        /// </summary>
        /// <param name="last">
        /// The previous block
        /// </param>
        /// <param name="content">
        /// The content of the block
        /// </param>
        /// <param name="mediaType">
        /// The mediatype of the block content
        /// </param>
        /// <returns>
        /// The created block
        /// </returns>
        protected override InMemoryBlock GenerateBlock(
            InMemoryBlock last,
            string content,
            RemoteCongressMediaType mediaType
        ) =>
            new InMemoryBlock(last, content, mediaType);
    }
}