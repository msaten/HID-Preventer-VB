Public Class IOFitxer
    Private fitxer As String

    Public Property getNomFitxer As String
        Get
            Return fitxer
        End Get
        Set(value As String)
            fitxer = value
        End Set
    End Property

    Sub llegirFitxer()
        Dim fileReader As String
        fileReader = My.Computer.FileSystem.ReadAllText("C:\test.txt")
        MsgBox(fileReader)
    End Sub






End Class
