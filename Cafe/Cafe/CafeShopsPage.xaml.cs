using Microsoft.Win32;
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
using static System.Net.Mime.MediaTypeNames;

namespace Cafe
{
    /// <summary>
    /// Логика взаимодействия для CafeShopsPage.xaml
    /// </summary>
    public partial class CafeShopsPage : Page
    {
        public CAFEEntities context = new CAFEEntities();
        public CafeShopsPage()
        {
            InitializeComponent();
            DgCafeShops.ItemsSource = context.CafeShops.ToList();
        }

        private void DgPositions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgCafeShops.SelectedItem != null)
            {
                var selected = DgCafeShops.SelectedItem as CafeShops;
                TbAddress.Text = selected.Address_;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (TbAddress.Text != "")
            {
                if (!ContainsEmojis(TbAddress.Text))
                {
                    CafeShops cafeShops = new CafeShops();
                    cafeShops.Address_ = TbAddress.Text;

                    context.CafeShops.Add(cafeShops);
                    context.SaveChanges();
                    DgCafeShops.ItemsSource = context.CafeShops.ToList();
                }
                else
                {
                    MessageBox.Show("Адрес не должен содержать смайликов.");
                }
            }
            else
            {
                MessageBox.Show("Поле не заполнено");
            }
        }


        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (DgCafeShops.SelectedItem != null)
            {
                if (TbAddress.Text != "")
                {
                    if (!ContainsEmojis(TbAddress.Text))
                    {
                        var selected = DgCafeShops.SelectedItem as CafeShops;
                        selected.Address_ = TbAddress.Text;

                        context.SaveChanges();
                        DgCafeShops.ItemsSource = context.CafeShops.ToList();
                    }
                    else
                    {
                        MessageBox.Show("Адрес не должен содержать смайликов.");
                    }
                }
                else
                {
                    MessageBox.Show("Поле не заполнено");
                }
            }
            else
            {
                MessageBox.Show("Поле не выбрано");
            }
        }


        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (DgCafeShops.SelectedItem != null)
            {
                context.CafeShops.Remove(DgCafeShops.SelectedItem as CafeShops);
                context.SaveChanges();
                DgCafeShops.ItemsSource = context.CafeShops.ToList();
            }
            else MessageBox.Show("Поле не выбрано");
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string json = File.ReadAllText(openFileDialog.FileName);
                    List<SerRoles> cafe = JsonConvert.DeserializeObject<List<SerRoles>>(json);
                    foreach (var item in cafe)
                    {
                        CafeShops u = new CafeShops();
                        u.Address_ = item.ser_Roles__.ToString();
                        context.CafeShops.Add(u);
                    }
                    context.SaveChanges();
                    DgCafeShops.ItemsSource = context.CafeShops.ToList();
                    Console.WriteLine("Data imported successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error importing data: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Неверный формат файла или файл не выбран.");
            }
        }

        private bool ContainsEmojis(string input)
        {
            Regex rgx = new Regex(@"\p{Cs}");
            Regex rgx2 = new Regex(@"\d|^[a-zA-Zа-яА-Я]*$");
            return rgx.IsMatch(input) || !rgx2.IsMatch(input);

            if (rgx.IsMatch(input))
            {
                return true;
            }
            return false;
        }
    }
}
