using Microsoft.Extensions.DependencyInjection;
using RemoteCongress.Common.Repositories;
using RemoteCongress.Server.DAL.InMemory;
using RemoteCongress.Server.Web.Controllers;
using System;

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

        public void Dispose() => _provider.Dispose();
    }
}
