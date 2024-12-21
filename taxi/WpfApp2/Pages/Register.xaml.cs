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
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                ErrorMessage.Text = "Необходимо заполнить все поля";
                ErrorMessage.Visibility = Visibility.Visible;
                return;
            }

            if (password != confirmPassword)
            {
                ErrorMessage.Text = "Пароли не совпадают";
                ErrorMessage.Visibility = Visibility.Visible;
                return;
            }

            
                var existingUser = ConnectionClass.connect.Users.FirstOrDefault(u => u.username == username);
                if (existingUser != null)
                {
                    ErrorMessage.Text = "Имя уже существует";
                    ErrorMessage.Visibility = Visibility.Visible;
                    return;
                }

            
                Users newUser = new Users
                {
                    username = username,
                    password_hash = password, 
                    role = "user" 
                };

                ConnectionClass.connect.Users.Add(newUser);
                ConnectionClass.connect.SaveChanges();

                MessageBox.Show("Регистрация пройденга");

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                ErrorMessage.Text = "Необходимо заполнить все поля";
                ErrorMessage.Visibility = Visibility.Visible;
                return;
            }

            if (password != confirmPassword)
            {
                ErrorMessage.Text = "Пароли не совпадают";
                ErrorMessage.Visibility = Visibility.Visible;
                return;
            }


            var existingUser = ConnectionClass.connect.Users.FirstOrDefault(u => u.username == username);
            if (existingUser != null)
            {
                ErrorMessage.Text = "Имя уже существует";
                ErrorMessage.Visibility = Visibility.Visible;
                return;
            }


            Users newUser = new Users
            {
                username = username,
                password_hash = password,
                role = "voditel"
            };
            Drivers newDriver = new Drivers
            {
                first_name = username,
                last_name = "nu",
                phone = "+79991231221",
                email = "adfasd@gmail.com",
            };

            ConnectionClass.connect.Users.Add(newUser);
            ConnectionClass.connect.Drivers.Add(newDriver);
            ConnectionClass.connect.SaveChanges();

            MessageBox.Show("Регистрация пройденга");
        }
    } 
}
