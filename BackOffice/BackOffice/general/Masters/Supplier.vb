Imports Devart.Data.MySql

Public Class Supplier
    Public GL_SUPPLIER_ID As String = ""
    Public GL_SUPPLIER_CODE As String = ""
    Public GL_SUPPLIER_NAME As String = ""
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
    Public Function getSupplierID(supplierCode As String, supplierName As String) As String
        Dim id As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim query As String = ""
            If supplierCode <> "" Then
                query = "SELECT `supplier_id` FROM `supplier` WHERE `supplier_code`='" + supplierCode + "'"
            Else
                query = "SELECT `supplier_id` FROM `supplier` WHERE `supplier_name`='" + supplierName + "'"
            End If

            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                id = reader.GetString("supplier_id")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            'added = False
            MsgBox(ex.Message)
        End Try
        Return id
    End Function
    Public Function getSupplierCode(supplierID As String, supplierName As String) As String
        Dim code As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim query As String = ""
            If supplierID <> "" Then
                query = "SELECT `supplier_code` FROM `supplier` WHERE `supplier_id`='" + supplierID + "'"
            Else
                query = "SELECT `supplier_code` FROM `supplier` WHERE `supplier_name`='" + supplierName + "'"
            End If
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                code = reader.GetString("supplier_code")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            'added = False
            MsgBox(ex.Message)
        End Try
        Return code
    End Function
    Public Function getSupplierName(supplierID As String, supplierCode As String) As String
        Dim supplier As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim query As String = ""
            If supplierID <> "" Then
                query = "SELECT `supplier_name` FROM `supplier` WHERE `supplier_id`='" + supplierID + "'"
            Else
                query = "SELECT `supplier_name` FROM `supplier` WHERE `supplier_code`='" + supplierCode + "'"
            End If
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                supplier = reader.GetString("supplier_name")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            'added = False
            MsgBox(ex.Message)
        End Try
        Return supplier
    End Function

    Public Function search(supplierCode As String) As Boolean
        Dim found As Boolean = False
        
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `supplier_id`, `supplier_code`, `supplier_name`, `address`, `post_code`, `physical_address`, `contact_name`, `bank_acc_name`, `bank_acc_address`, `bank_post_code`, `bank_name`, `bank_acc_no`, `telephone`, `mob`, `email`, `fax`, `tin`, `vrn` FROM `supplier` WHERE `supplier_code`='" + supplierCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                GL_SUPPLIER_ID = reader.GetString("supplier_id")
                GL_SUPPLIER_CODE = reader.GetString("supplier_code")
                GL_SUPPLIER_NAME = reader.GetString("supplier_name")
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
    Public Function addSupplier(supplierCode As String, supplierName As String, address As String, postCode As String, physicalAddress As String, contactName As String, bankAccName As String, bankAccAddress As String, bankPostCode As String, bankName As String, bankAccNo As String, telephone As String, mob As String, email As String, fax As String, tin As String, vrn As String) As Boolean
        Dim added As Boolean = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'Dim reader As MySqlDataReader
            'create bar code
            Dim codeQuery As String = "INSERT INTO `supplier`( `supplier_code`, `supplier_name`, `address`, `post_code`, `physical_address`, `contact_name`, `bank_acc_name`, `bank_acc_address`, `bank_post_code`,`bank_name`, `bank_acc_no`, `telephone`, `mob`, `email`, `fax`, `tin`, `vrn`) VALUES (@supplier_code,@supplier_name,@address,@post_code,@physical_address,@contact_name,@bank_acc_name,@bank_acc_address,@bank_post_code,@bank_name,@bank_acc_no,@telephone,@mob,@email,@fax,@tin,@vrn)"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@supplier_code", supplierCode)
            command.Parameters.AddWithValue("@supplier_name", supplierName)
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
            command.ExecuteNonQuery()
            conn.Close()
            added = True
        Catch ex As MySqlException
            added = False
            MsgBox("Operation failed. The supplier code entered already exist. Please enter a unique supplier code.", vbOKOnly + vbCritical, "Error: Duplicate entry")
        Catch ex As Exception
            added = False
            MsgBox(ex.Message + ex.GetType.ToString)
        End Try

        Return added
    End Function
    Public Function editSupplier(supplierID As String, supplierCode As String, supplierName As String, address As String, postCode As String, physicalAddress As String, contactName As String, bankAccName As String, bankAccAddress As String, bankPostCode As String, bankName As String, bankAccNo As String, telephone As String, mob As String, email As String, fax As String, tin As String, vrn As String) As Boolean
        Dim edited As Boolean = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'Dim reader As MySqlDataReader
            'create bar code
            Dim codeQuery As String = "UPDATE `supplier` SET `supplier_code`='" + supplierCode + "',`supplier_name`='" + supplierName + "',`address`='" + address + "',`post_code`='" + postCode + "',`physical_address`='" + physicalAddress + "',`contact_name`='" + contactName + "',`bank_acc_name`='" + bankAccName + "',`bank_acc_address`='" + bankAccAddress + "',`bank_post_code`='" + bankPostCode + "',`bank_name`='" + bankName + "',`bank_acc_no`='" + bankAccNo + "',`telephone`='" + telephone + "',`mob`='" + mob + "',`email`='" + email + "',`fax`='" + fax + "',`tin`='" + tin + "',`vrn`='" + vrn + "' WHERE `supplier_id`='" + supplierID + "'"
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
    Public Function deleteSupplier(supplierID As String) As Boolean
        Dim deleted As Boolean = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "DELETE FROM `supplier` WHERE `supplier_id`='" + supplierID + "'"
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
    Public Function getSuppliers(name As String) As List(Of String)
        Dim list As New List(Of String)
        Try
            Dim query As String = "SELECT  `supplier_name` FROM `supplier`" ' LIMIT 1,200"
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
                        list.Add(itemreader("supplier_name").ToString)
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
