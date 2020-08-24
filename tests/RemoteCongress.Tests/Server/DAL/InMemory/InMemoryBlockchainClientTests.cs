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
using RemoteCongress.Server.DAL.InMemory;
using RemoteCongress.Common;
using System;
using System.Threading;
using System.Threading.Tasks;
using RemoteCongress.Common.Exceptions;
using RemoteCongress.Common.Serialization;

namespace RemoteCongress.Tests.Server.DAL.InMemory
{
    [TestClass]
    public class InMemoryBlockchainClientTests
    {
        private InMemoryBlockchainClient GetSubject() =>
            new InMemoryBlockchainClient(
                new [] {
                    new SignedDataV1JsonCodec()
                }
            );

        [TestMethod]
        public void AppendToChainShouldThrowNullData()
        {
            //Arrange
            var subject = GetSubject();

            Func<Task<string>> action = async () =>
                await subject.AppendToChain(null, CancellationToken.None);

            //Act
            action

            //arrange
                .Should()
                .Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("data");
        }

        [TestMethod]
        public void AppendToChainShouldThrowOnCancel()
        {
            //Arrange
            var subject = GetSubject();
            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.Cancel();

            Func<Task<string>> action = async () =>
                await subject.AppendToChain(
                    await MockData.GetBill("title", "content"),
                    cancellationTokenSource.Token
                );

            //Act
            action

            //arrange
                .Should()
                .Throw<OperationCanceledException>();
        }

        [TestMethod]
        public async Task AppendToChainSuccess()
        {
            //Arrange
            var subject = GetSubject();

            //Act
            var result = await subject.AppendToChain(
                await MockData.GetBill("title", "content"),
                CancellationToken.None
            );

            //arrange
            result.Should().NotBeNullOrWhiteSpace();
        }

        [TestMethod]
        public void FetchFromChainShouldThrowNullData()
        {
            //Arrange
            var subject = GetSubject();

            Func<Task<ISignedData>> action = async () =>
                await subject.FetchFromChain(null, CancellationToken.None);

            //Act
            action

            //arrange
                .Should()
                .Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("id");
        }

        [TestMethod]
        public void FetchFromChainShouldThrowOnCancel()
        {
            //Arrange
            var subject = GetSubject();
            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.Cancel();

            Func<Task<ISignedData>> action = async () =>
                await subject.FetchFromChain(
                    "id",
                    cancellationTokenSource.Token
                );

            //Act
            action

            //arrange
                .Should()
                .Throw<OperationCanceledException>();
        }

        [TestMethod]
        public void FetchFromChainThrowsForNotFound()
        {
            //Arrange
            var subject = GetSubject();

            Func<Task<ISignedData>> action = async () =>
                await subject.FetchFromChain(
                    "id",
                    CancellationToken.None
                );

            //Act
            action

            //arrange
                .Should()
                .Throw<BlockNotFoundException>();
        }

        [TestMethod]
        public async Task FetchFromChainSuccess()
        {
            //Arrange
            var subject = GetSubject();

            var id = await subject.AppendToChain(
                await MockData.GetBill("title", "content"),
                CancellationToken.None
            );

            //Act
            var result = await subject.FetchFromChain(
                id,
                CancellationToken.None
            );

            //arrange
            result.IsValid.Should().BeTrue();
        }
    }
}