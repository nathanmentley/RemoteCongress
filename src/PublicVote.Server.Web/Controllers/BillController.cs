using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PublicVote.Common;
using PublicVote.Server.Actions;

namespace PublicVote.Controllers
{
    [ApiController]
    [Route("bill")]
    public class BillController
    {
        private readonly ILogger<BillController> _logger;
        private readonly ICreateBillAction _createBillAction;

        public BillController(ILogger<BillController> logger, ICreateBillAction createBillAction)
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));

            _createBillAction = createBillAction ??
                throw new ArgumentNullException(nameof(createBillAction));
        }

        [HttpPost]
        public async Task<Bill> Post(Bill bill) =>
            await _createBillAction.Create(bill);
    }
}