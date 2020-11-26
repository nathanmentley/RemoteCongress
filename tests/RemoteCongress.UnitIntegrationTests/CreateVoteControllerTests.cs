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
    public class CreateVoteControllerTests
    {
        [TestMethod]
        public async Task CreateVoteTests()
        {
            // Arrange
            using TestContext context = TestContext.Create();
            CreateVoteController subject = context.GetCreateVoteController();
            VerifiedData<Vote> vote = await MockData.GetVote("billId", true, "message");

            //Act
            VerifiedData<Vote> result = await subject.Post(vote, CancellationToken.None);

            //Assert
            result.Should().NotBeNull();
            result.Id.Should().NotBeNull();
            result.Data.BillId.Should().Be(vote.Data.BillId);
            result.Data.Opinion.Should().Be(vote.Data.Opinion);
            result.Data.Message.Should().Be(vote.Data.Message);
        }

        [TestMethod]
        public async Task CreateVoteThrowsOnCancelledToken()
        {
            // Arrange
            using TestContext context = TestContext.Create();
            using CancellationTokenSource tokenSource = new CancellationTokenSource();
            tokenSource.Cancel();

            CreateVoteController subject = context.GetCreateVoteController();
            VerifiedData<Vote> vote = await MockData.GetVote("billId", true, "message");

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