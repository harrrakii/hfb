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

namespace Cafe
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public CAFEEntities context = new CAFEEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtAuthorisation_Click(object sender, RoutedEventArgs e)
        {
            if (TbLogin.Text != "" && PbParol.Password != "")
            {
                var user = context.Users.FirstOrDefault(u => u.Login_ == TbLogin.Text && u.Password_ == PbParol.Password);
                if (user != null)
                {
                    var userRole = context.UserRoles.FirstOrDefault(r => r.RoleID == user.IDRole);

                    if (userRole != null)
                    {
                        switch (Convert.ToInt32(userRole.RoleID))
                        {
                            case 1:
                                MainAdminWindow mainAdminWindow = new MainAdminWindow();
                                mainAdminWindow.Show();
                                Close();
                                break;
                            case 2:
                                AdminWindow adminWindow = new AdminWindow();
                                adminWindow.Show();
                                Close();
                                break;
                            case 3:
                                StaffWindow staffWindow = new StaffWindow();
                                staffWindow.Show();
                                Close();
                                break;
                        }
                    }
                    else
                    {

                    }
                }
                else MessageBox.Show("Данного пользователя не существует");
            }
        }
    }
}
