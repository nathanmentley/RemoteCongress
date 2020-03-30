using PublicVote.Common;
using System;
using System.Threading.Tasks;

namespace PublicVote.Server.DAL
{
    public class BlockchainClient: IBlockchainClient, IDisposable
    {
        private readonly string _connectionString;

        public BlockchainClient(string connectionString)
        {
            _connectionString = connectionString ??
                throw new ArgumentNullException(connectionString);
        }

        public Task<string> AppendToChain(ISignedData data) =>
            throw new NotImplementedException();

        public Task<SignedData> FetchFromChain(string id) =>
            throw new NotImplementedException();

        protected virtual void Dispose(bool disposing) {}

        public void Dispose() => Dispose(true);
    }
}