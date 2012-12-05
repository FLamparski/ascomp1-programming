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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.en_textIn = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.en_textOut = New System.Windows.Forms.TextBox()
        Me.btn_Cipher = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(147, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enter text to decode/encode:"
        '
        'en_textIn
        '
        Me.en_textIn.Location = New System.Drawing.Point(16, 30)
        Me.en_textIn.Name = "en_textIn"
        Me.en_textIn.Size = New System.Drawing.Size(256, 20)
        Me.en_textIn.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Output text will appear below:"
        '
        'en_textOut
        '
        Me.en_textOut.Location = New System.Drawing.Point(16, 81)
        Me.en_textOut.Name = "en_textOut"
        Me.en_textOut.ReadOnly = True
        Me.en_textOut.Size = New System.Drawing.Size(256, 20)
        Me.en_textOut.TabIndex = 3
        '
        'btn_Cipher
        '
        Me.btn_Cipher.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_Cipher.Location = New System.Drawing.Point(177, 125)
        Me.btn_Cipher.Name = "btn_Cipher"
        Me.btn_Cipher.Size = New System.Drawing.Size(94, 23)
        Me.btn_Cipher.TabIndex = 4
        Me.btn_Cipher.Text = "Encode/decode"
        Me.btn_Cipher.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 156)
        Me.Controls.Add(Me.btn_Cipher)
        Me.Controls.Add(Me.en_textOut)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.en_textIn)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Enigma"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents en_textIn As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents en_textOut As System.Windows.Forms.TextBox
    Friend WithEvents btn_Cipher As System.Windows.Forms.Button

End Class
