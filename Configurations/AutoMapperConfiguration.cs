using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SoccerNetCore.Mappers;

namespace SoccerNetCore.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static void AddMappers(this IServiceCollection services)
        {
           services.AddAutoMapper(new Type[] { typeof(ContractMapping) });
        }
    }
}
