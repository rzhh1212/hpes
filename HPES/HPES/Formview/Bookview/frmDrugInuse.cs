using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HPES.Formview.Main;


namespace HPES.Formview.Bookview
{
    public partial class frmDrugInuse : Form
    {
        public frmDrugInuse()
        {
            InitializeComponent();
        }

        private void hpes_drugBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.hpes_drugBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsDrug);

        }

        private void frmDrugInuse_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“dsDrug.hpes_drug”中。您可以根据需要移动或移除它。
            frmMain frm = (frmMain)this.ParentForm;
            this.hpes_drugTableAdapter.Fill(this.dsDrug.hpes_drug, (int)frm.cboHospital.ComboBox.SelectedValue, (int)frm.cboYear.ComboBox.SelectedValue);

        }
    }
}
