using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CarManagementSystem.ViewModels;

namespace CarManagementSystem.Views
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ViewClients : Window
    {
        private readonly ClientsViewModel _viewModel = new();

        public ViewClients()
        {
            InitializeComponent();
            Loaded += Data_Loaded;
        }

        private async void Data_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await _viewModel.GetDataFromServiceAsync();

                DataContext = _viewModel;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void LogoutBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var messageBoxResult =
                MessageBox.Show("Are you sure?", "Logout confirmation", MessageBoxButton.YesNo);

            if (messageBoxResult != MessageBoxResult.Yes) return;
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void ViewClientsBtn_OnClick(object sender, RoutedEventArgs e)
        {
        }

        private void ViewCarsBtn_OnClick(object sender, RoutedEventArgs e)
        {
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button { CommandParameter: ClientViewModel client }) return;
            var addWindow = new AddClient(client);
            addWindow.Closed += AddClient_Close;
            addWindow.ShowDialog();
        }

        private void AddClient_Close(object? sender, EventArgs e)
        {
            _ = AddClientAsync_Close(sender, e);
        }

        private async Task AddClientAsync_Close(object? sender, EventArgs e)
        {
            if (sender is Window { DialogResult: true })
            {
                await _viewModel.GetDataFromServiceAsync();
                DataContext = _viewModel;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            _ = DeleteButtonClickAsync(sender, e);
        }

        private async Task DeleteButtonClickAsync(object sender, RoutedEventArgs e)
        {
            if (ClientsView.SelectedItem is ClientViewModel selectedClient)
            {
                await _viewModel.DeleteClient(selectedClient);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddClient();
            addWindow.Closed += AddClient_Close;
            addWindow.Show();
        }

        private void BtnExit_OnClick(object sender, RoutedEventArgs e)
        {
            var messageBoxResult =
                MessageBox.Show("Are you sure?", "Logout confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult != MessageBoxResult.Yes) return;
            Close();
        }
    }
}