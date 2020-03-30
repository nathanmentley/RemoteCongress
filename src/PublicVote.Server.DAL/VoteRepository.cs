using System;
using System.Threading.Tasks;
using PublicVote.Common;
using PublicVote.Common.Serializers;

namespace PublicVote.Server.DAL
{
    public class VoteRepository: IVoteRepository
    {
        private readonly static VoteSerializer _serializer =
            new VoteSerializer();

        private readonly IBlockchainClient _client;

        public VoteRepository(IBlockchainClient client)
        {
            _client = client ??
                throw new ArgumentNullException(nameof(client));
        }

        public async Task<Vote> Create(Vote vote)
        {
            vote.Id = await _client.AppendToChain(vote);

            return vote;
        }

        public async Task<Vote> Fetch(string id)
        {
            var data = await _client.FetchFromChain(id);

            return await _serializer.Deserialize(data);
        }
    }
}