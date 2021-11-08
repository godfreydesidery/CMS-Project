Imports Devart.Data.MySql

Public Class SalesReceipt
    Public GL_RECEIPT_ID As String = ""
    Public GL_RECEIPT_NO As String = ""
    Public GL_RECEIPT_DATE As String = ""
    Public GL_CUSTOMER_NO As String = ""
    Public GL_PAYMENT_MODE As String = ""
    Public GL_AMOUNT As Double = 0
    Public GL_ALLOCATED As Double = 0
    Public GL_COMMENTS As String = ""

    Public Function generateReceiptNo() As String
        Dim no As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `receipt_id` FROM `sales_receipts` ORDER BY `receipt_id` DESC LIMIT 1"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                no = (Val(reader.GetString("receipt_id")) + 1).ToString
                Exit While
            End While
            If no = "" Then
                no = "SRC-1"
            Else
                no = "SRC-" + no
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return no
    End Function

    Public Function search(receiptNo As String) As Boolean
        Dim found As Boolean = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `receipt_id`, `receipt_no`, `date_time`, `receipt_date`, `customer_no`, `payment_mode`, `amount`, `comments`, `allocated` FROM `sales_receipts` WHERE `receipt_no`='" + receiptNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                GL_RECEIPT_ID = reader.GetString("receipt_id")
                GL_RECEIPT_NO = reader.GetString("receipt_no")
                GL_RECEIPT_DATE = reader.GetString("receipt_date")
                GL_CUSTOMER_NO = reader.GetString("customer_no")
                GL_PAYMENT_MODE = reader.GetString("payment_mode")
                GL_AMOUNT = reader.GetString("amount")
                GL_ALLOCATED = reader.GetString("allocated")
                GL_COMMENTS = reader.GetString("comments")

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
    Public Function addReceipt(receiptNo As String, receiptDate As String, customerNo As String, paymentMode As String, amount As Double, comments As String) As Boolean
        Dim added As Boolean = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'Dim reader As MySqlDataReader
            'create bar code
            Dim codeQuery As String = "INSERT INTO `sales_receipts`( `receipt_no`, `receipt_date`, `customer_no`, `payment_mode`, `amount`, `comments`) VALUES (@receipt_no,@receipt_date,@customer_no,@payment_mode,@amount,@comments)"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@receipt_no", receiptNo)
            command.Parameters.AddWithValue("@receipt_date", receiptDate)
            command.Parameters.AddWithValue("@customer_no", customerNo)
            command.Parameters.AddWithValue("@payment_mode", paymentMode)
            command.Parameters.AddWithValue("@amount", amount)
            command.Parameters.AddWithValue("@comments", comments)
            command.ExecuteNonQuery()
            conn.Close()
            added = True
        Catch ex As MySqlException
            added = False
            MsgBox(ex.Message)
        Catch ex As Exception
            added = False
            MsgBox(ex.Message + ex.GetType.ToString)
        End Try

        Return added
    End Function
    Public Function editReceipt(receiptNo As String, paymentMode As String, comments As String) As Boolean
        Dim edited As Boolean = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'Dim reader As MySqlDataReader
            'create bar code
            Dim codeQuery As String = "UPDATE `sales_receipts` SET `payment_mode`='" + paymentMode + "',`comments`='" + comments + "' WHERE `receipt_no`='" + receiptNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            edited = True
        Catch ex As Exception
            edited = False
            MsgBox(ex.Message)
        End Try

        Return edited
    End Function
    Public Function deleteReceipt(receiptNo As String) As Boolean
        Dim deleted As Boolean = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "DELETE FROM `sales_receipts` WHERE `receipt_no`='" + receiptNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            deleted = True
        Catch ex As Exception
            deleted = False
            MsgBox(ex.Message)
        End Try

        Return deleted
    End Function
End Class
