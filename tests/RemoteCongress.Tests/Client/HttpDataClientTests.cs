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
using RemoteCongress.Client;
using RemoteCongress.Common;
using RemoteCongress.Common.Repositories;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Tests.Client
{
    [TestClass]
    public class HttpDataClientTests
    {
        /*
        private readonly Mock<IBillRepository> _billRepositoryMock =
            new Mock<IBillRepository>();

        private readonly Mock<IVoteRepository> _voteRepositoryMock =
            new Mock<IVoteRepository>();
        */
        private HttpDataClient GetSubject() =>
            new HttpDataClient(
                new ClientConfig("http", "localhost"),
                new HttpClient(),
                "endpoint"
            );

        [TestMethod]
        public void CtorNullClientConfigThrows()
        {
            //Arrange
            Func<HttpDataClient> action = () =>
                new HttpDataClient(
                    null,
                    new HttpClient(),
                    "endpoint"
                );

            //Act
            action

            //Assert
                .Should()
                .Throw<ArgumentNullException>()
                    .And.ParamName.Should()
                        .Be("config");
        }

        [TestMethod]
        public void CtorNullHttpClientThrows()
        {
            //Arrange
            Func<HttpDataClient> action = () =>
                new HttpDataClient(
                    new ClientConfig("http", "localhost"),
                    null,
                    "endpoint"
                );

            //Act
            action

            //Assert
                .Should()
                .Throw<ArgumentNullException>()
                    .And.ParamName.Should()
                        .Be("httpClient");
        }

        [TestMethod]
        public void CtorNullThrows()
        {
            //Arrange
            Func<HttpDataClient> action = () =>
                new HttpDataClient(
                    new ClientConfig("http", "localhost"),
                    new HttpClient(),
                    null
                );

            //Act
            action

            //Assert
                .Should()
                .Throw<ArgumentNullException>()
                    .And.ParamName.Should()
                        .Be("endpoint");
        }

        [TestMethod]
        public void AppendToChainThrowsIfCancelled()
        {
            //arrange
            HttpDataClient subject = GetSubject();
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.Cancel();

            Func<Task> action = async () =>
                await subject.AppendToChain(new SignedData(), cancellationTokenSource.Token);

            //act
            action

            //assert
                .Should()
                .Throw<OperationCanceledException>();
        }

        [TestMethod]
        public void FetchFromChainThrowsIfCancelled()
        {
            //arrange
            HttpDataClient subject = GetSubject();
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.Cancel();

            Func<Task> action = async () =>
                await subject.FetchFromChain("data", cancellationTokenSource.Token);

            //act
            action

            //assert
                .Should()
                .Throw<OperationCanceledException>();
        }
    }
}