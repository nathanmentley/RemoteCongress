using PublicVote.Common;

namespace PublicVote.Server.DAL
{
    public class SignedData: ISignedData
    {
        public string PublicKey { get; set; }
        public string SignedContent { get; set; }
    }
}