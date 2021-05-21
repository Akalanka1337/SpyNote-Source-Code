Imports Spy_Note.etonyps

Public Class about
    Private Sub about_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Label1.Text = store_0.name_prog + ":"
        Me.PictureBox1.Image = store_0.Bitmap_0("img_0")
    End Sub
End Class