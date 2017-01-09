'Class to hold business logic that does not neatly fit into the UserInterface or the WineCollection
Public Class WineFactory
    Private ui As UserInterface = New UserInterface()

    ''' <summary>
    ''' Logic used to choose type of information to search for, get the data to search for, search for the data and 
    ''' print out the results
    ''' </summary>
    ''' <param name="wineCollection"></param>
    Public Sub SearchFor(wineCollection As WineCollection)
        Dim searchTypeString = ui.searchMenu()
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
        If searchTypeString <> "exit" Then
            Dim searchForDataString As String = ui.getSearchForData(searchTypeString)
            Dim evenBoolean As Boolean = False
            Dim countInt As Int32 = 0
            For index As Int32 = 1 To wineCollection.wineCollectionSize - 1
                If wineCollection.findWineItem(searchForDataString, searchTypeString, index) Then
                    countInt += 1
                    If countInt Mod 2 = 0 Then
                        evenBoolean = True
                    Else
                        evenBoolean = False
                    End If
                    ui.printWineItem(wineCollection, index, evenBoolean)
                End If
            Next
            If countInt = 0 Then
                ui.printSearchNotFound(searchForDataString)
            End If
            ui.printWineItemSearchEnding()
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
