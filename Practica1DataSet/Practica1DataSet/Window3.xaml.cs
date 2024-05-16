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
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {

        MastersTableAdapter mastersTable = new MastersTableAdapter();
        ScheduleTableAdapter scheduleTable = new ScheduleTableAdapter();

        public Window3()
        {
            InitializeComponent();
            MastersDataGrid.ItemsSource = mastersTable.GetFullData();
            //MastersDataGrid.ItemsSource = mastersTable.GetData();
            CmbNumberOfDay.ItemsSource = scheduleTable.GetData();
            CmbSearch.ItemsSource = scheduleTable.GetData();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            object id = (MastersDataGrid.SelectedItem as DataRowView).Row[0];
            mastersTable.UpdateQuery(Name.Text, int.Parse(CmbNumberOfDay.Text), Convert.ToInt32(id));
            MastersDataGrid.ItemsSource = mastersTable.GetData();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

            mastersTable.InsertQuery(Name.Text, int.Parse(CmbNumberOfDay.Text));
            MastersDataGrid.ItemsSource = mastersTable.GetData();

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            object id = (MastersDataGrid.SelectedItem as DataRowView).Row[0];
            mastersTable.DeleteQuery(Convert.ToInt32(id));
            MastersDataGrid.ItemsSource = mastersTable.GetData();

        }

        private void MastersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MastersDataGrid.SelectedItem != null)
            {
                var selected = MastersDataGrid.SelectedItem as DataRowView;

                CmbNumberOfDay.Text = selected[2].ToString();
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            MastersDataGrid.ItemsSource = mastersTable.GetData();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            MastersDataGrid.ItemsSource = mastersTable.SearchBy(SearchTxt.Text);
        }

        private void CmbSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbSearch.SelectedItem != null)
            {
                var id = (int?)(CmbSearch.SelectedItem as DataRowView).Row[0];
                MastersDataGrid.ItemsSource = mastersTable.FilterBy(id);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MastersDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            MastersDataGrid.Columns[2].Visibility = Visibility.Collapsed;
            MastersDataGrid.Columns[3].Visibility = Visibility.Collapsed;
        }
    }
}
