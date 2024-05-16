using Practica1DataSet.PRACTICA1DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Practica1DataSet
{
    /// <summary>
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {

        MasterServicesTableAdapter masterServices = new MasterServicesTableAdapter();
        MastersTableAdapter masters = new MastersTableAdapter();
        Services_TableAdapter services = new Services_TableAdapter();
        public Window4()
        {
            InitializeComponent();
            MasterServicesDataGrid.ItemsSource = masterServices.GetFullData();
            //MasterServicesDataGrid.ItemsSource = masterServices.GetData();
            MasterID.ItemsSource = masters.GetData();
            ServiceID.ItemsSource = services.GetData();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            object id = (MasterServicesDataGrid.SelectedItem as DataRowView).Row[0];
            masterServices.UpdateQuery(int.Parse(MasterID.Text), int.Parse(ServiceID.Text), Convert.ToInt32(id));
            MasterServicesDataGrid.ItemsSource = masterServices.GetData();

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            masterServices.InsertQuery(int.Parse(MasterID.Text), int.Parse(ServiceID.Text));
            MasterServicesDataGrid.ItemsSource = masterServices.GetData();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            object id = (MasterServicesDataGrid.SelectedItem as DataRowView).Row[0];
            masterServices.DeleteQuery(Convert.ToInt32(id));
            MasterServicesDataGrid.ItemsSource = masterServices.GetData();
        }

        private void MasterServicesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MasterServicesDataGrid.SelectedItem != null)
            {
                var selected = MasterServicesDataGrid.SelectedItem as DataRowView;

                MasterID.Text = selected[1].ToString();
                ServiceID.Text = selected[2].ToString();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MasterServicesDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            MasterServicesDataGrid.Columns[1].Visibility = Visibility.Collapsed;
            MasterServicesDataGrid.Columns[2].Visibility = Visibility.Collapsed;
            MasterServicesDataGrid.Columns[3].Visibility = Visibility.Collapsed;
            MasterServicesDataGrid.Columns[6].Visibility = Visibility.Collapsed;
            MasterServicesDataGrid.Columns[8].Visibility = Visibility.Collapsed;
            MasterServicesDataGrid.Columns[9].Visibility = Visibility.Collapsed;
        }
    }
}
