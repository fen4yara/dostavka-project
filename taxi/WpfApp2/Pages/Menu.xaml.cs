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

namespace WpfApp2.Pages
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        private int _id;
        public Menu(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private void VehicleManagement_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Manage(_id));
        }

        private void DriverManagement_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Driver(_id));
        }

        private void OrderManagement_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Order(_id));
        }

        private void FeedbackManagement_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Feedback());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }
    }
}
