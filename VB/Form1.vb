Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Namespace WindowsApplication1
	''' <summary>
	''' Summary description for Form1.
	''' </summary>
	Public Class Form1
		Inherits System.Windows.Forms.Form
		Private gridControl1 As DevExpress.XtraGrid.GridControl
		Private WithEvents gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
		Private colProduct As DevExpress.XtraGrid.Columns.GridColumn
		Private colInStock As DevExpress.XtraGrid.Columns.GridColumn
		Private InStockCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
		Private MachineCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			'
			' Required for Windows Form Designer support
			'
			InitializeComponent()

			'
			' TODO: Add any constructor code after InitializeComponent call
			'
		End Sub

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.colProduct = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colInStock = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.InStockCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
			Me.MachineCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.InStockCheckEdit, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.MachineCheckEdit, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' gridControl1
			' 
			Me.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.gridControl1.Location = New System.Drawing.Point(0, 0)
			Me.gridControl1.MainView = Me.gridView1
			Me.gridControl1.Name = "gridControl1"
			Me.gridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() { Me.InStockCheckEdit, Me.MachineCheckEdit})
			Me.gridControl1.Size = New System.Drawing.Size(390, 272)
			Me.gridControl1.TabIndex = 0
			Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1})
			' 
			' gridView1
			' 
			Me.gridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.colProduct, Me.colInStock})
			Me.gridView1.GridControl = Me.gridControl1
			Me.gridView1.Name = "gridView1"
			Me.gridView1.OptionsView.ShowGroupPanel = False
'			Me.gridView1.CustomUnboundColumnData += New DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(Me.gridView1_CustomUnboundColumnData);
'			Me.gridView1.Click += New System.EventHandler(Me.gridView1_Click);
			' 
			' colProduct
			' 
			Me.colProduct.Caption = "Product"
			Me.colProduct.FieldName = "Product"
			Me.colProduct.Name = "colProduct"
			Me.colProduct.Visible = True
			Me.colProduct.VisibleIndex = 0
			' 
			' colInStock
			' 
			Me.colInStock.Caption = "In Stock"
			Me.colInStock.ColumnEdit = Me.InStockCheckEdit
			Me.colInStock.FieldName = "UnboundChecked"
			Me.colInStock.Name = "colInStock"
			Me.colInStock.OptionsColumn.AllowEdit = False
			Me.colInStock.UnboundType = DevExpress.Data.UnboundColumnType.Boolean
			Me.colInStock.Visible = True
			Me.colInStock.VisibleIndex = 1
			' 
			' InStockCheckEdit
			' 
			Me.InStockCheckEdit.AutoHeight = False
			Me.InStockCheckEdit.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
			Me.InStockCheckEdit.Name = "InStockCheckEdit"
			' 
			' MachineCheckEdit
			' 
			Me.MachineCheckEdit.AutoHeight = False
			Me.MachineCheckEdit.Name = "MachineCheckEdit"
			' 
			' Form1
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(390, 272)
			Me.Controls.Add(Me.gridControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.InStockCheckEdit, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.MachineCheckEdit, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread> _
		Shared Sub Main()
			Application.Run(New Form1())
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Dim myTable As New DataTable()
			myTable.Columns.Add("Product")

			For i As Integer = 1 To 3
				myTable.Rows.Add("Product " & i.ToString())
			Next i

			gridControl1.DataSource = myTable
			PrevCheckedRow = 0
			CheckedRow = gridView1.GetRow(0)
		End Sub

		Private PrevCheckedRow As Integer ' this is the selected row's handle
		Private CheckedRow As Object ' this is a DataRowView instance

		Private Sub gridView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridView1.Click
			Dim view As GridView = TryCast(sender, GridView)
			Dim hit As GridHitInfo = view.CalcHitInfo(view.GridControl.PointToClient(MousePosition))
			If hit.InRowCell AndAlso hit.Column.FieldName = "UnboundChecked" AndAlso hit.RowHandle <> PrevCheckedRow Then
				CheckedRow = view.GetRow(hit.RowHandle)
				view.RefreshRow(PrevCheckedRow)
				PrevCheckedRow = hit.RowHandle
				view.RefreshRow(PrevCheckedRow)
			End If
		End Sub

		Private Sub gridView1_CustomUnboundColumnData(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles gridView1.CustomUnboundColumnData
			If e.Column.FieldName = "UnboundChecked" Then
				If e.IsGetData Then
					e.Value = (gridView1.GetRow(e.RowHandle) Is CheckedRow)
				End If
			End If
		End Sub
	End Class
End Namespace
