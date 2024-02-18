using CarManagementSystem.Domain.Model;
using CarManagementSystem.Domain.Services;
using CarManagementSystem.Shared.Dtos;

namespace CarManagementSystem.WcfServices.Services
{
    public class WcfServices(IClientService clientService) : IWcfServices
    {
        private readonly IClientService _clientService =
            clientService ?? throw new ArgumentNullException(nameof(clientService));

        public async Task CreateClient(ClientDto client)
        {
            var createdClient = Client.CreateClient(client.FirstName, client.LastName, client.Email, client.PhoneNumber,
                new List<Car>());
            await _clientService.Create(createdClient, CancellationToken.None);
        }

        public async Task UpdateClient(ClientDto client)
        {
            var clientToUpdate = new Client
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Email = client.Email,
                PhoneNumber = client.PhoneNumber,
            };
            await _clientService.Update(clientToUpdate, CancellationToken.None);
        }

        public async Task DeleteClient(int id)
        {
            await _clientService.Delete(id, CancellationToken.None);
        }

        public async Task<IEnumerable<ClientDto>> GetAllClients()
        {
            var clients = await _clientService.GetAll(CancellationToken.None);
            return clients.Select(x => new ClientDto
            {
                Id = x.Id,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber,
            });
        }
    }
}