namespace RemoteCongress.Server.DAL.Blockchain
{
    /// <summary>
    /// A base model for a blockchain block
    /// </summary>
    public abstract class BaseBlock
    {
        /// <summary>
        /// The id of the block.
        /// </summary>
        public abstract string Id { get; }

        /// <summary>
        /// Is the block valid
        /// </summary>
        public abstract bool IsValid { get; }
    }
}
