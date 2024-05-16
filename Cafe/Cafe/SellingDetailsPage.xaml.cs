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
using System.Xml.Linq;

namespace Cafe
{
    /// <summary>
    /// Логика взаимодействия для SellingDetailsPage.xaml
    /// </summary>
    public partial class SellingDetailsPage : Page
    {
        public CAFEEntities context = new CAFEEntities();
        public SellingDetailsPage()
        {
            InitializeComponent();
            DgSellingDetails.ItemsSource = context.SellingDetails.ToList();
            CbProductID.ItemsSource = context.ProductTypes.ToList();
            CbSellingID.ItemsSource = context.Sellings.ToList();
        }

        private void DgSellingDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgSellingDetails.SelectedItem != null)
            {
                var selected = DgSellingDetails.SelectedItem as SellingDetails;
                TbAmount.Text = selected.Amount.ToString();
                TbCount.Text = selected.Count_.ToString();
                CbProductID.Text = selected.Products.ProductID.ToString();
                CbSellingID.Text = selected.Sellings.SellingID.ToString();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (TbCount.Text != "" && TbAmount.Text != "" && CbSellingID.SelectedItem != null && CbProductID.SelectedItem != null)
            {
                if (decimal.TryParse(TbCount.Text, out decimal count) && decimal.TryParse(TbAmount.Text, out decimal amount))
                {
                    if (count > 0 && amount > 0)
                    {
                        SellingDetails sellingDetails = new SellingDetails();
                        sellingDetails.Amount = amount;
                        sellingDetails.Count_ = (int)count;
                        sellingDetails.IDProduct = (CbProductID.SelectedItem as Products).ProductID;
                        sellingDetails.IDSelling = (CbSellingID.SelectedItem as Sellings).SellingID;

                        context.SellingDetails.Add(sellingDetails);

                        context.SaveChanges();
                        DgSellingDetails.ItemsSource = context.SellingDetails.ToList();
                    }
                    else MessageBox.Show("Поля должны быть положительными числами.");
                }
                else MessageBox.Show("Поля должны содержать только числа.");
            }
            else MessageBox.Show("Поля не заполнены");
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (DgSellingDetails.SelectedItem != null)
            {
                if (TbCount.Text != "" && TbAmount.Text != "" && CbSellingID.SelectedItem != null && CbProductID.SelectedItem != null)
                {
                    if (decimal.TryParse(TbCount.Text, out decimal count) && decimal.TryParse(TbAmount.Text, out decimal amount))
                    {
                        if (count > 0 && amount > 0)
                        {
                            var selected = DgSellingDetails.SelectedItem as SellingDetails;

                            selected.Count_ = (int)count;
                            selected.Amount = amount;
                            selected.IDProduct = (CbProductID.SelectedItem as Products).ProductID;
                            selected.IDSelling = (CbSellingID.SelectedItem as Sellings).SellingID;

                            context.SaveChanges();
                            DgSellingDetails.ItemsSource = context.SellingDetails.ToList();
                        }
                        else MessageBox.Show("Поля должны быть положительными числами.");
                    }
                    else MessageBox.Show("Поля должны содержать только числа.");
                }
                else MessageBox.Show("Поля не заполнены");
            }
            else MessageBox.Show("Поля не выбраны");
        }

        private bool ContainsEmojis(string input)
        {
            Regex rgx = new Regex(@"\p{Cs}");
            Regex rgx2 = new Regex(@"\d|^[a-zA-Zа-яА-Я]*$");
            return rgx.IsMatch(input) || !rgx2.IsMatch(input);

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (DgSellingDetails.SelectedItem != null)
            {
                context.SellingDetails.Remove(DgSellingDetails.SelectedItem as SellingDetails);

                context.SaveChanges();
                DgSellingDetails.ItemsSource = context.SellingDetails.ToList();
            }
            else MessageBox.Show("Поля не выбраны");
        }
    }
}
