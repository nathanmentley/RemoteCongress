using PublicVote.Common;
using System.Threading.Tasks;

namespace PublicVote.Server.DAL
{
    public interface IBlockchainClient
    {
        Task<string> AppendToChain(ISignedData data);

        Task<SignedData> FetchFromChain(string id);
    }
}