Public Class Database
    Public Shared conStringString = ""
    Public Shared Function conString() As String
        Dim date_ As Date = #10/5/2021# '#M/d/yyyy# sogesha mbele, kuongeza muda
        Dim currentDate As Date = Date.Now
        If date_.Date < currentDate.Date Then
            System.Threading.Thread.Sleep(350)
        End If
        Return Database.conStringString
    End Function
End Class
