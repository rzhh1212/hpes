using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
//using System.Data.SqlClient;
using System.Data.SqlClient;


namespace HPES.DBClass
{
    class DBOperate
    {
        SqlConnection conn = DBConnection.MyConnection();//得到数据库连接对象
        
        /// <summary>
        /// 操作数据库，执行各种SQL语句
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns>方法返回受影响的行数</returns>
        public int OperateData(string strSql)
        {
            conn.Open();//打开数据库连接
            SqlCommand cmd = new SqlCommand(strSql, conn);//创建命令对象

            int i = cmd.ExecuteNonQuery();//执行SQL命令,执行更新语句的方法，如果向执行查询语句，应该用Command对象的ExecuteReader方法来取得结果集。


            conn.Close();//关闭数据库连接
            return i;//返回数值
        }

        public SqlDataReader OperateSelect(string strSql)
        {
            conn.Open();//打开数据库连接
            SqlCommand cmd = new SqlCommand(strSql, conn);//创建命令对象

            SqlDataReader ora = cmd.ExecuteReader();//执行SQL命令,执行更新语句的方法，如果向执行查询语句，应该用Command对象的ExecuteReader方法来取得结果集。

            conn.Close();//关闭数据库连接
            return ora;//返回数值
        }


        /// <summary>
        /// 方法用于绑定DataGridView控件
        /// </summary>
        /// <param name="dgv">DataGridView控件</param>
        /// <param name="sql">SQL语句</param>
        public void BindDataGridView(DataGridView dgv, string sql)
        {
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);//创建数据适配器对象


            DataSet ds = new DataSet();//创建数据集对象
            sda.Fill(ds);//填充数据集
            dgv.DataSource = ds.Tables[0];//绑定到数据表
            ds.Dispose();//释放资源
        }


        //public void BindDataGridEX(Janus.Windows.GridEX.GridEX gridex, string sql1,DataSet ds)
        //{
            
        
            
        //    SqlDataAdapter sda1 = new SqlDataAdapter(sql1, conn);//创建数据适配器对象
        //    //SqlDataAdapter sda2 = new SqlDataAdapter(sql2, conn);//创建数据适配器对象
        //    //SqlDataAdapter sda3 = new SqlDataAdapter(sql3, conn);//创建数据适配器对象


        //    //DataSet ds = new DataSet();//创建数据集对象
        //    sda1.Fill(ds);//填充数据集
        //    //sda2.Fill(ds);//填充数据集
        //    //sda3.Fill(ds);//填充数据集
        //    gridex.DataSource = ds.Tables[0];//绑定到数据表
        //    //gridex.DataMember = ds.Tables[0];
            
        //    ds.Dispose();//释放资源
        //}

        

        /// <summary>
        /// 查找指定数据表的人数
        /// </summary>
        /// <param name="strsql">SQL语句</param>
        /// <returns>方法返回指定记录的数量</returns>
        public int HumanNum(string strsql)
        {
            conn.Open();//打开数据库连接
            SqlCommand cmd = new SqlCommand(strsql, conn);//创建命令对象
            decimal i = (decimal)cmd.ExecuteScalar();//执行SQL命令
            conn.Close();//关闭数据库连接
            return Convert.ToInt32(i);//返回数值
        }

        /// <summary>
        /// 显示选择的图片
        /// </summary>
        /// <param name="openF">图像文件的路径</param>
        /// <param name="MyImage">PictureBox控件</param>
        //public void Read_Image(OpenFileDialog openF, PictureBox MyImage)
        //{
        //    openF.Filter = "*.jpg|*.jpg|*.bmp|*.bmp";//筛选打开文件的格式
        //    if (openF.ShowDialog() == DialogResult.OK)//如果打开了图片文件
        //    {
        //        try
        //        {
        //            MyImage.Image = System.Drawing.Image.//设置PictureBox控件的Image属性
        //                FromFile(openF.FileName);

        //        }
        //        catch
        //        {
        //            MessageBox.Show("您选择的图片不能被读取或文件类型不对！",//弹出消息对话框
        //                "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //    }
        //}


        /// <summary>
        /// 使用此方法可以得到数据集
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>方法返回数据集</returns>
        public DataSet GetTable(string sql)
        {
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);//创建数据适配器对象


            DataSet ds = new DataSet();//创建数据集
            sda.Fill(ds);//填充数据集
            ds.Dispose();//释放资源
            return ds;//返回数据集
        }

        /// <summary>
        /// //绑定下拉列表
        /// </summary>
        /// <param name="strTable">数据库表名</param>
        /// <param name="cb">ComboBox对象</param>
        /// <param name="i">指定数据列索引</param>
        public void BindDropdownlist(string strTable, ComboBox cb, int i)
        {
            conn.Open();//打开数据库连接
            SqlCommand cmd = new SqlCommand(//创建命令对象
                "select * from " + strTable, conn);
            SqlDataReader sdr = cmd.ExecuteReader();//得到数据读取器

            while (sdr.Read())
            {
                cb.Items.Add(sdr[i].ToString());//添加信息

                
            }
            conn.Close();//关闭数据库连接
        }

        public void BindToolStripDropdownlist(string strTable, ToolStripComboBox tcb, int i)
        {
            conn.Open();//打开数据库连接
            SqlCommand cmd = new SqlCommand(//创建命令对象
                "select * from " + strTable, conn);
            SqlDataReader sdr = cmd.ExecuteReader();//得到数据读取器

            while (sdr.Read())
            {
                tcb.Items.Add(sdr[i].ToString());//添加信息


            }
            conn.Close();//关闭数据库连接
        }


        public int GetIdByName(string sql)
        {

            conn.Open();//打开数据库连接
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);//创建数据适配器对象

            SqlCommand cmd = new SqlCommand(sql, conn);//创建命令对象
            int i = (int)cmd.ExecuteScalar();//执行SQL命令
            conn.Close();//关闭数据库连接
            return i;//返回数值

        }

        public DataTable GetSubmitData(string sql)
        {
            DataSet ds = new DataSet();
 
            conn.Open();//打开数据库连接

            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);//创建数据适配器对象

            sda.Fill(ds);

            //ds.Tables[0].Columns.Remove("ID");
            //ds.Tables[0].Columns.Remove("HID");
            //ds.Tables[0].Columns.Remove("YID");

            conn.Close();//关闭数据库连接
            return ds.Tables[0];//返回数值

        }

        public int UpdateSubmitData(string strSql)
        {
            conn.Open();//打开数据库连接
            SqlCommand cmd = new SqlCommand(strSql, conn);//创建命令对象

            int i = cmd.ExecuteNonQuery();//执行SQL命令,执行更新语句的方法，如果向执行查询语句，应该用Command对象的ExecuteReader方法来取得结果集。


            conn.Close();//关闭数据库连接
            return i;//返回数值
        }




    }
}
