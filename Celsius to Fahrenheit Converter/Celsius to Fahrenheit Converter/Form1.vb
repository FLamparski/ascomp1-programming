Public Class Form1
    Dim tempC As Integer 'Stores Celsius value for conversion
    Dim tempF As Integer 'Stores Fahrenheit value for conversion

    Private Sub btn_convertCtoF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_convertCtoF.Click
        If Integer.TryParse(en_CelsiusValue.Text, tempC) Then ' If the value entered is a number,
            en_FahrenheitValue.Text = Math.Round(tempC * 9 / 5 + 32).ToString() ' Convert it to Fahrenheit using the appropriate formula and display in the other entry field
        Else ',
            MessageBox.Show("The value you entered is not a proper whole number.", "Numeric Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Warning) ' Warn the user their input is incorrect
        End If
    End Sub

    Private Sub btn_convertFtoC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_convertFtoC.Click
        If Integer.TryParse(en_FahrenheitValue.Text, tempF) Then ' If the value entered is a number,
            en_CelsiusValue.Text = Math.Round((tempF - 32) * 5 / 9).ToString() ' Convert it to Celsius using the appropriate formula and display in the other entry field
        Else ',
            MessageBox.Show("The value you entered is not a proper whole number.", "Numeric Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Warning) ' Warn the user their input is incorrect
        End If
    End Sub
End Class
