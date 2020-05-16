/*
    RemoteCongress - A platform for conducting small secure public elections
    Copyright (C) 2020  Nathan Mentley

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU Affero General Public License as published
    by the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Affero General Public License for more details.

    You should have received a copy of the GNU Affero General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/
using Newtonsoft.Json.Linq;
using RemoteCongress.Common;
using RemoteCongress.Common.Encryption;
using RemoteCongress.Common.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Client
{
    /// <summary>
    /// A client used to interact with the RemoteCongress api.
    /// </summary>
    public class RemoteCongressClient: IRemoteCongressClient
    {
        private readonly IBillRepository _billRepository;
        private readonly IVoteRepository _voteRepository;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="billRepository">
        /// An <see cref="IBillRepository"/> instance to use to interact with <see cref="Bill"/>s.
        /// </param>
        /// <param name="voteRepository">
        /// An <see cref="IVoteRepository"/> instance to use to interact with <see cref="Vote"/>s.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="billRepository"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="voteRepository"/> is null.
        /// </exception>
        public RemoteCongressClient(
            IBillRepository billRepository,
            IVoteRepository voteRepository
        )
        {
            _billRepository = billRepository ??
                throw new ArgumentNullException(nameof(billRepository));

            _voteRepository = voteRepository ??
                throw new ArgumentNullException(nameof(voteRepository));
        }

        /// <summary>
        /// Creates, signs, and persists a <see cref="Bill"/> instance.
        /// </summary>
        /// <param name="privateKey">
        /// The private key to use to generate the <see cref="ISignedData.Signature"/> of the <see cref="Bill"/>.
        /// </param>
        /// <param name="publicKey">
        /// The public key that matches <paramref name="privateKey"/> to link the immutable <see cref="Bill"/> to
        ///     the producing individual.
        /// </param>
        /// <param name="title">
        /// The title of the <see cref="Bill"/>.
        /// </param>
        /// <param name="content">
        /// The content of the <see cref="Bill"/>.
        /// </param>
        /// <returns>
        /// The persisted <see cref="Bill"/>.
        /// </returns>
        public async Task<Bill> CreateBill(
            string privateKey,
            string publicKey,
            string title,
            string content,
            CancellationToken cancellationToken
        )
        {
            var blockContent = JToken.FromObject(new {
                title = title,
                content = content
            }).ToString();

            var signedData = new SignedData(
                publicKey,
                blockContent,
                RsaUtils.GenerateSignature(privateKey, blockContent)
            );

            var bill = new Bill(signedData);

            return await _billRepository.Create(bill, cancellationToken);
        }

        /// <summary>
        /// Fetches a signed, and verified <see cref="Bill"/> by it's <see cref="IIdentifiable.Id"/>.
        /// </summary>
        /// <param name="id">
        /// The <see cref="IIdentifiable.Id"/> of the <see cref="Bill"/>.
        /// </param>
        /// <returns>
        /// The persisted <see cref="Bill"/>.
        /// </returns>
        public async Task<Bill> GetBill(string id, CancellationToken cancellationToken) =>
            await _billRepository.Fetch(id, cancellationToken);

        /// <summary>
        /// Creates, signs, and persists a <see cref="Vote"/> instance.
        /// </summary>
        /// <param name="privateKey">
        /// The private key to use to generate the <see cref="ISignedData.Signature"/> of the <see cref="Vote"/>.
        /// </param>
        /// <param name="publicKey">
        /// The public key that matches <paramref name="privateKey"/> to link the immutable <see cref="Vote"/> to
        ///     the producing individual.
        /// </param>
        /// <param name="billId">
        /// The <see cref="IIdentifiable.Id"/> of the <see cref="Bill"/> related to the <see cref="Vote"/>.
        /// </param>
        /// <param name="opinion">
        /// The opinion in the <see cref="Vote"/>.
        /// </param>
        /// <param name="message">
        /// The optional message attached to the <see cref="Vote"/>.
        /// </param>
        /// <returns>
        /// The persisted <see cref="Vote"/>.
        /// </returns>
        public async Task<Vote> CreateVote(
            string privateKey,
            string publicKey,
            string billId,
            bool? opinion,
            string message,
            CancellationToken cancellationToken
        )
        {
            var blockContent = JToken.FromObject(new {
                billId = billId,
                opinion = opinion,
                message = message
            }).ToString();

            var signedData = new SignedData(
                publicKey,
                blockContent,
                RsaUtils.GenerateSignature(privateKey, blockContent)
            );

            var vote = new Vote(signedData);

            return await _voteRepository.Create(vote, cancellationToken);
        }

        /// <summary>
        /// Fetches a signed, and verified <see cref="Vote"/> by it's <see cref="IIdentifiable.Id"/>.
        /// </summary>
        /// <param name="id">
        /// The <see cref="IIdentifiable.Id"/> of the <see cref="Vote"/>.
        /// </param>
        /// <returns>
        /// The persisted <see cref="Vote"/>.
        /// </returns>
        public async Task<Vote> GetVote(string id, CancellationToken cancellationToken) =>
            await _voteRepository.Fetch(id, cancellationToken);
    }
}