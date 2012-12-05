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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.en_DigitEntry = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.hundredsDigit = New _7Seg_Two_Digits.SevenSegDigit()
        Me.onesDigit = New _7Seg_Two_Digits.SevenSegDigit()
        Me.tensDigit = New _7Seg_Two_Digits.SevenSegDigit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.hundredsDigit)
        Me.Panel1.Controls.Add(Me.onesDigit)
        Me.Panel1.Controls.Add(Me.tensDigit)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(323, 178)
        Me.Panel1.TabIndex = 0
        '
        'en_DigitEntry
        '
        Me.en_DigitEntry.Location = New System.Drawing.Point(104, 218)
        Me.en_DigitEntry.MaxLength = 5
        Me.en_DigitEntry.Name = "en_DigitEntry"
        Me.en_DigitEntry.Size = New System.Drawing.Size(49, 20)
        Me.en_DigitEntry.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button1.Location = New System.Drawing.Point(159, 216)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Set Number"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'hundredsDigit
        '
        Me.hundredsDigit.Digit = 0
        Me.hundredsDigit.ForeColor = System.Drawing.Color.Green
        Me.hundredsDigit.Location = New System.Drawing.Point(26, 4)
        Me.hundredsDigit.Name = "hundredsDigit"
        Me.hundredsDigit.Size = New System.Drawing.Size(94, 167)
        Me.hundredsDigit.TabIndex = 2
        Me.hundredsDigit.Visible = False
        '
        'onesDigit
        '
        Me.onesDigit.Digit = 0
        Me.onesDigit.ForeColor = System.Drawing.Color.Green
        Me.onesDigit.Location = New System.Drawing.Point(226, 4)
        Me.onesDigit.Name = "onesDigit"
        Me.onesDigit.Size = New System.Drawing.Size(94, 167)
        Me.onesDigit.TabIndex = 1
        '
        'tensDigit
        '
        Me.tensDigit.Digit = 0
        Me.tensDigit.ForeColor = System.Drawing.Color.Green
        Me.tensDigit.Location = New System.Drawing.Point(126, 4)
        Me.tensDigit.Name = "tensDigit"
        Me.tensDigit.Size = New System.Drawing.Size(94, 167)
        Me.tensDigit.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(347, 281)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.en_DigitEntry)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.Text = "Two digits"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents en_DigitEntry As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents onesDigit As _7Seg_Two_Digits.SevenSegDigit
    Friend WithEvents tensDigit As _7Seg_Two_Digits.SevenSegDigit
    Friend WithEvents hundredsDigit As _7Seg_Two_Digits.SevenSegDigit

End Class
