using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using HPES.Formview.Main;
using HPES.Formview.Userview;
using HPES.DBClass;
namespace HPES.Formview.Userview
{
    public partial class FrmChangeUser : Form
    {
        public FrmChangeUser()
        {
            InitializeComponent();
        }
        DBOperate operate = new DBOperate();//�������ݿ��������
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();//�رմ���
        }

        private void frmChangeUser_Load(object sender, EventArgs e)
        {
            SqlConnection conn = DBConnection.MyConnection();//�������ݿ����Ӷ���
            conn.Open();//�����ݿ�����
            SqlCommand cmd = new SqlCommand("select * from HPES_user", conn);//�������ݿ��������
           
            SqlDataReader sdr = cmd.ExecuteReader();//�õ����ݶ�ȡ��
            while (sdr.Read())//��ȡ����
            {

                comboBox1.Items.Add(sdr["name"].ToString());//���������
                //comboBox1.Items.Add("shit");
            }
            conn.Close();//�ر����ݿ�����
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtpwd.Text.Trim()==""||comboBox1.Text=="")
                {
                    MessageBox.Show("�û��������벻��Ϊ�գ�", "��ʾ",//������Ϣ�Ի���
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;//�˳��¼�
                }
                else
                {
                    string name = comboBox1.Text;//��ȡ�û���
                    string pwd = txtpwd.Text.Trim();//��ȡ����
                    SqlConnection conn = DBConnection.MyConnection();//�������ݿ����Ӷ���
                    conn.Open();//�����ݿ�����
                    SqlCommand cmd = new SqlCommand(//�������ݿ��������
                        "select * from HPES_user where name='" + name + "' and password='" + pwd + "'", conn);
                    SqlDataReader sdr = cmd.ExecuteReader();//�������ݶ�ȡ��
                    sdr.Read();//��ȡ����
                    if (sdr.HasRows)//�ж��Ƿ�������
                    {
                        string time = DateTime.Now.ToString();//�õ�ʱ����Ϣ
                        string sql = //����SQL�ַ���
                            "update HPES_user set logintime='" + time + "' where name='" + name + "'";
                        operate.OperateData(sql);//�������ݿ���Ϣ
                        this.MdiParent.Close();//�رո�����
                        conn.Close();//�ر�����
                        frmMain Main = new frmMain();//�������������
                        //Main.loginuser.Text = name;//Ϊ�ֶθ�ֵ
                        //Main.Logintime.Text = time;//Ϊ�ֶθ�ֵ
                        Main.Show();//��ʾ������
                    }
                    else
                    {
                        txtpwd.Text = "";//����ı�����
                        comboBox1.Text = "";//����ı�����
                        MessageBox.Show("�û������������", "��ʾ",//������Ϣ�Ի���
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)//�����쳣
            {
                MessageBox.Show(ex.Message);//������Ϣ�Ի���
            }
        }
    }
}