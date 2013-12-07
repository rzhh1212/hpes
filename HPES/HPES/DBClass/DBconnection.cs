using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace HPES.DBClass
{
    class DBConnection
    {

        /// <summary>
        /// 返回数据库连接的静态方法
        /// </summary>
        /// <returns>方法返回数据库连接对象</returns>
        /// 

        public static SqlConnection MyConnection()
        {
            //return new SqlConnection(//创建数据库连接对象
            //@"server=127.0.0.1;database=HPES;uid=sa;pwd=");//数据库连接字符串
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = HPES.Properties.Settings.Default.HPESSQLConn;
            return conn;

            // return  new SqlConnection("server=localhost;database=db_PMS;uid=sa;pwd=Noah,123");
        }


        public static SqlBulkCopy SqlBulkCopy()
        {

            string strConn = "server=localhost;uid=sa;pwd=;database=HPES";

            System.Data.SqlClient.SqlBulkCopy bcp = new System.Data.SqlClient.SqlBulkCopy(strConn);

            return bcp;
        }

    }
}
