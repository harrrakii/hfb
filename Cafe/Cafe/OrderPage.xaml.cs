using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public CAFEEntities context = new CAFEEntities();
        Sellings sellings = new Sellings();
        SellingDetails sellingDetails = new SellingDetails();
        public OrderPage()
        {
            InitializeComponent();
            DgProducts.ItemsSource = context.Products.ToList();
            CbCustomer.ItemsSource = context.Customers.ToList();
            CbCafe.ItemsSource = context.CafeShops.ToList();

            sellingDetails.Amount = 0;
            context.SellingDetails.Add(sellingDetails);
            context.Sellings.Add(sellings);
            context.SaveChanges();

        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (CbCafe.SelectedItem != null && CbCustomer != null)
            {
                sellings.IDCustomer = (CbCustomer.SelectedItem as Customers).CustomerID;
                sellings.IDCoffeeShop = (CbCafe.SelectedItem as CafeShops).CafeID;
                context.SaveChanges();
                string receipt = $"FifthPractice\nКассовый чек #{sellings.SellingID}\n";
                var products = context.SellingDetails.Where(x => x.IDSelling == sellings.SellingID).ToList();
                foreach (var product in products)
                {
                    receipt += $"{product.Products.ProductTypes.ProductType} - {product.Amount}\n";
                }
                receipt += $"Итого к оплате: {sellings.TotalAmount}\n";
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\Заказ#{sellings.SellingID}.txt", receipt);
            }
            else MessageBox.Show("Не все поля заполнены");

        }

        private void ToCart(object sender, RoutedEventArgs e)
        {
            if(DgProducts.SelectedItem != null)
            {
                var product = DgProducts.SelectedItem as Products;
                if(product.Count_ >= 0)
                {
                    var saleAmount = context.Sales.Where(x => x.StartDate >= DateTime.Now && x.EndDate <= DateTime.Now).Max(x => x.Amount);
                    if (context.SellingDetails.Any(x => x.IDSelling == sellings.SellingID && x.IDProduct == product.ProductID))
                    {
                        var details = context.SellingDetails.Where(x => x.IDSelling == sellings.SellingID && x.IDProduct == product.ProductID).First();
                        details.Count_++;
                        if (saleAmount != null)
                        {
                            details.Amount = Convert.ToDecimal((product.Price - saleAmount) * details.Count_);
                        }
                        else
                        {
                            details.Amount = Convert.ToDecimal(product.Price * details.Count_);
                        }
                        context.SaveChanges();
                    }
                    else
                    {
                        SellingDetails details = new SellingDetails();
                        details.IDSelling = sellings.SellingID;
                        details.IDProduct = product.ProductID;
                        details.Count_ = 1;
                        if (saleAmount != null)
                        {
                            details.Amount = Convert.ToDecimal((product.Price - saleAmount) * details.Count_);
                        }
                        else
                        {
                            details.Amount = Convert.ToDecimal(product.Price * details.Count_);
                        }
                        context.SellingDetails.Add(details);
                        context.SaveChanges();
                    }
                    var customer = sellings.Customers;
                    var amount = context.SellingDetails.Where(x => x.IDSelling == sellings.SellingID).Sum(x => x.Amount);
                    sellings.TotalAmount = amount;
                    product.Count_--;
                    context.SaveChanges();
                    DgProducts.ItemsSource = context.Products.ToList();
                    DgSellingDetails.ItemsSource = context.SellingDetails.Where(x => x.IDSelling == sellings.SellingID).ToList();
                    ForPay.Text = $"К оплате: {amount}Р";
                }
            }
        }

        private void ToStock(object sender, RoutedEventArgs e)
        {
            var product = DgProducts.SelectedItem as Products;
            if (DgSellingDetails.SelectedItem != null)
            {
                var details = DgSellingDetails.SelectedItem as SellingDetails;
                var customer = sellings.Customers;
                if (details.Count_ == 1)
                {
                    details.Products.Count_++;
                    context.SellingDetails.Remove(details);
                }
                else
                {
                    var products = context.SellingDetails.Where(x => x.IDSelling == sellings.SellingID).ToList();
                    details.Count_--;
                    details.Amount -= details.Products.Price;
                    sellings.TotalAmount = details.Amount;
                }
                context.SaveChanges();
                DgProducts.ItemsSource = context.Products.ToList();
                DgSellingDetails.ItemsSource = context.SellingDetails.Where(x => x.IDSelling == sellings.SellingID).ToList();
                ForPay.Text = $"К оплате: {details.Amount}Р";
            }
        }

       

        private void Customer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CbCustomer.SelectedItem != null)
            {
                sellings.IDCustomer = (CbCustomer.SelectedItem as Customers).CustomerID;
                context.SaveChanges();
                TbCustomer.Text = (CbCustomer.SelectedItem as Customers).Surname.ToString();
            }
        }

        private void Cafe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CbCafe.SelectedItem != null)
            {
                sellings.IDCoffeeShop = (CbCafe.SelectedItem as CafeShops).CafeID;
                context.SaveChanges();
                TbCafe.Text = (CbCafe.SelectedItem as CafeShops).Address_.ToString();
            }

        }

    }
}
