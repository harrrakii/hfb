using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cafe
{
    /// <summary>
    /// Логика взаимодействия для SalesPage.xaml
    /// </summary>
    public partial class SalesPage : Page
    {
        public CAFEEntities context = new CAFEEntities();
        public SalesPage()
        {
            InitializeComponent();
            DgSales.ItemsSource = context.Sales.ToList();
        }

        private void DgSales_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgSales.SelectedItem != null)
            {
                var selected = DgSales.SelectedItem as Sales;
                TbStartDate.Text = selected.StartDate.ToString();
                TbEndDate.Text = selected.EndDate.ToString();
                TbAmount.Text = selected.Amount.ToString();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            decimal value;
            DateTime date;
            if (TbAmount.Text != "" && TbEndDate.Text != "" && TbStartDate.Text != "")
            {
                if (decimal.TryParse(TbAmount.Text, out value) && DateTime.TryParse(TbStartDate.Text, out date) && DateTime.TryParse(TbEndDate.Text, out date))
                {
                    if (!ContainsEmojis(TbAmount.Text) && !ContainsEmojis(TbStartDate.Text) && !ContainsEmojis(TbEndDate.Text))
                    {
                        Sales sales = new Sales();
                        sales.StartDate = Convert.ToDateTime(TbStartDate.Text);
                        sales.EndDate = Convert.ToDateTime(TbEndDate.Text);
                        sales.Amount = Convert.ToDecimal(TbAmount.Text);

                        context.Sales.Add(sales);

                        context.SaveChanges();
                        DgSales.ItemsSource = context.Sales.ToList();
                    }
                    else MessageBox.Show("Поля не должны содержать смайлики");
                }
                else MessageBox.Show("Неправильный формат ввода");
            }
            else MessageBox.Show("Поля не заполнены");
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            decimal value;
            DateTime date;
            if (TbAmount.Text != "" && TbEndDate.Text != "" && TbStartDate.Text != "")
            {
                if (decimal.TryParse(TbAmount.Text, out value) && DateTime.TryParse(TbStartDate.Text, out date) && DateTime.TryParse(TbEndDate.Text, out date))
                {
                    if (!ContainsEmojis(TbAmount.Text) && !ContainsEmojis(TbStartDate.Text) && !ContainsEmojis(TbEndDate.Text))
                    {
                        var selected = DgSales.SelectedItem as Sales;

                        selected.StartDate = Convert.ToDateTime(TbStartDate.Text);
                        selected.EndDate = Convert.ToDateTime(TbEndDate.Text);
                        selected.Amount = Convert.ToDecimal(TbAmount.Text);

                        context.SaveChanges();
                        DgSales.ItemsSource = context.Sales.ToList();
                    }
                    else MessageBox.Show("Поля не должны содержать смайлики");
                }
                else MessageBox.Show("Неправильный формат ввода");
            }
            else MessageBox.Show("Поля не заполнены");
        }


        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (DgSales.SelectedItem != null)
            {
                context.Sales.Remove(DgSales.SelectedItem as Sales);

                context.SaveChanges();
                DgSales.ItemsSource = context.Sales.ToList();
            }
            else MessageBox.Show("Поля не выбраны");
        }

        private bool ContainsEmojis(string input)
        {
            Regex rgx = new Regex(@"\p{Cs}");
            Regex rgx2 = new Regex(@"\d|^[a-zA-Zа-яА-Я]*$");
            return rgx.IsMatch(input) || !rgx2.IsMatch(input);

        }

    }
}
