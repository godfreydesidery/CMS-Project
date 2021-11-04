Imports Devart.Data.MySql

Public Class frmCorporateCustomers

    Private Sub btnBack_Click(sender As Object, e As EventArgs)
        Me.Dispose()
    End Sub
    Private Function lock()

        Return vbNull
    End Function
    Private Function unlock()

        Return vbNull
    End Function
    Private Function clear()

        Return vbNull
    End Function
    Private Function searchCustomers(customerNo As String, customerName As String)

        ' dtgrdCustomerList.Rows.Clear()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim query As String = ""
            If customerName <> "" Then
                query = "SELECT `sn`, `customer_no`, `customer_name`, `address`, `location`, `telephone`, `phone`, `email`, `fax` FROM `customers` WHERE `customer_name`LIKE'%" + customerName + "%'"
            Else
                query = "SELECT `sn`, `customer_no`, `customer_name`, `address`, `location`, `telephone`, `phone`, `email`, `fax` FROM `customers` WHERE `customer_no`LIKE'%" + customerNo + "%'"
            End If
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()

            Dim custNo As String = ""
            Dim custName As String = ""

            While reader.Read

                custNo = reader.GetString("customer_no")
                custName = reader.GetString("customer_name")

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = custNo
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = custName
                dtgrdRow.Cells.Add(dtgrdCell)

                '  dtgrdCustomerList.Rows.Add(dtgrdRow)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return vbNull
    End Function
    Private Function search(customerNo As String)
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim query As String = ""
            query = "SELECT `sn`, `customer_no`, `customer_name`, `address`, `location`, `telephone`, `phone`, `email`, `fax` FROM `customers` WHERE `customer_no`='" + customerNo + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read

                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return vbNull
    End Function

    Private Sub btnNew_Click(sender As Object, e As EventArgs)
        clear()
        unlock()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs)
        unlock()
    End Sub

End Class