Imports Devart.Data.MySql

Public Class Allocation
    Public GL_ALLOCATION_ID As String = ""
    Public GL_ALLOCATION_NO As String = ""
    Public GL_ALLOCATION_DATE As String = ""
    Public GL_CUSTOMER_NO As String = ""
    Public GL_INVOICE_NO As String = ""
    Public GL_RECEIPT_NO As String = ""
    Public GL_AMOUNT As Double = 0


    Public Function generateAllocationNo() As String
        Dim no As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `allocation_id` FROM `allocations` ORDER BY `allocation_id` DESC LIMIT 1"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                no = (Val(reader.GetString("allocation_id")) + 1).ToString
                Exit While
            End While
            If no = "" Then
                no = "ALC-1"
            Else
                no = "ALC-" + no
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return no
    End Function

    Public Function search(allocationNo As String) As Boolean
        Dim found As Boolean = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `allocation_id`, `allocation_no`, `date_time`, `allocation_date`, `invoice_no`, `receipt_no`, `amount`, `user_id` FROM `allocations` WHERE `allocation_no`='" + allocationNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                GL_ALLOCATION_ID = reader.GetString("allocation_id")
                GL_ALLOCATION_NO = reader.GetString("allocation_no")
                GL_ALLOCATION_DATE = reader.GetString("allocation_date")
                GL_INVOICE_NO = reader.GetString("invoice_no")
                GL_RECEIPT_NO = reader.GetString("receipt_no")
                GL_AMOUNT = reader.GetString("amount")
                found = True

                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            found = False
            MsgBox(ex.ToString)
        End Try

        Return found
    End Function
    Public Function addAllocation(allocationNo As String, allocationDate As String, invoiceNo As String, receiptNo As String, amount As Double, status As String) As Boolean
        Dim added As Boolean = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'Dim reader As MySqlDataReader
            'create bar code
            Dim query As String = "INSERT INTO `allocations`( `allocation_no`, `allocation_date`, `invoice_no`, `receipt_no`, `amount`, `user_id`) VALUES ('" + allocationNo + "','" + allocationDate + "','" + invoiceNo + "','" + receiptNo + "','" + amount.ToString + "','" + User.CURRENT_USER_ID + "');"
            query = query + "UPDATE `sales_invoices` SET `paid` = `paid` + " + amount.ToString + ", `status` = '" + status + "' WHERE `invoice_no` = '" + invoiceNo + "';"
            query = query + "UPDATE `sales_receipts` SET `allocated` = `allocated` + " + amount.ToString + " WHERE `receipt_no` = '" + receiptNo + "';"

            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            added = True
            MsgBox("Allocation successiful", vbOKOnly + vbInformation, "Success")
        Catch ex As MySqlException
            added = False
            MsgBox(ex.Message)
        Catch ex As Exception
            added = False
            MsgBox(ex.Message)
        End Try
        Return added
    End Function

End Class
