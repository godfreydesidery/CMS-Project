﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMaterialStockStatus
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnExportToExcel = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cmbMaterialName = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lstCode = New System.Windows.Forms.ListBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnSearchItem = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtMaterialCode = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtgrdList = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dtgrdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnExportToExcel
        '
        Me.btnExportToExcel.Location = New System.Drawing.Point(637, 76)
        Me.btnExportToExcel.Name = "btnExportToExcel"
        Me.btnExportToExcel.Size = New System.Drawing.Size(169, 34)
        Me.btnExportToExcel.TabIndex = 93
        Me.btnExportToExcel.Text = "Export to Excel"
        Me.btnExportToExcel.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(462, 76)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(169, 34)
        Me.btnPrint.TabIndex = 88
        Me.btnPrint.Text = "Export to PDF"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.cmbMaterialName)
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Controls.Add(Me.lstCode)
        Me.Panel3.Controls.Add(Me.btnAdd)
        Me.Panel3.Controls.Add(Me.btnSearchItem)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.txtMaterialCode)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Location = New System.Drawing.Point(5, 116)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(341, 266)
        Me.Panel3.TabIndex = 91
        '
        'cmbMaterialName
        '
        Me.cmbMaterialName.FormattingEnabled = True
        Me.cmbMaterialName.Location = New System.Drawing.Point(6, 95)
        Me.cmbMaterialName.Name = "cmbMaterialName"
        Me.cmbMaterialName.Size = New System.Drawing.Size(326, 24)
        Me.cmbMaterialName.TabIndex = 100
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(228, 126)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 34)
        Me.Button1.TabIndex = 65
        Me.Button1.Text = "Clear"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lstCode
        '
        Me.lstCode.FormattingEnabled = True
        Me.lstCode.ItemHeight = 16
        Me.lstCode.Location = New System.Drawing.Point(90, 166)
        Me.lstCode.Name = "lstCode"
        Me.lstCode.Size = New System.Drawing.Size(242, 84)
        Me.lstCode.TabIndex = 64
        '
        'btnAdd
        '
        Me.btnAdd.Enabled = False
        Me.btnAdd.Location = New System.Drawing.Point(88, 126)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(104, 34)
        Me.btnAdd.TabIndex = 63
        Me.btnAdd.Text = "Add>>"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnSearchItem
        '
        Me.btnSearchItem.Location = New System.Drawing.Point(235, 19)
        Me.btnSearchItem.Name = "btnSearchItem"
        Me.btnSearchItem.Size = New System.Drawing.Size(97, 50)
        Me.btnSearchItem.TabIndex = 62
        Me.btnSearchItem.Text = "Search"
        Me.btnSearchItem.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(95, 17)
        Me.Label11.TabIndex = 56
        Me.Label11.Text = "Material Code"
        '
        'txtMaterialCode
        '
        Me.txtMaterialCode.Location = New System.Drawing.Point(100, 19)
        Me.txtMaterialCode.MaxLength = 50
        Me.txtMaterialCode.Name = "txtMaterialCode"
        Me.txtMaterialCode.Size = New System.Drawing.Size(129, 22)
        Me.txtMaterialCode.TabIndex = 58
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 75)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 17)
        Me.Label10.TabIndex = 57
        Me.Label10.Text = "Description"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.cmbCategory)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Location = New System.Drawing.Point(5, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(341, 105)
        Me.Panel1.TabIndex = 92
        '
        'cmbCategory
        '
        Me.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(88, 5)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(245, 24)
        Me.cmbCategory.TabIndex = 52
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 17)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "Category"
        '
        'dtgrdList
        '
        Me.dtgrdList.AllowUserToAddRows = False
        Me.dtgrdList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgrdList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdList.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dtgrdList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dtgrdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrdList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column6, Me.Column5, Me.Column3, Me.Column4, Me.Column7})
        Me.dtgrdList.Location = New System.Drawing.Point(352, 116)
        Me.dtgrdList.Name = "dtgrdList"
        Me.dtgrdList.ReadOnly = True
        Me.dtgrdList.RowTemplate.Height = 24
        Me.dtgrdList.Size = New System.Drawing.Size(1112, 632)
        Me.dtgrdList.TabIndex = 90
        '
        'Column1
        '
        Me.Column1.FillWeight = 84.25756!
        Me.Column1.HeaderText = "Code"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.FillWeight = 294.8904!
        Me.Column2.HeaderText = "Description"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Category"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "UOM"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column3
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column3.FillWeight = 53.87895!
        Me.Column3.HeaderText = "Qty"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column4.FillWeight = 84.25756!
        Me.Column4.HeaderText = "Price"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column7
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column7.FillWeight = 84.25756!
        Me.Column7.HeaderText = "Amount"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'btnBack
        '
        Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBack.BackColor = System.Drawing.SystemColors.Control
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBack.Location = New System.Drawing.Point(1358, 754)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(115, 35)
        Me.btnBack.TabIndex = 89
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(352, 76)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(104, 34)
        Me.btnGenerate.TabIndex = 87
        Me.btnGenerate.Text = "Run"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'frmMaterialStockStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1479, 795)
        Me.Controls.Add(Me.btnExportToExcel)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dtgrdList)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnGenerate)
        Me.Name = "frmMaterialStockStatus"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Material Stock Status"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dtgrdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnExportToExcel As Button
    Friend WithEvents btnPrint As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents cmbMaterialName As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents lstCode As ListBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnSearchItem As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents txtMaterialCode As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cmbCategory As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents dtgrdList As DataGridView
    Friend WithEvents btnBack As Button
    Friend WithEvents btnGenerate As Button
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
End Class
