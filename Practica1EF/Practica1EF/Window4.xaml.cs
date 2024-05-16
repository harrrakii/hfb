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
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        private PRACTICA1EF1Entities context = new PRACTICA1EF1Entities();
        public Window4()
        {
            InitializeComponent();
            MasterServicesDataGrid.ItemsSource = context.MasterServices.ToList();
            MasterID.ItemsSource = context.Masters.ToList();
            ServiceID.ItemsSource = context.Services_.ToList();
        }

        private void MasterServicesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MasterServicesDataGrid.SelectedItem != null)
            {
                var selected = MasterServicesDataGrid.SelectedItem as MasterServices;
                MasterID.Text = selected.ID_Master.ToString();
                ServiceID.Text = selected.ID_Service.ToString();
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (MasterServicesDataGrid.SelectedItem != null)
            {
                var selected = MasterServicesDataGrid.SelectedItem as MasterServices;
                selected.ID_Master = (int)(MasterID.SelectedItem as Masters).Master_ID;
                selected.ID_Service = (int)(ServiceID.SelectedItem as Services_).Service_ID;

                context.SaveChanges();
                MasterServicesDataGrid.ItemsSource = context.MasterServices.ToList();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            MasterServices masterServices = new MasterServices();
            masterServices.ID_Master = (int)(MasterID.SelectedItem as Masters).Master_ID;
            masterServices.ID_Service = (int)(ServiceID.SelectedItem as Services_).Service_ID;

            context.MasterServices.Add(masterServices);

            context.SaveChanges();
            MasterServicesDataGrid.ItemsSource = context.MasterServices.ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(MasterServicesDataGrid.SelectedItem != null)
            {
                context.MasterServices.Remove(MasterServicesDataGrid.SelectedItem as MasterServices);

                context.SaveChanges();
                MasterServicesDataGrid.ItemsSource = context.MasterServices.ToList();
            }
        }
    }
}
