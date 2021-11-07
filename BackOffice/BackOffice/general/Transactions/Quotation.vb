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


    Public Function getQuotationId(quotationNo As String) As String
        Dim id As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `quotation_id` FROM `quotations` WHERE `quotation_no`='" + quotationNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                id = reader.GetString("quotation_id")
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
            Dim codeQuery As String = "SELECT `quotations`.`quotation_id` AS `id`, `quotations`.`quotation_no` AS `quotation_no`, `quotations`.`customer_no` AS `customer_no`, `quotations`.`quotation_date` AS `quotation_date`, `quotations`.`status` AS `status` FROM `quotations` WHERE `quotations`.`quotation_no`='" + quotationNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                Me.GL_ID = reader.GetString("id")
                Me.GL_QUOTATION_NO = reader.GetString("quotation_no")
                Me.GL_QUOTATION_DATE = reader.GetString("quotation_date")
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
    Public Function getStatus(quotationNo As String) As String
        Dim status As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `status` FROM `quotations` WHERE `quotation_no`='" + quotationNo + "'"
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


    Public Function addNewQuotation() As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "INSERT INTO `quotations`(  `quotation_no`, `quotation_date`, `customer_no`, `status`) VALUES (@quotation_no,@quotation_date,@customer_no,@status)"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.Add("@quotation_no", GL_QUOTATION_NO)
            command.Parameters.Add("@quotation_date", GL_QUOTATION_DATE)
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
    Public Function addQuotationDetails() As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "INSERT INTO `quotation_details`( `quotation_no`, `item_code`, `description`, `price`, `qty`) VALUES (@quotation_no,@item_code,@description,@price,@qty)"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text

            command.Parameters.Add("@quotation_no", GL_QUOTATION_NO)
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
    Public Function editQuotationDetails(quotationNo As String, itemCode As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `quotation_details` SET `price`='" + GL_PRICE.ToString + "', `qty`='" + GL_QTY.ToString + "' WHERE `quotation_no`='" + quotationNo + "' AND `item_code`='" + itemCode + "'"
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

    Public Function cancelQuotation(quotationNo As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `quotations` SET`status`='CANCELED' WHERE `quotation_no`='" + quotationNo + "'"
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
    Public Function archiveQuotation(quotationNo As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `quotations` SET`status`='ARCHIVED' WHERE `quotation_no`='" + quotationNo + "'"
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
    Public Function deleteQuotationDetails(quotationNo As String, itemCode As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "DELETE FROM `quotation_details` WHERE `quotation_no`='" + quotationNo + "' AND `item_code`='" + itemCode + "'"
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
    Public Function isQuotationExist(quotationNo As String) As Boolean
        Dim exist As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `quotation_no` FROM `quotations` WHERE `quotation_no`='" + quotationNo + "'"
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

    Public Function editQuotation(quotationNo As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `quotations` SET `customer_no`='" + (New CorporateCustomer).getCustomerCode("", GL_CUSTOMER_NAME) + "' WHERE `quotation_no`='" + quotationNo + "'"
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

    Public Function deletePackingList(quotationNo As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "DELETE FROM `quotations` WHERE `quotation_no`='" + quotationNo + "';DELETE FROM `quotation_details` WHERE `quotation_no`='" + quotationNo + "'"
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
