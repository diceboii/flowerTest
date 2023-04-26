using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using System.Windows.Threading;
using flowerTest.Models;
using Microsoft.Win32;

namespace flowerTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                this.txtDate.Text = "Актуальное время: " + DateTime.Now.ToString("HH:mm");
            }, this.Dispatcher);
        }

        private void txtProfile_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();

            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            if (Auth.isUserLogin == false)
            {
                txtGreet.Text = "Здравия!";

                txtWords.Text = "Вы еще не вошли в систему";

                txtMeeting1.Text = "Войдите в систему, чтобы увидеть встречи";


            } else if (Auth.isUserLogin == true)
            {
                txtGreet.Text = "Здравия, " + Auth.userName;

                txtWords.Text = "Вы успешно авторизированы";
            }
        }

        private void btnEnter_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Auth.isUserLogin == false)
            {
                Auth auth = new Auth();
                auth.Show();

                this.Close();

            }
            else if (Auth.isUserLogin == true)
                MessageBox.Show("Вы уже вошли в систему");
            
        }

        private void btnMeet_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Auth.isUserLogin == false)
                MessageBox.Show("Для перехода на данную вкладку необходимо авторизироваться в системе");
            else if (Auth.isUserLogin == true)
            {
                Meeting meeting = new Meeting();
                meeting.Show();

                this.Hide();
            }
        }

        private void btnRegist_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Auth.isUserLogin == false)
            {
                Regist regist = new Regist();
                regist.Show();

                this.Hide();
            }
            else if (Auth.isUserLogin == true)
                MessageBox.Show("Вы уже авторизированы в системе");
        }

        private void btnProducts_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Auth.isUserLogin == false)
                MessageBox.Show("Для перехода на данную вкладку необходимо авторизироваться в системе");
            else if (Auth.isUserLogin == true)
            {
                Products products = new Products();
                products.Show();

                this.Hide();
            }
            
        }
 

        private void btnDownload_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            

        }
    }
}
