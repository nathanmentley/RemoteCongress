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
using RemoteCongress.Common;
using RemoteCongress.Common.Repositories;
using RemoteCongress.Common.Serialization;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;

namespace RemoteCongress.Client
{
    /// <summary>
    /// Extension methods for <see cref="IServiceCollection"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class IServiceCollectionExtensions
    {
        private static readonly string BillEndpoint = "bill";
        private static readonly string VoteEndpoint = "vote";

        /// <summary>
        /// Sets up an <see cref="IRemoteCongressClient"/> implementation in <paramref name="collection"/>.
        /// </summary>
        /// <param name="collection">
        /// <see cref="IServiceCollection"/> to define <see cref="IRemoteCongressClient"/> in.
        /// </param>
        /// <param name="client">
        /// <see cref="ClientConfig"/> to configure <see cref="IRemoteCongressClient"/> with.
        /// </param>
        /// <returns>
        /// <paramref name="collection"/>
        /// </returns>
        public static IServiceCollection AddRemoteCongressClient(
            this IServiceCollection collection,
            ClientConfig config
        )
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));

            if (config is null)
                throw new ArgumentNullException(nameof(config));

            return collection
                .AddLogging()

                .AddSingleton(_ => {
                    HttpClientHandler handler = new HttpClientHandler();

                    handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                    handler.ServerCertificateCustomValidationCallback = 
                        (httpRequestMessage, cert, cetChain, policyErrors) => true;

                    return new HttpClient(handler);
                })
                .AddSingleton(config)

                .AddSingleton<ICodec<SignedData>, SignedDataV1JsonCodec>()
                .AddSingleton<ICodec<Bill>, BillV1JsonCodec>()
                .AddSingleton<ICodec<Vote>, VoteV1JsonCodec>()

                .AddSingleton<
                    IImmutableDataRepository<Bill>,
                    ImmutableDataRepository<Bill>
                >(provider =>
                    new ImmutableDataRepository<Bill>(
                        provider.GetRequiredService<ILogger<ImmutableDataRepository<Bill>>>(),
                        new HttpDataClient(
                            provider.GetRequiredService<ILogger<HttpDataClient>>(),
                            provider.GetRequiredService<ClientConfig>(),
                            provider.GetRequiredService<HttpClient>(),
                            BillEndpoint
                        ),
                        provider.GetRequiredService<ICodec<Bill>>()
                    )
                )
                .AddSingleton<
                    IImmutableDataRepository<Vote>,
                    ImmutableDataRepository<Vote>
                >(provider =>
                    new ImmutableDataRepository<Vote>(
                        provider.GetRequiredService<ILogger<ImmutableDataRepository<Vote>>>(),
                        new HttpDataClient(
                            provider.GetRequiredService<ILogger<HttpDataClient>>(),
                            provider.GetRequiredService<ClientConfig>(),
                            provider.GetRequiredService<HttpClient>(),
                            VoteEndpoint
                        ),
                        provider.GetRequiredService<ICodec<Vote>>()
                    )
                )

                .AddSingleton<IRemoteCongressClient, RemoteCongressClient>();
        }
    }
}