Imports System.IO
Imports System.Xml
Imports Devart.Data.MySql

Public Class frmCompany

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub
    Private Function validateDetails() As Boolean
        Dim valid As Boolean = True
        If txtName.Text = "" Then
            valid = False
        End If
        If txtContactName.Text = "" Then
            valid = False
        End If
        If txtTIN.Text = "" Then
            valid = False
        End If
        If txtVRN.Text = "" Then
            valid = False
        End If
        Return valid
    End Function
    Private Function lock()
        txtName.ReadOnly = True
        txtContactName.ReadOnly = True
        txtTIN.ReadOnly = True
        txtVRN.ReadOnly = True
        txtBankAccName.ReadOnly = True
        txtBankAccAddress.ReadOnly = True
        txtBankPostCode.ReadOnly = True
        txtBankName.ReadOnly = True
        txtBankAccNo.ReadOnly = True
        txtAddress.ReadOnly = True
        txtPostCode.ReadOnly = True
        txtPhysicalAddress.ReadOnly = True
        txtTelephone.ReadOnly = True
        txtMobile.ReadOnly = True
        txtEmail.ReadOnly = True
        txtFax.ReadOnly = True
        Return vbNull
    End Function
    Private Function unlock()
        txtName.ReadOnly = False
        txtContactName.ReadOnly = False
        txtTIN.ReadOnly = False
        txtVRN.ReadOnly = False
        txtBankAccName.ReadOnly = False
        txtBankAccAddress.ReadOnly = False
        txtBankPostCode.ReadOnly = False
        txtBankName.ReadOnly = False
        txtBankAccNo.ReadOnly = False
        txtAddress.ReadOnly = False
        txtPostCode.ReadOnly = False
        txtPhysicalAddress.ReadOnly = False
        txtTelephone.ReadOnly = False
        txtMobile.ReadOnly = False
        txtEmail.ReadOnly = False
        txtFax.ReadOnly = False
        Return vbNull
    End Function
    Private Function getDepartments()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT   `department_id`,`department_name` FROM `department`"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim deptName As String = ""
            Dim deptId As String = ""
            dtgrdDepartment.Rows.Clear()
            While reader.Read
                deptName = reader.GetString("department_name")
                deptId = reader.GetString("department_id")
                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = deptName
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = deptId
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdDepartment.Rows.Add(dtgrdRow)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return vbNull
    End Function
    Private Function getClasses(deptId As String)
        dtgrdClass.Rows.Clear()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim Query As String = ""
            If deptId = "" Then
                Query = "SELECT  `class_id`,`class_name`, `department_id` FROM `class` "
            Else
                Query = "SELECT  `class_id`,`class_name`, `department_id` FROM `class` WHERE `department_id`='" + deptId + "'"
            End If
            conn.Open()
            command.CommandText = Query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()

            Dim className As String = ""
            Dim deptName As String = ""
            Dim classID As String = ""
            dtgrdClass.Rows.Clear()
            While reader.Read
                classID = reader.GetString("class_id")
                className = reader.GetString("class_name")
                deptName = (New Department).getDepartmentName(reader.GetString("department_id"))

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = className
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = deptName
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = classID
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdClass.Rows.Add(dtgrdRow)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return vbNull
    End Function
    Private Function getSubClasses(classId)
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim query As String = ""
            If classId = "" Then
                query = "SELECT  `sub_class_id`,`sub_class_name`, `class_id` FROM `sub_class` "
            Else
                query = "SELECT  `sub_class_id`,`sub_class_name`, `class_id` FROM `sub_class` WHERE `class_id`='" + classId + "'"
            End If
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim subClassId As String = ""
            Dim subClassName As String = ""
            Dim className As String = ""
            dtgrdsubClass.Rows.Clear()
            While reader.Read
                subClassId = reader.GetString("sub_class_id")
                subClassName = reader.GetString("sub_class_name")
                className = (New Class_).getClassName(reader.GetString("class_id"))

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = subClassName
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = className
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = subClassId
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdsubClass.Rows.Add(dtgrdRow)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return vbNull
    End Function
    Private Sub frmCompany_Load(sender As Object, e As EventArgs) Handles Me.Shown
        loadCompanyDetails()
        txtDepartmentName.Text = ""

    End Sub
    Private Function refreshAll()
        getDepartments()
        getClasses("")
        getSubClasses("")
        loadUnits()

        dtgrdDepartment.ClearSelection()
        dtgrdClass.ClearSelection()
        dtgrdsubClass.ClearSelection()
        Return vbNull
    End Function
    Private Function loadUnits()
        cmbClassDepartment.Items.Clear()
        cmbSubClassDepartment.Items.Clear()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT   `department_name` FROM `department`"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim deptName As String = ""
            While reader.Read
                cmbClassDepartment.Items.Add(reader.GetString("department_name"))
                cmbSubClassDepartment.Items.Add(reader.GetString("department_name"))
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return vbNull
    End Function
    Private Sub frmCompany_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        refreshAll()
        btnEditDepartment.Enabled = False
        btnDeleteDepartment.Enabled = False
    End Sub

    Private Sub btnAddDepartment_Click(sender As Object, e As EventArgs) Handles btnAddDepartment.Click
        dtgrdDepartment.ClearSelection()
        txtDepartmentName.Text = ""
        btnEditDepartment.Enabled = False
        btnDeleteDepartment.Enabled = False
        btnSaveDepartment.Enabled = True
        txtDepartmentName.ReadOnly = False
        DEPT_EDIT_MODE = "NEW"

    End Sub

    Private Sub btnDeleteDepartment_Click(sender As Object, e As EventArgs) Handles btnDeleteDepartment.Click
        Dim res As Integer = MsgBox("Are you sure you want to delete the selected Department?", vbYesNo + vbQuestion, "Delete Department")
        If res = DialogResult.Yes Then
            'continue with operation
        Else
            Exit Sub
        End If
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "DELETE FROM `department` WHERE `department_name`='" + txtDepartmentName.Text + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
        refreshAll()
        txtDepartmentName.Text = ""
        btnEditDepartment.Enabled = False
        btnSaveDepartment.Enabled = False
        btnDeleteDepartment.Enabled = False
    End Sub

    Private Sub btnSaveDepartment_Click(sender As Object, e As EventArgs) Handles btnSaveDepartment.Click
        If txtDepartmentName.Text = "" Then
            MsgBox("Department name can not be empty.", vbOKOnly + vbCritical, "Eroor: No entry")
            Exit Sub
        End If
        If DEPT_EDIT_MODE = "NEW" Then
            DEPT_ID = ""
            Try
                Dim conn As New MySqlConnection(Database.conString)
                Dim command As New MySqlCommand()
                'create bar code
                Dim codeQuery As String = "INSERT INTO `department`(`department_name`) VALUES (@department_name)"
                conn.Open()
                command.CommandText = codeQuery
                command.Connection = conn
                command.CommandType = CommandType.Text
                command.Parameters.AddWithValue("@department_name", txtDepartmentName.Text)
                command.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception
                MsgBox("Operation failed. Duplicate entry or invalid input", vbOKOnly + vbCritical, "Error: Operation failed")
                Exit Sub
            End Try
        ElseIf DEPT_EDIT_MODE = "" Then
            Try
                Dim conn As New MySqlConnection(Database.conString)
                Dim command As New MySqlCommand()
                'create bar code
                Dim codeQuery As String = "UPDATE `department` SET `department_name`='" + txtDepartmentName.Text + "' WHERE `department_id`='" + DEPT_ID + "'"
                conn.Open()
                command.CommandText = codeQuery
                command.Connection = conn
                command.CommandType = CommandType.Text
                command.Parameters.AddWithValue("@department_name", txtDepartmentName.Text)
                command.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception
                MsgBox("Operation failed. Duplicate entry or invalid input", vbOKOnly + vbCritical, "Error: Operation failed")
                Exit Sub
            End Try
        End If
        btnSaveDepartment.Enabled = False
        btnEditDepartment.Enabled = False
        btnDeleteDepartment.Enabled = False
        refreshAll()

        txtDepartmentName.Text = ""
        txtDepartmentName.ReadOnly = True
    End Sub

    Private Sub dtgrdDepartment_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdDepartment.CellContentClick

    End Sub

    Private Sub dtgrdDepartment_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdDepartment.RowHeaderMouseClick

    End Sub

    Private Sub btnEditDepartment_Click(sender As Object, e As EventArgs) Handles btnEditDepartment.Click
        txtDepartmentName.ReadOnly = False
        btnSaveDepartment.Enabled = True
        DEPT_EDIT_MODE = ""
    End Sub
    Dim DEPT_EDIT_MODE = ""
    Dim DEPT_ID As String = ""
    Private Sub dtgrdDepartment_cellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdDepartment.CellClick
        btnEditDepartment.Enabled = True
        btnDeleteDepartment.Enabled = True
        btnSaveDepartment.Enabled = False
        txtDepartmentName.ReadOnly = True
        Try
            If dtgrdDepartment.CurrentRow.Index >= 0 Then
                txtDepartmentName.Text = dtgrdDepartment.Item(0, e.RowIndex).Value.ToString
                DEPT_ID = dtgrdDepartment.Item(1, e.RowIndex).Value.ToString
            End If
        Catch ex As Exception

        End Try


    End Sub
    Dim CLASS_EDIT_MODE = ""
    Dim CLASS_ID As String = ""
    Private Sub dtgrdclass_cellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdClass.CellClick
        btnEditClass.Enabled = True
        btnDeleteClass.Enabled = True
        btnSaveClass.Enabled = False
        txtClassName.ReadOnly = True
        Try
            If dtgrdClass.CurrentRow.Index >= 0 Then
                txtClassName.Text = dtgrdClass.Item(0, e.RowIndex).Value.ToString
                CLASS_ID = dtgrdClass.Item(2, e.RowIndex).Value.ToString
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub dtgrdSubClass_cellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdsubClass.CellClick
        btnEditSubClass.Enabled = True
        btnDeleteSubClass.Enabled = True
        btnSaveSubClass.Enabled = False
        txtSubClassName.ReadOnly = True
        Try
            If dtgrdsubClass.CurrentRow.Index >= 0 Then
                txtSubClassName.Text = dtgrdsubClass.Item(0, e.RowIndex).Value.ToString
                SUB_CLASS_ID = dtgrdsubClass.Item(2, e.RowIndex).Value.ToString
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmCompany_Load_1(sender As Object, e As EventArgs) Handles Me.Shown
        Dim company As New Company
        company.loadCompanyDetails()
    End Sub

    Private Sub cmbClassDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClassDepartment.SelectedIndexChanged
        Dim deptId As String = (New Department).getDepartmentID(cmbClassDepartment.Text)
        btnSaveClass.Enabled = False
        btnDeleteClass.Enabled = False
        txtClassName.Text = ""
        txtClassName.ReadOnly = True
        getClasses(deptId)
    End Sub

    Private Sub btnAddClass_Click(sender As Object, e As EventArgs) Handles btnAddClass.Click
        If cmbClassDepartment.Text = "" Then
            MsgBox("Select Department", vbOKOnly + vbCritical, "Error: Empty field")
            Exit Sub
        End If
        CLASS_EDIT_MODE = "NEW"
        txtClassName.Text = ""
        txtClassName.ReadOnly = False
        btnEditClass.Enabled = False
        btnDeleteClass.Enabled = False
        btnSaveClass.Enabled = True

    End Sub

    Private Sub btnEditClass_Click(sender As Object, e As EventArgs) Handles btnEditClass.Click
        CLASS_EDIT_MODE = ""
        txtClassName.ReadOnly = False
        btnSaveClass.Enabled = True
        btnDeleteClass.Enabled = False

    End Sub

    Private Sub dtgrdClass_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdClass.CellContentClick

    End Sub

    Private Sub btnSaveClass_Click(sender As Object, e As EventArgs) Handles btnSaveClass.Click
        If txtClassName.Text = "" Then
            MsgBox("Class name can not be empty.", vbOKOnly + vbCritical, "Error: No entry")
            Exit Sub
        End If
        If CLASS_EDIT_MODE = "NEW" Then
            CLASS_ID = ""
            Try
                Dim conn As New MySqlConnection(Database.conString)
                Dim command As New MySqlCommand()
                'create bar code
                Dim codeQuery As String = "INSERT INTO `class`(`class_name`,`department_id`) VALUES (@class_name,@department_id)"
                conn.Open()
                command.CommandText = codeQuery
                command.Connection = conn
                command.CommandType = CommandType.Text
                command.Parameters.AddWithValue("@class_name", txtClassName.Text)
                command.Parameters.AddWithValue("@department_id", (New Department).getDepartmentID(cmbClassDepartment.Text))
                command.ExecuteNonQuery()
                conn.Close()


            Catch ex As Exception
                MsgBox("Operation failed. Duplicate entry or invalid input", vbOKOnly + vbCritical, "Error: Operation failed")
                Exit Sub
            End Try
        ElseIf CLASS_EDIT_MODE = "" Then
            Try
                Dim conn As New MySqlConnection(Database.conString)
                Dim command As New MySqlCommand()
                'create bar code
                Dim codeQuery As String = "UPDATE `class` SET `class_name`='" + txtClassName.Text + "' WHERE `class_id`='" + CLASS_ID + "' AND `department_id`='" + (New Department).getDepartmentID(cmbClassDepartment.Text) + "'"
                conn.Open()
                command.CommandText = codeQuery
                command.Connection = conn
                command.CommandType = CommandType.Text
                command.Parameters.AddWithValue("@class_name", txtClassName.Text)
                command.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception
                MsgBox("Operation failed. Duplicate entry or invalid input", vbOKOnly + vbCritical, "Error: Operation failed")
                Exit Sub
            End Try
        End If
        btnSaveClass.Enabled = False
        btnEditClass.Enabled = False
        btnDeleteClass.Enabled = False

        dtgrdClass.Rows.Clear()
        getClasses((New Department).getDepartmentID(cmbClassDepartment.Text))
        dtgrdClass.ClearSelection()

        txtClassName.Text = ""
        txtClassName.ReadOnly = True
    End Sub

    Private Sub cmbSubClassDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubClassDepartment.SelectedIndexChanged
        btnSaveSubClass.Enabled = False
        btnDeleteSubClass.Enabled = False
        txtSubClassName.Text = ""
        txtSubClassName.ReadOnly = True

        Dim conn As New MySqlConnection(Database.conString)
        dtgrdsubClass.Rows.Clear()
        cmbSubClassClass.Items.Clear()
        Try
            Dim command As New MySqlCommand()
            Dim Query As String = "SELECT `class_id`, `class_name` FROM `class` WHERE `department_id`='" + (New Department).getDepartmentID(cmbSubClassDepartment.Text) + "'"
            conn.Open()
            command.CommandText = Query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader
            If reader.HasRows Then
                While reader.Read
                    cmbSubClassClass.Items.Add(reader.GetString("class_name"))
                End While
            End If
            conn.Close()
        Catch ex As Devart.Data.MySql.MySqlException
            ErrorMessage.dbConnectionError()
            Exit Sub
        End Try

    End Sub

    Private Sub cmbSubClassClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubClassClass.SelectedIndexChanged

        Dim classId As String = (New Class_).getClassID(cmbSubClassClass.Text)
        btnSaveSubClass.Enabled = False
        btnDeleteSubClass.Enabled = False
        txtSubClassName.Text = ""
        txtSubClassName.ReadOnly = True
        getSubClasses(classId)

    End Sub
    Dim SUB_CLASS_EDIT_MODE As String = ""
    Dim SUB_CLASS_ID As String = ""
    Private Sub btnAddSubClass_Click(sender As Object, e As EventArgs) Handles btnAddSubClass.Click
        If cmbSubClassDepartment.Text = "" Then
            MsgBox("Select Department", vbOKOnly + vbCritical, "Error: Empty field")
            Exit Sub
        End If
        If cmbSubClassClass.Text = "" Then
            MsgBox("Select Class", vbOKOnly + vbCritical, "Error: Empty field")
            Exit Sub
        End If
        SUB_CLASS_EDIT_MODE = "NEW"
        txtSubClassName.Text = ""
        txtSubClassName.ReadOnly = False
        btnEditSubClass.Enabled = False
        btnDeleteSubClass.Enabled = False
        btnSaveSubClass.Enabled = True
    End Sub

    Private Sub btnEditSubClass_Click(sender As Object, e As EventArgs) Handles btnEditSubClass.Click
        SUB_CLASS_EDIT_MODE = ""
        txtSubClassName.ReadOnly = False
        btnSaveSubClass.Enabled = True
        btnDeleteSubClass.Enabled = False
    End Sub

    Private Sub btnDeleteClass_Click(sender As Object, e As EventArgs) Handles btnDeleteClass.Click
        Dim res As Integer = MsgBox("Are you sure you want to delete the selected Class?", vbYesNo + vbQuestion, "Delete Class")
        If res = DialogResult.Yes Then
            'continue with operation
        Else
            Exit Sub
        End If
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "DELETE FROM `class` WHERE `class_name`='" + txtClassName.Text + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
        refreshAll()
        txtClassName.Text = ""
        btnEditClass.Enabled = False
        btnSaveClass.Enabled = False
        btnDeleteClass.Enabled = False
    End Sub

    Private Sub btnDeleteSubClass_Click(sender As Object, e As EventArgs) Handles btnDeleteSubClass.Click
        Dim res As Integer = MsgBox("Are you sure you want to delete the selected Sub-Class?", vbYesNo + vbQuestion, "Delete Sub class")
        If res = DialogResult.Yes Then
            'continue with operation
        Else
            Exit Sub
        End If
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "DELETE FROM `sub_class` WHERE `sub_class_name`='" + txtSubClassName.Text + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
        refreshAll()
        txtSubClassName.Text = ""
        btnEditSubClass.Enabled = False
        btnSaveSubClass.Enabled = False
        btnDeleteSubClass.Enabled = False
    End Sub

    Private Sub btnSaveSubClass_Click(sender As Object, e As EventArgs) Handles btnSaveSubClass.Click
        If txtSubClassName.Text = "" Then
            MsgBox("Sub-Class name can not be empty.", vbOKOnly + vbCritical, "Error: No entry")
            Exit Sub
        End If
        If SUB_CLASS_EDIT_MODE = "NEW" Then
            SUB_CLASS_ID = ""
            Try
                Dim conn As New MySqlConnection(Database.conString)
                Dim command As New MySqlCommand()
                'create bar code
                Dim codeQuery As String = "INSERT INTO `sub_class`(`sub_class_name`,`class_id`) VALUES (@sub_class_name,@class_id)"
                conn.Open()
                command.CommandText = codeQuery
                command.Connection = conn
                command.CommandType = CommandType.Text
                command.Parameters.AddWithValue("@sub_class_name", txtSubClassName.Text)
                command.Parameters.AddWithValue("@class_id", (New Class_).getClassID(cmbSubClassClass.Text))
                command.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception
                MsgBox("Operation failed. Duplicate entry or invalid input", vbOKOnly + vbCritical, "Error")
                Exit Sub
            End Try
        ElseIf SUB_CLASS_EDIT_MODE = "" Then
            Try
                Dim conn As New MySqlConnection(Database.conString)
                Dim command As New MySqlCommand()
                'create bar code
                Dim codeQuery As String = "UPDATE `sub_class` SET `sub_class_name`='" + txtSubClassName.Text + "' WHERE `sub_class_id`='" + SUB_CLASS_ID + "' AND `class_id`='" + (New Class_).getClassID(cmbSubClassClass.Text) + "'"
                conn.Open()
                command.CommandText = codeQuery
                command.Connection = conn
                command.CommandType = CommandType.Text
                command.Parameters.AddWithValue("@sub_class_name", txtSubClassName.Text)
                command.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception
                MsgBox("Operation failed. Duplicate entry or invalid input", vbOKOnly + vbCritical, "Error: Operation failed")
                Exit Sub
            End Try
        End If
        btnSaveSubClass.Enabled = False
        btnEditSubClass.Enabled = False
        btnDeleteSubClass.Enabled = False

        dtgrdsubClass.Rows.Clear()
        getSubClasses((New Class_).getClassID(cmbSubClassClass.Text))
        dtgrdsubClass.ClearSelection()

        txtSubClassName.Text = ""
        txtSubClassName.ReadOnly = True
    End Sub

    Private Sub dtgrdsubClass_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdsubClass.CellContentClick

    End Sub
    Dim locked As Boolean = True
    Private Function validateCompanyDetails() As Boolean
        Dim valid As Boolean = False
        'validate company details
        'flush error for invalid details

        Return valid
    End Function
    Private Function loadCompanyDetails() As Boolean
        Dim loaded As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT`company_name`, `contact_name`, `tin`, `vrn`, `bank_acc_name`, `bank_acc_address`, `bank_post_code`, `bank_name`, `bank_acc_no`, `address`, `post_code`, `physical_address`, `telephone`, `mobile`, `email`, `fax`, `logo`, LENGTH(`logo`)AS `logo_length` FROM `company`"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim deptName As String = ""
            While reader.Read
                txtName.Text = reader.GetString("company_name")
                txtContactName.Text = reader.GetString("contact_name")
                txtTIN.Text = reader.GetString("tin")
                txtVRN.Text = reader.GetString("vrn")
                txtBankAccName.Text = reader.GetString("bank_acc_name")
                txtBankAccAddress.Text = reader.GetString("bank_acc_address")
                txtBankPostCode.Text = reader.GetString("bank_post_code")
                txtBankName.Text = reader.GetString("bank_name")
                txtBankAccNo.Text = reader.GetString("bank_acc_no")
                txtAddress.Text = reader.GetString("address")
                txtPostCode.Text = reader.GetString("post_code")
                txtPhysicalAddress.Text = reader.GetString("physical_address")
                txtTelephone.Text = reader.GetString("telephone")
                txtEmail.Text = reader.GetString("email")
                txtMobile.Text = reader.GetString("mobile")
                txtFax.Text = reader.GetString("fax")
                If Not IsDBNull(reader("logo_length")) Then
                    Dim byteImage() As Byte = reader("logo")
                    Dim logo As New System.IO.MemoryStream(byteImage)
                    pctLogo.Image = Image.FromStream(logo)
                Else
                    pctLogo.Image = Nothing
                End If
                loaded = True
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return loaded
    End Function



    Private Sub btnEditCompanyDetails_Click(sender As Object, e As EventArgs) Handles btnEditCompanyDetails.Click
        If locked = True Then
            unlock()
            locked = False
            btnSaveCompanyDetails.Enabled = True
        Else
            lock()
            locked = True
            btnSaveCompanyDetails.Enabled = False
        End If
    End Sub

    Private Sub btnSaveCompanyDetails_Click(sender As Object, e As EventArgs) Handles btnSaveCompanyDetails.Click

        Dim ms As New MemoryStream
        pctLogo.Image.Save(ms, pctLogo.Image.RawFormat)
        Dim logo As Byte() = ms.GetBuffer()


        If validateDetails() = True Then
            Company.NAME = txtName.Text
            Company.CONTACT_NAME = txtContactName.Text
            Company.TIN = txtTIN.Text
            Company.VRN = txtVRN.Text
            Company.BANK_ACC_NAME = txtBankAccName.Text
            Company.BANK_ACC_ADDRESS = txtBankAccAddress.Text
            Company.BANK_POST_CODE = txtBankPostCode.Text
            Company.BANK_NAME = txtBankName.Text
            Company.BANK_ACC_NO = txtBankAccNo.Text
            Company.ADDRESS = txtAddress.Text
            Company.POST_CODE = txtPostCode.Text
            Company.PHYSICAL_ADDRESS = txtPhysicalAddress.Text
            Company.TELEPHONE = txtTelephone.Text
            Company.MOBILE = txtMobile.Text
            Company.EMAIL = txtEmail.Text
            Company.FAX = txtFax.Text
            Company.LOGO = logo
            Company.saveCompanyDetails()
            MsgBox("Company details saved successively", vbOKOnly + vbInformation, "Success: Save company details")
            btnSaveCompanyDetails.Enabled = False
            lock()
        Else
            MsgBox("Could not save company information. Important fields missing. Make sure the fields marked with * are filled", vbOKOnly + vbCritical, "Error: Missing information")
        End If

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub frmCompany_Load_2(sender As Object, e As EventArgs) Handles MyBase.Load
        lock()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub txtAddress_TextChanged(sender As Object, e As EventArgs) Handles txtAddress.TextChanged

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub txtPostCode_TextChanged(sender As Object, e As EventArgs) Handles txtPostCode.TextChanged

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub txtPhysicalAddress_TextChanged(sender As Object, e As EventArgs) Handles txtPhysicalAddress.TextChanged

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub txtTelephone_TextChanged(sender As Object, e As EventArgs) Handles txtTelephone.TextChanged

    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click

    End Sub

    Private Sub txtMobile_TextChanged(sender As Object, e As EventArgs) Handles txtMobile.TextChanged

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub

    Private Sub btnChangeLogo_Click(sender As Object, e As EventArgs) Handles btnChangeLogo.Click
        If fileDialog.ShowDialog = DialogResult.OK Then
            pctLogo.ImageLocation = fileDialog.FileName
        End If
    End Sub
End Class