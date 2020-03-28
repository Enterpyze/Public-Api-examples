Public Class Info_EventbriteUserEmail

    Private _email As String
    Private _verified As String
    Private _primary As Boolean

    Public Property email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property

    Public Property verified() As String
        Get
            Return _verified
        End Get
        Set(ByVal value As String)
            _verified = value
        End Set
    End Property

    Public Property primary() As Boolean
        Get
            Return _primary
        End Get
        Set(ByVal value As Boolean)
            _primary = value
        End Set
    End Property

End Class
