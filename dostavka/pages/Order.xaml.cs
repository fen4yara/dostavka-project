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
using static dostavka.pages.Catalog;

namespace dostavka.pages
{
    /// <summary>
    /// Логика взаимодействия для Order.xaml
    /// </summary>
    public partial class Order : Page
    {
        public Order()
        {
            InitializeComponent();
            LoadOrders();
        }
        private void LoadOrders()
        {
            // Загрузка заказов из базы данных
            var orders = ConnectionClass.connect.Orders.ToList();
            OrdersGrid.ItemsSource = orders;
        }
        private void PlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            if (PaymentMethod.SelectedItem == null)
            {
                MessageBox.Show("Выберите способ оплаты.");
                return;
            }

            string paymentMethod = (PaymentMethod.SelectedItem as ComboBoxItem)?.Content.ToString();
            var cartItems = Cart.Instance.Items;

            if (!cartItems.Any())
            {
                MessageBox.Show("Корзина пуста. Добавьте товары перед оформлением заказа.");
                return;
            }

            
            Orders newOrder = new Orders
            {
                Created_order = DateTime.Now,
                Total_price = cartItems.Sum(p => p.Price),
                Status = "Обработка",
                ID_Driver = 3,
                Delivery_time = DateTime.Now.AddHours(1), 
                Payment_method = "Банковская карта",
                Delivery_address = "Бари Галеева 3"
            };

            ConnectionClass.connect.Orders.Add(newOrder);
            ConnectionClass.connect.SaveChanges();

            MessageBox.Show("Заказ успешно оформлен.");
            foreach (var product in Cart.Instance.Items)
            {
                var orderItem = new Order_Items
                {
                    ID_Order = newOrder.ID_Order,
                    ID_Product = product.ID_Product,
                    Quantity_product = 1, 
                    Price = product.Price
                };

                ConnectionClass.connect.Order_Items.Add(orderItem);
            }

            ConnectionClass.connect.SaveChanges();
            MessageBox.Show("Заказ успешно оформлен!");
            Cart.Instance.Items.Clear();
            LoadOrders();
        }

        private void OrdersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedOrder = OrdersGrid.SelectedItem as Orders;
            if (selectedOrder != null)
            {
                if (selectedOrder.Status == "Обработка")
                {

                    var newTime = DateTime.Now.AddHours(2); 
                    selectedOrder.Delivery_time = newTime;
                    ConnectionClass.connect.SaveChanges();

                    MessageBox.Show($"Время доставки изменено на {newTime}");
                    LoadOrders();
                }
                else
                {
                    MessageBox.Show("Вы не можете редактировать заказ, который уже отправлен.");
                }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
