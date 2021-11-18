Imports Devart.Data.MySql

Public Class frmSettings
    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtgrdSettings.Rows.Clear()

        Dim settings As String() = Setting.SETTINGS

        For i As Integer = 0 To settings.Length - 1

            Dim status As Boolean = False

            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `value` FROM `settings` WHERE `name`='" + settings(i).ToString + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()

            While reader.Read
                If settings(i).ToString = "ALLOW_NEGATIVE_SALES" And reader.GetString("value") = "YES" Then
                    status = True
                End If
                Exit While
            End While

            Dim dtgrdRow As New DataGridViewRow
            Dim dtgrdCell As DataGridViewCell

            dtgrdCell = New DataGridViewTextBoxCell()
            ' dtgrdCell.Value = ""
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = settings(i).ToString
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewCheckBoxCell()
            dtgrdCell.Value = status
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdSettings.Rows.Add(dtgrdRow)
        Next


    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not dtgrdSettings.RowCount > 0 Then
            Exit Sub
        End If
        For i As Integer = 0 To dtgrdSettings.RowCount - 1
            Dim name As String = dtgrdSettings.Item(1, i).Value
            Dim status As Boolean = dtgrdSettings.Item(2, i).Value
            Dim value As String = ""
            If name = "ALLOW_NEGATIVE_SALES" Then
                If status = True Then
                    value = "YES"
                Else
                    value = "NO"
                End If
                Try
                    Dim conn As New MySqlConnection(Database.conString)
                    conn.Open()
                    Dim command As New MySqlCommand()
                    command.Connection = conn
                    command.CommandText = "DELETE FROM `settings` WHERE `name` ='" + name + "'; INSERT INTO `settings`(`name`,`value`) VALUES ('" + name + "','" + value + "')"
                    command.Prepare()
                    command.ExecuteNonQuery()
                    conn.Close()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

            End If
        Next
        MsgBox("Done", vbOKOnly + vbInformation, "Done")
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub
End Class