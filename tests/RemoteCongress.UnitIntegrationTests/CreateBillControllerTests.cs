using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemoteCongress.Common;
using RemoteCongress.Server.Web.Controllers;
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
            Bill bill = TestData.MockData.GetBill("title", "content");

            //Act
            Bill result = await subject.Post(bill, CancellationToken.None);

            //Assert
            result.Id.Should().NotBeNull();
            result.Title.Should().Be(bill.Title);
            result.Content.Should().Be(bill.Content);
        }
    }
}