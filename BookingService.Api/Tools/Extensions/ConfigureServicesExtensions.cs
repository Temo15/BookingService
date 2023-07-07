using BookingService.Api.Common.Swagger;
using BookingService.Application.Tools.Extensions;
using BookingService.Persistance.Tools.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Text.Json;

namespace BookingService.Api.Tools.Extensions
{
    public static class ConfigureServicesExtensions
    {
        public static void ConfigureServices(this WebApplicationBuilder builder, Assembly assembly)
        {
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.WriteIndented = true;
                }).ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);
            builder.Services.AddRouting(options => options.LowercaseUrls = true);
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddHealthChecks(builder.Configuration, assembly);
            builder.Services.AddApiVersioningOptions();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwagger();
            builder.Services.AddApplication();
            builder.Services.AddPersistence(builder.Configuration);
        }
        #region Private
        private static void AddHealthChecks(this IServiceCollection services, IConfiguration configuration, Assembly assembly)
        {
            IHealthChecksBuilder builder = services.AddHealthChecks()
                .AddCheck("self", () => HealthCheckResult.Healthy());
            string connectionString = configuration.GetConnectionString("SQL");
        }
        private static void AddApiVersioningOptions(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            });
            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VV";
                options.SubstituteApiVersionInUrl = true;
            });
        }
        private static void AddSwagger(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerConfiguration>();
            services.AddSwaggerGen(options =>
            {
                options.UseInlineDefinitionsForEnums();
                options.CustomSchemaIds(type => type.ToString());
            });
        }
        #endregion
    }
}
