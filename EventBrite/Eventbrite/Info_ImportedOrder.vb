Public Class Info_ImportedOrder

    Private _id As String
    Public Property id() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property

    Private _eventId As String
    Public Property eventId() As String
        Get
            Return _eventId
        End Get
        Set(ByVal value As String)
            _eventId = value
        End Set
    End Property

    Private _name As String
    Public Property name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    Private _email As String
    Public Property email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property

    Private _organisationId As String
    Public Property organisationId() As String
        Get
            Return _organisationId
        End Get
        Set(ByVal value As String)
            _organisationId = value
        End Set
    End Property

    Public Sub New(ByVal id As String, ByVal eventId As String, ByVal name As String, ByVal email As String, ByVal organisationId As String)
        Me._id = id
        Me._eventId = eventId
        Me._name = name
        Me._email = email
        Me._organisationId = organisationId
    End Sub

End Class
