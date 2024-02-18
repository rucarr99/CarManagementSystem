using ServiceReference1;
using System.ServiceModel;

namespace CarManagementSystem.ViewModels
{
    //TODO 
    //Add fluentValidation
    public class ClientViewModel : ViewModelBase
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public ClientViewModel(ClientDto client)
        {
            Id =client.Id;
            FirstName = client.FirstName;
            LastName = client.LastName;
            Email = client.Email;
            PhoneNumber = client.PhoneNumber;
        }

        public ClientViewModel()
        {
        }

        public async Task UpdateClient()
        {
            try
            {
                // Create an instance of the WCF client proxy
                await using var client = new WcfServicesClient();
                var clientDto = new ClientDto
                {
                    Email = Email,
                    LastName = LastName,
                    FirstName = FirstName,
                    Id = Id,
                    PhoneNumber = PhoneNumber
                };
                await client.UpdateClientAsync(clientDto);

            }
            catch (FaultException ex)
            {
                //TODO
            }
            catch (Exception ex)
            {
                //TODO
                // Handle other exceptions
            }
        }

        public async Task AddClient()
        {
            try
            {
                // Create an instance of the WCF client proxy
                await using var client = new WcfServicesClient();
                var clientDto = new ClientDto
                {
                    Email = Email,
                    LastName = LastName,
                    FirstName = FirstName,
                    Id = Id,
                    PhoneNumber = PhoneNumber
                };
                await client.CreateClientAsync(clientDto);

            }
            catch (FaultException ex)
            {
                //TODO
            }
            catch (Exception ex)
            {
                //TODO
                // Handle other exceptions
            }
        }

    }
}
