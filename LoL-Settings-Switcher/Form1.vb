﻿Imports System.Configuration
Imports System.IO
Imports System.Net.Http
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Diagnostics
Imports System.Windows.Forms

Public Class Form1

    Public gamecfg As String = "C:\Riot Games\League of Legends\Config\game.cfg"
    Public persistedsettings As String = "C:\Riot Games\League of Legends\Config\PersistedSettings.json"
    Public WorkingDir As String
    Public AppDataLocalDir As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Riot Games")
    Public LocalRiotClientDir As String = AppDataLocalDir + "\Riot Client"
    Public LaunchLeagueCommand As String = "C:\Riot Games\Riot Client\RiotClientServices.exe"
    Public LaunchLeagueCommandParameters As String = "--launch-product=league_of_legends --launch-patchline=live"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSettingsStatus()

        ' Determine if Riot Games installed at default location
        If IO.Directory.Exists("C:\Riot Games\") Then
            My.Settings.RiotGamesPath = "C:\Riot Games\"


        End If

        'If My.Settings.WorkingDirectory <> "" Then
        '    WorkingDir = My.Settings.WorkingDirectory

        'Else
        '    Dim ofd As New FolderBrowserDialog
        '    ofd.Description = "Please select the directory we will be using in this app. Subdirectories will be created for each profile."
        '    ofd.ShowDialog()
        '    WorkingDir = ofd.SelectedPath
        '    My.Settings.WorkingDirectory = ofd.SelectedPath

        'End If

        'GetProfileDirectories()

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

    Private Sub RestartClient(sender As Object, e As EventArgs) Handles Button3.Click
        ' Close LeagueOfLegends.exe if it's running
        EndProcessByName("LeagueClient")

        ' Close Riot Client Services background task, RiotClientServices.exe
        EndProcessByName("RiotClientServices")


        ' Launch league of legends from directory, with commandline args
        Process.Start(LaunchLeagueCommand, LaunchLeagueCommandParameters)

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
    Public Sub CloseApps()
        ' Close LeagueOfLegends.exe if it's running
        EndProcessByName("LeagueClient")

        ' Close Riot Client Services background task, RiotClientServices.exe
        EndProcessByName("RiotClientServices")

    End Sub

    Public Sub LaunchApps()
        ' Launch league of legends from directory, with commandline args
        Process.Start(LaunchLeagueCommand, LaunchLeagueCommandParameters)

    End Sub
    Private Sub NewProfile(sender As Object, e As EventArgs) Handles Button5.Click
        'CloseApps()

        Dim newprofilename As String
        newprofilename = InputBox("Please enter a 'name' for the new profile, as you would like it to appear in the application dropdown.")
        Dim newdirectoryname As String
        newdirectoryname = WorkingDir + "\" + newprofilename
        If Not IO.Directory.Exists(newdirectoryname) Then
            IO.Directory.CreateDirectory(newdirectoryname)
        End If

        My.Computer.FileSystem.CopyDirectory(LocalRiotClientDir, newdirectoryname + "\Riot Client", True)
        MsgBox("Profile Saved! New Dir: " & newdirectoryname)
        cboxProfile.Items.Clear()
        GetProfileDirectories()

    End Sub

    Public Sub GetProfileDirectories()
        For Each Dir As String In IO.Directory.GetDirectories(WorkingDir)
            Dim subdir As String
            Dim dd As New IO.DirectoryInfo(Dir)
            subdir = dd.Name
            cboxProfile.Items.Add(subdir)

        Next
    End Sub

#Region "Open Dropdown on mouseover"
    Private Sub cboxProfile_MouseHover(sender As Object, e As EventArgs) Handles cboxProfile.MouseHover
        'cboxProfile.DroppedDown = True

    End Sub

    Private Sub cboxProfile_MouseEnter(sender As Object, e As EventArgs) Handles cboxProfile.MouseEnter
        'cboxProfile.DroppedDown = True

    End Sub
#End Region

    Private Sub LoadProfile(sender As Object, e As EventArgs) Handles btnLoad.Click
        CloseApps()
        Dim profiledir As String
        profiledir = WorkingDir + "\" + cboxProfile.SelectedItem.ToString + "\Riot Client"
        Try
            IO.Directory.Delete(LocalRiotClientDir, True)
        Catch ex As Exception

        End Try
        My.Computer.FileSystem.CopyDirectory(profiledir, LocalRiotClientDir, True)
        LaunchApps()





    End Sub

    Private Sub SignOutClient(sender As Object, e As EventArgs) Handles Button8.Click
        MsgBox("We are about to clear out the local Riot Client directory , to sign you out without expiring the auth token for the login, so that you can sign in and capture a new login. Ideally this is something you're doing after already copying this profile into the app :)")
        CloseApps()


        IO.Directory.Delete(LocalRiotClientDir, True)
        LaunchApps()

    End Sub

    Private Sub DeleteProfile(sender As Object, e As EventArgs) Handles Button7.Click
        Dim profiledir As String
        profiledir = WorkingDir + "\" + cboxProfile.SelectedItem.ToString
        IO.Directory.Delete(profiledir, True)
        cboxProfile.Items.Clear()
        GetProfileDirectories()

    End Sub

End Class
