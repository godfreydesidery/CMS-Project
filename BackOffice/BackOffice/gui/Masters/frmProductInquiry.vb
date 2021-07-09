Imports Devart.Data.MySql

Public Class frmProductInquiry

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs)

    End Sub
    Private Function searchInventory(itemCode As String) As Boolean
        Dim found As Boolean = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code

            Dim codeQuery As String = "SELECT  `qty`, `min_inventory`, `max_inventory`, `def_reorder_qty`, `reorder_level` FROM `inventorys` WHERE `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read

                txtMinInventory.Text = reader.GetString("min_inventory")
                txtMaxInventory.Text = reader.GetString("max_inventory")
                txtReorderLevel.Text = reader.GetString("reorder_level")
                txtReorderQty.Text = reader.GetString("def_reorder_qty")
                txtQty.Text = reader.GetString("qty")

                found = True
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return found
    End Function
    Dim itemCodes As String = ""
    Private Function searchItem(itemCode As String) As Boolean
        Dim found As Boolean = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code

            Dim codeQuery As String = "SELECT `item_code`, `item_scan_code`, `item_long_description`, `item_description`, `pck`, `department_id`, `class_id`, `sub_class_id`, `supplier_id`, `unit_cost_price`, `retail_price`, `discount`, `vat`, `margin`, `standard_uom`,`active`, `sellable` FROM `items` WHERE `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                txtItemCode.Text = reader.GetString("item_code")
                itemCode = txtItemCode.Text
                cmbDescription.Text = reader.GetString("item_long_description")
                txtDescription.Text = reader.GetString("item_description")
                txtPck.Text = reader.GetString("pck")
                txtVAT.Text = LCurrency.displayValue(reader.GetString("vat"))
                txtDiscount.Text = LCurrency.displayValue(reader.GetString("discount"))
                txtCostPrice.Text = LCurrency.displayValue(reader.GetString("unit_cost_price"))
                txtRetailPrice.Text = LCurrency.displayValue(reader.GetString("retail_price"))
                txtSupplier.Text = (New Supplier).getSupplierName(reader.GetString("supplier_id"), "")
                txtMargin.Text = LCurrency.displayValue(reader.GetString("margin"))
                txtStandardUOM.Text = reader.GetString("standard_uom")
                txtDepartment.Text = (New Department).getDepartmentName(reader.GetString("department_id"))
                txtClass.Text = (New Class_).getClassName(reader.GetString("class_id"))
                txtSubClass.Text = (New SubClass).getSubClassName(reader.GetString("sub_class_id"))
                If reader.GetString("active") = "1" Then
                    chkDiscontinued.Checked = True
                Else
                    chkDiscontinued.Checked = False
                End If
                If reader.GetString("sellable") = "1" Then
                    chkSellable.Checked = True
                Else
                    chkSellable.Checked = False
                End If
                found = True
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return found
    End Function
    Private Function search()
        If txtBarCode.Text <> "" Then
            Dim itemCode As String = (New Item).getItemCode(txtBarCode.Text)

            If searchItem((New Item).getItemCode(txtBarCode.Text, "")) = True And searchInventory((New Item).getItemCode(txtBarCode.Text, "")) = True Then
                'found
            Else
                'not found
                MsgBox("Could not find an item with bar code: " + txtBarCode.Text, vbOKOnly + vbCritical, "Error: Item not found")
                txtBarCode.Text = ""
            End If
        ElseIf txtItemCode.Text <> "" Then
            If searchItem(txtItemCode.Text) = True And searchInventory(txtItemCode.Text) = True Then
                'found
            Else
                'not found
                MsgBox("Could not find an item with code: " + txtItemCode.Text, vbOKOnly + vbCritical, "Error: Item not found")
                txtItemCode.Text = ""
            End If
        ElseIf cmbDescription.Text <> "" Then
            If searchItem((New Item).getItemCode("", cmbDescription.Text)) = True And searchInventory((New Item).getItemCode("", cmbDescription.Text)) = True Then
                'found
            Else
                'not found
                MsgBox("Could not find an item with description: " + cmbDescription.Text, vbOKOnly + vbCritical, "Error: Item not found")
                txtBarCode.Text = ""
            End If
        Else

        End If
        If txtItemCode.Text = "" Then
            itemCodes = ""
        End If
        Dim barcodes As List(Of String) = (New Item).getBarCodes(txtItemCode.Text)
        lstBarCodes.Items.Clear()
        For i As Integer = 0 To barcodes.Count - 1
            lstBarCodes.Items.Add(barcodes.ElementAt(i))
        Next
        Return vbNull
    End Function
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        search()
    End Sub
    Private Function clearFields()
        txtBarCode.Text = ""
        txtItemCode.Text = ""
        cmbDescription.Text = ""
        txtDescription.Text = ""
        txtPck.Text = ""
        txtVAT.Text = ""
        txtDiscount.Text = ""
        txtCostPrice.Text = ""
        txtRetailPrice.Text = ""
        txtSupplier.Text = ""
        txtMargin.Text = ""
        txtStandardUOM.Text = ""
        txtDepartment.Text = ""
        txtClass.Text = ""
        txtSubClass.Text = ""
        txtMinInventory.Text = ""
        txtMaxInventory.Text = ""
        txtReorderLevel.Text = ""
        txtReorderQty.Text = ""
        txtQty.Text = ""
        chkDiscontinued.Checked = False
        chkSellable.Checked = False
        Return vbNull
    End Function
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        clearFields()
    End Sub

    Private Sub frmProductInquiry_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        clearFields()
    End Sub

    Private Sub txtLongDescription_mouseenter(sender As Object, e As EventArgs)
        Dim list As New List(Of String)
        Dim mySource As New AutoCompleteStringCollection
        Dim item As New Item
        list = item.getItems(cmbDescription.Text)
        mySource.AddRange(list.ToArray)
        cmbDescription.AutoCompleteCustomSource = mySource
        cmbDescription.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cmbDescription.AutoCompleteSource = AutoCompleteSource.CustomSource
    End Sub

    Private Sub txtBarCode_preview(sender As Object, e As PreviewKeyDownEventArgs) Handles txtBarCode.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            txtItemCode.Text = ""
            cmbDescription.Text = ""
            search()
        End If
    End Sub


    Private Sub txtItemCode_Preview(sender As Object, e As PreviewKeyDownEventArgs) Handles txtItemCode.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            txtBarCode.Text = ""
            cmbDescription.Text = ""
            search()
        End If
    End Sub

    Private Sub txtLongDescription_preview(sender As Object, e As PreviewKeyDownEventArgs)
        If e.KeyCode = Keys.Tab Then
            txtBarCode.Text = ""
            txtItemCode.Text = ""
            search()
        End If
    End Sub

    Private Sub frmProductInquiry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim item As New Item
        longList = item.getItems()
    End Sub
    Public Shared GLOBAL_ITEM_CODE As String = ""
    Private Sub txtBarCode_TextChanged(sender As Object, e As EventArgs) Handles txtBarCode.TextChanged

    End Sub

    Private Sub txtBarCode_LostFocus(sender As Object, e As EventArgs) Handles txtBarCode.LostFocus

    End Sub

    Private Sub txtBarCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            search()
        End If
    End Sub

    Private Sub txtLongDescription_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub

    Private Sub txtReorderQty_TextChanged(sender As Object, e As EventArgs) Handles txtReorderQty.TextChanged

    End Sub

    Private Sub txtReorderLevel_TextChanged(sender As Object, e As EventArgs) Handles txtReorderLevel.TextChanged

    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub txtMaxInventory_TextChanged(sender As Object, e As EventArgs) Handles txtMaxInventory.TextChanged

    End Sub

    Private Sub txtMinInventory_TextChanged(sender As Object, e As EventArgs) Handles txtMinInventory.TextChanged

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub Label21_Click(sender As Object, e As EventArgs) Handles Label21.Click

    End Sub

    Private Sub txtQty_TextChanged(sender As Object, e As EventArgs) Handles txtQty.TextChanged

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub txtStandardUOM_TextChanged(sender As Object, e As EventArgs) Handles txtStandardUOM.TextChanged

    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub

    Private Sub txtMargin_TextChanged(sender As Object, e As EventArgs) Handles txtMargin.TextChanged

    End Sub

    Private Sub txtDiscount_TextChanged(sender As Object, e As EventArgs) Handles txtDiscount.TextChanged

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub txtVAT_TextChanged(sender As Object, e As EventArgs) Handles txtVAT.TextChanged

    End Sub

    Private Sub txtRetailPrice_TextChanged(sender As Object, e As EventArgs) Handles txtRetailPrice.TextChanged

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub txtCostPrice_TextChanged(sender As Object, e As EventArgs) Handles txtCostPrice.TextChanged

    End Sub

    Private Sub btnViewSuppliers_Click(sender As Object, e As EventArgs)
        If txtItemCode.Text <> "" Then
            GLOBAL_ITEM_CODE = txtItemCode.Text
            frmViewSuppliers.ShowDialog()
        End If
    End Sub

    Dim longList As New List(Of String)
    Dim shortList As New List(Of String)
    Private Sub cmbDescription_KeyUp(sender As Object, e As EventArgs) Handles cmbDescription.KeyUp
        Dim currentText As String = cmbDescription.Text
        shortList.Clear()
        cmbDescription.Items.Clear()
        cmbDescription.Items.Add(currentText)
        cmbDescription.DroppedDown = True
        For Each text As String In longList
            Dim formattedText As String = text.ToUpper()
            If formattedText.Contains(cmbDescription.Text.ToUpper()) Then
                shortList.Add(text)
            End If
        Next
        cmbDescription.Items.AddRange(shortList.ToArray())
        cmbDescription.SelectionStart = cmbDescription.Text.Length
        Cursor.Current = Cursors.Default
    End Sub
End Class