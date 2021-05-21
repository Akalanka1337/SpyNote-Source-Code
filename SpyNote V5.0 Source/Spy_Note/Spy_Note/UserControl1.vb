Public Class UserControl1
    Private Sub DataLogs_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles DataLogs.KeyDown
        If (e.KeyCode = Keys.H) Then
            My.Forms.Form1.PKeyDown(False)
        ElseIf (e.KeyCode = Keys.S) Then
            My.Forms.Form1.PKeyDown(True)
        End If
    End Sub
End Class
