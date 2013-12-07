using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HPES.Formview.Bookview
{
    public partial class frmYear : Form
    {
        public frmYear()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“dsYear._dsYear”中。您可以根据需要移动或移除它。
            this.dsYearTableAdapter.Fill(this.dsYear._dsYear);


        }

        private void dsYearBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.dsYearBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsYear);

        }

        
    }
}
