﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserEnrolment
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
        Me.btnBack = New System.Windows.Forms.Button()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.txtConfPassword = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtPayrollNo = New System.Windows.Forms.TextBox()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtSecondName = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtgrdUsers = New System.Windows.Forms.DataGridView()
        Me.colUsername = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPayrollNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colnames = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.role = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbRole = New System.Windows.Forms.ComboBox()
        CType(Me.dtgrdUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.SystemColors.Control
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBack.Location = New System.Drawing.Point(795, 651)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(115, 35)
        Me.btnBack.TabIndex = 5
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(31, 154)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(99, 22)
        Me.txtID.TabIndex = 23
        Me.txtID.Visible = False
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"", "ACTIVE", "INACTIVE"})
        Me.cmbStatus.Location = New System.Drawing.Point(613, 104)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(269, 24)
        Me.cmbStatus.TabIndex = 22
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(525, 104)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 17)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "User Status"
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(368, 181)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(115, 35)
        Me.btnSave.TabIndex = 20
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(249, 181)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(115, 35)
        Me.btnDelete.TabIndex = 19
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(128, 181)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(115, 35)
        Me.btnEdit.TabIndex = 18
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(12, 181)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(115, 35)
        Me.btnNew.TabIndex = 17
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'txtConfPassword
        '
        Me.txtConfPassword.Location = New System.Drawing.Point(613, 76)
        Me.txtConfPassword.Name = "txtConfPassword"
        Me.txtConfPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfPassword.Size = New System.Drawing.Size(269, 22)
        Me.txtConfPassword.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(486, 79)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(121, 17)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Confirm Password"
        '
        'btnSearch
        '
        Me.btnSearch.Enabled = False
        Me.btnSearch.Location = New System.Drawing.Point(355, 14)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(115, 35)
        Me.btnSearch.TabIndex = 14
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(613, 48)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(269, 22)
        Me.txtPassword.TabIndex = 12
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(115, 14)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(226, 22)
        Me.txtUsername.TabIndex = 11
        '
        'txtPayrollNo
        '
        Me.txtPayrollNo.Location = New System.Drawing.Point(115, 42)
        Me.txtPayrollNo.Name = "txtPayrollNo"
        Me.txtPayrollNo.Size = New System.Drawing.Size(226, 22)
        Me.txtPayrollNo.TabIndex = 10
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(115, 126)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(355, 22)
        Me.txtLastName.TabIndex = 9
        '
        'txtSecondName
        '
        Me.txtSecondName.Location = New System.Drawing.Point(115, 98)
        Me.txtSecondName.Name = "txtSecondName"
        Me.txtSecondName.Size = New System.Drawing.Size(355, 22)
        Me.txtSecondName.TabIndex = 8
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(115, 70)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(355, 22)
        Me.txtFirstName.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(538, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 17)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Password"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(31, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 17)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Username*"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Payroll No"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 17)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Last Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Second Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "First Name"
        '
        'dtgrdUsers
        '
        Me.dtgrdUsers.AllowUserToAddRows = False
        Me.dtgrdUsers.AllowUserToDeleteRows = False
        Me.dtgrdUsers.AllowUserToOrderColumns = True
        Me.dtgrdUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdUsers.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dtgrdUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrdUsers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colUsername, Me.colPayrollNo, Me.colnames, Me.role})
        Me.dtgrdUsers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtgrdUsers.Location = New System.Drawing.Point(12, 222)
        Me.dtgrdUsers.Name = "dtgrdUsers"
        Me.dtgrdUsers.RowTemplate.Height = 24
        Me.dtgrdUsers.Size = New System.Drawing.Size(896, 423)
        Me.dtgrdUsers.TabIndex = 7
        '
        'colUsername
        '
        Me.colUsername.HeaderText = "Username"
        Me.colUsername.Name = "colUsername"
        Me.colUsername.Visible = False
        '
        'colPayrollNo
        '
        Me.colPayrollNo.HeaderText = "Payroll No"
        Me.colPayrollNo.Name = "colPayrollNo"
        '
        'colnames
        '
        Me.colnames.HeaderText = "Name"
        Me.colnames.Name = "colnames"
        '
        'role
        '
        Me.role.HeaderText = "Role/Function"
        Me.role.Name = "role"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.cmbRole)
        Me.Panel1.Controls.Add(Me.txtUsername)
        Me.Panel1.Controls.Add(Me.txtFirstName)
        Me.Panel1.Controls.Add(Me.cmbStatus)
        Me.Panel1.Controls.Add(Me.txtSecondName)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtID)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txtLastName)
        Me.Panel1.Controls.Add(Me.txtPayrollNo)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtConfPassword)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtPassword)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(896, 163)
        Me.Panel1.TabIndex = 24
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(570, 17)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 17)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Role"
        '
        'cmbRole
        '
        Me.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRole.FormattingEnabled = True
        Me.cmbRole.Items.AddRange(New Object() {"", "ADMIN", "MANAGER", "ASSISTANT MANAGER", "CHIEF CASHIER", "CASHIER", "WAITER", "ACCOUNTS", "MARKETING"})
        Me.cmbRole.Location = New System.Drawing.Point(613, 18)
        Me.cmbRole.Name = "cmbRole"
        Me.cmbRole.Size = New System.Drawing.Size(269, 24)
        Me.cmbRole.TabIndex = 24
        '
        'frmUserEnrolment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(917, 691)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.dtgrdUsers)
        Me.Controls.Add(Me.btnBack)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUserEnrolment"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "User Enrollment"
        CType(Me.dtgrdUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents txtConfPassword As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPayrollNo As TextBox
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents txtSecondName As TextBox
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnNew As Button
    Friend WithEvents cmbStatus As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents dtgrdUsers As DataGridView
    Friend WithEvents colUsername As DataGridViewTextBoxColumn
    Friend WithEvents colPayrollNo As DataGridViewTextBoxColumn
    Friend WithEvents colnames As DataGridViewTextBoxColumn
    Friend WithEvents role As DataGridViewTextBoxColumn
    Friend WithEvents txtID As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents cmbRole As ComboBox
End Class
