Public Class WineItem
    Private _id, _description, _pack As String

    Property id As String
        Get
            Return _id
        End Get
        Set(value As String)
            _id = value
        End Set
    End Property

    Property description As String
        Get
            Return _description
        End Get
        Set(value As String)
            _description = value
        End Set
    End Property

    Property pack As String
        Get
            Return _pack
        End Get
        Set(value As String)
            _pack = value
        End Set
    End Property

    Public Sub New(id As String, description As String, pack As String)
        _id = id
        _description = description
        _pack = pack
    End Sub

End Class
