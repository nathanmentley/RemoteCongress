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
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RemoteCongress.Client;
using RemoteCongress.Client.DAL.Http;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Util.FilteredVoteGenerator
{
    /// <summary>
    /// Entry point class.
    /// </summary>
    class Program
    {
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
                .AddSingleton<IApp>(provider =>
                    new App(
                        provider.GetRequiredService<ILogger<App>>(),
                        provider.GetRequiredService<IRemoteCongressClient>()
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