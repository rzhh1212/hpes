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
    public partial class frmQuery : Form
    {
        public frmQuery()
        {
            InitializeComponent();
        }

        private void hpes_queryBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.hpes_queryBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsQuery);

        }

        private void frmQuery_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“dsQuery.hpes_query”中。您可以根据需要移动或移除它。
            this.hpes_queryTableAdapter.Fill(this.dsQuery.hpes_query);

        }
    }
}
