/*
    RemoteCongress - A platform for conducting small secure public elections
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
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RemoteCongress.Common;
using RemoteCongress.Common.Repositories;
using RemoteCongress.Server.Web.Controllers.Base;
using System;

namespace RemoteCongress.Server.Web.Controllers.Members
{
    /// <summary>
    /// Exposes an endpoint to fetch a <see cref="Member"/>.
    /// </summary>
    [ApiController]
    [Route("member/{id}")]
    public class FetchMemberController: BaseFetchController<Member>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository">
        /// An <see cref="IImmutableDataRepository<MemberData>"/> instance.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="repository"/> is null.
        /// </exception>
        public FetchMemberController(
            ILogger<FetchMemberController> logger,
            IImmutableDataRepository<Member> repository
        ): base(logger, repository) {}
    }
}