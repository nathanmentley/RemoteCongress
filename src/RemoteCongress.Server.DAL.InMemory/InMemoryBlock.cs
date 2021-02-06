/*
    RemoteCongress - A platform for conducting small secure internal elections
    Copyright (C) 2021  Nathan Mentley

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
using System;
using System.Security.Cryptography;
using System.Text;

namespace RemoteCongress.Server.DAL.InMemory
{
    /// <summary>
    /// A simple class to exist as a block inside a blockchain.
    /// </summary>
    internal class InMemoryBlock: BaseBlock
    {
        /// <summary>
        /// The unique Identifier from the block.
        /// </summary>
        public override string Id { get; } =
            Guid.NewGuid().ToString();

        /// <summary>
        /// A UTC timestamp for when the block was created.
        /// </summary>
        internal DateTime Timestamp { get; } =
            DateTime.UtcNow;

        /// <summary>
        /// The <see cref="Hash"/> of the previous <see cref="InMemoryBlock"/> in the <see cref="InMemoryBlockchain"/>.
        /// </summary>
        internal string LastBlockHash { get; }
        
        /// <summary>
        /// The raw content of the block.
        /// </summary>
        internal string Content { get; private set; }
        
        /// <summary>
        /// The SHA256 hash of the concatinated:
        ///     * <see cref="Id"/>
        ///     * <see cref="Timestamp"/>
        ///     * <see cref="LastBlockHash"/>
        ///     * <see cref="Content"/>
        /// </summary>
        internal string Hash { get; private set; }

        /// <summary>
        /// The MediaType of <see cref="Content"/>.
        /// </summary>
        internal RemoteCongressMediaType MediaType { get; private set; }

        /// <summary>
        /// An <see cref="InMemoryBlock"/> is valid if the <see cref="Hash"/> equals the result from <see cref="GenerateHash"/>.
        /// </summary>
        public override bool IsValid =>
            string.Equals(Hash, GenerateHash(), StringComparison.InvariantCulture);


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="previousBlock">
        /// The previous <see cref="InMemoryBlock"/> in the <see cref="InMemoryBlockchain"/>.
        /// </param>
        /// <param name="content">
        /// The content to be stored in the <see cref="InMemoryBlock"/>.
        /// </param>
        /// <param name="mediaType">
        /// The <see cref="RemoteCongressMediaType"/> of the block.
        /// </param>
        internal InMemoryBlock(InMemoryBlock previousBlock, string content, RemoteCongressMediaType mediaType)
        {
            if (previousBlock is null)
                throw new ArgumentNullException(nameof(previousBlock));
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentNullException(nameof(content));

            LastBlockHash = previousBlock.Hash;
            Content = content;
            MediaType = mediaType;
            Hash = GenerateHash();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>
        /// This private constructor is used to generate the Genisys block.
        /// </remarks>
        private InMemoryBlock()
        {
            LastBlockHash = string.Empty;
            Content = string.Empty;
            MediaType = RemoteCongressMediaType.None;
            Hash = GenerateHash();
        }

        /// <summary>
        /// Generates a Hash based on the block content.
        /// </summary>
        /// <returns>
        /// A SHA256 Hash for the current <see cref="InMemoryBlock"/> state.
        /// </returns>
        private string GenerateHash()
        {
            using SHA256 sha256Hash = SHA256.Create();

            var content = Id + LastBlockHash + Content + Timestamp.ToLongTimeString();
            var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(content));
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// Logic to generate a root <see cref="InMemoryBlock"/>.
        /// </summary>
        /// <returns>
        /// A special <see cref="InMemoryBlock"/> that can be used as the root of a blockchain.
        /// </returns>
        internal static InMemoryBlock CreateGenisysBlock() =>
            new InMemoryBlock();
    }
}