/*
    RemoteCongress - A platform for conducting small secure internal elections
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
using System.Security.Cryptography;
using System.Text;

namespace RemoteCongress.Server.DAL.IpfsBlockchainDb
{
    /// <summary>
    /// A block POCO inside a <see cref="Blockchain"/>.
    /// </summary>
    internal class Block
    {
        /// <summary>
        /// The unique Identifier from the block.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The <see cref="Id"/> of the previous <see cref="Block"/> in the <see cref="Blockchain"/>.
        /// </summary>
        public string LastBlockId { get; set; }

        /// <summary>
        /// A UTC timestamp for when the block was created.
        /// </summary>
        public DateTime Timestamp { get; set; } =
            DateTime.UtcNow;

        /// <summary>
        /// The <see cref="Hash"/> of the previous <see cref="Block"/> in the <see cref="Blockchain"/>.
        /// </summary>
        public string LastBlockHash { get; set; }
        
        /// <summary>
        /// The raw content of the block.
        /// </summary>
        public string Content { get; set; }
        
        /// <summary>
        /// The SHA256 hash of the concatinated:
        ///     * <see cref="Timestamp"/>
        ///     * <see cref="LastBlockHash"/>
        ///     * <see cref="Content"/>
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        /// An <see cref="Block"/> is valid if the <see cref="Hash"/> equals the result from <see cref="GenerateHash"/>.
        /// </summary>
        public bool IsValid =>
            string.Equals(Hash, GenerateHash(), StringComparison.InvariantCulture);

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="previousBlock">
        /// The previous <see cref="Block"/> in the <see cref="Blockchain"/>.
        /// </param>
        /// <param name="content">
        /// The content to be stored in the <see cref="Block"/>.
        /// </param>
        public Block(Block previousBlock, string content)
        {
            if (previousBlock is null)
                throw new ArgumentNullException(nameof(previousBlock));
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentNullException(nameof(content));

            LastBlockHash = previousBlock.Hash;
            LastBlockId = previousBlock.Id;
            Content = content;
            Hash = GenerateHash();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>
        /// This private constructor is used to generate the Genisys block.
        /// </remarks>
        private Block()
        {
            LastBlockHash = string.Empty;
            LastBlockId = string.Empty;
            Content = string.Empty;
            Hash = GenerateHash();
        }

        /// <summary>
        /// Generates a Hash based on the block content.
        /// </summary>
        /// <returns>
        /// A SHA256 Hash for the current <see cref="Block"/> state.
        /// </returns>
        private string GenerateHash()
        {
            using SHA256 sha256Hash = SHA256.Create();

            var content = LastBlockHash + Content + Timestamp.ToLongTimeString();
            var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(content));
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// Logic to generate a root <see cref="Block"/>.
        /// </summary>
        /// <returns>
        /// A special <see cref="Block"/> that can be used as the root of a blockchain.
        /// </returns>
        internal static Block CreateGenisysBlock() =>
            new Block();
    }
}