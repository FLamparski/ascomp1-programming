Module Module1

    Dim ballNumbers As ArrayList
    ''' <summary>
    ''' Six newline characters for easier separation of generations.
    ''' </summary>
    ''' <remarks></remarks>
    Dim lnNewline As String = vbNewLine + vbNewLine + vbNewLine + vbNewLine + vbNewLine + vbNewLine

    Sub PrintFormatted(ByRef numbers As Array)
        Dim printnum As String = ""
        For Each num As Integer In numbers
            printnum = printnum + num.ToString() + vbTab ' Format the numbers for display in the console: numbers separated by tabs.
        Next
        Console.WriteLine(lnNewline + printnum) ' Print the formatted string to console.
    End Sub

    Sub GenerateSixNumbers()
        ballNumbers = New ArrayList() ' (Re)initialise the ArrayList. If there isn't any, this makes a new one. If there is, it discards the old one and leaves it for GC and makes a new one.

        For c = 1 To 49 ' Populate ballNumbers with numbers 1 to 49
            ballNumbers.Add(c)
        Next

        Dim lottery_numbers(5) As Integer ' Will store the SIX numbers generated. (indexes 0 to 5)

        Dim rnd As New Random() ' Initalise the random number generator
        For c = 0 To 5
            Dim idx As Integer = rnd.Next(ballNumbers.Count) ' Generate a random numbers within the index range of ballNumbers
            Dim num As Integer = ballNumbers(idx)
            ballNumbers.RemoveAt(idx) ' Remove the number at generated index: ball pops out of the machine.
            lottery_numbers(c) = num ' Add the number to the lottery_numbers array.
        Next

        PrintFormatted(lottery_numbers)
    End Sub

    Sub Main()
        Dim runloop = True ' Keep the program running
        Dim skipgen = False ' Allow for generation skipping
        Console.Write("Welcome to LotteryNumbers! Here are your lucky numbers:")
        While runloop
            If Not skipgen Then ' skipgen will be true if the input from previous iteration was invalid.
                GenerateSixNumbers() ' Generates the six numbers and prints them
            End If
            skipgen = False ' reset skipgen.
            Console.Write("Would you like to generate a [n]ew set of numbers, or [q]uit the program? ")
            Dim key = Console.ReadKey() ' User interaction
            If key.KeyChar = "n" Then
                Continue While ' Generate new six numbers
            ElseIf key.KeyChar = "q" Then
                runloop = False ' Quit the program
            Else
                Console.WriteLine(vbNewLine + "Sorry, invalid input. Press n for a new set of numbers or q to quit.")
                skipgen = True ' Don't generate new numbers after an invalid input
            End If
        End While
        Console.WriteLine(vbNewLine + "Goodbye!")
    End Sub

End Module
