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
    /// Логика взаимодействия для AddDriver.xaml
    /// </summary>
    public partial class AddDriver : Page
    {
        private int _id;
        public AddDriver(int id)
        {
            InitializeComponent();
            _id = id;
        }
        private void AddDriverButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Drivers newDriver = new Drivers
                {
                    first_name = FirstNameTextBox.Text,
                    last_name = LastNameTextBox.Text,
                    phone = PhoneTextBox.Text,
                    email = EmailTextBox.Text,
                    license_number = "123",
                    hire_date = DateTime.Now,
                    contract_status = "active"
                };

                ConnectionClass.connect.Drivers.Add(newDriver);
                ConnectionClass.connect.SaveChanges();
                MessageBox.Show("Курьер добавлен!");
                NavigationService.Navigate(new Driver(_id));

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
