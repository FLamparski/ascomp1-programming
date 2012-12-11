Public Class PumpForm
    Public Sub SetValues(ByVal pumped As String, ByVal sale As String, ByVal price As String)
        en_Litres.Text = pumped
        en_TotalSale.Text = sale
        en_Price.Text = price
    End Sub

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