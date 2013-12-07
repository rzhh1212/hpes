using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.Ribbon;
using System.Data.OleDb;
using HPES.Formview.Userview;
using HPES.Formview.Bookview;
using HPES.Formview.Scoreview;
using HPES.Formview.Main;
using HPES.Model;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using HPES.DBClass;

namespace HPES.Formview.Main
{

    public partial class frmMain : Form
    {
 
        public frmMain()
        {
            InitializeComponent();
        }

        public int hid;
        public int yid;

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.dsHospitalTableAdapter1.Fill(this.dsHospital._dsHospital);
            this.dsYearTableAdapter1.Fill(this.dsYear._dsYear);

            ComboBoxCommand cbo = this.cboHospital;
            foreach (DataRow row in this.dsHospital.Tables[0].Rows) {
                cbo.ComboBox.Items.Add(row[2].ToString(), row[0]);
            }
            if (cbo.ComboBox.Items.Count > 0) {
                cbo.ComboBox.SelectedIndex = 0;
            }


            ComboBoxCommand cbo1 = this.cboYear;
            foreach (DataRow row in this.dsYear.Tables[0].Rows)
            {
                cbo1.ComboBox.Items.Add(row[1].ToString(), row[0]);
            }
            if (cbo1.ComboBox.Items.Count > 0)
            {
                cbo1.ComboBox.SelectedIndex = 0;
            }

            //this.hpes_drugTableAdapter.Fill(this.dsDrug.hpes_drug, (int)this.cboHospital.ComboBox.SelectedValue, (int)this.cboYear.ComboBox.SelectedValue);
            //this.hpes_submit_dataTableAdapter.Fill(this.dsSubmitData.hpes_submit_data, (int)this.cboHospital.ComboBox.SelectedValue, (int)this.cboYear.ComboBox.SelectedValue);

        }

        private void btnObjectEval_Click(object sender, Janus.Windows.Ribbon.CommandEventArgs e)
        {
            if (this.cboHospital.ComboBox.SelectedValue == null || this.cboYear.ComboBox.SelectedValue == null)
            {
                MessageBox.Show("请先选择要考评的医院和考评年度然后再执行本操作。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "frmSubjectEval")
                {
                    frm.Activate();
                    frm.Focus();
                    return;
                }
            }
            frmSubjectEval frmSubjectEval = new frmSubjectEval();
            frmSubjectEval.MdiParent = this;
            frmSubjectEval.Show();
        }
        
        private void btnSubjectEval_Click(object sender, CommandEventArgs e)
        {
            if (this.cboHospital.ComboBox.SelectedValue == null || this.cboYear.ComboBox.SelectedValue == null)
            {
                MessageBox.Show("请先选择要考评的医院和考评年度然后再执行本操作。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "frmObjectEval")
                {
                    frm.Activate();
                    frm.Focus();
                    return;
                }
            }
            frmObjectEval frmObjectEval = new frmObjectEval();
            frmObjectEval.MdiParent= this;
            frmObjectEval.Show();

        }


        private void btnPrintData_Click(object sender, CommandEventArgs e)
        {
            //frmObjectEval.printData();
            if (this.ActiveMdiChild == null) return;

            string strReportName;
            string strReportPath;
            switch (this.ActiveMdiChild.Name)
            {
                case "frmObjectEval":
                    //frmObjectEval frmObjectEval = (frmObjectEval)this.ActiveMdiChild;
                    //frmObjectEval.gridEXPrintDocument1.Print();
                    break;
                case "frmSubjectEval":

                    break;
                case "frmEvalSummary":
                    frmPreview frmPreview = new frmPreview();
                    frmPreview.MdiParent = this;
                    CrystalDecisions.CrystalReports.Engine.ReportDocument rptDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    strReportName = "rptEvalSummary";
                    //strReportPath = Application.StartupPath + "\\Report\\" + strReportName + ".rpt";
                    strReportPath = "C:\\Documents and Settings\\Administrator\\My Documents\\Visual Studio 2008\\Projects\\HPES\\HPES\\Report\\" + strReportName + ".rpt";
                    rptDocument.Load(strReportPath);
                    frmEvalSummary frmEvalSummary = (frmEvalSummary)this.ActiveMdiChild;
                    //rptDocument.SetDataSource(frmEvalSummary.dsEvalSummary1);
                    frmPreview.crystalReportViewer1.ReportSource = rptDocument;
                    frmPreview.Show();

                    break;
            }
        }

        private void btnExportData_Click(object sender, CommandEventArgs e)
        {
            if (this.ActiveMdiChild == null) return;
            //GridEXExporter GridExporter = this.ActiveMdiChild.GridEXExporter1;
            //GridExporter.Export();

        }

        private void btnYear_Click(object sender, CommandEventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "frmYear")
                {
                    frm.Activate();
                    frm.Focus();
                    return;
                }
            }
            frmYear frmYear = new frmYear();
            frmYear.MdiParent = this;
            frmYear.Show();

        }

        private void btnSave_Click(object sender, CommandEventArgs e)
        {
            if (this.ActiveMdiChild == null) return;
            DataTable changedRecords;
            switch (this.ActiveMdiChild.Name)
            {
                case "frmObjectEval":
                    {
                        frmObjectEval frmObjectEval = (frmObjectEval)this.ActiveMdiChild;
                        changedRecords = frmObjectEval.dsEvaluation._dsEvaluation.GetChanges();
                        //MessageBox.Show(changedRecords.Rows.Count.ToString());
                        //return;
                        if (changedRecords != null && changedRecords.Rows.Count > 0)
                        {
                            int iCount = 0;
                            try
                            {
                                OleDbCommand UpdateCommand;
                                foreach (DataRow changedRow in changedRecords.Rows)
                                {
                                    UpdateCommand = new OleDbCommand();
                                    UpdateCommand.Connection = this.dsHospitalTableAdapter1.Connection;
                                    if (UpdateCommand.Connection.State == ConnectionState.Closed) UpdateCommand.Connection.Open();
                                    UpdateCommand.CommandText = "UPDATE HPES_evaluation SET History_Score = Score, Score = ?, Info = ?, InputTime = GETDATE() WHERE ID = ?";
                                    OleDbParameter odp1 = new OleDbParameter("@Score", OleDbType.Integer, 16);
                                    odp1.Value = changedRow.ItemArray[12];
                                    UpdateCommand.Parameters.Add(odp1);

                                    OleDbParameter odp2 = new OleDbParameter("@Info", OleDbType.LongVarChar, 2000);
                                    odp2.Value = changedRow.ItemArray[14];
                                    UpdateCommand.Parameters.Add(odp2);

                                    OleDbParameter odp3 = new OleDbParameter("@ID", OleDbType.Integer, 16);
                                    odp3.Value = changedRow.ItemArray[0];
                                    UpdateCommand.Parameters.Add(odp3);

                                    UpdateCommand.ExecuteNonQuery();
                                    iCount++;
                                }
                                this.lblSysMessage.Text = "已经成功保存 " + iCount.ToString() + " 条评分数据。";
                                frmObjectEval.dsEvaluation._dsEvaluation.AcceptChanges();
                            }
                            catch (Exception exc)
                            {
                                MessageBox.Show("保存数据过程中出现了问题。" +
                                    "数据库返回错误信息:\n\r" + exc.Message + "\n\n\r" +
                                    "未能保存的行会使用红色显示。",
                                    Application.ProductName, MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                                this.lblSysMessage.Text = @"保存数据过程中出现了问题。" +
                                    "数据库返回错误信息:" + exc.Message + "" +
                                    "未能保存的行会使用红色显示。";
                            }
                        }
                        else
                        {
                            this.lblSysMessage.Text = "当前数据没有修改，无需保存";
                            //MessageBox.Show("当前数据没有修改，无需保存", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
                default: {
                            MessageBox.Show("不支持此表单的保存操作。");
                            break;
                        }
            }
        }

        private void btnEvalSummary_Click(object sender, CommandEventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "frmEvalSummary")
                {
                    frm.Activate();
                    frm.Focus();
                    return;
                }
            }
            frmEvalSummary frmEvalSummary = new frmEvalSummary();
            frmEvalSummary.MdiParent = this;
            frmEvalSummary.Show();
        }

        private void btn1Level_Click(object sender, CommandEventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "frmInput")
                {
                    frm.Activate();
                    frm.Focus();
                    return;
                }
            }
            frmInput frmInput = new frmInput();
            frmInput.MdiParent = this;
            frmInput.Show();
        }


       
        private void btnUserManage_Click(object sender, CommandEventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "frmUser")
                {
                    frm.Activate();
                    frm.Focus();
                    return;
                }
            }
            frmUser frmUser = new frmUser();
            frmUser.MdiParent = this;
            frmUser.Show();
        }

        private void btnExit_Click(object sender, CommandEventArgs e)
        {
            if (MessageBox.Show("确定退出本系统吗？", "提示",//弹出消息对话框
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                Application.Exit();//退出应用程序
            }
        }

        private void buttonCommand6_Click(object sender, CommandEventArgs e)
        {
            if (MessageBox.Show("确定退出本系统吗？", "提示",//弹出消息对话框
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                Application.Exit();//退出应用程序
            }
        }

        private void buttonCommand10_Click(object sender, CommandEventArgs e)
        {

            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "frmEquipment")
                {
                    frm.Activate();
                    frm.Focus();
                    return;
                }
            }
            frmMaterial frmEquipment = new frmMaterial();
            frmEquipment.MdiParent = this;
            frmEquipment.Show();

        }

        private void buttonCommand2_Click(object sender, CommandEventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "frmSubmitData")
                {
                    frm.Activate();
                    frm.Focus();
                    return;
                }
            }
            frmSubmitData frmSubmitData = new frmSubmitData();
            frmSubmitData.MdiParent = this;
            frmSubmitData.Show();
        }

        private void buttonCommand4_Click(object sender, CommandEventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "frmDrug")
                {
                    frm.Activate();
                    frm.Focus();
                    return;
                }
            }
            frmDrug frmDrug = new frmDrug();
            frmDrug.MdiParent = this;
            frmDrug.Show();
        }

        private void buttonCommand5_Click(object sender, CommandEventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "frmDrugInuse")
                {
                    frm.Activate();
                    frm.Focus();
                    return;
                }
            }
            frmDrugInuse frmDrugInuse = new frmDrugInuse();
            frmDrugInuse.MdiParent = this;
            frmDrugInuse.Show();
        }

        private void buttonCommand8_Click(object sender, CommandEventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "frmMaterial")
                {
                    frm.Activate();
                    frm.Focus();
                    return;
                }
            }
            frmMaterial frmMaterial = new frmMaterial();
            frmMaterial.MdiParent = this;
            frmMaterial.Show();


        }

        private void btnHospital_Click(object sender, CommandEventArgs e)
        {

            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "frmHospital")
                {
                    frm.Activate();
                    frm.Focus();
                    return;
                }
            }
            frmHospital frmHospital = new frmHospital();
            frmHospital.MdiParent = this;
            frmHospital.Show();

        }

        private void buttonCommand3_Click(object sender, CommandEventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "frmSubmitDataModel")
                {
                    frm.Activate();
                    frm.Focus();
                    return;
                }
            }
            frmSubmitDataModel frmSubmitDataModel = new frmSubmitDataModel();
            frmSubmitDataModel.MdiParent = this;
            frmSubmitDataModel.Show();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        

        private void cboHospital_ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.cboHospital.ComboBox.SelectedValue == null || this.cboYear.ComboBox.SelectedValue == null) return;
            hid = int.Parse(this.cboHospital.ComboBox.SelectedValue.ToString());
            yid = int.Parse(this.cboYear.ComboBox.SelectedValue.ToString());

            this.hpes_submit_dataTableAdapter.Fill(this.dsSubmitData.hpes_submit_data, hid, yid);
            this.gridEX1.Refresh();
            this.hpes_drugTableAdapter.Fill(this.dsDrug.hpes_drug, hid, yid);
            this.gridEX2.Refresh();
            this.hpes_materialTableAdapter.Fill(this.dsMaterial.hpes_material, hid, yid);
            this.gridEX3.Refresh();
            this.hpes_cijunbiTableAdapter.Fill(this.dsCiJunBi.hpes_cijunbi, hid, yid);
            this.gridEX4.Refresh();

        }

        private void cboYear_ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.cboHospital.ComboBox.SelectedValue == null || this.cboYear.ComboBox.SelectedValue == null) return;
            hid = int.Parse(this.cboHospital.ComboBox.SelectedValue.ToString());
            yid = int.Parse(this.cboYear.ComboBox.SelectedValue.ToString());

            this.hpes_submit_dataTableAdapter.Fill(this.dsSubmitData.hpes_submit_data, hid, yid);
            this.gridEX1.Refresh();
            this.hpes_drugTableAdapter.Fill(this.dsDrug.hpes_drug, hid, yid);
            this.gridEX2.Refresh();
            this.hpes_materialTableAdapter.Fill(this.dsMaterial.hpes_material, hid, yid);
            this.gridEX3.Refresh();
            this.hpes_cijunbiTableAdapter.Fill(this.dsCiJunBi.hpes_cijunbi, hid, yid);
            this.gridEX4.Refresh();

        }

        private void buttonCommand11_Click(object sender, CommandEventArgs e)
        {

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();


            saveFileDialog1.Filter = "Excel 文件(*.xls)|*.xls|Excel 文件(*.xlsx)|*.xlsx|所有文件(*.*)|*.*";//以文件“*.xls”导出

            saveFileDialog1.FileName = cboHospital.ComboBox.Text + "_" + cboYear.ComboBox.Text;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string sFilePathName = saveFileDialog1.FileName;

                // MessageBox.Show(sFilePathName);

                DataSet ds = new DataSet();

                DataTable dtdrug = new DataTable("医院在用药品");
                DataRow drdrug = dtdrug.NewRow();

                //dtdrug.Columns.Add("序号", System.Type.GetType("System.String"));
                dtdrug.Columns.Add("药品编码", System.Type.GetType("System.String"));
                dtdrug.Columns.Add("药品名称", System.Type.GetType("System.String"));
                dtdrug.Columns.Add("药品规格", System.Type.GetType("System.String"));
                dtdrug.Columns.Add("药品单位", System.Type.GetType("System.String"));
                dtdrug.Columns.Add("药品厂家", System.Type.GetType("System.String"));
                dtdrug.Columns.Add("抗菌药", System.Type.GetType("System.String"));
                dtdrug.Columns.Add("中标", System.Type.GetType("System.String"));
                dtdrug.Columns.Add("统计", System.Type.GetType("System.String"));
                dtdrug.Rows.Add(drdrug);



                DataTable dtmaterial = new DataTable("医用耗材");
                DataRow drmaterial = dtmaterial.NewRow();
                // dtmaterial.Columns.Add("序号", System.Type.GetType("System.String"));
                dtmaterial.Columns.Add("耗材编码", System.Type.GetType("System.String"));
                dtmaterial.Columns.Add("耗材名称", System.Type.GetType("System.String"));
                dtmaterial.Columns.Add("耗材单位", System.Type.GetType("System.String"));
                dtmaterial.Columns.Add("耗材厂家", System.Type.GetType("System.String"));
                dtmaterial.Columns.Add("耗材规格", System.Type.GetType("System.String"));
                dtmaterial.Columns.Add("中标", System.Type.GetType("System.String"));
                dtmaterial.Columns.Add("统计", System.Type.GetType("System.String"));



                //DataTable dtbasedata = new DataTable("基础数据");

                //DataTable dtbasedata=dsSubmitData.Tables[0].Copy();
                //DataRow drbasedata = dtbasedata.NewRow();
                //// dtbasedata.Columns.Add("序号", System.Type.GetType("System.String"));
                //dtbasedata.Columns.Add("名称", System.Type.GetType("System.String"));
                //dtbasedata.Columns.Add("值", System.Type.GetType("System.String"));
                //dtbasedata.Columns.Add("说明", System.Type.GetType("System.String"));
                //string sql = "select NAME AS 名称,VALUE AS 值,info AS 说明 from hpes_submit_data where hid=(select id from hpes_hospital where name='" + cboHospital.ComboBox.Text + "') and yid=(select yid from hpes_time where year='" + cboYear.ComboBox.Text+"')";

                string sql = "select NAME AS 名称,info AS 说明 from hpes_submit_dictionary";

                DataTable dtbasedata = new DBOperate().GetSubmitData(sql).Copy();
                dtbasedata.Columns.Add("值",typeof(string));
                //dtbasedata.Columns.Add("HID", typeof(int));
                dtbasedata.TableName = "基础数据";
                ds.Tables.Add(dtbasedata);
                ds.Tables.Add(dtmaterial);
                ds.Tables.Add(dtdrug);

                MessageBox.Show(DataSetToExcell.ExportToExcel(ds, sFilePathName));
            }


        }

        private void buttonCommand10_Click_1(object sender, CommandEventArgs e)
        {
            openFileDialog1.FileName = cboHospital.ComboBox.Text + "_" + cboYear.ComboBox.Text + ".xls";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                TransferData(openFileDialog1.FileName);


            }
        }









        public void TransferData(string excelFile)
        {
            DBOperate operate = new DBOperate();//创建操作数据库对象

            int hid = operate.GetIdByName("select id from hpes_hospital where name='" + cboHospital.ComboBox.Text + "'");

            int yid = operate.GetIdByName("select yid from hpes_time where year='" + cboYear.ComboBox.Text + "'");

            try
            {

                //string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + excelFile + ";" + "Extended Properties='Excel 12.0;HDR=YES;IMEX=1;'"
                ;
                string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + excelFile + ";" + "Extended Properties='Excel 12.0;HDR=YES;IMEX=1;'";


                //(1)HDR表示要把第一行作为数据还是作为列名,作为数据用HDR=no,作为列名用HDR=yes;通过Imex=1来把混合型作为文本型读取,避免 null值。 

                //(2)左右两个单引号不能少 


                OleDbConnection conn = new OleDbConnection(strConn);

                conn.Open();

                DataSet ds = new DataSet();

                DataTable dtSheetName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });

                string[] strTableNames = new string[dtSheetName.Rows.Count]; //包含excel中表名的字符串数组 

                for (int k = 0; k < dtSheetName.Rows.Count; k++)
                {
                    strTableNames[k] = dtSheetName.Rows[k]["TABLE_NAME"].ToString();


                    string sheetName = strTableNames[k].Substring(0, strTableNames[k].Length - 1);

                    string targetTable = "";

                    string strExcel = "";

                    if (sheetName.Equals("基础数据"))
                    {
                        targetTable = "hpes_submit_data";

                        strExcel = "select 名称,值,说明 from [" + strTableNames[k] + "]";

                    }
                    else if (sheetName.Equals("医用耗材"))
                    {
                        targetTable = "hpes_material";

                        strExcel = "select 耗材编码,耗材名称,耗材单位,耗材厂家,耗材规格,中标,统计 from [" + strTableNames[k] + "]";
                    }
                    else if (sheetName.Equals("医院在用药品"))
                    {

                        targetTable = "hpes_drug";

                        //strexcel = "select 药品编码,药品名称,药品规格,药品单位,药品厂家,抗菌药,中标,统计 from [" + strtablenames[k] + "]";
                        strExcel = "select * from [" + strTableNames[k] + "]";


                    }




                    OleDbDataAdapter myCommand = null;

                    myCommand = new OleDbDataAdapter(strExcel, strConn);

                    myCommand.Fill(ds, sheetName);

                    ds.Tables[k].Columns.Add("HID", typeof(int));

                    ds.Tables[k].Columns.Add("YID", typeof(int));

                    if (sheetName.Equals("基础数据"))
                    {

                        for (int i = 0; i < ds.Tables[sheetName].Rows.Count; i++) //开始循环赋值
                        {
                            //ds.Tables[k].Rows[i]["HID"] = hid;
                            //ds.Tables[k].Rows[i]["YID"] = yid;


                            string sql = "if exists (select * from hpes_submit_data where name='" + ds.Tables[k].Rows[i]["名称"] + "')"
                                + "begin update hpes_submit_data set value='" + ds.Tables[k].Rows[i]["值"] + "',info='" + ds.Tables[k].Rows[i]["说明"] + "',hid=" + hid + ",yid=" + yid
                                + " where name='" + ds.Tables[k].Rows[i]["名称"] + "' end"
                                + " else begin insert into hpes_submit_data(name,value,info,hid,yid) values('" + ds.Tables[k].Rows[i]["名称"] + "','" + ds.Tables[k].Rows[i]["值"] + "','" + ds.Tables[k].Rows[i]["说明"] + "'," + hid + "," + yid + ") end";

                            //string sql = "insert into hpes_submit_data(name,value,info,hid,yid) values('" + ds.Tables[k].Rows[i]["名称"] + "','" + ds.Tables[k].Rows[i]["值"] + "','" + ds.Tables[k].Rows[i]["说明"] + "'," + hid + "," + yid + ")";

                            int num = new DBOperate().UpdateSubmitData(sql);

                          

                        }


                    }
                    else
                    {

                        for (int i = 0; i < ds.Tables[k].Rows.Count; i++) //开始循环赋值
                        {
                            ds.Tables[k].Rows[i]["HID"] = hid;
                            ds.Tables[k].Rows[i]["YID"] = yid;

                        }




                        System.Data.SqlClient.SqlBulkCopy bcp = DBConnection.SqlBulkCopy();

                        using (bcp)
                        {

                            bcp.SqlRowsCopied += new System.Data.SqlClient.SqlRowsCopiedEventHandler(bcp_SqlRowsCopied);
                            bcp.BatchSize = 100;//每次传输的行数
                            bcp.NotifyAfter = 100;//进度提示的行数
                            bcp.DestinationTableName = targetTable;//目标表

                            if (sheetName.Equals("医用耗材"))
                            {

                                bcp.ColumnMappings.Add("耗材编码", "MCODE");
                                bcp.ColumnMappings.Add("耗材名称", "NAME");
                                bcp.ColumnMappings.Add("耗材单位", "UNIT");
                                bcp.ColumnMappings.Add("耗材厂家", "FACTORY");
                                bcp.ColumnMappings.Add("耗材规格", "SPECIFICATION");
                                bcp.ColumnMappings.Add("中标", "BID");
                                bcp.ColumnMappings.Add("统计", "STATISTICS");
                                bcp.ColumnMappings.Add("HID", "HID");
                                bcp.ColumnMappings.Add("YID", "YID");

                            }
                            else if (sheetName.Equals("医院在用药品"))
                            {

                                bcp.ColumnMappings.Add("药品编码", "DCODE");
                                bcp.ColumnMappings.Add("药品名称", "NAME");
                                bcp.ColumnMappings.Add("药品规格", "SPECIFICATION");
                                bcp.ColumnMappings.Add("药品单位", "UNIT");
                                bcp.ColumnMappings.Add("药品厂家", "FACTORY");
                                bcp.ColumnMappings.Add("抗菌药", "ANTIBACTERIAL");
                                bcp.ColumnMappings.Add("中标", "BID");
                                bcp.ColumnMappings.Add("统计", "STATISTICS");
                                bcp.ColumnMappings.Add("HID", "HID");
                                bcp.ColumnMappings.Add("YID", "YID");
                            }

                            bcp.WriteToServer(ds.Tables[k]);
                            bcp.Close();



                    }

                    }

                    lblSysMessage.Visible = true;
                    uiProgressBar1.Visible = true;
                    uiProgressBar1.Value = 0;
                    uiProgressBar1.Minimum = 0;
                    uiProgressBar1.Maximum = ds.Tables[k].Rows.Count;
                    // MessageBox.Show("进度条长度"+uiProgressBar1.Maximum.ToString());


                    for (int i = 0; i < uiProgressBar1.Maximum; i++)
                    {
                        uiProgressBar1.Value = i + 1;

                        Application.DoEvents();

                        this.lblSysMessage.Text = Convert.ToString("已经导入" + uiProgressBar1.Value + "条数据");
                    }



                }

                conn.Close();

                MessageBox.Show("数据导入成功！");


            }
            catch (Exception ex)
            {
                MessageBox.Show("数据导入异常！请检查文件名称及数据格式。");
            }

        }

        //进度显示
        void bcp_SqlRowsCopied(object sender, System.Data.SqlClient.SqlRowsCopiedEventArgs e)
        {
            this.Text = e.RowsCopied.ToString();
            this.Update();
        }

        private void btn2Level_Click(object sender, CommandEventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "frmInput")
                {
                    frm.Activate();
                    frm.Focus();
                    return;
                }
            }
            frmInput frmInput = new frmInput();
            frmInput.MdiParent = this;
            frmInput.Show();
        }

        private void btn3Level_Click(object sender, CommandEventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "frmInput")
                {
                    frm.Activate();
                    frm.Focus();
                    return;
                }
            }
            frmInput frmInput = new frmInput();
            frmInput.MdiParent = this;
            frmInput.Show();
        }

        private void btnOption_Click(object sender, CommandEventArgs e)
        {
            MessageBox.Show("暂无操作");
        }

        private void btnQuery_Click(object sender, CommandEventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "frmQuery")
                {
                    frm.Activate();
                    frm.Focus();
                    return;
                }
            }
            frmQuery frmQuery = new frmQuery();
            frmQuery.MdiParent = this;
            frmQuery.Show();
        }




    }
}
