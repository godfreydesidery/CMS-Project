Public Class Utility
    Public Shared Function generateRandom20TokenWithDateTime() As String
        Dim KeyGen As RandomKeyGenerator
        Dim NumKeys As Integer
        Dim i_Keys As Integer
        Dim RandomKey As String = ""

        ''' MODIFY THIS TO GET MORE KEYS    - LAITH - 27/07/2005 22:48:30 -
        NumKeys = 30

        KeyGen = New RandomKeyGenerator
        KeyGen.KeyLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
        KeyGen.KeyNumbers = "0123456789"
        KeyGen.KeyChars = 20
        For i_Keys = 1 To NumKeys
            RandomKey = KeyGen.Generate()
        Next
        Return System.DateTime.Now.ToString + RandomKey
    End Function
End Class
