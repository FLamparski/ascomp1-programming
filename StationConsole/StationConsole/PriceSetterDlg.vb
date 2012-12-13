Public Class PriceSetterDlg
    ''' <summary>
    ''' Gets or sets the display value of fuel price in the dialog
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FuelPrice() As Decimal
        Get
            Return NumericUpDown1.Value
        End Get
        Set(ByVal value As Decimal)
            NumericUpDown1.Value = value
        End Set
    End Property

End Class