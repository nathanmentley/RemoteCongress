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
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RemoteCongress.Common.Repositories;
using RemoteCongress.Server.DAL;
//using RemoteCongress.Server.DAL.InMemory;
using RemoteCongress.Server.DAL.IpfsBlockchainDb;
using RemoteCongress.Server.Web.Formatters;
using System.Net.Http;

namespace RemoteCongress.Server.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton<HttpClient>(_ => {
                    var handler = new HttpClientHandler();
                    handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                    handler.ServerCertificateCustomValidationCallback = 
                        (httpRequestMessage, cert, cetChain, policyErrors) => true;

                    return new HttpClient(handler);
                })

                .AddSingleton<IBlockchainClient>(
                    new IpfsBlockchainClient(
                        null
                    )
                )

                .AddSingleton<IBillRepository, BillRepository>()
                .AddSingleton<IVoteRepository, VoteRepository>()

                .AddControllers()

                .AddMvcOptions(options => {
                    options.InputFormatters.Insert(0, new BillInputFormatter());
                    options.InputFormatters.Insert(0, new VoteInputFormatter());

                    options.OutputFormatters.Insert(0, new BillOutputFormatter());
                    options.OutputFormatters.Insert(0, new VoteOutputFormatter());
                });
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
