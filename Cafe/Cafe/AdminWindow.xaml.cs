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

namespace Cafe
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void CafeShops_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new CafeShopsPage();
        }

        private void Employees_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new EmployeesPage();
        }

        private void ProductTypes_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new ProductTypesPage();
        }

        private void Products_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new ProductsPage();
        }

        private void Sales_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new SalesPage();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
