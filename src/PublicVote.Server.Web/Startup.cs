using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PublicVote.Common.Serializers;
using PublicVote.Server.Actions;
using PublicVote.Server.DAL;
using PublicVote.Server.Web.Formatters;

namespace PublicVote.Server.Web
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
                .AddSingleton<IBlockchainClient, BlockchainClient>(
                    _ => new BlockchainClient("connection string")
                )

                .AddSingleton<IBillRepository, BillRepository>()
                .AddSingleton<IVoteRepository, VoteRepository>()

                .AddSingleton<ICreateBillAction, CreateBillAction>()
                .AddSingleton<ISubmitVoteAction, SubmitVoteAction>()

                .AddControllers()

                .AddMvcOptions(options => {
                    options.InputFormatters.Add(new BillInputFormatter(new BillSerializer()));
                    options.InputFormatters.Add(new VoteInputFormatter(new VoteSerializer()));

                    options.OutputFormatters.Add(new BillOutputFormatter());
                    options.OutputFormatters.Add(new VoteOutputFormatter());
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
