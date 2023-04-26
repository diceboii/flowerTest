
using flowerTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace flowerTest
{
    /// <summary>
    /// Логика взаимодействия для Products.xaml
    /// </summary>
    public partial class Products : Window
    {
        public Products()
        {
            InitializeComponent();
           
             
        }

        private void btnHome_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            this.Close();
        }

        private void btnSettings_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnAddTovar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AddProd addProd = new AddProd();
            addProd.Show();

            this.Close();
        }

        private void btnEditTovar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DGProducts.ItemsSource = AppData.db.Product.ToList();
        }
    }
}
