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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Close LeagueOfLegends.exe if it's running
        EndProcessByName("LeagueClient")

        ' Close Riot Client Services background task, RiotClientServices.exe
        EndProcessByName("RiotClientServices")


        ' Launch league of legends from directory, with commandline args
        Process.Start("C:\Riot Games\League of Legends\LeagueClient.exe", "--locale=en_US")

    End Sub

    Private Sub EndProcessByName(Name As String)
        Dim processes As Process() = Process.GetProcessesByName(Name)

        If processes.Length > 0 Then
            For Each proc As Process In processes
                Try
                    ' Kill the process
                    proc.Kill()
                    ' Wait for the process to exit
                    proc.WaitForExit()
                Catch ex As Exception
                    ' Handle any exception that might occur
                    Console.WriteLine("Error while terminating the process: " & ex.Message)
                End Try
            Next

            Console.WriteLine("Killed " & Name & vbCrLf)
        Else
            Console.WriteLine("Didn't kill " & Name & ", process not running." & vbCrLf)
        End If
    End Sub

End Class
