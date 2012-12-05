<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SevenSegDigit
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.VSegmentLeftBottom = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.HSegmentBottom = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.VSegmentRightBottom = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.VSegmentRightTop = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.VSegmentLeftTop = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.HSegmentMiddle = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.HSegmentTop = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.VSegmentLeftBottom, Me.HSegmentBottom, Me.VSegmentRightBottom, Me.VSegmentRightTop, Me.VSegmentLeftTop, Me.HSegmentMiddle, Me.HSegmentTop})
        Me.ShapeContainer1.Size = New System.Drawing.Size(51, 94)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'VSegmentLeftBottom
        '
        Me.VSegmentLeftBottom.BackColor = System.Drawing.Color.Lime
        Me.VSegmentLeftBottom.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.VSegmentLeftBottom.Location = New System.Drawing.Point(4, 51)
        Me.VSegmentLeftBottom.Name = "VSegmentLeftBottom"
        Me.VSegmentLeftBottom.Size = New System.Drawing.Size(4, 32)
        '
        'HSegmentBottom
        '
        Me.HSegmentBottom.BackColor = System.Drawing.Color.Lime
        Me.HSegmentBottom.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.HSegmentBottom.Location = New System.Drawing.Point(9, 84)
        Me.HSegmentBottom.Name = "HSegmentBottom"
        Me.HSegmentBottom.Size = New System.Drawing.Size(32, 4)
        '
        'VSegmentRightBottom
        '
        Me.VSegmentRightBottom.BackColor = System.Drawing.Color.Lime
        Me.VSegmentRightBottom.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.VSegmentRightBottom.Location = New System.Drawing.Point(42, 50)
        Me.VSegmentRightBottom.Name = "VSegmentRightBottom"
        Me.VSegmentRightBottom.Size = New System.Drawing.Size(4, 32)
        '
        'VSegmentRightTop
        '
        Me.VSegmentRightTop.BackColor = System.Drawing.Color.Lime
        Me.VSegmentRightTop.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.VSegmentRightTop.Location = New System.Drawing.Point(42, 11)
        Me.VSegmentRightTop.Name = "VSegmentRightTop"
        Me.VSegmentRightTop.Size = New System.Drawing.Size(4, 32)
        '
        'VSegmentLeftTop
        '
        Me.VSegmentLeftTop.BackColor = System.Drawing.Color.Lime
        Me.VSegmentLeftTop.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.VSegmentLeftTop.Location = New System.Drawing.Point(4, 12)
        Me.VSegmentLeftTop.Name = "VSegmentLeftTop"
        Me.VSegmentLeftTop.Size = New System.Drawing.Size(4, 32)
        '
        'HSegmentMiddle
        '
        Me.HSegmentMiddle.BackColor = System.Drawing.Color.Lime
        Me.HSegmentMiddle.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.HSegmentMiddle.Location = New System.Drawing.Point(9, 45)
        Me.HSegmentMiddle.Name = "HSegmentMiddle"
        Me.HSegmentMiddle.Size = New System.Drawing.Size(32, 4)
        '
        'HSegmentTop
        '
        Me.HSegmentTop.BackColor = System.Drawing.Color.Lime
        Me.HSegmentTop.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.HSegmentTop.Location = New System.Drawing.Point(9, 6)
        Me.HSegmentTop.Name = "HSegmentTop"
        Me.HSegmentTop.Size = New System.Drawing.Size(32, 4)
        '
        'SevenSegDigit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ShapeContainer1)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.Green
        Me.Name = "SevenSegDigit"
        Me.Size = New System.Drawing.Size(51, 94)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents HSegmentTop As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents VSegmentLeftTop As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents HSegmentMiddle As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents VSegmentLeftBottom As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents HSegmentBottom As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents VSegmentRightBottom As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents VSegmentRightTop As Microsoft.VisualBasic.PowerPacks.RectangleShape

End Class
