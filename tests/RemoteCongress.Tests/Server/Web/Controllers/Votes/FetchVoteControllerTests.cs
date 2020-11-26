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

using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RemoteCongress.Common;
using RemoteCongress.Common.Repositories;
using RemoteCongress.Server.Api.Controllers.Votes;
using RemoteCongress.Server.Api.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Tests.Server.Web.Controllers.Votes
{
    [TestClass]
    public class FetchVoteControllerTests
    {
        private readonly Mock<ILogger<FetchVoteController>> _loggerMock =
            new Mock<ILogger<FetchVoteController>>();
        private readonly Mock<IImmutableDataRepository<Vote>> _voteRepositoryMock =
            new Mock<IImmutableDataRepository<Vote>>();

        private FetchVoteController GetSubject() =>
            new FetchVoteController(
                _loggerMock.Object,
                _voteRepositoryMock.Object
            );

        [TestMethod]
        public void CtorShouldThrowNullLogger()
        {
            //arrange
            Func<FetchVoteController> action = () =>
                new FetchVoteController(null, _voteRepositoryMock.Object);

            //act
            action

            //assert
                .Should()
                .Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("logger");
        }

        [TestMethod]
        public void CtorShouldThrowNullRepo()
        {
            //arrange
            Func<FetchVoteController> action = () =>
                new FetchVoteController(_loggerMock.Object, null);

            //act
            action

            //assert
                .Should()
                .Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("repository");
        }

        [TestMethod]
        public void GetShouldThrowNullVoteId()
        {
            //arrange
            FetchVoteController subject = GetSubject();

            Func<Task> action = async () =>
                await subject.Get(null, CancellationToken.None);

            //act
            action

            //assert
                .Should()
                .Throw<MissingPathParameterException>();
        }

        [TestMethod]
        public void GetShouldThrowCancelledToken()
        {
            //arrange
            FetchVoteController subject = GetSubject();
            using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.Cancel();

            Func<Task> action = async () =>
                await subject.Get("id", cancellationTokenSource.Token);

            //act
            action

            //assert
                .Should()
                .Throw<OperationCanceledException>();
        }

        [TestMethod]
        public async Task GetShouldCallRepo()
        {
            //arrange
            FetchVoteController subject = GetSubject();
            string voteId = "voteId";
            VerifiedData<Vote> fetchedVote = await MockData.GetVote("billId", true, "message");

            _voteRepositoryMock.Setup(
                mock => mock.Fetch(voteId, CancellationToken.None)
            ).ReturnsAsync(fetchedVote);

            //act
            VerifiedData<Vote> result = await subject.Get(voteId, CancellationToken.None);

            //assert
            result.Should().BeSameAs(fetchedVote);

            _voteRepositoryMock.Verify(
                mock => mock.Fetch(voteId, CancellationToken.None),
                Times.Once
            );
        }
    }
}