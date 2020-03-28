Public Class Info_EventbriteEvent

    Private _id As String
    Private _name As New Info_EventbriteEventName
    Private _organization_id As String
    Private _status As String
    Private _currency As String

    Public Property id() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property

    Public ReadOnly Property name() As Info_EventbriteEventName
        Get
            Return _name
        End Get
    End Property

    Public Property organization_id() As String
        Get
            Return _organization_id
        End Get
        Set(ByVal value As String)
            _organization_id = value
        End Set
    End Property

    Public Property status() As String
        Get
            Return _status
        End Get
        Set(ByVal value As String)
            _status = value
        End Set
    End Property

    Public Property currency() As String
        Get
            Return _currency
        End Get
        Set(ByVal value As String)
            _currency = value
        End Set
    End Property

    Public Sub New(ByVal id As String, ByVal name As Info_EventbriteEventName, ByVal organization_id As String, ByVal status As String, ByVal currency As String)
        Me._id = id
        Me._name = name
        Me._organization_id = organization_id
        Me._status = status
        Me._currency = currency
    End Sub

End Class
