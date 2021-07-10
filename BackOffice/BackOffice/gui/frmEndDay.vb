Imports Devart.Data.MySql

Public Class frmEndDay
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub
    Private Function loadDay()
        Dim day As New Day
        Dim currentDate As Date = day.getCurrentDay()
        If currentDate.ToString("yyyy-MM-dd") = "0001-01-01" Then
            currentDate = Date.Now
            ''''''day.startDay(currentDate.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd:HH:MM:SS"))
        End If
        txtCurrentDate.Text = currentDate.ToString("yyyy-MM-dd")
        txtOpenAt.Text = day.startedAt
        Return vbNull
    End Function

    Private Function getDatabaseDate() As String
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = "SELECT CURDATE() AS `date`"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                Return reader.GetString("date").ToString()
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ""
    End Function

    Private Sub frmEndDay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim serverDate As String = Day.getDatabaseDate()
        Dim computerDate As String = Date.Today.ToString("yyyy-MM-dd")
        If serverDate <> computerDate Then
            MsgBox("Can not perform operation. Server date and client date do not match. Server date: " + serverDate + ", Computer Date: " + computerDate + " Please ensure the server date matches with your computer date to be able to end the day", vbOKOnly + vbCritical, "Error: Date synchronization failed")
            Me.Dispose()
        End If
        loadDay()
    End Sub
    Private Sub btnCloseDay_Click(sender As Object, e As EventArgs) Handles btnCloseDay.Click
        Dim res As Integer = MsgBox("Are you sure you want to End the day?", vbQuestion + vbYesNo, "End Day")
        If res = DialogResult.Yes Then
            Dim day As New Day
            Dim daysToAdd As Integer = 1
            Dim currentDate As Date = day.getCurrentDay()
            If currentDate.ToString("yyyy-MM-dd") = "0001-01-01" Or currentDate < Date.Today Then
                currentDate = Date.Now
                daysToAdd = 0
            ElseIf currentDate.ToString("yyyy-MM-dd") = Date.Today.ToString("yyyy-MM-dd") Then
                daysToAdd = 1
            ElseIf currentDate > Date.Today Then
                daysToAdd = 0
            Else
                daysToAdd = 0
            End If

            day.endDay(currentDate.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd:HH:MM:SS"))
            Dim newDate As Date = currentDate.AddDays(daysToAdd)
            day.startDay(newDate.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd:HH:MM:SS"))
            'loadDay()
            btnCloseDay.Enabled = False
            lblStatus.Text = "....You have started a new day!...."
            End
        End If
    End Sub
End Class