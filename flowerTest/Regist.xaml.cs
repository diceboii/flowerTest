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

using System.Data.SqlClient;
using flowerTest.Models;
using System.Text.RegularExpressions;
using System.Windows.Navigation;

namespace flowerTest
{
    /// <summary>
    /// Логика взаимодействия для Regist.xaml
    /// </summary>
    public partial class Regist : Window
    {
        
        public Regist()
        {
            InitializeComponent();
        }

        private void btnHome_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            this.Close();
        }

        

        private void btnRegist_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            /*Проверка того, чтобы пользователь не создавал много аккаунтов на одну и ту же почту*/
            
            //ввод переменных для проверки
            int id = 1;
            string checkEmail = txtEmail.Text;

            //проверка на налачие эл. почты в бд
            do
            {
                using (var connection1 = new SqlConnection(@"Data Source=LAPTOP-CBV6T39F\SQLEXPRESS;Initial Catalog=Flower; Integrated Security=true; Pooling = true"))
                {
                    connection1.Open();

                    SqlCommand command1 = new SqlCommand();
                    command1.Connection = connection1;
                    command1.CommandText = $"SELECT userEmail from Users where id_users = '{id}'";
                    object US = command1.ExecuteScalar();

                    Auth.userName = US.ToString();

                }

                if (checkEmail == Auth.userName)
                    goto endRegist;

                id++;
            } while (checkEmail != Auth.userName);

            /*Регистрация пользователя*/

            //подключение к классу
            DataBase dataBase = new DataBase();
            
            //объявление переменных, которые будут в последсвтии добавлены в бд
            var name = txtName.Text;
            var email = txtEmail.Text;
            var password = txtPas.Text;

            //создание запроса на внесение данных в бд
            string query = $"insert into Users(userName, userEmail, userPassword) values ('{name}', '{email}', '{password}')";

            //создание команды для запроса
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());

            //подключение бд 
            dataBase.openConnection();

            
            if (command.ExecuteNonQuery() == 1)
            {
                Auth.isUserLogin = true;
                Auth.userName = txtName.Text;

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка, аккаунт не создан");
            }
            dataBase.closeConnection();

            endRegist:
                MessageBox.Show("Вы не можете зарегестрироваться, т.к. к данной почте уже привзян аккаунт");
        }
    }
}
