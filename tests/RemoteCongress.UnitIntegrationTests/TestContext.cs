using Microsoft.Extensions.DependencyInjection;
using RemoteCongress.Common;
using RemoteCongress.Common.Repositories;
using RemoteCongress.Common.Serialization;
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

                .AddSingleton<ICodec<SignedData>, SignedDataV1JsonCodec>()
                .AddSingleton<ICodec<SignedData>, SignedDataV1AvroCodec>()
                .AddSingleton<ICodec<Bill>, BillV1AvroCodec>()
                .AddSingleton<ICodec<Bill>, BillV1JsonCodec>()
                .AddSingleton<ICodec<Vote>, VoteV1AvroCodec>()
                .AddSingleton<ICodec<Vote>, VoteV1JsonCodec>()

                .AddSingleton<IImmutableDataRepository<Bill>, ImmutableDataRepository<Bill>>()
                .AddSingleton<IImmutableDataRepository<Vote>, ImmutableDataRepository<Vote>>()
                
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

        public async Task<string> SeedBill(VerifiedData<Bill> bill)
        {
            CreateBillController controller = GetCreateBillController();

            VerifiedData<Bill> result = await controller.Post(bill, CancellationToken.None);

            return result.Id;
        }

        public async Task<string> SeedVote(VerifiedData<Vote> vote)
        {
            SubmitVoteController controller = GetSubmitVoteController();

            VerifiedData<Vote> result = await controller.Post(vote, CancellationToken.None);

            return result.Id;
        }

        public void Dispose() => _provider.Dispose();
    }
}
