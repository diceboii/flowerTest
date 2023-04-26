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
using System.Data;
using System.Net;
using System.Data.SqlClient;
using flowerTest.Models;
using System.Text.RegularExpressions;



namespace flowerTest
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    /// 


    //валидация почты
    public static class ValidatorExtensions
    {
        public static bool IsValidEmailAddress(this string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }
    }



    public partial class Auth : Window
    {

        public static string userName;
        public static bool isUserLogin = false;

        public Auth()
        {
            InitializeComponent();

        }

        private void btnAuth_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            bool checKEmaiil = ValidatorExtensions.IsValidEmailAddress(txtEmail.Text);
            //bool checkPass = ValidatorExtensions.IsValidEmailAddress(txtPassword.Text);

            //глобальные переменные
            

            //создание переменной, которая сверяет правильно ли введена почта и пароль для входа в систему
            var CurrentUser = AppData.db.Users.FirstOrDefault(u => u.userEmail == txtEmail.Text && u.userPassword == txtPassword.Text);


            //переменная для подключения
            string txtCon = @"Data Source=LAPTOP-CBV6T39F\SQLEXPRESS;Initial Catalog=Flower; Integrated Security=true; Pooling = true";

            //переменная для запроса
            string txtSelect = "";
            var email = txtEmail.Text;
            txtSelect += txtEmail.Text;

            if (CurrentUser != null)
            {
                if (checKEmaiil == true)
                {
                    using (var connection = new SqlConnection(txtCon)) 
                    {
                        connection.Open();

                        SqlCommand command = new SqlCommand();
                        command.Connection = connection;
                        command.CommandText = $"SELECT userName from Users where userEmail = '{email}'";
                        object US = command.ExecuteScalar();

                        userName = US.ToString();
                    }

                    isUserLogin = true;

                     MainWindow mainWindow = new MainWindow();
                     mainWindow.Show();

                     this.Close();
                }
                else if (checKEmaiil == false)
                    MessageBox.Show("Электронная почта была указана неверно.");


            }
            
        }

        private void btnHome_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            this.Close();
        }

        private void ShowPasswordCharsCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            MyPasswordBox.Visibility = Visibility.Collapsed; //This hides the PasswordBox
            txtPassword.Visibility = Visibility.Visible; //This shows the TextBox

            txtPassword.Text = new NetworkCredential(string.Empty, MyPasswordBox.SecurePassword).Password; //This sets the text to the TextBox to the password typed into the PasswordBox
            txtPassword.Focus();
        }

        private void ShowPasswordCharsCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            MyPasswordBox.Visibility = Visibility.Visible; //This shows the PasswordBox
            txtPassword.Visibility = Visibility.Collapsed; //This hides the TextBox

            txtPassword.Text = ""; //Clear the text
            MyPasswordBox.Focus();
        }

        private void MyPasswordBox_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }
    }
}
