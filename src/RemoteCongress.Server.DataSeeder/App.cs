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
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Server.DataSeeder
{
    public class App: IApp
    {
        private readonly string _adminPrivateKey;
        private readonly string _adminPublicKey;
        private readonly IRemoteCongressClient _client;
        private readonly IDataProvider _dataProvider;
        private readonly ILogger<App> _logger;

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

        public async Task Run(CancellationToken cancellationToken)
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

                //await SeedBill(bill, id, cancellationToken);
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