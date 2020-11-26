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
using RemoteCongress.Server.Api.Controllers.Bills;
using RemoteCongress.Server.Api.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Tests.Server.Web.Controllers.Bills
{
    [TestClass]
    public class FetchBillControllerTests
    {
        private readonly Mock<ILogger<FetchBillController>> _loggerMock =
            new Mock<ILogger<FetchBillController>>();
        private readonly Mock<IImmutableDataRepository<Bill>> _billRepositoryMock =
            new Mock<IImmutableDataRepository<Bill>>();

        private FetchBillController GetSubject() =>
            new FetchBillController(
                _loggerMock.Object,
                _billRepositoryMock.Object
            );

        [TestMethod]
        public void CtorShouldThrowNullLogger()
        {
            //arrange
            Func<FetchBillController> action = () =>
                new FetchBillController(null, _billRepositoryMock.Object);

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
            Func<FetchBillController> action = () =>
                new FetchBillController(_loggerMock.Object, null);

            //act
            action

            //assert
                .Should()
                .Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("repository");
        }

        [TestMethod]
        public void GetShouldThrowNullBillId()
        {
            //arrange
            FetchBillController subject = GetSubject();

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
            FetchBillController subject = GetSubject();
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
            FetchBillController subject = GetSubject();
            string billId = "billId";
            VerifiedData<Bill> fetchedBill = await MockData.GetBill("title", "content");

            _billRepositoryMock.Setup(
                mock => mock.Fetch(billId, CancellationToken.None)
            ).ReturnsAsync(fetchedBill);

            //act
            VerifiedData<Bill> result = await subject.Get(billId, CancellationToken.None);

            //assert
            result.Should().BeSameAs(fetchedBill);

            _billRepositoryMock.Verify(
                mock => mock.Fetch(billId, CancellationToken.None),
                Times.Once
            );
        }
    }
}