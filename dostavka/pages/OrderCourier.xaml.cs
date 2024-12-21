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
    /// Логика взаимодействия для OrderCourier.xaml
    /// </summary>
    public partial class OrderCourier : Page
    {
        private string _name;
        public OrderCourier(string name)
        {
            InitializeComponent();
            var orders = ConnectionClass.connect.Orders.Where(o => o.Status == "Обработка").ToList();
            OrdersGrid.ItemsSource = orders;
            _name = name;
        }

        private void LoadOrders()
        {
            var orders = ConnectionClass.connect.Orders.Where(o => o.Status == "Обработка").ToList();
            OrdersGrid.ItemsSource = orders;
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


                    LoadOrders();
                }

            }


        }

        private void Zakaz_Click(object sender, RoutedEventArgs e)
        {
            var selectedOrder = OrdersGrid.SelectedItem as Orders;
            if (selectedOrder != null)
            {

                if (selectedOrder.ID_Order > 0)
                {
                    NavigationService.Navigate(new Marshrut(selectedOrder.ID_Order));
                }
                else
                {
                    MessageBox.Show("Некорректный ID заказа.");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заказ.");
            }
        }
    }
}
