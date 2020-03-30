using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PublicVote.Common;
using PublicVote.Server.Actions;

namespace PublicVote.Controllers
{
    [ApiController]
    [Route("vote")]
    public class VoteController
    {
        private readonly ILogger<VoteController> _logger;
        private readonly ISubmitVoteAction _createVoteAction;

        public VoteController(ILogger<VoteController> logger, ISubmitVoteAction createVoteAction)
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));

            _createVoteAction = createVoteAction ??
                throw new ArgumentNullException(nameof(createVoteAction));
        }

        [HttpPost]
        public async Task<Vote> Post(Vote vote) =>
            await _createVoteAction.Submit(vote);
    }
}