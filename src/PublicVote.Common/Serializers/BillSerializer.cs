using System;
using System.Threading.Tasks;

namespace PublicVote.Common.Serializers
{
    public class BillSerializer: ISerializer<Bill>
    {
        public Task<Bill> Deserialize(ISignedData data) =>
            throw new NotImplementedException();
    }
}