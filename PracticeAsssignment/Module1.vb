﻿Module Module1
    Dim wineCollection As WineCollection = New WineCollection()
    Sub Main()
        Dim mainMenuChoice = 1
        Dim ui As UserInterface = New UserInterface()
        Const CSV_FILE_PATH As String = "../../datafiles/WineList.csv"

        'Initialize the console
        ui.initializeConsole()

        'Start the console and see if the user wants to load the CSV file or quit
        If ui.startProgram() Then
            'User wants to load the CSV file so make an instance of the CSVInterface and read in the files
            Dim csvInterface As CSVInterface = New CSVInterface()
            csvInterface.ReadCSVFile(CSV_FILE_PATH, wineCollection)

            'Start the main menu and get back the users choice until it is "5" to exit the program
            Do While mainMenuChoice <> 5
                mainMenuChoice = ui.mainMenu

                Select Case mainMenuChoice
                    Case 1
                        ui.printWineList(wineCollection)
                    Case 2

                    Case 3

                    Case 4

                End Select
            Loop
            ui.enterAnyKeyToContinue()
        End If

    End Sub

End Module
