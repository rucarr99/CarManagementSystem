using CarManagementSystem.Domain.Model;
using CarManagementSystem.Domain.Services;
using CarManagementSystem.Services.Repositories;

namespace CarManagementSystem.Services.Services
{
    public class ClientService(IClientRepository clientRepository) : IClientService
    {
        private readonly IClientRepository _clientRepository =
            clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));

        public async Task Create(Client createdClient, CancellationToken cancellationToken)
        {
            await _clientRepository.CreateAsync(createdClient, cancellationToken);
            await _clientRepository.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Client>> GetAll(CancellationToken cancellationToken)
        {
            return await _clientRepository.GetAllAsync(cancellationToken);
        }

        public async Task Update(Client client, CancellationToken cancellationToken)
        {
            var clientFromDb = await _clientRepository.GetByIdAsync(client.Id, cancellationToken);
            if (clientFromDb is null)
            {
                return;
            }

            clientFromDb.UpdateClient(client.FirstName, client.LastName, client.Email, client.PhoneNumber, client.Cars);
            _clientRepository.UpdateAsync(clientFromDb);
            await _clientRepository.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var clientFromDb = await _clientRepository.GetByIdAsync(id, cancellationToken);
            if (clientFromDb is null)
            {
                return;
            }

            _clientRepository.DeleteAsync(clientFromDb);
            await _clientRepository.SaveChangesAsync(cancellationToken);
        }
    }
}