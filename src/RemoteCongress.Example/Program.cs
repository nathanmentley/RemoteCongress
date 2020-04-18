﻿/*
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
using RemoteCongress.Common.Repositories;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Threading.Tasks;

namespace RemoteCongress.Example
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        /// <remarks>
        /// Throw away private / pub key
        /// </remarks>
        private static string PrivateKey = @"MIICWgIBAAKBgGiz/dPcdEo6G6b/+zf8VN65fgSUFTwpq3tjtOwR6jj9zzWG6o3S
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
        private static string PublicKey = @"MIGeMA0GCSqGSIb3DQEBAQUAA4GMADCBiAKBgGiz/dPcdEo6G6b/+zf8VN65fgSU
FTwpq3tjtOwR6jj9zzWG6o3Sd6V/XmJhrAzuyvnZP+779nhvuUaT7ks2hZXOEV40
FKdqbPS9sqAz1op32vOHHvB1rc8HVopFY5UqpN1SJ/15BMImaAb/ucGe/YBpNTkw
kwMRyHisc6diIMoNAgMBAAE=";

        private static string HostName = "127.0.0.1:8000";
        private static string Protocol = "http";

        public static async Task Main(string[] args)
        {
            //Setup client in DI
            using var serviceProvider = GetServiceProvider();
            
            // pull out the client
            var RemoteCongressClient = serviceProvider.GetService<IRemoteCongressClient>();

            //create a bill
            var bill = await RemoteCongressClient.CreateBill(PrivateKey, PublicKey, "title", "content");
            Console.WriteLine(
                $"created bill[{bill.Id}] {bill.BlockContent}"
            );

            Console.WriteLine(string.Empty);

            //pull the bill from the api
            bill = await RemoteCongressClient.GetBill(bill.Id);
            Console.WriteLine(
                $"fetched bill[{bill.Id}] {bill.BlockContent} Signed And Verified"
            );

            Console.WriteLine(string.Empty);

            //create a yes vote against the bill
            var vote = await RemoteCongressClient.CreateVote(PrivateKey, PublicKey, bill.Id, true, "message");
            Console.WriteLine(
                $"created vote[{vote.Id}] {vote.BlockContent}"
            );

            Console.WriteLine(string.Empty);

            //pull the newly created vote from the api.
            vote = await RemoteCongressClient.GetVote(vote.Id);
            Console.WriteLine(
                $"fetched vote[{vote.Id}] {vote.BlockContent} Signed And Verified"
            );

            Console.WriteLine(string.Empty);
        }

        private static ServiceProvider GetServiceProvider() =>
            new ServiceCollection()
                .AddSingleton<HttpClient>(_ => {
                    var handler = new HttpClientHandler();
                    handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                    handler.ServerCertificateCustomValidationCallback = 
                        (httpRequestMessage, cert, cetChain, policyErrors) => true;

                    return new HttpClient(handler);
                })
                .AddSingleton<ClientConfig>(
                    new ClientConfig(Protocol, HostName)
                )

                .AddSingleton<IBillRepository, BillRepository>()
                .AddSingleton<IVoteRepository, VoteRepository>()

                .AddSingleton<IRemoteCongressClient, RemoteCongressClient>()

                .BuildServiceProvider();
    }
}
