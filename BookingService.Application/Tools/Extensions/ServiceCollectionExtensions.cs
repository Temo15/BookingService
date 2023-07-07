using BookingService.Application.Common.FireBaseAuthentication;
using BookingService.Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookingService.Application.Tools.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            services.AddScoped<IFireBaseAuthenticationService, FireBaseAuthenticationService>();
        }
    }
}
