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
    public class FetchVoteControllerTests
    {
        [TestMethod]
        public async Task FetchVoteTests()
        {
            // Arrange
            using TestContext context = TestContext.Create();
            Vote vote = MockData.GetVote("billId", true, "message");
            string id = await context.SeedVote(vote);
            FetchVoteController subject = context.GetFetchVoteController();

            //Act
            Vote result = await subject.Get(id, CancellationToken.None);

            //Assert
            result.Should().NotBeNull();
            result.Id.Should().NotBeNull();
            result.BillId.Should().Be(vote.BillId);
            result.Opinion.Should().Be(vote.Opinion);
            result.Message.Should().Be(vote.Message);
        }

        [TestMethod]
        public async Task FetchVoteThrowsOnCancelledToken()
        {
            // Arrange
            using TestContext context = TestContext.Create();
            using CancellationTokenSource tokenSource = new CancellationTokenSource();
            tokenSource.Cancel();
            Vote vote = MockData.GetVote("billId", true, "message");
            string id = await context.SeedVote(vote);
            FetchVoteController subject = context.GetFetchVoteController();

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