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
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PublicVote.Common;
using PublicVote.Common.Repositories;

namespace PublicVote.Controllers
{
    [ApiController]
    [Route("vote")]
    public class SubmitVoteController
    {
        private readonly ILogger<SubmitVoteController> _logger;
        private readonly IVoteRepository _voteRepository;

        public SubmitVoteController(
            ILogger<SubmitVoteController> logger,
            IVoteRepository voteRepository
        )
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));

            _voteRepository = voteRepository ??
                throw new ArgumentNullException(nameof(voteRepository));
        }

        [HttpPost]
        public async Task<Vote> Post([FromBody] Vote vote) =>
            await _voteRepository.Create(vote);
    }
}