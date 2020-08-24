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
using RemoteCongress.Client;
using RemoteCongress.Common;
using RemoteCongress.Common.Repositories;
using RemoteCongress.Common.Serialization;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Tests.Client
{
    [TestClass]
    public class RemoteCongressClientTests
    {
        private readonly Mock<ILogger<RemoteCongressClient>> _loggerMock =
            new Mock<ILogger<RemoteCongressClient>>();

        private readonly IEnumerable<ICodec<Bill>> _billCodecs =
            new [] {
                new BillV1JsonCodec()
            };

        private readonly IEnumerable<ICodec<Vote>> _voteCodecs =
            new [] {
                new VoteV1JsonCodec()
            };

        private readonly Mock<IImmutableDataRepository<Bill>> _billRepositoryMock =
            new Mock<IImmutableDataRepository<Bill>>();

        private readonly Mock<IImmutableDataRepository<Vote>> _voteRepositoryMock =
            new Mock<IImmutableDataRepository<Vote>>();

        private RemoteCongressClient GetSubject() =>
            new RemoteCongressClient(
                _loggerMock.Object,
                _billCodecs,
                _voteCodecs,
                _billRepositoryMock.Object,
                _voteRepositoryMock.Object
            );

        [TestMethod]
        public void CtorNullLoggerThrows()
        {
            //Arrange
            Func<RemoteCongressClient> action = () =>
                new RemoteCongressClient(
                    null,
                    _billCodecs,
                    _voteCodecs,
                    _billRepositoryMock.Object,
                    _voteRepositoryMock.Object
                );

            //Act
            action

            //Assert
                .Should()
                .Throw<ArgumentNullException>()
                    .And.ParamName.Should()
                        .Be("logger");
        }

        [TestMethod]
        public void CtorNullBillCodecThrows()
        {
            //Arrange
            Func<RemoteCongressClient> action = () =>
                new RemoteCongressClient(
                    _loggerMock.Object,
                    null,
                    _voteCodecs,
                    _billRepositoryMock.Object,
                    _voteRepositoryMock.Object
                );

            //Act
            action

            //Assert
                .Should()
                .Throw<ArgumentNullException>()
                    .And.ParamName.Should()
                        .Be("billCodec");
        }

        [TestMethod]
        public void CtorNullVoteCodecThrows()
        {
            //Arrange
            Func<RemoteCongressClient> action = () =>
                new RemoteCongressClient(
                    _loggerMock.Object,
                    _billCodecs,
                    null,
                    _billRepositoryMock.Object,
                    _voteRepositoryMock.Object
                );

            //Act
            action

            //Assert
                .Should()
                .Throw<ArgumentNullException>()
                    .And.ParamName.Should()
                        .Be("voteCodec");
        }

        [TestMethod]
        public void CtorNullBillRepoThrows()
        {
            //Arrange
            Func<RemoteCongressClient> action = () =>
                new RemoteCongressClient(
                    _loggerMock.Object,
                    _billCodecs,
                    _voteCodecs,
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
                    _loggerMock.Object,
                    _billCodecs,
                    _voteCodecs,
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
            RemoteCongressClient subject = GetSubject();
            string id = "fake_bill_id";
            VerifiedData<Bill> bill = await MockData.GetBill(id, "title", "content");

            _billRepositoryMock.Setup(
                repository => repository.Fetch(id, CancellationToken.None)
            ).ReturnsAsync(bill);

            //Act
            VerifiedData<Bill> result = await subject.GetBill(id, CancellationToken.None);

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
            RemoteCongressClient subject = GetSubject();
            string id = "fake_vote_id";
            VerifiedData<Vote> vote = await MockData.GetVote(id, "bill id", false, "message");

            _voteRepositoryMock.Setup(
                repository => repository.Fetch(id, CancellationToken.None)
            ).ReturnsAsync(vote);

            //Act
            VerifiedData<Vote> result = await subject.GetVote(id, CancellationToken.None);

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
            await subject.CreateBill(
                MockData.PrivateKey,
                MockData.PublicKey,
                new Bill()
                {
                    Title = title,
                    Content = content
                },
                CancellationToken.None
            );

            //Assert
            _billRepositoryMock.Verify(
                repository => repository.Create(It.Is<VerifiedData<Bill>>(
                    bill => bill.Data.Title.Equals(title) && bill.Data.Content.Equals(content)
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
            await subject.CreateVote(
                MockData.PrivateKey,
                MockData.PublicKey,
                new Vote(){
                    BillId = billId,
                    Opinion = opinion,
                    Message = message
                },
                CancellationToken.None
            );

            //Assert
            _voteRepositoryMock.Verify(
                repository => repository.Create(It.Is<VerifiedData<Vote>>(
                    vote => vote.Data.BillId.Equals(billId) &&
                        vote.Data.Opinion.Equals(opinion) &&
                        vote.Data.Message.Equals(message)
                ), CancellationToken.None)
            );
        }
    }
}