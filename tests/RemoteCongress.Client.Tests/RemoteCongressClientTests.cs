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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RemoteCongress.Common;
using RemoteCongress.Common.Repositories;
using RemoteCongress.TestData;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Client.Tests
{
    [TestClass]
    public class RemoteCongressClientTests
    {
        private readonly Mock<IBillRepository> _billRepositoryMock =
            new Mock<IBillRepository>();

        private readonly Mock<IVoteRepository> _voteRepositoryMock =
            new Mock<IVoteRepository>();

        private RemoteCongressClient GetSubject() =>
            new RemoteCongressClient(
                _billRepositoryMock.Object,
                _voteRepositoryMock.Object
            );

        [TestMethod]
        public void CtorNullBillRepoThrows()
        {
            //Arrange
            Func<RemoteCongressClient> action = () =>
                new RemoteCongressClient(
                    null,
                    _voteRepositoryMock.Object
                );

            //Act
            action

            //Assert
                .Should()
                .Throw<ArgumentNullException>()
                    .And.ParamName.Should()
                        .Be("billRepository");
        }

        [TestMethod]
        public void CtorNullVoteRepoThrows()
        {
            //Arrange
            Func<RemoteCongressClient> action = () =>
                new RemoteCongressClient(
                    _billRepositoryMock.Object,
                    null
                );

            //Act
            action

            //Assert
                .Should()
                .Throw<ArgumentNullException>()
                    .And.ParamName.Should()
                        .Be("voteRepository");
        }

        [TestMethod]
        public async Task FetchBillCallsRepo()
        {
            //Arrange
            var subject = GetSubject();
            var id = "fake_bill_id";
            var bill = MockData.GetBill(id, "title", "content");

            _billRepositoryMock.Setup(
                repository => repository.Fetch(id, CancellationToken.None)
            ).ReturnsAsync(bill);

            //Act
            var result = await subject.GetBill(id, CancellationToken.None);

            //Assert
            result.Should().Be(bill);

            _billRepositoryMock.Verify(
                repository => repository.Fetch(id, CancellationToken.None), Times.Once()
            );
        }

        [TestMethod]
        public async Task FetchVoteCallsRepo()
        {
            //Arrange
            var subject = GetSubject();
            var id = "fake_vote_id";
            var vote = MockData.GetVote(id, "bill id", false, "message");

            _voteRepositoryMock.Setup(
                repository => repository.Fetch(id, CancellationToken.None)
            ).ReturnsAsync(vote);

            //Act
            var result = await subject.GetVote(id, CancellationToken.None);

            //Assert
            result.Should().Be(vote);

            _voteRepositoryMock.Verify(
                repository => repository.Fetch(id, CancellationToken.None), Times.Once()
            );
        }

        [TestMethod]
        public async Task CreateBillCallsRepo()
        {
            //Arrange
            var subject = GetSubject();
            var title = "title";
            var content = "content";

            //Act
            await subject.CreateBill(MockData.PrivateKey, MockData.PublicKey, title, content, CancellationToken.None);

            //Assert
            _billRepositoryMock.Verify(
                repository => repository.Create(It.Is<Bill>(
                    bill => bill.Title.Equals(title) && bill.Content.Equals(content)
                ), CancellationToken.None)
            );
        }

        [TestMethod]
        public async Task CreateVoteCallsRepo()
        {
            //Arrange
            var subject = GetSubject();
            var billId = "bill id";
            var opinion = false;
            var message = "message";

            //Act
            await subject.CreateVote(MockData.PrivateKey, MockData.PublicKey, billId, opinion, message, CancellationToken.None);

            //Assert
            _voteRepositoryMock.Verify(
                repository => repository.Create(It.Is<Vote>(
                    vote => vote.BillId.Equals(billId) &&
                        vote.Opinion.Equals(opinion) &&
                        vote.Message.Equals(message)
                ), CancellationToken.None)
            );
        }
    }
}
