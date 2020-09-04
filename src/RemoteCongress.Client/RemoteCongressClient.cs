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
using RemoteCongress.Common;
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
        private readonly IEndpointClient<Bill> _billClient;
        private readonly IEndpointClient<Member> _memberClient;
        private readonly IEndpointClient<Vote> _voteClient;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="billClient">
        /// </param>
        /// <param name="memberClient">
        /// </param>
        /// <param name="voteClient">
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="billClient"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="memberClient"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="voteClient"/> is null.
        /// </exception>
        public RemoteCongressClient(
            IEndpointClient<Bill> billClient,
            IEndpointClient<Member> memberClient,
            IEndpointClient<Vote> voteClient
        )
        {
            _billClient = billClient ??
                throw new ArgumentNullException(nameof(billClient));

            _memberClient = memberClient ??
                throw new ArgumentNullException(nameof(memberClient));

            _voteClient = voteClient ??
                throw new ArgumentNullException(nameof(voteClient));
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
        /// <param name="data">
        /// The <see cref="Bill"/> data to persist.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation requests.
        /// </param>
        /// <returns>
        /// The persisted <see cref="Bill"/>.
        /// </returns>
        public Task<VerifiedData<Bill>> CreateBill(
            string privateKey,
            string publicKey,
            Bill data,
            CancellationToken cancellationToken
        ) =>
            _billClient.Create(privateKey, publicKey, data, cancellationToken);

        /// <summary>
        /// Fetches a signed, and verified <see cref="Bill"/> by it's <see cref="IIdentifiable.Id"/>.
        /// </summary>
        /// <param name="id">
        /// The <see cref="IIdentifiable.Id"/> of the <see cref="Bill"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation requests.
        /// </param>
        /// <returns>
        /// The persisted <see cref="Bill"/>.
        /// </returns>
        public Task<VerifiedData<Bill>> GetBill(string id, CancellationToken cancellationToken) =>
            _billClient.Get(id, cancellationToken);

        /// <summary>
        /// Creates, signs, and persists a <see cref="Member"/> instance.
        /// </summary>
        /// <param name="privateKey">
        /// The private key to use to generate the <see cref="ISignedData.Signature"/> of the <see cref="Member"/>.
        /// </param>
        /// <param name="publicKey">
        /// The public key that matches <paramref name="privateKey"/> to link the immutable <see cref="Member"/> to
        ///     the producing individual.
        /// </param>
        /// <param name="data">
        /// The <see cref="Member"/> data to persist.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation requests.
        /// </param>
        /// <returns>
        /// The persisted <see cref="Member"/>.
        /// </returns>
        public Task<VerifiedData<Member>> CreateMember(
            string privateKey,
            string publicKey,
            Member data,
            CancellationToken cancellationToken
        ) =>
            _memberClient.Create(privateKey, publicKey, data, cancellationToken);

        /// <summary>
        /// Fetches a signed, and verified <see cref="Member"/> by it's <see cref="IIdentifiable.Id"/>.
        /// </summary>
        /// <param name="id">
        /// The <see cref="IIdentifiable.Id"/> of the <see cref="Member"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation requests.
        /// </param>
        /// <returns>
        /// The persisted <see cref="Member"/>.
        /// </returns>
        public Task<VerifiedData<Member>> GetMember(string id, CancellationToken cancellationToken) =>
            _memberClient.Get(id, cancellationToken);

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
        /// <param name="data">
        /// The <see cref="Vote"/> data to persist.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation requests.
        /// </param>
        /// <returns>
        /// The persisted <see cref="Vote"/>.
        /// </returns>
        public Task<VerifiedData<Vote>> CreateVote(
            string privateKey,
            string publicKey,
            Vote data,
            CancellationToken cancellationToken
        ) =>
            _voteClient.Create(privateKey, publicKey, data, cancellationToken);

        /// <summary>
        /// Fetches a signed, and verified <see cref="Vote"/> by it's <see cref="IIdentifiable.Id"/>.
        /// </summary>
        /// <param name="id">
        /// The <see cref="IIdentifiable.Id"/> of the <see cref="Vote"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation requests.
        /// </param>
        /// <returns>
        /// The persisted <see cref="Vote"/>.
        /// </returns>
        public Task<VerifiedData<Vote>> GetVote(string id, CancellationToken cancellationToken) =>
            _voteClient.Get(id, cancellationToken);
    }
}