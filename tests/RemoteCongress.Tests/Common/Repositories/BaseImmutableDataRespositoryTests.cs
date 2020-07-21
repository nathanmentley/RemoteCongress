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
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Tests.Common.Repositories
{
    [TestClass]
    public class BaseImmutableDataRepositoryTests
    {
        private readonly Mock<IDataClient> _mockClient =
            new Mock<IDataClient>();
        private readonly Mock<ILogger> _mockLogger =
            new Mock<ILogger>();

        private class FakeImmutableDataRepository : BaseImmutableDataRepository<Bill>
        {
            public FakeImmutableDataRepository(
                ILogger logger,
                IDataClient client,
                Func<string, ISignedData, Bill> creator
            ) : base(logger, client, creator) {}
        }

        private FakeImmutableDataRepository GetSubject() =>
            new FakeImmutableDataRepository(
                _mockLogger.Object,
                _mockClient.Object,
                (id, data) => new Bill(id, data)
            );

        [TestMethod]
        public void CtorThrowsForNullLogger()
        {
            //Arrange
            Func<FakeImmutableDataRepository> action = () =>
                new FakeImmutableDataRepository(
                    null,
                _mockClient.Object,
                    (id, data) => new Bill(id, data)
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
                    (id, data) => new Bill(id, data)
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
                    null
                );

            //act
            action

            //assert
                .Should()
                .Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("creator");
        }

        [TestMethod]
        public void CreateThrowsIfCancelled()
        {
            //arrange
            FakeImmutableDataRepository subject = GetSubject();
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.Cancel();

            Func<Task<Bill>> action = async () =>
                await subject.Create(MockData.GetBill("title", "content"), cancellationTokenSource.Token);

            //act
            action

            //arrange
                .Should()
                .Throw<OperationCanceledException>();
        }

        [TestMethod]
        public void CreateThrowsIfClientReturnsNull()
        {
            //arrange
            FakeImmutableDataRepository subject = GetSubject();

            Func<Task<Bill>> action = async () =>
                await subject.Create(MockData.GetBill("title", "content"), CancellationToken.None);

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

            //act
            Bill result = await subject.Create(MockData.GetBill("title", "content"), CancellationToken.None);

            //arrange
            result.Id.Should().Be(id);
        }

        [TestMethod]
        public void FetchThrowsIfCancelled()
        {
            //arrange
            FakeImmutableDataRepository subject = GetSubject();
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.Cancel();

            Func<Task<Bill>> action = async () =>
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

            Func<Task<Bill>> action = async () =>
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

            Bill bill = MockData.GetBill("id", "title", "content");
            _mockClient.Setup(client =>
                client.FetchFromChain(
                    "id",
                    CancellationToken.None
                )
            ).ReturnsAsync(bill);

            //act
            Bill result = await subject.Fetch("id", CancellationToken.None);

            //arrange
            result.Id.Should().Be(bill.Id);
            result.Title.Should().Be(bill.Title);
            result.Content.Should().Be(bill.Content);
        }
    }
}