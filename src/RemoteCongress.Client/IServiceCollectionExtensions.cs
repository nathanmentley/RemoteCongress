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
using Microsoft.Extensions.Logging;
using RemoteCongress.Common.Repositories;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;

namespace RemoteCongress.Client
{
    /// <summary>
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class IServiceCollectionExtensions
    {
        private static readonly string BillEndpoint = "bill";
        private static readonly string VoteEndpoint = "vote";

        /// <summary>
        /// </summary>
        public static IServiceCollection AddRemoteCongressClient(
            this IServiceCollection collection,
            ClientConfig config
        ) =>
            collection
                .AddLogging()

                .AddSingleton<HttpClient>(_ => {
                    HttpClientHandler handler = new HttpClientHandler();

                    handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                    handler.ServerCertificateCustomValidationCallback = 
                        (httpRequestMessage, cert, cetChain, policyErrors) => true;

                    return new HttpClient(handler);
                })
                .AddSingleton<ClientConfig>(config)

                .AddSingleton<IBillRepository, BillRepository>(provider =>
                    new BillRepository(
                        provider.GetRequiredService<ILogger<BillRepository>>(),
                        new HttpDataClient(
                            provider.GetRequiredService<ILogger<HttpDataClient>>(),
                            provider.GetRequiredService<ClientConfig>(),
                            provider.GetRequiredService<HttpClient>(),
                            BillEndpoint
                        )
                    )
                )
                .AddSingleton<IVoteRepository, VoteRepository>(provider =>
                    new VoteRepository(
                        provider.GetRequiredService<ILogger<VoteRepository>>(),
                        new HttpDataClient(
                            provider.GetRequiredService<ILogger<HttpDataClient>>(),
                            provider.GetRequiredService<ClientConfig>(),
                            provider.GetRequiredService<HttpClient>(),
                            VoteEndpoint
                        )
                    )
                )

                .AddSingleton<IRemoteCongressClient, RemoteCongressClient>();
    }
}