'Class to hold business logic that does not neatly fit into the UserInterface or the WineCollection
Public Class WineFactory
    Private ui As UserInterface = New UserInterface()
    Private printBool As Boolean = True
    Private searchTypeString As String
    Private searchForDataString As String

    ''' <summary>
    ''' Logic used to choose type of information to search for, get the data to search for, search for the data and 
    ''' print out the results
    ''' </summary>
    ''' <param name="wineCollection"></param>
    Public Sub SearchForDelete(wineCollection As WineCollection, searchOrDeleteString As String)
        If printBool Then
            searchTypeString = ui.searchMenu(searchOrDeleteString)

            Select Case searchTypeString
                Case "1"
                    searchTypeString = NameOf(WineItem.id)
                Case "2"
                    searchTypeString = NameOf(WineItem.description)
                Case "3"
                    searchTypeString = NameOf(WineItem.pack)
                Case "4"
                    searchTypeString = "exit"
            End Select
        End If
        If searchTypeString <> "exit" Then
            If printBool Then
                searchForDataString = ui.getSearchForData(searchTypeString, searchOrDeleteString)
            End If

            Dim evenBoolean As Boolean = False
            Dim countInt As Int32 = 0
            For index As Int32 = 0 To wineCollection.wineCollectionSize - 1
                If wineCollection.findWineItem(searchForDataString, searchTypeString, index) Then
                    countInt += 1
                    If printBool Then
                        If countInt Mod 2 = 0 Then
                            evenBoolean = True
                        Else
                            evenBoolean = False
                        End If
                        ui.printWineItem(wineCollection, index, evenBoolean)
                    Else
                        wineCollection.swapWineItem(index + countInt, index)
                    End If
                End If

            Next
            If countInt = 0 Then
                ui.printSearchNotFound(searchForDataString)
            End If
            If printBool Then
                ui.printWineItemSearchEnding(searchOrDeleteString)
                If searchOrDeleteString = "Delete" Then
                    If ui.getAreYouSureToDelete() Then
                        printBool = False
                        SearchForDelete(wineCollection, searchOrDeleteString)
                        ui.itemsDeleted()
                    End If
                End If
            Else
                wineCollection.deleteRemainingItems(countInt)
                printBool = True
            End If

        End If

    End Sub

    ''' <summary>
    ''' Logic to get the data for a wine item and validate the ID
    ''' </summary>
    ''' <param name="wineCollection">WineCollection</param>
    Public Sub AddAWine(wineCollection As WineCollection)
        Dim foundID = True
        Dim idString As String = ui.getDataForWine("Id")
        foundID = findWineByID(idString, wineCollection)
        Do While foundID
            ui.duplicateId(idString)
            idString = ui.getDataForWine("Id")
            foundID = findWineByID(idString, wineCollection)
        Loop
        Dim descriptionString As String = ui.getDataForWine("Description")
        Dim packString As String = ui.getDataForWine("Pack")
        wineCollection.addWineItem(idString, descriptionString, packString)
        ui.wineAddedMessage(wineCollection)
    End Sub

    ''' <summary>
    ''' Search for a wine by id and return true if found
    ''' </summary>
    ''' <param name="idString">String</param>
    ''' <param name="wineCollection">WineCollection</param>
    ''' <returns>Boolean</returns>
    Private Function findWineByID(idString As String, wineCollection As WineCollection) As Boolean
        findWineByID = False
        For index As Int32 = 1 To wineCollection.wineCollectionSize - 1
            If wineCollection.findWineItem(idString, "id", index) Then
                findWineByID = True
            End If
        Next
    End Function
End Class
