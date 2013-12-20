using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;

namespace ConsoleTest
{
    public class DBSelectTest
    {
        public static void Test()
        {
            string connectionString = "";
            string queryString = "";

            DataSet dataset=new DataSet();

            using (SqlConnection connection =new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(
                    queryString, connection);
                adapter.Fill(dataset);
            }
        }

    }
}
