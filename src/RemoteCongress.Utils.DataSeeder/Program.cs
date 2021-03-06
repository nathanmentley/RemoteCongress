﻿/*
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
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RemoteCongress.Client;
using RemoteCongress.Client.DAL.Http;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Utils.DataSeeder
{
    /// <summary>
    /// Entry point class.
    /// </summary>
    class Program
    {
        /// <remarks>
        /// Throw away private / pub key
        /// </remarks>
        private static readonly string AdminPrivateKey = @"MIICWgIBAAKBgGiz/dPcdEo6G6b/+zf8VN65fgSUFTwpq3tjtOwR6jj9zzWG6o3S
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
        private static readonly string AdminPublicKey = @"MIGeMA0GCSqGSIb3DQEBAQUAA4GMADCBiAKBgGiz/dPcdEo6G6b/+zf8VN65fgSU
FTwpq3tjtOwR6jj9zzWG6o3Sd6V/XmJhrAzuyvnZP+779nhvuUaT7ks2hZXOEV40
FKdqbPS9sqAz1op32vOHHvB1rc8HVopFY5UqpN1SJ/15BMImaAb/ucGe/YBpNTkw
kwMRyHisc6diIMoNAgMBAAE=";

        /// <summary>
        /// The congress to seed.
        /// </summary>
        private static readonly int Congress = 117;

        /// <summary>
        /// The session to seed.
        /// </summary>
        private static readonly int Session = 1;

        /// <summary>
        /// The hardcoded hostname to seed against
        /// </summary>
        /// <remarks>
        /// TODO: Provide this from the cli.
        /// </remarks>
        private static readonly string Hostname = "127.0.0.1:8000";

        /// <summary>
        /// The hardcoded protocol to seed against
        /// </summary>
        /// <remarks>
        /// TODO: Provide this from the cli.
        /// </remarks>
        private static readonly string Protocol = "http";

        /// <summary>
        /// Runs the application logic
        /// </summary>
        /// <param name="args">
        /// Command line arguments
        /// </param>
        /// <returns>
        /// Result code
        /// </returns>
        public static async Task<int> Main(string[] args)
        {
            using CancellationTokenSource cancellationTokenSource = GetCancellationTokenSource();
            using ServiceProvider serviceProvider = GetServiceProvider(new ClientConfig(Protocol, Hostname));

            return await serviceProvider.GetRequiredService<IApp>().Run(cancellationTokenSource.Token);
        }

        /// <summary>
        /// Sets up the <see cref="ServiceProvider"/> and registers the Remote Congress client in DI.
        /// </summary>
        /// <param name="config">
        /// The <see cref="ClientConfig"/> to use to configure the RemoteCongress client instances.
        /// </param>
        /// <returns>
        /// The DI <see cref="ServiceProvider"/>.
        /// </returns>
        private static ServiceProvider GetServiceProvider(ClientConfig config) =>
            new ServiceCollection()
                .AddSingleton<IKeyGenerator, KeyGenerator>()
                .AddSingleton<IDataProvider>(provider => 
                    new SenateDataProvider(
                        provider.GetRequiredService<IKeyGenerator>(),
                        Congress,
                        Session
                    )
                )
                .AddSingleton<IDataProvider>(provider => 
                    new HouseDataProvider(
                        provider.GetRequiredService<IKeyGenerator>(),
                        Congress,
                        Session
                    )
                )
                .AddSingleton<IApp>(provider =>
                    new App(
                        provider.GetRequiredService<ILogger<App>>(),
                        AdminPrivateKey,
                        AdminPublicKey,
                        provider.GetRequiredService<IRemoteCongressClient>(),
                        provider.GetRequiredService<IEnumerable<IDataProvider>>()
                    )
                )
                .AddRemoteCongressClient(config)
                .BuildServiceProvider();

        /// <summary>
        /// Sets up the <see cref="CancellationTokenSource"/> for the cli application.
        /// </summary>
        /// <returns>
        /// A <see cref="CancellationTokenSource"/> linked to the application cancellation event.
        /// </returns>
        private static CancellationTokenSource GetCancellationTokenSource()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            Console.CancelKeyPress += (_, @event) => {
                @event.Cancel = false;
                cancellationTokenSource.Cancel();
            };

            return cancellationTokenSource;
        }
    }
}