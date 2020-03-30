namespace PublicVote.Common
{
    public class Vote: IIdentifiable, ISignedData
    {
        public string Id { get; set; }

        public string PublicKey { get; set; }
        public string SignedContent { get; set; }

        public string BillId { get; set; }
        public bool? Opinion { get; set; }
        public string Message { get; set; }
    }
}