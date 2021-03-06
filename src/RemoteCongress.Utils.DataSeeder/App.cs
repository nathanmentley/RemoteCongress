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
using RemoteCongress.Client;
using RemoteCongress.Common;
using RemoteCongress.Common.Exceptions;
using RemoteCongress.Common.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Utils.DataSeeder
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
        private readonly IEnumerable<IDataProvider> _dataProviders;

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
        /// <param name="dataProviders">
        /// All the <see cref="IDataProvider"/> to load data from.
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
        /// Thrown if <paramref name="dataProviders"/> is null.
        /// </exception>
        public App(
            ILogger<App> logger,
            string adminPrivateKey,
            string adminPublicKey,
            IRemoteCongressClient client,
            IEnumerable<IDataProvider> dataProviders
        )
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));

            if (string.IsNullOrWhiteSpace(adminPrivateKey))
            {
                throw _logger.LogException(
                    new ArgumentNullException(nameof(adminPrivateKey)),
                    LogLevel.Debug
                );
            }

            if (string.IsNullOrWhiteSpace(adminPublicKey))
            {
                throw _logger.LogException(
                    new ArgumentNullException(nameof(adminPublicKey)),
                    LogLevel.Debug
                );
            }

            if (client is null)
            {
                throw _logger.LogException(
                    new ArgumentNullException(nameof(client)),
                    LogLevel.Debug
                );
            }

            if (dataProviders is null)
            {
                throw _logger.LogException(
                    new ArgumentNullException(nameof(dataProviders)),
                    LogLevel.Debug
                );
            }

            _adminPrivateKey = adminPrivateKey;
            _adminPublicKey = adminPublicKey;
            _client = client;
            _dataProviders = dataProviders;
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
            catch(Exception exception)
            {
                _logger.LogException(exception, LogLevel.Debug);

                return exception switch
                {
                    BaseRemoteCongressException _ =>
                        AppResultCode.UnknownError,
                    OperationCanceledException _ =>
                        AppResultCode.OperationCancelled,
                    _ =>
                        AppResultCode.UnknownError
                };
            }

            return AppResultCode.Success;
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

            foreach(IDataProvider dataProvider in _dataProviders)
            {
                IList<Task> addMemberTasks = new List<Task>();

                await foreach(Member member in dataProvider.GetMembers(cancellationToken))
                {
                    _logger.LogDebug(
                        "Creating Member: {firstName} {lastName} ({party}) - {seat}",
                        member.FirstName,
                        member.LastName,
                        member.Party,
                        member.Seat
                    );

                    addMemberTasks.Add(
                        _client.CreateMember(
                            _adminPrivateKey,
                            _adminPublicKey,
                            member,
                            cancellationToken
                        )
                    );
                }

                await Task.WhenAll(addMemberTasks);

                IList<Task> addBillTasks = new List<Task>();

                int counter = 0;
                await foreach((Bill bill, string id) in dataProvider.GetBills(cancellationToken))
                {
                    if (counter % 5 == 0)
                    {
                        await Task.WhenAll(addBillTasks);
                        addBillTasks.Clear();
                    }

                    _logger.LogDebug(
                        "Creating bill: {title}",
                        bill.Title
                    );

                    addBillTasks.Add(
                        SeedBill(bill, id, dataProvider, cancellationToken)
                    );

                    counter++;
                }

                await Task.WhenAll(addBillTasks);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bill">
        /// 
        /// </param>
        /// <param name="id">
        /// 
        /// </param>
        /// <param name="dataProvider">
        /// 
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation.
        /// </param>
        private async Task SeedBill(
            Bill bill,
            string id,
            IDataProvider dataProvider,
            CancellationToken cancellationToken
        )
        {
            VerifiedData<Bill> billData = await _client.CreateBill(
                _adminPrivateKey,
                _adminPublicKey,
                bill,
                cancellationToken
            );

            IList<Task> addVoteTasks = new List<Task>();

            await foreach(
                (Vote vote, string memberPrivateKey, string memberPublicKey) in
                    dataProvider.GetVotes(id, billData, cancellationToken))
            {
                _logger.LogDebug(
                    "Creating vote for bill: {billId}",
                    vote.BillId
                );

                addVoteTasks.Add(
                    _client.CreateVote(
                        memberPrivateKey,
                        memberPublicKey,
                        vote,
                        cancellationToken
                    )
                );
            }

            await Task.WhenAll(addVoteTasks);
        }
    }
}