using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для Manage.xaml
    /// </summary>
    public partial class Manage : Page
    {
        private int _id;
        public Manage(int id)
        {
            InitializeComponent();
            _id = id;
            LoadVehicles();
        }
        private void LoadVehicles()
        {
            VehiclesDataGrid.ItemsSource = ConnectionClass.connect.Vehicles.ToList();
        }

        private void AddVehicle_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddVehicle(_id));
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Menu(_id));
        }
    }
}
