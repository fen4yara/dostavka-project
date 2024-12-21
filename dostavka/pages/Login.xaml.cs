using dostavka.DB;
using dostavka.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace dostavka.pages
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        int code = new Random().Next(100000, 999999);
        private readonly TelegramService _telegramService;
        private CancellationTokenSource _cancellationTokenSource;
        public Login()
        {
            InitializeComponent();
            _telegramService = new TelegramService("7607352593:AAFhuj0-E7YzAkP9MHulawDPe997RKNnXX4");
            _cancellationTokenSource = new CancellationTokenSource();
            StartTelegramService();
        }
        private async void StartTelegramService()
        {
            try
            {
                await _telegramService.StartAsync(_cancellationTokenSource.Token);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка запуска Telegram бота: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string usernameOrEmail = UsernameOrEmailTextBox.Text;
            string password = PasswordBox.Password;
            var user = ConnectionClass.connect.Users.FirstOrDefault(u => u.Name == usernameOrEmail || u.Email == usernameOrEmail);


            if (user != null && VerifyPassword(user, password))
            {

                if (user.Phone == null)
                {
                    MessageBox.Show("TelegramChatID не установлен. Пожалуйста, свяжитесь с администратором.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {

                }
                if (fac.Text == code.ToString())
                {
                    if(user.Role == "Courier") {
                        MessageBox.Show("Успешный вход! Курьер");
                        NavigationService.Navigate(new MenuCourier(user.Name));
                    }
                    else if (user.Role == "Client")
                    {
                        MessageBox.Show("Успешный вход! Клиент");
                        NavigationService.Navigate(new MenuClient(user.Name));
                    }

                }
                else
                {
                    MessageBox.Show("Неверный код 2FA!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Неверные данные для входа.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Send2FACodeToTelegram(long chatId, int code)
        {
            Task.Run(async () =>
            {
                try
                {
                    await _telegramService.SendTextMessageAsync(chatId, $"Ваш код для входа: {code}");
                }
                catch (Exception ex)
                {
                    Dispatcher.Invoke(() =>
                    {
                        MessageBox.Show($"Ошибка при отправке кода 2FA: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    });
                }
            });
        }
        private bool VerifyPassword(DB.Users user, string password)
        {
            return user.Password_hash == HashPassword(password);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Reg());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string usernameOrEmail = UsernameOrEmailTextBox.Text;
            string password = PasswordBox.Password;
            var user = ConnectionClass.connect.Users.FirstOrDefault(u => u.Name == usernameOrEmail || u.Email == usernameOrEmail);
            if (user.Password_hash == HashPassword(password))
            {
                Send2FACodeToTelegram(user.Phone.Value, code);
            }
            else
            {
                MessageBox.Show("Проверьте порол!");
            }
        }

        private void asd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Analytics());
        }
    }
}
