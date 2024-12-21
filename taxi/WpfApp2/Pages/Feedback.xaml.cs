﻿using System;
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
    /// Логика взаимодействия для Feedback.xaml
    /// </summary>
    public partial class Feedback : Page
    {
        public Feedback()
        {
            InitializeComponent();
            LoadFeedback();
        }
        private void LoadFeedback()
        {
            FeedbackDataGrid.ItemsSource = ConnectionClass.connect.Feedback.ToList();
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
