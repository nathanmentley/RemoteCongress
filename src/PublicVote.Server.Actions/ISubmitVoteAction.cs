using PublicVote.Common;
using System.Threading.Tasks;

namespace PublicVote.Server.Actions
{
    public interface ISubmitVoteAction
    {
        Task<Vote> Submit(Vote vote);
    }
}