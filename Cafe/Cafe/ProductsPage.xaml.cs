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
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        public CAFEEntities context = new CAFEEntities();
        public ProductsPage()
        {
            InitializeComponent();
            DgProducts.ItemsSource = context.Products.ToList();
            CbIDProductType.ItemsSource = context.ProductTypes.ToList();
        }


        private void DgProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DgProducts.SelectedItem != null)
            {
                var selected = DgProducts.SelectedItem as Products;
                TbCount.Text = selected.Count_.ToString();
                TbPrice.Text = selected.Price.ToString();
                CbIDProductType.Text = selected.ProductTypes.ProductTypeID.ToString();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int value;
            decimal value1;
            if (TbCount.Text != "" && TbPrice.Text != "" && CbIDProductType.SelectedItem != null)
            {
                if (int.TryParse(TbCount.Text, out value) || decimal.TryParse(TbPrice.Text, out value1))
                {
                    if (!ContainsEmojis(TbCount.Text) && !ContainsEmojis(TbPrice.Text))
                    {
                        Products products = new Products();
                        products.Count_ = Convert.ToInt32(TbCount.Text);
                        products.Price = Convert.ToDecimal(TbPrice.Text);
                        products.IDProductType = (CbIDProductType.SelectedItem as ProductTypes).ProductTypeID;

                        context.Products.Add(products);

                        context.SaveChanges();
                        DgProducts.ItemsSource = context.Products.ToList();
                    }
                    else MessageBox.Show("Поля не должны содержать смайлики или символы");
                }
                else MessageBox.Show("Неправильный формат ввода");
            }
            else MessageBox.Show("Поля не заполнены");
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            int value;
            decimal value1;
            if (DgProducts.SelectedItem != null)
            {
                if (TbCount.Text != "" && TbPrice.Text != "" && CbIDProductType.SelectedItem != null)
                {
                    if (int.TryParse(TbCount.Text, out value) || decimal.TryParse(TbPrice.Text, out value1))
                    {
                        if (!ContainsEmojis(TbCount.Text) && !ContainsEmojis(TbPrice.Text))
                        {
                            var selected = DgProducts.SelectedItem as Products;

                            selected.Count_ = Convert.ToInt32(TbCount.Text);
                            selected.Price = Convert.ToDecimal(TbPrice.Text);
                            selected.IDProductType = (CbIDProductType.SelectedItem as ProductTypes).ProductTypeID;

                            context.SaveChanges();
                            DgProducts.ItemsSource = context.Products.ToList();
                        }
                        else MessageBox.Show("Поля не должны содержать смайлики или символы");
                    }
                    else MessageBox.Show("Неправильный формат ввода");
                }
                else MessageBox.Show("Поля не заполнены");
            }
            else MessageBox.Show("Поля не выбраны");
        }


        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(DgProducts.SelectedItem != null)
            {
                context.Products.Remove(DgProducts.SelectedItem as Products);

                context.SaveChanges();
                DgProducts.ItemsSource = context.Products.ToList();
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
