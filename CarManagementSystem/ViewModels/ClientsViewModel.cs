using System.CodeDom;
using System.Collections.ObjectModel;
using System.ServiceModel;
using ServiceReference1;

namespace CarManagementSystem.ViewModels
{
    //TODO 
    //Add fluentValidation
    internal class ClientsViewModel : ViewModelBase
    {
        private ObservableCollection<ClientViewModel> _dataList = new();
        public ObservableCollection<ClientViewModel> DataList
        {
            get => _dataList;
            set
            {
                _dataList = value;
                OnPropertyChanged();
            }
        }
        public List<string> PropertiesToEdit { get; } = new() { "FirstName", "LastName", "Email", "PhoneNumber" };

        public async Task GetDataFromServiceAsync()
        {
            try
            {
                // Create an instance of the WCF client proxy
                await using var client = new WcfServicesClient();
                // Call the asynchronous method of your WCF service
                var result = await client.GetAllClientsAsync();

                // Update UI with the retrieved data
                if (result != null)
                {
                    DataList = new ObservableCollection<ClientViewModel>(result.Select(x => new ClientViewModel(x)));
                }
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

        public async Task DeleteClient(ClientViewModel selectedClient)
        {
            var client = DataList.FirstOrDefault(x => x.Id == selectedClient.Id);
            if (client != null)
            {
                try
                {
                    // Create an instance of the WCF client proxy
                    await using var wcfClient = new WcfServicesClient();
                    await wcfClient.DeleteClientAsync(client.Id);

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
                DataList.Remove(selectedClient);
            }
        }
    }
}
