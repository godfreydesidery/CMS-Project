<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProductInquiry
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
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.txtPck = New System.Windows.Forms.TextBox()
        Me.txtSupplier = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.chkDiscontinued = New System.Windows.Forms.CheckBox()
        Me.txtStandardUOM = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtMargin = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtItemCode = New System.Windows.Forms.TextBox()
        Me.txtBarCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRetailPrice = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDiscount = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCostPrice = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtVAT = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtDepartment = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtSubClass = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtClass = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtReorderQty = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtReorderLevel = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtMaxInventory = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtMinInventory = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lstBarCodes = New System.Windows.Forms.ListBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbDescription = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBack.Location = New System.Drawing.Point(811, 426)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(115, 35)
        Me.btnBack.TabIndex = 10
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(416, 126)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(115, 35)
        Me.btnReset.TabIndex = 50
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'txtPck
        '
        Me.txtPck.Location = New System.Drawing.Point(129, 153)
        Me.txtPck.MaxLength = 20
        Me.txtPck.Name = "txtPck"
        Me.txtPck.ReadOnly = True
        Me.txtPck.Size = New System.Drawing.Size(174, 22)
        Me.txtPck.TabIndex = 49
        '
        'txtSupplier
        '
        Me.txtSupplier.Location = New System.Drawing.Point(130, 190)
        Me.txtSupplier.MaxLength = 100
        Me.txtSupplier.Name = "txtSupplier"
        Me.txtSupplier.ReadOnly = True
        Me.txtSupplier.Size = New System.Drawing.Size(401, 22)
        Me.txtSupplier.TabIndex = 48
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 96)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(117, 17)
        Me.Label16.TabIndex = 47
        Me.Label16.Text = "Short Description"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(129, 96)
        Me.txtDescription.MaxLength = 100
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ReadOnly = True
        Me.txtDescription.Size = New System.Drawing.Size(402, 22)
        Me.txtDescription.TabIndex = 46
        '
        'chkDiscontinued
        '
        Me.chkDiscontinued.AutoSize = True
        Me.chkDiscontinued.Enabled = False
        Me.chkDiscontinued.Location = New System.Drawing.Point(129, 124)
        Me.chkDiscontinued.Name = "chkDiscontinued"
        Me.chkDiscontinued.Size = New System.Drawing.Size(112, 21)
        Me.chkDiscontinued.TabIndex = 45
        Me.chkDiscontinued.Text = "Discontinued"
        Me.chkDiscontinued.UseVisualStyleBackColor = True
        '
        'txtStandardUOM
        '
        Me.txtStandardUOM.Location = New System.Drawing.Point(203, 158)
        Me.txtStandardUOM.MaxLength = 100
        Me.txtStandardUOM.Name = "txtStandardUOM"
        Me.txtStandardUOM.ReadOnly = True
        Me.txtStandardUOM.Size = New System.Drawing.Size(174, 22)
        Me.txtStandardUOM.TabIndex = 34
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(95, 157)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(102, 17)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "Standard UOM"
        '
        'txtMargin
        '
        Me.txtMargin.Location = New System.Drawing.Point(203, 130)
        Me.txtMargin.MaxLength = 6
        Me.txtMargin.Name = "txtMargin"
        Me.txtMargin.ReadOnly = True
        Me.txtMargin.Size = New System.Drawing.Size(174, 22)
        Me.txtMargin.TabIndex = 32
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(63, 190)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 17)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "Supplier"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(416, 12)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(115, 50)
        Me.btnSearch.TabIndex = 15
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(146, 130)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(51, 17)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "Margin"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(52, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 17)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Item Code"
        '
        'txtItemCode
        '
        Me.txtItemCode.Location = New System.Drawing.Point(129, 40)
        Me.txtItemCode.MaxLength = 20
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.Size = New System.Drawing.Size(281, 22)
        Me.txtItemCode.TabIndex = 12
        '
        'txtBarCode
        '
        Me.txtBarCode.Location = New System.Drawing.Point(129, 12)
        Me.txtBarCode.MaxLength = 20
        Me.txtBarCode.Name = "txtBarCode"
        Me.txtBarCode.Size = New System.Drawing.Size(281, 22)
        Me.txtBarCode.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(56, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 17)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Bar Code"
        '
        'txtRetailPrice
        '
        Me.txtRetailPrice.Location = New System.Drawing.Point(203, 42)
        Me.txtRetailPrice.MaxLength = 20
        Me.txtRetailPrice.Name = "txtRetailPrice"
        Me.txtRetailPrice.ReadOnly = True
        Me.txtRetailPrice.Size = New System.Drawing.Size(174, 22)
        Me.txtRetailPrice.TabIndex = 28
        Me.txtRetailPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(117, 39)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 17)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Retail Price"
        '
        'txtDiscount
        '
        Me.txtDiscount.Location = New System.Drawing.Point(203, 102)
        Me.txtDiscount.MaxLength = 6
        Me.txtDiscount.Name = "txtDiscount"
        Me.txtDiscount.ReadOnly = True
        Me.txtDiscount.Size = New System.Drawing.Size(107, 22)
        Me.txtDiscount.TabIndex = 26
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(108, 100)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 17)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Discount (%)"
        '
        'txtCostPrice
        '
        Me.txtCostPrice.Location = New System.Drawing.Point(203, 14)
        Me.txtCostPrice.MaxLength = 20
        Me.txtCostPrice.Name = "txtCostPrice"
        Me.txtCostPrice.ReadOnly = True
        Me.txtCostPrice.Size = New System.Drawing.Size(174, 22)
        Me.txtCostPrice.TabIndex = 22
        Me.txtCostPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(100, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 17)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Unit Cost Price"
        '
        'txtVAT
        '
        Me.txtVAT.Location = New System.Drawing.Point(203, 74)
        Me.txtVAT.MaxLength = 6
        Me.txtVAT.Name = "txtVAT"
        Me.txtVAT.ReadOnly = True
        Me.txtVAT.Size = New System.Drawing.Size(107, 22)
        Me.txtVAT.TabIndex = 20
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(140, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 17)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "VAT(%)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 17)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Long Description"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(54, 153)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 17)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Pack Size"
        '
        'txtQty
        '
        Me.txtQty.Location = New System.Drawing.Point(200, 249)
        Me.txtQty.MaxLength = 20
        Me.txtQty.Name = "txtQty"
        Me.txtQty.ReadOnly = True
        Me.txtQty.Size = New System.Drawing.Size(174, 22)
        Me.txtQty.TabIndex = 44
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(130, 249)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(61, 17)
        Me.Label21.TabIndex = 43
        Me.Label21.Text = "Quantity"
        '
        'txtDepartment
        '
        Me.txtDepartment.Location = New System.Drawing.Point(130, 218)
        Me.txtDepartment.MaxLength = 50
        Me.txtDepartment.Name = "txtDepartment"
        Me.txtDepartment.ReadOnly = True
        Me.txtDepartment.Size = New System.Drawing.Size(401, 22)
        Me.txtDepartment.TabIndex = 42
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(42, 221)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(82, 17)
        Me.Label20.TabIndex = 41
        Me.Label20.Text = "Department"
        '
        'txtSubClass
        '
        Me.txtSubClass.Location = New System.Drawing.Point(129, 283)
        Me.txtSubClass.MaxLength = 50
        Me.txtSubClass.Name = "txtSubClass"
        Me.txtSubClass.ReadOnly = True
        Me.txtSubClass.Size = New System.Drawing.Size(402, 22)
        Me.txtSubClass.TabIndex = 40
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(56, 283)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(71, 17)
        Me.Label19.TabIndex = 39
        Me.Label19.Text = "Sub Class"
        '
        'txtClass
        '
        Me.txtClass.Location = New System.Drawing.Point(129, 255)
        Me.txtClass.MaxLength = 50
        Me.txtClass.Name = "txtClass"
        Me.txtClass.ReadOnly = True
        Me.txtClass.Size = New System.Drawing.Size(402, 22)
        Me.txtClass.TabIndex = 38
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(81, 254)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(42, 17)
        Me.Label18.TabIndex = 37
        Me.Label18.Text = "Class"
        '
        'txtReorderQty
        '
        Me.txtReorderQty.Location = New System.Drawing.Point(200, 373)
        Me.txtReorderQty.MaxLength = 20
        Me.txtReorderQty.Name = "txtReorderQty"
        Me.txtReorderQty.ReadOnly = True
        Me.txtReorderQty.Size = New System.Drawing.Size(174, 22)
        Me.txtReorderQty.TabIndex = 36
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(25, 376)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(166, 17)
        Me.Label15.TabIndex = 35
        Me.Label15.Text = "Default Reorder Quantity"
        '
        'txtReorderLevel
        '
        Me.txtReorderLevel.Location = New System.Drawing.Point(200, 342)
        Me.txtReorderLevel.MaxLength = 20
        Me.txtReorderLevel.Name = "txtReorderLevel"
        Me.txtReorderLevel.ReadOnly = True
        Me.txtReorderLevel.Size = New System.Drawing.Size(174, 22)
        Me.txtReorderLevel.TabIndex = 34
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(93, 345)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(98, 17)
        Me.Label17.TabIndex = 33
        Me.Label17.Text = "Reorder Level"
        '
        'txtMaxInventory
        '
        Me.txtMaxInventory.Location = New System.Drawing.Point(200, 314)
        Me.txtMaxInventory.MaxLength = 20
        Me.txtMaxInventory.Name = "txtMaxInventory"
        Me.txtMaxInventory.ReadOnly = True
        Me.txtMaxInventory.Size = New System.Drawing.Size(174, 22)
        Me.txtMaxInventory.TabIndex = 32
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(63, 314)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(128, 17)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Maximum Inventory"
        '
        'txtMinInventory
        '
        Me.txtMinInventory.Location = New System.Drawing.Point(200, 282)
        Me.txtMinInventory.MaxLength = 20
        Me.txtMinInventory.Name = "txtMinInventory"
        Me.txtMinInventory.ReadOnly = True
        Me.txtMinInventory.Size = New System.Drawing.Size(174, 22)
        Me.txtMinInventory.TabIndex = 30
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(66, 282)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(125, 17)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "Minimum Inventory"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(197, 220)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(113, 17)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Inventory Details"
        '
        'lstBarCodes
        '
        Me.lstBarCodes.Enabled = False
        Me.lstBarCodes.FormattingEnabled = True
        Me.lstBarCodes.ItemHeight = 16
        Me.lstBarCodes.Location = New System.Drawing.Point(130, 311)
        Me.lstBarCodes.Name = "lstBarCodes"
        Me.lstBarCodes.Size = New System.Drawing.Size(202, 100)
        Me.lstBarCodes.TabIndex = 52
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(49, 311)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(74, 17)
        Me.Label23.TabIndex = 53
        Me.Label23.Text = "Bar Codes"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.txtCostPrice)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtReorderQty)
        Me.Panel1.Controls.Add(Me.txtVAT)
        Me.Panel1.Controls.Add(Me.txtQty)
        Me.Panel1.Controls.Add(Me.txtRetailPrice)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtDiscount)
        Me.Panel1.Controls.Add(Me.txtReorderLevel)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.txtMargin)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.txtStandardUOM)
        Me.Panel1.Controls.Add(Me.txtMaxInventory)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.txtMinInventory)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Location = New System.Drawing.Point(537, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(389, 408)
        Me.Panel1.TabIndex = 54
        '
        'cmbDescription
        '
        Me.cmbDescription.FormattingEnabled = True
        Me.cmbDescription.Location = New System.Drawing.Point(130, 68)
        Me.cmbDescription.Name = "cmbDescription"
        Me.cmbDescription.Size = New System.Drawing.Size(402, 24)
        Me.cmbDescription.TabIndex = 108
        '
        'frmProductInquiry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(937, 466)
        Me.Controls.Add(Me.cmbDescription)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.lstBarCodes)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.txtSupplier)
        Me.Controls.Add(Me.txtSubClass)
        Me.Controls.Add(Me.txtDepartment)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtPck)
        Me.Controls.Add(Me.txtClass)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.chkDiscontinued)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtBarCode)
        Me.Controls.Add(Me.txtItemCode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.MinimizeBox = False
        Me.Name = "frmProductInquiry"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Product Inquiry"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents txtPck As TextBox
    Friend WithEvents txtSupplier As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents chkDiscontinued As CheckBox
    Friend WithEvents txtStandardUOM As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtMargin As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents btnSearch As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtItemCode As TextBox
    Friend WithEvents txtBarCode As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtRetailPrice As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtDiscount As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCostPrice As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtVAT As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtReorderQty As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtReorderLevel As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtMaxInventory As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtMinInventory As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtDepartment As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents txtSubClass As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtClass As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents btnReset As Button
    Friend WithEvents txtQty As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents lstBarCodes As ListBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cmbDescription As ComboBox
End Class
