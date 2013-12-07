using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HPES.Model;
using System.Data.OleDb;
using System.Data.SqlClient;
using HPES.DBClass;

namespace HPES.Formview.Main
{
    public partial class OpenDialog : Form
    {
        public OpenDialog()
        {
            InitializeComponent();
        }

        private void OpenDialog_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                label1.Text = openFileDialog1.FileName;
               // ExcelToSql.(ctlPath.Text);

               DataTable dt= ExcelToSql.ExceltoDataSet(label1.Text);

               //ExcelToSql.InsertTable(dt);

               DA dw = new DA();

               dw.dataGridView1.DataSource = dt;

               dw.Show();

               ExcelToSql.InsertTable(dt);


            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog1 = new SaveFileDialog(); 
            
            saveFileDialog1.Filter = "Excel 文件(*.xls)|*.xls|Excel 文件(*.xlsx)|*.xlsx|所有文件(*.*)|*.*";//以文件“*.xls”导出
            
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {       
                
                string sFilePathName = saveFileDialog1.FileName;

                MessageBox.Show(sFilePathName);

                DataSet ds = new DataSet();

                DataTable dt1 = this.dsDrug.Tables[0].Copy();
                DataTable dt2 = this.dsMaterial.Tables[0].Copy();


                ds.Tables.Add(dt1);
                ds.Tables.Add(dt2);

                DataSetToExcell.ExportToExcel(ds, sFilePathName);

                
            
            }
            
    
            
            


        }


       

    

        
    }
}
