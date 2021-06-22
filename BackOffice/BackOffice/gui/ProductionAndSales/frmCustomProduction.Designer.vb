<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomProduction
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtProductionNo = New System.Windows.Forms.TextBox()
        Me.txtBatchSize = New System.Windows.Forms.TextBox()
        Me.txtProductName = New System.Windows.Forms.TextBox()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbUom = New System.Windows.Forms.ComboBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.dtgrdProductionList = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnAddUpdate = New System.Windows.Forms.Button()
        Me.chklstMaterials = New System.Windows.Forms.CheckedListBox()
        Me.lstbxMaterials = New System.Windows.Forms.ListBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.lblUom = New System.Windows.Forms.Label()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtgrdItemList = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbDescription = New System.Windows.Forms.ComboBox()
        Me.btnSearchItem = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtBarCode = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtItemCode = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnProduction = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnComplete = New System.Windows.Forms.Button()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnArchive = New System.Windows.Forms.Button()
        CType(Me.dtgrdProductionList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.dtgrdItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Production No"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Product Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(35, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Batch Size"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(62, 144)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Status"
        '
        'txtProductionNo
        '
        Me.txtProductionNo.Location = New System.Drawing.Point(115, 12)
        Me.txtProductionNo.Name = "txtProductionNo"
        Me.txtProductionNo.Size = New System.Drawing.Size(138, 22)
        Me.txtProductionNo.TabIndex = 4
        '
        'txtBatchSize
        '
        Me.txtBatchSize.Location = New System.Drawing.Point(115, 85)
        Me.txtBatchSize.Name = "txtBatchSize"
        Me.txtBatchSize.ReadOnly = True
        Me.txtBatchSize.Size = New System.Drawing.Size(138, 22)
        Me.txtBatchSize.TabIndex = 5
        '
        'txtProductName
        '
        Me.txtProductName.Location = New System.Drawing.Point(115, 57)
        Me.txtProductName.Name = "txtProductName"
        Me.txtProductName.ReadOnly = True
        Me.txtProductName.Size = New System.Drawing.Size(242, 22)
        Me.txtProductName.TabIndex = 6
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(115, 144)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(138, 22)
        Me.txtStatus.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(69, 117)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 17)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "UOM"
        '
        'cmbUom
        '
        Me.cmbUom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUom.FormattingEnabled = True
        Me.cmbUom.Items.AddRange(New Object() {"", "KG", "LTR", "PCS"})
        Me.cmbUom.Location = New System.Drawing.Point(115, 114)
        Me.cmbUom.Name = "cmbUom"
        Me.cmbUom.Size = New System.Drawing.Size(138, 24)
        Me.cmbUom.TabIndex = 9
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(255, 11)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(101, 40)
        Me.btnSearch.TabIndex = 10
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'dtgrdProductionList
        '
        Me.dtgrdProductionList.AllowUserToAddRows = False
        Me.dtgrdProductionList.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgrdProductionList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdProductionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrdProductionList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.dtgrdProductionList.Location = New System.Drawing.Point(808, 12)
        Me.dtgrdProductionList.Name = "dtgrdProductionList"
        Me.dtgrdProductionList.ReadOnly = True
        Me.dtgrdProductionList.RowTemplate.Height = 24
        Me.dtgrdProductionList.Size = New System.Drawing.Size(687, 182)
        Me.dtgrdProductionList.TabIndex = 11
        '
        'Column1
        '
        Me.Column1.HeaderText = "Process no"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Issue Date"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Status"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 217)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(144, 17)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Select Material to use"
        '
        'btnAddUpdate
        '
        Me.btnAddUpdate.Enabled = False
        Me.btnAddUpdate.Location = New System.Drawing.Point(309, 237)
        Me.btnAddUpdate.Name = "btnAddUpdate"
        Me.btnAddUpdate.Size = New System.Drawing.Size(168, 47)
        Me.btnAddUpdate.TabIndex = 14
        Me.btnAddUpdate.Text = "Add Selected Materials"
        Me.btnAddUpdate.UseVisualStyleBackColor = True
        '
        'chklstMaterials
        '
        Me.chklstMaterials.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chklstMaterials.FormattingEnabled = True
        Me.chklstMaterials.Location = New System.Drawing.Point(12, 237)
        Me.chklstMaterials.Name = "chklstMaterials"
        Me.chklstMaterials.Size = New System.Drawing.Size(291, 548)
        Me.chklstMaterials.TabIndex = 15
        '
        'lstbxMaterials
        '
        Me.lstbxMaterials.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstbxMaterials.FormattingEnabled = True
        Me.lstbxMaterials.ItemHeight = 16
        Me.lstbxMaterials.Location = New System.Drawing.Point(483, 237)
        Me.lstbxMaterials.Name = "lstbxMaterials"
        Me.lstbxMaterials.Size = New System.Drawing.Size(319, 548)
        Me.lstbxMaterials.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(480, 217)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(250, 17)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Materials used(Click to edit or remove)"
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(362, 10)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(97, 41)
        Me.btnNew.TabIndex = 18
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(465, 10)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(97, 41)
        Me.btnEdit.TabIndex = 19
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(568, 10)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(97, 41)
        Me.btnSave.TabIndex = 21
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.btnAdd)
        Me.Panel1.Controls.Add(Me.btnReset)
        Me.Panel1.Controls.Add(Me.lblUom)
        Me.Panel1.Controls.Add(Me.txtQty)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.dtgrdItemList)
        Me.Panel1.Controls.Add(Me.cmbDescription)
        Me.Panel1.Controls.Add(Me.btnSearchItem)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.txtBarCode)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.txtItemCode)
        Me.Panel1.Location = New System.Drawing.Point(808, 237)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(687, 493)
        Me.Panel1.TabIndex = 22
        '
        'btnAdd
        '
        Me.btnAdd.Enabled = False
        Me.btnAdd.Location = New System.Drawing.Point(255, 104)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(120, 30)
        Me.btnAdd.TabIndex = 111
        Me.btnAdd.Text = "Add/Update"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(381, 104)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(120, 30)
        Me.btnReset.TabIndex = 112
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'lblUom
        '
        Me.lblUom.AutoSize = True
        Me.lblUom.Location = New System.Drawing.Point(214, 107)
        Me.lblUom.Name = "lblUom"
        Me.lblUom.Size = New System.Drawing.Size(35, 17)
        Me.lblUom.TabIndex = 110
        Me.lblUom.Text = "LTR"
        '
        'txtQty
        '
        Me.txtQty.Location = New System.Drawing.Point(93, 104)
        Me.txtQty.MaxLength = 50
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(115, 22)
        Me.txtQty.TabIndex = 109
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(57, 107)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 17)
        Me.Label9.TabIndex = 108
        Me.Label9.Text = "Qty"
        '
        'dtgrdItemList
        '
        Me.dtgrdItemList.AllowUserToAddRows = False
        Me.dtgrdItemList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgrdItemList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrdItemList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.Column4, Me.Column5})
        Me.dtgrdItemList.Location = New System.Drawing.Point(3, 155)
        Me.dtgrdItemList.Name = "dtgrdItemList"
        Me.dtgrdItemList.ReadOnly = True
        Me.dtgrdItemList.RowTemplate.Height = 24
        Me.dtgrdItemList.Size = New System.Drawing.Size(677, 331)
        Me.dtgrdItemList.TabIndex = 107
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Code"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Qty"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "UOM"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "sn"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Visible = False
        '
        'cmbDescription
        '
        Me.cmbDescription.FormattingEnabled = True
        Me.cmbDescription.Location = New System.Drawing.Point(93, 74)
        Me.cmbDescription.Name = "cmbDescription"
        Me.cmbDescription.Size = New System.Drawing.Size(408, 24)
        Me.cmbDescription.TabIndex = 106
        '
        'btnSearchItem
        '
        Me.btnSearchItem.Location = New System.Drawing.Point(214, 10)
        Me.btnSearchItem.Name = "btnSearchItem"
        Me.btnSearchItem.Size = New System.Drawing.Size(120, 53)
        Me.btnSearchItem.TabIndex = 105
        Me.btnSearchItem.Text = "Search"
        Me.btnSearchItem.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(20, 43)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 17)
        Me.Label12.TabIndex = 100
        Me.Label12.Text = "Item Code"
        '
        'txtBarCode
        '
        Me.txtBarCode.Location = New System.Drawing.Point(93, 10)
        Me.txtBarCode.MaxLength = 50
        Me.txtBarCode.Name = "txtBarCode"
        Me.txtBarCode.Size = New System.Drawing.Size(115, 22)
        Me.txtBarCode.TabIndex = 104
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(8, 77)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 17)
        Me.Label13.TabIndex = 101
        Me.Label13.Text = "Description"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(26, 13)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(61, 17)
        Me.Label16.TabIndex = 103
        Me.Label16.Text = "Barcode"
        '
        'txtItemCode
        '
        Me.txtItemCode.Location = New System.Drawing.Point(93, 41)
        Me.txtItemCode.MaxLength = 50
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.Size = New System.Drawing.Size(115, 22)
        Me.txtItemCode.TabIndex = 102
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(805, 217)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(121, 17)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Finished Products"
        '
        'btnProduction
        '
        Me.btnProduction.Location = New System.Drawing.Point(309, 290)
        Me.btnProduction.Name = "btnProduction"
        Me.btnProduction.Size = New System.Drawing.Size(168, 41)
        Me.btnProduction.TabIndex = 24
        Me.btnProduction.Text = "Approve"
        Me.btnProduction.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(309, 337)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(168, 41)
        Me.btnCancel.TabIndex = 25
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(309, 384)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(168, 41)
        Me.btnPrint.TabIndex = 26
        Me.btnPrint.Text = "Print Production sheet"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnComplete
        '
        Me.btnComplete.Location = New System.Drawing.Point(309, 431)
        Me.btnComplete.Name = "btnComplete"
        Me.btnComplete.Size = New System.Drawing.Size(168, 65)
        Me.btnComplete.TabIndex = 27
        Me.btnComplete.Text = "Complete Process"
        Me.btnComplete.UseVisualStyleBackColor = True
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(14, 35)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(40, 22)
        Me.txtId.TabIndex = 28
        Me.txtId.Visible = False
        '
        'txtDate
        '
        Me.txtDate.Location = New System.Drawing.Point(115, 172)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.ReadOnly = True
        Me.txtDate.Size = New System.Drawing.Size(138, 22)
        Me.txtDate.TabIndex = 29
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(72, 172)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 17)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "Date"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(671, 10)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(97, 41)
        Me.btnClear.TabIndex = 31
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnArchive
        '
        Me.btnArchive.Location = New System.Drawing.Point(309, 502)
        Me.btnArchive.Name = "btnArchive"
        Me.btnArchive.Size = New System.Drawing.Size(168, 53)
        Me.btnArchive.TabIndex = 32
        Me.btnArchive.Text = "Archive"
        Me.btnArchive.UseVisualStyleBackColor = True
        '
        'frmCustomProduction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1507, 789)
        Me.Controls.Add(Me.btnArchive)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.btnComplete)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnProduction)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lstbxMaterials)
        Me.Controls.Add(Me.chklstMaterials)
        Me.Controls.Add(Me.btnAddUpdate)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dtgrdProductionList)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.cmbUom)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.txtProductName)
        Me.Controls.Add(Me.txtBatchSize)
        Me.Controls.Add(Me.txtProductionNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmCustomProduction"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Custom Production"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtgrdProductionList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dtgrdItemList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtProductionNo As TextBox
    Friend WithEvents txtBatchSize As TextBox
    Friend WithEvents txtProductName As TextBox
    Friend WithEvents txtStatus As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbUom As ComboBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents dtgrdProductionList As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Label6 As Label
    Friend WithEvents btnAddUpdate As Button
    Friend WithEvents chklstMaterials As CheckedListBox
    Friend WithEvents lstbxMaterials As ListBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btnNew As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents cmbDescription As ComboBox
    Friend WithEvents btnSearchItem As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents txtBarCode As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtItemCode As TextBox
    Friend WithEvents dtgrdItemList As DataGridView
    Friend WithEvents txtQty As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents lblUom As Label
    Friend WithEvents btnProduction As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnComplete As Button
    Friend WithEvents txtId As TextBox
    Friend WithEvents txtDate As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents btnClear As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnReset As Button
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents btnArchive As Button
End Class
