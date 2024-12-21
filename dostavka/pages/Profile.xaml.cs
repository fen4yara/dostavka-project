using dostavka.DB;
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
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        private string _name;
        private Users currentUser;
        public Profile(string name)
        {
            InitializeComponent();
            
            _name = name;
            currentUser = ConnectionClass.connect.Users.FirstOrDefault(u => u.Name == name);
            UsernameInput.Text = currentUser.Name;
            EmailInput.Text = currentUser.Email;
            RoleInput.Text = currentUser.Role;
        }


        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            if (currentUser == null)
            {
                MessageBox.Show("Пользователь не найден.");
                return;
            }

            if (string.IsNullOrEmpty(UsernameInput.Text) || string.IsNullOrEmpty(EmailInput.Text))
            {
                Message.Text = "Поля не могут быть пустыми.";
                Message.Visibility = Visibility.Visible;
                return;
            }

            currentUser.Name= UsernameInput.Text;
            currentUser.Email = EmailInput.Text;

            try
            {
                ConnectionClass.connect.SaveChanges();
                Message.Text = "Изменения успешно сохранены.";
                Message.Visibility = Visibility.Visible;
                NavigationService.Navigate(new MenuClient(_name));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
