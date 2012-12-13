Public Class PumpForm
    ''' <summary>
    ''' Set values which go into boxes in the form
    ''' </summary>
    ''' <param name="pumped">Amount of fuel pumped</param>
    ''' <param name="sale">Total price to pay for the fuel</param>
    ''' <param name="price">Price per litre of the fuel</param>
    ''' <remarks></remarks>
    Public Sub SetValues(ByVal pumped As String, ByVal sale As String, ByVal price As String)
        en_Litres.Text = pumped
        en_TotalSale.Text = sale
        en_Price.Text = price
    End Sub

    ''' <summary>
    ''' Toggles the pumping status on the form
    ''' </summary>
    ''' <param name="pumping"></param>
    ''' <remarks></remarks>
    Public Sub SetPumping(ByVal pumping As Boolean)
        If pumping Then
            en_IsPumping.Text = "YES"
            en_IsPumping.BackColor = Color.PaleGreen
        Else
            en_IsPumping.Text = "NO"
            en_IsPumping.BackColor = Color.LightCoral
        End If
    End Sub
End Class