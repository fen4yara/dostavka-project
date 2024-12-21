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
    /// Логика взаимодействия для review.xaml
    /// </summary>
    public partial class review : Page
    {
        private Orders selectedOrder;
        private string _name;
        public review(string name)
        {
            InitializeComponent();
            OrdersGrid.ItemsSource = ConnectionClass.connect.Orders
                .Where(o => o.Status == "Доставлен")
                .Select(o => new
                {
                    o.ID_Order,
                    o.Delivery_time,
                    o.Total_price
                }).ToList();
            _name = name;
        }
        private void OrdersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedOrderr = OrdersGrid.SelectedItem as Orders;

        }
        private void SubmitReview_Click(object sender, RoutedEventArgs e)
        {
            var selectedOrderr = OrdersGrid.SelectedItem as Orders;

            
            if (!int.TryParse(RatingInput.Text, out int rating) || rating < 1 || rating > 5)
            {
                MessageBox.Show("Оценка должна быть числом от 1 до 5.");
                return;
            }

            if (string.IsNullOrEmpty(CommentInput.Text))
            {
                MessageBox.Show("Комментарий не может быть пустым.");
                return;
            }


            Reviews newReview = new Reviews
            {
                ID_Order = 1,
                Rating = rating,
                Comment = CommentInput.Text,
                Created_Review = DateTime.Now
            };

            try
            {
                ConnectionClass.connect.Reviews.Add(newReview);
                ConnectionClass.connect.SaveChanges();

                Message.Text = "Отзыв успешно добавлен.";
                Message.Visibility = Visibility.Visible;

                RatingInput.Text = string.Empty;
                CommentInput.Text = string.Empty;
                NavigationService.Navigate(new MenuClient(_name));

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении отзыва: {ex.Message}");
            }
        }


    }
}
