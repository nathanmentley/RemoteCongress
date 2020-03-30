using PublicVote.Common;
using PublicVote.Common.Serializers;

namespace PublicVote.Server.Web.Formatters
{
    public class BillInputFormatter: BaseInputFormatter<Bill>
    {
        public BillInputFormatter(ISerializer<Bill> serializer): base(serializer) {}
    }
}