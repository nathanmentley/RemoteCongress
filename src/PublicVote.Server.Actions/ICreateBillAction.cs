using PublicVote.Common;
using System.Threading.Tasks;

namespace PublicVote.Server.Actions
{
    public interface ICreateBillAction
    {
        Task<Bill> Create(Bill bill);
    }
}