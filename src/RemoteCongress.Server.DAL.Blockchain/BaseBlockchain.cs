using RemoteCongress.Common;
using RemoteCongress.Common.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace RemoteCongress.Server.DAL.Blockchain
{
    /// <summary>
    /// A base blockchain class
    /// </summary>
    /// <typeparam name="TBlock">
    /// The block model stored in the blockchain
    /// </typeparam>
    public abstract class BaseBlockchain<TBlock>
        where TBlock: BaseBlock
    {
        /// <summary>
        /// The in memory collection of blocks in the chain.
        /// </summary>
        private readonly IList<TBlock> _blocks;

        /// <summary>
        /// A <typeparamref name="TBlock"/> is valid if:
        /// <list>
        ///     <item>Every <typeparamref name="TBlock"/>'s <typeparamref name="TBlock.IsValid"/> is true</item>
        ///     <item>Every <typeparamref name="TBlock"/>'s <typeparamref name="TBlock.LastBlockHash"/> matches the previous <typeparamref name="TBlock"/>'s <typeparamref name="TBlock.Hash"/>.</item>
        /// </list>
        /// </summary>
        public bool IsValid => !_blocks.Any(block => !block.IsValid);

        /// <summary>
        /// Constructor
        /// </summary>
        protected BaseBlockchain()
        {
            _blocks = new ConcurrentList.ConcurrentList<TBlock>();

            _blocks.Add(GenerateGenisysBlock());
        }

        /// <summary>
        /// Creates a genisys block.
        /// </summary>
        /// <returns>
        /// The genisys block
        /// </returns>
        protected abstract TBlock GenerateGenisysBlock();

        /// <summary>
        /// Creates a new block
        /// </summary>
        /// <param name="last">
        /// The previous block
        /// </param>
        /// <param name="content">
        /// The block content
        /// </param>
        /// <param name="mediaType">
        /// The mediatype of the block
        /// </param>
        /// <returns>
        /// The created block
        /// </returns>
        protected abstract TBlock GenerateBlock(TBlock last, string content, RemoteCongressMediaType mediaType);

        /// <summary>
        /// Appends data to the blockchain.
        /// </summary>
        /// <param name="content">
        /// The raw content to append to the blockchain.
        /// </param>
        /// <param name="mediaType">
        /// The <see cref="RemoteCongressMediaType"/> of the block to append.
        /// </param>
        /// <returns>
        /// The created <typeparamref name="TBlock"/> that contains <paramref name="content"/>.
        /// </returns>
        public TBlock AppendToChain(string content, RemoteCongressMediaType mediaType)
        {
            TBlock block = GenerateBlock(_blocks.Last(), content, mediaType);

            lock(_blocks)
            {
                _blocks.Add(block);
            }

            return block;
        }

        /// <summary>
        /// Fetches a <typeparamref name="TBlock"/> by <paramref name="id"/>.
        /// </summary>
        /// <param name="id">
        /// The unique identifier to look up the <typeparamref name="TBlock"/> by.
        /// </param>
        /// <returns>
        /// The matching <typeparamref name="TBlock"/>, or null if it's not found.
        /// /// </returns>
        public TBlock FetchFromChain(string id) =>
            _blocks.FirstOrDefault(block => block.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

        /// <summary>
        /// Fetches all matching blocks from the chain
        /// </summary>
        /// <param name="query">
        /// A collection of queries to match each block on.
        /// </param>
        /// <param name="cancellationToken">
        /// A token to handle cancellation
        /// </param>
        /// <returns>
        /// The matching blocks from the chain
        /// </returns>
        #pragma warning disable CS1998 //We want this to be an async method in the interface, but it's not here.
        public async IAsyncEnumerable<TBlock> FetchAllFromChain(
            IEnumerable<IQuery> query,
            [EnumeratorCancellation] CancellationToken cancellationToken
        )
        {
            foreach(TBlock block in _blocks.Skip(1))
            {
                cancellationToken.ThrowIfCancellationRequested();

                yield return block;
            }
        }
        #pragma warning restore CS1998
    }
}
