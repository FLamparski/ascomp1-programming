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
        Me.btn_convertFtoC = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.en_CelsiusValue = New System.Windows.Forms.TextBox()
        Me.en_FahrenheitValue = New System.Windows.Forms.TextBox()
        Me.btn_convertCtoF = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btn_convertFtoC
        '
        Me.btn_convertFtoC.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_convertFtoC.Location = New System.Drawing.Point(226, 55)
        Me.btn_convertFtoC.Name = "btn_convertFtoC"
        Me.btn_convertFtoC.Size = New System.Drawing.Size(75, 23)
        Me.btn_convertFtoC.TabIndex = 11
        Me.btn_convertFtoC.Text = "Convert"
        Me.btn_convertFtoC.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Fahrenheit"
        '
        'en_CelsiusValue
        '
        Me.en_CelsiusValue.BackColor = System.Drawing.SystemColors.Window
        Me.en_CelsiusValue.Location = New System.Drawing.Point(98, 16)
        Me.en_CelsiusValue.Name = "en_CelsiusValue"
        Me.en_CelsiusValue.Size = New System.Drawing.Size(122, 20)
        Me.en_CelsiusValue.TabIndex = 8
        '
        'en_FahrenheitValue
        '
        Me.en_FahrenheitValue.Location = New System.Drawing.Point(98, 57)
        Me.en_FahrenheitValue.Name = "en_FahrenheitValue"
        Me.en_FahrenheitValue.Size = New System.Drawing.Size(122, 20)
        Me.en_FahrenheitValue.TabIndex = 9
        '
        'btn_convertCtoF
        '
        Me.btn_convertCtoF.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_convertCtoF.Location = New System.Drawing.Point(226, 14)
        Me.btn_convertCtoF.Name = "btn_convertCtoF"
        Me.btn_convertCtoF.Size = New System.Drawing.Size(75, 23)
        Me.btn_convertCtoF.TabIndex = 10
        Me.btn_convertCtoF.Text = "Convert"
        Me.btn_convertCtoF.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Celsius"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(316, 102)
        Me.Controls.Add(Me.btn_convertFtoC)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.en_CelsiusValue)
        Me.Controls.Add(Me.en_FahrenheitValue)
        Me.Controls.Add(Me.btn_convertCtoF)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Celsius to Fahrenheit converter"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_convertFtoC As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents en_CelsiusValue As System.Windows.Forms.TextBox
    Friend WithEvents en_FahrenheitValue As System.Windows.Forms.TextBox
    Friend WithEvents btn_convertCtoF As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
