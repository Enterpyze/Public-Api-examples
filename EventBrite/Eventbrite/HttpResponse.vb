Imports System.Net

Public Class HttpResponse

    Private _statusCode As HttpStatusCode
    Private _statusDescription As String
    Private _responseBody As String

    Public Property StatusCode() As HttpStatusCode
        Get
            Return _statusCode
        End Get
        Set(ByVal value As HttpStatusCode)
            _statusCode = value
        End Set
    End Property

    Public Property StatusDescription() As String
        Get
            Return _statusDescription
        End Get
        Set(ByVal value As String)
            _statusDescription = value
        End Set
    End Property

    Public Property ResponseBody() As String
        Get
            Return _responseBody
        End Get
        Set(ByVal value As String)
            _responseBody = value
        End Set
    End Property

End Class
