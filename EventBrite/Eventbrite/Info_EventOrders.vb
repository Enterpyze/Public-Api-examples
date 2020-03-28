Public Class Info_EventOrders

    Public Class Rootobject
        Public Property pagination As Pagination
        Public Property orders As List(Of Order)
    End Class

    Public Class Pagination
        Public Property object_count As Integer
        Public Property page_number As Integer
        Public Property page_size As Integer
        Public Property page_count As Integer
        Public Property has_more_items As Boolean
    End Class

    Public Class Order
        Public Property costs As Costs
        Public Property resource_uri As String
        Public Property id As String
        Public Property changed As Date
        Public Property created As Date
        Public Property name As String
        Public Property first_name As String
        Public Property last_name As String
        Public Property email As String
        Public Property status As String
        Public Property time_remaining As Object
        Public Property event_id As String
        Public Property attendees As List(Of Attendee)
    End Class

    Public Class Costs
        Public Property base_price As Base_Price
        Public Property eventbrite_fee As Eventbrite_Fee
        Public Property gross As Gross
        Public Property payment_fee As Payment_Fee
        Public Property tax As Tax
        Public Property fee_components As List(Of Object)
        Public Property tax_components As List(Of Object)
        Public Property has_gts_tax As Boolean
    End Class

    Public Class Base_Price
        Public Property display As String
        Public Property currency As String
        Public Property value As Double
        Public Property major_value As String
    End Class

    Public Class Eventbrite_Fee
        Public Property display As String
        Public Property currency As String
        Public Property value As Double
        Public Property major_value As String
    End Class

    Public Class Gross
        Public Property display As String
        Public Property currency As String
        Public Property value As Double
        Public Property major_value As String
    End Class

    Public Class Payment_Fee
        Public Property display As String
        Public Property currency As String
        Public Property value As Double
        Public Property major_value As String
    End Class

    Public Class Tax
        Public Property display As String
        Public Property currency As String
        Public Property value As Double
        Public Property major_value As String
    End Class

    Public Class Attendee
        Public Property team As String
        Public Property costs As Costs
        Public Property resource_uri As String
        Public Property id As String
        Public Property changed As Date
        Public Property created As Date
        Public Property quantity As Integer
        Public Property variant_id As String
        Public Property profile As Profile
        Public Property barcodes As List(Of BarCode)
        Public Property answers() As Object
        Public Property checked_in As Boolean
        Public Property cancelled As Boolean
        Public Property refunded As Boolean
        Public Property affiliate As String
        Public Property guestlist_id As String
        Public Property invited_by As String
        Public Property status As String
        Public Property ticket_class_name As String
        Public Property delivery_method As String
        Public Property event_id As String
        Public Property order_id As String
        Public Property ticket_class_id As String
    End Class

    Public Class Profile
        Public Property first_name As String
        Public Property last_name As String
        Public Property email As String
        Public Property name As String
        Public Property addresses As Object
    End Class

    Public Class BarCode
        Public Property status As String
        Public Property barcode As String
        Public Property created As Date
        Public Property changed As Date
        Public Property checkin_type As Integer
        Public Property is_printed As Boolean
    End Class
End Class
