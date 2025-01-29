using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace LogistTr
{
    /// <summary>
    /// Логика взаимодействия для VehiclesPage.xaml
    /// </summary>
    public partial class VehiclesPage : Page
    {
        public VehiclesPage()
        {
            InitializeComponent();
            LoadVehicles();
            LoadStatuses();
        }

        /// <summary>
        /// Загрузка данных о транспорте в DataGrid
        /// </summary>
        private void LoadVehicles(string searchQuery = "")
        {
            using (var context = new LOGTRANCEEntities())
            {
                // Подгружаем данные о транспорте и применяем фильтр поиска
                var vehicles = context.Vehicles
                    .Where(v => v.PlateNumber.Contains(searchQuery) || v.Driver.Contains(searchQuery))
                    .ToList();

                DGridVehicle.ItemsSource = vehicles;
            }
        }

        /// <summary>
        /// Загрузка статусов для ComboBox
        /// </summary>
        private void LoadStatuses()
        {
            using (var context = new LOGTRANCEEntities())
            {
                var statuses = context.Vehicles
                    .Select(v => v.Status_)
                    .Distinct()
                    .ToList();

                CbStatus.ItemsSource = statuses;
            }
        }

        /// <summary>
        /// Обновление данных в текстбоксах при выборе строки в DataGrid
        /// </summary>
        private void DGridVehicle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DGridVehicle.SelectedItem is Vehicles selectedVehicle)
            {
                TxtPlateNumber.Text = selectedVehicle.PlateNumber;
                TxtCapacityVolume.Text = selectedVehicle.CapacityVolume.ToString();
                TxtDriver.Text = selectedVehicle.Driver;
                CbStatus.Text = selectedVehicle.Status_;
            }
        }

        /// <summary>
        /// Обработчик для поиска
        /// </summary>
        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadVehicles(TxtSearch.Text); // Обновляем DataGrid с учётом поискового запроса
        }

        /// <summary>
        /// Добавление нового транспорта
        /// </summary>
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var newVehicle = new Vehicles
            {
                PlateNumber = TxtPlateNumber.Text,
                CapacityVolume = decimal.Parse(TxtCapacityVolume.Text),
                Driver = TxtDriver.Text,
                Status_ = CbStatus.Text
            };

            using (var context = new LOGTRANCEEntities())
            {
                context.Vehicles.Add(newVehicle);
                context.SaveChanges();
            }

            LoadVehicles(); // Обновляем данные в DataGrid
        }

        /// <summary>
        /// Редактирование выделенного транспорта
        /// </summary>
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (DGridVehicle.SelectedItem is Vehicles selectedVehicle)
            {
                using (var context = new LOGTRANCEEntities())
                {
                    var vehicle = context.Vehicles.FirstOrDefault(v => v.VehicleId == selectedVehicle.VehicleId);
                    if (vehicle != null)
                    {
                        vehicle.PlateNumber = TxtPlateNumber.Text;
                        vehicle.CapacityVolume = decimal.Parse(TxtCapacityVolume.Text);
                        vehicle.Driver = TxtDriver.Text;
                        vehicle.Status_ = CbStatus.Text;

                        context.SaveChanges();
                    }
                }

                LoadVehicles(); // Обновляем данные в DataGrid
            }
        }

        /// <summary>
        /// Удаление выделенного транспорта
        /// </summary>
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (DGridVehicle.SelectedItem is Vehicles selectedVehicle)
            {
                using (var context = new LOGTRANCEEntities())
                {
                    var vehicle = context.Vehicles.FirstOrDefault(v => v.VehicleId == selectedVehicle.VehicleId);
                    if (vehicle != null)
                    {
                        context.Vehicles.Remove(vehicle);
                        context.SaveChanges();
                    }
                }

                LoadVehicles(); // Обновляем данные в DataGrid
            }
        }
    }
}
