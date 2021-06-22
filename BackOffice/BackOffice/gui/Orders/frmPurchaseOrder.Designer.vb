<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPurchaseOrder
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSupplierCode = New System.Windows.Forms.TextBox()
        Me.dtgrdItemList = New System.Windows.Forms.DataGridView()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtOrderNo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.txtOrderDate = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtVaildUntil = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtOrderStatus = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbValidityPeriod = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.txtItemCodeS = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtPackSize = New System.Windows.Forms.TextBox()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtStockSize = New System.Windows.Forms.TextBox()
        Me.txtCostPrice = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtBarCode = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnSearchItem = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmbDescription = New System.Windows.Forms.ComboBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnApprove = New System.Windows.Forms.Button()
        Me.cmbSupplier = New System.Windows.Forms.ComboBox()
        CType(Me.dtgrdItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBack
        '
        Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBack.BackColor = System.Drawing.SystemColors.Control
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBack.Location = New System.Drawing.Point(1400, 704)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(115, 35)
        Me.btnBack.TabIndex = 10
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 17)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Supplier Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 17)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Supplier Name"
        '
        'txtSupplierCode
        '
        Me.txtSupplierCode.Location = New System.Drawing.Point(119, 42)
        Me.txtSupplierCode.MaxLength = 50
        Me.txtSupplierCode.Name = "txtSupplierCode"
        Me.txtSupplierCode.Size = New System.Drawing.Size(184, 22)
        Me.txtSupplierCode.TabIndex = 13
        '
        'dtgrdItemList
        '
        Me.dtgrdItemList.AllowUserToAddRows = False
        Me.dtgrdItemList.AllowUserToResizeColumns = False
        Me.dtgrdItemList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgrdItemList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdItemList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgrdItemList.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dtgrdItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrdItemList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column13, Me.Column7, Me.Column8, Me.Column10, Me.Column9, Me.Column11, Me.Column2, Me.Column12, Me.Column1})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgrdItemList.DefaultCellStyle = DataGridViewCellStyle1
        Me.dtgrdItemList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtgrdItemList.GridColor = System.Drawing.SystemColors.ActiveBorder
        Me.dtgrdItemList.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dtgrdItemList.Location = New System.Drawing.Point(443, 293)
        Me.dtgrdItemList.Name = "dtgrdItemList"
        Me.dtgrdItemList.ReadOnly = True
        Me.dtgrdItemList.RowTemplate.Height = 24
        Me.dtgrdItemList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dtgrdItemList.Size = New System.Drawing.Size(1072, 405)
        Me.dtgrdItemList.TabIndex = 16
        '
        'Column13
        '
        Me.Column13.HeaderText = "Bar Code"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        Me.Column13.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column13.Visible = False
        '
        'Column7
        '
        Me.Column7.FillWeight = 83.45177!
        Me.Column7.HeaderText = "Item Code"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.FillWeight = 182.7411!
        Me.Column8.HeaderText = "Description"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column10
        '
        Me.Column10.FillWeight = 83.45177!
        Me.Column10.HeaderText = "Pack Size"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.FillWeight = 83.45177!
        Me.Column9.HeaderText = "Quantity"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column11
        '
        Me.Column11.FillWeight = 83.45177!
        Me.Column11.HeaderText = "Cost Price@"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Total Cost"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column12
        '
        Me.Column12.FillWeight = 83.45177!
        Me.Column12.HeaderText = "Current Stock"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "Column1"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'txtOrderNo
        '
        Me.txtOrderNo.Location = New System.Drawing.Point(119, 14)
        Me.txtOrderNo.MaxLength = 50
        Me.txtOrderNo.Name = "txtOrderNo"
        Me.txtOrderNo.ReadOnly = True
        Me.txtOrderNo.Size = New System.Drawing.Size(184, 22)
        Me.txtOrderNo.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(46, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 17)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Order No"
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(443, 181)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(101, 49)
        Me.btnSave.TabIndex = 20
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(443, 12)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(101, 50)
        Me.btnNew.TabIndex = 21
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(443, 68)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(101, 48)
        Me.btnEdit.TabIndex = 22
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(443, 124)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(101, 51)
        Me.btnDelete.TabIndex = 23
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'txtOrderDate
        '
        Me.txtOrderDate.Location = New System.Drawing.Point(119, 98)
        Me.txtOrderDate.Name = "txtOrderDate"
        Me.txtOrderDate.ReadOnly = True
        Me.txtOrderDate.Size = New System.Drawing.Size(115, 22)
        Me.txtOrderDate.TabIndex = 25
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(34, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 17)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Order Date"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(24, 129)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 17)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Validity Days"
        '
        'txtVaildUntil
        '
        Me.txtVaildUntil.Location = New System.Drawing.Point(119, 159)
        Me.txtVaildUntil.Name = "txtVaildUntil"
        Me.txtVaildUntil.ReadOnly = True
        Me.txtVaildUntil.Size = New System.Drawing.Size(115, 22)
        Me.txtVaildUntil.TabIndex = 29
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(77, 162)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 17)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Until"
        '
        'txtOrderStatus
        '
        Me.txtOrderStatus.Location = New System.Drawing.Point(119, 187)
        Me.txtOrderStatus.Name = "txtOrderStatus"
        Me.txtOrderStatus.ReadOnly = True
        Me.txtOrderStatus.Size = New System.Drawing.Size(115, 22)
        Me.txtOrderStatus.TabIndex = 31
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(65, 187)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 17)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Status"
        '
        'cmbValidityPeriod
        '
        Me.cmbValidityPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbValidityPeriod.FormattingEnabled = True
        Me.cmbValidityPeriod.Items.AddRange(New Object() {"30", "7", "14", "21", "30", "45", "60"})
        Me.cmbValidityPeriod.Location = New System.Drawing.Point(119, 129)
        Me.cmbValidityPeriod.Name = "cmbValidityPeriod"
        Me.cmbValidityPeriod.Size = New System.Drawing.Size(115, 24)
        Me.cmbValidityPeriod.TabIndex = 32
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(98, 587)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 25)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "Total"
        '
        'txtTotal
        '
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(160, 587)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(280, 30)
        Me.txtTotal.TabIndex = 36
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtItemCodeS
        '
        Me.txtItemCodeS.Location = New System.Drawing.Point(89, 43)
        Me.txtItemCodeS.MaxLength = 50
        Me.txtItemCodeS.Name = "txtItemCodeS"
        Me.txtItemCodeS.Size = New System.Drawing.Size(230, 22)
        Me.txtItemCodeS.TabIndex = 39
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(5, 76)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 17)
        Me.Label10.TabIndex = 38
        Me.Label10.Text = "Description"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 45)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 17)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Item Code"
        '
        'txtPackSize
        '
        Me.txtPackSize.Location = New System.Drawing.Point(89, 155)
        Me.txtPackSize.MaxLength = 50
        Me.txtPackSize.Name = "txtPackSize"
        Me.txtPackSize.ReadOnly = True
        Me.txtPackSize.Size = New System.Drawing.Size(133, 22)
        Me.txtPackSize.TabIndex = 44
        '
        'txtQuantity
        '
        Me.txtQuantity.Location = New System.Drawing.Point(89, 99)
        Me.txtQuantity.MaxLength = 50
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(133, 22)
        Me.txtQuantity.TabIndex = 43
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(13, 155)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 17)
        Me.Label12.TabIndex = 42
        Me.Label12.Text = "Pack Size"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(22, 102)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(61, 17)
        Me.Label13.TabIndex = 41
        Me.Label13.Text = "Quantity"
        '
        'txtStockSize
        '
        Me.txtStockSize.Location = New System.Drawing.Point(89, 187)
        Me.txtStockSize.MaxLength = 50
        Me.txtStockSize.Name = "txtStockSize"
        Me.txtStockSize.ReadOnly = True
        Me.txtStockSize.Size = New System.Drawing.Size(133, 22)
        Me.txtStockSize.TabIndex = 48
        '
        'txtCostPrice
        '
        Me.txtCostPrice.Location = New System.Drawing.Point(89, 127)
        Me.txtCostPrice.MaxLength = 50
        Me.txtCostPrice.Name = "txtCostPrice"
        Me.txtCostPrice.ReadOnly = True
        Me.txtCostPrice.Size = New System.Drawing.Size(133, 22)
        Me.txtCostPrice.TabIndex = 47
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(9, 183)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(74, 17)
        Me.Label14.TabIndex = 46
        Me.Label14.Text = "Stock Size"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(13, 127)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 17)
        Me.Label15.TabIndex = 45
        Me.Label15.Text = "Cost Price"
        '
        'txtBarCode
        '
        Me.txtBarCode.Location = New System.Drawing.Point(89, 12)
        Me.txtBarCode.MaxLength = 50
        Me.txtBarCode.Name = "txtBarCode"
        Me.txtBarCode.Size = New System.Drawing.Size(230, 22)
        Me.txtBarCode.TabIndex = 50
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(22, 15)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(61, 17)
        Me.Label16.TabIndex = 49
        Me.Label16.Text = "Barcode"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(309, 14)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(99, 50)
        Me.btnSearch.TabIndex = 19
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnSearchItem
        '
        Me.btnSearchItem.Location = New System.Drawing.Point(325, 12)
        Me.btnSearchItem.Name = "btnSearchItem"
        Me.btnSearchItem.Size = New System.Drawing.Size(90, 53)
        Me.btnSearchItem.TabIndex = 51
        Me.btnSearchItem.Text = "Search"
        Me.btnSearchItem.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.cmbDescription)
        Me.Panel2.Controls.Add(Me.btnAdd)
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Controls.Add(Me.btnSearchItem)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.txtBarCode)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.txtItemCodeS)
        Me.Panel2.Controls.Add(Me.txtStockSize)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.txtCostPrice)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.txtQuantity)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.txtPackSize)
        Me.Panel2.Location = New System.Drawing.Point(12, 293)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(425, 288)
        Me.Panel2.TabIndex = 52
        '
        'cmbDescription
        '
        Me.cmbDescription.FormattingEnabled = True
        Me.cmbDescription.Location = New System.Drawing.Point(89, 71)
        Me.cmbDescription.Name = "cmbDescription"
        Me.cmbDescription.Size = New System.Drawing.Size(325, 24)
        Me.cmbDescription.TabIndex = 100
        '
        'btnAdd
        '
        Me.btnAdd.Enabled = False
        Me.btnAdd.Location = New System.Drawing.Point(228, 99)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(90, 50)
        Me.btnAdd.TabIndex = 53
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(324, 99)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 50)
        Me.btnCancel.TabIndex = 54
        Me.btnCancel.Text = "Reset"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.cmbSupplier)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.txtSupplierCode)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.txtOrderNo)
        Me.Panel3.Controls.Add(Me.cmbValidityPeriod)
        Me.Panel3.Controls.Add(Me.btnSearch)
        Me.Panel3.Controls.Add(Me.txtOrderStatus)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.txtVaildUntil)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.txtOrderDate)
        Me.Panel3.Location = New System.Drawing.Point(12, 12)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(425, 275)
        Me.Panel3.TabIndex = 53
        '
        'btnApprove
        '
        Me.btnApprove.Enabled = False
        Me.btnApprove.Location = New System.Drawing.Point(443, 236)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(101, 51)
        Me.btnApprove.TabIndex = 33
        Me.btnApprove.Text = "Approve"
        Me.btnApprove.UseVisualStyleBackColor = True
        '
        'cmbSupplier
        '
        Me.cmbSupplier.FormattingEnabled = True
        Me.cmbSupplier.Location = New System.Drawing.Point(119, 70)
        Me.cmbSupplier.Name = "cmbSupplier"
        Me.cmbSupplier.Size = New System.Drawing.Size(289, 24)
        Me.cmbSupplier.TabIndex = 100
        '
        'frmPurchaseOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1527, 751)
        Me.Controls.Add(Me.btnApprove)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dtgrdItemList)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.MinimizeBox = False
        Me.Name = "frmPurchaseOrder"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Local Purchase Order (LPO)"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtgrdItemList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSupplierCode As TextBox
    Friend WithEvents dtgrdItemList As DataGridView
    Friend WithEvents txtOrderNo As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnNew As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents txtOrderDate As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtVaildUntil As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtOrderStatus As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbValidityPeriod As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents txtItemCodeS As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtPackSize As TextBox
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtStockSize As TextBox
    Friend WithEvents txtCostPrice As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txtBarCode As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnSearchItem As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Column13 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents btnApprove As Button
    Friend WithEvents cmbDescription As ComboBox
    Friend WithEvents cmbSupplier As ComboBox
End Class
