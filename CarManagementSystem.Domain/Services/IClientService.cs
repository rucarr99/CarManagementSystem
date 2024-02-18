using CarManagementSystem.Domain.Model;

namespace CarManagementSystem.Domain.Services
{
    public interface IClientService
    {
        Task Create(Client createdClient, CancellationToken cancellationToken = default);
        Task<IEnumerable<Client>> GetAll(CancellationToken cancellationToken = default);
        Task Delete(int id, CancellationToken cancellationToken = default);
        Task Update(Client client, CancellationToken cancellationToken);
    }
}
