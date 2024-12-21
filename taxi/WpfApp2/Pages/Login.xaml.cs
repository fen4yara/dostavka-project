using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                ErrorMessage.Text = "Введите пароль и имя";
                ErrorMessage.Visibility = Visibility.Visible;
                return;
            }

            var user = ConnectionClass.connect.Users.FirstOrDefault(u => u.username == username && u.password_hash == password);
            if (user != null)
            {
                if (user.role == "user") { 
                    MessageBox.Show("Вы вошли в аккаунт как пользователь");
                    NavigationService.Navigate(new Menu (user.user_id));
                }
                if (user.role == "voditel")
                {
                    MessageBox.Show("Вы вошли в аккаунт как курьер");
                    NavigationService.Navigate(new MenuDriver());
                }
            }
            else
            {
                ErrorMessage.Text = "Проверьте введенные данные";
                ErrorMessage.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Register());
            
        }
    }
}
