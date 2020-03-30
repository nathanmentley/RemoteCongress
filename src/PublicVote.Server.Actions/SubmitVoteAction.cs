using System;
using System.Threading.Tasks;
using PublicVote.Common;
using PublicVote.Server.DAL;

namespace PublicVote.Server.Actions
{
    public class SubmitVoteAction: ISubmitVoteAction
    {
        private readonly IVoteRepository _voteRepository;

        public SubmitVoteAction(IVoteRepository voteRepository)
        {
            _voteRepository = voteRepository ??
                throw new ArgumentNullException(nameof(voteRepository));
        }

        public Task<Vote> Submit(Vote vote) =>
            _voteRepository.Create(vote);
    }
}