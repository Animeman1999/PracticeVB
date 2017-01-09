''' <summary>
''' Class to hold and process the WineCollection
''' </summary>
Public Class WineCollection
    Private wineCollection(4000) As WineItem
    Private _wineCollectionSize As Int32

    ReadOnly Property wineCollectionSize As Int32
        Get
            Return _wineCollectionSize
        End Get
    End Property

    Public Function getWineItem(whichWine As Integer) As String
        getWineItem = $"  {wineCollection(whichWine).id,6 } {wineCollection(whichWine).description,-60} {wineCollection(whichWine).pack,25}"
    End Function

    Public Sub addWineItem(id As String, description As String, pack As String)
        wineCollection(_wineCollectionSize) = New WineItem(id, description, pack)
        _wineCollectionSize += 1
    End Sub

    Public Function findWineItem(searchForString As String, searchType As String, currentIndex As Integer) As Boolean
        findWineItem = False
        Select Case searchType
            Case NameOf(WineItem.id)
                If wineCollection(currentIndex).id.Contains(searchForString) Then
                    findWineItem = True
                End If
            Case NameOf(WineItem.description)
                If wineCollection(currentIndex).description.Contains(searchForString) Then
                    findWineItem = True
                End If
            Case NameOf(WineItem.pack)
                If wineCollection(currentIndex).pack.Contains(searchForString) Then
                    findWineItem = True
                End If
        End Select
    End Function

    Public Sub New()
        _wineCollectionSize = 0
    End Sub
End Class
