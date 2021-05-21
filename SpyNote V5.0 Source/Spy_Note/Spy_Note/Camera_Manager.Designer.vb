<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Camera_Manager
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.L1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.FlashModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ONToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OFFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FocusModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EdofToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FixedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SceneModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutoToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.NightToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PartyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EffectsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EFFECTNONEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EFFECTNEGATIVEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EFFECTAQUAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EFFECTBLACKBOARDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EFFECTMONOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EFFECTPOSTERIZEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EFFECTSEPIAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EFFECTWHITEBOARDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.L1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Controls.Add(Me.ComboBox2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 254)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(432, 23)
        Me.Panel1.TabIndex = 0
        '
        'ComboBox1
        '
        Me.ComboBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(85, 1)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(85, 21)
        Me.ComboBox1.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Select Camera"
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.Location = New System.Drawing.Point(177, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(69, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Capture"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.CheckBox1.Location = New System.Drawing.Point(246, 0)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(91, 23)
        Me.CheckBox1.TabIndex = 2
        Me.CheckBox1.Text = "Multi-Capture"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ComboBox2
        '
        Me.ComboBox2.Dock = System.Windows.Forms.DockStyle.Right
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"10%", "20%", "30%", "40%", "50%", "60%", "70%", "80%", "90%", "100%"})
        Me.ComboBox2.Location = New System.Drawing.Point(337, 0)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(54, 21)
        Me.ComboBox2.TabIndex = 1
        Me.ComboBox2.Text = "50%"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label3.Location = New System.Drawing.Point(391, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Quality"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Panel2.Controls.Add(Me.L1)
        Me.Panel2.Controls.Add(Me.PictureBox2)
        Me.Panel2.Location = New System.Drawing.Point(3, 44)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(54, 31)
        Me.Panel2.TabIndex = 1
        '
        'L1
        '
        Me.L1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.L1.Location = New System.Drawing.Point(2, 2)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(24, 24)
        Me.L1.TabIndex = 1
        Me.L1.TabStop = False
        Me.L1.Tag = "On"
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Location = New System.Drawing.Point(47, 11)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(5, 7)
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Tag = "On"
        '
        'Timer1
        '
        Me.Timer1.Interval = 10
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 241)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(432, 13)
        Me.Panel3.TabIndex = 2
        Me.Panel3.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.ForeColor = System.Drawing.Color.Crimson
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "..."
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(432, 241)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FlashModeToolStripMenuItem, Me.FocusModeToolStripMenuItem, Me.SceneModeToolStripMenuItem, Me.EffectsToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(140, 92)
        '
        'FlashModeToolStripMenuItem
        '
        Me.FlashModeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AutoToolStripMenuItem, Me.ONToolStripMenuItem, Me.OFFToolStripMenuItem})
        Me.FlashModeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.FlashModeToolStripMenuItem.Name = "FlashModeToolStripMenuItem"
        Me.FlashModeToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.FlashModeToolStripMenuItem.Text = "Flash Mode"
        '
        'AutoToolStripMenuItem
        '
        Me.AutoToolStripMenuItem.Name = "AutoToolStripMenuItem"
        Me.AutoToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.AutoToolStripMenuItem.Text = "Auto"
        '
        'ONToolStripMenuItem
        '
        Me.ONToolStripMenuItem.Name = "ONToolStripMenuItem"
        Me.ONToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.ONToolStripMenuItem.Text = "ON"
        '
        'OFFToolStripMenuItem
        '
        Me.OFFToolStripMenuItem.Checked = True
        Me.OFFToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.OFFToolStripMenuItem.Name = "OFFToolStripMenuItem"
        Me.OFFToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.OFFToolStripMenuItem.Text = "OFF"
        '
        'FocusModeToolStripMenuItem
        '
        Me.FocusModeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AutoToolStripMenuItem1, Me.EdofToolStripMenuItem, Me.FixedToolStripMenuItem})
        Me.FocusModeToolStripMenuItem.Name = "FocusModeToolStripMenuItem"
        Me.FocusModeToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.FocusModeToolStripMenuItem.Text = "Focus Mode"
        '
        'AutoToolStripMenuItem1
        '
        Me.AutoToolStripMenuItem1.Name = "AutoToolStripMenuItem1"
        Me.AutoToolStripMenuItem1.Size = New System.Drawing.Size(101, 22)
        Me.AutoToolStripMenuItem1.Text = "Auto"
        '
        'EdofToolStripMenuItem
        '
        Me.EdofToolStripMenuItem.Name = "EdofToolStripMenuItem"
        Me.EdofToolStripMenuItem.Size = New System.Drawing.Size(101, 22)
        Me.EdofToolStripMenuItem.Text = "Edof"
        '
        'FixedToolStripMenuItem
        '
        Me.FixedToolStripMenuItem.Name = "FixedToolStripMenuItem"
        Me.FixedToolStripMenuItem.Size = New System.Drawing.Size(101, 22)
        Me.FixedToolStripMenuItem.Text = "Fixed"
        '
        'SceneModeToolStripMenuItem
        '
        Me.SceneModeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AutoToolStripMenuItem2, Me.NightToolStripMenuItem, Me.SportsToolStripMenuItem, Me.PartyToolStripMenuItem})
        Me.SceneModeToolStripMenuItem.Name = "SceneModeToolStripMenuItem"
        Me.SceneModeToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.SceneModeToolStripMenuItem.Text = "Scene Mode"
        '
        'AutoToolStripMenuItem2
        '
        Me.AutoToolStripMenuItem2.Name = "AutoToolStripMenuItem2"
        Me.AutoToolStripMenuItem2.Size = New System.Drawing.Size(107, 22)
        Me.AutoToolStripMenuItem2.Text = "Auto"
        '
        'NightToolStripMenuItem
        '
        Me.NightToolStripMenuItem.Name = "NightToolStripMenuItem"
        Me.NightToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.NightToolStripMenuItem.Text = "Night"
        '
        'SportsToolStripMenuItem
        '
        Me.SportsToolStripMenuItem.Name = "SportsToolStripMenuItem"
        Me.SportsToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.SportsToolStripMenuItem.Text = "Sports"
        '
        'PartyToolStripMenuItem
        '
        Me.PartyToolStripMenuItem.Name = "PartyToolStripMenuItem"
        Me.PartyToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.PartyToolStripMenuItem.Text = "Party"
        '
        'EffectsToolStripMenuItem
        '
        Me.EffectsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EFFECTNONEToolStripMenuItem, Me.EFFECTNEGATIVEToolStripMenuItem, Me.EFFECTAQUAToolStripMenuItem, Me.EFFECTBLACKBOARDToolStripMenuItem, Me.EFFECTMONOToolStripMenuItem, Me.EFFECTPOSTERIZEToolStripMenuItem, Me.EFFECTSEPIAToolStripMenuItem, Me.EFFECTWHITEBOARDToolStripMenuItem})
        Me.EffectsToolStripMenuItem.Name = "EffectsToolStripMenuItem"
        Me.EffectsToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.EffectsToolStripMenuItem.Text = "Effects"
        '
        'EFFECTNONEToolStripMenuItem
        '
        Me.EFFECTNONEToolStripMenuItem.Checked = True
        Me.EFFECTNONEToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.EFFECTNONEToolStripMenuItem.Name = "EFFECTNONEToolStripMenuItem"
        Me.EFFECTNONEToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.EFFECTNONEToolStripMenuItem.Text = "EFFECT NONE"
        '
        'EFFECTNEGATIVEToolStripMenuItem
        '
        Me.EFFECTNEGATIVEToolStripMenuItem.Name = "EFFECTNEGATIVEToolStripMenuItem"
        Me.EFFECTNEGATIVEToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.EFFECTNEGATIVEToolStripMenuItem.Text = "EFFECT NEGATIVE"
        '
        'EFFECTAQUAToolStripMenuItem
        '
        Me.EFFECTAQUAToolStripMenuItem.Name = "EFFECTAQUAToolStripMenuItem"
        Me.EFFECTAQUAToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.EFFECTAQUAToolStripMenuItem.Text = "EFFECT AQUA"
        '
        'EFFECTBLACKBOARDToolStripMenuItem
        '
        Me.EFFECTBLACKBOARDToolStripMenuItem.Name = "EFFECTBLACKBOARDToolStripMenuItem"
        Me.EFFECTBLACKBOARDToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.EFFECTBLACKBOARDToolStripMenuItem.Text = "EFFECT BLACKBOARD"
        '
        'EFFECTMONOToolStripMenuItem
        '
        Me.EFFECTMONOToolStripMenuItem.Name = "EFFECTMONOToolStripMenuItem"
        Me.EFFECTMONOToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.EFFECTMONOToolStripMenuItem.Text = "EFFECT MONO"
        '
        'EFFECTPOSTERIZEToolStripMenuItem
        '
        Me.EFFECTPOSTERIZEToolStripMenuItem.Name = "EFFECTPOSTERIZEToolStripMenuItem"
        Me.EFFECTPOSTERIZEToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.EFFECTPOSTERIZEToolStripMenuItem.Text = "EFFECT POSTERIZE"
        '
        'EFFECTSEPIAToolStripMenuItem
        '
        Me.EFFECTSEPIAToolStripMenuItem.Name = "EFFECTSEPIAToolStripMenuItem"
        Me.EFFECTSEPIAToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.EFFECTSEPIAToolStripMenuItem.Text = "EFFECT SEPIA"
        '
        'EFFECTWHITEBOARDToolStripMenuItem
        '
        Me.EFFECTWHITEBOARDToolStripMenuItem.Name = "EFFECTWHITEBOARDToolStripMenuItem"
        Me.EFFECTWHITEBOARDToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.EFFECTWHITEBOARDToolStripMenuItem.Text = "EFFECT WHITEBOARD"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Please Wait..."
        Me.Label4.Visible = False
        '
        'Camera_Manager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(432, 277)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.MinimumSize = New System.Drawing.Size(387, 316)
        Me.Name = "Camera_Manager"
        Me.Tag = "Control_Hack"
        Me.Text = "Camera Manager"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.L1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents L1 As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents FlashModeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AutoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ONToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OFFToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label4 As Label
    Friend WithEvents FocusModeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AutoToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents EdofToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FixedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SceneModeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AutoToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents NightToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SportsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PartyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EffectsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EFFECTNONEToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EFFECTNEGATIVEToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EFFECTAQUAToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EFFECTBLACKBOARDToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EFFECTMONOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EFFECTPOSTERIZEToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EFFECTSEPIAToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EFFECTWHITEBOARDToolStripMenuItem As ToolStripMenuItem
End Class
