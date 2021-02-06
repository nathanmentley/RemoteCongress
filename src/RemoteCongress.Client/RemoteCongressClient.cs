/*
    RemoteCongress - A platform for conducting small secure public elections
    Copyright (C) 2021  Nathan Mentley

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
using Microsoft.Extensions.Logging;
using RemoteCongress.Common;
using RemoteCongress.Common.Logging;
using RemoteCongress.Common.Repositories;
using RemoteCongress.Common.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Client
{
    /// <summary>
    /// A client used to interact with the RemoteCongress api.
    /// </summary>
    internal class RemoteCongressClient: IRemoteCongressClient
    {
        /// <summary>
        /// An <see cref="ILogger"/> instance to log against.
        /// </summary>
        private readonly ILogger<RemoteCongressClient> _logger;

        /// <summary>
        /// An <see cref="IDataSigner{Bill}"/> to sign <see cref="Bill"/>s.
        /// </summary>
        private readonly IDataSigner<Bill> _billDataSigner;

        /// <summary>
        /// An <see cref="IDataSigner{Member}"/> to sign <see cref="Member"/>s.
        /// </summary>
        private readonly IDataSigner<Member> _memberDataSigner;

        /// <summary>
        /// An <see cref="IDataSigner{Vote}"/> to sign <see cref="Vote"/>s.
        /// </summary>
        private readonly IDataSigner<Vote> _voteDataSigner;

        /// <summary>
        /// An <see cref="IImmutableDataRepository{Bill}"/> to interact with <see cref="Bill"/>s.
        /// </summary>
        private readonly IImmutableDataRepository<Bill> _billRepo;

        /// <summary>
        /// An <see cref="IImmutableDataRepository{Member}"/> to interact with <see cref="Member"/>s.
        /// </summary>
        private readonly IImmutableDataRepository<Member> _memberRepo;

        /// <summary>
        /// An <see cref="IImmutableDataRepository{Vote}"/> to interact with <see cref="Vote"/>s.
        /// </summary>
        private readonly IImmutableDataRepository<Vote> _voteRepo;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="logger">
        /// An <see cref="ILogger"/> instance to log against.
        /// </param>
        /// <param name="billDataSigner">
        /// An <see cref="IDataSigner{Bill}"/> to sign <see cref="Bill"/>s.
        /// </param>
        /// <param name="memberDataSigner">
        /// An <see cref="IDataSigner{Member}"/> to sign <see cref="Member"/>s.
        /// </param>
        /// <param name="voteDataSigner">
        /// An <see cref="IDataSigner{Vote}"/> to sign <see cref="Vote"/>s.
        /// </param>
        /// <param name="billRepo">
        /// An <see cref="IImmutableDataRepository{Bill}"/> to interact with <see cref="Bill"/>s.
        /// </param>
        /// <param name="memberRepo">
        /// An <see cref="IImmutableDataRepository{Member}"/> to interact with <see cref="Member"/>s.
        /// </param>
        /// <param name="voteRepo">
        /// An <see cref="IImmutableDataRepository{Vote}"/> to interact with <see cref="Vote"/>s.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="logger"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="billDataSigner"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="memberDataSigner"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="voteDataSigner"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="billRepo"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="memberRepo"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="voteRepo"/> is null.
        /// </exception>
        internal RemoteCongressClient(
            ILogger<RemoteCongressClient> logger,
            IDataSigner<Bill> billDataSigner,
            IDataSigner<Member> memberDataSigner,
            IDataSigner<Vote> voteDataSigner,
            IImmutableDataRepository<Bill> billRepo,
            IImmutableDataRepository<Member> memberRepo,
            IImmutableDataRepository<Vote> voteRepo
        )
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));

            _billDataSigner = billDataSigner ??
                throw _logger.LogException(
                    new ArgumentNullException(nameof(billDataSigner)),
                    LogLevel.Debug
                );

            _memberDataSigner = memberDataSigner ??
                throw _logger.LogException(
                    new ArgumentNullException(nameof(memberDataSigner)),
                    LogLevel.Debug
                );

            _voteDataSigner = voteDataSigner ??
                throw _logger.LogException(
                    new ArgumentNullException(nameof(voteDataSigner)),
                    LogLevel.Debug
                );

            _billRepo = billRepo ??
                throw _logger.LogException(
                    new ArgumentNullException(nameof(billRepo)),
                    LogLevel.Debug
                );

            _memberRepo = memberRepo ??
                throw _logger.LogException(
                    new ArgumentNullException(nameof(memberRepo)),
                    LogLevel.Debug
                );

            _voteRepo = voteRepo ??
                throw _logger.LogException(
                    new ArgumentNullException(nameof(voteRepo)),
                    LogLevel.Debug
                );
        }

        /// <summary>
        /// Creates, signs, and persists a <see cref="Bill"/> instance.
        /// </summary>
        /// <param name="privateKey">
        /// The private key to use to generate the <see cref="ISignedData.Signature"/> of the <see cref="Bill"/>.
        /// </param>
        /// <param name="publicKey">
        /// The public key that matches <paramref name="privateKey"/> to link the immutable <see cref="Bill"/> to the producing individual.
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
        public async Task<VerifiedData<Bill>> CreateBill(
            string privateKey,
            string publicKey,
            Bill data,
            CancellationToken cancellationToken
        )
        {
            VerifiedData<Bill> bill = await _billDataSigner.Create(privateKey, publicKey, data, cancellationToken);

            return await _billRepo.Create(bill, cancellationToken);
        }    

        /// <summary>
        /// Fetches a signed, and verified <see cref="Bill"/>s that match <paramref name="query"/>.
        /// </summary>
        /// <param name="query">
        /// A collection of <see cref="IQuery"/>s to filter on.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation requests.
        /// </param>
        /// <returns>
        /// The persisted <see cref="Bill"/>s that match <paramref name="query"/>.
        /// </returns>
        public IAsyncEnumerable<VerifiedData<Bill>> GetBills(
            IList<IQuery> query,
            CancellationToken cancellationToken
        ) =>
            _billRepo.Fetch(query, cancellationToken);

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
            _billRepo.Fetch(id, cancellationToken);

        /// <summary>
        /// Creates, signs, and persists a <see cref="Member"/> instance.
        /// </summary>
        /// <param name="privateKey">
        /// The private key to use to generate the <see cref="ISignedData.Signature"/> of the <see cref="Member"/>.
        /// </param>
        /// <param name="publicKey">
        /// The public key that matches <paramref name="privateKey"/> to link the immutable <see cref="Member"/> to the producing individual.
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
        public async Task<VerifiedData<Member>> CreateMember(
            string privateKey,
            string publicKey,
            Member data,
            CancellationToken cancellationToken
        )
        {
            VerifiedData<Member> member = await _memberDataSigner.Create(privateKey, publicKey, data, cancellationToken);

            return await _memberRepo.Create(member, cancellationToken);
        }    

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
            _memberRepo.Fetch(id, cancellationToken);

        /// <summary>
        /// Fetches a signed, and verified <see cref="Member"/>s that match <paramref name="query"/>.
        /// </summary>
        /// <param name="query">
        /// A collection of <see cref="IQuery"/>s to filter on.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation requests.
        /// </param>
        /// <returns>
        /// The persisted <see cref="Member"/>s that match <paramref name="query"/>.
        /// </returns>
        public IAsyncEnumerable<VerifiedData<Member>> GetMembers(
            IList<IQuery> query,
            CancellationToken cancellationToken
        ) =>
            _memberRepo.Fetch(query, cancellationToken);

        /// <summary>
        /// Creates, signs, and persists a <see cref="Vote"/> instance.
        /// </summary>
        /// <param name="privateKey">
        /// The private key to use to generate the <see cref="ISignedData.Signature"/> of the <see cref="Vote"/>.
        /// </param>
        /// <param name="publicKey">
        /// The public key that matches <paramref name="privateKey"/> to link the immutable <see cref="Vote"/> to the producing individual.
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
        public async Task<VerifiedData<Vote>> CreateVote(
            string privateKey,
            string publicKey,
            Vote data,
            CancellationToken cancellationToken
        )
        {
            VerifiedData<Vote> vote = await _voteDataSigner.Create(privateKey, publicKey, data, cancellationToken);

            return await _voteRepo.Create(vote, cancellationToken);
        }    

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
            _voteRepo.Fetch(id, cancellationToken);

        /// <summary>
        /// Fetches a signed, and verified <see cref="Vote"/>s that match <paramref name="query"/>.
        /// </summary>
        /// <param name="query">
        /// A collection of <see cref="IQuery"/>s to filter on.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation requests.
        /// </param>
        /// <returns>
        /// The persisted <see cref="Vote"/>s that match <paramref name="query"/>.
        /// </returns>
        public IAsyncEnumerable<VerifiedData<Vote>> GetVotes(
            IList<IQuery> query,
            CancellationToken cancellationToken
        ) =>
            _voteRepo.Fetch(query, cancellationToken);
    }
}