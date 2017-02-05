Imports System.Collections.Generic
Imports System.IO
Imports System.Runtime.InteropServices
Imports System
Imports System.Management
Imports System.Security.Permissions



Public Class frmLlistatDispositius

    Private Const WM_DEVICECHANGE As Integer = &H219
    Private Const DBT_DEVICEARRIVAL As Integer = &H8000
    Private Const DBT_DEVTYP_VOLUME As Integer = &H2


    Private Declare Sub LockWorkStation Lib "user32.dll" ()

    'Device information structure
    Public Structure DEV_BROADCAST_HDR
        Public dbch_size As Int32
        Public dbch_devicetype As Int32
        Public dbch_reserved As Int32
    End Structure

    'Volume information Structure
    Private Structure DEV_BROADCAST_VOLUME
        Public dbcv_size As Int32
        Public dbcv_devicetype As Int32
        Public dbcv_reserved As Int32
        Public dbcv_unitmask As Int32
        Public dbcv_flags As Int16
    End Structure

    'Function that gets the drive letter from the unit mask
    Private Function GetDriveLetterFromMask(ByRef Unit As Int32) As Char
        Dim res As Char
        For i As Integer = 0 To 25
            If Unit = (2 ^ i) Then
                Return Chr(Asc("A") + i)
            End If
        Next
    End Function



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

    'https://blog.cjwdev.co.uk/2009/11/10/vb-net-detecting-when-a-usb-drive-is-connected-and-getting-the-drive-letter/
    <SecurityPermissionAttribute(SecurityAction.InheritanceDemand,
    Flags:=SecurityPermissionFlag.UnmanagedCode)>
    <SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags:=SecurityPermissionFlag.UnmanagedCode)>
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = WM_DEVICECHANGE Then
            LockWorkStation()
            If CInt(m.WParam) = DBT_DEVICEARRIVAL Then
                'Dim DeviceInfo As DEV_BROADCAST_HDR
                'DeviceInfo = DirectCast(Marshal.PtrToStructure(m.LParam, GetType(DEV_BROADCAST_HDR)), DEV_BROADCAST_HDR)
                'If DeviceInfo.dbch_devicetype = DBT_DEVTYP_VOLUME Then
                '    Dim Volume As DEV_BROADCAST_VOLUME
                '    Volume = DirectCast(Marshal.PtrToStructure(m.LParam, GetType(DEV_BROADCAST_VOLUME)), DEV_BROADCAST_VOLUME)
                '    Dim DriveLetter As String = (GetDriveLetterFromMask(Volume.dbcv_unitmask) & ":\")
                '    If IO.File.Exists(IO.Path.Combine(DriveLetter, "test.txt")) Then
                '        '<<<< The test file has been found >>>>
                '        MessageBox.Show("Found test file")
                '    Else
                '        '<<<< Test file has not been found >>>>
                '        MessageBox.Show("Could not find test file")
                '    End If
                'End If
            End If
        End If
        'Process all other messages as normal
        MyBase.WndProc(m)
    End Sub

End Class