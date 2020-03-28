Public Class Info_EntBusinessPartner

    Private _index As Integer
    Public Property bpIndex() As Integer
        Get
            Return _index
        End Get
        Set(ByVal value As Integer)
            _index = value
        End Set
    End Property

    Private _cardCode As String
    Public Property cardCode() As String
        Get
            Return _cardCode
        End Get
        Set(ByVal value As String)
            _cardCode = value
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

    Private _currency As String
    Public Property currency() As String
        Get
            Return _currency
        End Get
        Set(ByVal value As String)
            _currency = value
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

    Public Sub New(ByVal index As Integer, ByVal cardCode As String, ByVal name As String, ByVal currency As String, ByVal email As String)
        Me._index = index
        Me._cardCode = cardCode
        Me._name = name
        Me._currency = currency
        Me._email = email
    End Sub
End Class
