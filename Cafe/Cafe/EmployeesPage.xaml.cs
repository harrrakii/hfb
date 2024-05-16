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
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        public CAFEEntities context = new CAFEEntities();
        public EmployeesPage()
        {
            InitializeComponent();
            DgEmployees.ItemsSource = context.Employees.ToList();
            CbIDPosition.ItemsSource = context.Positions.ToList();
            CbIDCafe.ItemsSource = context.CafeShops.ToList();
            CbIDUser.ItemsSource = context.Users.ToList();
        }

        private void DgEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DgEmployees.SelectedItem != null)
            {
                var selected = DgEmployees.SelectedItem as Employees;
                TbSurname.Text = selected.Surname;
                TbName.Text = selected.Firstname;
                TbPatronymic.Text = selected.Patronymic;
                CbIDPosition.Text = selected.Positions.PositionID.ToString();
                CbIDCafe.Text = selected.CafeShops.CafeID.ToString();
                CbIDUser.Text = selected.Users.UserID.ToString();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (TbName.Text != null && TbPatronymic.Text != null && TbSurname.Text != null && CbIDCafe.SelectedItem != null && CbIDPosition.SelectedItem != null && CbIDUser.SelectedItem != null)
            {
                if (!ContainsEmojis(TbSurname.Text) && !ContainsEmojis(TbName.Text) && !ContainsEmojis(TbPatronymic.Text))
                {
                    Employees employees = new Employees();
                    employees.Surname = TbSurname.Text;
                    employees.Firstname = TbName.Text;
                    employees.Patronymic = TbPatronymic.Text;
                    employees.IDPosition = (CbIDPosition.SelectedItem as Positions).PositionID;
                    employees.IDCafe = (CbIDCafe.SelectedItem as CafeShops).CafeID;
                    employees.IDUser = (CbIDUser.SelectedItem as Users).UserID;

                    context.Employees.Add(employees);

                    context.SaveChanges();
                    DgEmployees.ItemsSource = context.Employees.ToList();
                }
                else MessageBox.Show("Поля не должны содержать смайлики или символы");
            }
            else MessageBox.Show("Поля не заполнены");
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (DgEmployees.SelectedItem != null)
            {
                if (TbName.Text != null && TbPatronymic.Text != null && TbSurname.Text != null && CbIDCafe.SelectedItem != null && CbIDPosition.SelectedItem != null && CbIDUser.SelectedItem != null)
                {
                    if (!ContainsEmojis(TbSurname.Text) && !ContainsEmojis(TbName.Text) && !ContainsEmojis(TbPatronymic.Text))
                    {
                        var selected = DgEmployees.SelectedItem as Employees;

                        selected.Surname = TbSurname.Text;
                        selected.Firstname = TbName.Text;
                        selected.Patronymic = TbPatronymic.Text;
                        selected.IDPosition = (CbIDPosition.SelectedItem as Positions).PositionID;
                        selected.IDCafe = (CbIDCafe.SelectedItem as CafeShops).CafeID;
                        selected.IDUser = (CbIDUser.SelectedItem as Users).UserID;

                        context.SaveChanges();
                        DgEmployees.ItemsSource = context.Employees.ToList();
                    }
                    else MessageBox.Show("Поля не должны содержать смайлики или символы");
                }
                else MessageBox.Show("Поля не заполнены");
            }
            else MessageBox.Show("Поля не выбраны");
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(DgEmployees.SelectedItem != null)
            {
                context.Employees.Remove(DgEmployees.SelectedItem as Employees);

                context.SaveChanges();
                DgEmployees.ItemsSource = context.Employees.ToList();
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
