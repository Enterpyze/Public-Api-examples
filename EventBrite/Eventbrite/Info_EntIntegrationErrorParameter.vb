Public Class Info_EntIntegrationErrorParameter

    Private _name As String
    Public Property name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    Private _value As String
    Public Property value() As String
        Get
            Return _value
        End Get
        Set(ByVal value As String)
            _value = value
        End Set
    End Property

    Private _dataType As Object
    Public Property dataType() As Object
        Get
            Return _dataType
        End Get
        Set(ByVal value As Object)
            _dataType = value
        End Set
    End Property

End Class
