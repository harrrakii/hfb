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
using static System.Net.Mime.MediaTypeNames;

namespace Cafe
{
    /// <summary>
    /// Логика взаимодействия для CustomersPage.xaml
    /// </summary>
    public partial class CustomersPage : Page
    {
        public CAFEEntities context = new CAFEEntities();
        public CustomersPage()
        {
            InitializeComponent();
            DgCustomers.ItemsSource = context.Customers.ToList();
        }

        private void DgEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgCustomers.SelectedItem != null)
            {
                var selected = DgCustomers.SelectedItem as Customers;
                TbSurname.Text = selected.Surname;
                TbName.Text = selected.Firstname;
                TbPatronymic.Text = selected.Patronymic;
                TbNumber.Text = selected.Number;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (TbName.Text != "" && TbPatronymic.Text != "" && TbSurname.Text != "" && TbNumber.Text != "")
            {
                if (!ContainsEmojis(TbSurname.Text) && !ContainsEmojis(TbName.Text) && !ContainsEmojis(TbPatronymic.Text) && !ContainsEmojis(TbNumber.Text))
                {
                    Customers customers = new Customers();
                    customers.Surname = TbSurname.Text;
                    customers.Firstname = TbName.Text;
                    customers.Patronymic = TbPatronymic.Text;
                    customers.Number = TbNumber.Text;

                    context.Customers.Add(customers);

                    context.SaveChanges();
                    DgCustomers.ItemsSource = context.Customers.ToList();
                }
                else MessageBox.Show("Поля не должны содержать смайлики");
            }
            else MessageBox.Show("Поля не заполнены");
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (DgCustomers.SelectedItem != null)
            {
                if (TbName.Text != "" && TbPatronymic.Text != "" && TbSurname.Text != "" && TbNumber.Text != "")
                {
                    if (!ContainsEmojis(TbSurname.Text) && !ContainsEmojis(TbName.Text) && !ContainsEmojis(TbPatronymic.Text) && !ContainsEmojis(TbNumber.Text))
                    {
                        var selected = DgCustomers.SelectedItem as Customers;

                        selected.Surname = TbSurname.Text;
                        selected.Firstname = TbName.Text;
                        selected.Patronymic = TbPatronymic.Text;
                        selected.Number = TbNumber.Text;

                        context.SaveChanges();
                        DgCustomers.ItemsSource = context.Customers.ToList();
                    }
                    else MessageBox.Show("Поля не должны содержать смайлики или символы");
                }
                else MessageBox.Show("Поля не заполнены");
            }
            else MessageBox.Show("Поля не выбраны");
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (DgCustomers.SelectedItem != null)
            {
                context.Customers.Remove(DgCustomers.SelectedItem as Customers);

                context.SaveChanges();
                DgCustomers.ItemsSource = context.Customers.ToList();
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
