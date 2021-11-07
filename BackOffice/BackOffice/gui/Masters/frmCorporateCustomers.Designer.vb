<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCorporateCustomers
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnEdit = New System.Windows.Forms.ToolStripButton()
        Me.btnClear = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtBankAccountNo = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtBankName = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtBankPostCode = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtBankAddress = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtBankAccountName = New System.Windows.Forms.TextBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFax = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtMobile = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTelephone = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPostCode = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPostAddress = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPhysicalAddress = New System.Windows.Forms.TextBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtCreditDays = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtCreditLimit = New System.Windows.Forms.TextBox()
        Me.txtInvoiceLimit = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.cmbName = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTin = New System.Windows.Forms.TextBox()
        Me.chkActive = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtVrn = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtContactName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtNo = New System.Windows.Forms.TextBox()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.dtgrdCustomerList = New System.Windows.Forms.DataGridView()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtCreditBalance = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dtgrdCustomerList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnEdit, Me.btnClear, Me.btnDelete, Me.btnSave, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1584, 27)
        Me.ToolStrip1.TabIndex = 109
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnNew
        '
        Me.btnNew.Image = Global.BackOffice.My.Resources.Resources.new_file
        Me.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(63, 24)
        Me.btnNew.Text = "New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNew.ToolTipText = "Creates a new record"
        '
        'btnEdit
        '
        Me.btnEdit.Image = Global.BackOffice.My.Resources.Resources.pencil
        Me.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(59, 24)
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.ToolTipText = "Unlock fields for editing"
        '
        'btnClear
        '
        Me.btnClear.Image = Global.BackOffice.My.Resources.Resources.cancel
        Me.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(67, 24)
        Me.btnClear.Text = "Clear"
        Me.btnClear.ToolTipText = "Clear all the fields"
        Me.btnClear.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.Enabled = False
        Me.btnDelete.Image = Global.BackOffice.My.Resources.Resources.trash
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(77, 24)
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.ToolTipText = "Deletes an existing record"
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Image = Global.BackOffice.My.Resources.Resources.floppy_disk
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(64, 24)
        Me.btnSave.Text = "Save"
        Me.btnSave.ToolTipText = "Save a new or existing record"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Panel8)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 27)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(400, 713)
        Me.Panel1.TabIndex = 110
        '
        'Panel8
        '
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel8.Controls.Add(Me.Label14)
        Me.Panel8.Controls.Add(Me.txtBankAccountNo)
        Me.Panel8.Controls.Add(Me.Label15)
        Me.Panel8.Controls.Add(Me.txtBankName)
        Me.Panel8.Controls.Add(Me.Label16)
        Me.Panel8.Controls.Add(Me.txtBankPostCode)
        Me.Panel8.Controls.Add(Me.Label17)
        Me.Panel8.Controls.Add(Me.txtBankAddress)
        Me.Panel8.Controls.Add(Me.Label18)
        Me.Panel8.Controls.Add(Me.txtBankAccountName)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(0, 503)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(396, 147)
        Me.Panel8.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(30, 115)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(89, 17)
        Me.Label14.TabIndex = 19
        Me.Label14.Text = "Bank Acc No"
        '
        'txtBankAccountNo
        '
        Me.txtBankAccountNo.Location = New System.Drawing.Point(124, 115)
        Me.txtBankAccountNo.Name = "txtBankAccountNo"
        Me.txtBankAccountNo.Size = New System.Drawing.Size(266, 22)
        Me.txtBankAccountNo.TabIndex = 18
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(36, 87)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(81, 17)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "Bank Name"
        '
        'txtBankName
        '
        Me.txtBankName.Location = New System.Drawing.Point(124, 87)
        Me.txtBankName.Name = "txtBankName"
        Me.txtBankName.Size = New System.Drawing.Size(265, 22)
        Me.txtBankName.TabIndex = 16
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(10, 59)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(109, 17)
        Me.Label16.TabIndex = 15
        Me.Label16.Text = "Bank Post Code"
        '
        'txtBankPostCode
        '
        Me.txtBankPostCode.Location = New System.Drawing.Point(124, 59)
        Me.txtBankPostCode.Name = "txtBankPostCode"
        Me.txtBankPostCode.Size = New System.Drawing.Size(265, 22)
        Me.txtBankPostCode.TabIndex = 14
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(21, 31)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(96, 17)
        Me.Label17.TabIndex = 13
        Me.Label17.Text = "Bank Address"
        '
        'txtBankAddress
        '
        Me.txtBankAddress.Location = New System.Drawing.Point(124, 31)
        Me.txtBankAddress.Name = "txtBankAddress"
        Me.txtBankAddress.Size = New System.Drawing.Size(265, 22)
        Me.txtBankAddress.TabIndex = 12
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(10, 3)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(108, 17)
        Me.Label18.TabIndex = 11
        Me.Label18.Text = "Bank Acc Name"
        '
        'txtBankAccountName
        '
        Me.txtBankAccountName.Location = New System.Drawing.Point(124, 3)
        Me.txtBankAccountName.Name = "txtBankAccountName"
        Me.txtBankAccountName.Size = New System.Drawing.Size(265, 22)
        Me.txtBankAccountName.TabIndex = 10
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel6.Controls.Add(Me.Label4)
        Me.Panel6.Controls.Add(Me.txtFax)
        Me.Panel6.Controls.Add(Me.Label10)
        Me.Panel6.Controls.Add(Me.txtEmail)
        Me.Panel6.Controls.Add(Me.Label9)
        Me.Panel6.Controls.Add(Me.txtMobile)
        Me.Panel6.Controls.Add(Me.Label8)
        Me.Panel6.Controls.Add(Me.txtTelephone)
        Me.Panel6.Controls.Add(Me.Label5)
        Me.Panel6.Controls.Add(Me.txtPostCode)
        Me.Panel6.Controls.Add(Me.Label6)
        Me.Panel6.Controls.Add(Me.txtPostAddress)
        Me.Panel6.Controls.Add(Me.Label7)
        Me.Panel6.Controls.Add(Me.txtPhysicalAddress)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 293)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(396, 210)
        Me.Panel6.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(88, 174)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 17)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Fax"
        '
        'txtFax
        '
        Me.txtFax.Location = New System.Drawing.Point(124, 174)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(265, 22)
        Me.txtFax.TabIndex = 26
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(76, 146)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 17)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "Email"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(124, 146)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(265, 22)
        Me.txtEmail.TabIndex = 24
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(69, 118)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 17)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Mobile"
        '
        'txtMobile
        '
        Me.txtMobile.Location = New System.Drawing.Point(124, 118)
        Me.txtMobile.Name = "txtMobile"
        Me.txtMobile.Size = New System.Drawing.Size(265, 22)
        Me.txtMobile.TabIndex = 22
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(42, 90)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 17)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Telephone"
        '
        'txtTelephone
        '
        Me.txtTelephone.Location = New System.Drawing.Point(124, 90)
        Me.txtTelephone.Name = "txtTelephone"
        Me.txtTelephone.Size = New System.Drawing.Size(265, 22)
        Me.txtTelephone.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(45, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 17)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Post Code"
        '
        'txtPostCode
        '
        Me.txtPostCode.Location = New System.Drawing.Point(124, 62)
        Me.txtPostCode.Name = "txtPostCode"
        Me.txtPostCode.Size = New System.Drawing.Size(265, 22)
        Me.txtPostCode.TabIndex = 18
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(26, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 17)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Post Address"
        '
        'txtPostAddress
        '
        Me.txtPostAddress.Location = New System.Drawing.Point(124, 34)
        Me.txtPostAddress.Name = "txtPostAddress"
        Me.txtPostAddress.Size = New System.Drawing.Size(265, 22)
        Me.txtPostAddress.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(2, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 17)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Physical Address"
        '
        'txtPhysicalAddress
        '
        Me.txtPhysicalAddress.Location = New System.Drawing.Point(124, 6)
        Me.txtPhysicalAddress.Name = "txtPhysicalAddress"
        Me.txtPhysicalAddress.Size = New System.Drawing.Size(265, 22)
        Me.txtPhysicalAddress.TabIndex = 14
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel5.Controls.Add(Me.txtCreditBalance)
        Me.Panel5.Controls.Add(Me.Label19)
        Me.Panel5.Controls.Add(Me.Label13)
        Me.Panel5.Controls.Add(Me.txtCreditDays)
        Me.Panel5.Controls.Add(Me.Label23)
        Me.Panel5.Controls.Add(Me.txtCreditLimit)
        Me.Panel5.Controls.Add(Me.txtInvoiceLimit)
        Me.Panel5.Controls.Add(Me.Label22)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 173)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(396, 120)
        Me.Panel5.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(2, 3)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(114, 17)
        Me.Label13.TabIndex = 117
        Me.Label13.Text = "Maximum Invoice"
        '
        'txtCreditDays
        '
        Me.txtCreditDays.Location = New System.Drawing.Point(123, 90)
        Me.txtCreditDays.Name = "txtCreditDays"
        Me.txtCreditDays.Size = New System.Drawing.Size(153, 22)
        Me.txtCreditDays.TabIndex = 120
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(35, 90)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(81, 17)
        Me.Label23.TabIndex = 121
        Me.Label23.Text = "Credit Days"
        '
        'txtCreditLimit
        '
        Me.txtCreditLimit.Location = New System.Drawing.Point(124, 33)
        Me.txtCreditLimit.Name = "txtCreditLimit"
        Me.txtCreditLimit.Size = New System.Drawing.Size(153, 22)
        Me.txtCreditLimit.TabIndex = 118
        Me.txtCreditLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtInvoiceLimit
        '
        Me.txtInvoiceLimit.Location = New System.Drawing.Point(124, 3)
        Me.txtInvoiceLimit.Name = "txtInvoiceLimit"
        Me.txtInvoiceLimit.Size = New System.Drawing.Size(153, 22)
        Me.txtInvoiceLimit.TabIndex = 116
        Me.txtInvoiceLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(41, 33)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(78, 17)
        Me.Label22.TabIndex = 119
        Me.Label22.Text = "Credit Limit"
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.Add(Me.cmbName)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Controls.Add(Me.txtTin)
        Me.Panel4.Controls.Add(Me.chkActive)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.txtVrn)
        Me.Panel4.Controls.Add(Me.btnSearch)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.txtContactName)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.txtNo)
        Me.Panel4.Controls.Add(Me.txtId)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(396, 173)
        Me.Panel4.TabIndex = 0
        '
        'cmbName
        '
        Me.cmbName.FormattingEnabled = True
        Me.cmbName.Location = New System.Drawing.Point(122, 47)
        Me.cmbName.Name = "cmbName"
        Me.cmbName.Size = New System.Drawing.Size(267, 24)
        Me.cmbName.TabIndex = 123
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(86, 113)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(30, 17)
        Me.Label12.TabIndex = 122
        Me.Label12.Text = "TIN"
        '
        'txtTin
        '
        Me.txtTin.Location = New System.Drawing.Point(122, 110)
        Me.txtTin.Name = "txtTin"
        Me.txtTin.Size = New System.Drawing.Size(153, 22)
        Me.txtTin.TabIndex = 121
        '
        'chkActive
        '
        Me.chkActive.AutoSize = True
        Me.chkActive.Location = New System.Drawing.Point(281, 111)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(68, 21)
        Me.chkActive.TabIndex = 118
        Me.chkActive.Text = "Active"
        Me.chkActive.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(80, 143)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 17)
        Me.Label1.TabIndex = 120
        Me.Label1.Text = "VRN"
        '
        'txtVrn
        '
        Me.txtVrn.Location = New System.Drawing.Point(122, 138)
        Me.txtVrn.Name = "txtVrn"
        Me.txtVrn.Size = New System.Drawing.Size(153, 22)
        Me.txtVrn.TabIndex = 119
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(291, 1)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(100, 40)
        Me.btnSearch.TabIndex = 116
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 17)
        Me.Label3.TabIndex = 115
        Me.Label3.Text = "Contact Name"
        '
        'txtContactName
        '
        Me.txtContactName.Location = New System.Drawing.Point(122, 78)
        Me.txtContactName.Name = "txtContactName"
        Me.txtContactName.Size = New System.Drawing.Size(267, 22)
        Me.txtContactName.TabIndex = 114
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 17)
        Me.Label2.TabIndex = 113
        Me.Label2.Text = "Customer Name"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(26, 6)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(90, 17)
        Me.Label11.TabIndex = 112
        Me.Label11.Text = "Customer No"
        '
        'txtNo
        '
        Me.txtNo.Location = New System.Drawing.Point(122, 3)
        Me.txtNo.Name = "txtNo"
        Me.txtNo.Size = New System.Drawing.Size(153, 22)
        Me.txtNo.TabIndex = 111
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(3, 26)
        Me.txtId.Name = "txtId"
        Me.txtId.ReadOnly = True
        Me.txtId.Size = New System.Drawing.Size(48, 22)
        Me.txtId.TabIndex = 117
        Me.txtId.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(400, 27)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1184, 44)
        Me.Panel2.TabIndex = 111
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnBack)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(400, 700)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1184, 40)
        Me.Panel3.TabIndex = 112
        '
        'btnBack
        '
        Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBack.BackgroundImage = Global.BackOffice.My.Resources.Resources.red_back_arrow
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBack.Location = New System.Drawing.Point(1072, 3)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(100, 35)
        Me.btnBack.TabIndex = 113
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel7.Location = New System.Drawing.Point(1564, 71)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(20, 629)
        Me.Panel7.TabIndex = 114
        '
        'dtgrdCustomerList
        '
        Me.dtgrdCustomerList.AllowUserToAddRows = False
        Me.dtgrdCustomerList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdCustomerList.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dtgrdCustomerList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dtgrdCustomerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrdCustomerList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column5, Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        Me.dtgrdCustomerList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgrdCustomerList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtgrdCustomerList.Location = New System.Drawing.Point(400, 71)
        Me.dtgrdCustomerList.Name = "dtgrdCustomerList"
        Me.dtgrdCustomerList.RowTemplate.Height = 24
        Me.dtgrdCustomerList.Size = New System.Drawing.Size(1164, 629)
        Me.dtgrdCustomerList.TabIndex = 115
        '
        'Column5
        '
        Me.Column5.HeaderText = "ID"
        Me.Column5.Name = "Column5"
        Me.Column5.Visible = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "Cust No"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Name"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.HeaderText = "Contact Name"
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.HeaderText = "Status"
        Me.Column4.Name = "Column4"
        '
        'txtCreditBalance
        '
        Me.txtCreditBalance.Location = New System.Drawing.Point(124, 61)
        Me.txtCreditBalance.Name = "txtCreditBalance"
        Me.txtCreditBalance.Size = New System.Drawing.Size(153, 22)
        Me.txtCreditBalance.TabIndex = 122
        Me.txtCreditBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(16, 61)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(100, 17)
        Me.Label19.TabIndex = 123
        Me.Label19.Text = "Credit Balance"
        '
        'frmCorporateCustomers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1584, 740)
        Me.Controls.Add(Me.dtgrdCustomerList)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.MinimizeBox = False
        Me.Name = "frmCorporateCustomers"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Corporate Customers"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.dtgrdCustomerList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnNew As ToolStripButton
    Friend WithEvents btnEdit As ToolStripButton
    Friend WithEvents btnClear As ToolStripButton
    Friend WithEvents btnDelete As ToolStripButton
    Friend WithEvents btnSave As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents btnBack As Button
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents txtFax As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtMobile As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtTelephone As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtPostCode As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtPostAddress As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtPhysicalAddress As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtCreditDays As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents txtCreditLimit As TextBox
    Friend WithEvents txtInvoiceLimit As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents cmbName As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtTin As TextBox
    Friend WithEvents chkActive As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtVrn As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txtContactName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtNo As TextBox
    Friend WithEvents txtId As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtBankAccountNo As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtBankName As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtBankPostCode As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtBankAddress As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtBankAccountName As TextBox
    Friend WithEvents dtgrdCustomerList As DataGridView
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents txtCreditBalance As TextBox
    Friend WithEvents Label19 As Label
End Class
