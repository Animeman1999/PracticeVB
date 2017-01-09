''' <summary>
''' Class to hold and process the WineCollection
''' </summary>
Public Class WineCollection
    Private wineCollection(4000) As WineItem
    Private _wineCollectionSize As Int32

    ''' <summary>
    ''' Only backing field used for the collection to allow the size of the array to be known
    ''' </summary>
    ''' <returns>Int32</returns>
    ReadOnly Property wineCollectionSize As Int32
        Get
            Return _wineCollectionSize
        End Get
    End Property

    ''' <summary>
    ''' Create string for the data in a single wine item
    ''' </summary>
    ''' <param name="whichWine">Integer</param>
    ''' <returns>String</returns>
    Public Function getWineItem(whichWine As Integer) As String
        getWineItem = $"  {wineCollection(whichWine).id,6 } {wineCollection(whichWine).description,-60} {wineCollection(whichWine).pack,25}"
    End Function

    ''' <summary>
    ''' Adds a wine item to the collection and keeps track of the total wine items in the list
    ''' </summary>
    ''' <param name="id">String</param>
    ''' <param name="description">String</param>
    ''' <param name="pack">String</param>
    Public Sub addWineItem(id As String, description As String, pack As String)
        wineCollection(_wineCollectionSize) = New WineItem(id, description, pack)
        _wineCollectionSize += 1
    End Sub

    ''' <summary>
    ''' Generic search that can be used no matter what property is used and or added in the future
    ''' </summary>
    ''' <param name="searchForString">String</param>
    ''' <param name="searchType">String</param>
    ''' <param name="currentIndex">String</param>
    ''' <returns></returns>
    Public Function findWineItem(searchForString As String, searchType As String, currentIndex As Integer) As Boolean
        findWineItem = False
        Dim searchWineItem As WineItem = wineCollection(currentIndex)
        Dim propertyValue As String = searchWineItem.GetType().GetProperty(searchType).GetValue(searchWineItem).ToString().ToLower()
        If propertyValue.Contains(searchForString.ToLower) Then
            findWineItem = True
        End If

        '******Specific case to do the search - easier to read, but repeats code and if more fields added would have to be updated
        'Select Case searchType
        '    Case NameOf(WineItem.id)
        '        If wineCollection(currentIndex).id.ToLower.Contains(searchForString.ToLower) Then
        '            findWineItem = True
        '        End If
        '    Case NameOf(WineItem.description)
        '        If wineCollection(currentIndex).description.ToLower.Contains(searchForString.ToLower) Then
        '            findWineItem = True
        '        End If
        '    Case NameOf(WineItem.pack)
        '        If wineCollection(currentIndex).pack.ToLower.Contains(searchForString.ToLower) Then
        '            findWineItem = True
        '        End If
        'End Select
    End Function

    ''' <summary>
    ''' Initailize the size of the collection upon creation of the WineCollection
    ''' </summary>
    Public Sub New()
        _wineCollectionSize = 0
    End Sub
End Class
