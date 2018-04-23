using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace WindowsApplication1
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn colProduct;
		private DevExpress.XtraGrid.Columns.GridColumn colInStock;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit InStockCheckEdit;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit MachineCheckEdit;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProduct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.InStockCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.MachineCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InStockCheckEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MachineCheckEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.InStockCheckEdit,
            this.MachineCheckEdit});
            this.gridControl1.Size = new System.Drawing.Size(390, 272);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProduct,
            this.colInStock});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView1_CustomUnboundColumnData);
            this.gridView1.Click += new System.EventHandler(this.gridView1_Click);
            // 
            // colProduct
            // 
            this.colProduct.Caption = "Product";
            this.colProduct.FieldName = "Product";
            this.colProduct.Name = "colProduct";
            this.colProduct.Visible = true;
            this.colProduct.VisibleIndex = 0;
            // 
            // colInStock
            // 
            this.colInStock.Caption = "In Stock";
            this.colInStock.ColumnEdit = this.InStockCheckEdit;
            this.colInStock.FieldName = "UnboundChecked";
            this.colInStock.Name = "colInStock";
            this.colInStock.OptionsColumn.AllowEdit = false;
            this.colInStock.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.colInStock.Visible = true;
            this.colInStock.VisibleIndex = 1;
            // 
            // InStockCheckEdit
            // 
            this.InStockCheckEdit.AutoHeight = false;
            this.InStockCheckEdit.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.InStockCheckEdit.Name = "InStockCheckEdit";
            // 
            // MachineCheckEdit
            // 
            this.MachineCheckEdit.AutoHeight = false;
            this.MachineCheckEdit.Name = "MachineCheckEdit";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(390, 272);
            this.Controls.Add(this.gridControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InStockCheckEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MachineCheckEdit)).EndInit();
            this.ResumeLayout(false);

        }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			DataTable myTable = new DataTable();
			myTable.Columns.Add("Product");

            for(int i = 1; i <= 3; i++)
			    myTable.Rows.Add("Product " + i.ToString());
			
			gridControl1.DataSource = myTable;
			PrevCheckedRow = 0;
            CheckedRow = gridView1.GetRow(0);
		}

        private int PrevCheckedRow; // this is the selected row's handle
        object CheckedRow; // this is a DataRowView instance
        
		private void gridView1_Click(object sender, System.EventArgs e) {
			GridView view = sender as GridView;
			GridHitInfo hit = view.CalcHitInfo(view.GridControl.PointToClient(MousePosition));
			if(hit.InRowCell && hit.Column.FieldName == "UnboundChecked" 
                && hit.RowHandle != PrevCheckedRow) {
                CheckedRow = view.GetRow(hit.RowHandle);
                view.RefreshRow(PrevCheckedRow);
				PrevCheckedRow = hit.RowHandle;
                view.RefreshRow(PrevCheckedRow);
			}
		}

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e) {
            if(e.Column.FieldName == "UnboundChecked") {
                if(e.IsGetData) 
                    e.Value = (gridView1.GetRow(e.RowHandle) == CheckedRow);
            }
        }
	}
}
