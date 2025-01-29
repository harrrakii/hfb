using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace LogistTr
{
    public partial class ClientsPage : Page
    {
        public LOGTRANCEEntities context = new LOGTRANCEEntities();
        public ClientsPage()
        {
            InitializeComponent();
            DGridClients.ItemsSource = LOGTRANCEEntities.GetContext().Clients.ToList();

        }

        private void DGridClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DGridClients.SelectedItem != null)
            {
                var selected = DGridClients.SelectedItem as Clients;
                FIO.Text = selected.ContactPerson;
                Phone.Text = selected.Phone;
                Organization.Text = selected.CompanyName;
            }
        }

        // Добавление нового клиента
        private void AddBt_Click(object sender, RoutedEventArgs e)
        {
            var newClient = new Clients
            {
                ContactPerson = FIO.Text,
                Phone = Phone.Text,
                CompanyName = Organization.Text
            };

            LOGTRANCEEntities.GetContext().Clients.Add(newClient);
            LOGTRANCEEntities.GetContext().SaveChanges();

            DGridClients.ItemsSource = LOGTRANCEEntities.GetContext().Clients.ToList();

            FIO.Clear();
            Phone.Clear();
            Organization.Clear();

            MessageBox.Show("Клиент добавлен.");
        }

        // Редактирование выбранного клиента
        private void EditBt_Click(object sender, RoutedEventArgs e)
        {
            var selectedClient = DGridClients.SelectedItem as Clients;
            if (selectedClient != null)
            {
                selectedClient.ContactPerson = FIO.Text;
                selectedClient.Phone = Phone.Text;
                selectedClient.CompanyName = Organization.Text;

                LOGTRANCEEntities.GetContext().SaveChanges();

                DGridClients.ItemsSource = LOGTRANCEEntities.GetContext().Clients.ToList();

                MessageBox.Show("Данные клиента обновлены.");
            }
            else
            {
                MessageBox.Show("Выберите клиента для редактирования.");
            }
        }

        private void DeleteBt_Click(object sender, RoutedEventArgs e)
        {
            var selectedClient = DGridClients.SelectedItem as Clients;

            if (selectedClient != null)
            {
                try
                {
                    // Проверяем заказы клиента
                    var hasActiveOrders = context.Orders
                        .Any(o => o.ClientId == selectedClient.ClientId && o.Status_ != "Completed");

                    if (hasActiveOrders)
                    {
                        MessageBox.Show("Невозможно удалить клиента, так как у него есть активные заказы.");
                        return;
                    }

                    // Прикрепляем и удаляем клиента
                    context.Clients.Attach(selectedClient);
                    context.Clients.Remove(selectedClient);

                    // Сохраняем изменения
                    context.SaveChanges();

                    // Обновляем DataGrid
                    DGridClients.ItemsSource = context.Clients.ToList();
                    MessageBox.Show("Клиент успешно удалён.");
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show($"Ошибка базы данных: {ex.InnerException?.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Неизвестная ошибка: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Выберите клиента для удаления.");
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchBox.Text.ToLower();

            var filteredClients = context.Clients
                .Where(c => c.ContactPerson.ToLower().Contains(searchText) ||
                            c.Phone.ToLower().Contains(searchText) ||
                            c.CompanyName.ToLower().Contains(searchText))
                .ToList();

            DGridClients.ItemsSource = filteredClients;
        }
    }
}
