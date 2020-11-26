using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemoteCongress.Common;
using RemoteCongress.Server.Api.Controllers.Bills;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.UnitIntegrationTests
{
    [TestClass]
    public class FetchBillControllerTests
    {
        [TestMethod]
        public async Task FetchBillTests()
        {
            // Arrange
            using TestContext context = TestContext.Create();
            VerifiedData<Bill> bill = await MockData.GetBill("title", "content");
            string id = await context.SeedBill(bill);
            FetchBillController subject = context.GetFetchBillController();

            //Act
            VerifiedData<Bill> result = await subject.Get(id, CancellationToken.None);

            //Assert
            result.Should().NotBeNull();
            result.Id.Should().NotBeNull();
            result.Data.Title.Should().Be(bill.Data.Title);
            result.Data.Content.Should().Be(bill.Data.Content);
        }

        [TestMethod]
        public async Task FetchBillThrowsOnCancelledToken()
        {
            // Arrange
            using TestContext context = TestContext.Create();
            using CancellationTokenSource tokenSource = new CancellationTokenSource();
            tokenSource.Cancel();
            VerifiedData<Bill> bill = await MockData.GetBill("title", "content");
            string id = await context.SeedBill(bill);
            FetchBillController subject = context.GetFetchBillController();

            Func<Task> action = async () =>
                await subject.Get(id, tokenSource.Token);

            //Act
            action

            //Assert
                .Should()
                    .Throw<OperationCanceledException>();
        }
    }
}