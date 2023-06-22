using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ppapp.Classes;

namespace ppapp.DB
{
   public class AppContext
    {
        public static changsalonEntities1 DB;
        public static List<Products> products = new List<Products>();


        SqlConnection sqlConnection = new SqlConnection(@"Data Source = LAPTOP-CL4O429I\SQLEXPRESS;Initial Catalog = changsalon;Integrated Security=true"); //подключение к БД

    

        public void OpenConnection()
        {
            if(sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }
        public void CloseConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        public SqlConnection GetConnection()
        {
           return sqlConnection;
        }
    }
}
