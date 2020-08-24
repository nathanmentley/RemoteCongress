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
using Moq.Protected;
using RemoteCongress.Client;
using RemoteCongress.Common;
using RemoteCongress.Common.Serialization;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Tests.Client
{
    [TestClass]
    public class HttpDataClientTests
    {
        private readonly Mock<HttpMessageHandler> handlerMock =
            new Mock<HttpMessageHandler>(MockBehavior.Strict);

        private readonly Mock<ILogger<HttpDataClient>> mockLogger =
            new Mock<ILogger<HttpDataClient>>();
 
        private readonly IEnumerable<ICodec<SignedData>> _codecs =
            new [] {
                new SignedDataV1JsonCodec()
            };

        private HttpClient GetClient(HttpResponseMessage response)
        {
            handlerMock
               .Protected()
               // Setup the PROTECTED method to mock
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               // prepare the expected response of the mocked http call
               .ReturnsAsync(response)
               .Verifiable();

            return new HttpClient(handlerMock.Object)
            {
               BaseAddress = new Uri("http://localhost/"),
            };
        }

        private HttpDataClient GetSubject(HttpResponseMessage response) =>
            new HttpDataClient(
                mockLogger.Object,
                new ClientConfig("http", "localhost"),
                GetClient(response),
                _codecs,
                "endpoint"
            );

        [TestMethod]
        public void CtorNullLoggerThrows()
        {
            //Arrange
            Func<HttpDataClient> action = () =>
                new HttpDataClient(
                    null,
                    new ClientConfig("http", "localhost"),
                    new HttpClient(),
                    _codecs,
                    "endpoint"
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
        public void CtorNullClientConfigThrows()
        {
            //Arrange
            Func<HttpDataClient> action = () =>
                new HttpDataClient(
                    mockLogger.Object,
                    null,
                    new HttpClient(),
                    _codecs,
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
                    mockLogger.Object,
                    new ClientConfig("http", "localhost"),
                    null,
                    _codecs,
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
        public void CtorNullCodecThrows()
        {
            //Arrange
            Func<HttpDataClient> action = () =>
                new HttpDataClient(
                    mockLogger.Object,
                    new ClientConfig("http", "localhost"),
                    new HttpClient(),
                    null,
                    "endpoint"
                );

            //Act
            action

            //Assert
                .Should()
                .Throw<ArgumentNullException>()
                    .And.ParamName.Should()
                        .Be("codec");
        }

        [TestMethod]
        public void CtorNullThrows()
        {
            //Arrange
            Func<HttpDataClient> action = () =>
                new HttpDataClient(
                    mockLogger.Object,
                    new ClientConfig("http", "localhost"),
                    new HttpClient(),
                    _codecs,
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
            HttpResponseMessage response = new HttpResponseMessage()
            {
               StatusCode = HttpStatusCode.OK,
               Content = new StringContent("[{'id':1,'value':'1'}]"),
            };
            HttpDataClient subject = GetSubject(response);
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
        public async Task AppendToChainSucess()
        {
            //arrange
            VerifiedData<Bill> bill = await MockData.GetBill("abc", "title", "content");
            HttpResponseMessage response = new HttpResponseMessage()
            {
               StatusCode = HttpStatusCode.OK,
               Content = new StringContent(await MockData.GetJson(bill)),
            };
            HttpDataClient subject = GetSubject(response);

            //act
            string id = await subject.AppendToChain(
                bill,
                CancellationToken.None
            );

            //assert
            id.Should().Be(bill.Id);
        }

        [TestMethod]
        public void FetchFromChainThrowsIfCancelled()
        {
            //arrange
            HttpResponseMessage response = new HttpResponseMessage()
            {
               StatusCode = HttpStatusCode.OK,
               Content = new StringContent("{'id':1}"),
            };
            HttpDataClient subject = GetSubject(response);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.Cancel();

            Func<Task> action = async () =>
                await subject.FetchFromChain("id", cancellationTokenSource.Token);

            //act
            action

            //assert
                .Should()
                .Throw<OperationCanceledException>();
        }

        [TestMethod]
        public async Task FetchFromChainSuccess()
        {
            //arrange
            VerifiedData<Bill> bill = await MockData.GetBill("id", "title", "content");
            HttpResponseMessage response = new HttpResponseMessage()
            {
               StatusCode = HttpStatusCode.OK,
               Content = new StringContent(await MockData.GetJson(bill))
            };
            HttpDataClient subject = GetSubject(response);

            //act
            ISignedData result = await subject.FetchFromChain("id", CancellationToken.None);

            //assert
            result.BlockContent.Should().Be(bill.BlockContent);
            result.IsValid.Should().BeTrue();
        }
    }
}