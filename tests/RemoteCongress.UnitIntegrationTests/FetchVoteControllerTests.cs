using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemoteCongress.Common;
using RemoteCongress.Server.Api.Controllers.Votes;
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
            VerifiedData<Vote> vote = await MockData.GetVote("billId", true, "message");
            string id = await context.SeedVote(vote);
            FetchVoteController subject = context.GetFetchVoteController();

            //Act
            VerifiedData<Vote> result = await subject.Get(id, CancellationToken.None);

            //Assert
            result.Should().NotBeNull();
            result.Id.Should().NotBeNull();
            result.Data.BillId.Should().Be(vote.Data.BillId);
            result.Data.Opinion.Should().Be(vote.Data.Opinion);
            result.Data.Message.Should().Be(vote.Data.Message);
        }

        [TestMethod]
        public async Task FetchVoteThrowsOnCancelledToken()
        {
            // Arrange
            using TestContext context = TestContext.Create();
            using CancellationTokenSource tokenSource = new CancellationTokenSource();
            tokenSource.Cancel();
            VerifiedData<Vote> vote = await MockData.GetVote("billId", true, "message");
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