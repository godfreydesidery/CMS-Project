<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPackingList
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPackingList))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtIssueNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.dtgrdPackingLists = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtTotalAmountIssued = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTotalReturns = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTotalDiscounts = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTotalExpenditures = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTotalBankCash = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCostOfGoodsSold = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtTotalPreviousReturns = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtTotalPacked = New System.Windows.Forms.TextBox()
        Me.btnDeficit = New System.Windows.Forms.Button()
        Me.txtTotalSales = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtDebt = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTotalDamages = New System.Windows.Forms.TextBox()
        Me.dtgrdItemList = New System.Windows.Forms.DataGridView()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtCPrice = New System.Windows.Forms.TextBox()
        Me.btnChange = New System.Windows.Forms.Button()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtReturns = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtPacked = New System.Windows.Forms.TextBox()
        Me.cmbDescription = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtQtyDamaged = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtQtySold = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtQtyReturned = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtIssued = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.txtPackSize = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnSearchItem = New System.Windows.Forms.Button()
        Me.txtStockSize = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtBarCode = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtItemCode = New System.Windows.Forms.TextBox()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmbSalesPersons = New System.Windows.Forms.ComboBox()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.txtIssueDate = New System.Windows.Forms.TextBox()
        Me.txtCustomerAddress = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtCustomerName = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cntxtMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnRemove = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnEdit = New System.Windows.Forms.ToolStripButton()
        Me.btnClear = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCancel = New System.Windows.Forms.ToolStripButton()
        Me.btnApprove = New System.Windows.Forms.ToolStripButton()
        Me.btnPrint = New System.Windows.Forms.ToolStripButton()
        Me.btnComplete = New System.Windows.Forms.ToolStripButton()
        Me.btnClearDebt = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnArchive = New System.Windows.Forms.ToolStripButton()
        Me.btnArchiveAll = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnPrintReport = New System.Windows.Forms.ToolStripButton()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        CType(Me.dtgrdPackingLists, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgrdItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.cntxtMenu.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(47, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Issue No"
        '
        'txtIssueNo
        '
        Me.txtIssueNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIssueNo.Location = New System.Drawing.Point(117, 3)
        Me.txtIssueNo.Name = "txtIssueNo"
        Me.txtIssueNo.ReadOnly = True
        Me.txtIssueNo.Size = New System.Drawing.Size(100, 24)
        Me.txtIssueNo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(35, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Issue Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "S/M Officer"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(65, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 17)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Status"
        '
        'txtStatus
        '
        Me.txtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(118, 100)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(187, 24)
        Me.txtStatus.TabIndex = 7
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(256, 4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(100, 40)
        Me.btnSearch.TabIndex = 9
        Me.btnSearch.Text = "&Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'dtgrdPackingLists
        '
        Me.dtgrdPackingLists.AllowUserToAddRows = False
        Me.dtgrdPackingLists.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgrdPackingLists.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdPackingLists.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dtgrdPackingLists.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dtgrdPackingLists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrdPackingLists.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3})
        Me.dtgrdPackingLists.Location = New System.Drawing.Point(3, 6)
        Me.dtgrdPackingLists.Name = "dtgrdPackingLists"
        Me.dtgrdPackingLists.ReadOnly = True
        Me.dtgrdPackingLists.RowTemplate.Height = 24
        Me.dtgrdPackingLists.Size = New System.Drawing.Size(804, 236)
        Me.dtgrdPackingLists.TabIndex = 67
        '
        'DataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn1.FillWeight = 42.63959!
        Me.DataGridViewTextBoxColumn1.HeaderText = "Issue No"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.FillWeight = 59.71546!
        Me.DataGridViewTextBoxColumn2.HeaderText = "Issue Date"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.FillWeight = 197.6449!
        Me.DataGridViewTextBoxColumn3.HeaderText = "Summary"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'txtTotalAmountIssued
        '
        Me.txtTotalAmountIssued.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalAmountIssued.Location = New System.Drawing.Point(144, 69)
        Me.txtTotalAmountIssued.Name = "txtTotalAmountIssued"
        Me.txtTotalAmountIssued.ReadOnly = True
        Me.txtTotalAmountIssued.Size = New System.Drawing.Size(127, 24)
        Me.txtTotalAmountIssued.TabIndex = 73
        Me.txtTotalAmountIssued.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(37, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 17)
        Me.Label5.TabIndex = 72
        Me.Label5.Text = "Amount Issued"
        '
        'txtTotalReturns
        '
        Me.txtTotalReturns.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalReturns.Location = New System.Drawing.Point(144, 135)
        Me.txtTotalReturns.Name = "txtTotalReturns"
        Me.txtTotalReturns.ReadOnly = True
        Me.txtTotalReturns.Size = New System.Drawing.Size(127, 24)
        Me.txtTotalReturns.TabIndex = 75
        Me.txtTotalReturns.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(24, 267)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 17)
        Me.Label6.TabIndex = 74
        Me.Label6.Text = "Total Bank/Cash"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(44, 135)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 17)
        Me.Label7.TabIndex = 76
        Me.Label7.Text = "Total Returns"
        '
        'txtTotalDiscounts
        '
        Me.txtTotalDiscounts.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDiscounts.Location = New System.Drawing.Point(144, 201)
        Me.txtTotalDiscounts.Name = "txtTotalDiscounts"
        Me.txtTotalDiscounts.Size = New System.Drawing.Size(127, 24)
        Me.txtTotalDiscounts.TabIndex = 79
        Me.txtTotalDiscounts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(28, 201)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(106, 17)
        Me.Label8.TabIndex = 78
        Me.Label8.Text = "Total Discounts"
        '
        'txtTotalExpenditures
        '
        Me.txtTotalExpenditures.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalExpenditures.Location = New System.Drawing.Point(144, 234)
        Me.txtTotalExpenditures.Name = "txtTotalExpenditures"
        Me.txtTotalExpenditures.Size = New System.Drawing.Size(127, 24)
        Me.txtTotalExpenditures.TabIndex = 81
        Me.txtTotalExpenditures.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(32, 168)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 17)
        Me.Label9.TabIndex = 80
        Me.Label9.Text = "Total Damages"
        '
        'txtTotalBankCash
        '
        Me.txtTotalBankCash.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalBankCash.Location = New System.Drawing.Point(144, 267)
        Me.txtTotalBankCash.Name = "txtTotalBankCash"
        Me.txtTotalBankCash.Size = New System.Drawing.Size(127, 24)
        Me.txtTotalBankCash.TabIndex = 83
        Me.txtTotalBankCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(11, 234)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(125, 17)
        Me.Label10.TabIndex = 82
        Me.Label10.Text = "Total expenditures"
        '
        'txtCostOfGoodsSold
        '
        Me.txtCostOfGoodsSold.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCostOfGoodsSold.Location = New System.Drawing.Point(279, 329)
        Me.txtCostOfGoodsSold.Name = "txtCostOfGoodsSold"
        Me.txtCostOfGoodsSold.ReadOnly = True
        Me.txtCostOfGoodsSold.Size = New System.Drawing.Size(135, 24)
        Me.txtCostOfGoodsSold.TabIndex = 102
        Me.txtCostOfGoodsSold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(108, 335)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(165, 17)
        Me.Label29.TabIndex = 101
        Me.Label29.Text = "Cost Value of goods sold"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(47, 8)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(91, 17)
        Me.Label26.TabIndex = 95
        Me.Label26.Text = "Prev Returns"
        '
        'txtTotalPreviousReturns
        '
        Me.txtTotalPreviousReturns.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPreviousReturns.Location = New System.Drawing.Point(144, 3)
        Me.txtTotalPreviousReturns.Name = "txtTotalPreviousReturns"
        Me.txtTotalPreviousReturns.ReadOnly = True
        Me.txtTotalPreviousReturns.Size = New System.Drawing.Size(127, 24)
        Me.txtTotalPreviousReturns.TabIndex = 96
        Me.txtTotalPreviousReturns.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(47, 36)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(91, 17)
        Me.Label25.TabIndex = 93
        Me.Label25.Text = "Total Packed"
        '
        'txtTotalPacked
        '
        Me.txtTotalPacked.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPacked.Location = New System.Drawing.Point(144, 36)
        Me.txtTotalPacked.Name = "txtTotalPacked"
        Me.txtTotalPacked.ReadOnly = True
        Me.txtTotalPacked.Size = New System.Drawing.Size(127, 24)
        Me.txtTotalPacked.TabIndex = 94
        Me.txtTotalPacked.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnDeficit
        '
        Me.btnDeficit.Location = New System.Drawing.Point(279, 272)
        Me.btnDeficit.Name = "btnDeficit"
        Me.btnDeficit.Size = New System.Drawing.Size(135, 51)
        Me.btnDeficit.TabIndex = 92
        Me.btnDeficit.Text = "Calculate Deficit"
        Me.btnDeficit.UseVisualStyleBackColor = True
        '
        'txtTotalSales
        '
        Me.txtTotalSales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalSales.Location = New System.Drawing.Point(144, 102)
        Me.txtTotalSales.Name = "txtTotalSales"
        Me.txtTotalSales.ReadOnly = True
        Me.txtTotalSales.Size = New System.Drawing.Size(127, 24)
        Me.txtTotalSales.TabIndex = 90
        Me.txtTotalSales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(59, 102)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(79, 17)
        Me.Label14.TabIndex = 91
        Me.Label14.Text = "Total Sales"
        '
        'txtDebt
        '
        Me.txtDebt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDebt.Location = New System.Drawing.Point(144, 300)
        Me.txtDebt.Name = "txtDebt"
        Me.txtDebt.Size = New System.Drawing.Size(127, 24)
        Me.txtDebt.TabIndex = 85
        Me.txtDebt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(44, 300)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(91, 17)
        Me.Label11.TabIndex = 84
        Me.Label11.Text = "Deficit (Debt)"
        '
        'txtTotalDamages
        '
        Me.txtTotalDamages.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDamages.Location = New System.Drawing.Point(144, 168)
        Me.txtTotalDamages.Name = "txtTotalDamages"
        Me.txtTotalDamages.ReadOnly = True
        Me.txtTotalDamages.Size = New System.Drawing.Size(127, 24)
        Me.txtTotalDamages.TabIndex = 77
        Me.txtTotalDamages.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtgrdItemList
        '
        Me.dtgrdItemList.AllowUserToAddRows = False
        Me.dtgrdItemList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgrdItemList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdItemList.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dtgrdItemList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dtgrdItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrdItemList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column8, Me.Column9, Me.Column10, Me.Column2, Me.Column3, Me.Column11, Me.Column13, Me.Column12, Me.Column14, Me.Column1, Me.Column4})
        Me.dtgrdItemList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtgrdItemList.Location = New System.Drawing.Point(430, 379)
        Me.dtgrdItemList.Name = "dtgrdItemList"
        Me.dtgrdItemList.ReadOnly = True
        Me.dtgrdItemList.RowTemplate.Height = 24
        Me.dtgrdItemList.Size = New System.Drawing.Size(1304, 484)
        Me.dtgrdItemList.TabIndex = 90
        '
        'Column8
        '
        Me.Column8.FillWeight = 61.77913!
        Me.Column8.HeaderText = "Item Code"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.FillWeight = 233.4812!
        Me.Column9.HeaderText = "Description"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column10
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column10.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column10.FillWeight = 89.8288!
        Me.Column10.HeaderText = "Price"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Returns"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Packed"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column11
        '
        Me.Column11.FillWeight = 85.86243!
        Me.Column11.HeaderText = "Total Issued"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        '
        'Column13
        '
        Me.Column13.FillWeight = 76.53453!
        Me.Column13.HeaderText = "Qty Sold"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        '
        'Column12
        '
        Me.Column12.FillWeight = 81.44789!
        Me.Column12.HeaderText = "Qty Returned"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        '
        'Column14
        '
        Me.Column14.FillWeight = 71.06599!
        Me.Column14.HeaderText = "Qty Damaged"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "id"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'Column4
        '
        Me.Column4.HeaderText = "CPrice"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label28)
        Me.Panel2.Controls.Add(Me.txtCPrice)
        Me.Panel2.Controls.Add(Me.btnChange)
        Me.Panel2.Controls.Add(Me.Label24)
        Me.Panel2.Controls.Add(Me.txtReturns)
        Me.Panel2.Controls.Add(Me.Label23)
        Me.Panel2.Controls.Add(Me.txtPacked)
        Me.Panel2.Controls.Add(Me.cmbDescription)
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Controls.Add(Me.txtQtyDamaged)
        Me.Panel2.Controls.Add(Me.Label21)
        Me.Panel2.Controls.Add(Me.txtQtySold)
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Controls.Add(Me.txtQtyReturned)
        Me.Panel2.Controls.Add(Me.Label19)
        Me.Panel2.Controls.Add(Me.txtIssued)
        Me.Panel2.Controls.Add(Me.btnAdd)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.btnReset)
        Me.Panel2.Controls.Add(Me.txtPackSize)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.btnSearchItem)
        Me.Panel2.Controls.Add(Me.txtStockSize)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.txtBarCode)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.txtItemCode)
        Me.Panel2.Controls.Add(Me.txtPrice)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Location = New System.Drawing.Point(7, 6)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(800, 248)
        Me.Panel2.TabIndex = 93
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(44, 151)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(72, 17)
        Me.Label28.TabIndex = 105
        Me.Label28.Text = "Cost Price"
        '
        'txtCPrice
        '
        Me.txtCPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCPrice.Location = New System.Drawing.Point(118, 151)
        Me.txtCPrice.MaxLength = 50
        Me.txtCPrice.Name = "txtCPrice"
        Me.txtCPrice.ReadOnly = True
        Me.txtCPrice.Size = New System.Drawing.Size(116, 24)
        Me.txtCPrice.TabIndex = 106
        Me.txtCPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnChange
        '
        Me.btnChange.Location = New System.Drawing.Point(238, 121)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(50, 25)
        Me.btnChange.TabIndex = 104
        Me.btnChange.Text = "<c>"
        Me.btnChange.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(374, 5)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(58, 17)
        Me.Label24.TabIndex = 102
        Me.Label24.Text = "Returns"
        '
        'txtReturns
        '
        Me.txtReturns.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReturns.Location = New System.Drawing.Point(439, 7)
        Me.txtReturns.MaxLength = 50
        Me.txtReturns.Name = "txtReturns"
        Me.txtReturns.Size = New System.Drawing.Size(115, 24)
        Me.txtReturns.TabIndex = 103
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(377, 38)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(55, 17)
        Me.Label23.TabIndex = 100
        Me.Label23.Text = "Packed"
        '
        'txtPacked
        '
        Me.txtPacked.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPacked.Location = New System.Drawing.Point(438, 37)
        Me.txtPacked.MaxLength = 50
        Me.txtPacked.Name = "txtPacked"
        Me.txtPacked.Size = New System.Drawing.Size(115, 24)
        Me.txtPacked.TabIndex = 101
        '
        'cmbDescription
        '
        Me.cmbDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDescription.FormattingEnabled = True
        Me.cmbDescription.Location = New System.Drawing.Point(3, 86)
        Me.cmbDescription.Name = "cmbDescription"
        Me.cmbDescription.Size = New System.Drawing.Size(344, 28)
        Me.cmbDescription.TabIndex = 99
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(579, 66)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(95, 17)
        Me.Label22.TabIndex = 61
        Me.Label22.Text = "Qty Damaged"
        '
        'txtQtyDamaged
        '
        Me.txtQtyDamaged.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtyDamaged.Location = New System.Drawing.Point(678, 66)
        Me.txtQtyDamaged.MaxLength = 50
        Me.txtQtyDamaged.Name = "txtQtyDamaged"
        Me.txtQtyDamaged.Size = New System.Drawing.Size(115, 24)
        Me.txtQtyDamaged.TabIndex = 62
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(609, 10)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(62, 17)
        Me.Label21.TabIndex = 59
        Me.Label21.Text = "Qty Sold"
        '
        'txtQtySold
        '
        Me.txtQtySold.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtySold.Location = New System.Drawing.Point(678, 7)
        Me.txtQtySold.MaxLength = 50
        Me.txtQtySold.Name = "txtQtySold"
        Me.txtQtySold.Size = New System.Drawing.Size(115, 24)
        Me.txtQtySold.TabIndex = 60
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(578, 38)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(93, 17)
        Me.Label20.TabIndex = 57
        Me.Label20.Text = "Qty Returned"
        '
        'txtQtyReturned
        '
        Me.txtQtyReturned.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtyReturned.Location = New System.Drawing.Point(678, 38)
        Me.txtQtyReturned.MaxLength = 50
        Me.txtQtyReturned.Name = "txtQtyReturned"
        Me.txtQtyReturned.Size = New System.Drawing.Size(115, 24)
        Me.txtQtyReturned.TabIndex = 58
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(349, 70)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(85, 17)
        Me.Label19.TabIndex = 55
        Me.Label19.Text = "Total Issued"
        '
        'txtIssued
        '
        Me.txtIssued.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIssued.Location = New System.Drawing.Point(439, 70)
        Me.txtIssued.MaxLength = 50
        Me.txtIssued.Name = "txtIssued"
        Me.txtIssued.ReadOnly = True
        Me.txtIssued.Size = New System.Drawing.Size(115, 24)
        Me.txtIssued.TabIndex = 56
        '
        'btnAdd
        '
        Me.btnAdd.Enabled = False
        Me.btnAdd.Location = New System.Drawing.Point(439, 105)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(120, 40)
        Me.btnAdd.TabIndex = 53
        Me.btnAdd.Text = "Add/Update"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(44, 184)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(70, 17)
        Me.Label15.TabIndex = 42
        Me.Label15.Text = "Pack Size"
        Me.Label15.Visible = False
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(565, 105)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(100, 40)
        Me.btnReset.TabIndex = 54
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'txtPackSize
        '
        Me.txtPackSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPackSize.Location = New System.Drawing.Point(118, 181)
        Me.txtPackSize.MaxLength = 50
        Me.txtPackSize.Name = "txtPackSize"
        Me.txtPackSize.ReadOnly = True
        Me.txtPackSize.Size = New System.Drawing.Size(116, 24)
        Me.txtPackSize.TabIndex = 44
        Me.txtPackSize.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(42, 209)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(74, 17)
        Me.Label17.TabIndex = 46
        Me.Label17.Text = "Stock Size"
        Me.Label17.Visible = False
        '
        'btnSearchItem
        '
        Me.btnSearchItem.Location = New System.Drawing.Point(238, 4)
        Me.btnSearchItem.Name = "btnSearchItem"
        Me.btnSearchItem.Size = New System.Drawing.Size(100, 40)
        Me.btnSearchItem.TabIndex = 51
        Me.btnSearchItem.Text = "Search"
        Me.btnSearchItem.UseVisualStyleBackColor = True
        '
        'txtStockSize
        '
        Me.txtStockSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockSize.Location = New System.Drawing.Point(118, 209)
        Me.txtStockSize.MaxLength = 50
        Me.txtStockSize.Name = "txtStockSize"
        Me.txtStockSize.ReadOnly = True
        Me.txtStockSize.Size = New System.Drawing.Size(116, 24)
        Me.txtStockSize.TabIndex = 48
        Me.txtStockSize.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(44, 37)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 17)
        Me.Label12.TabIndex = 37
        Me.Label12.Text = "Item Code"
        '
        'txtBarCode
        '
        Me.txtBarCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarCode.Location = New System.Drawing.Point(117, 4)
        Me.txtBarCode.MaxLength = 50
        Me.txtBarCode.Name = "txtBarCode"
        Me.txtBarCode.Size = New System.Drawing.Size(115, 27)
        Me.txtBarCode.TabIndex = 50
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(4, 66)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 17)
        Me.Label13.TabIndex = 38
        Me.Label13.Text = "Description"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(50, 7)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(61, 17)
        Me.Label16.TabIndex = 49
        Me.Label16.Text = "Barcode"
        '
        'txtItemCode
        '
        Me.txtItemCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemCode.Location = New System.Drawing.Point(117, 35)
        Me.txtItemCode.MaxLength = 50
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.Size = New System.Drawing.Size(115, 27)
        Me.txtItemCode.TabIndex = 39
        '
        'txtPrice
        '
        Me.txtPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice.Location = New System.Drawing.Point(118, 120)
        Me.txtPrice.MaxLength = 50
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.ReadOnly = True
        Me.txtPrice.Size = New System.Drawing.Size(114, 24)
        Me.txtPrice.TabIndex = 47
        Me.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(30, 121)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(86, 17)
        Me.Label18.TabIndex = 45
        Me.Label18.Text = "Selling Price"
        '
        'cmbSalesPersons
        '
        Me.cmbSalesPersons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSalesPersons.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbSalesPersons.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSalesPersons.FormattingEnabled = True
        Me.cmbSalesPersons.Location = New System.Drawing.Point(118, 62)
        Me.cmbSalesPersons.Name = "cmbSalesPersons"
        Me.cmbSalesPersons.Size = New System.Drawing.Size(291, 26)
        Me.cmbSalesPersons.TabIndex = 94
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(6, 4)
        Me.txtId.Name = "txtId"
        Me.txtId.ReadOnly = True
        Me.txtId.Size = New System.Drawing.Size(23, 22)
        Me.txtId.TabIndex = 95
        Me.txtId.Visible = False
        '
        'txtIssueDate
        '
        Me.txtIssueDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIssueDate.Location = New System.Drawing.Point(117, 31)
        Me.txtIssueDate.Name = "txtIssueDate"
        Me.txtIssueDate.ReadOnly = True
        Me.txtIssueDate.Size = New System.Drawing.Size(101, 24)
        Me.txtIssueDate.TabIndex = 96
        '
        'txtCustomerAddress
        '
        Me.txtCustomerAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerAddress.Location = New System.Drawing.Point(119, 160)
        Me.txtCustomerAddress.Name = "txtCustomerAddress"
        Me.txtCustomerAddress.Size = New System.Drawing.Size(290, 24)
        Me.txtCustomerAddress.TabIndex = 100
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(15, 160)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(95, 17)
        Me.Label31.TabIndex = 99
        Me.Label31.Text = "Addr&&Contact"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(4, 130)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(109, 17)
        Me.Label30.TabIndex = 97
        Me.Label30.Text = "Customer Name"
        '
        'txtCustomerName
        '
        Me.txtCustomerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerName.Location = New System.Drawing.Point(119, 130)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.Size = New System.Drawing.Size(290, 24)
        Me.txtCustomerName.TabIndex = 98
        '
        'Label27
        '
        Me.Label27.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(1289, 359)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(457, 17)
        Me.Label27.TabIndex = 100
        Me.Label27.Text = "Item list (Maximum entries: 200) (Click to select, Double click to remove)"
        '
        'cntxtMenu
        '
        Me.cntxtMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cntxtMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnRemove})
        Me.cntxtMenu.Name = "cntxtMenu"
        Me.cntxtMenu.Size = New System.Drawing.Size(167, 28)
        '
        'mnRemove
        '
        Me.mnRemove.Name = "mnRemove"
        Me.mnRemove.Size = New System.Drawing.Size(166, 24)
        Me.mnRemove.Text = "Remove Item"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnEdit, Me.btnClear, Me.btnSave, Me.ToolStripSeparator1, Me.ToolStripSeparator2, Me.ToolStripSeparator3, Me.ToolStripSeparator4, Me.btnCancel, Me.btnApprove, Me.btnPrint, Me.btnComplete, Me.btnClearDebt, Me.ToolStripSeparator6, Me.btnArchive, Me.btnArchiveAll, Me.ToolStripSeparator5, Me.btnPrintReport})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1746, 27)
        Me.ToolStrip1.TabIndex = 101
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnNew
        '
        Me.btnNew.Image = Global.BackOffice.My.Resources.Resources.new_file
        Me.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(63, 24)
        Me.btnNew.Text = "New"
        Me.btnNew.ToolTipText = "Creates a new Packing List"
        '
        'btnEdit
        '
        Me.btnEdit.Image = Global.BackOffice.My.Resources.Resources.pencil
        Me.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(59, 24)
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.ToolTipText = "Promts user to edit an existing Packing List"
        '
        'btnClear
        '
        Me.btnClear.Image = Global.BackOffice.My.Resources.Resources.brush
        Me.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(67, 24)
        Me.btnClear.Text = "Clear"
        Me.btnClear.ToolTipText = "Clear all the fields"
        '
        'btnSave
        '
        Me.btnSave.Image = Global.BackOffice.My.Resources.Resources.floppy_disk
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(64, 24)
        Me.btnSave.Text = "Save"
        Me.btnSave.ToolTipText = "Save details of a new or existing Packing List"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 27)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 27)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 27)
        '
        'btnCancel
        '
        Me.btnCancel.Image = Global.BackOffice.My.Resources.Resources.cancel
        Me.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(77, 24)
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.ToolTipText = "Cancels the packing list"
        '
        'btnApprove
        '
        Me.btnApprove.Image = Global.BackOffice.My.Resources.Resources.tick
        Me.btnApprove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(90, 24)
        Me.btnApprove.Text = "Approve"
        Me.btnApprove.ToolTipText = "Approve the Packing List"
        '
        'btnPrint
        '
        Me.btnPrint.Image = Global.BackOffice.My.Resources.Resources.printer
        Me.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(63, 24)
        Me.btnPrint.Text = "Print"
        Me.btnPrint.ToolTipText = "Removes items from stock and print the packing list to pdf"
        '
        'btnComplete
        '
        Me.btnComplete.Image = Global.BackOffice.My.Resources.Resources.foward_arrow
        Me.btnComplete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnComplete.Name = "btnComplete"
        Me.btnComplete.Size = New System.Drawing.Size(160, 24)
        Me.btnComplete.Text = "Complete and post"
        Me.btnComplete.ToolTipText = "Complete sales made from the packing list"
        '
        'btnClearDebt
        '
        Me.btnClearDebt.Enabled = False
        Me.btnClearDebt.Image = Global.BackOffice.My.Resources.Resources.money
        Me.btnClearDebt.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClearDebt.Name = "btnClearDebt"
        Me.btnClearDebt.Size = New System.Drawing.Size(92, 24)
        Me.btnClearDebt.Text = "Pay Debt"
        Me.btnClearDebt.ToolTipText = "Receive debts from sales persons"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 27)
        '
        'btnArchive
        '
        Me.btnArchive.Image = CType(resources.GetObject("btnArchive.Image"), System.Drawing.Image)
        Me.btnArchive.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnArchive.Name = "btnArchive"
        Me.btnArchive.Size = New System.Drawing.Size(82, 24)
        Me.btnArchive.Text = "Archive"
        Me.btnArchive.ToolTipText = "Sends a completed packing list to archives for future references"
        '
        'btnArchiveAll
        '
        Me.btnArchiveAll.Image = CType(resources.GetObject("btnArchiveAll.Image"), System.Drawing.Image)
        Me.btnArchiveAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnArchiveAll.Name = "btnArchiveAll"
        Me.btnArchiveAll.Size = New System.Drawing.Size(102, 24)
        Me.btnArchiveAll.Text = "Archive all"
        Me.btnArchiveAll.ToolTipText = "Sends all completed and cleared packing list to archives for future references"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 27)
        '
        'btnPrintReport
        '
        Me.btnPrintReport.Image = Global.BackOffice.My.Resources.Resources.printer
        Me.btnPrintReport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrintReport.Name = "btnPrintReport"
        Me.btnPrintReport.Size = New System.Drawing.Size(112, 24)
        Me.btnPrintReport.Text = "Print Report"
        Me.btnPrintReport.ToolTipText = "Print packing list as report to pdf"
        '
        'btnBack
        '
        Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBack.BackgroundImage = Global.BackOffice.My.Resources.Resources.red_back_arrow
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBack.Location = New System.Drawing.Point(1214, 9)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(100, 40)
        Me.btnBack.TabIndex = 92
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(6, 31)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(821, 279)
        Me.TabControl1.TabIndex = 102
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.Panel2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(813, 250)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Item Entry"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.dtgrdPackingLists)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(813, 250)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Packing Lists"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Panel8)
        Me.Panel4.Controls.Add(Me.Panel7)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(0, 27)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(420, 898)
        Me.Panel4.TabIndex = 103
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.txtCostOfGoodsSold)
        Me.Panel8.Controls.Add(Me.txtTotalPreviousReturns)
        Me.Panel8.Controls.Add(Me.Label29)
        Me.Panel8.Controls.Add(Me.Label8)
        Me.Panel8.Controls.Add(Me.Label26)
        Me.Panel8.Controls.Add(Me.Label7)
        Me.Panel8.Controls.Add(Me.txtTotalDiscounts)
        Me.Panel8.Controls.Add(Me.Label25)
        Me.Panel8.Controls.Add(Me.txtTotalReturns)
        Me.Panel8.Controls.Add(Me.txtTotalPacked)
        Me.Panel8.Controls.Add(Me.Label9)
        Me.Panel8.Controls.Add(Me.btnDeficit)
        Me.Panel8.Controls.Add(Me.Label6)
        Me.Panel8.Controls.Add(Me.txtTotalSales)
        Me.Panel8.Controls.Add(Me.txtTotalExpenditures)
        Me.Panel8.Controls.Add(Me.Label14)
        Me.Panel8.Controls.Add(Me.txtTotalAmountIssued)
        Me.Panel8.Controls.Add(Me.txtDebt)
        Me.Panel8.Controls.Add(Me.Label10)
        Me.Panel8.Controls.Add(Me.Label11)
        Me.Panel8.Controls.Add(Me.Label5)
        Me.Panel8.Controls.Add(Me.txtTotalDamages)
        Me.Panel8.Controls.Add(Me.txtTotalBankCash)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel8.Location = New System.Drawing.Point(0, 202)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(420, 696)
        Me.Panel8.TabIndex = 1
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.txtCustomerAddress)
        Me.Panel7.Controls.Add(Me.txtIssueNo)
        Me.Panel7.Controls.Add(Me.Label31)
        Me.Panel7.Controls.Add(Me.btnSearch)
        Me.Panel7.Controls.Add(Me.Label30)
        Me.Panel7.Controls.Add(Me.txtStatus)
        Me.Panel7.Controls.Add(Me.txtCustomerName)
        Me.Panel7.Controls.Add(Me.Label4)
        Me.Panel7.Controls.Add(Me.Label3)
        Me.Panel7.Controls.Add(Me.txtIssueDate)
        Me.Panel7.Controls.Add(Me.cmbSalesPersons)
        Me.Panel7.Controls.Add(Me.Label1)
        Me.Panel7.Controls.Add(Me.Label2)
        Me.Panel7.Controls.Add(Me.txtId)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(420, 196)
        Me.Panel7.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.TabControl1)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(420, 27)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1326, 329)
        Me.Panel5.TabIndex = 104
        '
        'Panel6
        '
        Me.Panel6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel6.Controls.Add(Me.btnBack)
        Me.Panel6.Location = New System.Drawing.Point(420, 869)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1326, 56)
        Me.Panel6.TabIndex = 105
        '
        'frmPackingList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1746, 925)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.dtgrdItemList)
        Me.Name = "frmPackingList"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Packing Lists and Returns"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtgrdPackingLists, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgrdItemList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.cntxtMenu.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtIssueNo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtStatus As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents dtgrdPackingLists As DataGridView
    Friend WithEvents txtTotalAmountIssued As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtTotalReturns As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtTotalDiscounts As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtTotalExpenditures As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtTotalBankCash As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents dtgrdItemList As DataGridView
    Friend WithEvents txtDebt As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents btnBack As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnReset As Button
    Friend WithEvents btnSearchItem As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents txtBarCode As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtItemCode As TextBox
    Friend WithEvents txtStockSize As TextBox
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents txtPackSize As TextBox
    Friend WithEvents cmbSalesPersons As ComboBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txtQtyDamaged As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents txtQtySold As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents txtQtyReturned As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtIssued As TextBox
    Friend WithEvents txtId As TextBox
    Friend WithEvents txtIssueDate As TextBox
    Friend WithEvents txtTotalDamages As TextBox
    Friend WithEvents cmbDescription As ComboBox
    Friend WithEvents txtTotalSales As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents btnDeficit As Button
    Friend WithEvents Label24 As Label
    Friend WithEvents txtReturns As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents txtPacked As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents txtTotalPreviousReturns As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents txtTotalPacked As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents cntxtMenu As ContextMenuStrip
    Friend WithEvents mnRemove As ToolStripMenuItem
    Friend WithEvents btnChange As Button
    Friend WithEvents Label28 As Label
    Friend WithEvents txtCPrice As TextBox
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column13 As DataGridViewTextBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
    Friend WithEvents Column14 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents txtCostOfGoodsSold As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnNew As ToolStripButton
    Friend WithEvents btnEdit As ToolStripButton
    Friend WithEvents btnClear As ToolStripButton
    Friend WithEvents btnSave As ToolStripButton
    Friend WithEvents btnApprove As ToolStripButton
    Friend WithEvents btnArchive As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btnPrintReport As ToolStripButton
    Friend WithEvents btnCancel As ToolStripButton
    Friend WithEvents btnPrint As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents btnComplete As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents btnClearDebt As ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents btnArchiveAll As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents Label30 As Label
    Friend WithEvents txtCustomerName As TextBox
    Friend WithEvents txtCustomerAddress As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel8 As Panel
End Class
