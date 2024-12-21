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
    /// Логика взаимодействия для Catalog.xaml
    /// </summary>
    public partial class Catalog : Page
    {
        private List<Products> AllProducts; 
        private List<Products> FilteredProducts;
        private string _name;
        public Catalog(string name)
        {
            InitializeComponent();
            _name = name;
            try
            {
                // Загрузка всех продуктов из базы данных
                AllProducts = ConnectionClass.connect.Products.ToList();
                FilteredProducts = AllProducts;

                // Отображение всех продуктов при запуске
                UpdateProductList(AllProducts);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
                AllProducts = new List<Products>();
                FilteredProducts = AllProducts;
            }
        }
        public class Cart
        {
            private static Cart _instance;
            public static Cart Instance => _instance ?? (_instance = new Cart());

            public List<Products> Items { get; private set; }

            private Cart()
            {
                Items = new List<Products>();
            }

            public void AddToCart(Products product)
            {
                Items.Add(product);
            }
        }

        private void UpdateProductList(IEnumerable<Products> products)
        {
            ProductList.ItemsSource = null; // Сбрасываем источник данных
            ProductList.ItemsSource = products; // Устанавливаем новый источник данных
        }

        private void CategoryFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AllProducts == null || !AllProducts.Any())
            {
                
                return;
            }

            var selectedCategory = (CategoryFilter.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (selectedCategory == "Все категории")
                FilteredProducts = AllProducts.ToList(); // Сброс фильтра
            else
                FilteredProducts = AllProducts.Where(p => p.Category == selectedCategory).ToList();

            // Применяем текущую сортировку после фильтрации
            ApplySorting();
            UpdateProductList(FilteredProducts);
        }

        private void SortFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FilteredProducts == null || !FilteredProducts.Any()) return;

            ApplySorting();
            UpdateProductList(FilteredProducts);
        }

        private void ApplySorting()
        {
            var selectedSort = (SortFilter.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (selectedSort == "По цене (возрастание)")
                FilteredProducts = FilteredProducts.OrderBy(p => p.Price).ToList();
            else if (selectedSort == "По цене (убывание)")
                FilteredProducts = FilteredProducts.OrderByDescending(p => p.Price).ToList();
        }


        private void ProductList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedProduct = ProductList.SelectedItem as Products;
            if (selectedProduct != null)
            {
                MessageBox.Show($"Название: {selectedProduct.Name}\nКатегория: {selectedProduct.Category}\nОписание: {selectedProduct.Description}\nЦена: {selectedProduct.Price}");
            }
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = ProductList.SelectedItem as Products;
            if (selectedProduct != null)
            {

                Cart.Instance.AddToCart(selectedProduct);
                MessageBox.Show($"Товар {selectedProduct.Name} добавлен в корзину.");
            }
            else
            {
                MessageBox.Show("Выберите товар для добавления.");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
