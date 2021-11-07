Imports Devart.Data.MySql

Public Class Quotation
    Inherits Item


    Public Shared GLOBAL_QUOTATION_NO As String = ""
    Public Shared GLOBAL_CUSTOMER As String = ""


    Public GL_ID As String = ""
    Public GL_QUOTATION_NO As String = ""
    Public GL_QUOTATION_DATE As String = ""
    Public GL_STATUS As String = ""
    Public GL_CUSTOMER_NAME As String = ""
    Public GL_CUSTOMER_ADDRESS As String = ""


    Public GL_DESCRIPTION As String = ""

    Public GL_QTY As Double = 0
    Public GL_PRICE As Double = 0

    Public Function generateQuotationNo() As String
        Dim no As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `quotation_id` FROM `quotations` ORDER BY `quotation_id` DESC LIMIT 1"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                no = (Val(reader.GetString("quotation_id")) + 1).ToString
                Exit While
            End While
            If no = "" Then
                no = "QT-1"
            Else
                no = "QT-" + no
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return no
    End Function
    Public Function getOrderTotal(orderno As String)
        Dim total As Double = 0
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT  (`quantity`* `unit_cost_price`) AS `total` FROM `order_details` WHERE `order_no`='" + orderno + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                total = total + Val(reader.GetString("total"))
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return total
    End Function


    Public Function getInvoiceId(invoiceNo As String) As String
        Dim id As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `id` FROM `sales_invoices` WHERE `invoice_no`='" + invoiceNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                id = reader.GetString("id")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return id
    End Function
    Public Function getInvoiceDate(quotationNo As String) As String
        Dim _date As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `quotation_date` FROM `quotations` WHERE `quotation_no`='" + quotationNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                _date = reader.GetString("quotation_date")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return _date
    End Function

    Public Function getQuotation(quotationNo As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `sales_invoices`.`invoice_id` AS `id`, `sales_invoices`.`invoice_no` AS `invoice_no`, `sales_invoices`.`customer_no` AS `customer_no`, `sales_invoices`.`invoice_date` AS `invoice_date`, `sales_invoices`.`status` AS `status` FROM `sales_invoices` WHERE `sales_invoices`.`invoice_no`='" + invoiceNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                Me.GL_ID = reader.GetString("id")
                Me.GL_INVOICE_NO = reader.GetString("invoice_no")
                Me.GL_INVOICE_DATE = reader.GetString("invoice_date")
                Me.GL_STATUS = reader.GetString("status")
                Me.GL_CUSTOMER_NAME = (New CorporateCustomer).getCustomerName("", reader.GetString("customer_no"))
                '   Me.GL_CUSTOMER_ADDRESS = reader.GetString("customer_address")

                success = True
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
    Public Function getStatus(invoiceNo As String) As String
        Dim status As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `status` FROM `sales_invoices` WHERE `invoice_no`='" + invoiceNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                status = reader.GetString("status")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return status
    End Function


    Public Function addNewInvoice() As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "INSERT INTO `sales_invoices`(  `invoice_no`, `invoice_date`, `customer_no`, `status`) VALUES (@invoice_no,@invoice_date,@customer_no,@status)"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.Add("@invoice_no", GL_INVOICE_NO)
            command.Parameters.Add("@invoice_date", GL_INVOICE_DATE)
            command.Parameters.Add("@customer_no", (New CorporateCustomer).getCustomerCode("", GL_CUSTOMER_NAME))
            command.Parameters.Add("@status", "NEW")
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.ToString)
        End Try
        Return success
    End Function
    Public Function addInvoiceDetails() As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "INSERT INTO `sales_invoice_details`( `invoice_no`, `item_code`, `description`, `price`, `qty`) VALUES (@invoice_no,@item_code,@description,@price,@qty)"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text

            command.Parameters.Add("@invoice_no", GL_INVOICE_NO)
            command.Parameters.Add("@item_code", GL_ITEM_CODE)
            command.Parameters.Add("@description", GL_DESCRIPTION)
            command.Parameters.Add("@price", GL_PRICE)
            command.Parameters.Add("@qty", GL_QTY)
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
    Public Function editInvoiceDetails(invoiceNo As String, itemCode As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `sales_invoice_details` SET `price`='" + GL_PRICE.ToString + "', `qty`='" + GL_QTY.ToString + "' WHERE `invoice_no`='" + invoiceNo + "' AND `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.ToString)
        End Try
        Return success
    End Function

    Public Function printPackingList(issueNo As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `packing_list` SET`status`='PRINTED' WHERE `issue_no`='" + issueNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
    Public Function completePackingList(issueNo As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `packing_list` SET`status`='COMPLETED' WHERE `issue_no`='" + issueNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
    Public Function cancelInvoice(invoiceNo As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `sales_invoices` SET`status`='CANCELED' WHERE `invoice_no`='" + invoiceNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
    Public Function archiveInvoice(invoiceNo As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `sales_invoices` SET`status`='ARCHIVED' WHERE `invoice_no`='" + invoiceNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
    Public Function deletePackingListDetails(invoiceNo As String, itemCode As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "DELETE FROM `sales_invoice_details` WHERE `invoice_no`='" + invoiceNo + "' AND `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
    Public Function isInvoiceExist(invoiceNo As String) As Boolean
        Dim exist As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `invoice_no` FROM `sales_invoices` WHERE `invoice_no`='" + invoiceNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                exist = True
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return exist
    End Function

    Public Function editInvoice(issueNo As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `sales_invoices` SET `customer_no`='" + (New CorporateCustomer).getCustomerCode("", GL_CUSTOMER_NAME) + "' WHERE `issue_no`='" + issueNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function

    Public Function deletePackingList(invoiceNo As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "DELETE FROM `sales_invoices` WHERE `invoice_no`='" + invoiceNo + "';DELETE FROM `sales_invoice_details` WHERE `invoice_no`='" + invoiceNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
End Class
