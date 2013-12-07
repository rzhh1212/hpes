using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HPES
{
    public partial class frmInput : Form
    {
        public frmInput()
        {
            InitializeComponent();
        }

        private void frmInput_Load(object sender, EventArgs e)
        {

            // TODO: 这行代码将数据加载到表“dsStandard.DataTable1”中。您可以根据需要移动或移除它。
            this.dsStandardTableAdapter.Fill(this.dsStandard._dsStandard);

        }


    }
}
