Public Class Info_EventbriteEventName

    Private _text As String
    Private _html As String

    Public Property text() As String
        Get
            Return _text
        End Get
        Set(ByVal value As String)
            _text = value
        End Set
    End Property

    Public Property html() As String
        Get
            Return _html
        End Get
        Set(ByVal value As String)
            _html = value
        End Set
    End Property

End Class
