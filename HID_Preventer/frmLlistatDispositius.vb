Imports System.Collections.Generic


Public Class frmLlistatDispositius
    Private Sub frmLlistatDispositius_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dispositius As New List(Of String)
        dispositius.Add("teclat")
        dispositius.Add("ratoli")
        dispositius.Add("camara")
        omplenaListBox(dispositius)

    End Sub



    Sub omplenaListBox(ByVal dispositius As List(Of String))
        For Each disp As String In dispositius
            listDisp.Items.Add(disp)
        Next
    End Sub


End Class