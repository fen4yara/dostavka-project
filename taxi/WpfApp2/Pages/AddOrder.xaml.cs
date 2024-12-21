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
    /// Логика взаимодействия для AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Page
    {
        private int _id;
        public AddOrder(int id)
        {
            InitializeComponent();
            _id = id;
            var user = ConnectionClass.connect.Users.FirstOrDefault(u => u.user_id == _id);
            CustomerNameTextBox.Text = user.username;
        }

        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                Orders newOrder = new Orders
                {
                    customer_name = CustomerNameTextBox.Text,
                    customer_phone = CustomerPhoneTextBox.Text,
                    pickup_location = PickupLocationTextBox.Text,
                    dropoff_location = DropoffLocationTextBox.Text,
                    order_date = DateTime.Now,
                };

                ConnectionClass.connect.Orders.Add(newOrder);
                ConnectionClass.connect.SaveChanges();
                MessageBox.Show("Заказ добавлен");
                NavigationService.Navigate(new Order(_id));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


    }
}
