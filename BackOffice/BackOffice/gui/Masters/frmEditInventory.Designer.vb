<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditInventory
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
        Me.txtMinInventory = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.txtMaxInventory = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtReorderQuantity = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAdd = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDeduct = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNewQuantity = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtItemCode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtReorderLevel = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtMinInventory
        '
        Me.txtMinInventory.Location = New System.Drawing.Point(122, 159)
        Me.txtMinInventory.MaxLength = 20
        Me.txtMinInventory.Name = "txtMinInventory"
        Me.txtMinInventory.Size = New System.Drawing.Size(174, 22)
        Me.txtMinInventory.TabIndex = 48
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(49, 127)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(61, 17)
        Me.Label15.TabIndex = 43
        Me.Label15.Text = "Quantity"
        '
        'txtQuantity
        '
        Me.txtQuantity.Location = New System.Drawing.Point(122, 127)
        Me.txtQuantity.MaxLength = 20
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.ReadOnly = True
        Me.txtQuantity.Size = New System.Drawing.Size(174, 22)
        Me.txtQuantity.TabIndex = 44
        '
        'txtMaxInventory
        '
        Me.txtMaxInventory.Location = New System.Drawing.Point(122, 187)
        Me.txtMaxInventory.MaxLength = 20
        Me.txtMaxInventory.Name = "txtMaxInventory"
        Me.txtMaxInventory.Size = New System.Drawing.Size(174, 22)
        Me.txtMaxInventory.TabIndex = 50
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(26, 239)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(86, 17)
        Me.Label16.TabIndex = 45
        Me.Label16.Text = "Reorder Qty"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(55, 187)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(55, 17)
        Me.Label18.TabIndex = 49
        Me.Label18.Text = "Max Inv"
        '
        'txtReorderQuantity
        '
        Me.txtReorderQuantity.Location = New System.Drawing.Point(122, 239)
        Me.txtReorderQuantity.MaxLength = 20
        Me.txtReorderQuantity.Name = "txtReorderQuantity"
        Me.txtReorderQuantity.Size = New System.Drawing.Size(174, 22)
        Me.txtReorderQuantity.TabIndex = 46
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(58, 159)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(52, 17)
        Me.Label17.TabIndex = 47
        Me.Label17.Text = "Min Inv"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(79, 270)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 17)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Add"
        '
        'txtAdd
        '
        Me.txtAdd.Location = New System.Drawing.Point(124, 267)
        Me.txtAdd.MaxLength = 20
        Me.txtAdd.Name = "txtAdd"
        Me.txtAdd.Size = New System.Drawing.Size(172, 22)
        Me.txtAdd.TabIndex = 52
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(57, 298)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 17)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "Deduct"
        '
        'txtDeduct
        '
        Me.txtDeduct.Location = New System.Drawing.Point(124, 295)
        Me.txtDeduct.MaxLength = 20
        Me.txtDeduct.Name = "txtDeduct"
        Me.txtDeduct.Size = New System.Drawing.Size(172, 22)
        Me.txtDeduct.TabIndex = 54
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(122, 363)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(68, 39)
        Me.btnSave.TabIndex = 55
        Me.btnSave.Text = "OK"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(228, 363)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(68, 39)
        Me.btnCancel.TabIndex = 56
        Me.btnCancel.Text = "Close"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 326)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 17)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "New Quantity"
        '
        'txtNewQuantity
        '
        Me.txtNewQuantity.Location = New System.Drawing.Point(124, 323)
        Me.txtNewQuantity.MaxLength = 20
        Me.txtNewQuantity.Name = "txtNewQuantity"
        Me.txtNewQuantity.ReadOnly = True
        Me.txtNewQuantity.Size = New System.Drawing.Size(172, 22)
        Me.txtNewQuantity.TabIndex = 58
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(39, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 17)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "Item Code"
        '
        'txtItemCode
        '
        Me.txtItemCode.Location = New System.Drawing.Point(122, 89)
        Me.txtItemCode.MaxLength = 20
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.ReadOnly = True
        Me.txtItemCode.Size = New System.Drawing.Size(174, 22)
        Me.txtItemCode.TabIndex = 60
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 211)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 17)
        Me.Label5.TabIndex = 61
        Me.Label5.Text = "Reorder Level"
        '
        'txtReorderLevel
        '
        Me.txtReorderLevel.Location = New System.Drawing.Point(122, 211)
        Me.txtReorderLevel.MaxLength = 20
        Me.txtReorderLevel.Name = "txtReorderLevel"
        Me.txtReorderLevel.Size = New System.Drawing.Size(174, 22)
        Me.txtReorderLevel.TabIndex = 62
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(67, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(166, 24)
        Me.Label6.TabIndex = 63
        Me.Label6.Text = "Change inventory"
        '
        'frmEditInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(308, 434)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtReorderLevel)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtItemCode)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNewQuantity)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDeduct)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtAdd)
        Me.Controls.Add(Me.txtMinInventory)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtQuantity)
        Me.Controls.Add(Me.txtMaxInventory)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtReorderQuantity)
        Me.Controls.Add(Me.Label17)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEditInventory"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit Inventory"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtMinInventory As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents txtMaxInventory As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents txtReorderQuantity As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtAdd As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDeduct As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNewQuantity As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtItemCode As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtReorderLevel As TextBox
    Friend WithEvents Label6 As Label
End Class
