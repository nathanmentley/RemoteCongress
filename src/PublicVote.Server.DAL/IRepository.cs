using PublicVote.Common;
using System.Threading.Tasks;

namespace PublicVote.Server.DAL
{
    public interface IRepository<T>
        where T: IIdentifiable
    {
        Task<T> Create(T instance);

        Task<T> Fetch(string id);
    }
}