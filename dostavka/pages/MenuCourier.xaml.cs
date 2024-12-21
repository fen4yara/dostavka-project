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
    /// Логика взаимодействия для MenuCourier.xaml
    /// </summary>
    public partial class MenuCourier : Page
    {
        private string _name;
        public MenuCourier(string name)
        {
            InitializeComponent();
            _name = name;
        }

        private void profile(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrderCourier(_name));
        }
        private void profile1(object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(new Profile(_name));
        }
    }
}
