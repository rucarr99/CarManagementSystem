using CarManagementSystem.Domain.Model;
using CarManagementSystem.Infra.DbContext;
using CarManagementSystem.Services.Repositories;

namespace CarManagementSystem.Infra.Repositories
{
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        public CarRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
