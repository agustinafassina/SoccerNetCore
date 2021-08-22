using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace SoccerNetCore.Configurations
{
    public static class OpenApiConfiguration
    {
        private const string Version = "v1";
        private const string Scheme = "Bearer";
        private const string SecurityDescription = "Please introduce Bearer Token";
        private const string SecurityTypeName = "Authorization";
        private const string EndpointName = "Soccer Api .net core";
        private static readonly string SwaggerUrl = $"/swagger/{Version}/swagger.json";

        public static void SetupSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    Version,
                    new OpenApiInfo
                    {
                        Title = "Soccer Api .net core",
                        Version = Version,
                        Description = "Repository "
                    }
                );
                var dir = new DirectoryInfo(AppContext.BaseDirectory);
                foreach (var file in dir.EnumerateFiles("*.xml")) c.IncludeXmlComments(file.FullName);

                var securitySchema = new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = SecurityDescription,
                    Name = SecurityTypeName,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = Scheme,
                    BearerFormat = "JWT",
                };

                c.AddSecurityDefinition(Scheme, securitySchema);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id =  Scheme
                            }
                        },
                        new string[] {}
                    }
            });
            });
        }

        public static void UseSwaggerConfig(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint(SwaggerUrl, EndpointName); });
        }

        public static void UseReDocConfig(this IApplicationBuilder app)
        {
            app.UseReDoc(c =>
            {
                c.SpecUrl($"../swagger/{Version}/swagger.json");
                c.EnableUntrustedSpec();
                c.ScrollYOffset(10);
                c.HideHostname();
                c.HideDownloadButton();
                c.ExpandResponses("200,201");
                c.RequiredPropsFirst();
                c.NoAutoAuth();
                c.PathInMiddlePanel();
                c.HideLoading();
                c.NativeScrollbars();
                c.DisableSearch();
                c.OnlyRequiredInSamples();
                c.SortPropsAlphabetically();
            });
        }
    }
}

