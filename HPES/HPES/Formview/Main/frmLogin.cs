using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using HPES.DBClass;

namespace HPES.Formview.Main
{
    public partial class frmLogin : Form
    {
        DBOperate operate = new DBOperate();//创建操作数据库对象

        public frmLogin()
        {
            InitializeComponent();
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {

            if (nameTxt.Text == "" || pwdTxt.Text == "")//判断用户名和密码是否为空
            {
                MessageBox.Show("用户名或密码不能为空！",//弹出消息对话框
                    "提示", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;//退出事件
            }
            else
            {
                string name = nameTxt.Text.Trim();//移除用户名前部和后部的空格
                string pwd = pwdTxt.Text.Trim();//移除密码前部和后部的空格

                SqlConnection conn = DBClass.DBConnection.MyConnection();//创建数据库连接对象
                conn.Open();//连接到SQL数据库
                //SqlCommand cmd = new SqlCommand(//创建数据库命令对象
                //    "select * from HPES_user where name='" +
                //    name + "' and password='" + pwd + "'", conn);



                SqlCommand cmd = new SqlCommand("select * from HPES_user where name='" + name + "' and password='" + pwd + "'", conn);

                SqlDataReader sdr = cmd.ExecuteReader();//得到数据读取器对象

                sdr.Read();//读取一条记录



                if (sdr.HasRows)//判断是否包含数据
                {
                    string time = DateTime.Now.ToString();//得到系统时间字符串


                    string sql = "update HPES_user set logintime='" //设置更新数据库的SQL语句
                        + time + "' where name='" + name + "'";
                    operate.OperateData(sql);//更新数据库内容
                    conn.Close();//关闭数据库连接
                    //this.Hide();//隐藏窗体


                    //FrmMain main = new FrmMain();//创建主窗体对象


                    ////main.loginuser.Text = name;//为主窗体字段赋值
                    ////main.Logintime.Text = time;//为主窗体字段赋值
                    //main.Show();//显示主窗体


                    frmMain frmMain = new frmMain();
                    frmMain.Show();
                    this.Hide();


                }
                else
                {
                    nameTxt.Text = "";//清空用户名
                    pwdTxt.Text = "";//清空密码
                    MessageBox.Show("用户名或密码错误！", "提示",//弹出消息对话框
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

                       
        }

        private void pwdTxt_KeyDown(object sender, KeyEventArgs e)
        {            //在输入完成密码后按下enter键进入系统            
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键            
            
            {
                this.uiButton1_Click(sender, e);//触发button事件            
            }        
        }




        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
