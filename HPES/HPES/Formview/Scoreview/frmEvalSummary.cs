using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HPES.Formview.Main;

namespace HPES
{
    public partial class frmEvalSummary : Form
    {
        public frmEvalSummary()
        {
            InitializeComponent();
        }

        private void frmEvalSummary_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“dsEvalSummaryOne._dsEvalSummaryOne”中。您可以根据需要移动或移除它。
            this.dsEvalSummaryOneTableAdapter.Fill(this.dsEvalSummaryOne._dsEvalSummaryOne);
        }





        private void gridEX1_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            //MessageBox.Show(sender.ToString());
            frmMain frm = (frmMain)this.ParentForm;

            int hid = int.Parse(this.gridEX1.CurrentRow.Cells[0].Value.ToString());
            int yid = int.Parse(this.gridEX1.CurrentRow.Cells[3].Value.ToString());

            frm.cboHospital.ComboBox.SelectedValue=hid;
            frm.cboYear.ComboBox.SelectedValue=yid;
            if (e.Column.Caption == "主观评分")
            {
                foreach (Form frmTemp in frm.MdiChildren)
                {
                    if (frmTemp.Name == "frmObjectEval" && MessageBox.Show(this, "主观评分窗口当前已打开，要重新载入数据吗？\n\r重新载入可能丢失您当前尚未保存的数据，建议手工保存后再执行此操作。", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        frmTemp.Dispose();
                    }
                }
                frmObjectEval frmObjectEval = new frmObjectEval();
                frmObjectEval.MdiParent = frm;
                frmObjectEval.Show();
            }
            else
            {
                foreach (Form frmTemp in frm.MdiChildren)
                {
                    if (frmTemp.Name == "frmSubjectEval" && MessageBox.Show(this, "客观评分窗口当前已打开，要重新载入数据吗？\n\r重新载入可能丢失您当前尚未保存的数据，建议手工保存后再执行此操作。", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        frmTemp.Dispose();
                    }
                }
                frmSubjectEval frmSubjectEval = new frmSubjectEval();
                frmSubjectEval.MdiParent = frm;
                frmSubjectEval.Show();

            }
            
        }

        private void gridEX1_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {

        }

    }
}
