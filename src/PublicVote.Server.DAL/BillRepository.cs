using System;
using System.Threading.Tasks;
using PublicVote.Common;
using PublicVote.Common.Serializers;

namespace PublicVote.Server.DAL
{
    public class BillRepository: IBillRepository
    {
        private readonly static BillSerializer _serializer =
            new BillSerializer();

        private readonly IBlockchainClient _client;

        public BillRepository(IBlockchainClient client)
        {
            _client = client ??
                throw new ArgumentNullException(nameof(client));
        }

        public async Task<Bill> Create(Bill bill)
        {
            bill.Id = await _client.AppendToChain(bill);

            return bill;
        }

        public async Task<Bill> Fetch(string id)
        {
            var data = await _client.FetchFromChain(id);

            return await _serializer.Deserialize(data);
        }
    }
}