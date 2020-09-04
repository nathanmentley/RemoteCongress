using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemoteCongress.Common;
using RemoteCongress.Server.Web.Controllers.Bills;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.UnitIntegrationTests
{
    [TestClass]
    public class CreateBillControllerTests
    {
        [TestMethod]
        public async Task CreateBillTests()
        {
            // Arrange
            using TestContext context = TestContext.Create();
            CreateBillController subject = context.GetCreateBillController();
            VerifiedData<Bill> bill = await MockData.GetBill("title", "content");

            //Act
            VerifiedData<Bill> result = await subject.Post(bill, CancellationToken.None);

            //Assert
            result.Should().NotBeNull();
            result.Id.Should().NotBeNull();
            result.Data.Title.Should().Be(bill.Data.Title);
            result.Data.Content.Should().Be(bill.Data.Content);
        }

        [TestMethod]
        public async Task CreateBillThrowsOnCancelledToken()
        {
            // Arrange
            using TestContext context = TestContext.Create();
            using CancellationTokenSource tokenSource = new CancellationTokenSource();
            tokenSource.Cancel();

            CreateBillController subject = context.GetCreateBillController();
            VerifiedData<Bill> bill = await MockData.GetBill("title", "content");

            Func<Task> action = async () =>
                await subject.Post(bill, tokenSource.Token);

            //Act
            action

            //Assert
                .Should()
                    .Throw<OperationCanceledException>();
        }
    }
}