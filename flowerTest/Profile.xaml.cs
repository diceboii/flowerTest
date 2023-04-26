using Prism.Services.Dialogs;
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
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Auth.isUserLogin == false)
            {
                txtHello.Text = "Здравия, гость!";
                txtHello1.Text = "Вы еще не вошли в систему";

                txtIf.Text = "Для того, чтобы увидеть инф-ию";
                txtIf1.Text = "войдите или зарегестрируетесь";

                txtTo.Text = "Войти в систему можно, вернувшись";
                txtTo1.Text = "на главную страницу";
            } else if (Auth.isUserLogin == true)
            {
                txtHello.Text = "Приветсвтуем, " + Auth.userName;
                txtHello1.Text = "Вы находитесь в личном кабинете";

                txtIf.Text = "Здесь можно добавить и ";
                txtIf1.Text = "отредактировать инф-ию о вас";

                txtTo.Text = "";

            }
        }

        private void btnHome_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            this.Close();
        }

        private void btnUserInfo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Auth.isUserLogin == false)
            {
                MessageBox.Show("Дабы узнать информацию, необходимо войти в систему");
            } else if (Auth.isUserLogin == true)
            {
                MessageBox.Show("Информация о пользователе\n\n" + "Фамилия: \n" + "Имя: " + Auth.userName + "\n") ;
            }
        }

        private void btnChangeInfo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Auth.isUserLogin == false)
            {
                MessageBox.Show("Дабы изменить инфомрацию в профиле, необходимо войти в систему");
            }
            else if (Auth.isUserLogin == true)
            {
                editProf editProf = new editProf();
                editProf.Show();

                this.Close();
            }
        }

        private void btnLogOut_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Auth.isUserLogin == false)
            {
                MessageBox.Show("Вы не можете выйти из системы, так как еще не авторизированы");
            }
            else if (Auth.isUserLogin == true)
            {
                if (MessageBox.Show("Вы точно хотите выйти из системы?", "Выйти", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Auth.isUserLogin = false;

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();

                    this.Close();
                }
                else
                {
                    
                }
            }
        }
    }
}
