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
using Ipfs.CoreApi;
using Ipfs.Engine;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Nito.AsyncEx;
using RemoteCongress.Common;
using RemoteCongress.Common.Repositories;
using RemoteCongress.Common.Repositories.Queries;
using RemoteCongress.Common.Serialization;
using RemoteCongress.Server.DAL.InMemory;
using RemoteCongress.Server.DAL.IpfsBlockchainDb;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace RemoteCongress.Server.Api
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            IpfsBlockchainConfig ipfsConfig = _configuration
                .GetSection("Ipfs")
                .Get<IpfsBlockchainConfig>();

            services
                .AddLogging()

                .AddSingleton<IpfsBlockchainConfig>(ipfsConfig)
                .AddSingleton<ICoreApi>(provider => {
                    IpfsBlockchainConfig config = provider.GetRequiredService<IpfsBlockchainConfig>();
                    IpfsEngine engine = new IpfsEngine(config.Password.ToCharArray());

                    AsyncContext.Run(async () => {
                        engine.Options.Repository.Folder = config.AbsoluteDataDirectoryPath;
                        await engine.StartAsync();
                    });

                    return engine;
                })

                .AddSingleton<ICodec<SignedData>, SignedDataV1JsonCodec>()
                .AddSingleton<ICodec<SignedData>, SignedDataV1AvroCodec>()
                .AddSingleton<ICodec<IEnumerable<SignedData>>, SignedDataCollectionV1JsonCodec>()
                .AddSingleton<ICodec<Bill>, BillV1AvroCodec>()
                .AddSingleton<ICodec<Bill>, BillV1JsonCodec>()
                .AddSingleton<ICodec<Member>, MemberV1JsonCodec>()
                .AddSingleton<ICodec<Vote>, VoteV1JsonCodec>()
                .AddSingleton<ICodec<Vote>, VoteV1AvroCodec>()
                .AddSingleton<ICodec<IQuery>, IQueryV1JsonCodec>()

                .AddSingleton<IDataClient, InMemoryBlockchainClient>()

                .AddSingleton<IQueryProcessor<Bill>, BillQueryProcessor>()
                .AddSingleton<IQueryProcessor<Member>, MemberQueryProcessor>()
                .AddSingleton<IQueryProcessor<Vote>, VoteQueryProcessor>()
                .AddSingleton<IImmutableDataRepository<Bill>, ImmutableDataRepository<Bill>>()
                .AddSingleton<IImmutableDataRepository<Member>, ImmutableDataRepository<Member>>()
                .AddSingleton<IImmutableDataRepository<Vote>, ImmutableDataRepository<Vote>>()

                .AddSingleton<IConfigureOptions<MvcOptions>, ConfigureMvcOptions>()

                .AddControllers();

            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
