Module Module1

    Enum GameState
        WIN
        QUIT
    End Enum

    Function Game() As GameState
        Dim randomizer As Random = New Random()
        Dim number As Integer = randomizer.Next(0, 11) ' Generate a random number

        Dim counter As Integer = 1

        Console.WriteLine("I'm thinking of a number between 1 and 10. What is it?")

        Dim runLoop As Boolean = True ' Controls the loop
        While runLoop
            Console.Write("(" & counter & ") Your guess: ")
            Dim input As String = Console.ReadLine()
            If input = "quit" Then
                runLoop = False ' Quit the loop
            End If

            Try
                Dim inNumber As Integer = Integer.Parse(input)

                If inNumber = number Then ' User entered the correct number
                    Console.WriteLine("You win!")
                    Return GameState.WIN ' The game was won
                ElseIf inNumber < number Then ' User entered a smaller number
                    Console.WriteLine("Too small!")
                    counter += 1
                ElseIf inNumber > number Then ' User entered a bigger number
                    Console.WriteLine("Too big!")
                    counter += 1
                End If
            Catch ex As Exception ' User entered something that is not an integer
                Console.WriteLine("Problems: " & ex.Message)
            End Try
        End While
        Return GameState.QUIT ' If this point is reached, then the game is quit.
    End Function

    Sub Main()
        Dim runLoop As Boolean = True ' Controls the main loop

        Console.WriteLine("Welcome to Guess The Number. Enter ""quit"" at any time to close the program.")

        While runLoop
            Dim result As GameState = Game()
            If result = GameState.WIN Then
                Console.Write("Want to play again? [y]/n ")
                Dim answer = Console.ReadKey()

                Console.WriteLine("") ' Outputs a new line character to fix text layout

                If answer.Key = ConsoleKey.N Then
                    runLoop = False ' Quit if the user presses n.
                End If
            ElseIf result = GameState.QUIT Then
                runLoop = False ' Quit if the user types "quit".
            End If
        End While

        Console.WriteLine("Thank you for playing!")
    End Sub

End Module
