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

namespace Cafe
{
    /// <summary>
    /// Логика взаимодействия для PositionsPage.xaml
    /// </summary>
    public partial class PositionsPage : Page
    {
        public CAFEEntities context = new CAFEEntities();
        public PositionsPage()
        {
            InitializeComponent();
            DgPositions.ItemsSource = context.Positions.ToList();
        }

        private void DgPositions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgPositions.SelectedItem != null)
            {
                var selected = DgPositions.SelectedItem as Positions;
                TbPosition.Text = selected.Position;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (TbPosition.Text != "")
            {
                if (!ContainsEmojis(TbPosition.Text))
                {
                    Positions positions = new Positions();
                    positions.Position = TbPosition.Text;

                    context.Positions.Add(positions);
                    context.SaveChanges();
                    DgPositions.ItemsSource = context.Positions.ToList();
                }
                else MessageBox.Show("Поле не должно содержать смайлики");
            }
            else MessageBox.Show("Поле не заполнено");
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (DgPositions.SelectedItem != null)
            {
                if (TbPosition.Text != "")
                {
                    if (!ContainsEmojis(TbPosition.Text))
                    {
                        var selected = DgPositions.SelectedItem as Positions;
                        selected.Position = TbPosition.Text;

                        context.SaveChanges();
                        DgPositions.ItemsSource = context.Positions.ToList();
                    }
                    else MessageBox.Show("Поле не должно содержать смайлики");
                }
                else MessageBox.Show("Поле не заполнено");
            }
            else MessageBox.Show("Поле не выбрано");
        }


        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (DgPositions.SelectedItem != null)
            {
                context.Positions.Remove(DgPositions.SelectedItem as Positions);
                context.SaveChanges();
                DgPositions.ItemsSource = context.Positions.ToList();
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
                    List<SerCafe> cafe = JsonConvert.DeserializeObject<List<SerCafe>>(json);
                    foreach (var item in cafe)
                    {
                        Positions u = new Positions();
                        u.Position = item.cafe_name__.ToString();
                        context.Positions.Add(u);
                    }
                    context.SaveChanges();
                    DgPositions.ItemsSource = context.Positions.ToList();
                }
                catch
                {
                    MessageBox.Show("Неверный формат файла.");
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
        }
    }
}
