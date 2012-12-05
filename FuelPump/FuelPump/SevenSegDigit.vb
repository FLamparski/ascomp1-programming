Public Class SevenSegDigit


    Private digitDisplayed As Integer

    ''' <summary>
    ''' Hide ALL the segments
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ResetDisplay()
        VSegmentLeftBottom.Hide()
        VSegmentLeftTop.Hide()
        VSegmentRightBottom.Hide()
        VSegmentRightTop.Hide()
        HSegmentBottom.Hide()
        HSegmentMiddle.Hide()
        HSegmentTop.Hide()
    End Sub

    ''' <summary>
    ''' Sets the 7-seg display to digit
    ''' </summary>
    ''' <param name="digit">A single digit to be displayed</param>
    ''' <remarks></remarks>
    Public Sub SetDigit(ByVal digit As Integer)
        If digit < 0 And digit > 9 Then ' Check if the number provided is a digit
            Throw New ArgumentOutOfRangeException("Number is not a single digit")
        End If

        Select Case digit
            Case 0
                ResetDisplay()              ' Reset the display by hiding all the segments
                VSegmentLeftBottom.Show()   ' Show the appropriate segments for a digit
                VSegmentLeftTop.Show()      ' ..
                VSegmentRightBottom.Show()  ' ..
                VSegmentRightTop.Show()     ' ..
                HSegmentBottom.Show()       ' ..
                HSegmentTop.Show()          ' That's how all of this method works.
            Case 1
                ResetDisplay()
                VSegmentRightBottom.Show()
                VSegmentRightTop.Show()
            Case 2
                ResetDisplay()
                HSegmentTop.Show()
                VSegmentRightTop.Show()
                HSegmentMiddle.Show()
                VSegmentLeftBottom.Show()
                HSegmentBottom.Show()
            Case 3
                ResetDisplay()
                VSegmentRightBottom.Show()
                VSegmentRightTop.Show()
                HSegmentTop.Show()
                HSegmentMiddle.Show()
                HSegmentBottom.Show()
            Case 4
                ResetDisplay()
                VSegmentRightBottom.Show()
                VSegmentRightTop.Show()
                VSegmentLeftTop.Show()
                HSegmentMiddle.Show()
            Case 5
                ResetDisplay()
                HSegmentTop.Show()
                VSegmentLeftTop.Show()
                HSegmentMiddle.Show()
                VSegmentRightBottom.Show()
                HSegmentBottom.Show()
            Case 6
                ResetDisplay()
                VSegmentLeftBottom.Show()
                VSegmentLeftTop.Show()
                VSegmentRightBottom.Show()
                HSegmentBottom.Show()
                HSegmentMiddle.Show()
                HSegmentTop.Show()
            Case 7
                ResetDisplay()
                VSegmentRightBottom.Show()
                VSegmentRightTop.Show()
                HSegmentTop.Show()
            Case 8
                ResetDisplay()
                VSegmentLeftBottom.Show()
                VSegmentLeftTop.Show()
                VSegmentRightBottom.Show()
                VSegmentRightTop.Show()
                HSegmentBottom.Show()
                HSegmentMiddle.Show()
                HSegmentTop.Show()
            Case 9
                ResetDisplay()
                VSegmentLeftTop.Show()
                VSegmentRightBottom.Show()
                VSegmentRightTop.Show()
                HSegmentBottom.Show()
                HSegmentMiddle.Show()
                HSegmentTop.Show()
            Case Else
                Throw New SevenSegmentDigitException("Cannot display the digit " + digit.ToString())
        End Select

        digitDisplayed = digit
    End Sub

    Public Property Digit() As Integer
        Get
            Return digitDisplayed
        End Get
        Set(ByVal value As Integer)
            SetDigit(value)
        End Set
    End Property

    ''' <summary>
    ''' Returns a string representation of the digit displayed
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function ToString() As String
        Return digitDisplayed.ToString()
    End Function

End Class

Public Class SevenSegmentDigitException
    Inherits Exception
    Public Sub New()

    End Sub

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(ByVal message As String, ByVal inner As Exception)
        MyBase.New(message, inner)
    End Sub
End Class