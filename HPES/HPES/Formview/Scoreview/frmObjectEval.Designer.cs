namespace HPES
{
    partial class frmObjectEval
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmObjectEval));
            this.gridEX1 = new Janus.Windows.GridEX.GridEX();
            this.dsEvaluationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsEvaluation = new HPES.dsEvaluation();
            this.dsEvaluationTableAdapter = new HPES.dsEvaluationTableAdapters.dsEvaluationTableAdapter();
            this.tableAdapterManager = new HPES.dsEvaluationTableAdapters.TableAdapterManager();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.gridEXPrintDocument1 = new Janus.Windows.GridEX.GridEXPrintDocument();
            this.officeFormAdorner1 = new Janus.Windows.Ribbon.OfficeFormAdorner(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEvaluationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEvaluation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeFormAdorner1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridEX1
            // 
            this.gridEX1.AlternatingColors = true;
            this.gridEX1.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><GroupByBoxInfo>拖动表格列到" +
                "这里进行汇总显示</GroupByBoxInfo></LocalizableData>";
            this.gridEX1.ControlStyle.HoverBaseColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gridEX1.DataSource = this.dsEvaluationBindingSource;
            gridEX1_DesignTimeLayout.LayoutString = resources.GetString("gridEX1_DesignTimeLayout.LayoutString");
            this.gridEX1.DesignTimeLayout = gridEX1_DesignTimeLayout;
            this.gridEX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEX1.Font = new System.Drawing.Font("宋体", 9F);
            this.gridEX1.GroupExpandBoxStyle = Janus.Windows.GridEX.ExpandBoxStyle.Classic;
            this.gridEX1.GroupIndent = 12;
            this.gridEX1.GroupRowVisualStyle = Janus.Windows.GridEX.GroupRowVisualStyle.UseRowStyle;
            this.gridEX1.GroupTotals = Janus.Windows.GridEX.GroupTotals.ExpandedGroup;
            this.gridEX1.HasEditorsControlStyle = true;
            this.gridEX1.HeaderFormatStyle.Font = new System.Drawing.Font("宋体", 10.5F);
            this.gridEX1.HideColumnsWhenGrouped = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridEX1.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gridEX1.Location = new System.Drawing.Point(0, 0);
            this.gridEX1.Name = "gridEX1";
            this.gridEX1.Size = new System.Drawing.Size(1011, 500);
            this.gridEX1.TabIndex = 0;
            this.gridEX1.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.gridEX1.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridEX1.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.gridEX1.UpdateMode = Janus.Windows.GridEX.UpdateMode.CellUpdate;
            this.gridEX1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // dsEvaluationBindingSource
            // 
            this.dsEvaluationBindingSource.DataMember = "dsEvaluation";
            this.dsEvaluationBindingSource.DataSource = this.dsEvaluation;
            // 
            // dsEvaluation
            // 
            this.dsEvaluation.DataSetName = "dsEvaluation";
            this.dsEvaluation.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsEvaluationTableAdapter
            // 
            this.dsEvaluationTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = HPES.dsEvaluationTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // gridEXExporter1
            // 
            this.gridEXExporter1.GridEX = this.gridEX1;
            // 
            // gridEXPrintDocument1
            // 
            this.gridEXPrintDocument1.GridEX = this.gridEX1;
            this.gridEXPrintDocument1.PageHeaderLeft = "医院内涵建设指标量化考评管理系统";
            this.gridEXPrintDocument1.PageHeaderRight = "专家评分打印";
            // 
            // officeFormAdorner1
            // 
            this.officeFormAdorner1.Form = this;
            this.officeFormAdorner1.VisualStyle = Janus.Windows.Ribbon.VisualStyle.Office2010;
            // 
            // frmObjectEval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 500);
            this.Controls.Add(this.gridEX1);
            this.Name = "frmObjectEval";
            this.Text = "专家评分录入与编辑";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmObjectEval_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEvaluationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEvaluation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeFormAdorner1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.GridEX.GridEX gridEX1;
        private System.Windows.Forms.BindingSource dsEvaluationBindingSource;
        private HPES.dsEvaluationTableAdapters.dsEvaluationTableAdapter dsEvaluationTableAdapter;
        private HPES.dsEvaluationTableAdapters.TableAdapterManager tableAdapterManager;
        public Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        public Janus.Windows.GridEX.GridEXPrintDocument gridEXPrintDocument1;
        public dsEvaluation dsEvaluation;
        private Janus.Windows.Ribbon.OfficeFormAdorner officeFormAdorner1;
    }
}