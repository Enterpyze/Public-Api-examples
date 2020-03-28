Public Class Info_ImportData

    Private _eventId As String
    Private _eventName As String
    Private _orderId As String
    Private _orderEmail As String
    Private _orderName As String
    Private _orderCurrency As String
    Private _orderTotalValue As Double

    Private _entDocType As String
    Private _entDocBpCode As String
    Private _entDocBpName As String
    'Private _entCreateBP As Boolean
    Private _entDocEntry As Integer
    Private _entDocNum As Integer
    Private _entDocDate As String
    Private _entDocCur As String
    Private _entDocTax As Double
    Private _entDocTotal As Double
    Private _entDocRem As String
    Private _entDocError As String

    Public Property eventId() As String
        Get
            Return _eventId
        End Get
        Set(ByVal value As String)
            _eventId = value
        End Set
    End Property

    Public Property eventName() As String
        Get
            Return _eventName
        End Get
        Set(ByVal value As String)
            _eventName = value
        End Set
    End Property

    Public Property orderId() As String
        Get
            Return _orderId
        End Get
        Set(ByVal value As String)
            _orderId = value
        End Set
    End Property

    Public Property orderEmail() As String
        Get
            Return _orderEmail
        End Get
        Set(ByVal value As String)
            _orderEmail = value
        End Set
    End Property

    Public Property orderName() As String
        Get
            Return _orderName
        End Get
        Set(ByVal value As String)
            _orderName = value
        End Set
    End Property

    Public Property orderCurrency() As String
        Get
            Return _orderCurrency
        End Get
        Set(ByVal value As String)
            _orderCurrency = value
        End Set
    End Property

    Public Property orderTotalValue() As Double
        Get
            Return _orderTotalValue
        End Get
        Set(ByVal value As Double)
            _orderTotalValue = value
        End Set
    End Property

    Public Property entDocType() As String
        Get
            Return _entDocType
        End Get
        Set(ByVal value As String)
            _entDocType = value
        End Set
    End Property

    Public Property entDocBpCode() As String
        Get
            Return _entDocBpCode
        End Get
        Set(ByVal value As String)
            _entDocBpCode = value
        End Set
    End Property

    Public Property entDocBpName() As String
        Get
            Return _entDocBpName
        End Get
        Set(ByVal value As String)
            _entDocBpName = value
        End Set
    End Property

    'Public Property entCreateBP() As Boolean
    '    Get
    '        Return _entCreateBP
    '    End Get
    '    Set(ByVal value As Boolean)
    '        _entCreateBP = value
    '    End Set
    'End Property

    Public Property entDocEntry() As Integer
        Get
            Return _entDocEntry
        End Get
        Set(ByVal value As Integer)
            _entDocEntry = value
        End Set
    End Property

    Public Property entDocNum() As Integer
        Get
            Return _entDocNum
        End Get
        Set(ByVal value As Integer)
            _entDocNum = value
        End Set
    End Property

    Public Property entDocDate() As String
        Get
            Return _entDocDate
        End Get
        Set(ByVal value As String)
            _entDocDate = value
        End Set
    End Property

    Public Property entDocCur() As String
        Get
            Return _entDocCur
        End Get
        Set(ByVal value As String)
            _entDocCur = value
        End Set
    End Property

    Public Property entDocTax() As Double
        Get
            Return _entDocTax
        End Get
        Set(ByVal value As Double)
            _entDocTax = value
        End Set
    End Property

    Public Property entDocTotal() As Double
        Get
            Return _entDocTotal
        End Get
        Set(ByVal value As Double)
            _entDocTotal = value
        End Set
    End Property

    Public Property entDocRem() As String
        Get
            Return _entDocRem
        End Get
        Set(ByVal value As String)
            _entDocRem = value
        End Set
    End Property

    Public Property entDocError() As String
        Get
            Return _entDocError
        End Get
        Set(ByVal value As String)
            _entDocError = value
        End Set
    End Property

    Private _lines As New List(Of Info_ImportDataLine)
    Public ReadOnly Property lines() As List(Of Info_ImportDataLine)
        Get
            Return _lines
        End Get
    End Property

    Public Sub New(ByVal eventId As String, ByVal eventName As String,
                   ByVal orderId As String, ByVal orderEmail As String, ByVal orderName As String, ByVal orderCurrency As String, ByVal orderTotalValue As Double,
                   ByVal entDocType As String,
                   ByVal entDocBpCode As String, ByVal entDocBpName As String,
                   ByVal entDocEntry As Integer, ByVal entDocNum As Integer, ByVal entDocDate As String,
                   ByVal entDocCur As String, ByVal entDocTax As Double, ByVal entDocTotal As Double, ByVal entDocRem As String,
                   ByVal entDocError As String, ByVal lines As List(Of Info_ImportDataLine))

        Me._eventId = eventId
        Me._eventName = eventName
        Me._orderId = orderId
        Me._orderEmail = orderEmail
        Me._orderName = orderName
        Me._orderCurrency = orderCurrency
        Me._orderTotalValue = orderTotalValue

        Me._entDocType = entDocType
        Me._entDocBpCode = entDocBpCode
        Me._entDocBpName = entDocBpName
        Me._entDocEntry = entDocEntry
        Me._entDocNum = entDocNum
        Me._entDocDate = entDocDate
        Me._entDocCur = entDocCur
        Me._entDocTax = entDocTax
        Me._entDocTotal = entDocTotal
        Me._entDocRem = entDocRem
        Me._entDocError = entDocError

        If lines IsNot Nothing Then
            For Each l In lines
                _lines.Add(l)
            Next
        End If
    End Sub

    Public Class Info_ImportDataLine

        Private _itemCode As String
        Public Property itemCode() As String
            Get
                Return _itemCode
            End Get
            Set(ByVal value As String)
                _itemCode = value
            End Set
        End Property

        Private _itemDetails As String
        Public Property itemDetails() As String
            Get
                Return _itemDetails
            End Get
            Set(ByVal value As String)
                _itemDetails = value
            End Set
        End Property

        Private _freeText As String
        Public Property freeText() As String
            Get
                Return _freeText
            End Get
            Set(ByVal value As String)
                _freeText = value
            End Set
        End Property

        Private _quantity As Integer
        Public Property quantity() As Integer
            Get
                Return _quantity
            End Get
            Set(ByVal value As Integer)
                _quantity = value
            End Set
        End Property

        Private _priceAfterVat As Double
        Public Property priceAfterVat() As Double
            Get
                Return _priceAfterVat
            End Get
            Set(ByVal value As Double)
                _priceAfterVat = value
            End Set
        End Property

        Public Sub New(ByVal itemCode As String, ByVal itemDetails As String, ByVal freeText As String, ByVal quantity As Integer, ByVal priceAfterVat As Double)
            Me._itemCode = itemCode
            Me._itemDetails = itemDetails
            Me._freeText = freeText
            Me._quantity = quantity
            Me._priceAfterVat = priceAfterVat
        End Sub
    End Class

End Class
