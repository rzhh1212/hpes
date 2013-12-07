namespace HPES
{
    partial class frmEvalSummary
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
            Janus.Windows.GridEX.GridEXLayout gridEX1_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEvalSummary));
            this.officeFormAdorner1 = new Janus.Windows.Ribbon.OfficeFormAdorner(this.components);
            this.gridEX1 = new Janus.Windows.GridEX.GridEX();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dsEvalSummaryOne = new HPES.dsEvalSummaryOne();
            this.dsEvalSummaryOneBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsEvalSummaryOneTableAdapter = new HPES.dsEvalSummaryOneTableAdapters.dsEvalSummaryOneTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.officeFormAdorner1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEvalSummaryOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEvalSummaryOneBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // officeFormAdorner1
            // 
            this.officeFormAdorner1.Form = this;
            this.officeFormAdorner1.OfficeCustomColor = System.Drawing.Color.Red;
            this.officeFormAdorner1.VisualStyle = Janus.Windows.Ribbon.VisualStyle.Office2010;
            // 
            // gridEX1
            // 
            this.gridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gridEX1.AlternatingColors = true;
            this.gridEX1.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><GroupByBoxInfo>拖动数据列到" +
                "这里进行汇总显示</GroupByBoxInfo><EmptyGridInfo>没有数据可供显示</EmptyGridInfo></LocalizableDat" +
                "a>";
            this.gridEX1.DataSource = this.dsEvalSummaryOneBindingSource;
            gridEX1_DesignTimeLayout.LayoutString = resources.GetString("gridEX1_DesignTimeLayout.LayoutString");
            this.gridEX1.DesignTimeLayout = gridEX1_DesignTimeLayout;
            this.gridEX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEX1.DynamicFiltering = true;
            this.gridEX1.EmptyRows = true;
            this.gridEX1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.gridEX1.Hierarchical = true;
            this.gridEX1.Location = new System.Drawing.Point(0, 0);
            this.gridEX1.Name = "gridEX1";
            this.gridEX1.Size = new System.Drawing.Size(874, 540);
            this.gridEX1.TabIndex = 0;
            this.gridEX1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.gridEX1.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.gridEX1_FormattingRow);
            this.gridEX1.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.gridEX1_LinkClicked);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.dsEvalSummaryOne;
            this.bindingSource1.Position = 0;
            // 
            // dsEvalSummaryOne
            // 
            this.dsEvalSummaryOne.DataSetName = "dsEvalSummaryOne";
            this.dsEvalSummaryOne.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsEvalSummaryOneBindingSource
            // 
            this.dsEvalSummaryOneBindingSource.DataMember = "dsEvalSummaryOne";
            this.dsEvalSummaryOneBindingSource.DataSource = this.bindingSource1;
            // 
            // dsEvalSummaryOneTableAdapter
            // 
            this.dsEvalSummaryOneTableAdapter.ClearBeforeFill = true;
            // 
            // frmEvalSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 540);
            this.Controls.Add(this.gridEX1);
            this.Name = "frmEvalSummary";
            this.Text = "评分汇总";
            this.Load += new System.EventHandler(this.frmEvalSummary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.officeFormAdorner1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEvalSummaryOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEvalSummaryOneBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.Ribbon.OfficeFormAdorner officeFormAdorner1;
        private Janus.Windows.GridEX.GridEX gridEX1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private dsEvalSummaryOne dsEvalSummaryOne;
        private System.Windows.Forms.BindingSource dsEvalSummaryOneBindingSource;
        private HPES.dsEvalSummaryOneTableAdapters.dsEvalSummaryOneTableAdapter dsEvalSummaryOneTableAdapter;
    }
}