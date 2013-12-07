using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using Janus.Windows.GridEX.Export;
using System.Data.OleDb;
using HPES.Formview.Main;



namespace HPES
{
    public partial class frmObjectEval : Form
    {
        public frmObjectEval()
        {
            InitializeComponent();
        }

        public int hid;
        public int yid;

        private void frmObjectEval_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“dsEvaluation._dsEvaluation”中。您可以根据需要移动或移除它。
            frmMain frm=(frmMain)this.ParentForm;
            if (frm.cboHospital.ComboBox.SelectedValue == null || frm.cboYear.ComboBox.SelectedValue==null) {
                MessageBox.Show("请先选择要考评的医院和考评年度。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            hid = int.Parse(frm.cboHospital.ComboBox.SelectedValue.ToString());
            yid = int.Parse(frm.cboYear.ComboBox.SelectedValue.ToString());

            this.dsEvaluationTableAdapter.Fill(this.dsEvaluation._dsEvaluation, hid, yid);
        

        }


    }
}
