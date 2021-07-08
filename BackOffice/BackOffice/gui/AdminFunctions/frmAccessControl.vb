Imports Devart.Data.MySql

Public Class frmAccessControl

    Dim EDIT_MODE As String = ""
    Private GL_ROLE_ID As String = ""
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Function clear()
        txtRole.Text = ""
        Return vbNull
    End Function
    Private Function lock()
        txtRole.ReadOnly = True
        Return vbNull
    End Function
    Private Function unlock()
        txtRole.ReadOnly = False
        Return vbNull
    End Function
    Private Sub frmUserEnrolment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clear()
        loadRoles()
    End Sub
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

    Private Function refreshRoleList()
        dtgrdRoles.Rows.Clear()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `id`, `role` FROM `roles`"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim id As String = ""
            Dim role As String = ""

            While reader.Read

                id = reader.GetString("id")
                role = reader.GetString("role")

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = id
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = role
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdRoles.Rows.Add(dtgrdRow)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return vbNull
    End Function
    Private Function refreshPriveledgeList(_role As String)
        dtgrdPriveledges.Rows.Clear()
        Try


            Dim _priveledge As String = ""
            Dim role As New Role

            Dim priveledges As String() = Priveledge.PRIVELEDGES

            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `role_id`, `priveledge` FROM `role_priveledge` WHERE `role_id`='" + (New Role).getRoleID(_role) + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text

            Dim result As New ArrayList

            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                Dim dict As New Dictionary(Of String, Object)
                For count As Integer = 0 To (reader.FieldCount - 1)
                    dict.Add(reader.GetName(count), reader(count))
                Next
                result.Add(dict)
            End While
            ' conn.Close()
            For ctr As Integer = 0 To priveledges.Length - 1

                _priveledge = priveledges(ctr).ToString

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = _priveledge
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewCheckBoxCell()
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdPriveledges.Rows.Add(dtgrdRow)


                'While reader.Read
                'If reader.GetString("priveledge") = _priveledge And reader.GetString("role_id") = role.getRoleID(cmbRole.SelectedItem.ToString) Then
                'dtgrdPriveledges.Item(1, ctr).Value = True

                'End If
                '  End While

                For Each dat As Dictionary(Of String, Object) In result
                    If dat("priveledge") = _priveledge And dat("role_id") = role.getRoleID(cmbRole.SelectedItem.ToString) Then
                        dtgrdPriveledges.Item(1, ctr).Value = True
                        dtgrdPriveledges.Rows(ctr).DefaultCellStyle.BackColor = SystemColors.ControlDark
                        If dat("priveledge").ToString.Contains("@") Then
                            dtgrdPriveledges.Rows(ctr).DefaultCellStyle.BackColor = SystemColors.ActiveCaption
                            dtgrdPriveledges.Rows(ctr).ReadOnly = True
                        End If
                        Exit For
                    End If
                Next
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return vbNull
    End Function

    Private Sub frmUserEnrolment_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        refreshRoleList()
        lock()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        EDIT_MODE = "NEW"
        txtRole.Text = ""
        btnEdit.Enabled = True
        btnDelete.Enabled = False
        btnSave.Enabled = True
        clear()
        unlock()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        If txtRole.Text <> "" Then
            EDIT_MODE = ""
            btnDelete.Enabled = True
            btnSave.Enabled = True

        End If
        unlock()
    End Sub
    'Dim username As String = ""
    Private Function search() As Boolean
        Dim found As Boolean = False
        Dim role As New Role
        If role.searchRole((New Role).getRoleID(txtRole.Text)) = True Then
            txtRole.Text = role.GL_ROLE
            found = True

            lock()
            btnEdit.Enabled = True
            btnSave.Enabled = False
            btnDelete.Enabled = True
        Else
            MsgBox("No matching role", vbOKOnly + vbCritical, "Error: Not found")
        End If
        Return found
    End Function


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If validateEntries() <> True Then
            Exit Sub
        End If
        Dim role As New Role
        role.GL_ROLE = txtRole.Text

        If EDIT_MODE = "NEW" Then
            If role.addNewRole() = True Then
                lock()
                btnEdit.Enabled = True
                btnSave.Enabled = False
                EDIT_MODE = ""
            End If
        Else
            If role.editRole(GL_ROLE_ID) = True Then
                lock()
                btnEdit.Enabled = True
                btnSave.Enabled = False
                EDIT_MODE = ""
            End If
        End If
        refreshRoleList()
    End Sub
    Private Function deleteRole(role As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "DELETE FROM `roles` WHERE `role`='" + role + "'"
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
        Dim res As Integer = MsgBox("Are you sure you want to delete the selected role? Information about the role will be removed from the system", vbYesNo + vbQuestion, "Delete role account?")
        If res = DialogResult.Yes Then
            deleteRole(txtRole.Text)
            refreshRoleList()
        End If
        btnDelete.Enabled = False
        btnEdit.Enabled = False
        btnSave.Enabled = False
        unlock()
        clear()
    End Sub



    Private Sub txtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRole.KeyDown
        If Keys.Tab = Keys.Right Then
            search()
        End If
    End Sub


    Private Function validateEntries() As Boolean
        Dim valid As Boolean = True
        Dim errorMessage As String = ""

        If txtRole.Text = "" Then
            errorMessage = "Role required"
            valid = False
        End If
        Return valid
    End Function
    Private Sub dtgrdRoles_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdRoles.RowHeaderMouseClick
        Dim row As Integer = -1
        Dim col As Integer = -1
        Try
            row = dtgrdRoles.CurrentRow.Index
            col = dtgrdRoles.CurrentCell.ColumnIndex
        Catch ex As Exception
            row = -1
        End Try
        Dim role As String = ""
        row = dtgrdRoles.CurrentRow.Index
        txtRole.Text = dtgrdRoles.Item(1, row).Value.ToString
        GL_ROLE_ID = dtgrdRoles.Item(0, row).Value.ToString
        search()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub cmbRole_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRole.Click

    End Sub

    Private Sub cmbRole_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbRole.SelectedIndexChanged
        lblInfo.Text = "Check or uncheck priveledges for " + cmbRole.SelectedItem.ToString
        refreshPriveledgeList(cmbRole.SelectedItem.ToString)
    End Sub

    Private Sub dtgrdPriveledges_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdPriveledges.CellContentClick
        Dim col As Integer = -1
        Dim row As Integer = -1
        Try
            row = dtgrdPriveledges.CurrentRow.Index
            col = dtgrdPriveledges.CurrentCell.ColumnIndex
        Catch ex As Exception
            row = -1
        End Try

        If dtgrdPriveledges.CurrentCell.ColumnIndex = 1 Then

            Try
                Dim conn As New MySqlConnection(Database.conString)
                Dim command As New MySqlCommand()
                'create bar code
                Dim codeQuery As String = "SELECT `id` FROM `role_priveledge`WHERE `role_id`='" + (New Role).getRoleID(cmbRole.Text) + "' AND `priveledge`='" + dtgrdPriveledges.Item(0, row).Value.ToString + "'"
                conn.Open()
                command.CommandText = codeQuery
                command.Connection = conn
                command.CommandType = CommandType.Text
                Dim f As Integer = 0
                Dim reader As MySqlDataReader = command.ExecuteReader()

                While reader.Read
                    f = 1
                    MsgBox("Disabled")
                    Exit While
                End While
                conn.Close()
                If f > 0 Then
                    deletePrev()
                Else
                    addPrev()
                End If

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            refreshPriveledgeList(cmbRole.SelectedItem.ToString)
        End If
    End Sub
    Private Sub deletePrev()
        Dim col As Integer = -1
        Dim row As Integer = -1
        Try
            row = dtgrdPriveledges.CurrentRow.Index
            col = dtgrdPriveledges.CurrentCell.ColumnIndex
        Catch ex As Exception
            row = -1
        End Try
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "DELETE FROM `role_priveledge` WHERE `role_id`='" + (New Role).getRoleID(cmbRole.SelectedItem.ToString) + "' AND `priveledge`='" + dtgrdPriveledges.Item(0, row).Value.ToString + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub addPrev()
        Dim col As Integer = -1
        Dim row As Integer = -1
        Try
            row = dtgrdPriveledges.CurrentRow.Index
            col = dtgrdPriveledges.CurrentCell.ColumnIndex
        Catch ex As Exception
            row = -1
        End Try
        Try
            Dim conn As New MySqlConnection(Database.conString)
            conn.Open()
            Dim command As New MySqlCommand()
            command.Connection = conn
            command.CommandText = "INSERT INTO `role_priveledge`( `role_id`, `priveledge`) VALUES (@role_id,@priveledge)"
            command.Prepare()
            command.Parameters.AddWithValue("@role_id", (New Role).getRoleID(cmbRole.SelectedItem.ToString))
            command.Parameters.AddWithValue("@priveledge", dtgrdPriveledges.Item(0, row).Value.ToString)
            command.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class