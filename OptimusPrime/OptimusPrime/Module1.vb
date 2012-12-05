Module Module1

    Function CheckPrime(ByVal num As UInteger)
        For i As Integer = 2 To num
            If (num Mod i = 0) And (i <> num) Then ' If the number is divisible by anything (2 <= x < number), the number is not prime
                Return False
            End If
        Next
        Return True ' This means that the number is prime
    End Function

    Sub Main()
        Dim quit As Boolean = False
        Dim prime As Boolean = False
        Dim num As UInteger
        Dim innum As String
        While Not quit
            Console.WriteLine("Optimus Prime tells if your number is a prime.")
            Console.Write("Enter a whole positive number [q quits]: ")
            innum = Console.ReadLine()

            If innum = "q" Then ' User wants to quit
                quit = True ' Set quit flag
                Continue While ' Then skip over the code below
            End If

            If UInteger.TryParse(innum, num) Then
                prime = CheckPrime(num) ' Run the actual prime check
                If prime Then
                    If num = 0 Or num = 1 Then
                        Console.WriteLine("The number is neither prime nor composite." + vbCrLf)
                    Else
                        Console.WriteLine("The number is prime" + vbCrLf)
                    End If
                Else
                    Console.WriteLine("The number is not prime" + vbCrLf)
                End If
            Else
                Console.WriteLine("Can't convert your input to a whole positive number. Is it valid?" + vbCrLf) ' User entered a non-integer
            End If
        End While
        Console.WriteLine("Goodbye!")
        ' Console.ReadKey() ' For development and testing only
    End Sub

End Module
