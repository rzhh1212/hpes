using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HPES.Formview.Userview
{
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }


        
        private void frmUser_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“dsUser.ds_user”中。您可以根据需要移动或移除它。
            this.dsUserTableAdapter.Fill(this.dsUser.ds_user);
            // TODO: 这行代码将数据加载到表“dsUser.ds_user”中。您可以根据需要移动或移除它。
            this.dsUserTableAdapter.Fill(this.dsUser.ds_user);

        }

        

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void ds_userBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.ds_userBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsUser);

        }

    }
}
