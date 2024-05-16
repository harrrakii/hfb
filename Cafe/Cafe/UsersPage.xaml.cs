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
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        public CAFEEntities context = new CAFEEntities();
        public UsersPage()
        {
            InitializeComponent();
            DgUsers.ItemsSource = context.Users.ToList();
            CbRoleID.ItemsSource = context.UserRoles.ToList();
        }

        private void DgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DgUsers.SelectedItem != null)
            {
                var selected = DgUsers.SelectedItem as Users;
                TbLogin.Text = selected.Login_;
                TbPassword.Text = selected.Password_;
                CbRoleID.Text = selected.UserRoles.RoleID.ToString();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidInput())
            {
                if (!ContainsEmojis(TbLogin.Text) && !ContainsEmojis(TbPassword.Text))
                {
                    Users users = new Users();
                    users.Login_ = TbLogin.Text;
                    users.Password_ = TbPassword.Text;
                    users.IDRole = (CbRoleID.SelectedItem as UserRoles).RoleID;

                    context.Users.Add(users);

                    context.SaveChanges();
                    DgUsers.ItemsSource = context.Users.ToList();
                }
                else MessageBox.Show("Логин и пароль не должны содержать смайлики");
            }
            else MessageBox.Show("Поля не заполнены");
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (DgUsers.SelectedItem != null)
            {
                if (IsValidInput())
                {
                    if (!ContainsEmojis(TbLogin.Text) && !ContainsEmojis(TbPassword.Text))
                    {
                        var selected = DgUsers.SelectedItem as Users;

                        selected.Login_ = TbLogin.Text;
                        selected.Password_ = TbPassword.Text;
                        selected.IDRole = (CbRoleID.SelectedItem as UserRoles).RoleID;

                        context.SaveChanges();
                        DgUsers.ItemsSource = context.Users.ToList();
                    }
                    else MessageBox.Show("Логин и пароль не должны содержать смайлики");
                }
                else MessageBox.Show("Поля не заполнены");
            }
            else MessageBox.Show("Поля не выбраны");
        }

        private bool IsValidInput()
        {
            return !string.IsNullOrWhiteSpace(TbLogin.Text) && !string.IsNullOrWhiteSpace(TbPassword.Text) && CbRoleID.SelectedItem != null;
        }

        private bool ContainsEmojis(string input)
        {
            Regex rgx = new Regex(@"\p{Cs}");
            Regex rgx2 = new Regex(@"\d|^[a-zA-Zа-яА-Я]*$");
            return rgx.IsMatch(input) || !rgx2.IsMatch(input);

        }


        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (DgUsers.SelectedItem != null)
            {
                context.Users.Remove(DgUsers.SelectedItem as Users);

                context.SaveChanges();
                DgUsers.ItemsSource = context.Users.ToList();
            }
            else MessageBox.Show("Поля не выбраны");
        }
    }
}
