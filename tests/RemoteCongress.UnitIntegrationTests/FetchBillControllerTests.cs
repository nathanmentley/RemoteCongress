using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemoteCongress.Common;
using RemoteCongress.Server.Web.Controllers;
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
            Bill bill = MockData.GetBill("title", "content");
            string id = await context.SeedBill(bill);
            FetchBillController subject = context.GetFetchBillController();

            //Act
            Bill result = await subject.Get(id, CancellationToken.None);

            //Assert
            result.Should().NotBeNull();
            result.Id.Should().NotBeNull();
            result.Title.Should().Be(bill.Title);
            result.Content.Should().Be(bill.Content);
        }

        [TestMethod]
        public async Task FetchBillThrowsOnCancelledToken()
        {
            // Arrange
            using TestContext context = TestContext.Create();
            using CancellationTokenSource tokenSource = new CancellationTokenSource();
            tokenSource.Cancel();
            Bill bill = MockData.GetBill("title", "content");
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