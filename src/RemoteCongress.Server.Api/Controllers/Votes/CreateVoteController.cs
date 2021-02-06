/*
    RemoteCongress - A platform for conducting small secure public elections
    Copyright (C) 2021  Nathan Mentley

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
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RemoteCongress.Common;
using RemoteCongress.Common.Repositories;
using RemoteCongress.Server.Api.Controllers.Base;
using System;

namespace RemoteCongress.Server.Api.Controllers.Votes
{
    /// <summary>
    /// Exposes an endpoint to persist <see cref="Vote"/>s.
    /// </summary>
    [ApiController]
    [Route("vote")]
    public class CreateVoteController: BaseCreateController<Vote>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">
        /// An <see cref="ILogger"/> instance to log against.
        /// </param>
        /// <param name="repository">
        /// An <see cref="IImmutableDataRepository{VoteData}"/> instance.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="repository"/> is null.
        /// </exception>
        public CreateVoteController(
            ILogger<CreateVoteController> logger,
            IImmutableDataRepository<Vote> repository
        ): base(logger, repository) {}
    }
}