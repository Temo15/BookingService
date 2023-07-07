using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Reflection;

namespace BookingService.Api.Tools.Extensions
{
    public static class ConfigureMiddlewaresExtensions
    {
        private static readonly string PathBase = Environment.GetEnvironmentVariable("ASPNETCORE_APPL_PATH")!;
        public static void ConfigureMiddlewares(this WebApplication app, Assembly assembly)
        {
            app.UsePathBase();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseCors(options => options
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials()
            );
            app.UseEndpoints(app.Environment.IsProduction());
            app.UseSwagger(assembly);
            //app.UseFirebaseApp();
        }
        #region Private
        public static void UseSwagger(this IApplicationBuilder app, Assembly assembly)
        {
            IApiVersionDescriptionProvider provider = app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>();
            app.UseSwagger()
            .UseSwaggerUI(options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"{((!string.IsNullOrWhiteSpace(PathBase)) ? $"/{PathBase}" : string.Empty)}/swagger/{description.GroupName}/swagger.json",
                        $"{assembly.GetName().Name} {description.GroupName}");
                }
            });
        }
        public static void UsePathBase(this IApplicationBuilder app)
        {
            if (!string.IsNullOrWhiteSpace(PathBase))
            {
                app.UsePathBase($"/{PathBase}");
            }
        }
        public static void UseEndpoints(this IApplicationBuilder app, bool isProduction)
        {
            if (isProduction)
            {
                //ToDo: dasamatebelia tu gadava production-ze
            }
            else
            {
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                    endpoints.MapHealthChecks("/liveness", new HealthCheckOptions
                    {
                        Predicate = registration => registration.Name.Contains("self")
                    });
                    endpoints.MapHealthChecks("/hc", new HealthCheckOptions
                    {
                        Predicate = _ => true,
                    });
                    endpoints.MapGet("/", context =>
                    {
                        if (!isProduction)
                        {
                            context.Response.Redirect($"{(!string.IsNullOrWhiteSpace(PathBase) ? $"/{PathBase}" : string.Empty)}/swagger");
                            return Task.FromResult(0);
                        }
                        return context.Response.WriteAsync("OK");
                    });
                });
            }
        }
        #endregion
    }
}
