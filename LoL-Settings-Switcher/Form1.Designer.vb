<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Button1 = New Button()
        Button2 = New Button()
        Label1 = New Label()
        Button3 = New Button()
        cboxProfile = New ComboBox()
        Button5 = New Button()
        btnLoad = New Button()
        Button7 = New Button()
        Button8 = New Button()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(12, 115)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 38)
        Button1.TabIndex = 0
        Button1.Text = "Lock Settings"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(93, 115)
        Button2.Name = "Button2"
        Button2.Size = New Size(75, 38)
        Button2.TabIndex = 0
        Button2.Text = "Unlock Settings"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(41, 15)
        Label1.TabIndex = 1
        Label1.Text = "Label1"
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(12, 159)
        Button3.Name = "Button3"
        Button3.Size = New Size(156, 23)
        Button3.TabIndex = 2
        Button3.Text = "Restart / Start League"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' cboxProfile
        ' 
        cboxProfile.DropDownStyle = ComboBoxStyle.DropDownList
        cboxProfile.FormattingEnabled = True
        cboxProfile.Location = New Point(12, 27)
        cboxProfile.Name = "cboxProfile"
        cboxProfile.Size = New Size(99, 23)
        cboxProfile.TabIndex = 3
        ' 
        ' Button5
        ' 
        Button5.Location = New Point(12, 57)
        Button5.Name = "Button5"
        Button5.Size = New Size(75, 23)
        Button5.TabIndex = 5
        Button5.Text = "Add"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' btnLoad
        ' 
        btnLoad.Location = New Point(117, 27)
        btnLoad.Name = "btnLoad"
        btnLoad.Size = New Size(58, 23)
        btnLoad.TabIndex = 6
        btnLoad.Text = "Load"
        btnLoad.UseVisualStyleBackColor = True
        ' 
        ' Button7
        ' 
        Button7.Location = New Point(93, 57)
        Button7.Name = "Button7"
        Button7.Size = New Size(75, 23)
        Button7.TabIndex = 7
        Button7.Text = "Remove"
        Button7.UseVisualStyleBackColor = True
        ' 
        ' Button8
        ' 
        Button8.Location = New Point(12, 86)
        Button8.Name = "Button8"
        Button8.Size = New Size(156, 23)
        Button8.TabIndex = 8
        Button8.Text = "Sign Out To Add New"
        Button8.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(187, 188)
        Controls.Add(Button8)
        Controls.Add(Button7)
        Controls.Add(btnLoad)
        Controls.Add(Button5)
        Controls.Add(cboxProfile)
        Controls.Add(Button3)
        Controls.Add(Label1)
        Controls.Add(Button2)
        Controls.Add(Button1)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Leauge Login / Settings Manager"
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents cboxProfile As ComboBox
    Friend WithEvents Button5 As Button
    Friend WithEvents btnLoad As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
End Class
