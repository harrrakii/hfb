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

namespace Practica1EF
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private PRACTICA1EF1Entities context = new PRACTICA1EF1Entities();
        public Window1()
        {
            InitializeComponent();
            ServicesDataGrid.ItemsSource = context.Services_.ToList();
            CmbSearch.ItemsSource = context.Services_.ToList();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (ServicesDataGrid.SelectedItem != null)
            {
                var selected = ServicesDataGrid.SelectedItem as Services_;
                selected.ServiceName = Service.Text;
                selected.Price = decimal.Parse(Price.Text);

                context.SaveChanges();
                ServicesDataGrid.ItemsSource = context.Services_.ToList();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Services_ services_ = new Services_();
            services_.ServiceName = Service.Text;
            services_.Price = decimal.Parse(Price.Text);

            context.Services_.Add(services_);
            context.SaveChanges();
            ServicesDataGrid.ItemsSource = context.Services_.ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(ServicesDataGrid.SelectedItem != null)
            {
                context.Services_.Remove(ServicesDataGrid.SelectedItem as Services_);

                context.SaveChanges();
                ServicesDataGrid.ItemsSource = context.Services_.ToList();
            }
        }

        private void ServicesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ServicesDataGrid.SelectedItem != null)
            {
                var selected = ServicesDataGrid.SelectedItem as Services_;
                Service.Text = selected.ServiceName;
                Price.Text = Convert.ToString(selected.Price);
            }
        }
        

        private void CmbSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CmbSearch.SelectedItem != null)
            {
                var selected = CmbSearch.SelectedItem as Services_;
                ServicesDataGrid.ItemsSource = context.Services_.ToList().Where(item => item.Price == selected.Price);

            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ServicesDataGrid.ItemsSource = context.Services_.ToList();
        }

        private void Search_Click_1(object sender, RoutedEventArgs e)
        {
            ServicesDataGrid.ItemsSource = context.Services_.ToList().Where(item => item.ServiceName.Contains(SearchTxt.Text));

        }
    }
}
