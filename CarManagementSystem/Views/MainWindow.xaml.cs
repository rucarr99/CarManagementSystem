using System.Windows;
using System.Windows.Input;

namespace CarManagementSystem.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnGoToLogin_OnClick(object sender, RoutedEventArgs e)
        {
            var viewClients = new ViewClients();
            viewClients.Show();
            Close();
        }

        private void BtnExit_OnClick(object sender, RoutedEventArgs e)
        {

            Application.Current.Shutdown();
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}