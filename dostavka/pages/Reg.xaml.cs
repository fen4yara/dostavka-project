using dostavka.DB;
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

namespace dostavka.pages
{
    /// <summary>
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Page
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void RegisterClient_Click(object sender, RoutedEventArgs e)
        {
            RegisterUser("Client");
        }

        private void RegisterCourier_Click(object sender, RoutedEventArgs e)
        {
            RegisterUser("Courier");
        }

        private void RegisterUser(string role)
        {
            string username = UsernameInput.Text;
            string password = PasswordInput.Password;
            string email = Telegram.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ErrorMessage.Text = "Все поля должны быть заполнены.";
                ErrorMessage.Visibility = Visibility.Visible;
                return;
            }
            
            
            var existingUser = ConnectionClass.connect.Users.FirstOrDefault(u => u.Name == username);
            if (existingUser != null)
            {
                ErrorMessage.Text = "Имя пользователя уже существует.";
                ErrorMessage.Visibility = Visibility.Visible;
                return;
            }

            
            string hashedPassword = HashPassword(password);

            
            Users newUser = new Users
            {
                Name = username,
                Password_hash = hashedPassword,
                Role = role,
                Email = email,
                Hire_date = DateTime.Now
            };

            
            ConnectionClass.connect.Users.Add(newUser);
            ConnectionClass.connect.SaveChanges();

            MessageBox.Show($"Регистрация прошла успешно. Вы зарегистрированы как {role}.");
            NavigationService.Navigate(new Login());
        }
        

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }
    }
}
