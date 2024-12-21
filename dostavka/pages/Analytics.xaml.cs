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

using OxyPlot.Axes;
using OxyPlot.Wpf;
using OxyPlot;
using LiveCharts.Wpf;


namespace dostavka.pages
{
    /// <summary>
    /// Логика взаимодействия для Analytics.xaml
    /// </summary>
    public partial class Analytics : Page
    {
        public Analytics()
        {
            InitializeComponent();
        }
        private void GenerateSalesReport_Click(object sender, RoutedEventArgs e)
        {
            // Общий отчет о продажах
            var salesReport = ConnectionClass.connect.Order_Items
                .GroupBy(oi => 1)
                .Select(g => new
                {
                    TotalSales = g.Sum(oi => oi.Price * oi.Quantity_product),
                    TotalOrders = ConnectionClass.connect.Orders.Count(),
                    TotalProductsSold = g.Sum(oi => oi.Quantity_product)
                }).ToList();

            AnalyticsGrid.ItemsSource = salesReport;
        }

        private void GeneratePopularProductsReport_Click(object sender, RoutedEventArgs e)
        {
            // Популярные товары
            var popularProducts = ConnectionClass.connect.Order_Items
                .GroupBy(oi => oi.ID_Product)
                .Select(g => new
                {
                    ProductId = g.Key,
                    ProductName = ConnectionClass.connect.Products.FirstOrDefault(p => p.ID_Product == g.Key).Name,
                    QuantitySold = g.Sum(oi => oi.Quantity_product),
                    TotalRevenue = g.Sum(oi => oi.Price * oi.Quantity_product)
                })
                .OrderByDescending(p => p.QuantitySold)
                .Take(10)
                .ToList();

            AnalyticsGrid.ItemsSource = popularProducts;
        }

        private void GenerateSalesChart_Click(object sender, RoutedEventArgs e)
        {
            var popularProducts = ConnectionClass.connect.Order_Items
        .GroupBy(oi => oi.ID_Product)
        .Select(g => new
        {
            ProductName = ConnectionClass.connect.Products.FirstOrDefault(p => p.ID_Product == g.Key).Name,
            QuantitySold = g.Sum(oi => oi.Quantity_product)
        })
        .OrderByDescending(p => p.QuantitySold)
        .Take(10) // Ограничиваем топ-10 товаров
        .ToList();

            // Создание данных для графика
            var productNames = popularProducts.Select(p => p.ProductName).ToArray();
            var quantities = popularProducts.Select(p => (double)p.QuantitySold).ToArray();

            // Создание графика
            var columnSeries = new LiveCharts.Wpf.ColumnSeries
            {
                Title = "Популярные товары",
                Values = new LiveCharts.ChartValues<double>(quantities)
            };

            var cartesianChart = new LiveCharts.Wpf.CartesianChart
            {
                Series = new LiveCharts.SeriesCollection { columnSeries },
                AxisX = new LiveCharts.Wpf.AxesCollection
        {
            new LiveCharts.Wpf.Axis
            {
                Title = "Товары",
                Labels = productNames
            }
        },
                AxisY = new LiveCharts.Wpf.AxesCollection
        {
            new LiveCharts.Wpf.Axis
            {
                Title = "Проданные единицы"
            }
        },
                Width = 600,
                Height = 400
            };

            // Отображение графика в контейнере
            ChartContainer.Content = cartesianChart;
        }




        internal class CartesianChart
        {
            public object Series { get; set; }
            public object AxisX { get; set; }
            public object AxisY { get; set; }
        }
    }
}
