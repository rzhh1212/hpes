using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using HPES.DBClass;

namespace HPES.Model
{
    class ExcelToSql
    {
        

        public static  DataTable ExceltoDataSet(string path)
        {
            DataTable dTable;
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1';";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            System.Data.DataTable schemaTable = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
            string tableName = schemaTable.Rows[0][2].ToString().Trim();

            string strExcel = "";
            OleDbDataAdapter myCommand = null;
            DataSet ds = null;
            strExcel = "Select   *   From   [" + tableName + "]";
            myCommand = new OleDbDataAdapter(strExcel, strConn);

            ds = new DataSet();

            myCommand.Fill(ds, tableName);
            System.Data.DataTable dt = ds.Tables[0];

            dTable = dt;

            return dt;

        }


    


        public static void InsertTable(DataTable dt) {

            string strInsert = "insert into TEST(ID,NAME,VALUE,INFO,HID,YID) values (@id,@name,@value,@info,@hid,@yid)";

            SqlConnection conn = DBConnection.MyConnection();

            conn.Open();

            SqlCommand com = new SqlCommand(strInsert, conn);

            SqlParameter p = new SqlParameter("@id", SqlDbType.VarChar);
            SqlParameter p1 = new SqlParameter("@name", SqlDbType.VarChar);
            SqlParameter p2 = new SqlParameter("@value", SqlDbType.VarChar);
            SqlParameter p3 = new SqlParameter("@info", SqlDbType.VarChar);
            SqlParameter p4 = new SqlParameter("@hid", SqlDbType.VarChar);
            SqlParameter p5 = new SqlParameter("@yid", SqlDbType.VarChar);


            com.Parameters.Add(p);
            com.Parameters.Add(p1);
            com.Parameters.Add(p2);
            com.Parameters.Add(p3);
            com.Parameters.Add(p4);
            com.Parameters.Add(p5);



            for (int i = 0; i < dt.Rows.Count; i++)
            {

               // MessageBox.Show(dt.Rows.Count.ToString());

                DataRow row = dt.Rows[i];

                p.Value = row[0].ToString();
                p1.Value = row[1].ToString();
                p2.Value = row[2].ToString();
                p3.Value = row[3].ToString();
                p4.Value = row[4].ToString();
                p5.Value = row[5].ToString();

                //MessageBox.Show(row[1].ToString());

                com.ExecuteNonQuery();
            }

            conn.Close(); 
        
        }



    }
}
