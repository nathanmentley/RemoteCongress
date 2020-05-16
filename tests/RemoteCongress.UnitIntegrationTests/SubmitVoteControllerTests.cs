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
    public class SubmitVoteControllerTests
    {
        [TestMethod]
        public async Task SubmitVoteTests()
        {
            // Arrange
            using TestContext context = TestContext.Create();
            SubmitVoteController subject = context.GetSubmitVoteController();
            Vote vote = TestData.MockData.GetVote("billId", true, "message");

            //Act
            Vote result = await subject.Post(vote, CancellationToken.None);

            //Assert
            result.Should().NotBeNull();
            result.Id.Should().NotBeNull();
            result.BillId.Should().Be(vote.BillId);
            result.Opinion.Should().Be(vote.Opinion);
            result.Message.Should().Be(vote.Message);
        }

        [TestMethod]
        public void SubmitVoteThrowsOnCancelledToken()
        {
            // Arrange
            using TestContext context = TestContext.Create();
            using CancellationTokenSource tokenSource = new CancellationTokenSource();
            tokenSource.Cancel();

            SubmitVoteController subject = context.GetSubmitVoteController();
            Vote vote = TestData.MockData.GetVote("billId", true, "message");

            Func<Task> action = async () =>
                await subject.Post(vote, tokenSource.Token);

            //Act
            action

            //Assert
                .Should()
                    .Throw<OperationCanceledException>();
        }
    }
}