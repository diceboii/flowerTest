using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowerTest.Models
{
    class DataBase
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-CBV6T39F\SQLEXPRESS;Initial Catalog=Flower; Integrated Security=true; Pooling = true");

        public void openConnection()
        {
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
        }

        public void closeConnection()
        {
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
        }

        public SqlConnection getConnection()
        {
            return con;
        }

    }
}
