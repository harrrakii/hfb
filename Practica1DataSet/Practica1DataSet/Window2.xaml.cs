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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {

        ScheduleTableAdapter schedule = new ScheduleTableAdapter();
        public Window2()
        {
            InitializeComponent();
            ScheduleDataGrid.ItemsSource = schedule.GetData();
            CmbSearch.ItemsSource = schedule.GetData();

        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            object id = (ScheduleDataGrid.SelectedItem as DataRowView).Row[0];
            schedule.UpdateQuery(Day.Text, Hours.Text, Convert.ToInt32(id));
            ScheduleDataGrid.ItemsSource = schedule.GetData();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            schedule.InsertQuery(Day.Text, Hours.Text);
            ScheduleDataGrid.ItemsSource = schedule.GetData();

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            object id = (ScheduleDataGrid.SelectedItem as DataRowView).Row[0];
            schedule.DeleteQuery(Convert.ToInt32(id));
            ScheduleDataGrid.ItemsSource = schedule.GetData();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            ScheduleDataGrid.ItemsSource = schedule.SearchByName(SearchTxt.Text);
        }

        private void CmbSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbSearch.SelectedItem != null)
            {
                var id = (string)(CmbSearch.SelectedItem as DataRowView).Row[2];
                ScheduleDataGrid.ItemsSource = schedule.FilterByName(id);
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ScheduleDataGrid.ItemsSource = schedule.GetData();
        }
    }
}
