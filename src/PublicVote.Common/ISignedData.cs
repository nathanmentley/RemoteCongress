namespace PublicVote.Common
{
    public interface ISignedData
    {
        string PublicKey { get; set; }
        string SignedContent { get; set; }
    }
}