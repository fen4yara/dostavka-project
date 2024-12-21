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
    /// Логика взаимодействия для Order.xaml
    /// </summary>
    public partial class Order : Page
    {
        private int _id;
        public Order(int id)
        {
            InitializeComponent();
            LoadOrders();
            _id = id;
        }
        private void LoadOrders()
        {
            
            OrdersDataGrid.ItemsSource = ConnectionClass.connect.Orders.ToList();
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddOrder(_id));
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Menu(_id));
        }
    }
}
