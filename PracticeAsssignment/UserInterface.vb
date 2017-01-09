''' <summary>
''' Class to output to the user and get input from the user
''' </summary>
Public Class UserInterface
    ''' <summary>
    ''' Sets the size and buffer of the console
    ''' </summary>
    Public Sub initializeConsole()
        Console.SetWindowSize(Console.LargestWindowWidth * 0.8, Console.LargestWindowHeight * 0.8)
        Console.BufferHeight = Int16.MaxValue / 4
    End Sub

    ''' <summary>
    ''' Outputs start menu, gets users input, and validates users input
    ''' </summary>
    ''' <returns>Boolean</returns>
    Public Function startProgram() As Boolean
        Dim inputString As String = getUserMenuInput(loadCSVfileString)
        Do While inputString <> "1" And inputString <> "2"
            printErrorMessage(inputString)
            inputString = getUserMenuInput(loadCSVfileString)
        Loop
        If inputString = "1" Then
            startProgram = True
        Else
            startProgram = False
        End If
    End Function

    ''' <summary>
    ''' Outputs main menu, gets users input, and validates users input
    ''' </summary>
    ''' <returns>Integer</returns>
    Public Function mainMenu() As Integer
        Dim inputString As String = getUserMenuInput(mainMenuString)
        Do While inputString <> "1" And inputString <> "2" And inputString <> "3" And inputString <> "4" And
        inputString <> "5"
            printErrorMessage(inputString)
            inputString = getUserMenuInput(mainMenuString)
        Loop
        mainMenu = Convert.ToInt32(inputString)
    End Function

    ''' <summary>
    ''' Outputs search menu, gets users input and validates users input
    ''' </summary>
    ''' <returns>String</returns>
    Public Function searchMenu() As String
        Dim inputString As String = getUserMenuInput(searchMenuString)
        Do While inputString <> "1" And inputString <> "2" And inputString <> "3" And inputString <> "4"
            printErrorMessage(inputString)
            inputString = getUserMenuInput(searchMenuString)
        Loop
        searchMenu = inputString
    End Function

    Public Sub printWineList(wineCollection As WineCollection)
        Console.WriteLine()
        Console.WriteLine("____________________________________ Wine List ____________________________________")

        For index As Integer = 0 To wineCollection.wineCollectionSize - 1
            If index Mod 2 = 0 Then
                Console.ForegroundColor = ConsoleColor.Gray
            Else
                Console.ForegroundColor = ConsoleColor.White
            End If
            Console.WriteLine(wineCollection.getWineItem(index))
        Next

        Console.WriteLine("___________________________________ End Wine List ___________________________________")
    End Sub

    ''' <summary>
    ''' Method to pause before closing program
    ''' </summary>
    Public Sub enterAnyKeyToContinue()
        Console.WriteLine()
        Console.WriteLine(" Hit any key to continue. . .")
        Console.ReadKey()
    End Sub

    ''' <summary>
    ''' Creates the string used for the start of program
    ''' </summary>
    ''' <returns>String</returns>
    Private Function loadCSVfileString() As String
        loadCSVfileString = Environment.NewLine & " Welcome to Wine Item List" & Environment.NewLine
        loadCSVfileString += " 1) Load Wine List" & Environment.NewLine
        loadCSVfileString += " 2) Exit Program"
    End Function

    ''' <summary>
    ''' Creates the string used for the Main Menu
    ''' </summary>
    ''' <returns>String</returns>
    Private Function mainMenuString() As String
        mainMenuString = Environment.NewLine & " Main Menu" & Environment.NewLine
        mainMenuString += " 1) Print Wine List" & Environment.NewLine
        mainMenuString += " 2) Search for Wine Item" & Environment.NewLine
        mainMenuString += " 3) Add a New Wine Item" & Environment.NewLine
        mainMenuString += " 4) Delete a Wine Item by Id" & Environment.NewLine
        mainMenuString += " 5) Exit"
    End Function

    Private Function searchMenuString() As String
        searchMenuString = Environment.NewLine & " Search Menu" & Environment.NewLine
        searchMenuString += " 1) Search by ID" & Environment.NewLine
        searchMenuString += " 2) Search by Description" & Environment.NewLine
        searchMenuString += " 3) Search by Pack" & Environment.NewLine
        searchMenuString += " 4) Exit"
    End Function

    ''' <summary>
    ''' Generic method to get users menu choice
    ''' </summary>
    ''' <param name="MessageToUser">String</param>
    ''' <returns>String</returns>
    Private Function getUserMenuInput(MessageToUser As String) As String
        Console.WriteLine(MessageToUser)
        Console.Write(" Enter the number of the item you wish to do: ")
        getUserMenuInput = Console.ReadLine.Trim
    End Function

    ''' <summary>
    ''' Generic method to output the error message with the bad data
    ''' </summary>
    ''' <param name="BadInput">String</param>
    Private Sub printErrorMessage(BadInput As String)
        Console.ForegroundColor = ConsoleColor.Red
        Console.WriteLine("-----------------------------------------")
        Console.WriteLine(" " & BadInput & " is not a valid input.")
        Console.WriteLine("-----------------------------------------")
        Console.ForegroundColor = ConsoleColor.White
    End Sub

End Class
