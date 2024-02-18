using CarManagementSystem.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CarManagementSystem.Services.Services
{
    public static class ContainerRegistration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IClientService, ClientService>();
        }
    }
}
