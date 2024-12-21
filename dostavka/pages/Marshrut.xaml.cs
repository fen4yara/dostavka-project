using dostavka.DB;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace dostavka.pages
{
    /// <summary>
    /// Логика взаимодействия для Marshrut.xaml
    /// </summary>
    public partial class Marshrut : Page
    {
        private Orders selectedOrder;
        private int _id;
        public Marshrut(int id)
        {
            InitializeComponent();

            _id = id;
            LoadCourierOrders();
        }
        private void LoadCourierOrders()
        {
            // Загрузка заказов для курьера (например, со статусом "В пути")
            var courierOrders = ConnectionClass.connect.Orders
                .Where(o => o.ID_Order == _id)
                .Select(o => new
                {
                    o.ID_Order,
                    o.Delivery_address,
                    o.Delivery_time,
                    o.Status
                }).ToList();

            DeliveryOrdersGrid.ItemsSource = courierOrders;
        }
        private void DeliveryOrdersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedOrder = DeliveryOrdersGrid.SelectedItem as Orders;

        }

        private void MarkAsDelivered_Click(object sender, RoutedEventArgs e)
        {
            selectedOrder = ConnectionClass.connect.Orders.FirstOrDefault(o => o.ID_Order == _id);
            selectedOrder.Status = "Доставлен";
            


                    ConnectionClass.connect.SaveChanges();
                    MessageBox.Show($"Заказ {selectedOrder.ID_Order} отмечен как доставленный.");
                    LoadCourierOrders(); // Обновление списка заказов

        }

        private void PlanRoute_Click(object sender, RoutedEventArgs e)
        {
            // Симуляция планирования маршрута
            var addresses = ConnectionClass.connect.Orders
                .Where(o => o.Status == "В пути")
                .Select(o => o.Delivery_address)
                .ToList();

            if (addresses.Any())
            {
                string route = string.Join(" -> ", addresses);
                MessageBox.Show($"Маршрут построен: {route}");
            }
            else
            {
                MessageBox.Show("Нет доступных заказов для построения маршрута.");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
