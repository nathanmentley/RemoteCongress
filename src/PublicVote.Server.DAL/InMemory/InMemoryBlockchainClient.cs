/*
    PublicVote - A platform for conducting small secure public elections
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
using PublicVote.Common;
using PublicVote.Server.DAL.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PublicVote.Server.DAL.InMemory
{
    /// <summary>
    /// An In Memory implementation of <see cref="IBlockchainClient"/> for testing.
    /// </summary>
    /// <remarks>
    /// This data store is not a blockchain, and the data is not immutable.
    ///     It is only useful for testing code and validating the layers above this.
    /// </remarks>
    public class InMemoryBlockchainClient: IBlockchainClient
    {
        private readonly IDictionary<string, ISignedData> _data =
            new Dictionary<string, ISignedData>();

        /// <summary>
        /// Creates a new block containing the verified content in <paramref="data"/> in the blockchain.
        /// </summary>
        /// <param name="data">
        /// The signed and verified data structure to store in the blockchain.
        /// </param>
        /// <returns>
        /// The unique id of the stored block.
        /// </returns>
        public Task<string> AppendToChain(ISignedData data)
        {
            // generate a new id for our in memory test data store
            var id = Guid.NewGuid().ToString();

            // in the near impossible event we have a guid collision, throw an exception.
            if (_data.ContainsKey(id))
                throw new BlockNotStorableException(
                    $"Could not store a block with the id[{id}] in {nameof(InMemoryBlockchainClient)} " +
                        $"because there is already a block with that id."
                );

            //if the id is valid, store the data, and return the id.
            _data[id] = data;
            return Task.FromResult(id);
        }

        /// <summary>
        /// Fetches the verified data in the form of <see cref="ISignedData"/> from the blockchain by block id.
        /// </summary>
        /// <param name="id">
        /// The unique block id to pull verified data from.
        /// </param>
        /// <returns>
        /// An <see cref="ISignedData"/> instance containing the block data.
        /// </returns>
        public Task<ISignedData> FetchFromChain(string id)
        {
            //fetch the data from our in memory store if it exists, and return it.
            if (_data.TryGetValue(id, out ISignedData data))
                return Task.FromResult(data);

            // if the data for that id doesn't exist, throw an exception.
            throw new BlockNotFoundException(
                $"Could not fetch block with id[{id}] from {nameof(InMemoryBlockchainClient)}"
            );
        }
    }
}