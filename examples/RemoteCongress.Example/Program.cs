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
using Microsoft.Extensions.DependencyInjection;
using RemoteCongress.Client;
using RemoteCongress.Client.DAL.Http;
using RemoteCongress.Common;
using RemoteCongress.Common.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Example
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        /// <remarks>
        /// Throw away private / pub key
        /// </remarks>
        private static readonly string PrivateKey = @"MIICWgIBAAKBgGiz/dPcdEo6G6b/+zf8VN65fgSUFTwpq3tjtOwR6jj9zzWG6o3S
d6V/XmJhrAzuyvnZP+779nhvuUaT7ks2hZXOEV40FKdqbPS9sqAz1op32vOHHvB1
rc8HVopFY5UqpN1SJ/15BMImaAb/ucGe/YBpNTkwkwMRyHisc6diIMoNAgMBAAEC
gYAi/1buxBeS4A1yKso8EnoD4JjAywa2D2+kVNWauvpBhoUGbUxlj14y0XopBGDQ
CdmK3hVCurHN2/pgHv5d4aGQ3E394Nslog33uiz/Ianlt0mWQV/s9JolHJymI+na
njP+gMZafqVIePvlHWheJaqhdAF80yU44JJV9E/1RwQg+QJBAMGM0TFwJSOWgkZs
lMshTa8yQUjPtyXjQeqaZFwDF6ZdZLoQQ48ZNrXHz2Kxnkf22s5eovRAORJAPIf5
xvdcld8CQQCKfHA6j62ea2E9FzzDo4FAbaOZ1ZzHfiZJkP5V02g5PvqDa9pL5o2i
Q9MApt3UVzj2KtXZMx5yHSK0nao0YqWTAkAmt7qpPxvO0K7i05m4QMM/hrgUjqi+
hYWMHrJwzZWPjCM4LUS2fX66Qmwz/AADuVfv7HKAldBU3FC/irHIjdbVAkBjYHrU
u0f2t822nhc/uPRGfKb6/Hwd+BuXjRHGGwfelKAGcP3cm5ylhZBEFnp3JwQ8Om7t
By7g6qF+BOof3247AkAkBiZ5okAVl8BGBG4m4RPoUgVzi+ZKwFSxWko4hoo8tMKV
1YvXub7/GoRzqUdnxmo6F3qHl1+uT2CnSJuvkcqI";

        /// <remarks>
        /// Throw away private / pub key
        /// </remarks>
        private static readonly string PublicKey = @"MIGeMA0GCSqGSIb3DQEBAQUAA4GMADCBiAKBgGiz/dPcdEo6G6b/+zf8VN65fgSU
FTwpq3tjtOwR6jj9zzWG6o3Sd6V/XmJhrAzuyvnZP+779nhvuUaT7ks2hZXOEV40
FKdqbPS9sqAz1op32vOHHvB1rc8HVopFY5UqpN1SJ/15BMImaAb/ucGe/YBpNTkw
kwMRyHisc6diIMoNAgMBAAE=";

        private static readonly string HostName = "127.0.0.1:8000";
        private static readonly string Protocol = "http";

        /// <summary>
        /// The program entry point
        /// </summary>
        public static async Task Main(string[] args)
        {
            //Setup client in DI
            using ServiceProvider serviceProvider = GetServiceProvider();
            
            // pull out the client from DI
            IRemoteCongressClient remoteCongressClient =
                serviceProvider.GetService<IRemoteCongressClient>();

            //create a bill
            VerifiedData<Bill> bill = await CreateBill(remoteCongressClient);
    
            //create a yes vote against the bill
            VerifiedData<Vote> vote = await CreateVote(remoteCongressClient, bill);

            //fetch multiple votes with a query
            await QueryVotes(remoteCongressClient, bill);
        }

        private static async Task<VerifiedData<Bill>> CreateBill(IRemoteCongressClient remoteCongressClient)
        {
            VerifiedData<Bill> bill = await remoteCongressClient.CreateBill(
                PrivateKey,
                PublicKey,
                new Bill()
                {
                    Title = "title",
                    Content = "content"
                },
                CancellationToken.None
            );
            Output($"created bill[{bill.Id}] {bill.BlockContent}");

            //pull the bill from the api
            bill = await remoteCongressClient.GetBill(bill.Id, CancellationToken.None);
            Output($"fetched bill[{bill.Id}] {bill.BlockContent} Signed And Verified");

            return bill;
        }

        private static async Task<VerifiedData<Vote>> CreateVote(
            IRemoteCongressClient remoteCongressClient,
            VerifiedData<Bill> bill
        )
        {
            VerifiedData<Vote> vote = await remoteCongressClient.CreateVote(
                PrivateKey,
                PublicKey,
                new Vote()
                {
                    BillId = bill.Id,
                    Opinion = true,
                    Message = "message"
                },
                CancellationToken.None
            );
            Output($"created vote[{vote.Id}] {vote.BlockContent}");

            //pull the newly created vote from the api.
            vote = await remoteCongressClient.GetVote(vote.Id, CancellationToken.None);
            Output($"fetched vote[{vote.Id}] {vote.BlockContent} Signed And Verified");

            return vote;
        }

        private static async Task QueryVotes(
            IRemoteCongressClient remoteCongressClient,
            VerifiedData<Bill> bill
        )
        {
            //seed a few more votes against our bill for testing.
            foreach(int i in Enumerable.Range(1, 10))
            {
                await remoteCongressClient.CreateVote(
                    PrivateKey,
                    PublicKey,
                    new Vote()
                    {
                        BillId = bill.Id,
                        Opinion = i % 2 == 0, //only even i in our loop is yes.
                        Message = $"message for vote {i}"
                    },
                    CancellationToken.None
                );
            }

            //Get an async Enumerable of Votes that match our query.
            IAsyncEnumerable<VerifiedData<Vote>> votes = remoteCongressClient.GetVotes(
                new List<IQuery>()
                {
                    new BillIdQuery(bill.Id),   //filter votes to only votes against a bill id
                    new OpinionQuery(true)      // only select the yes votes
                },
                CancellationToken.None
            );

            await foreach (VerifiedData<Vote> yesVote in votes)
            {
                Output($"fetched vote[{yesVote.Id}] {yesVote.BlockContent} Signed And Verified");
            }
        }

        /// <summary>
        /// Builds a <see cref="ServiceProvider"/>
        /// </summary>
        /// <returns>
        /// A <see cref="ServiceProvider"/> with an <see cref="IRemoteCongressClient"/> implementation configured.
        /// </returns>
        private static ServiceProvider GetServiceProvider() =>
            new ServiceCollection()
                .AddRemoteCongressClient(new ClientConfig(Protocol, HostName))
                .BuildServiceProvider();

        /// <summary>
        /// <see cref="Console.WriteLine"/> with an extra <see cref="Environment.NewLine"/>.
        /// </summary>
        private static void Output(string content) =>
            Console.WriteLine($"{content}{Environment.NewLine}");
    }
}
