using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для ReceiptPage.xaml
    /// </summary>
    public partial class ReceiptPage : Page
    {
        public CAFEEntities context = new CAFEEntities();
        public ReceiptPage()
        {
            InitializeComponent();
            comOrd.ItemsSource = context.Sellings.ToList();
            comOrd.DisplayMemberPath = "SellingID";
        }
        private void comOrd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comOrd.SelectedItem != null)
            {
                var Selling = (comOrd.SelectedItem as Sellings);
                DATA.ItemsSource = context.SellingDetails.Where(x => x.IDSelling == Selling.SellingID).ToList();
            }
        }
    }
}
