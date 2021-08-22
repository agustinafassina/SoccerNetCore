using System.Buffers;
using System.Linq;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SoccerNetCore.Configurations;
using SoccerNetCore.Context;
using SoccerNetCore.Repository;
using SoccerNetCore.Services;

namespace SoccerNetCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private readonly string Policy = "OriginAllowedPolicy";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddDbContextCheck<SoccerNetCoreDbContext>();

            services.SetupSwagger();

            services.AddMappers();
            services.AddRepository(Configuration);

            services.AddCors(o => o.AddPolicy(Policy, builder =>
            {
                if (Configuration.GetValue<bool>("CrossOrigins"))
                {
                    builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                }
                else
                {
                    builder.WithOrigins(Configuration.GetSection("AllowedOriginsList").GetChildren().ToArray().Select(c => c.Value).ToArray());
                }
            }));

            services.AddODataConfiguration();

            services.AddService();

            services
                .AddControllers(options => options.EnableEndpointRouting = false)
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(Policy);

            app.UseRouting();

            app.UseSwaggerConfig();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseMvc(routeBuilder =>
            {
                routeBuilder.Select().Filter().Expand().OrderBy().Count().MaxTop(null);
                routeBuilder.MapODataServiceRoute("odata", "odata", ODataConfiguration.GetEdmModel());
                routeBuilder.EnableDependencyInjection();
            });
        }
    }
}
