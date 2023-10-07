Imports System.IO

Public Class Form1

    Public gamecfg As String = "C:\Riot Games\League of Legends\Config\game.cfg"
    Public persistedsettings As String = "C:\Riot Games\League of Legends\Config\PersistedSettings.json"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSettingsStatus()


    End Sub

    Public Sub LoadSettingsStatus()
        If IO.File.Exists(gamecfg) And IO.File.Exists(persistedsettings) Then
            ' Check if files are readonly
            Dim fileInfo As New FileInfo(gamecfg)

            If (fileInfo.Attributes And FileAttributes.ReadOnly) = FileAttributes.ReadOnly Then
                Label1.Text = "Settings are locked."
            Else
                Label1.Text = "Settings are unlocked."
            End If
            Dim fileInfo2 As New FileInfo(persistedsettings)

            If (fileInfo2.Attributes And FileAttributes.ReadOnly) = FileAttributes.ReadOnly Then
                Label1.Text = "Settings are locked."
            Else
                Label1.Text = "Settings are unlocked."
            End If

        Else
            MsgBox("Couldn't locate settings files.")
            Label1.Text = "Couldn't locate settings files."

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        File.SetAttributes(gamecfg, FileAttributes.ReadOnly)
        File.SetAttributes(persistedsettings, FileAttributes.ReadOnly)
        LoadSettingsStatus()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        File.SetAttributes(gamecfg, File.GetAttributes(gamecfg) And Not FileAttributes.ReadOnly)
        File.SetAttributes(persistedsettings, File.GetAttributes(persistedsettings) And Not FileAttributes.ReadOnly)
        LoadSettingsStatus()

    End Sub
End Class
