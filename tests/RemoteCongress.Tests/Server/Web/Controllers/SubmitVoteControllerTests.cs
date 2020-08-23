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
using RemoteCongress.Server.Web.Controllers;
using RemoteCongress.Server.Web.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Tests.Server.Web.Controllers
{
    [TestClass]
    public class SubmitVoteControllerTests
    {
        private readonly Mock<ILogger<SubmitVoteController>> _loggerMock =
            new Mock<ILogger<SubmitVoteController>>();
        private readonly Mock<IImmutableDataRepository<Vote>> _voteRepositoryMock =
            new Mock<IImmutableDataRepository<Vote>>();

        private SubmitVoteController GetSubject() =>
            new SubmitVoteController(
                _loggerMock.Object,
                _voteRepositoryMock.Object
            );

        [TestMethod]
        public void CtorShouldThrowNullLogger()
        {
            //arrange
            Func<SubmitVoteController> action = () =>
                new SubmitVoteController(null, _voteRepositoryMock.Object);

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
            Func<SubmitVoteController> action = () =>
                new SubmitVoteController(_loggerMock.Object, null);

            //act
            action

            //assert
                .Should()
                .Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("voteRepository");
        }

        [TestMethod]
        public void PostShouldThrowNullVote()
        {
            //arrange
            SubmitVoteController subject = GetSubject();

            Func<Task> action = async () =>
                await subject.Post(null, CancellationToken.None);

            //act
            action

            //assert
                .Should()
                .Throw<MissingBodyException>();
        }

        [TestMethod]
        public async Task PostShouldThrowCancelledToken()
        {
            //arrange
            SubmitVoteController subject = GetSubject();
            using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.Cancel();
            VerifiedData<Vote> voteToCreate = await MockData.GetVote("billId", true, "message");

            Func<Task> action = async () =>
                await subject.Post(voteToCreate, cancellationTokenSource.Token);

            //act
            action

            //assert
                .Should()
                .Throw<OperationCanceledException>();
        }

        [TestMethod]
        public async Task PostShouldCallRepo()
        {
            //arrange
            SubmitVoteController subject = GetSubject();
            VerifiedData<Vote> voteToCreate = await MockData.GetVote("billId", true, "message");
            VerifiedData<Vote> createdVote = await MockData.GetVote("billId", true, "message");

            _voteRepositoryMock.Setup(
                mock => mock.Create(voteToCreate, CancellationToken.None)
            ).ReturnsAsync(createdVote);

            //act
            VerifiedData<Vote> result = await subject.Post(voteToCreate, CancellationToken.None);

            //assert
            result.Should().BeSameAs(createdVote);

            _voteRepositoryMock.Verify(
                mock => mock.Create(voteToCreate, CancellationToken.None),
                Times.Once
            );
        }
    }
}