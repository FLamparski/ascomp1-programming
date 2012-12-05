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
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape3 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbl_Status = New System.Windows.Forms.Label()
        Me.en_ConsoleHost = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btn_Pump = New System.Windows.Forms.Button()
        Me.btn_Connect = New System.Windows.Forms.Button()
        Me.ss_price_hundreds = New FuelPump.SevenSegDigit()
        Me.ss_price_tens = New FuelPump.SevenSegDigit()
        Me.ss_price_ones = New FuelPump.SevenSegDigit()
        Me.ss_price_decimal = New FuelPump.SevenSegDigit()
        Me.ss_pumped_hundreds = New FuelPump.SevenSegDigit()
        Me.ss_pumped_tens = New FuelPump.SevenSegDigit()
        Me.ss_pumped_ones = New FuelPump.SevenSegDigit()
        Me.ss_pumped_decimal = New FuelPump.SevenSegDigit()
        Me.ss_pumped_hundredth = New FuelPump.SevenSegDigit()
        Me.ss_totalprice_hundreds = New FuelPump.SevenSegDigit()
        Me.ss_totalprice_tens = New FuelPump.SevenSegDigit()
        Me.ss_totalprice_ones = New FuelPump.SevenSegDigit()
        Me.ss_totalprice_decimal = New FuelPump.SevenSegDigit()
        Me.ss_totalprice_hundredth = New FuelPump.SevenSegDigit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 109)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "TOTAL PRICE:"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape3, Me.RectangleShape2, Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(619, 493)
        Me.ShapeContainer1.TabIndex = 7
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape3
        '
        Me.RectangleShape3.BackColor = System.Drawing.Color.Black
        Me.RectangleShape3.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape3.Location = New System.Drawing.Point(523, 344)
        Me.RectangleShape3.Name = "RectangleShape3"
        Me.RectangleShape3.Size = New System.Drawing.Size(10, 14)
        '
        'RectangleShape2
        '
        Me.RectangleShape2.BackColor = System.Drawing.Color.Black
        Me.RectangleShape2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape2.Location = New System.Drawing.Point(482, 246)
        Me.RectangleShape2.Name = "RectangleShape2"
        Me.RectangleShape2.Size = New System.Drawing.Size(10, 14)
        '
        'RectangleShape1
        '
        Me.RectangleShape1.BackColor = System.Drawing.Color.Black
        Me.RectangleShape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape1.Location = New System.Drawing.Point(482, 144)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(10, 14)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 210)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 25)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "LITRES:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(305, 305)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 24)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "p/l:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_Connect)
        Me.GroupBox1.Controls.Add(Me.lbl_Status)
        Me.GroupBox1.Controls.Add(Me.en_ConsoleHost)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(180, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(237, 61)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Connection"
        '
        'lbl_Status
        '
        Me.lbl_Status.AutoSize = True
        Me.lbl_Status.Location = New System.Drawing.Point(7, 40)
        Me.lbl_Status.Name = "lbl_Status"
        Me.lbl_Status.Size = New System.Drawing.Size(129, 13)
        Me.lbl_Status.TabIndex = 2
        Me.lbl_Status.Text = "Port 15000 must be open!"
        '
        'en_ConsoleHost
        '
        Me.en_ConsoleHost.Location = New System.Drawing.Point(75, 17)
        Me.en_ConsoleHost.Name = "en_ConsoleHost"
        Me.en_ConsoleHost.Size = New System.Drawing.Size(100, 20)
        Me.en_ConsoleHost.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Connect to:"
        '
        'btn_Pump
        '
        Me.btn_Pump.Location = New System.Drawing.Point(15, 395)
        Me.btn_Pump.Name = "btn_Pump"
        Me.btn_Pump.Size = New System.Drawing.Size(591, 83)
        Me.btn_Pump.TabIndex = 20
        Me.btn_Pump.Text = "PUMP (Hold space)"
        Me.btn_Pump.UseVisualStyleBackColor = True
        '
        'btn_Connect
        '
        Me.btn_Connect.Image = Global.FuelPump.My.Resources.Resources.stock_connect
        Me.btn_Connect.Location = New System.Drawing.Point(181, 17)
        Me.btn_Connect.Name = "btn_Connect"
        Me.btn_Connect.Size = New System.Drawing.Size(48, 35)
        Me.btn_Connect.TabIndex = 3
        Me.btn_Connect.UseVisualStyleBackColor = True
        '
        'ss_price_hundreds
        '
        Me.ss_price_hundreds.BackColor = System.Drawing.Color.Transparent
        Me.ss_price_hundreds.Digit = 0
        Me.ss_price_hundreds.ForeColor = System.Drawing.Color.Green
        Me.ss_price_hundreds.Location = New System.Drawing.Point(351, 270)
        Me.ss_price_hundreds.Name = "ss_price_hundreds"
        Me.ss_price_hundreds.Size = New System.Drawing.Size(51, 94)
        Me.ss_price_hundreds.TabIndex = 18
        '
        'ss_price_tens
        '
        Me.ss_price_tens.BackColor = System.Drawing.Color.Transparent
        Me.ss_price_tens.Digit = 0
        Me.ss_price_tens.ForeColor = System.Drawing.Color.Green
        Me.ss_price_tens.Location = New System.Drawing.Point(408, 270)
        Me.ss_price_tens.Name = "ss_price_tens"
        Me.ss_price_tens.Size = New System.Drawing.Size(51, 94)
        Me.ss_price_tens.TabIndex = 17
        '
        'ss_price_ones
        '
        Me.ss_price_ones.BackColor = System.Drawing.Color.Transparent
        Me.ss_price_ones.Digit = 0
        Me.ss_price_ones.ForeColor = System.Drawing.Color.Green
        Me.ss_price_ones.Location = New System.Drawing.Point(465, 270)
        Me.ss_price_ones.Name = "ss_price_ones"
        Me.ss_price_ones.Size = New System.Drawing.Size(51, 94)
        Me.ss_price_ones.TabIndex = 16
        '
        'ss_price_decimal
        '
        Me.ss_price_decimal.BackColor = System.Drawing.Color.Transparent
        Me.ss_price_decimal.Digit = 0
        Me.ss_price_decimal.ForeColor = System.Drawing.Color.Green
        Me.ss_price_decimal.Location = New System.Drawing.Point(541, 270)
        Me.ss_price_decimal.Name = "ss_price_decimal"
        Me.ss_price_decimal.Size = New System.Drawing.Size(51, 94)
        Me.ss_price_decimal.TabIndex = 15
        '
        'ss_pumped_hundreds
        '
        Me.ss_pumped_hundreds.BackColor = System.Drawing.Color.Transparent
        Me.ss_pumped_hundreds.Digit = 0
        Me.ss_pumped_hundreds.ForeColor = System.Drawing.Color.Green
        Me.ss_pumped_hundreds.Location = New System.Drawing.Point(309, 170)
        Me.ss_pumped_hundreds.Name = "ss_pumped_hundreds"
        Me.ss_pumped_hundreds.Size = New System.Drawing.Size(51, 94)
        Me.ss_pumped_hundreds.TabIndex = 13
        '
        'ss_pumped_tens
        '
        Me.ss_pumped_tens.BackColor = System.Drawing.Color.Transparent
        Me.ss_pumped_tens.Digit = 0
        Me.ss_pumped_tens.ForeColor = System.Drawing.Color.Green
        Me.ss_pumped_tens.Location = New System.Drawing.Point(366, 170)
        Me.ss_pumped_tens.Name = "ss_pumped_tens"
        Me.ss_pumped_tens.Size = New System.Drawing.Size(51, 94)
        Me.ss_pumped_tens.TabIndex = 12
        '
        'ss_pumped_ones
        '
        Me.ss_pumped_ones.BackColor = System.Drawing.Color.Transparent
        Me.ss_pumped_ones.Digit = 0
        Me.ss_pumped_ones.ForeColor = System.Drawing.Color.Green
        Me.ss_pumped_ones.Location = New System.Drawing.Point(423, 170)
        Me.ss_pumped_ones.Name = "ss_pumped_ones"
        Me.ss_pumped_ones.Size = New System.Drawing.Size(51, 94)
        Me.ss_pumped_ones.TabIndex = 11
        '
        'ss_pumped_decimal
        '
        Me.ss_pumped_decimal.BackColor = System.Drawing.Color.Transparent
        Me.ss_pumped_decimal.Digit = 0
        Me.ss_pumped_decimal.ForeColor = System.Drawing.Color.Green
        Me.ss_pumped_decimal.Location = New System.Drawing.Point(499, 170)
        Me.ss_pumped_decimal.Name = "ss_pumped_decimal"
        Me.ss_pumped_decimal.Size = New System.Drawing.Size(51, 94)
        Me.ss_pumped_decimal.TabIndex = 10
        '
        'ss_pumped_hundredth
        '
        Me.ss_pumped_hundredth.BackColor = System.Drawing.Color.Transparent
        Me.ss_pumped_hundredth.Digit = 0
        Me.ss_pumped_hundredth.ForeColor = System.Drawing.Color.Green
        Me.ss_pumped_hundredth.Location = New System.Drawing.Point(556, 170)
        Me.ss_pumped_hundredth.Name = "ss_pumped_hundredth"
        Me.ss_pumped_hundredth.Size = New System.Drawing.Size(51, 94)
        Me.ss_pumped_hundredth.TabIndex = 9
        '
        'ss_totalprice_hundreds
        '
        Me.ss_totalprice_hundreds.BackColor = System.Drawing.Color.Transparent
        Me.ss_totalprice_hundreds.Digit = 0
        Me.ss_totalprice_hundreds.ForeColor = System.Drawing.Color.Green
        Me.ss_totalprice_hundreds.Location = New System.Drawing.Point(309, 69)
        Me.ss_totalprice_hundreds.Name = "ss_totalprice_hundreds"
        Me.ss_totalprice_hundreds.Size = New System.Drawing.Size(51, 94)
        Me.ss_totalprice_hundreds.TabIndex = 6
        '
        'ss_totalprice_tens
        '
        Me.ss_totalprice_tens.BackColor = System.Drawing.Color.Transparent
        Me.ss_totalprice_tens.Digit = 0
        Me.ss_totalprice_tens.ForeColor = System.Drawing.Color.Green
        Me.ss_totalprice_tens.Location = New System.Drawing.Point(366, 69)
        Me.ss_totalprice_tens.Name = "ss_totalprice_tens"
        Me.ss_totalprice_tens.Size = New System.Drawing.Size(51, 94)
        Me.ss_totalprice_tens.TabIndex = 5
        '
        'ss_totalprice_ones
        '
        Me.ss_totalprice_ones.BackColor = System.Drawing.Color.Transparent
        Me.ss_totalprice_ones.Digit = 0
        Me.ss_totalprice_ones.ForeColor = System.Drawing.Color.Green
        Me.ss_totalprice_ones.Location = New System.Drawing.Point(423, 69)
        Me.ss_totalprice_ones.Name = "ss_totalprice_ones"
        Me.ss_totalprice_ones.Size = New System.Drawing.Size(51, 94)
        Me.ss_totalprice_ones.TabIndex = 4
        '
        'ss_totalprice_decimal
        '
        Me.ss_totalprice_decimal.BackColor = System.Drawing.Color.Transparent
        Me.ss_totalprice_decimal.Digit = 0
        Me.ss_totalprice_decimal.ForeColor = System.Drawing.Color.Green
        Me.ss_totalprice_decimal.Location = New System.Drawing.Point(499, 69)
        Me.ss_totalprice_decimal.Name = "ss_totalprice_decimal"
        Me.ss_totalprice_decimal.Size = New System.Drawing.Size(51, 94)
        Me.ss_totalprice_decimal.TabIndex = 3
        '
        'ss_totalprice_hundredth
        '
        Me.ss_totalprice_hundredth.BackColor = System.Drawing.Color.Transparent
        Me.ss_totalprice_hundredth.Digit = 0
        Me.ss_totalprice_hundredth.ForeColor = System.Drawing.Color.Green
        Me.ss_totalprice_hundredth.Location = New System.Drawing.Point(556, 69)
        Me.ss_totalprice_hundredth.Name = "ss_totalprice_hundredth"
        Me.ss_totalprice_hundredth.Size = New System.Drawing.Size(51, 94)
        Me.ss_totalprice_hundredth.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(619, 493)
        Me.Controls.Add(Me.btn_Pump)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ss_price_hundreds)
        Me.Controls.Add(Me.ss_price_tens)
        Me.Controls.Add(Me.ss_price_ones)
        Me.Controls.Add(Me.ss_price_decimal)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ss_pumped_hundreds)
        Me.Controls.Add(Me.ss_pumped_tens)
        Me.Controls.Add(Me.ss_pumped_ones)
        Me.Controls.Add(Me.ss_pumped_decimal)
        Me.Controls.Add(Me.ss_pumped_hundredth)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ss_totalprice_hundreds)
        Me.Controls.Add(Me.ss_totalprice_tens)
        Me.Controls.Add(Me.ss_totalprice_ones)
        Me.Controls.Add(Me.ss_totalprice_decimal)
        Me.Controls.Add(Me.ss_totalprice_hundredth)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Name = "Form1"
        Me.Text = "Fuel Pump"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ss_totalprice_hundredth As FuelPump.SevenSegDigit
    Friend WithEvents ss_totalprice_decimal As FuelPump.SevenSegDigit
    Friend WithEvents ss_totalprice_ones As FuelPump.SevenSegDigit
    Friend WithEvents ss_totalprice_tens As FuelPump.SevenSegDigit
    Friend WithEvents ss_totalprice_hundreds As FuelPump.SevenSegDigit
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape3 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents RectangleShape2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents ss_pumped_hundreds As FuelPump.SevenSegDigit
    Friend WithEvents ss_pumped_tens As FuelPump.SevenSegDigit
    Friend WithEvents ss_pumped_ones As FuelPump.SevenSegDigit
    Friend WithEvents ss_pumped_decimal As FuelPump.SevenSegDigit
    Friend WithEvents ss_pumped_hundredth As FuelPump.SevenSegDigit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ss_price_hundreds As FuelPump.SevenSegDigit
    Friend WithEvents ss_price_tens As FuelPump.SevenSegDigit
    Friend WithEvents ss_price_ones As FuelPump.SevenSegDigit
    Friend WithEvents ss_price_decimal As FuelPump.SevenSegDigit
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_Connect As System.Windows.Forms.Button
    Friend WithEvents lbl_Status As System.Windows.Forms.Label
    Friend WithEvents en_ConsoleHost As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_Pump As System.Windows.Forms.Button

End Class
