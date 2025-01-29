using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace LogistTr
{
    public partial class RoutesPage : Page
    {
        private readonly string _role;
        private readonly LOGTRANCEEntities _context; // Контекст базы данных
        private List<string> _deliveryStatuses; // Статусы доставки
        private List<string> _vehicleStatuses; // Статусы состояния автомобиля

        public RoutesPage(string role)
        {
            InitializeComponent();
            _role = role;
            _context = LOGTRANCEEntities.GetContext(); // Создание контекста

            ConfigureAccessByRole();
            LoadRoutes();
            LoadStatusData();
            // Подписываемся на событие Unloaded для освобождения ресурсов
            this.Unloaded += RoutesPage_Unloaded;
        }

        // Метод для загрузки маршрутов из базы данных
        private void LoadRoutes()
        {
            var routesData = from r in _context.Routes_
                             join v in _context.Vehicles on r.VehicleId equals v.VehicleId
                             join o in _context.Orders on r.RouteId equals o.RouteId
                             select new RouteDto
                             {
                                 OrderNumber = o.OrderNumber,
                                 EndPoint_ = r.EndPoint_,
                                 Distance = r.Distance,
                                 VehicleStatus = v.Status_,
                                 DeliveryStatus = o.Status_,
                                 VehicleId = v.VehicleId,
                                 RouteId = r.RouteId
                             };

            DGridVehicle.ItemsSource = routesData.ToList(); // Загрузка данных в DataGrid
        }

        private void LoadStatusData()
        {
            // Загружаем статусы доставки из базы данных (используем Status_ из таблицы Orders)
            _deliveryStatuses = _context.Orders.Select(o => o.Status_).Distinct().ToList();

            // Загружаем статусы состояния автомобиля из базы данных (используем Status_ из таблицы Vehicles)
            _vehicleStatuses = _context.Vehicles.Select(v => v.Status_).Distinct().ToList();

            // Привязываем статусы доставки к StatusComboBox
            StatusComboBox.ItemsSource = _deliveryStatuses;

            // Привязываем статусы состояния автомобиля к StatusCarComboBox
            StatusCarComboBox.ItemsSource = _vehicleStatuses;
        }

        // Настройка интерфейса в зависимости от роли пользователя
        private void ConfigureAccessByRole()
        {
            if (_role == "Driver")
            {
                // Для водителя скрываем кнопки и комбобоксы, не относящиеся к статусу доставки
                AddTransportButton.Visibility = Visibility.Visible;  // Кнопка для изменения статуса доставки
                StatusComboBox.Visibility = Visibility.Visible; // ComboBox для изменения статуса доставки

                EditButton.Visibility = Visibility.Collapsed; // Кнопка для изменения статуса авто
                DeleteButton.Visibility = Visibility.Collapsed; // Кнопка для отправки уведомления о ТО
                StatusCarComboBox.Visibility = Visibility.Collapsed; // ComboBox для изменения состояния автомобиля

                DGridVehicle.IsReadOnly = false; // Разрешаем редактирование только статуса доставки
            }
            else
            {
                // Для остальных ролей (например, администратор) предоставляем полный доступ
                AddTransportButton.Visibility = Visibility.Visible;
                EditButton.Visibility = Visibility.Visible;
                DeleteButton.Visibility = Visibility.Visible;

                StatusComboBox.Visibility = Visibility.Visible; // ComboBox для изменения статуса доставки
                StatusCarComboBox.Visibility = Visibility.Visible; // ComboBox для изменения состояния автомобиля

                DGridVehicle.IsReadOnly = true; // Полный доступ, но DataGrid остается только для чтения
            }
        }


        // Обработчик события Unloaded для освобождения ресурсов
        private void RoutesPage_Unloaded(object sender, RoutedEventArgs e)
        {
            _context?.Dispose(); // Освобождение ресурсов
        }

        private void DGridVehicle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DGridVehicle.SelectedItem is RouteDto selectedRoute)
            {
                // Передаем в ComboBox данные из выбранной строки
                StatusComboBox.SelectedItem = selectedRoute.DeliveryStatus;
                StatusCarComboBox.SelectedItem = selectedRoute.VehicleStatus;
            }
        }


        // Обработчик кнопки для изменения статуса доставки
        private void AddTransportButton_Click(object sender, RoutedEventArgs e)
        {
            if (DGridVehicle.SelectedItem is RouteDto selectedRoute)
            {
                // Находим заказ по номеру
                var order = _context.Orders.FirstOrDefault(o => o.OrderNumber == selectedRoute.OrderNumber);

                if (order != null)
                {
                    // Обновляем статус доставки
                    order.Status_ = (string)StatusComboBox.SelectedItem;

                    // Сохраняем изменения в базе данных
                    _context.SaveChanges();
                    LoadRoutes(); // Перезагружаем данные в DataGrid
                }
            }
        }

        // Обработчик кнопки для изменения статуса авто
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (DGridVehicle.SelectedItem is RouteDto selectedRoute)
            {
                // Находим транспортное средство по ID
                var vehicle = _context.Vehicles.FirstOrDefault(v => v.VehicleId == selectedRoute.VehicleId);

                if (vehicle != null)
                {
                    // Обновляем статус состояния автомобиля
                    vehicle.Status_ = (string)StatusCarComboBox.SelectedItem;

                    // Сохраняем изменения в базе данных
                    _context.SaveChanges();
                    LoadRoutes(); // Перезагружаем данные в DataGrid
                }
            }
        }

        // Обработчик кнопки для отправки уведомления о ТО
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Реализация отправки уведомления о ТО
            MessageBox.Show("Уведомление о ТО отправлено!");
        }
    }
}
