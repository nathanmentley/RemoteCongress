namespace PublicVote.Common
{
    public class Bill: IIdentifiable, ISignedData
    {
        public string Id { get; set; }

        public string PublicKey { get; set; }
        public string SignedContent { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
    }
}