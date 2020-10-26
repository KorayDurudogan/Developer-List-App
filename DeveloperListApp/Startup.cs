using DeveloperListApp.Fields;
using DeveloperListApp.Types;
using DeveloperListApp.Types.Inputs;
using Fields.DeveloperListApp;
using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DeveloperListApp
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
            services.AddSingleton<DevelopersContext>();
            services.AddSingleton<IDependencyResolver>(_ => new FuncDependencyResolver(_.GetRequiredService));
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

            services.AddSingleton<DeveloperType>();
            services.AddSingleton<DeveloperInputType>();
            services.AddSingleton<TeamType>();

            services.AddSingleton<DevelopersQuery>();
            services.AddSingleton<DevelopersMutation>();

            services.AddSingleton<ISchema, DeveloperSchema>();

            services.AddControllers().AddNewtonsoftJson();
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

            app.UseWebSockets();

            app.UseGraphiQl("/ui/graphiql", "/api/developers");
        }
    }
}
