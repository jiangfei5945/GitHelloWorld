using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ConsoleTest
{
    public class BulkCopyTest
    {
        public static void Test()
        {
            using (SqlConnection conn = new SqlConnection("Data Source = localhost;Database  = TestDB;User Id = sa;Password = abc@123;Trusted_Connection = False;"))
            {
                conn.Open();
                using (var bulk = new SqlBulkCopy(conn))
                {
                    bulk.BulkCopyTimeout = 5 * 60;
                    //每一批次中的行数(在每一批次结束时，将该批次中的行发送到服务器)
                    //bulk.BatchSize = 5000;
                    //设置服务器上目标表的名称
                    bulk.DestinationTableName = "SMS_Department";

                    DataTable dt = CreateDataTable();
                    //写入数据库
                    bulk.WriteToServer(dt);
                }
            }
        }

        public static DataTable CreateDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Description", typeof(string));
            dataTable.Columns.Add("Operator", typeof(string));
            dataTable.Columns.Add("OperateIP", typeof(string));
            dataTable.Columns.Add("OperateTime", typeof(DateTime));

            DataRow dataRow = dataTable.NewRow();
            dataRow["ID"] = 1;
            dataRow["Name"] = "sdf";
            dataRow["Description"] = "sdf";
            dataRow["Operator"] = "sdf";
            dataRow["OperateIP"] = DBNull.Value;
            dataRow["OperateTime"] = DateTime.Now;
            dataTable.Rows.Add(dataRow);

            return dataTable;
        }
    }
}
