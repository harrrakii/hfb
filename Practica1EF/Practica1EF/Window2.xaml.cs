using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Practica1EF
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private PRACTICA1EF1Entities context = new PRACTICA1EF1Entities();
        public Window2()
        {
            InitializeComponent();
            ScheduleDataGrid.ItemsSource = context.Schedule.ToList();
            CmbSearch.ItemsSource = context.Schedule.ToList();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if(ScheduleDataGrid.SelectedItem != null)
            {
                var selected = ScheduleDataGrid.SelectedItem as Schedule;

                selected.Day_OfWeek = Day.Text;
                selected.WorkingHours = Hours.Text;

                context.SaveChanges();
                ScheduleDataGrid.ItemsSource = context.Schedule.ToList();
            }

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Schedule schedule = new Schedule();
            schedule.WorkingHours = Hours.Text;
            schedule.Day_OfWeek = Day.Text;

            context.Schedule.Add(schedule);

            context.SaveChanges();
            ScheduleDataGrid.ItemsSource = context.Schedule.ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (ScheduleDataGrid.SelectedItem != null)
            {
                context.Schedule.Remove(ScheduleDataGrid.SelectedItem as Schedule);

                context.SaveChanges();
                ScheduleDataGrid.ItemsSource = context.Schedule.ToList();
            }
        }

        private void ScheduleDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ScheduleDataGrid.SelectedItem != null)
            {
                var selected = ScheduleDataGrid.SelectedItem as Schedule;

                Day.Text = selected.Day_OfWeek;
                Hours.Text = selected.WorkingHours;
            }
        }

        private void CmbSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbSearch.SelectedItem != null)
            {
                var selected = CmbSearch.SelectedItem as Schedule;
                ScheduleDataGrid.ItemsSource = context.Schedule.ToList().Where(item => item.WorkingHours == selected.WorkingHours);

            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ScheduleDataGrid.ItemsSource = context.Schedule.ToList();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            ScheduleDataGrid.ItemsSource = context.Schedule.ToList().Where(item => item.Day_OfWeek.Contains(SearchTxt.Text));
        }
    }
}
