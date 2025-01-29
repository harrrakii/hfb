using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace LogistTr
{
    public partial class OrdersPage : Page
    {
        private readonly LOGTRANCEEntities _context; // Контекст базы данных

        public OrdersPage()
        {
            InitializeComponent();
            _context = LOGTRANCEEntities.GetContext(); // Создание контекста

            LoadOrders(); // Загружаем данные в DataGrid
        }

        // Метод для загрузки заказов из базы данных
        private void LoadOrders()
        {
            var ordersData = from o in _context.Orders
                             join c in _context.Clients on o.ClientId equals c.ClientId
                             join r in _context.Routes_ on o.RouteId equals r.RouteId
                             join v in _context.Vehicles on r.VehicleId equals v.VehicleId
                             select new
                             {
                                 OrderNumber = o.OrderNumber,   // Номер заказа
                                 CompanyName = c.CompanyName,   // Название компании
                                 Status = v.Status_             // Статус доставки
                             };

            DGridOrders.ItemsSource = ordersData.ToList(); // Загрузка данных в DataGrid
        }

        // Обработчик изменения выбора в DataGrid
        private void DGridOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DGridOrders.SelectedItem != null)
            {
                // Здесь можно обработать выбор строки, например, для отображения информации или для других операций
            }
        }

        // Обработчик кнопки для изменения статуса доставки
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        // Обработчик кнопки для удаления заказа
        private void DeleteOrderButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void CreateOrderButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateOrderButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
