Public Class WineFactory
    Private ui As UserInterface = New UserInterface()
    Public Sub SearchFor(WineCollection As WineCollection)
        Dim searchChoiceString = ui.searchMenu()
        Select Case searchChoiceString
            Case "1"
                searchChoiceString = NameOf(WineItem.id)
            Case "2"
                searchChoiceString = NameOf(WineItem.description)
            Case "3"
                searchChoiceString = NameOf(WineItem.pack)
            Case "4"
                searchChoiceString = "exit"
        End Select
        If searchChoiceString <> "exit" Then

        End If
    End Sub
End Class
