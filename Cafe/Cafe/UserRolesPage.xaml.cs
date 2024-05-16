using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
using static MaterialDesignThemes.Wpf.Theme;

namespace Cafe
{
    /// <summary>
    /// Логика взаимодействия для UserRolesPage.xaml
    /// </summary>
    public partial class UserRolesPage : Page
    {
        public CAFEEntities context = new CAFEEntities();
        public UserRolesPage()
        {
            InitializeComponent();
            DgUserRoles.ItemsSource = context.UserRoles.ToList();
        }

        private void DgUserRoles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgUserRoles.SelectedItem != null)
            {
                var selected = DgUserRoles.SelectedItem as UserRoles;
                TbRole.Text = selected.Role;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (TbRole.Text != "")
            {
                if (!ContainsEmojis(TbRole.Text))
                {
                    UserRoles userRoles = new UserRoles();
                    userRoles.Role = TbRole.Text;

                    context.UserRoles.Add(userRoles);
                    context.SaveChanges();
                    DgUserRoles.ItemsSource = context.UserRoles.ToList();
                }
                else MessageBox.Show("Поле не должно содержать смайлики");
            }
            else MessageBox.Show("Поле не заполнено");
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (DgUserRoles.SelectedItem != null)
            {
                if (TbRole.Text != "")
                {
                    if (!ContainsEmojis(TbRole.Text))
                    {
                        var selected = DgUserRoles.SelectedItem as UserRoles;
                        selected.Role = TbRole.Text;

                        context.SaveChanges();
                        DgUserRoles.ItemsSource = context.UserRoles.ToList();
                    }
                    else MessageBox.Show("Поле не должно содержать смайлики");
                }
                else MessageBox.Show("Поле не заполнено");
            }
            else MessageBox.Show("Поле не выбрано");
        }

        private bool ContainsEmojis(string input)
        {
            Regex rgx = new Regex(@"\p{Cs}");
            Regex rgx2 = new Regex(@"\d|^[a-zA-Zа-яА-Я]*$");
            return rgx.IsMatch(input) || !rgx2.IsMatch(input);

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (DgUserRoles.SelectedItem != null)
            {
                context.UserRoles.Remove(DgUserRoles.SelectedItem as UserRoles);
                context.SaveChanges();
                DgUserRoles.ItemsSource = context.UserRoles.ToList();
            }
            else MessageBox.Show("Поле не выбрано");
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            string json = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\json_rolessss.json");
            List<SerRoles> cafe = JsonConvert.DeserializeObject<List<SerRoles>>(json);
            foreach (var item in cafe)
            {
                UserRoles u = new UserRoles();
                u.Role = item.ser_Roles__.ToString();
                context.UserRoles.Add(u);
                context.SaveChanges();
                DgUserRoles.ItemsSource = context.UserRoles.ToList();
            }
        }
    }
}
