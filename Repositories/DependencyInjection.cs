using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoccerNetCore.Context;

namespace SoccerNetCore.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<SoccerNetCoreDbContext>(options =>
                    options.UseInMemoryDatabase("Test db"));
            }
            else
            {
                services.AddDbContext<SoccerNetCoreDbContext>(options =>
                    options.UseMySQL(
                        Environment.GetEnvironmentVariable("ConnectionString") ??
                        configuration.GetConnectionString("DefaultConnection")
                    )
                );
            }

            services.AddScoped<ISoccerNetCoreDbContext>(provider => provider.GetService<ISoccerNetCoreDbContext>());

            services.AddRepositories();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            return services;
        }
    }
}
