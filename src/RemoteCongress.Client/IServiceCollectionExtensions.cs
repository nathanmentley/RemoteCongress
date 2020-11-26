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
using RemoteCongress.Client.DAL.Http;
using RemoteCongress.Common;
using RemoteCongress.Common.Repositories;
using RemoteCongress.Common.Repositories.Queries;
using RemoteCongress.Common.Serialization;
using System;
using System.Collections.Generic;
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
        /// <summary>
        /// Endpoint for interacting with bills.
        /// </summary>
        private static readonly string BillEndpoint = "bill";

        /// <summary>
        /// Endpoint for interacting with members.
        /// </summary>
        private static readonly string MemberEndpoint = "member";

        /// <summary>
        /// Endpoint for interacting with votes.
        /// </summary>
        private static readonly string VoteEndpoint = "vote";

        /// <summary>
        /// Sets up an <see cref="IRemoteCongressClient"/> implementation in <paramref name="collection"/>.
        /// </summary>
        /// <param name="collection">
        /// <see cref="IServiceCollection"/> to define <see cref="IRemoteCongressClient"/> in.
        /// </param>
        /// <param name="config">
        /// <see cref="ClientConfig"/> to configure <see cref="IRemoteCongressClient"/> with.
        /// </param>
        /// <returns>
        /// <paramref name="collection"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="collection"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="config"/> is null.
        /// </exception>
        public static IServiceCollection AddRemoteCongressClient(
            this IServiceCollection collection,
            ClientConfig config
        )
        {
            if (collection is null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (config is null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            return collection
                .AddLogging(configure =>
                    configure
                        .SetMinimumLevel(LogLevel.Debug)
                        .AddConsole()
                )

                .AddCodecs()

                .AddHttpClient(config)

                .AddBillClient()
                .AddMemberClient()
                .AddVoteClient()

                .AddSingleton<IRemoteCongressClient, RemoteCongressClient>();
        }

        /// <summary>
        /// Registers a <see cref="HttpClient"/> to use for communicating over http.
        /// </summary>
        /// <param name="collection">
        /// <see cref="IServiceCollection"/> to define <see cref="IRemoteCongressClient"/> in.
        /// </param>
        /// <param name="config">
        /// <see cref="ClientConfig"/> to configure <see cref="IRemoteCongressClient"/> with.
        /// </param>
        /// <returns>
        /// <paramref name="collection"/>
        /// </returns>
        private static IServiceCollection AddHttpClient(
            this IServiceCollection collection,
            ClientConfig config
        ) =>
            collection
                .AddSingleton(config)
                .AddSingleton(new HttpClient());

        /// <summary>
        /// Registers all supported <see cref="ICodec{TModel}"/>s.
        /// </summary>
        /// <param name="collection">
        /// <see cref="IServiceCollection"/> to define <see cref="IRemoteCongressClient"/> in.
        /// </param>
        /// <returns>
        /// <paramref name="collection"/>
        /// </returns>
        private static IServiceCollection AddCodecs(this IServiceCollection collection) =>
            collection
                //.AddSingleton<ICodec<SignedData>, SignedDataV1AvroCodec>()
                .AddSingleton<ICodec<SignedData>, SignedDataV1JsonCodec>()
                .AddSingleton<ICodec<IEnumerable<SignedData>>, SignedDataCollectionV1JsonCodec>()
                //.AddSingleton<ICodec<Bill>, BillV1AvroCodec>()
                .AddSingleton<ICodec<Bill>, BillV1JsonCodec>()
                .AddSingleton<ICodec<Member>, MemberV1JsonCodec>()
                //.AddSingleton<ICodec<Vote>, VoteV1AvroCodec>()
                .AddSingleton<ICodec<Vote>, VoteV1JsonCodec>()
                .AddSingleton<ICodec<IQuery>, IQueryV1JsonCodec>();

        /// <summary>
        /// Registers a <see cref="IEndpointClient{Bill}"/> implementation.
        /// </summary>
        /// <param name="collection">
        /// <see cref="IServiceCollection"/> to define <see cref="IRemoteCongressClient"/> in.
        /// </param>
        /// <returns>
        /// <paramref name="collection"/>
        /// </returns>
        private static IServiceCollection AddBillClient(this IServiceCollection collection) =>
            collection
                .AddSingleton<IQueryProcessor<Bill>, BillQueryProcessor>()
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
                            provider.GetRequiredService<ICodec<IQuery>>(),
                            provider.GetRequiredService<IEnumerable<ICodec<SignedData>>>(),
                            provider.GetRequiredService<IEnumerable<ICodec<IEnumerable<SignedData>>>>(),
                            BillEndpoint
                        ),
                        provider.GetRequiredService<IEnumerable<ICodec<Bill>>>(),
                        provider.GetRequiredService<IQueryProcessor<Bill>>()
                    )
                )
                .AddSingleton<IEndpointClient<Bill>, EndpointClient<Bill>>();

        /// <summary>
        /// Registers a <see cref="IEndpointClient{Member}"/> implementation.
        /// </summary>
        /// <param name="collection">
        /// <see cref="IServiceCollection"/> to define <see cref="IRemoteCongressClient"/> in.
        /// </param>
        /// <returns>
        /// <paramref name="collection"/>
        /// </returns>
        private static IServiceCollection AddMemberClient(this IServiceCollection collection) =>
            collection
                .AddSingleton<IQueryProcessor<Member>, MemberQueryProcessor>()
                .AddSingleton<
                    IImmutableDataRepository<Member>,
                    ImmutableDataRepository<Member>
                >(provider =>
                    new ImmutableDataRepository<Member>(
                        provider.GetRequiredService<ILogger<ImmutableDataRepository<Member>>>(),
                        new HttpDataClient(
                            provider.GetRequiredService<ILogger<HttpDataClient>>(),
                            provider.GetRequiredService<ClientConfig>(),
                            provider.GetRequiredService<HttpClient>(),
                            provider.GetRequiredService<ICodec<IQuery>>(),
                            provider.GetRequiredService<IEnumerable<ICodec<SignedData>>>(),
                            provider.GetRequiredService<IEnumerable<ICodec<IEnumerable<SignedData>>>>(),
                            MemberEndpoint
                        ),
                        provider.GetRequiredService<IEnumerable<ICodec<Member>>>(),
                        provider.GetRequiredService<IQueryProcessor<Member>>()
                    )
                )
                .AddSingleton<IEndpointClient<Member>, EndpointClient<Member>>();

        /// <summary>
        /// Registers a <see cref="IEndpointClient{Vote}"/> implementation.
        /// </summary>
        /// <param name="collection">
        /// <see cref="IServiceCollection"/> to define <see cref="IRemoteCongressClient"/> in.
        /// </param>
        /// <returns>
        /// <paramref name="collection"/>
        /// </returns>
        private static IServiceCollection AddVoteClient(this IServiceCollection collection) =>
            collection
                .AddSingleton<IQueryProcessor<Vote>, VoteQueryProcessor>()
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
                            provider.GetRequiredService<ICodec<IQuery>>(),
                            provider.GetRequiredService<IEnumerable<ICodec<SignedData>>>(),
                            provider.GetRequiredService<IEnumerable<ICodec<IEnumerable<SignedData>>>>(),
                            VoteEndpoint
                        ),
                        provider.GetRequiredService<IEnumerable<ICodec<Vote>>>(),
                        provider.GetRequiredService<IQueryProcessor<Vote>>()
                    )
                )
                .AddSingleton<IEndpointClient<Vote>, EndpointClient<Vote>>();
    }
}