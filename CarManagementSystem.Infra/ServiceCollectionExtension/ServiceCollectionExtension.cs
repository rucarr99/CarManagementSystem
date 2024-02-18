using System.Reflection;
using CarManagementSystem.Infra.DbContext;
using CarManagementSystem.Infra.Repositories;
using CarManagementSystem.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarManagementSystem.Infra.ServiceCollectionExtension
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterDatabaseAccess(this IServiceCollection services, string connectionString)
        {
            ArgumentNullException.ThrowIfNull(services);

            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connectionString,
                builder =>
                {
                    builder.MigrationsAssembly(typeof(ServiceCollectionExtension).GetTypeInfo().Assembly.GetName()
                        .Name);
                }));

            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();

            services.AddSingleton<IDbConnectivity>(_ => new DbConnectivity(connectionString));
        }
    }
}