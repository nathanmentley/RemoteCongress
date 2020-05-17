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
    public class CreateBillControllerTests
    {
        [TestMethod]
        public async Task CreateBillTests()
        {
            // Arrange
            using TestContext context = TestContext.Create();
            CreateBillController subject = context.GetCreateBillController();
            Bill bill = MockData.GetBill("title", "content");

            //Act
            Bill result = await subject.Post(bill, CancellationToken.None);

            //Assert
            result.Should().NotBeNull();
            result.Id.Should().NotBeNull();
            result.Title.Should().Be(bill.Title);
            result.Content.Should().Be(bill.Content);
        }

        [TestMethod]
        public void CreateBillThrowsOnCancelledToken()
        {
            // Arrange
            using TestContext context = TestContext.Create();
            using CancellationTokenSource tokenSource = new CancellationTokenSource();
            tokenSource.Cancel();

            CreateBillController subject = context.GetCreateBillController();
            Bill bill = MockData.GetBill("title", "content");

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