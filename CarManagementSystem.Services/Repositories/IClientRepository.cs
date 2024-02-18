using CarManagementSystem.Domain.Model;

namespace CarManagementSystem.Services.Repositories
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        Task<IEnumerable<Client>> GetClientsWithCars();
    }
}
