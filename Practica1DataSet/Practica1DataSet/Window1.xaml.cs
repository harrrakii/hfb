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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Services_TableAdapter services_ = new Services_TableAdapter();
        public Window1()
        {
            InitializeComponent();
            ServicesDataGrid.ItemsSource = services_.GetData();
            CmbSearch.ItemsSource = services_.GetData();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            object id = (ServicesDataGrid.SelectedItem as DataRowView).Row[0];
            services_.UpdateQuery(Service.Text, Convert.ToDecimal(Price.Text), Convert.ToInt32(id));
            ServicesDataGrid.ItemsSource = services_.GetData();

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            services_.InsertQuery(Service.Text, decimal.Parse(Price.Text));
            ServicesDataGrid.ItemsSource = services_.GetData();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            object id = (ServicesDataGrid.SelectedItem as DataRowView).Row[0];
            services_.DeleteQuery(Convert.ToInt32(id));
            ServicesDataGrid.ItemsSource = services_.GetData();

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            ServicesDataGrid.ItemsSource = services_.SearchByName(SearchTxt.Text);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ServicesDataGrid.ItemsSource = services_.GetData();
        }

        private void CmbSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CmbSearch.SelectedItem != null)
            {
                var id = (decimal)(CmbSearch.SelectedItem as DataRowView)[2];
                ServicesDataGrid.ItemsSource = services_.FilterByColor(id);
            }
        }

    }
}
