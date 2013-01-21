Public Class AnalogueClock
    Dim dateTime As Date
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        ' Enable anti-aliasing so that the clock looks better
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        Dim h = e.ClipRectangle.Height
        Dim w = e.ClipRectangle.Width
        Dim diameter As Single = h * 0.9
        Dim radius As Single = diameter / 2
        Dim line_width As Single = h / 100 * 3

        Dim cx As Single = w / 2
        Dim cy As Single = h / 2

        ' Draw the clock face - A white circle with a black border
        Dim clockBorderPen As Pen = New Pen(Brushes.Black, line_width)
        Dim clockFill As Brush = New SolidBrush(Color.FromArgb(240, 255, 255, 255))

        e.Graphics.FillEllipse(clockFill, New Rectangle(w * 0.05, h * 0.05, diameter, diameter))
        e.Graphics.DrawEllipse(clockBorderPen, New Rectangle(w * 0.05, h * 0.05, diameter, diameter))

        ' Clock ticks
        For i As Integer = 0 To 12
            Dim inset As Single = line_width * 2
            Dim clockMarkPen As Pen = New Pen(Brushes.Black, line_width)
            If i Mod 3 <> 0 Then
                inset *= 0.8
                clockMarkPen.Width = line_width * 0.4
            End If
            Dim insetd = radius - inset
            Dim angleR As Double = i * Math.PI / 6
            Dim startpf = New PointF(cx + insetd * Math.Cos(angleR),
                                     cy + insetd * Math.Sin(angleR))
            Dim endpf = New PointF(cx + radius * Math.Cos(angleR),
                                   cy + radius * Math.Sin(angleR))
            e.Graphics.DrawLine(clockMarkPen, startpf, endpf)
        Next

        ' Calculate the angle, in radians, of the clock indicators
        Dim hrs As Single = dateTime.Hour * Math.PI / 6
        Dim mins As Single = dateTime.Minute * Math.PI / 30
        Dim secs As Single = dateTime.Second * Math.PI / 30

        Dim hrsPen As Pen = New Pen(Brushes.Blue, line_width * 0.8)
        Dim minsPen As Pen = New Pen(Brushes.Blue, line_width * 0.6)
        Dim secsPen As Pen = New Pen(Brushes.Red, line_width * 0.3)

        ' Draw the clock indicators
        Dim clock_centre = New PointF(cx, cy)
        Dim hrs_epf = New PointF(cx + (radius - line_width * 3) / 2 * Math.Sin(hrs + mins / 12),
                                 cy + (radius - line_width * 3) / 2 * -Math.Cos(hrs + mins / 12))
        Dim mins_epf = New PointF(cx + (radius - line_width * 3) * Math.Sin(mins + secs / 60),
                                  cy + (radius - line_width * 3) * -Math.Cos(mins + secs / 60))
        Dim secs_epf = New PointF(cx + (radius - line_width * 3) * Math.Sin(secs),
                                  cy + (radius - line_width * 3) * -Math.Cos(secs))
        e.Graphics.DrawLine(hrsPen, clock_centre, hrs_epf)
        e.Graphics.DrawLine(minsPen, clock_centre, mins_epf)
        e.Graphics.DrawLine(secsPen, clock_centre, secs_epf)
    End Sub

    ''' <summary>
    ''' Set the time to be displayed by the clock control. This also redraws the clock.
    ''' </summary>
    ''' <param name="dt">A Date object with target time</param>
    ''' <remarks></remarks>
    Public Sub SetTime(ByRef dt As Date)
        dateTime = dt
        Me.Refresh()
    End Sub
End Class
