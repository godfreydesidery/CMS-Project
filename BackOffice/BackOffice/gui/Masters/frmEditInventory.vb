Imports Devart.Data.MySql

Public Class frmEditInventory
    Dim itemCode As String = ""
    Dim qty As Integer = 0
    Dim minInv As Integer = 0
    Dim maxInv As Integer = 0
    Dim reorderQty As Integer = 0
    Dim reorderLevel As Integer = 0
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub
    Private Function setValues()
        itemCode = txtItemCode.Text
        qty = Val(txtQuantity.Text)
        minInv = Val(txtMinInventory.Text)
        maxInv = Val(txtMaxInventory.Text)
        reorderQty = Val(txtReorderQuantity.Text)
        reorderLevel = Val(txtReorderLevel.Text)
        Return vbNull
    End Function
    Private Function _validate()

        Return vbNull
    End Function
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Val(txtMinInventory.Text) > Val(txtMaxInventory.Text) Then
            MsgBox("Minimum inventory limit should be less than or equal to Maximum inventory limit")
            Exit Sub
        End If
        If Val(txtReorderLevel.Text) < Val(txtMinInventory.Text) Then
            MsgBox("Reorder level should exceed minimum inventory limit")
            Exit Sub
        End If
        If Val(txtReorderQuantity.Text) > Val(txtMaxInventory.Text) Then
            MsgBox("Reorder quantity should not exceed the maximum inventory limit")
            Exit Sub
        End If
        Dim res As Integer = MsgBox("Confirm inventory update?", vbQuestion + vbYesNo, "Update inventory")
        If res = DialogResult.No Then
            Exit Sub
        End If
        If Val(txtMinInventory.Text) < 0 Or Val(txtMaxInventory.Text) < 0 Or Val(txtReorderQuantity.Text) < 0 Or Val(txtReorderLevel.Text) < 0 Then
            MsgBox("Values should not be less than zero")
            Exit Sub
        End If
        Try
            setValues()
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand
            Dim query As String = "UPDATE `inventorys` SET `qty`=" + Math.Round((Val(txtNewQuantity.Text)), 2, MidpointRounding.AwayFromZero).ToString + ",`min_inventory`=" + Math.Round((Val(minInv)), 2, MidpointRounding.AwayFromZero).ToString + ",`max_inventory`=" + Math.Round((Val(maxInv)), 2, MidpointRounding.AwayFromZero).ToString + ",`def_reorder_qty`=" + Math.Round((Val(reorderQty)), 2, MidpointRounding.AwayFromZero).ToString + ",`reorder_level`=" + Math.Round((Val(txtReorderLevel.Text)), 2, MidpointRounding.AwayFromZero).ToString + " WHERE `item_code`='" + itemCode.ToString + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            Dim stockCard As New StockCard
            If (Val(txtAdd.Text) > 0) Then
                stockCard.qtyIn(Day.DAY, itemCode, Val(txtAdd.Text), Val(txtNewQuantity.Text), "Inventory Update, Stock Increment")
            End If
            If (Val(txtDeduct.Text) > 0) Then
                stockCard.qtyOut(Day.DAY, itemCode, Val(txtDeduct.Text), Val(txtNewQuantity.Text), "Inventory Update, Stock Decrement")
            End If

            MsgBox("Inventory updated successifully", vbInformation + vbOKOnly, "Success: Inventory update")
            Me.Dispose()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub frmEditInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conn As New MySqlConnection(Database.conString)

        Try
            Dim command As New MySqlCommand()
            Dim code As String = Item.GLOBAL_ITEM_CODE
            Dim Query As String = "SELECT `sn`, `item_code`, `qty`, `min_inventory`, `max_inventory`, `def_reorder_qty`,`reorder_level` FROM `inventorys` WHERE `item_code`='" + code + "'"
            conn.Open()
            command.CommandText = Query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader
            If reader.HasRows Then
                While reader.Read
                    itemCode = reader.GetString("item_code")
                    qty = Val(reader.GetString("qty"))
                    minInv = Val(reader.GetString("min_inventory"))
                    maxInv = Val(reader.GetString("max_inventory"))
                    reorderQty = Val(reader.GetString("def_reorder_qty"))
                    reorderLevel = Val(reader.GetString("reorder_level"))
                    Exit While
                End While
            End If
            txtItemCode.Text = itemCode.ToString
            txtQuantity.Text = qty.ToString
            txtMinInventory.Text = minInv.ToString
            txtMaxInventory.Text = maxInv.ToString
            txtReorderQuantity.Text = reorderQty.ToString
            txtReorderLevel.Text = reorderLevel.ToString

            txtNewQuantity.Text = (Val(txtQuantity.Text)).ToString

            conn.Close()
        Catch ex As Devart.Data.MySql.MySqlException
            ErrorMessage.dbConnectionError()
            Exit Sub
        End Try
    End Sub

    Private Sub txtAdd_TextChanged(sender As Object, e As EventArgs) Handles txtAdd.TextChanged
        If Not IsNumeric(txtAdd.Text) Or Val(txtAdd.Text) < 0 Then
            txtAdd.Text = ""
        End If
        txtDeduct.Text = ""
        txtNewQuantity.Text = Math.Round((Val(txtAdd.Text)), 2, MidpointRounding.AwayFromZero) + Val(txtQuantity.Text).ToString
    End Sub

    Private Sub txtDeduct_TextChanged(sender As Object, e As EventArgs) Handles txtDeduct.TextChanged
        If Not IsNumeric(txtDeduct.Text) Or Val(txtDeduct.Text) < 0 Then
            txtDeduct.Text = ""
        End If
        txtAdd.Text = ""
        txtNewQuantity.Text = Val(txtQuantity.Text) - Math.Round((Val(txtDeduct.Text)), 2, MidpointRounding.AwayFromZero)
    End Sub
End Class