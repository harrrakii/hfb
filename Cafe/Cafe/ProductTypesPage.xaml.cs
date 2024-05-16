using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для ProductTypesPage.xaml
    /// </summary>
    public partial class ProductTypesPage : Page
    {
        public CAFEEntities context = new CAFEEntities();
        public ProductTypesPage()
        {
            InitializeComponent();
            DgProductTypes.ItemsSource = context.ProductTypes.ToList();
        }

        private void DgProductTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgProductTypes.SelectedItem != null)
            {
                var selected = DgProductTypes.SelectedItem as ProductTypes;
                TbProductType.Text = selected.ProductType;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (TbProductType.Text != "")
            {
                if (!ContainsEmojis(TbProductType.Text))
                {
                    ProductTypes productTypes = new ProductTypes();
                    productTypes.ProductType = TbProductType.Text;

                    context.ProductTypes.Add(productTypes);
                    context.SaveChanges();
                    DgProductTypes.ItemsSource = context.ProductTypes.ToList();
                }
                else MessageBox.Show("Поле не должно содержать смайлики или символы");
            }
            else MessageBox.Show("Поле не заполнено");
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (DgProductTypes.SelectedItem != null)
            {
                if (TbProductType.Text != "")
                {
                    if (!ContainsEmojis(TbProductType.Text))
                    {
                        var selected = DgProductTypes.SelectedItem as ProductTypes;
                        selected.ProductType = TbProductType.Text;

                        context.SaveChanges();
                        DgProductTypes.ItemsSource = context.ProductTypes.ToList();
                    }
                    else MessageBox.Show("Поле не должно содержать смайлики или символы");
                }
                else MessageBox.Show("Поле не заполнено");
            }
            else MessageBox.Show("Поле не выбрано");
        }


        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (DgProductTypes.SelectedItem != null)
            {
                context.ProductTypes.Remove(DgProductTypes.SelectedItem as ProductTypes);
                context.SaveChanges();
                DgProductTypes.ItemsSource = context.ProductTypes.ToList();
            }
            else MessageBox.Show("Поле не выбрано");
        }

        private bool ContainsEmojis(string input)
        {
            Regex rgx = new Regex(@"\p{Cs}");
            Regex rgx2 = new Regex(@"\d|^[a-zA-Zа-яА-Я]*$");
            return rgx.IsMatch(input) || !rgx2.IsMatch(input);

        }
    }
}
