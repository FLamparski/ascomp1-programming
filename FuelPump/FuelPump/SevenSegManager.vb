Public Class SevenSegManager
    Private digits As ArrayList

    ''' <summary>
    ''' Initializes the SevenSegManager and adds one digit.
    ''' </summary>
    ''' <param name="digit1"></param>
    ''' <remarks></remarks>
    Public Sub New(ByRef digit1 As SevenSegDigit)
        digits = New ArrayList()
        digits.Add(digit1)
    End Sub

    ''' <summary>
    ''' Initializes the SevenSegManager
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        digits = New ArrayList()
    End Sub

    ''' <summary>
    ''' Adds a SevenSegDigit to this SevenSegManager
    ''' </summary>
    ''' <param name="digit1"></param>
    ''' <remarks></remarks>
    Public Sub AddDigit(ByRef digit1 As SevenSegDigit)
        digits.Add(digit1)
    End Sub

    ''' <summary>
    ''' Iterates through its internal list of SevenSegDigits and sets the number.
    ''' </summary>
    ''' <param name="number">Number to be set on SevenSegDigits.</param>
    ''' <remarks>Throws an exception if there is too many digits.
    ''' Sets leading zeros.</remarks>
    Public Sub SetNumber(ByVal number As Integer)
        Dim cheatyDigitSplit As String = number.ToString()

        If digits.Count < cheatyDigitSplit.Count() Then ' Check if the number is too large to display
            Throw New ArgumentOutOfRangeException("number", "Too many digits to display")
        End If

        If digits.Count > cheatyDigitSplit.Count() Then ' Check if the number needs to have zeros prepended to fit
            Dim zeros_needed As Integer = digits.Count - cheatyDigitSplit.Count()
            For i As Integer = 1 To zeros_needed ' Don't add too many zeros: If i = 0, the loop would run twice for one place difference, which is bad.
                cheatyDigitSplit = "0" + cheatyDigitSplit ' Prepend a zero to the number we want to display as many times as needed.
            Next
        End If

        ' Use a loop to set our digits to display the number we want.
        For i As Integer = 0 To (digits.Count - 1) ' digits.Count is greater than the last index which makes sense.
            Try
                Dim realDigit As Integer = Integer.Parse(cheatyDigitSplit(i))
                digits(i).SetDigit(realDigit)
            Catch ex As Exception
                Throw New ArgumentException("A SevenSegDigit doth protest too much.") ' This never should happen unless the memory is messed with.
            End Try
        Next
    End Sub

    ''' <summary>
    ''' Iterates through its internal list of SevenSegDigits and sets the number.
    ''' </summary>
    ''' <param name="number">String representing a number to be displayed. Leading zeros please.</param>
    ''' <remarks></remarks>
    Public Sub SetNumber(ByVal number As String)
        If digits.Count < number.Count() Then
            Throw New ArgumentOutOfRangeException("number", "Too many digits to display")
        End If

        ' Use a loop to set our digits to display the number we want.
        For i As Integer = 0 To (digits.Count - 1) ' digits.Count is greater than the last index which makes sense.
            Try
                Dim realDigit As Integer = Integer.Parse(number(i))
                digits(i).SetDigit(realDigit)
            Catch ex As Exception
                Throw New ArgumentException("Contents of the string given must be numeric.", "number")
            End Try
        Next
    End Sub

    ''' <summary>
    ''' Retrieves the number of SevenSegDigits stored.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DigitsCount() As String
        Get
            Return digits.Count
        End Get
    End Property

End Class
