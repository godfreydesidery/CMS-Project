<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSalesReceipts
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnEdit = New System.Windows.Forms.ToolStripButton()
        Me.btnClear = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.cmbDescription = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtgrdParticulars = New System.Windows.Forms.DataGridView()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.dtgrdParticulars, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnEdit, Me.btnClear, Me.btnDelete, Me.btnSave, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1216, 27)
        Me.ToolStrip1.TabIndex = 110
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
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 27)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(400, 681)
        Me.Panel1.TabIndex = 111
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(400, 27)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(816, 40)
        Me.Panel2.TabIndex = 112
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Button2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(400, 668)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(816, 40)
        Me.Panel3.TabIndex = 113
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(1176, 67)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(40, 601)
        Me.Panel4.TabIndex = 114
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.ComboBox1)
        Me.Panel5.Controls.Add(Me.TextBox5)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Controls.Add(Me.cmbDescription)
        Me.Panel5.Controls.Add(Me.Button1)
        Me.Panel5.Controls.Add(Me.TextBox4)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.TextBox2)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.TextBox1)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(400, 275)
        Me.Panel5.TabIndex = 0
        '
        'cmbDescription
        '
        Me.cmbDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDescription.FormattingEnabled = True
        Me.cmbDescription.Location = New System.Drawing.Point(103, 87)
        Me.cmbDescription.Name = "cmbDescription"
        Me.cmbDescription.Size = New System.Drawing.Size(289, 28)
        Me.cmbDescription.TabIndex = 125
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(294, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 35)
        Me.Button1.TabIndex = 124
        Me.Button1.Text = "Search"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(103, 200)
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(289, 65)
        Me.TextBox4.TabIndex = 123
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 200)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 17)
        Me.Label4.TabIndex = 122
        Me.Label4.Text = "Comments"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(29, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 17)
        Me.Label3.TabIndex = 121
        Me.Label3.Text = "Customer"
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(103, 54)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(289, 27)
        Me.TextBox2.TabIndex = 120
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 17)
        Me.Label2.TabIndex = 119
        Me.Label2.Text = "Receipt Date"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(103, 13)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(180, 27)
        Me.TextBox1.TabIndex = 118
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 17)
        Me.Label1.TabIndex = 117
        Me.Label1.Text = "Receipt No"
        '
        'TextBox5
        '
        Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(103, 157)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(180, 27)
        Me.TextBox5.TabIndex = 129
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(41, 163)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 17)
        Me.Label6.TabIndex = 128
        Me.Label6.Text = "Amount"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Cash", "Cheque", "Other"})
        Me.ComboBox1.Location = New System.Drawing.Point(103, 121)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(180, 28)
        Me.ComboBox1.TabIndex = 130
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(24, 127)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 17)
        Me.Label7.TabIndex = 131
        Me.Label7.Text = "Pay Mode"
        '
        'dtgrdParticulars
        '
        Me.dtgrdParticulars.AllowUserToAddRows = False
        Me.dtgrdParticulars.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgrdParticulars.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdParticulars.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dtgrdParticulars.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dtgrdParticulars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrdParticulars.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column5, Me.Column4})
        Me.dtgrdParticulars.Location = New System.Drawing.Point(406, 73)
        Me.dtgrdParticulars.Name = "dtgrdParticulars"
        Me.dtgrdParticulars.ReadOnly = True
        Me.dtgrdParticulars.RowTemplate.Height = 24
        Me.dtgrdParticulars.Size = New System.Drawing.Size(764, 589)
        Me.dtgrdParticulars.TabIndex = 115
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackgroundImage = Global.BackOffice.My.Resources.Resources.red_back_arrow
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.Location = New System.Drawing.Point(713, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(100, 35)
        Me.Button2.TabIndex = 115
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "ID"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'Column2
        '
        Me.Column2.HeaderText = "No"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Date"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Customer"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Amount"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'frmSalesReceipts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1216, 708)
        Me.Controls.Add(Me.dtgrdParticulars)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frmSalesReceipts"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Sales Receipts"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.dtgrdParticulars, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Label7 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbDescription As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dtgrdParticulars As DataGridView
    Friend WithEvents Button2 As Button
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
End Class
