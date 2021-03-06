﻿namespace HPES.Formview.Bookview
{
    partial class frmDrug
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDrug));
            this.dsDrug1 = new HPES.dsDrug();
            this.hpes_drugBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hpes_drugTableAdapter = new HPES.dsDrugTableAdapters.hpes_drugTableAdapter();
            this.tableAdapterManager = new HPES.dsDrugTableAdapters.TableAdapterManager();
            this.hpes_drugBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.hpes_drugBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.hpes_drugDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dsDrug1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hpes_drugBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hpes_drugBindingNavigator)).BeginInit();
            this.hpes_drugBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hpes_drugDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dsDrug1
            // 
            this.dsDrug1.DataSetName = "dsDrug";
            this.dsDrug1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hpes_drugBindingSource
            // 
            this.hpes_drugBindingSource.DataMember = "hpes_drug";
            this.hpes_drugBindingSource.DataSource = this.dsDrug1;
            // 
            // hpes_drugTableAdapter
            // 
            this.hpes_drugTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.hpes_drugTableAdapter = this.hpes_drugTableAdapter;
            this.tableAdapterManager.UpdateOrder = HPES.dsDrugTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // hpes_drugBindingNavigator
            // 
            this.hpes_drugBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.hpes_drugBindingNavigator.BindingSource = this.hpes_drugBindingSource;
            this.hpes_drugBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.hpes_drugBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.hpes_drugBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.hpes_drugBindingNavigatorSaveItem,
            this.toolStripButton1});
            this.hpes_drugBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.hpes_drugBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.hpes_drugBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.hpes_drugBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.hpes_drugBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.hpes_drugBindingNavigator.Name = "hpes_drugBindingNavigator";
            this.hpes_drugBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.hpes_drugBindingNavigator.Size = new System.Drawing.Size(912, 25);
            this.hpes_drugBindingNavigator.TabIndex = 0;
            this.hpes_drugBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "新添";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(32, 22);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "总项数";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "删除";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "移到第一条记录";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "移到上一条记录";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "位置";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "当前位置";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "移到下一条记录";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "移到最后一条记录";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // hpes_drugBindingNavigatorSaveItem
            // 
            this.hpes_drugBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.hpes_drugBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("hpes_drugBindingNavigatorSaveItem.Image")));
            this.hpes_drugBindingNavigatorSaveItem.Name = "hpes_drugBindingNavigatorSaveItem";
            this.hpes_drugBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.hpes_drugBindingNavigatorSaveItem.Text = "保存数据";
            this.hpes_drugBindingNavigatorSaveItem.Click += new System.EventHandler(this.hpes_drugBindingNavigatorSaveItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "数据导入";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // hpes_drugDataGridView
            // 
            this.hpes_drugDataGridView.AutoGenerateColumns = false;
            this.hpes_drugDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hpes_drugDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewCheckBoxColumn1});
            this.hpes_drugDataGridView.DataSource = this.hpes_drugBindingSource;
            this.hpes_drugDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hpes_drugDataGridView.Location = new System.Drawing.Point(0, 25);
            this.hpes_drugDataGridView.Name = "hpes_drugDataGridView";
            this.hpes_drugDataGridView.RowTemplate.Height = 23;
            this.hpes_drugDataGridView.Size = new System.Drawing.Size(912, 399);
            this.hpes_drugDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "序号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DCODE";
            this.dataGridViewTextBoxColumn2.HeaderText = "药品编码";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "HID";
            this.dataGridViewTextBoxColumn3.HeaderText = "医院编码";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "YID";
            this.dataGridViewTextBoxColumn4.HeaderText = "年度";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "NAME";
            this.dataGridViewTextBoxColumn5.HeaderText = "名称";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "SPECIFICATION";
            this.dataGridViewTextBoxColumn6.HeaderText = "药品规格";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "FACTORY";
            this.dataGridViewTextBoxColumn8.HeaderText = "药品厂家";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "BID";
            this.dataGridViewCheckBoxColumn1.HeaderText = "是否中标";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmDrug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 424);
            this.Controls.Add(this.hpes_drugDataGridView);
            this.Controls.Add(this.hpes_drugBindingNavigator);
            this.Name = "frmDrug";
            this.Text = "抗菌药物目录";
            this.Load += new System.EventHandler(this.dsDrug_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsDrug1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hpes_drugBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hpes_drugBindingNavigator)).EndInit();
            this.hpes_drugBindingNavigator.ResumeLayout(false);
            this.hpes_drugBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hpes_drugDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HPES.dsDrug dsDrug1;
        private System.Windows.Forms.BindingSource hpes_drugBindingSource;
        private HPES.dsDrugTableAdapters.hpes_drugTableAdapter hpes_drugTableAdapter;
        private HPES.dsDrugTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator hpes_drugBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton hpes_drugBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView hpes_drugDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}