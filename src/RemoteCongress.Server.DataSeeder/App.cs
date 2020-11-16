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
using RemoteCongress.Client;
using RemoteCongress.Common;
using RemoteCongress.Common.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Server.DataSeeder
{
    /// <summary>
    /// Application logic.
    /// </summary>
    /// <remarks>
    /// This impl is essentially glue code that ties an <see cref="IDataProvider"/>, and an <see cref="IRemoteCongressClient"/> to seed data. 
    /// </remarks>
    public class App: IApp
    {
        /// <summary>
        /// The "admin" private key to seed members
        /// </summary>
        private readonly string _adminPrivateKey;

        /// <summary>
        /// The "admin" public key to seed members
        /// </summary>
        private readonly string _adminPublicKey;

        /// <summary>
        /// The <see cref="IRemoteCongressClient"/> to seed against.
        /// </summary>
        private readonly IRemoteCongressClient _client;

        /// <summary>
        /// The <see cref="IDataProvider"/> to load data from.
        /// </summary>
        private readonly IDataProvider _dataProvider;

        /// <summary>
        /// An <see cref="ILogger"/> to log against.
        /// </summary>
        private readonly ILogger<App> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">
        /// An <see cref="ILogger"/> to log against.
        /// </param>
        /// <param name="adminPrivateKey">
        /// The "admin" private key to seed members
        /// </param>
        /// <param name="adminPublicKey">
        /// The "admin" public key to seed members
        /// </param>
        /// <param name="client">
        /// The <see cref="IRemoteCongressClient"/> to seed against.
        /// </param>
        /// <param name="dataProvider">
        /// The <see cref="IDataProvider"/> to load data from.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="logger"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="adminPrivateKey"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="adminPublicKey"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="client"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="dataProvider"/> is null.
        /// </exception>
        public App(
            ILogger<App> logger,
            string adminPrivateKey,
            string adminPublicKey,
            IRemoteCongressClient client,
            IDataProvider dataProvider
        )
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));

            if (string.IsNullOrWhiteSpace(adminPrivateKey))
            {
                throw _logger.LogException(
                    new ArgumentNullException(nameof(adminPrivateKey))
                );
            }

            if (string.IsNullOrWhiteSpace(adminPublicKey))
            {
                throw _logger.LogException(
                    new ArgumentNullException(nameof(adminPublicKey))
                );
            }

            if (client is null)
            {
                throw _logger.LogException(
                    new ArgumentNullException(nameof(client))
                );
            }

            if (dataProvider is null)
            {
                throw _logger.LogException(
                    new ArgumentNullException(nameof(dataProvider))
                );
            }

            _adminPrivateKey = adminPrivateKey;
            _adminPublicKey = adminPublicKey;
            _client = client;
            _dataProvider = dataProvider;
        }

        /// <summary>
        /// Runs the seed data logic.
        /// </summary>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation.
        /// </param>
        /// <returns>
        /// The result code
        /// </returns>
        public async Task<int> Run(CancellationToken cancellationToken)
        {
            try
            {
                await Logic(cancellationToken);
            }
            catch(OperationCanceledException)
            {
                return 2;
            }
            catch(Exception)
            {
                return 1;
            }

            return 0;
        }

        /// <summary>
        /// Runs the logic to seed data.
        /// </summary>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation.
        /// </param>
        private async Task Logic(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await foreach(Member member in _dataProvider.GetMembers(cancellationToken))
            {
                _logger.LogDebug(
                    "Creating Member: {firstName} {lastName} ({party}) - {seat}",
                    member.FirstName,
                    member.LastName,
                    member.Party,
                    member.Seat
                );

                await _client.CreateMember(
                    _adminPrivateKey,
                    _adminPublicKey,
                    member,
                    cancellationToken
                );
            }

            await foreach((Bill bill, string id) in _dataProvider.GetBills(cancellationToken))
            {
                _logger.LogDebug(
                    "Creating bill: {title}",
                    bill.Title
                );

                await SeedBill(bill, id, cancellationToken);
            }
        }

        private async Task SeedBill(Bill bill, string id, CancellationToken cancellationToken)
        {
            VerifiedData<Bill> billData = await _client.CreateBill(
                _adminPrivateKey,
                _adminPublicKey,
                bill,
                cancellationToken
            );

            await foreach(
                (Vote vote, string memberPrivateKey, string memberPublicKey) in
                    _dataProvider.GetVotes(id, billData, cancellationToken))
            {
                _logger.LogDebug(
                    "Creating vote for bill: {billId}",
                    vote.BillId
                );

                await _client.CreateVote(
                    memberPrivateKey,
                    memberPublicKey,
                    vote,
                    cancellationToken
                );
            }
        }
    }
}