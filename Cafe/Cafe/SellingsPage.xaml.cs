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
    /// Логика взаимодействия для SellingsPage.xaml
    /// </summary>
    public partial class SellingsPage : Page
    {
        public CAFEEntities context = new CAFEEntities();
        public SellingsPage()
        {
            InitializeComponent();
            DgSellings.ItemsSource = context.Sellings.ToList();
            CbCafeID.ItemsSource = context.CafeShops.ToList();
            CbCustomerID.ItemsSource = context.Customers.ToList();
            CbSaleID.ItemsSource = context.Sales.ToList();
        }

        private void DgSellings_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgSellings.SelectedItem != null)
            {
                var selected = DgSellings.SelectedItem as Sellings;
                TbTotalAmount.Text = selected.TotalAmount.ToString();
                TbSaleDate.Text = selected.SaleDate.ToString();
                CbCafeID.Text = selected.CafeShops.CafeID.ToString();
                CbCustomerID.Text = selected.Customers.CustomerID.ToString();
                CbSaleID.Text = selected.Sales.SaleID.ToString();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (TbTotalAmount.Text != "" && CbSaleID.SelectedItem != null && CbCustomerID.SelectedItem != null && CbCafeID.SelectedItem != null)
            {
                if (decimal.TryParse(TbTotalAmount.Text, out decimal totalAmount) && totalAmount >= 0)
                {
                    if (DateTime.TryParse(TbSaleDate.Text, out DateTime saleDate))
                    {
                        Sellings sellings = new Sellings();
                        sellings.TotalAmount = totalAmount;
                        sellings.SaleDate = saleDate;
                        sellings.IDCoffeeShop = (CbCafeID.SelectedItem as CafeShops).CafeID;
                        sellings.IDCustomer = (CbCustomerID.SelectedItem as Customers).CustomerID;
                        sellings.IDSale = (CbSaleID.SelectedItem as Sales).SaleID;

                        context.Sellings.Add(sellings);

                        context.SaveChanges();
                        DgSellings.ItemsSource = context.Sellings.ToList();
                    }
                    else
                    {
                        MessageBox.Show("Неверный формат даты.");
                    }
                }
                else
                {
                    MessageBox.Show("Поле 'Общая сумма' должно быть положительным числом.");
                }
            }
            else MessageBox.Show("Поля не заполнены");
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (DgSellings.SelectedItem != null)
            {
                if (TbTotalAmount.Text != "" && CbSaleID.SelectedItem != null && CbCustomerID.SelectedItem != null && CbCafeID.SelectedItem != null)
                {
                    if (decimal.TryParse(TbTotalAmount.Text, out decimal totalAmount) && totalAmount >= 0)
                    {
                        if (DateTime.TryParse(TbSaleDate.Text, out DateTime saleDate))
                        {
                            var selected = DgSellings.SelectedItem as Sellings;

                            selected.TotalAmount = totalAmount;
                            selected.SaleDate = saleDate;
                            selected.IDCustomer = (CbCustomerID.SelectedItem as Customers).CustomerID;
                            selected.IDSale = (CbSaleID.SelectedItem as Sales).SaleID;
                            selected.IDCoffeeShop = (CbCafeID.SelectedItem as CafeShops).CafeID;

                            context.SaveChanges();
                            DgSellings.ItemsSource = context.Sellings.ToList();
                        }
                        else
                        {
                            MessageBox.Show("Неверный формат даты.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Поле 'Общая сумма' должно быть положительным числом.");
                    }
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
            if (DgSellings.SelectedItem != null)
            {
                context.Sellings.Remove(DgSellings.SelectedItem as Sellings);

                context.SaveChanges();
                DgSellings.ItemsSource = context.Sellings.ToList();
            }
            else MessageBox.Show("Поля не выбраны");
        }
    }
}
