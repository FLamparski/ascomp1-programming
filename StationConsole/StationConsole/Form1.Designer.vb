<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ten_HostnameDisplay = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.textview_Messages = New System.Windows.Forms.RichTextBox()
        Me.tb_ServerStartStop = New System.Windows.Forms.ToolStripButton()
        Me.tb_ShowLogWindow = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ten_HostnameDisplay, Me.ToolStripSeparator1, Me.tb_ServerStartStop, Me.tb_ShowLogWindow, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(613, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(128, 22)
        Me.ToolStripLabel1.Text = "Computer's hostname:"
        '
        'ten_HostnameDisplay
        '
        Me.ten_HostnameDisplay.Name = "ten_HostnameDisplay"
        Me.ten_HostnameDisplay.ReadOnly = True
        Me.ten_HostnameDisplay.Size = New System.Drawing.Size(100, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'textview_Messages
        '
        Me.textview_Messages.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.textview_Messages.Location = New System.Drawing.Point(0, 384)
        Me.textview_Messages.Name = "textview_Messages"
        Me.textview_Messages.ReadOnly = True
        Me.textview_Messages.Size = New System.Drawing.Size(613, 137)
        Me.textview_Messages.TabIndex = 2
        Me.textview_Messages.Text = ""
        Me.textview_Messages.Visible = False
        '
        'tb_ServerStartStop
        '
        Me.tb_ServerStartStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tb_ServerStartStop.Image = Global.StationConsole.My.Resources.Resources.glyphicons_173_play
        Me.tb_ServerStartStop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tb_ServerStartStop.Name = "tb_ServerStartStop"
        Me.tb_ServerStartStop.Size = New System.Drawing.Size(23, 22)
        Me.tb_ServerStartStop.Text = "Start server"
        '
        'tb_ShowLogWindow
        '
        Me.tb_ShowLogWindow.CheckOnClick = True
        Me.tb_ShowLogWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tb_ShowLogWindow.Image = Global.StationConsole.My.Resources.Resources.glyphicons_087_log_book
        Me.tb_ShowLogWindow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tb_ShowLogWindow.Name = "tb_ShowLogWindow"
        Me.tb_ShowLogWindow.Size = New System.Drawing.Size(23, 22)
        Me.tb_ShowLogWindow.Text = "View messages"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.StationConsole.My.Resources.Resources.glyphicons_228_gbp
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Set price..."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(613, 521)
        Me.Controls.Add(Me.textview_Messages)
        Me.Controls.Add(Me.ToolStrip1)
        Me.IsMdiContainer = True
        Me.Name = "Form1"
        Me.Text = "Station console on "
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ten_HostnameDisplay As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tb_ServerStartStop As System.Windows.Forms.ToolStripButton
    Friend WithEvents tb_ShowLogWindow As System.Windows.Forms.ToolStripButton
    Friend WithEvents textview_Messages As System.Windows.Forms.RichTextBox
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton

End Class
