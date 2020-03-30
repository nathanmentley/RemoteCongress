using System;
using System.Threading.Tasks;

namespace PublicVote.Common.Serializers
{
    public class VoteSerializer: ISerializer<Vote>
    {
        public Task<Vote> Deserialize(ISignedData data) =>
            throw new NotImplementedException();
    }
}