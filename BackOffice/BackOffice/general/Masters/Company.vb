Imports System.Xml
Imports Devart.Data.MySql

Public Class Company
    Public Shared NAME As String = ""
    Public Shared CONTACT_NAME As String = ""
    Public Shared TIN As String = ""
    Public Shared VRN As String = ""
    Public Shared BANK_ACC_NAME As String = ""
    Public Shared BANK_ACC_ADDRESS As String = ""
    Public Shared BANK_POST_CODE As String = ""
    Public Shared BANK_NAME As String = ""
    Public Shared BANK_ACC_NO As String = ""
    Public Shared ADDRESS As String = ""
    Public Shared POST_CODE As String = ""
    Public Shared PHYSICAL_ADDRESS As String = ""
    Public Shared TELEPHONE As String = ""
    Public Shared MOBILE As String = ""
    Public Shared EMAIL As String = ""
    Public Shared FAX As String = ""
    Public Shared Function saveCompanyDetails()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "DELETE FROM `company`"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()

            query = "INSERT INTO `company`( `company_name`, `contact_name`, `tin`, `vrn`, `bank_acc_name`, `bank_acc_address`, `bank_post_code`, `bank_name`, `bank_acc_no`, `address`, `post_code`, `physical_address`, `telephone`, `mobile`, `email`, `fax`) VALUES (@company_name, @contact_name, @tin, @vrn, @bank_acc_name, @bank_acc_address, @bank_post_code, @bank_name, @bank_acc_no, @address, @post_code, @physical_address, @telephone, @mobile, @email, @fax)"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@company_name", NAME)
            command.Parameters.AddWithValue("@contact_name", CONTACT_NAME)
            command.Parameters.AddWithValue("@tin", TIN)
            command.Parameters.AddWithValue("@vrn", VRN)
            command.Parameters.AddWithValue("@bank_acc_name", BANK_ACC_NAME)
            command.Parameters.AddWithValue("@bank_acc_address", BANK_ACC_ADDRESS)
            command.Parameters.AddWithValue("@bank_post_code", BANK_POST_CODE)
            command.Parameters.AddWithValue("@bank_name", BANK_NAME)
            command.Parameters.AddWithValue("@bank_acc_no", BANK_ACC_NO)
            command.Parameters.AddWithValue("@address", ADDRESS)
            command.Parameters.AddWithValue("@post_code", POST_CODE)
            command.Parameters.AddWithValue("@physical_address", PHYSICAL_ADDRESS)
            command.Parameters.AddWithValue("@telephone", TELEPHONE)
            command.Parameters.AddWithValue("@mobile", MOBILE)
            command.Parameters.AddWithValue("@email", EMAIL)
            command.Parameters.AddWithValue("@fax", FAX)
            command.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return vbNull
    End Function
    Public Shared Function loadCompanyDetails() As Boolean
        Dim loaded As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `company_name`, `contact_name`, `tin`, `vrn`, `bank_acc_name`, `bank_acc_address`, `bank_post_code`, `bank_name`, `bank_acc_no`, `address`, `post_code`, `physical_address`, `telephone`, `mobile`, `email`, `fax` FROM `company`"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                NAME = reader.GetString("company_name")
                CONTACT_NAME = reader.GetString("contact_name")
                TIN = reader.GetString("tin")
                VRN = reader.GetString("vrn")
                BANK_ACC_NAME = reader.GetString("bank_acc_name")
                BANK_ACC_ADDRESS = reader.GetString("bank_acc_address")
                BANK_POST_CODE = reader.GetString("bank_post_code")
                BANK_NAME = reader.GetString("bank_name")
                BANK_ACC_NO = reader.GetString("bank_acc_no")
                ADDRESS = reader.GetString("address")
                POST_CODE = reader.GetString("post_code")
                PHYSICAL_ADDRESS = reader.GetString("physical_address")
                TELEPHONE = reader.GetString("telephone")
                MOBILE = reader.GetString("mobile")
                EMAIL = reader.GetString("email")
                FAX = reader.GetString("fax")
                loaded = True
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return loaded
    End Function

End Class
