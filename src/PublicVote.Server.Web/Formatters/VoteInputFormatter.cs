using PublicVote.Common;
using PublicVote.Common.Serializers;

namespace PublicVote.Server.Web.Formatters
{
    public class VoteInputFormatter: BaseInputFormatter<Vote>
    {
        public VoteInputFormatter(ISerializer<Vote> serializer): base(serializer) {}
    }
}