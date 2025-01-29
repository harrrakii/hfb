using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LogistTr
{
    /// <summary>
    /// Логика взаимодействия для AllWindow.xaml
    /// </summary>
    public partial class AllWindow : Window
    {
        private string _role;

        public AllWindow(string role)
        {
            InitializeComponent();
            _role = role;

            ConfigureControlPanel();
        }

        private void ConfigureControlPanel()
        {
            ControlPanel.Items.Clear();

            if (_role == "Administrator")
            {
                AddButtonToPanel("Главная", NavigateToMainPage);
                AddButtonToPanel("Заказы", NavigateToOrderPage);
                AddButtonToPanel("Клиенты", NavigateToClientPage);
                AddButtonToPanel("Склад", NavigateToWarehousePage);
                AddButtonToPanel("Маршруты", NavigateToRoutesPage);
                AddButtonToPanel("Отчеты", NavigateToDocuments);
                AddButtonToPanel("Транспорт ", NavigateToVehiclesPage);
            }
            else if (_role == "Driver")
            {
                AddButtonToPanel("Маршруты", NavigateToRoutesPage);
            }
            else if (_role == "Logist")
            {
                AddButtonToPanel("Главная", NavigateToMainPage);
                AddButtonToPanel("Заказы", NavigateToOrderPage);
                AddButtonToPanel("Клиенты", NavigateToClientPage);
                AddButtonToPanel("Склад", NavigateToWarehousePage);
                AddButtonToPanel("Маршруты", NavigateToRoutesPage);
                AddButtonToPanel("Транспорт ", NavigateToVehiclesPage);
            }
        }

        private void AddButtonToPanel(string content, RoutedEventHandler clickHandler)
        {
            Button button = new Button
            {
                Content = content,
                Margin = new Thickness(10),
                Width = 180,
                Height = 20
            };
            button.Click += clickHandler;
            ControlPanel.Items.Add(button);
        }
        private void NavigateToMainPage(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new MainPage());
        }
        
        private void NavigateToOrderPage(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new OrdersPage());
        }

        private void NavigateToClientPage(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new ClientsPage());
        }

        private void NavigateToWarehousePage(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new WarehousePage());
        }

        private void NavigateToRoutesPage(object sender, RoutedEventArgs e)
        {
            RoutesPage routesPage = new RoutesPage(_role);
            MainContentFrame.Navigate(routesPage);
        }
        
        private void NavigateToDocuments(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new Documents());
        }
        
        private void NavigateToVehiclesPage(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new VehiclesPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
