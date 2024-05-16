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
    /// Логика взаимодействия для StaffWindow.xaml
    /// </summary>
    public partial class StaffWindow : Window
    {
        public StaffWindow()
        {
            InitializeComponent();
        }
        private void Customers_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new CustomersPage();
        }

        private void Sellings_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new SellingsPage();
        }

        private void SellingDetails_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new SellingDetailsPage();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new OrderPage();
        }

        private void Receipt_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new ReceiptPage();
        }
    }
}
