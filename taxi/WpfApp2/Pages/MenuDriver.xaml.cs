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
using WpfApp2.DB;

namespace WpfApp2.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuDriver.xaml
    /// </summary>
    public partial class MenuDriver : Page
    {
        public MenuDriver()
        {
            InitializeComponent();
            LoadOrders();
        }
        private void LoadOrders()
        {
            OrdersDataGrid.ItemsSource = ConnectionClass.connect.Orders.ToList();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Принять заказ?", "Принять", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                var b = OrdersDataGrid.SelectedItem as Orders;
                if (b != null)
                {
                    ConnectionClass.connect.Orders.Remove(b);
                    ConnectionClass.connect.SaveChanges();
                    OrdersDataGrid.ItemsSource = ConnectionClass.connect.Orders.ToList();
                    MessageBox.Show($"Заказ номер {b.order_id} принят", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Для начала выберите заказ!!!");
                }
            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }

        
    }
}
