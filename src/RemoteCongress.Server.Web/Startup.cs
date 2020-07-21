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
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Nito.AsyncEx;
using RemoteCongress.Common.Repositories;
using RemoteCongress.Server.DAL.IpfsBlockchainDb;
using System.Diagnostics.CodeAnalysis;

namespace RemoteCongress.Server.Web
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

                .AddSingleton<IDataClient, IpfsBlockchainClient>()

                .AddSingleton<IBillRepository, BillRepository>()
                .AddSingleton<IVoteRepository, VoteRepository>()

                .AddSingleton<IConfigureOptions<MvcOptions>, ConfigureMvcOptions>()

                .AddControllers();

                //.AddMvc()
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
