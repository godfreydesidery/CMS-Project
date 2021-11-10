Imports Devart.Data.MySql

Public Class CorporateCustomer
    Public GL_CUSTOMER_ID As String = ""
    Public GL_CUSTOMER_CODE As String = ""
    Public GL_CUSTOMER_NAME As String = ""
    Public GL_ADDRESS As String = ""
    Public GL_POSTAL_CODE As String = ""
    Public GL_PHYSICAL_ADDRESS As String = ""
    Public GL_CONTACT_NAME As String = ""
    Public GL_BANK_ACC_NAME As String = ""
    Public GL_BANK_ACC_ADDRESS As String = ""
    Public GL_BANK_POST_CODE As String = ""
    Public GL_BANK_NAME As String = ""
    Public GL_BANK_ACC_NO As String = ""
    Public GL_TELEPHONE As String = ""
    Public GL_MOBILE As String = ""
    Public GL_EMAIL As String = ""
    Public GL_FAX As String = ""
    Public GL_TIN As String = ""
    Public GL_VRN As String = ""
    Public GL_INVOICE_LIMIT As Double = 0
    Public GL_CREDIT_LIMIT As Double = 0
    Public GL_STATUS As String = ""
    Public GL_CREDIT_DAYS As Integer = 0
    Public GL_CREDIT_BALANCE As Double = 0

    Public Function getCustomerID(customerCode As String, customerName As String) As String
        Dim id As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim query As String = ""
            If customerCode <> "" Then
                query = "SELECT `customer_id` FROM `corporate_customers` WHERE `customer_code`='" + customerCode + "'"
            Else
                query = "SELECT `customer_id` FROM `corporate_customers` WHERE `customer_name`='" + customerName + "'"
            End If

            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                id = reader.GetString("customer_id")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            'added = False
            MsgBox(ex.Message)
        End Try
        Return id
    End Function
    Public Function getCustomerCode(customerID As String, customerName As String) As String
        Dim code As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim query As String = ""
            If customerID <> "" Then
                query = "SELECT `customer_code` FROM `corporate_customers` WHERE `customer_id`='" + customerID + "'"
            Else
                query = "SELECT `customer_code` FROM `corporate_customers` WHERE `customer_name`='" + customerName + "'"
            End If
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                code = reader.GetString("customer_code")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            'added = False
            MsgBox(ex.Message)
        End Try
        Return code
    End Function
    Public Function getCustomerName(CustomerID As String, customerCode As String) As String
        Dim customer As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim query As String = ""
            If CustomerID <> "" Then
                query = "SELECT `customer_name` FROM `corporate_customers` WHERE `customer_id`='" + CustomerID + "'"
            Else
                query = "SELECT `customer_name` FROM `corporate_customers` WHERE `customer_code`='" + customerCode + "'"
            End If
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                customer = reader.GetString("customer_name")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            'added = False
            MsgBox(ex.Message)
        End Try
        Return customer
    End Function

    Public Function search(customerCode As String) As Boolean
        Dim found As Boolean = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `customer_id`, `customer_code`, `customer_name`, `address`, `post_code`, `physical_address`, `contact_name`, `bank_acc_name`, `bank_acc_address`, `bank_post_code`, `bank_name`, `bank_acc_no`, `telephone`, `mob`, `email`, `fax`, `tin`, `vrn`, `invoice_limit`, `credit_limit`, `credit_balance`, `status`, `credit_days` FROM `corporate_customers` WHERE `customer_code`='" + customerCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                GL_CUSTOMER_ID = reader.GetString("customer_id")
                GL_CUSTOMER_CODE = reader.GetString("customer_code")
                GL_CUSTOMER_NAME = reader.GetString("customer_name")
                GL_ADDRESS = reader.GetString("address")
                GL_POSTAL_CODE = reader.GetString("post_code")
                GL_PHYSICAL_ADDRESS = reader.GetString("physical_address")
                GL_CONTACT_NAME = reader.GetString("contact_name")
                GL_BANK_ACC_NAME = reader.GetString("bank_acc_name")
                GL_BANK_ACC_ADDRESS = reader.GetString("bank_acc_address")
                GL_BANK_POST_CODE = reader.GetString("bank_post_code")
                GL_BANK_NAME = reader.GetString("bank_name")
                GL_BANK_ACC_NO = reader.GetString("bank_acc_no")
                GL_TELEPHONE = reader.GetString("telephone")
                GL_MOBILE = reader.GetString("mob")
                GL_EMAIL = reader.GetString("email")
                GL_FAX = reader.GetString("fax")
                GL_TIN = reader.GetString("tin")
                GL_VRN = reader.GetString("vrn")
                GL_INVOICE_LIMIT = reader.GetString("invoice_limit")
                GL_CREDIT_LIMIT = reader.GetString("credit_limit")
                GL_CREDIT_DAYS = reader.GetString("credit_days")
                GL_CREDIT_balance = reader.GetString("credit_balance")
                GL_STATUS = reader.GetString("status")
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
    Public Function addCustomer(customerCode As String, customerName As String, address As String, postCode As String, physicalAddress As String, contactName As String, bankAccName As String, bankAccAddress As String, bankPostCode As String, bankName As String, bankAccNo As String, telephone As String, mob As String, email As String, fax As String, tin As String, vrn As String, invoiceLimit As Double, creditLimit As Double, status As String, creditBalance As Double, creditDays As Double) As Boolean
        Dim added As Boolean = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'Dim reader As MySqlDataReader
            'create bar code
            Dim codeQuery As String = "INSERT INTO `corporate_customers`( `customer_code`, `customer_name`, `address`, `post_code`, `physical_address`, `contact_name`, `bank_acc_name`, `bank_acc_address`, `bank_post_code`, `bank_name`, `bank_acc_no`, `telephone`, `mob`, `email`, `fax`, `tin`, `vrn`, `invoice_limit`, `credit_limit`, `status`, `credit_balance`, `credit_days`) 
                                                                 VALUES (@customer_code,@customer_name,@address,@post_code,@physical_address,@contact_name,@bank_acc_name,@bank_acc_address,@bank_post_code,@bank_name,@bank_acc_no,@telephone,@mob,@email,@fax,@tin,@vrn,@invoice_limit,@credit_limit,@status,@credit_balance,@credit_days)"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@customer_code", customerCode)
            command.Parameters.AddWithValue("@customer_name", customerName)
            command.Parameters.AddWithValue("@address", address)
            command.Parameters.AddWithValue("@post_code", postCode)
            command.Parameters.AddWithValue("@physical_address", physicalAddress)
            command.Parameters.AddWithValue("@contact_name", contactName)
            command.Parameters.AddWithValue("@bank_acc_name", bankAccName)
            command.Parameters.AddWithValue("@bank_acc_address", bankAccAddress)
            command.Parameters.AddWithValue("@bank_post_code", bankPostCode)
            command.Parameters.AddWithValue("@bank_name", bankName)
            command.Parameters.AddWithValue("@bank_acc_no", bankAccNo)
            command.Parameters.AddWithValue("@telephone", telephone)
            command.Parameters.AddWithValue("@mob", mob)
            command.Parameters.AddWithValue("@email", email)
            command.Parameters.AddWithValue("@fax", fax)
            command.Parameters.AddWithValue("@tin", tin)
            command.Parameters.AddWithValue("@vrn", vrn)
            command.Parameters.AddWithValue("@invoice_limit", invoiceLimit.ToString())
            command.Parameters.AddWithValue("@credit_limit", creditLimit.ToString())
            command.Parameters.AddWithValue("@status", status)
            command.Parameters.AddWithValue("@credit_balance", creditBalance.ToString)
            command.Parameters.AddWithValue("@credit_days", creditDays.ToString)
            command.ExecuteNonQuery()
            conn.Close()
            added = True
        Catch ex As MySqlException
            added = False
            MsgBox(ex.ToString)
            MsgBox("Operation failed. The supplier code entered already exist. Please enter a unique supplier code.", vbOKOnly + vbCritical, "Error: Duplicate entry")
        Catch ex As Exception
            added = False
            MsgBox(ex.ToString)
        End Try

        Return added
    End Function
    Public Function editCustomer(customerCode As String, customerName As String, address As String, postCode As String, physicalAddress As String, contactName As String, bankAccName As String, bankAccAddress As String, bankPostCode As String, bankName As String, bankAccNo As String, telephone As String, mob As String, email As String, fax As String, tin As String, vrn As String, invoiceLimit As Double, creditLimit As Double, status As String, creditBalance As Double, creditDays As Double) As Boolean
        Dim edited As Boolean = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'Dim reader As MySqlDataReader
            'create bar code
            Dim codeQuery As String = "UPDATE `corporate_customers` SET `customer_name`='" + customerName + "',`address`='" + address + "',`post_code`='" + postCode + "',`physical_address`='" + physicalAddress + "',`contact_name`='" + contactName + "',`bank_acc_name`='" + bankAccName + "',`bank_acc_address`='" + bankAccAddress + "',`bank_post_code`='" + bankPostCode + "',`bank_name`='" + bankName + "',`bank_acc_no`='" + bankAccNo + "',`telephone`='" + telephone + "',`mob`='" + mob + "',`email`='" + email + "',`fax`='" + fax + "',`tin`='" + tin + "',`vrn`='" + vrn + "',`invoice_limit`='" + invoiceLimit.ToString + "',`credit_limit`='" + creditLimit.ToString + "',`status`='" + status + "', `credit_balance`='" + creditBalance.ToString + "', `credit_days`='" + creditDays.ToString + "' WHERE `customer_code`='" + customerCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            edited = True
        Catch ex As Exception
            edited = False
            MsgBox(ex.ToString)
        End Try

        Return edited
    End Function
    Public Function deleteCustomer(customerID As String) As Boolean
        Dim deleted As Boolean = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "DELETE FROM `corporate_customers` WHERE `customer_id`='" + customerID + "'"
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
    Public Function getCustomers(name As String) As List(Of String)
        Dim list As New List(Of String)
        Try
            Dim query As String = "SELECT  `customer_name` FROM `corporate_customers`" ' LIMIT 1,200"
            Dim command As New MySqlCommand()
            Dim conn As New MySqlConnection(Database.conString)
            Try
                list.Clear()
                conn.Open()
                command.CommandText = query
                command.Connection = conn
                command.CommandType = CommandType.Text
                Dim itemreader As MySqlDataReader = command.ExecuteReader()
                If itemreader.HasRows = True Then
                    While itemreader.Read
                        list.Add(itemreader("customer_name").ToString)
                    End While
                Else
                    Return list
                    Exit Function
                End If
            Catch ex As Devart.Data.MySql.MySqlException
                MsgBox(ex.Message)
                Return list
                Exit Function
            End Try

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

        Return list
    End Function
End Class