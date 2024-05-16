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
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        private PRACTICA1EF1Entities context = new PRACTICA1EF1Entities();
        public Window3()
        {
            InitializeComponent();
            MastersDataGrid.ItemsSource = context.Masters.ToList();
            CmbNumberOfDay.ItemsSource = context.Schedule.ToList();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (MastersDataGrid.SelectedItem != null)
            {
                var selected = MastersDataGrid.SelectedItem as Masters;

                selected.FullName = Name.Text;
                selected.ScheduleID = (CmbNumberOfDay.SelectedItem as Schedule).ScheduleID;

                context.SaveChanges();
                MastersDataGrid.ItemsSource = context.Masters.ToList();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Masters masters = new Masters();
            masters.FullName = Name.Text;
            masters.ScheduleID = (CmbNumberOfDay.SelectedItem as Schedule).ScheduleID;

            context.Masters.Add(masters);

            context.SaveChanges();
            MastersDataGrid.ItemsSource = context.Masters.ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(MastersDataGrid.SelectedItem != null)
            {
                context.Masters.Remove(MastersDataGrid.SelectedItem as Masters);

                context.SaveChanges();
                MastersDataGrid.ItemsSource = context.Masters.ToList();
            }
        }

        private void MastersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MastersDataGrid.SelectedItem != null)
            {
                var selected = MastersDataGrid.SelectedItem as Masters;

                Name.Text = selected.FullName;
                CmbNumberOfDay.Text = selected.ScheduleID.ToString();
            }
        }

    }
}
