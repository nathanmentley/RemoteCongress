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
    public class CreateBillControllerTests
    {
        private readonly Mock<ILogger<CreateBillController>> _loggerMock =
            new Mock<ILogger<CreateBillController>>();
        private readonly Mock<IImmutableDataRepository<Bill>> _billRepositoryMock =
            new Mock<IImmutableDataRepository<Bill>>();

        private CreateBillController GetSubject() =>
            new CreateBillController(
                _loggerMock.Object,
                _billRepositoryMock.Object
            );

        [TestMethod]
        public void CtorShouldThrowNullLogger()
        {
            //arrange
            Func<CreateBillController> action = () =>
                new CreateBillController(null, _billRepositoryMock.Object);

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
            Func<CreateBillController> action = () =>
                new CreateBillController(_loggerMock.Object, null);

            //act
            action

            //assert
                .Should()
                .Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("billRepository");
        }

        [TestMethod]
        public void PostShouldThrowNullBill()
        {
            //arrange
            CreateBillController subject = GetSubject();

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
            CreateBillController subject = GetSubject();
            using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.Cancel();
            VerifiedData<Bill> billToCreate = await MockData.GetBill("title", "content");

            Func<Task> action = async () =>
                await subject.Post(billToCreate, cancellationTokenSource.Token);

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
            CreateBillController subject = GetSubject();
            VerifiedData<Bill> billToCreate = await MockData.GetBill("title", "content");
            VerifiedData<Bill> createdBill = await MockData.GetBill("title", "content");

            _billRepositoryMock.Setup(
                mock => mock.Create(billToCreate, CancellationToken.None)
            ).ReturnsAsync(createdBill);

            //act
            VerifiedData<Bill> result = await subject.Post(billToCreate, CancellationToken.None);

            //assert
            result.Should().BeSameAs(createdBill);

            _billRepositoryMock.Verify(
                mock => mock.Create(billToCreate, CancellationToken.None),
                Times.Once
            );
        }
    }
}