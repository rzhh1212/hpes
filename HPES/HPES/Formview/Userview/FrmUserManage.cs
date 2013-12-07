using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HPES.DBClass;
using System.Data.SqlClient;
namespace HPES.Formview.Userview
{
    public partial class FrmUserManage : Form
    {
        public FrmUserManage()
        {
            InitializeComponent();
        }
        
        DBOperate operate = new DBOperate();//�������ݿ��������
        private void �˳�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();//�رմ���
        }

        private void FrmUserManage_Load(object sender, EventArgs e)
        {
            string getUser =//����SQL�ַ���
                "select name as �û���,password as ����,userauth as Ȩ�� from  HPES_user";
            operate.BindDataGridView(dataGridView1,getUser);//�󶨵�DataGridView�ؼ�
            dataGridView1.Columns[0].Width = 88;//�����п��
            dataGridView1.Columns[1].Width = 85;//�����п��
            dataGridView1.Columns[2].Width = 88;//�����п��
            comboBox1.SelectedIndex = 0;//����Ĭ��ѡ����
        }
	
        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                txtOUser.Enabled = true;//�����ı���ؼ�
                txtOPwd.Enabled = true;//�����ı���ؼ�
                comboBox1.Enabled = true;//����ComboBox�ؼ�

                SqlConnection conn = DBClass.DBConnection.MyConnection();

                conn.Open();//���ӵ�SQL���ݿ�

                string str = "select * from HPES_user where name='" + txtOUser.Text.Trim() + "'"; ;//����SQL�ַ���

                SqlCommand cmd = new SqlCommand(str,conn);

                SqlDataReader sdr = cmd.ExecuteReader();//�õ����ݶ�ȡ������

                sdr.Read();//��ȡһ����¼       

                if (sdr.HasRows)//�ж��Ƿ��������
                
                {
                    MessageBox.Show("����Ա���ڣ�", "��ʾ",//������Ϣ�Ի���
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;//�˳��¼�
                }
                else
                {
                    if (txtOUser.Text.Trim() == "" || txtOPwd.Text.Trim() == "")
                    {
                        MessageBox.Show("��Ϣ��������", "��ʾ",//������Ϣ�Ի���
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;//�˳��¼�
                    }
                    else
                    {
                        string InsertSql =//����SQL�ַ���
                            "insert into HPES_user(id,name,password,userauth) values(HPES_user_sequence.nextval,'" + txtOUser.Text.Trim() + "','" + txtOPwd.Text.Trim() + "','" + comboBox1.Text + "')";
                        operate.OperateData(InsertSql);//�����ݿ��в�������
                        txtOPwd.Text = "";//����ı�����
                        txtOUser.Text = "";//����ı�����
                        MessageBox.Show("�����û��ɹ���", "��ʾ",//������Ϣ�Ի���
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch
            {
                MessageBox.Show("���Ӳ���Աʧ�ܣ�","��ʾ",//������Ϣ�Ի���
                    MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string name=dataGridView1.SelectedCells[0].Value.ToString();//�õ��û���
            string str =//����SQL�ַ���
                "select * from HPES_user where name='"+name+"'";
            DataSet ds = operate.GetTable(str);//�õ����ݼ�
            ds.Dispose();//�ͷ���Դ
            txtOUser.Text = ds.Tables[0].Rows[0][1].ToString();//�õ��û���
            txtOPwd.Text = ds.Tables[0].Rows[0][2].ToString();//�õ�����
            comboBox1.SelectedItem = ds.Tables[0].Rows[0][3].ToString();//����ѡ����
        }

        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("��ѡ��Ҫɾ���Ĺ���Ա", "��ʾ",//������Ϣ�Ի���
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;//�˳��¼�
            }
            else
            {
                string username = dataGridView1.SelectedCells[0].Value.ToString();//�õ��û���
                string strsql =//����SQL�ַ���
                    "delete from HPES_user where name='"+username+"'";
                operate.OperateData(strsql);//ɾ�����ݿ���ָ����¼
                MessageBox.Show("ɾ���ɹ���", "��ʾ",//������Ϣ�Ի���
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmUserManage_Activated(object sender, EventArgs e)
        {
            FrmUserManage_Load(sender, e);//ִ�д���Load�¼�
        }

        private void �޸�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtOUser.Text.Trim() == "" || txtOPwd.Text.Trim() == "")
            {
                MessageBox.Show("��Ϣ��������", "��ʾ",//������Ϣ�Ի���
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;//�˳��¼�
            }
            else
            {
                string str =//����SQL�ַ�������
                    "select count(*) from HPES_user where name='" + txtOUser.Text.Trim() + "'";
                int i = operate.HumanNum(str);//������¼����
                if (i > 0)
                {
                    string updatestr =//����SQL�ַ���
                        "update HPES_user set password='" + txtOPwd.Text.Trim() + "',userauth='" + comboBox1.Text + "' where name='" + txtOUser.Text.Trim() + "'";
                    operate.OperateData(updatestr);//�������ݿ���Ϣ
                    MessageBox.Show("��Ϣ�޸ĳɹ���", "��ʾ",//������Ϣ�Ի���
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtOPwd.Text = "";//����ı�����
                    txtOUser.Text = "";//����ı�����
                }
                else
                {
                    MessageBox.Show("ָ���û������ڣ�", "��ʾ",//������Ϣ�Ի���
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


       
    }
}