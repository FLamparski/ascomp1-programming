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
        Me.components = New System.ComponentModel.Container()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("GMT +0 (London)")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("GMT +1 (Paris)")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("GMT +3 (Moscow)")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("GMT -5 (New York)")
        Me.clockTick = New System.Windows.Forms.Timer(Me.components)
        Me.lbl_TimeDisplay = New System.Windows.Forms.Label()
        Me.check_24h = New System.Windows.Forms.CheckBox()
        Me.tz_list = New System.Windows.Forms.TreeView()
        Me.AnalogueClock1 = New TravelClock.AnalogueClock()
        Me.SuspendLayout()
        '
        'clockTick
        '
        Me.clockTick.Enabled = True
        Me.clockTick.Interval = 1000
        '
        'lbl_TimeDisplay
        '
        Me.lbl_TimeDisplay.AutoSize = True
        Me.lbl_TimeDisplay.Font = New System.Drawing.Font("OCR A Extended", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TimeDisplay.Location = New System.Drawing.Point(217, 292)
        Me.lbl_TimeDisplay.Name = "lbl_TimeDisplay"
        Me.lbl_TimeDisplay.Size = New System.Drawing.Size(164, 23)
        Me.lbl_TimeDisplay.TabIndex = 3
        Me.lbl_TimeDisplay.Text = "00:00:00 am"
        '
        'check_24h
        '
        Me.check_24h.AutoSize = True
        Me.check_24h.Checked = True
        Me.check_24h.CheckState = System.Windows.Forms.CheckState.Checked
        Me.check_24h.Location = New System.Drawing.Point(283, 333)
        Me.check_24h.Name = "check_24h"
        Me.check_24h.Size = New System.Drawing.Size(98, 17)
        Me.check_24h.TabIndex = 4
        Me.check_24h.Text = "Use 24h format"
        Me.check_24h.UseVisualStyleBackColor = True
        '
        'tz_list
        '
        Me.tz_list.Location = New System.Drawing.Point(13, 13)
        Me.tz_list.Name = "tz_list"
        TreeNode1.Name = "tzlondon"
        TreeNode1.Tag = "0"
        TreeNode1.Text = "GMT +0 (London)"
        TreeNode2.Name = "tzparis"
        TreeNode2.Tag = "1"
        TreeNode2.Text = "GMT +1 (Paris)"
        TreeNode3.Name = "tzmoscow"
        TreeNode3.Tag = "3"
        TreeNode3.Text = "GMT +3 (Moscow)"
        TreeNode4.Name = "tzny"
        TreeNode4.Tag = "-5"
        TreeNode4.Text = "GMT -5 (New York)"
        Me.tz_list.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4})
        Me.tz_list.Size = New System.Drawing.Size(142, 337)
        Me.tz_list.TabIndex = 5
        '
        'AnalogueClock1
        '
        Me.AnalogueClock1.Location = New System.Drawing.Point(172, 13)
        Me.AnalogueClock1.Name = "AnalogueClock1"
        Me.AnalogueClock1.Size = New System.Drawing.Size(256, 256)
        Me.AnalogueClock1.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 362)
        Me.Controls.Add(Me.tz_list)
        Me.Controls.Add(Me.check_24h)
        Me.Controls.Add(Me.lbl_TimeDisplay)
        Me.Controls.Add(Me.AnalogueClock1)
        Me.Name = "Form1"
        Me.Text = "Travel Clock"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents clockTick As System.Windows.Forms.Timer
    Friend WithEvents AnalogueClock1 As TravelClock.AnalogueClock
    Friend WithEvents lbl_TimeDisplay As System.Windows.Forms.Label
    Friend WithEvents check_24h As System.Windows.Forms.CheckBox
    Friend WithEvents tz_list As System.Windows.Forms.TreeView

End Class
