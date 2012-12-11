<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PumpForm
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.en_Litres = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.en_TotalSale = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.en_Price = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.en_IsPumping = New System.Windows.Forms.TextBox()
        Me.btn_ResetPump = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Litres:"
        '
        'en_Litres
        '
        Me.en_Litres.Location = New System.Drawing.Point(75, 10)
        Me.en_Litres.Name = "en_Litres"
        Me.en_Litres.ReadOnly = True
        Me.en_Litres.Size = New System.Drawing.Size(135, 20)
        Me.en_Litres.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Total sale:"
        '
        'en_TotalSale
        '
        Me.en_TotalSale.Location = New System.Drawing.Point(75, 37)
        Me.en_TotalSale.Name = "en_TotalSale"
        Me.en_TotalSale.ReadOnly = True
        Me.en_TotalSale.Size = New System.Drawing.Size(135, 20)
        Me.en_TotalSale.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Price:"
        '
        'en_Price
        '
        Me.en_Price.Location = New System.Drawing.Point(75, 63)
        Me.en_Price.Name = "en_Price"
        Me.en_Price.ReadOnly = True
        Me.en_Price.Size = New System.Drawing.Size(70, 20)
        Me.en_Price.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Pumping:"
        '
        'en_IsPumping
        '
        Me.en_IsPumping.BackColor = System.Drawing.Color.LightCoral
        Me.en_IsPumping.Location = New System.Drawing.Point(75, 106)
        Me.en_IsPumping.Name = "en_IsPumping"
        Me.en_IsPumping.Size = New System.Drawing.Size(70, 20)
        Me.en_IsPumping.TabIndex = 7
        Me.en_IsPumping.Text = "NO"
        Me.en_IsPumping.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn_ResetPump
        '
        Me.btn_ResetPump.Location = New System.Drawing.Point(75, 132)
        Me.btn_ResetPump.Name = "btn_ResetPump"
        Me.btn_ResetPump.Size = New System.Drawing.Size(135, 23)
        Me.btn_ResetPump.TabIndex = 8
        Me.btn_ResetPump.Text = "Reset pump"
        Me.btn_ResetPump.UseVisualStyleBackColor = True
        '
        'PumpForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(225, 167)
        Me.Controls.Add(Me.btn_ResetPump)
        Me.Controls.Add(Me.en_IsPumping)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.en_Price)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.en_TotalSale)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.en_Litres)
        Me.Controls.Add(Me.Label1)
        Me.Name = "PumpForm"
        Me.Text = "PumpForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents en_Litres As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents en_TotalSale As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents en_Price As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents en_IsPumping As System.Windows.Forms.TextBox
    Friend WithEvents btn_ResetPump As System.Windows.Forms.Button
End Class
