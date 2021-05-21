Public Class Theme_0
    Inherits System.Windows.Forms.ToolStripSystemRenderer
    Dim selcted_0 As Color = Color.FromArgb(47, 149, 200)
    Dim backColor_0 As Color = Color.FromArgb(236, 239, 241)
    Dim ForeColor_0 As Color = Color.FromArgb(68, 85, 93)
    Dim backColor_0_u_d As Color = Color.FromArgb(90, 111, 123)
    Dim MyFont As Font = New Font("Arial", 8.25, FontStyle.Bold)
    Public clrMBButtonDarkBorder As Color = Color.SteelBlue
    Dim clrSelectedBorder As Color = Color.SteelBlue

    Dim vbx As Color = Color.FromArgb(79, 89, 99)

    Public clrCheckBG As Color = Color.FromArgb(60, 60, 60, 60)
    Public Sub DrawRoundedRectangle(ByVal objGraphics As Graphics,
                                ByVal m_intxAxis As Integer,
                                ByVal m_intyAxis As Integer,
                                ByVal m_intWidth As Integer,
                                ByVal m_intHeight As Integer,
                                ByVal m_diameter As Integer, ByVal color As Color)
        Try
            Dim pen As New Pen(color)
            'Dim g As Graphics
            Dim BaseRect As New RectangleF(m_intxAxis, m_intyAxis, m_intWidth, m_intHeight)
            Dim ArcRect As New RectangleF(BaseRect.Location, New SizeF(m_diameter, m_diameter))
            'top left Arc
            objGraphics.DrawArc(pen, ArcRect, 180, 90)
            objGraphics.DrawLine(pen, m_intxAxis + CInt(m_diameter / 2), m_intyAxis, m_intxAxis + m_intWidth - CInt(m_diameter / 2), m_intyAxis)
            ' top right arc
            ArcRect.X = BaseRect.Right - m_diameter
            objGraphics.DrawArc(pen, ArcRect, 270, 90)
            objGraphics.DrawLine(pen, m_intxAxis + m_intWidth, m_intyAxis + CInt(m_diameter / 2), m_intxAxis + m_intWidth, m_intyAxis + m_intHeight - CInt(m_diameter / 2))
            ' bottom right arc
            ArcRect.Y = BaseRect.Bottom - m_diameter
            objGraphics.DrawArc(pen, ArcRect, 0, 90)
            objGraphics.DrawLine(pen, m_intxAxis + CInt(m_diameter / 2), m_intyAxis + m_intHeight, m_intxAxis + m_intWidth - CInt(m_diameter / 2), m_intyAxis + m_intHeight)
            ' bottom left arc
            ArcRect.X = BaseRect.Left
            objGraphics.DrawArc(pen, ArcRect, 90, 90)
            objGraphics.DrawLine(pen, m_intxAxis, m_intyAxis + CInt(m_diameter / 2), m_intxAxis, m_intyAxis + m_intHeight - CInt(m_diameter / 2))
        Catch ex As Exception
        End Try
    End Sub
    Protected Overrides Sub Initialize(ByVal toolStrip As System.Windows.Forms.ToolStrip)
        Try
            MyBase.Initialize(toolStrip)
            If TypeOf toolStrip Is MenuStrip Then
                toolStrip.ForeColor = ForeColor_0
            ElseIf TypeOf toolStrip Is ToolStripDropDownMenu Then
                toolStrip.ForeColor = ForeColor_0
                toolStrip.BackColor = backColor_0
            ElseIf TypeOf toolStrip Is ToolStrip Then
                toolStrip.ForeColor = ForeColor_0
                toolStrip.BackColor = backColor_0
            End If
            toolStrip.Font = MyFont
            toolStrip.Padding = New Padding(5, 2, 5, 2)
        Catch ex As Exception
        End Try

    End Sub
    Protected Overrides Sub OnRenderMenuItemBackground(ByVal e As System.Windows.Forms.ToolStripItemRenderEventArgs)
        Try
            If TypeOf e.ToolStrip Is ToolStripDropDownMenu Then
                If e.Item.Selected Then
                    Dim i8 As Integer = 4
                    Dim i9 As Integer = 6
                    If Not e.Item.Image Is Nothing Then
                        i8 = 30
                        i9 = 32
                    End If
                    Dim clrSelectGradTop As Color
                    Dim clrSelectGradBottom As Color
                    Dim clrMenuBorder As Color
                    If Not e.Item.Enabled = True Then
                        clrSelectGradTop = e.Item.BackColor
                        clrSelectGradBottom = e.Item.BackColor
                        clrMenuBorder = e.Item.BackColor
                    Else
                        clrSelectGradTop = selcted_0
                        clrSelectGradBottom = selcted_0
                        clrMenuBorder = selcted_0
                    End If
                    Dim rect As New Rectangle(i8, 2, e.Item.Width - i9, e.Item.Height - 4)
                    Dim b As New Drawing2D.LinearGradientBrush(rect, clrSelectGradTop, clrSelectGradBottom, Drawing2D.LinearGradientMode.Vertical)
                    e.Graphics.FillRectangle(b, rect)
                    DrawRoundedRectangle(e.Graphics, rect.Left - 1, rect.Top - 1, rect.Width, rect.Height + 1, 1, clrSelectedBorder)
                    e.Item.ForeColor = System.Drawing.Color.White
                Else
                    e.Item.ForeColor = ForeColor_0
                End If
            ElseIf (TypeOf e.ToolStrip Is MenuStrip) Then
                If e.Item.IsOnDropDown = False AndAlso e.Item.Selected Then
                    Dim i8 As Integer = 4
                    Dim i9 As Integer = 6
                    If Not e.Item.Image Is Nothing Then
                        i8 = 22
                        i9 = 30
                    End If

                    Dim rect As New Rectangle(i8, 2, e.Item.Width - i9, e.Item.Height - 4)
                    Dim rect2 As New Rectangle(i8, 2, e.Item.Width - i9, e.Item.Height - 4)
                    Dim b2 As New SolidBrush(If(e.Item.Tag = "u-d", backColor_0_u_d, If(e.Item.Enabled = False, SystemColors.Control, selcted_0)))
                    DrawRoundedRectangle(e.Graphics, rect.Left - 1, rect.Top - 1, rect.Width + 1, rect.Height + 1, 1, If(e.Item.Tag = "u-d", vbx, clrMBButtonDarkBorder))
                    e.Graphics.FillRectangle(b2, rect2)
                    e.Item.ForeColor = System.Drawing.Color.White
                Else
                    e.Item.ForeColor = ForeColor_0
                End If

            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Overrides Sub OnRenderArrow(ByVal e As System.Windows.Forms.ToolStripArrowRenderEventArgs)
        Try
            If e.Item.Selected Then
                e.ArrowColor = backColor_0
            Else
                e.ArrowColor = ForeColor_0
            End If
            MyBase.OnRenderArrow(e)
        Catch ex As Exception
        End Try
    End Sub
    Protected Overrides Sub OnRenderItemCheck(ByVal e As System.Windows.Forms.ToolStripItemImageRenderEventArgs)
        Try
            MyBase.OnRenderItemCheck(e)
            Dim rect2 As New Rectangle(4, 2, e.Item.Height - 3, e.Item.Height - 4)
            Dim b2 As New Drawing.SolidBrush(clrCheckBG)
            e.Graphics.FillRectangle(b2, rect2)
            e.Graphics.DrawImage(e.Image, New System.Drawing.Point(5, 3))

        Catch ex As Exception
        End Try
    End Sub
    Protected Overrides Sub OnRenderImageMargin(ByVal e As System.Windows.Forms.ToolStripRenderEventArgs)
        Try
            MyBase.OnRenderImageMargin(e)
            Dim clrMenuBorder As Color = selcted_0
            Dim WhiteLine As New Drawing.SolidBrush(System.Drawing.Color.Silver)
            Dim rect2 As New Rectangle(e.AffectedBounds.Width + 0, 2, 1, e.AffectedBounds.Height)
            Dim borderPen As New Pen(clrMenuBorder)
            e.Graphics.FillRectangle(WhiteLine, rect2)
            e.ToolStrip.BackColor = backColor_0
        Catch ex As Exception
        End Try
    End Sub

End Class