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
    /// Логика взаимодействия для MenuClient.xaml
    /// </summary>
    public partial class MenuClient : Page
    {
        private string _name;
        public MenuClient(string name)
        {
            InitializeComponent();
            _name = name;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Catalog("qe"));
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Order());
        }

        private void profile(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Profile(_name));
        }

        private void review(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new review(_name));
        }

        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }
    }
}
