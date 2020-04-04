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

namespace PublicVote.Server.DAL
{
    public class InMemoryBlockchainClient: IBlockchainClient, IDisposable
    {
        private readonly IDictionary<string, ISignedData> _data =
            new Dictionary<string, ISignedData>();

        public Task<string> AppendToChain(ISignedData data)
        {
            var id = Guid.NewGuid().ToString();

            if (_data.ContainsKey(id))
                throw new BlockNotStorableException(
                    $"Could not store a block with the id[{id}] in {nameof(InMemoryBlockchainClient)} " +
                        $"because there is already a block with that id."
                );

            _data[id] = data;

            return Task.FromResult(id);
        }

        public Task<ISignedData> FetchFromChain(string id)
        {
            if (_data.TryGetValue(id, out ISignedData data))
                return Task.FromResult(data);

            throw new BlockNotFoundException(
                $"Could not fetch block with id[{id}] from {nameof(InMemoryBlockchainClient)}"
            );
        }

        protected virtual void Dispose(bool disposing) {}

        public void Dispose() => Dispose(true);
    }
}