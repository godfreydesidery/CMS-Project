Imports Devart.Data.MySql

Public Class frmUserEnrolment
    Dim EDIT_MODE As String = ""
    Private GL_USERNAME As String = ""
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub



    Private Function clear()
        txtFirstName.Text = ""
        txtSecondName.Text = ""
        txtLastName.Text = ""
        txtPayrollNo.Text = ""
        cmbRole.Text = ""
        cmbStatus.Text = ""
        txtUsername.Text = ""
        txtPassword.Text = ""
        txtConfPassword.Text = ""
        Return vbNull
    End Function
    Private Function lock()
        txtFirstName.ReadOnly = True
        txtSecondName.ReadOnly = True
        txtLastName.ReadOnly = True
        txtPayrollNo.ReadOnly = True
        cmbRole.Enabled = False
        cmbStatus.Enabled = False
        txtUsername.ReadOnly = True
        txtPassword.ReadOnly = True
        txtConfPassword.ReadOnly = True
        Return vbNull
    End Function
    Private Function unlock()
        txtFirstName.ReadOnly = False
        txtSecondName.ReadOnly = False
        txtLastName.ReadOnly = False
        txtPayrollNo.ReadOnly = False
        cmbRole.Enabled = True
        cmbStatus.Enabled = True
        txtUsername.ReadOnly = False
        txtPassword.ReadOnly = False
        txtConfPassword.ReadOnly = False
        Return vbNull
    End Function
    Private Sub loadRoles()
        Dim conn As New MySqlConnection(Database.conString)
        Try
            Dim suppcommand As New MySqlCommand()
            Dim supplierQuery As String = "SELECT `id`, `role` FROM `roles`"
            conn.Open()
            suppcommand.CommandText = supplierQuery
            suppcommand.Connection = conn
            suppcommand.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = suppcommand.ExecuteReader
            cmbRole.Items.Clear()
            If reader.HasRows Then
                While reader.Read
                    cmbRole.Items.Add(reader.GetString("role"))
                End While
            End If
            conn.Close()
        Catch ex As Devart.Data.MySql.MySqlException
            ErrorMessage.dbConnectionError()
            Exit Sub
        End Try
    End Sub
    Private Sub frmUserEnrolment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clear()
        loadRoles()
    End Sub
    Private Function refreshList()


        dtgrdUsers.Rows.Clear()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `first_name`, `second_name`, `last_name`, `pay_roll_no`, `role`,role_id,`username` FROM `users`"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim payRollNo As String = ""
            Dim name As String = ""
            Dim role As String = ""
            Dim username As String = ""

            While reader.Read

                payRollNo = reader.GetString("pay_roll_no")
                name = reader.GetString("first_name") + " " + reader.GetString("last_name")
                role = (New Role).getRole(reader.GetString("role_id"))
                username = reader.GetString("username")

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = username
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = payRollNo
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = name
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = role
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdUsers.Rows.Add(dtgrdRow)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return vbNull
    End Function
    Private Sub frmUserEnrolment_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        refreshList()
        lock()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        EDIT_MODE = "NEW"
        txtID.Text = ""
        btnEdit.Enabled = True
        btnDelete.Enabled = False
        btnSave.Enabled = True
        btnSearch.Enabled = False
        clear()
        unlock()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        If txtUsername.Text <> "" Then
            EDIT_MODE = ""
            btnDelete.Enabled = True
            btnSave.Enabled = True

        End If
        btnSearch.Enabled = True
        unlock()
        txtPassword.Text = ""
        txtConfPassword.Text = ""
    End Sub
    'Dim username As String = ""
    Private Function search() As Boolean
        Dim found As Boolean = False
        Dim user As New User
        If user.searchUser((New User).getUserID(txtUsername.Text)) = True Then
            txtID.Text = user.GL_USER_ID
            txtUsername.Text = user.GL_USERNAME
            txtFirstName.Text = user.GL_FIRST_NAME
            txtSecondName.Text = user.GL_SECOND_NAME
            txtLastName.Text = user.GL_LAST_NAME
            txtPayrollNo.Text = user.GL_PAYROLL_NO
            cmbRole.Text = user.GL_ROLE
            cmbStatus.Text = user.GL_STATUS
            found = True

            lock()
            btnEdit.Enabled = True
            btnSave.Enabled = False
            btnDelete.Enabled = True
        Else
            MsgBox("No matching user", vbOKOnly + vbCritical, "Error: Not found")
        End If
        txtPassword.Text = ""
        txtConfPassword.Text = ""
        Return found
    End Function
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        btnNew.Enabled = True
        btnEdit.Enabled = True
        btnDelete.Enabled = False
        btnSave.Enabled = False
        search()

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If validateEntries() <> True Then
            Exit Sub
        End If
        Dim user As New User
        user.GL_USERNAME = txtUsername.Text
        user.GL_FIRST_NAME = txtFirstName.Text
        user.GL_SECOND_NAME = txtSecondName.Text
        user.GL_LAST_NAME = txtLastName.Text
        user.GL_PAYROLL_NO = txtPayrollNo.Text
        user.GL_ROLE = cmbRole.Text
        user.GL_STATUS = cmbStatus.Text
        user.GL_PASSWORD = Hash.make(txtPassword.Text)    'txtPassword.Text
        If EDIT_MODE = "NEW" Then
            user.GL_STATUS = "ACTIVE"
            If user.addNewUser() = True Then
                lock()
                btnEdit.Enabled = True
                btnSave.Enabled = False
                EDIT_MODE = ""
            End If
        Else
            If user.editUser(txtID.Text) = True Then
                lock()
                btnEdit.Enabled = True
                btnSave.Enabled = False
                EDIT_MODE = ""
            End If
        End If
        refreshList()
    End Sub
    Private Function deleteUser(username As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "DELETE FROM `users` WHERE `username`='" + username + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return success
    End Function

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim res As Integer = MsgBox("Are you sure you want to delete the selected user? Information about the user will be removed from the sustem", vbYesNo + vbQuestion, "Delete user account?")
        If res = DialogResult.Yes Then
            deleteUser(txtUsername.Text)
            refreshList()
        End If
        btnDelete.Enabled = False
        btnEdit.Enabled = False
        btnSave.Enabled = False
        unlock()
        clear()
    End Sub

    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged

    End Sub

    Private Sub txtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsername.KeyDown
        If Keys.Tab = Keys.Right Then
            search()
        End If
    End Sub

    Private Sub dtgrdUsers_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdUsers.CellContentClick

    End Sub
    Private Function validateEntries() As Boolean
        Dim valid As Boolean = True
        Dim errorMessage As String = ""

        If txtPassword.Text = "" Then
            errorMessage = "Password required"
            valid = False
        End If
        If txtPassword.Text.Length < 6 Or txtPassword.Text.Length > 10 Then
            errorMessage = "Invalid password length. Password length must be between 6-10 characters"
            valid = False
        End If
        If txtPassword.Text <> txtConfPassword.Text Then
            errorMessage = "The value of password and password confirmation does not match"
            valid = False
        End If
        If txtLastName.Text = "" Then
            errorMessage = "Last name required"
            valid = False
        End If
        If txtFirstName.Text = "" Then
            errorMessage = "First name required"
            valid = False
        End If
        If txtUsername.Text = "" Then
            errorMessage = "Username required"
            valid = False
        End If
        If valid = False Then
            MsgBox(errorMessage, vbOKOnly + vbCritical, "Error: Invalid entry")
        End If
        Return valid
    End Function
    Private Sub dtgrdUsers_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdUsers.RowHeaderMouseClick
        clear()
        Dim row As Integer = -1
        Dim col As Integer = -1
        Try
            row = dtgrdUsers.CurrentRow.Index
            col = dtgrdUsers.CurrentCell.ColumnIndex
        Catch ex As Exception
            row = -1
        End Try
        Dim username As String = ""
        row = dtgrdUsers.CurrentRow.Index
        txtUsername.Text = dtgrdUsers.Item(0, row).Value.ToString
        search()
    End Sub

    Private Sub cmbStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStatus.SelectionChangeCommitted
        If txtID.Text <> "" And txtUsername.Text <> "" Then
            Try
                Dim conn As New MySqlConnection(Database.conString)
                Dim command As New MySqlCommand()

                Dim codeQuery As String = "UPDATE `users` SET `status`='" + cmbStatus.Text + "' WHERE `id`='" + txtID.Text + "'"
                conn.Open()
                command.CommandText = codeQuery
                command.Connection = conn
                command.CommandType = CommandType.Text
                command.ExecuteNonQuery()
                conn.Close()
                MsgBox("Status set to " + cmbStatus.Text + " ", vbOKOnly + vbInformation, "Status changed")
            Catch ex As Exception
                'MsgBox(ex.Message)
            End Try

        End If
    End Sub

    Private Sub cmbStatus_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbStatus.SelectedIndexChanged

    End Sub
End Class