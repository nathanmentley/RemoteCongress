using System;
using System.Threading.Tasks;
using PublicVote.Common;
using PublicVote.Server.DAL;

namespace PublicVote.Server.Actions
{
    public class CreateBillAction: ICreateBillAction
    {
        private readonly IBillRepository _billRepository;

        public CreateBillAction(IBillRepository billRepository)
        {
            _billRepository = billRepository ??
                throw new ArgumentNullException(nameof(billRepository));
        }

        public Task<Bill> Create(Bill bill) =>
            _billRepository.Create(bill);
    }
}