using System.Threading.Tasks;

namespace PublicVote.Common.Serializers
{
    public interface ISerializer<T>
        where T: ISignedData
    {
        Task<T> Deserialize(ISignedData data);
    }
}