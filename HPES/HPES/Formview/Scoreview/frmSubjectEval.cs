using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HPES.Formview.Main;
using System.Data.OleDb;
using Janus.Windows.GridEX;

namespace HPES
{
    public partial class frmSubjectEval : Form
    {
        public OleDbConnection oleconnhis=new OleDbConnection();
        public OleDbConnection oleconnfis=new OleDbConnection();
        public frmSubjectEval()
        {
            InitializeComponent();
        }

        public int hid;
        public int yid;
        public frmMain frm;


        private void frmSubjectEval_Load(object sender, EventArgs e)
        {
            frm = (frmMain)this.ParentForm;
            if (frm.cboHospital.ComboBox.SelectedValue == null || frm.cboYear.ComboBox.SelectedValue == null)
            {
                MessageBox.Show("请先选择要考评的医院和考评年度。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            hid = int.Parse(frm.cboHospital.ComboBox.SelectedValue.ToString());
            yid = int.Parse(frm.cboYear.ComboBox.SelectedValue.ToString());

            // TODO: 这行代码将数据加载到表“dsQuery.hpes_query”中。您可以根据需要移动或移除它。
            this.hpes_queryTableAdapter.Fill(this.dsQuery.hpes_query);
            this.hpes_query_dataTableAdapter.Fill(this.dsQuery.hpes_query_data, hid, yid);


            OleDbCommand command = new OleDbCommand();
            OleDbDataReader reader;
            command.Connection = this.hpes_standard_pointTableAdapter.Connection;
            if (command.Connection.State == ConnectionState.Closed) command.Connection.Open();

            command.CommandText = "SELECT StartDate, endDate FROM hpes_time WHERE YID = " + yid.ToString();
            reader = command.ExecuteReader();
            reader.Read();
            DateTime dBEGINDATE = Convert.ToDateTime(reader[0].ToString());
            DateTime dENDDDATE = Convert.ToDateTime(reader[1].ToString());

            string sBEGINDATE = dBEGINDATE.ToString("yyyy-MM-dd");
            string sENDDATE = dENDDDATE.ToString("yyyy-MM-dd");

            GridEXRow[] rows;
            rows = gridEX1.GetRows();
            foreach (GridEXRow row in rows)
            {
                row.BeginEdit();
                row.Cells[6].Value = sBEGINDATE;
                row.Cells[7].Value = sENDDATE;
                row.EndEdit();
            }


        }

        private void btnCalcAll_Click(object sender, EventArgs e)
        {
            frm = (frmMain)this.ParentForm;
            frm.lblSysMessage.Text = "正在检查各系统输入信息...";  
            if (this.edtHISServerIP.Text == "" || this.edtHISPassword.Text == "" || this.edtHISUserName.Text  == "") {
                MessageBox.Show("请先输入军卫一号系统数据库连接信息后再执行本操作。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                frm.lblSysMessage.Text = "系统已就绪。";
                return;
            }

            /*if (this.edtFISServerIP.Text == "" || this.edtFISDBName.Text == "" || this.edtFISUserName.Text == "")
            {
                MessageBox.Show("请先输入军财一号系统数据库连接信息后再执行本操作。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                frm.lblSysMessage.Text = "系统已就绪。";
                return;
            }
            */
            try
            {
                frm.lblSysMessage.Text = "正在尝试连接军卫一号系统数据库...";
                frm.StatusBar1.Refresh();
                Console.WriteLine("正在尝试连接军卫一号系统数据库...");
                //oleconnhis.ConnectionString = "Provider=MSDAORA.Oracle;Data Source=" + this.edtHISServerIP.Text + ";Initial Catalog=" + this.edtHISDBName.Text + ";User Id=" + this.edtHISUserName.Text + ";Password=" + this.edtHISPassword.Text + ";";
                oleconnhis.ConnectionString = "Provider=MSDAORA.Oracle;Data Source=" + this.edtHISServerIP.Text + ";User Id=" + this.edtHISUserName.Text + ";Password=" + this.edtHISPassword.Text + ";";
                oleconnhis.Open();

            }
            catch (Exception exec)
            {
                MessageBox.Show("连接军卫一号系统数据库时出现错误，请检查您输入的连接信息或网络连接。\n错误代码：" + exec.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                frm.lblSysMessage.Text = "系统已就绪。";
                ////return;
            }
            /*
            try
            {
                frm.lblSysMessage.Text = "正在尝试连接军财一号系统数据库...";  
                Console.WriteLine("正在尝试连接军财一号系统数据库...");
                oleconnfis.ConnectionString = "Provider=sqloledb;Data Source=" + this.edtFISServerIP.Text  + ";Initial Catalog=" + this.edtFISDBName.Text  + ";User Id=" + this.edtFISUserName.Text  + ";Password=" + this.edtFISPassword.Text + ";";
                oleconnfis.Open();

            }
            catch (Exception exec)
            {
                MessageBox.Show("连接军财一号系统数据库时出现错误，请检查您输入的连接信息或网络。\n" + exec.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                frm.lblSysMessage.Text = "系统已就绪。";
                return;
            }
            */
            frm.lblSysMessage.Text = "各系统数据库连接就绪，正在准备查询...";
            frm.StatusBar1.Refresh();
            Console.WriteLine("各系统数据库连接就绪，正在准备查询...");
            this.hpes_standard_pointTableAdapter.Fill(this.dsPoint.hpes_standard_point);
            DataTable dt= this.dsPoint.hpes_standard_point;
            
            //int oid, tid, pid;
            string sName = "";
            string sSQL;
            string sParameters;
            string[] aParameters;
            string sBEGINDATE, sENDDATE;
            string sFields = "";
            string sQID;

            OleDbCommand command;
            OleDbDataReader reader;
            OleDbCommand UpdateCommand = new OleDbCommand();
            UpdateCommand.Connection = this.hpes_standard_pointTableAdapter.Connection;

            command = new OleDbCommand();
            command.Connection = this.hpes_standard_pointTableAdapter.Connection;
            if (command.Connection.State == ConnectionState.Closed) command.Connection.Open();
            GridEXRow[] rows;
            rows = gridEX1.GetRows();
            foreach (GridEXRow row in rows)
            {
                row.GridEX.MoveToRowIndex(row.Position);
                sQID = row.Cells[1].Value.ToString();
                sName = row.Cells[3].Value.ToString();
                sSQL = row.Cells[4].Value.ToString();
                sBEGINDATE = row.Cells[6].Value.ToString().Replace("-", "");
                sENDDATE = row.Cells[7].Value.ToString().Replace("-", "");
                sFields = row.Cells[8].Value.ToString();
                //MessageBox.Show(row.Children.ToString());
                //GridEXRow childrow = childrows.First();
                
                String[] aFields = sFields.Split(';');

                sParameters = row.Cells[5].Value.ToString();
                aParameters = sParameters.Split(';');
                foreach (String sParameter in aParameters) {
                    switch (sParameter){
                        case "BEGINDATE": 
                            sSQL = sSQL.Replace("BEGINDATE", sBEGINDATE);
                            break;
                        case "ENDDATE":
                            sSQL = sSQL.Replace("ENDDATE", sENDDATE);
                            break;
                        default:
                            Console.WriteLine("无法识别的查询参数： {0}", sParameter);
                            break;
                    }
                }
                frm.lblSysMessage.Text="即将执行查询: "+ sName;
                Console.WriteLine("即将执行查询: {0}\n查询语句: {1}", sName, sSQL);
                try
                {
                    command = new OleDbCommand(sSQL, oleconnhis);
                    reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        frm.lblSysMessage.Text = "找到数据，准备插入数据库...";
                        Console.WriteLine("找到数据，准备插入数据库。");
                        while (reader.Read())
                        {
                            string sTemp = "";
                            for (int i = 0; i < aFields.Length; i++)
                            {
                                sTemp += aFields[i] + ": " + reader[i].ToString();
                            }
                            frm.lblSysMessage.Text = sTemp;
                            sSQL = @"INSERT INTO hpes_query_data (HID, YID, QID, " + sFields + ") VALUES (" + hid.ToString() + ", " + yid.ToString() + ", " + sQID + ", ";
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                sSQL += reader[i].ToString() + ", ";
                            }
                            sSQL += ")";
                            Console.WriteLine(reader[0].ToString());
                            UpdateCommand.CommandText = sSQL;
                            UpdateCommand.ExecuteNonQuery();

                        }
                    }
                    else
                    {
                        Console.WriteLine("没有找到符合条件的数据。");
                    }
                    reader.Close();
                    if (row.Position <= gridEX1.RecordCount)
                    {
                        frm.uiProgressBar1.Value = (row.Position) * 100 / gridEX1.RecordCount;
                    }
                    else
                        frm.uiProgressBar1.Value = frm.uiProgressBar1.Maximum;
                }
                catch (Exception exec) {
                    MessageBox.Show("执行查询时出现错误，请检查数据库连接或查询语句。\n错误代码：" + exec.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //frm.lblSysMessage.Text = "系统已就绪。";
                }
            }
            frm.lblSysMessage.Text = "系统已就绪，请继续使用。";
        }

        private void frmSubjectEval_Activated(object sender, EventArgs e)
        {
            frm = (frmMain)this.ParentForm;
            if (frm.cboHospital.ComboBox.SelectedValue!=null) {
                this.dsHospitalTableAdapter1.Fill(this.dsHospital1._dsHospital);
                this.dsHospital1._dsHospital.DefaultView.RowFilter = "ID = " + frm.cboHospital.ComboBox.SelectedValue.ToString();
                if (this.dsHospital1._dsHospital.Rows[0]["HISServer"] != null)
                {
                    this.edtHISServerIP.Text = this.dsHospital1._dsHospital.Rows[0]["HISServer"].ToString();
                    this.edtHISUserName.Text = this.dsHospital1._dsHospital.Rows[0]["HISUserName"].ToString();
                    this.edtHISPassword.Text = this.dsHospital1._dsHospital.Rows[0]["HISPassword"].ToString();
                }

                if (this.dsHospital1._dsHospital.Rows[0]["FISServer"] != null)
                {
                    this.edtFISServerIP.Text = this.dsHospital1._dsHospital.Rows[0]["FISServer"].ToString();
                    this.edtFISDBName.Text = this.dsHospital1._dsHospital.Rows[0]["FISDBName"].ToString();
                    this.edtFISUserName.Text = this.dsHospital1._dsHospital.Rows[0]["FISUserName"].ToString();
                    this.edtFISPassword.Text = this.dsHospital1._dsHospital.Rows[0]["FISPassword"].ToString();
                }

            }
        }






    }
}
