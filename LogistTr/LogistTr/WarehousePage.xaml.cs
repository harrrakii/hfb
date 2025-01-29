using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

namespace LogistTr
{
    public partial class WarehousePage : Page
    {
        private readonly LOGTRANCEEntities _context; // Контекст базы данных
        private List<string> _warehouseStatuses; // Статусы склада

        public WarehousePage()
        {
            InitializeComponent();
            _context = LOGTRANCEEntities.GetContext(); // Создание контекста

            LoadWarehouseData();
            LoadWarehouseStatusData();
            // Подписываемся на событие Unloaded для освобождения ресурсов
            this.Unloaded += WarehousePage_Unloaded;
        }

        // Метод для загрузки данных о складе из базы данных
        private void LoadWarehouseData()
        {
            var warehouseData = from order in _context.Orders
                                join cargo in _context.Cargo on order.CargoId equals cargo.CargoId
                                join warehouse in _context.Warehouse on cargo.WarehouseId equals warehouse.WarehouseId
                                select new WarehouseDTO
                                {
                                    OrderNumber = order.OrderNumber,
                                    CargoDescription = cargo.CargoDescription,
                                    Weight = cargo.Weight_,
                                    WarehouseStatus = warehouse.Status_,
                                    WarehouseId = warehouse.WarehouseId,
                                    OrderId = order.OrderId
                                };

            DGridClients.ItemsSource = warehouseData.ToList(); // Загрузка данных в DataGrid
        }

        // Метод для загрузки статусов склада
        private void LoadWarehouseStatusData()
        {
            // Загружаем статусы склада из базы данных
            _warehouseStatuses = _context.Warehouse.Select(w => w.Status_).Distinct().ToList();
        }


        // Обработчик события Unloaded для освобождения ресурсов
        private void WarehousePage_Unloaded(object sender, RoutedEventArgs e)
        {
            _context?.Dispose(); // Освобождение ресурсов
        }

    }
}
