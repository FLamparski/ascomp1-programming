Public Class PriceSetterDlg

    Public Property FuelPrice() As Decimal
        Get
            Return NumericUpDown1.Value
        End Get
        Set(ByVal value As Decimal)
            NumericUpDown1.Value = value
        End Set
    End Property

End Class