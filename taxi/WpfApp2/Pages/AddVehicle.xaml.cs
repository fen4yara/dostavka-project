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
    /// Логика взаимодействия для AddVehicle.xaml
    /// </summary>
    public partial class AddVehicle : Page
    {
        private int _id;
        public AddVehicle(int id)
        {
            InitializeComponent();
            _id = id;
        }
        private void AddVehicleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Vehicles newVehicle = new Vehicles
                {
                    model = ModelTextBox.Text,
                    year = int.Parse(YearTextBox.Text),
                    mileage = int.Parse(MileageTextBox.Text),
                    status = "available",
                    last_service_date = DateTime.Now,
                    next_service_date = DateTime.Now.AddMonths(6)
                };

                ConnectionClass.connect.Vehicles.Add(newVehicle);
                ConnectionClass.connect.SaveChanges();
                MessageBox.Show("Товар добавлен!");
                NavigationService.Navigate(new Manage(_id));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
