using Microsoft.Extensions.DependencyInjection;

namespace SoccerNetCore.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<ITeamService, TeamService>();
            return services;
        }
    }
}
