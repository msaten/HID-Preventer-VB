Imports System.Collections.Generic
Imports System.IO
Imports System.Runtime.InteropServices
Imports System
Imports System.Management



Public Class frmLlistatDispositius
    Private Sub frmLlistatDispositius_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        omplenaListBox(getConnectedDevices())
    End Sub



    Sub omplenaListBox(ByVal dispositius As List(Of String))
        For Each disp As String In dispositius
            If disp <> Nothing Then
                listDisp.Items.Add(disp)
            End If
        Next
    End Sub



    Private Function getConnectedDevices() As List(Of String)
        Dim info As System.Management.ManagementObject
        Dim search As System.Management.ManagementObjectSearcher
        Dim Name As String
        Dim dispositius As New List(Of String)

        search = New System.Management.ManagementObjectSearcher("SELECT * From Win32_PnPEntity")

        For Each info In search.Get()
            Name = CType(info("Caption"), String)
            dispositius.Add(Name)
        Next


        Return dispositius
    End Function




End Class