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
using RemoteCongress.Common.Exceptions;
using RemoteCongress.Common.Repositories;
using RemoteCongress.Common.Repositories.Queries;
using RemoteCongress.Common.Serialization;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Tests.Common.Repositories
{
    [TestClass]
    public class ImmutableDataRepositoryTests
    {
        private readonly Mock<IDataClient> _mockClient =
            new Mock<IDataClient>();
        private readonly Mock<ILogger<ImmutableDataRepository<Bill>>> _mockLogger =
            new Mock<ILogger<ImmutableDataRepository<Bill>>>();

        private readonly IEnumerable<ICodec<Bill>> _codecs =
            new []
            {
                new BillV1JsonCodec(
                    new Mock<ILogger<BillV1JsonCodec>>().Object
                )
            };

        private class FakeImmutableDataRepository : ImmutableDataRepository<Bill>
        {
            public FakeImmutableDataRepository(
                ILogger<ImmutableDataRepository<Bill>> logger,
                IDataClient client,
                IEnumerable<ICodec<Bill>> codecs,
                IQueryProcessor<Bill> queryProcessor
            ) : base(logger, client, codecs, queryProcessor) {}
        }

        private FakeImmutableDataRepository GetSubject() =>
            new FakeImmutableDataRepository(
                _mockLogger.Object,
                _mockClient.Object,
                _codecs,
                new BillQueryProcessor(new Mock<ILogger<BillQueryProcessor>>().Object)
            );

        [TestMethod]
        public void CtorThrowsForNullLogger()
        {
            //Arrange
            Func<FakeImmutableDataRepository> action = () =>
                new FakeImmutableDataRepository(
                    null,
                    _mockClient.Object,
                    _codecs,
                    new BillQueryProcessor(new Mock<ILogger<BillQueryProcessor>>().Object)
                );

            //act
            action

            //assert
                .Should()
                .Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("logger");
        }

        [TestMethod]
        public void CtorThrowsForNullClient()
        {
            //Arrange
            Func<FakeImmutableDataRepository> action = () =>
                new FakeImmutableDataRepository(
                    _mockLogger.Object,
                    null,
                    _codecs,
                    new BillQueryProcessor(new Mock<ILogger<BillQueryProcessor>>().Object)
                );

            //act
            action

            //assert
                .Should()
                .Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("client");
        }

        [TestMethod]
        public void CtorThrowsForNullCreator()
        {
            //Arrange
            Func<FakeImmutableDataRepository> action = () =>
                new FakeImmutableDataRepository(
                    _mockLogger.Object,
                    _mockClient.Object,
                    null,
                    new BillQueryProcessor(new Mock<ILogger<BillQueryProcessor>>().Object)
                );

            //act
            action

            //assert
                .Should()
                .Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("codecs");
        }

        [TestMethod]
        public async Task CreateThrowsIfCancelled()
        {
            //arrange
            FakeImmutableDataRepository subject = GetSubject();
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.Cancel();
            VerifiedData<Bill> bill = await MockData.GetBill("title", "content");

            Func<Task<VerifiedData<Bill>>> action = async () =>
                await subject.Create(bill, cancellationTokenSource.Token);

            //act
            action

            //arrange
                .Should()
                .Throw<OperationCanceledException>();
        }

        [TestMethod]
        public async Task CreateThrowsIfClientReturnsNull()
        {
            //arrange
            FakeImmutableDataRepository subject = GetSubject();
            VerifiedData<Bill> bill = await MockData.GetBill("title", "content");

            Func<Task<VerifiedData<Bill>>> action = async () =>
                await subject.Create(bill, CancellationToken.None);

            //act
            action

            //arrange
                .Should()
                .Throw<BlockNotStorableException>();
        }

        [TestMethod]
        public async Task CreateReturnsIdFromClient()
        {
            //arrange
            FakeImmutableDataRepository subject = GetSubject();
            string id = "abc";
            _mockClient.Setup(client =>
                client.AppendToChain(It.IsAny<ISignedData>(), CancellationToken.None)
            ).ReturnsAsync(id);

            VerifiedData<Bill> bill = await MockData.GetBill("title", "content");

            //act
            VerifiedData<Bill> result = await subject.Create(bill, CancellationToken.None);

            //arrange
            result.Data.Title.Should().Be(bill.Data.Title);
            result.Data.Content.Should().Be(bill.Data.Content);
        }

        [TestMethod]
        public void FetchThrowsIfCancelled()
        {
            //arrange
            FakeImmutableDataRepository subject = GetSubject();
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.Cancel();

            Func<Task<VerifiedData<Bill>>> action = async () =>
                await subject.Fetch("id", cancellationTokenSource.Token);

            //act
            action

            //arrange
                .Should()
                .Throw<OperationCanceledException>();
        }

        [TestMethod]
        public void FetchThrowsIfIdIsNull()
        {
            //arrange
            FakeImmutableDataRepository subject = GetSubject();

            Func<Task<VerifiedData<Bill>>> action = async () =>
                await subject.Fetch("id", CancellationToken.None);

            //act
            action

            //arrange
                .Should()
                .Throw<BlockNotFoundException>();
        }

        [TestMethod]
        public async Task FetchReturnsBlockFromClient()
        {
            //arrange
            FakeImmutableDataRepository subject = GetSubject();

            VerifiedData<Bill> bill = await MockData.GetBill("id", "title", "content");

            _mockClient.Setup(client =>
                client.FetchFromChain(
                    "id",
                    CancellationToken.None
                )
            ).ReturnsAsync(bill);

            //act
            VerifiedData<Bill> result = await subject.Fetch("id", CancellationToken.None);

            //arrange
            result.Id.Should().Be(bill.Id);
            result.Data.Title.Should().Be(bill.Data.Title);
            result.Data.Content.Should().Be(bill.Data.Content);
        }
    }
}