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
using Microsoft.Extensions.Logging;
using RemoteCongress.Common;
using RemoteCongress.Common.Encryption;
using RemoteCongress.Common.Exceptions;
using RemoteCongress.Common.Logging;
using RemoteCongress.Common.Repositories;
using RemoteCongress.Common.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Client
{
    /// <summary>
    /// A client used to interact with the RemoteCongress api.
    /// </summary>
    public class RemoteCongressClient: IRemoteCongressClient
    {
        private readonly ILogger<RemoteCongressClient> _logger;
        private readonly IEnumerable<ICodec<Bill>> _billCodecs;
        private readonly IEnumerable<ICodec<Vote>> _voteCodecs;
        private readonly IImmutableDataRepository<Bill> _billRepository;
        private readonly IImmutableDataRepository<Vote> _voteRepository;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="logger">
        /// An <see cref="ILogger"/> to log against.
        /// </param>
        /// <param name="billCodecs">
        /// An <see cref="ICodec"/> for <see cref="Bill"/>s.
        /// </param>
        /// <param name="voteCodecs">
        /// An <see cref="ICodec"/> for <see cref="Vote"/>s.
        /// </param>
        /// <param name="billRepository">
        /// An <see cref="IImmutableDataRepository<BillData>"/> instance to use to interact with <see cref="Bill"/>s.
        /// </param>
        /// <param name="voteRepository">
        /// An <see cref="IImmutableDataRepository<VoteData>"/> instance to use to interact with <see cref="Vote"/>s.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="logger"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="billCodecs"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="voteCodecs"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="billRepository"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="voteRepository"/> is null.
        /// </exception>
        public RemoteCongressClient(
            ILogger<RemoteCongressClient> logger,
            IEnumerable<ICodec<Bill>> billCodecs,
            IEnumerable<ICodec<Vote>> voteCodecs,
            IImmutableDataRepository<Bill> billRepository,
            IImmutableDataRepository<Vote> voteRepository
        )
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));

            _billCodecs = billCodecs ??
                throw _logger.LogException(
                    LogLevel.Debug,
                    new ArgumentNullException(nameof(billCodecs))
                );

            _voteCodecs = voteCodecs ??
                throw _logger.LogException(
                    LogLevel.Debug,
                    new ArgumentNullException(nameof(voteCodecs))
                );

            _billRepository = billRepository ??
                throw _logger.LogException(
                    LogLevel.Debug,
                    new ArgumentNullException(nameof(billRepository))
                );

            _voteRepository = voteRepository ??
                throw _logger.LogException(
                    LogLevel.Debug,
                    new ArgumentNullException(nameof(voteRepository))
                );
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
        public async Task<VerifiedData<Bill>> CreateBill(
            string privateKey,
            string publicKey,
            Bill data,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();

            ICodec<Bill> codec = GetBillCodec(BillV1AvroCodec.MediaType);

            string blockContent = await codec.EncodeToString(
                codec.GetPreferredMediaType(),
                data
            );
            SignedData signedData = new SignedData(
                publicKey,
                blockContent,
                RsaUtils.GenerateSignature(privateKey, blockContent),
                codec.GetPreferredMediaType()
            );

            VerifiedData<Bill> bill = new VerifiedData<Bill>(signedData, data);

            return await _billRepository.Create(bill, cancellationToken);
        }

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
        public async Task<VerifiedData<Bill>> GetBill(string id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await _billRepository.Fetch(id, cancellationToken);
        }

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
        public async Task<VerifiedData<Vote>> CreateVote(
            string privateKey,
            string publicKey,
            Vote data,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();

            ICodec<Vote> codec = GetVoteCodec(VoteV1AvroCodec.MediaType);

            string blockContent = await codec.EncodeToString(
                codec.GetPreferredMediaType(),
                data
            );
            SignedData signedData = new SignedData(
                publicKey,
                blockContent,
                RsaUtils.GenerateSignature(privateKey, blockContent),
                codec.GetPreferredMediaType()
            );

            VerifiedData<Vote> vote = new VerifiedData<Vote>(signedData, data);

            return await _voteRepository.Create(vote, cancellationToken);
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
        public async Task<VerifiedData<Vote>> GetVote(string id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await _voteRepository.Fetch(id, cancellationToken);
        }

        private ICodec<Bill> GetBillCodec(RemoteCongressMediaType mediaType) =>
            _billCodecs.FirstOrDefault(
                codec => codec.CanHandle(mediaType)
            ) ??
                throw _logger.LogException(
                    LogLevel.Debug,
                    new UnknownBlockMediaTypeException(
                        $"{mediaType.ToString()} is not supported."
                    )
                );

        private ICodec<Vote> GetVoteCodec(RemoteCongressMediaType mediaType) =>
            _voteCodecs.FirstOrDefault(
                codec => codec.CanHandle(mediaType)
            ) ??
                throw _logger.LogException(
                    LogLevel.Debug,
                    new UnknownBlockMediaTypeException(
                        $"{mediaType.ToString()} is not supported."
                    )
                );
    }
}