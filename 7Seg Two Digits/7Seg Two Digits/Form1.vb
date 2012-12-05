Public Class Form1

    Dim sevenSegManager As SevenSegManager

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sevenSegManager = New SevenSegManager()

        ' Uncomment the following lines for up to 999 displayed
        'hundredsDigit.Show()
        'sevenSegManager.AddDigit(hundredsDigit)

        sevenSegManager.AddDigit(tensDigit)
        sevenSegManager.AddDigit(onesDigit)
        sevenSegManager.SetNumber(0)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim number As Integer
        If Integer.TryParse(en_DigitEntry.Text, number) Then
            Try
                Me.sevenSegManager.SetNumber(number)
            Catch ex As ArgumentOutOfRangeException
                MessageBox.Show("Can't display number: too many digits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Error happens: the digit does not like your number. " & ex.Message, "Zen Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Your input was not a proper integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class
