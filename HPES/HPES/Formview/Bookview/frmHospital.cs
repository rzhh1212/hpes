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
    public partial class frmHospital : Form
    {
        public frmHospital()
        {
            InitializeComponent();
        }

        private void dsHospitalBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.dsHospitalBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsHospital);

        }

        private void frmHospital_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“dsHospital._dsHospital”中。您可以根据需要移动或移除它。
            this.dsHospitalTableAdapter.Fill(this.dsHospital._dsHospital);
            // TODO: 这行代码将数据加载到表“dsHospital._dsHospital”中。您可以根据需要移动或移除它。
            this.dsHospitalTableAdapter.Fill(this.dsHospital._dsHospital);

        }

        private void dsHospitalBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.dsHospitalBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsHospital);

        }
    }
}
