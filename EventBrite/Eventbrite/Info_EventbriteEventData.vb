Public Class Info_EventbriteEventData

    Private _eventIndex As Integer
    Private _eventId As String
    Private _eventName As String

    Public Property EventIndex() As Integer
        Get
            Return _eventIndex
        End Get
        Set(ByVal value As Integer)
            _eventIndex = value
        End Set
    End Property

    Public Property EventId() As String
        Get
            Return _eventId
        End Get
        Set(ByVal value As String)
            _eventId = value
        End Set
    End Property

    Public Property EventName() As String
        Get
            Return _eventName
        End Get
        Set(ByVal value As String)
            _eventName = value
        End Set
    End Property

    Public Sub New(ByVal eventindex As Integer, ByVal eventid As String, ByVal eventname As String)
        Me._eventIndex = eventindex
        Me._eventId = eventid
        Me._eventName = eventname
    End Sub

End Class
