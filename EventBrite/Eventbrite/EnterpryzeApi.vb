Option Explicit On

Imports System.Text
Imports System.Net.Http
Imports Newtonsoft.Json
Imports System.IO

Public Class EnterpryzeApi

#Region "Declarations"
    Private oFuncs As New Funcs
#End Region

    Private sEnvironmentType As String
    Private sEmail As String
    Private sPassword As String

    Public Sub New(ByVal entEnvironmentType As String, ByVal entEmail As String, ByVal entPassword As String)
        sEnvironmentType = entEnvironmentType
        sEmail = entEmail
        sPassword = entPassword
    End Sub

    Public Async Function Authenticate() As Task(Of HttpResponse)

        Dim apiUrl = GetApiBaseUrl() + "/authenticate"
        Dim dict As New Dictionary(Of String, String) From {
            {"username", sEmail},
            {"password", sPassword}
        }
        Dim json As String = JsonConvert.SerializeObject(dict, Formatting.Indented)
        Dim httpContent As HttpContent = New StringContent(json, Encoding.UTF8, "application/json")

        Using client As HttpClient = New HttpClient()
            client.DefaultRequestHeaders.Clear()
            client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/json"))

            Dim response As HttpResponseMessage = Await client.PostAsync(apiUrl, httpContent)

            Dim result As New HttpResponse()
            result.StatusCode = response.StatusCode
            result.StatusDescription = response.ReasonPhrase
            result.ResponseBody = response.Content.ReadAsStringAsync().Result

            Return result
        End Using

    End Function

    Public Async Function GetBPList() As Task(Of HttpResponse)

        Dim apiUrl = GetApiBaseUrl() + "/business-partner"

        Using client As HttpClient = New HttpClient()
            client.DefaultRequestHeaders.Clear()
            client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/json"))
            client.DefaultRequestHeaders.Add("surferAuth", sEntSurferAuth)
            client.DefaultRequestHeaders.Add("surferOrganisationId", sEntSurferOrganisationId)

            Dim response As HttpResponseMessage = Await client.GetAsync(apiUrl)

            Dim result As New HttpResponse()
            result.StatusCode = response.StatusCode
            result.StatusDescription = response.ReasonPhrase
            result.ResponseBody = response.Content.ReadAsStringAsync().Result

            Return result
        End Using

    End Function

    Public Async Function CreateBusinessPartner(data As Info_EntBusinessPartner) As Task(Of HttpResponse)

        Dim apiUrl = GetApiBaseUrl() + "/business-partner"
        Dim sb As New StringBuilder()
        Dim sw As New StringWriter(sb)
        Using jw As JsonTextWriter = New JsonTextWriter(sw)
            jw.Formatting = Formatting.Indented
            jw.WriteStartObject()

            jw.WritePropertyName("cardCode")
            jw.WriteValue(data.cardCode)
            jw.WritePropertyName("name")
            jw.WriteValue(data.name)
            jw.WritePropertyName("contactType")
            jw.WriteValue("Customer")
            If data.currency <> "" Then
                jw.WritePropertyName("currency")
                jw.WriteValue(data.currency)
            End If
            jw.WritePropertyName("email")
            jw.WriteValue(data.email)

            jw.WriteEndObject()

        End Using

        Dim httpContent As HttpContent = New StringContent(sb.ToString(), Encoding.UTF8, "application/json")

        Using client As HttpClient = New HttpClient()
            client.DefaultRequestHeaders.Clear()
            client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/json"))
            httpContent.Headers.Add("surferAuth", sEntSurferAuth)
            httpContent.Headers.Add("surferOrganisationId", sEntSurferOrganisationId)

            Dim response As HttpResponseMessage = Await client.PostAsync(apiUrl, httpContent)

            Dim result As New HttpResponse()
            result.StatusCode = response.StatusCode
            result.StatusDescription = response.ReasonPhrase
            result.ResponseBody = response.Content.ReadAsStringAsync().Result

            Return result
        End Using

    End Function
    Public Async Function CreateSalesInvoice(data As Info_ImportData) As Task(Of HttpResponse)

        Dim dt As Date = Date.Today

        Dim apiUrl = GetApiBaseUrl() + "/sales/invoice"
        Dim sb As New StringBuilder()
        Dim sw As New StringWriter(sb)
        Using jw As JsonTextWriter = New JsonTextWriter(sw)
            jw.Formatting = Formatting.Indented
            jw.WriteStartObject()

            jw.WritePropertyName("docType")
            jw.WriteValue("I")
            jw.WritePropertyName("cardCode")
            jw.WriteValue(data.entDocBpCode)
            jw.WritePropertyName("docDate")
            jw.WriteValue(dt.ToString("yyyy-MM-dd"))
            jw.WritePropertyName("dueDate")
            jw.WriteValue(dt.ToString("yyyy-MM-dd"))
            jw.WritePropertyName("currency")
            jw.WriteValue(data.orderCurrency)
            jw.WritePropertyName("customerReferenceNumber")
            jw.WriteValue(data.orderId)
            jw.WritePropertyName("comments")
            jw.WriteValue("Order Id: " + data.orderId)

            jw.WritePropertyName("items")
            jw.WriteStartArray()
            For Each line In data.lines
                jw.WriteStartObject()
                jw.WritePropertyName("itemCode")
                jw.WriteValue(line.itemCode)
                jw.WritePropertyName("itemDetails")
                jw.WriteValue(line.itemDetails)
                jw.WritePropertyName("freeText")
                jw.WriteValue(line.freeText)
                jw.WritePropertyName("quantity")
                jw.WriteValue(line.quantity)
                jw.WritePropertyName("warehouseCode")
                jw.WriteValue("01")
                jw.WritePropertyName("currency")
                jw.WriteValue(data.orderCurrency)
                'jw.WritePropertyName("vatCode")
                'jw.WriteValue("X0")
                'jw.WritePropertyName("priceBeforeDiscount")
                'jw.WriteValue(line.price)
                jw.WritePropertyName("priceAfterVat")
                jw.WriteValue(line.priceAfterVat)
                jw.WriteEndObject()
            Next
            jw.WriteEndArray()

            jw.WriteEndObject()

        End Using

        Dim httpContent As HttpContent = New StringContent(sb.ToString(), Encoding.UTF8, "application/json")

        Using client As HttpClient = New HttpClient()
            client.DefaultRequestHeaders.Clear()
            client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/json"))
            httpContent.Headers.Add("surferAuth", sEntSurferAuth)
            httpContent.Headers.Add("surferOrganisationId", sEntSurferOrganisationId)

            Dim response As HttpResponseMessage = Await client.PostAsync(apiUrl, httpContent)

            Dim result As New HttpResponse()
            result.StatusCode = response.StatusCode
            result.StatusDescription = response.ReasonPhrase
            result.ResponseBody = response.Content.ReadAsStringAsync().Result

            Return result
        End Using

    End Function

    Public Async Function CreateIncomingPayment(data As Info_ImportData, paidDocumentDocEntry As Integer) As Task(Of HttpResponse)

        Dim dt As Date = Date.Today

        Dim apiUrl = GetApiBaseUrl() + "/payment/incoming"
        Dim sb As New StringBuilder()
        Dim sw As New StringWriter(sb)
        Using jw As JsonTextWriter = New JsonTextWriter(sw)
            jw.Formatting = Formatting.Indented
            jw.WriteStartObject()

            jw.WritePropertyName("docType")
            jw.WriteValue("C")
            jw.WritePropertyName("contactId")
            jw.WriteValue("contact_" + data.entDocBpCode)
            jw.WritePropertyName("docDate")
            jw.WriteValue(dt.ToString("yyyy-MM-dd"))
            jw.WritePropertyName("transferDate")
            jw.WriteValue(dt.ToString("yyyy-MM-dd"))
            jw.WritePropertyName("transferAccount")
            jw.WriteValue("161000")
            jw.WritePropertyName("transferSum")
            jw.WriteValue(data.orderTotalValue)
            jw.WritePropertyName("reference")
            jw.WriteValue("EVENT")
            jw.WritePropertyName("journalRemarks")
            jw.WriteValue(data.orderId)
            jw.WritePropertyName("comments")
            jw.WriteValue("Order Id: " + data.orderId)

            jw.WritePropertyName("documents")
            jw.WriteStartArray()
            jw.WriteStartObject()
            jw.WritePropertyName("documentType")
            jw.WriteValue("SalesInvoice")
            jw.WritePropertyName("documentDocEntry")
            jw.WriteValue(paidDocumentDocEntry)
            jw.WritePropertyName("amount")
            jw.WriteValue(data.orderTotalValue)
            jw.WriteEndObject()
            jw.WriteEndArray()

            jw.WriteEndObject()

        End Using

        Dim httpContent As HttpContent = New StringContent(sb.ToString(), Encoding.UTF8, "application/json")

        Using client As HttpClient = New HttpClient()
            client.DefaultRequestHeaders.Clear()
            client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/json"))
            httpContent.Headers.Add("surferAuth", sEntSurferAuth)
            httpContent.Headers.Add("surferOrganisationId", sEntSurferOrganisationId)

            Dim response As HttpResponseMessage = Await client.PostAsync(apiUrl, httpContent)

            Dim result As New HttpResponse()
            result.StatusCode = response.StatusCode
            result.StatusDescription = response.ReasonPhrase
            result.ResponseBody = response.Content.ReadAsStringAsync().Result

            Return result
        End Using

    End Function

    Private Function GetApiBaseUrl() As String
        ''[TESTING]
        'Return "http://localhost:9096/public/v1"
        Select Case sEntEnvironmentType
            Case EnterpryzeEnvTypeTest
                Return "https://api-test.enterpryze.com/public/v1"
            Case EnterpryzeEnvTypeStaging
                Return "https://api-staging.enterpryze.com/public/v1"
            Case EnterpryzeEnvTypeLive
                Return "https://api.enterpryze.com/public/v1"
            Case Else
                Return "https://api-staging.enterpryze.com/public/v1"
        End Select
    End Function

End Class
