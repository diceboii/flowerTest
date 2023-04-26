using System;
using System.Collections.Generic;
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
using flowerTest.Models;

namespace flowerTest
{
    /// <summary>
    /// Логика взаимодействия для AddProd.xaml
    /// </summary>
    public partial class AddProd : Window
    {
        public AddProd()
        {
            InitializeComponent();
        }

        private void btnAdd_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataBase dataBase = new DataBase();

            //объявление переменных, которые будут в последсвтии добавлены в бд
            var nameP = txtNameProd.Text;
            var price = txtPriceProd.Text;
            var phone = txtPhoneProd.Text;
            var amount = txtAmountProd.Text;
            var about = txtAboutProd.Text;

            //создание запроса на внесение данных в бд
            string query = $"insert into Product(nameOfProd, price, sellerPhone, amount, about) values ('{nameP}', '{price}', '{phone}', '{amount}', '{about}')";

            //создание команды для запроса
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());

            //подключение бд 
            dataBase.openConnection();


            if (command.ExecuteNonQuery() == 1)
            {

                Products product = new Products();
                product.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка, товар не добавлен");
            }
            dataBase.closeConnection();
        }
    }
}
