using Microsoft.Extensions.DependencyInjection;
using RemoteCongress.Common;
using RemoteCongress.Common.Repositories;
using RemoteCongress.Server.DAL.InMemory;
using RemoteCongress.Server.Web.Controllers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.UnitIntegrationTests
{
    public class TestContext: IDisposable
    {
        private readonly ServiceProvider _provider;

        private TestContext()
        {
            _provider = new ServiceCollection()
                .AddSingleton<IDataClient, InMemoryBlockchainClient>()

                .AddSingleton<IBillRepository, BillRepository>()
                .AddSingleton<IVoteRepository, VoteRepository>()
                
                .AddSingleton<CreateBillController>()
                .AddSingleton<FetchBillController>()
                .AddSingleton<SubmitVoteController>()
                .AddSingleton<FetchVoteController>()

                .AddLogging()

                .BuildServiceProvider();
        }

        public static TestContext Create() => new TestContext();

        public CreateBillController GetCreateBillController() =>
            _provider.GetRequiredService<CreateBillController>();

        public FetchBillController GetFetchBillController() =>
            _provider.GetRequiredService<FetchBillController>();

        public SubmitVoteController GetSubmitVoteController() =>
            _provider.GetRequiredService<SubmitVoteController>();

        public FetchVoteController GetFetchVoteController() =>
            _provider.GetRequiredService<FetchVoteController>();

        public async Task<string> SeedBill(Bill bill)
        {
            CreateBillController controller = GetCreateBillController();

            Bill result = await controller.Post(bill, CancellationToken.None);

            return result.Id;
        }

        public async Task<string> SeedVote(Vote vote)
        {
            SubmitVoteController controller = GetSubmitVoteController();

            Vote result = await controller.Post(vote, CancellationToken.None);

            return result.Id;
        }

        public void Dispose() => _provider.Dispose();
    }
}
