using System.Windows;
using System.Windows.Input;
using CarManagementSystem.ViewModels;

namespace CarManagementSystem.Views
{
    /// <summary>
    /// Interaction logic for AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        private readonly ClientViewModel? _client;

        public AddClient(ClientViewModel? client = null)
        {
            _client = client;
            InitializeComponent();
            if (client != null)
            {
                FirstName.Text = client.FirstName;
                LastName.Text = client.LastName;
                PhoneNumber.Text = client.PhoneNumber;
                Email.Text = client.Email;
            }
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private async Task ButtonSaveAsync_OnClick(object sender, RoutedEventArgs e)
        {
            if (_client is not null)
            {
                _client.FirstName = FirstName.Text;
                _client.LastName = LastName.Text;
                _client.PhoneNumber = PhoneNumber.Text;
                _client.Email = Email.Text;

                await _client.UpdateClient();
            }
            else
            {
                var newClient = new ClientViewModel
                {
                    FirstName = FirstName.Text,
                    LastName = LastName.Text,
                    PhoneNumber = PhoneNumber.Text,
                    Email = Email.Text,
                };

                await newClient.AddClient();
            }

            this.DialogResult = true;
            this.Close();
        }

        private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var messageBoxResult =
                MessageBox.Show("Are you sure?", "Logout confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult != MessageBoxResult.Yes) return;
            Close();
        }

        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
            _ = ButtonSaveAsync_OnClick(sender, e);
        }
    }
}