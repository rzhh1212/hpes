using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HPES.Formview.Main;
using HPES.Model;


namespace HPES.Formview.Bookview
{
    public partial class frmDrug : Form
    {
        public frmDrug()
        {
            InitializeComponent();
        }

        private void hpes_drugBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.hpes_drugBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsDrug1);

        }

        private void dsDrug_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“dsDrug1.hpes_drug”中。您可以根据需要移动或移除它。
            frmMain frm = (frmMain)this.ParentForm;
            this.hpes_drugTableAdapter.Fill(this.dsDrug1.hpes_drug, (int)frm.cboHospital.ComboBox.SelectedValue, (int)frm.cboYear.ComboBox.SelectedValue);

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                // ExcelToSql.(ctlPath.Text);

                DataTable dt = ExcelToSql.ExceltoDataSet(openFileDialog1.FileName);

                //ExcelToSql.InsertTable(dt);

                DA dw = new DA();

                dw.dataGridView1.DataSource = dt;

                dw.Show();

                ExcelToSql.InsertTable(dt);


            }




        }
    }
}
