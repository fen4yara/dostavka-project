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
    /// Логика взаимодействия для Driver.xaml
    /// </summary>
    public partial class Driver : Page
    {
        private int _id;
        public Driver(int id)
        {
            InitializeComponent();
            _id = id;
            LoadDrivers();
        }
        private void LoadDrivers()
        {
            DriversDataGrid.ItemsSource = ConnectionClass.connect.Drivers.ToList();
        }

        private void AddDriver_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddDriver(_id));
        }

        private void Back(object sender, RoutedEventArgs e)
        {
               NavigationService.Navigate(new Menu(_id));
        }
    }
}
