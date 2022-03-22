using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace XMLProcessor.Server.API.CustomExtensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            // Register the Swagger generator
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ServerApp.API",
                    Version = "v1",
                    Description = "The XML Processing Service HTTP API",
                });
                c.IncludeXmlComments(string.Format(@"{0}\SampleContent.xml", System.AppDomain.CurrentDomain.BaseDirectory));
            });

            return services;
        }
        public static IServiceCollection AddCustomCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            return services;
        }

        public static IServiceCollection AddCustomApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });

            return services;
        }
        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {

            services.AddMvc()
             .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
             .AddControllersAsServices();

            return services;
        }


    }
}
