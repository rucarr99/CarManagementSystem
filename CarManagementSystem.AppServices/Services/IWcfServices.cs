using CarManagementSystem.Shared.Dtos;
using CoreWCF;

namespace CarManagementSystem.WcfServices.Services
{
    [ServiceContract]
    public interface IWcfServices
    {
        [OperationContract]
        Task CreateClient(ClientDto client);

        [OperationContract]
        Task UpdateClient(ClientDto client);

        [OperationContract]
        Task DeleteClient(int id);

        [OperationContract]
        Task<IEnumerable<ClientDto>> GetAllClients();
    }
}
