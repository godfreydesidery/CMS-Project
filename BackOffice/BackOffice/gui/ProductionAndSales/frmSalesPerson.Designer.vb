<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSalesPerson
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnUnblock = New System.Windows.Forms.Button()
        Me.btnBlock = New System.Windows.Forms.Button()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.txtInvoiceLimit = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtTelephone = New System.Windows.Forms.TextBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtSecondName = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.txtRollNo = New System.Windows.Forms.TextBox()
        Me.dtgrdList = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.dtgrdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(65, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Roll No"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(43, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "First Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Second Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(43, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Last Name"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(59, 186)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 17)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Address"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(46, 213)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 17)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Telephone"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(77, 247)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 17)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Email"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(71, 278)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 17)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Status"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.btnUnblock)
        Me.Panel1.Controls.Add(Me.btnBlock)
        Me.Panel1.Controls.Add(Me.txtId)
        Me.Panel1.Controls.Add(Me.txtInvoiceLimit)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.btnDelete)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.btnEdit)
        Me.Panel1.Controls.Add(Me.txtStatus)
        Me.Panel1.Controls.Add(Me.btnNew)
        Me.Panel1.Controls.Add(Me.txtEmail)
        Me.Panel1.Controls.Add(Me.txtTelephone)
        Me.Panel1.Controls.Add(Me.txtAddress)
        Me.Panel1.Controls.Add(Me.txtLastName)
        Me.Panel1.Controls.Add(Me.txtSecondName)
        Me.Panel1.Controls.Add(Me.txtFirstName)
        Me.Panel1.Controls.Add(Me.txtRollNo)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(12, 11)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(548, 437)
        Me.Panel1.TabIndex = 8
        '
        'btnUnblock
        '
        Me.btnUnblock.Enabled = False
        Me.btnUnblock.Location = New System.Drawing.Point(211, 301)
        Me.btnUnblock.Name = "btnUnblock"
        Me.btnUnblock.Size = New System.Drawing.Size(79, 54)
        Me.btnUnblock.TabIndex = 21
        Me.btnUnblock.Text = "Unblock"
        Me.btnUnblock.UseVisualStyleBackColor = True
        '
        'btnBlock
        '
        Me.btnBlock.Enabled = False
        Me.btnBlock.Location = New System.Drawing.Point(125, 301)
        Me.btnBlock.Name = "btnBlock"
        Me.btnBlock.Size = New System.Drawing.Size(80, 54)
        Me.btnBlock.TabIndex = 20
        Me.btnBlock.Text = "Block"
        Me.btnBlock.UseVisualStyleBackColor = True
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(3, 4)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(41, 22)
        Me.txtId.TabIndex = 19
        Me.txtId.Visible = False
        '
        'txtInvoiceLimit
        '
        Me.txtInvoiceLimit.Location = New System.Drawing.Point(125, 159)
        Me.txtInvoiceLimit.Name = "txtInvoiceLimit"
        Me.txtInvoiceLimit.Size = New System.Drawing.Size(156, 22)
        Me.txtInvoiceLimit.TabIndex = 18
        Me.txtInvoiceLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(426, 186)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(115, 50)
        Me.btnSave.TabIndex = 12
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(34, 157)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 17)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Invoice Limit"
        '
        'btnDelete
        '
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(426, 126)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(115, 54)
        Me.btnDelete.TabIndex = 11
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        Me.btnDelete.Visible = False
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(297, 14)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(110, 52)
        Me.btnSearch.TabIndex = 16
        Me.btnSearch.Text = "&Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(426, 72)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(115, 49)
        Me.btnEdit.TabIndex = 10
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(125, 273)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(156, 22)
        Me.txtStatus.TabIndex = 15
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(426, 14)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(115, 52)
        Me.btnNew.TabIndex = 9
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(125, 244)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(156, 22)
        Me.txtEmail.TabIndex = 14
        '
        'txtTelephone
        '
        Me.txtTelephone.Location = New System.Drawing.Point(125, 214)
        Me.txtTelephone.Name = "txtTelephone"
        Me.txtTelephone.Size = New System.Drawing.Size(156, 22)
        Me.txtTelephone.TabIndex = 13
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(125, 186)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(156, 22)
        Me.txtAddress.TabIndex = 12
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(125, 127)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(282, 22)
        Me.txtLastName.TabIndex = 11
        '
        'txtSecondName
        '
        Me.txtSecondName.Location = New System.Drawing.Point(125, 99)
        Me.txtSecondName.Name = "txtSecondName"
        Me.txtSecondName.Size = New System.Drawing.Size(282, 22)
        Me.txtSecondName.TabIndex = 10
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(125, 72)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(282, 22)
        Me.txtFirstName.TabIndex = 9
        '
        'txtRollNo
        '
        Me.txtRollNo.Location = New System.Drawing.Point(125, 16)
        Me.txtRollNo.Name = "txtRollNo"
        Me.txtRollNo.Size = New System.Drawing.Size(156, 22)
        Me.txtRollNo.TabIndex = 8
        '
        'dtgrdList
        '
        Me.dtgrdList.AllowUserToAddRows = False
        Me.dtgrdList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgrdList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdList.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dtgrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtgrdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrdList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column7, Me.Column6})
        Me.dtgrdList.Location = New System.Drawing.Point(566, 11)
        Me.dtgrdList.Name = "dtgrdList"
        Me.dtgrdList.ReadOnly = True
        Me.dtgrdList.RowTemplate.Height = 24
        Me.dtgrdList.Size = New System.Drawing.Size(917, 578)
        Me.dtgrdList.TabIndex = 65
        '
        'Column1
        '
        Me.Column1.FillWeight = 40.60914!
        Me.Column1.HeaderText = "Roll No"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.FillWeight = 119.797!
        Me.Column2.HeaderText = "Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.FillWeight = 119.797!
        Me.Column7.HeaderText = "Contact"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.FillWeight = 119.797!
        Me.Column6.HeaderText = "Summary"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'btnBack
        '
        Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBack.BackColor = System.Drawing.SystemColors.Control
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBack.Location = New System.Drawing.Point(1368, 595)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(115, 35)
        Me.btnBack.TabIndex = 66
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'frmSalesPerson
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1495, 642)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.dtgrdList)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmSalesPerson"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Sales Persons"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dtgrdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtStatus As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtTelephone As TextBox
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents txtSecondName As TextBox
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents txtRollNo As TextBox
    Friend WithEvents btnNew As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents dtgrdList As DataGridView
    Friend WithEvents btnBack As Button
    Friend WithEvents txtInvoiceLimit As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtId As TextBox
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents btnBlock As Button
    Friend WithEvents btnUnblock As Button
End Class
