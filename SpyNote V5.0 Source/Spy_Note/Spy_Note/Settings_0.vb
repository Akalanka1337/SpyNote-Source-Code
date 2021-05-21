Imports Microsoft.VisualBasic.CompilerServices
Imports Spy_Note.etonyps

Public Class Settings_0
    Private Sub Settings_0_Load(sender As Object, e As EventArgs) Handles Me.Load
        MyBase.Icon = store_0.icons_0("window")
        Select Case My.Settings.Data_encoding
            Case 0
                Me.ComboBox1.Text = "Default"
            Case 1
                Me.ComboBox1.Text = "UTF7"
            Case 2
                Me.ComboBox1.Text = "UTF8"
            Case 3
                Me.ComboBox1.Text = "UTF32"
            Case 4
                Me.ComboBox1.Text = "Unicode"
            Case 5
                Me.ComboBox1.Text = "ASCII"
            Case 6
                Me.ComboBox1.Text = "BigEndianUnicode"
            Case Else
                Me.ComboBox1.Text = "Unknown error"
        End Select
        Select Case My.Settings.Process_Priority
            Case 0
                Me.ComboBox2.Text = "RealTime"
            Case 1
                Me.ComboBox2.Text = "High"
            Case 2
                Me.ComboBox2.Text = "AboveNormal"
            Case 3
                Me.ComboBox2.Text = "Normal"
            Case 4
                Me.ComboBox2.Text = "BelowNormal"
            Case 5
                Me.ComboBox2.Text = "Idle"
            Case Else
                Me.ComboBox2.Text = "Unknown error"
        End Select
        Dim flag As Boolean = My.Settings.Protocol_tcp <> 0
        If flag Then
            Me.CheckBox2.Checked = True
        Else
            Me.CheckBox2.Checked = False
        End If
        Dim flag2 As Boolean = My.Settings.Protocol_udp <> 0
        If flag2 Then
            Me.CheckBox1.Checked = True
        Else
            Me.CheckBox1.Checked = False
        End If
        Me.NumericUpDown1.Value = New Decimal(My.Settings.Maximum_Clients)
        Dim flag3 As Boolean = Conversions.ToBoolean(Operators.NotObject(store_0.IF_Admin()))
        If flag3 Then
            Me.GroupBox2.Enabled = False
        End If
        Dim windows_foreground As Boolean = My.Settings.Windows_foreground
        If windows_foreground Then
            Me.CheckBox4.Checked = True
        Else
            Me.CheckBox4.Checked = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Settings.Data_encoding = Me.ComboBox1.SelectedIndex
        Dim checked As Boolean = Me.CheckBox2.Checked
        If checked Then
            My.Settings.Protocol_tcp = 1
        Else
            My.Settings.Protocol_tcp = 0
        End If
        Dim checked2 As Boolean = Me.CheckBox1.Checked
        If checked2 Then
            My.Settings.Protocol_udp = 1
        Else
            My.Settings.Protocol_udp = 0
        End If
        My.Settings.Maximum_Clients = Convert.ToInt32(Me.NumericUpDown1.Value)
        My.Settings.Process_Priority = Me.ComboBox2.SelectedIndex
        store_0.myProcessPreference()
        Dim checked3 As Boolean = Me.CheckBox4.Checked
        If checked3 Then
            My.Settings.Windows_foreground = True
        Else
            My.Settings.Windows_foreground = False
        End If
        My.Settings.Save()
        Dim flag As Boolean = My.Forms.Form1.s.ListenerTCP.Count > 0
        If flag Then
            Interaction.MsgBox("Some features work after you restart the listener", MsgBoxStyle.Information, Nothing)
        End If
        MyBase.Close()
    End Sub
End Class