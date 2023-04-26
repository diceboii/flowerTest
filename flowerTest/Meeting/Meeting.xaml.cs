using flowerTest.Models;
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
using System.Windows.Shapes;

namespace flowerTest
{
    /// <summary>
    /// Логика взаимодействия для Meeting.xaml
    /// </summary>
    public partial class Meeting : Window
    {
        public Meeting()
        {
            InitializeComponent();
        }

        private void btnWatch_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnAddMeet_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DGMeet.ItemsSource = AppData.db.Meeting.ToList();
        }

        private void btnAddMeet_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnSettings_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnSend_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
