using CarManagementSystem.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CarManagementSystem.Infra.DbContext
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Car> Cars => Set<Car>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}