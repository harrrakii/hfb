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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LogistTr
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string userName = userNameBox.Text;
            string password = passwordBox.Password;

            if (string.IsNullOrWhiteSpace(userName))
            {
                MessageBox.Show("Введите ник");
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите пароль");
                return;
            }

            using(var context = new LOGTRANCEEntities())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == userName && u.Password_ == password);

                if(user == null)
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
                else
                {
                    string role = user.RolesEmployee.Name_;
                    MessageBox.Show($"Добро пожаловать, ваша роль: {role}");

                    AllWindow allWindow = new AllWindow(role);
                    this.Hide();
                    allWindow.Show();
                    this.Close();
                }
            }
        }
    }
}
