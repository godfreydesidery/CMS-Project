<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmQuotations
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
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnEdit = New System.Windows.Forms.ToolStripButton()
        Me.btnClear = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbDescription = New System.Windows.Forms.ComboBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.cmbRawDescription = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtRawQty = New System.Windows.Forms.TextBox()
        Me.btnRawAdd = New System.Windows.Forms.Button()
        Me.btnRawReset = New System.Windows.Forms.Button()
        Me.btnRawSearchItem = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtRawBarCode = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtRawItemCode = New System.Windows.Forms.TextBox()
        Me.txtRawPrice = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.dtgrdItemsToConvert = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dtgrdConversionList = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dtgrdItemsToConvert, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dtgrdConversionList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnEdit, Me.btnClear, Me.btnDelete, Me.btnSave, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1538, 27)
        Me.ToolStrip1.TabIndex = 111
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
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 27)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(400, 710)
        Me.Panel1.TabIndex = 112
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Button1)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.cmbDescription)
        Me.Panel5.Controls.Add(Me.TextBox3)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.TextBox2)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.TextBox1)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(396, 152)
        Me.Panel5.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(290, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 35)
        Me.Button1.TabIndex = 113
        Me.Button1.Text = "Search"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 17)
        Me.Label4.TabIndex = 111
        Me.Label4.Text = "Customer Name"
        '
        'cmbDescription
        '
        Me.cmbDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDescription.FormattingEnabled = True
        Me.cmbDescription.Location = New System.Drawing.Point(122, 110)
        Me.cmbDescription.Name = "cmbDescription"
        Me.cmbDescription.Size = New System.Drawing.Size(268, 26)
        Me.cmbDescription.TabIndex = 110
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(122, 80)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(146, 24)
        Me.TextBox3.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Customer No"
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(122, 50)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(146, 24)
        Me.TextBox2.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Quotation Date"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(122, 15)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(146, 24)
        Me.TextBox1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Quotation No"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TabControl1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(400, 27)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1138, 244)
        Me.Panel2.TabIndex = 113
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.cmbRawDescription)
        Me.Panel6.Controls.Add(Me.Label19)
        Me.Panel6.Controls.Add(Me.txtRawQty)
        Me.Panel6.Controls.Add(Me.btnRawAdd)
        Me.Panel6.Controls.Add(Me.btnRawReset)
        Me.Panel6.Controls.Add(Me.btnRawSearchItem)
        Me.Panel6.Controls.Add(Me.Label12)
        Me.Panel6.Controls.Add(Me.txtRawBarCode)
        Me.Panel6.Controls.Add(Me.Label13)
        Me.Panel6.Controls.Add(Me.Label16)
        Me.Panel6.Controls.Add(Me.txtRawItemCode)
        Me.Panel6.Controls.Add(Me.txtRawPrice)
        Me.Panel6.Controls.Add(Me.Label18)
        Me.Panel6.Location = New System.Drawing.Point(6, 6)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(456, 189)
        Me.Panel6.TabIndex = 95
        '
        'cmbRawDescription
        '
        Me.cmbRawDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRawDescription.FormattingEnabled = True
        Me.cmbRawDescription.Location = New System.Drawing.Point(117, 68)
        Me.cmbRawDescription.Name = "cmbRawDescription"
        Me.cmbRawDescription.Size = New System.Drawing.Size(332, 28)
        Me.cmbRawDescription.TabIndex = 99
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(81, 141)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(30, 17)
        Me.Label19.TabIndex = 55
        Me.Label19.Text = "Qty"
        '
        'txtRawQty
        '
        Me.txtRawQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRawQty.Location = New System.Drawing.Point(117, 141)
        Me.txtRawQty.MaxLength = 50
        Me.txtRawQty.Name = "txtRawQty"
        Me.txtRawQty.Size = New System.Drawing.Size(115, 27)
        Me.txtRawQty.TabIndex = 56
        '
        'btnRawAdd
        '
        Me.btnRawAdd.Enabled = False
        Me.btnRawAdd.Location = New System.Drawing.Point(329, 102)
        Me.btnRawAdd.Name = "btnRawAdd"
        Me.btnRawAdd.Size = New System.Drawing.Size(120, 40)
        Me.btnRawAdd.TabIndex = 53
        Me.btnRawAdd.Text = "Add/Update"
        Me.btnRawAdd.UseVisualStyleBackColor = True
        '
        'btnRawReset
        '
        Me.btnRawReset.Location = New System.Drawing.Point(329, 146)
        Me.btnRawReset.Name = "btnRawReset"
        Me.btnRawReset.Size = New System.Drawing.Size(120, 40)
        Me.btnRawReset.TabIndex = 54
        Me.btnRawReset.Text = "Reset"
        Me.btnRawReset.UseVisualStyleBackColor = True
        '
        'btnRawSearchItem
        '
        Me.btnRawSearchItem.Location = New System.Drawing.Point(349, 4)
        Me.btnRawSearchItem.Name = "btnRawSearchItem"
        Me.btnRawSearchItem.Size = New System.Drawing.Size(100, 40)
        Me.btnRawSearchItem.TabIndex = 51
        Me.btnRawSearchItem.Text = "Search"
        Me.btnRawSearchItem.UseVisualStyleBackColor = True
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
        'txtRawBarCode
        '
        Me.txtRawBarCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRawBarCode.Location = New System.Drawing.Point(117, 4)
        Me.txtRawBarCode.MaxLength = 50
        Me.txtRawBarCode.Name = "txtRawBarCode"
        Me.txtRawBarCode.Size = New System.Drawing.Size(206, 27)
        Me.txtRawBarCode.TabIndex = 50
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(32, 68)
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
        'txtRawItemCode
        '
        Me.txtRawItemCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRawItemCode.Location = New System.Drawing.Point(117, 35)
        Me.txtRawItemCode.MaxLength = 50
        Me.txtRawItemCode.Name = "txtRawItemCode"
        Me.txtRawItemCode.Size = New System.Drawing.Size(206, 27)
        Me.txtRawItemCode.TabIndex = 39
        '
        'txtRawPrice
        '
        Me.txtRawPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRawPrice.Location = New System.Drawing.Point(117, 104)
        Me.txtRawPrice.MaxLength = 50
        Me.txtRawPrice.Name = "txtRawPrice"
        Me.txtRawPrice.ReadOnly = True
        Me.txtRawPrice.Size = New System.Drawing.Size(206, 27)
        Me.txtRawPrice.TabIndex = 47
        Me.txtRawPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(71, 106)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(40, 17)
        Me.Label18.TabIndex = 45
        Me.Label18.Text = "Price"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnBack)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(400, 697)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1138, 40)
        Me.Panel3.TabIndex = 114
        '
        'btnBack
        '
        Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBack.BackgroundImage = Global.BackOffice.My.Resources.Resources.red_back_arrow
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBack.Location = New System.Drawing.Point(1035, 0)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(100, 40)
        Me.btnBack.TabIndex = 111
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(1498, 271)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(40, 426)
        Me.Panel4.TabIndex = 115
        '
        'dtgrdItemsToConvert
        '
        Me.dtgrdItemsToConvert.AllowUserToAddRows = False
        Me.dtgrdItemsToConvert.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgrdItemsToConvert.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdItemsToConvert.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dtgrdItemsToConvert.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dtgrdItemsToConvert.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrdItemsToConvert.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        Me.dtgrdItemsToConvert.Location = New System.Drawing.Point(406, 277)
        Me.dtgrdItemsToConvert.Name = "dtgrdItemsToConvert"
        Me.dtgrdItemsToConvert.ReadOnly = True
        Me.dtgrdItemsToConvert.RowTemplate.Height = 24
        Me.dtgrdItemsToConvert.Size = New System.Drawing.Size(1086, 414)
        Me.dtgrdItemsToConvert.TabIndex = 116
        '
        'Column1
        '
        Me.Column1.HeaderText = "Item Code"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Description"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Qty"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle12
        Me.Column4.HeaderText = "Price"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(6, 11)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(578, 230)
        Me.TabControl1.TabIndex = 96
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.Panel6)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(570, 201)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Item Entry"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.dtgrdConversionList)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(570, 201)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Quotation List"
        '
        'dtgrdConversionList
        '
        Me.dtgrdConversionList.AllowUserToAddRows = False
        Me.dtgrdConversionList.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgrdConversionList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdConversionList.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dtgrdConversionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrdConversionList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7})
        Me.dtgrdConversionList.Location = New System.Drawing.Point(6, 6)
        Me.dtgrdConversionList.Name = "dtgrdConversionList"
        Me.dtgrdConversionList.ReadOnly = True
        Me.dtgrdConversionList.RowTemplate.Height = 24
        Me.dtgrdConversionList.Size = New System.Drawing.Size(558, 189)
        Me.dtgrdConversionList.TabIndex = 107
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Quot No"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Status"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'frmQuotations
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1538, 737)
        Me.Controls.Add(Me.dtgrdItemsToConvert)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.MinimizeBox = False
        Me.Name = "frmQuotations"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Quotations"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.dtgrdItemsToConvert, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dtgrdConversionList, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbDescription As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel6 As Panel
    Friend WithEvents cmbRawDescription As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtRawQty As TextBox
    Friend WithEvents btnRawAdd As Button
    Friend WithEvents btnRawReset As Button
    Friend WithEvents btnRawSearchItem As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents txtRawBarCode As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtRawItemCode As TextBox
    Friend WithEvents txtRawPrice As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents dtgrdItemsToConvert As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents btnBack As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents dtgrdConversionList As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
End Class
