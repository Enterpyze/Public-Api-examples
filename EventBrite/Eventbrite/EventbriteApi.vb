Option Explicit On

Imports System.Text
Imports System.Net.Http

Public Class EventbriteApi
#Region "Declarations"
    Private oFuncs As New Funcs
#End Region

    Public Async Function GetApiCall(ByVal url As String, Optional ByVal queryParams As Dictionary(Of String, String) = Nothing) As Task(Of HttpResponse)

        Dim query As String = String.Empty
        If queryParams IsNot Nothing Then
            Dim content As FormUrlEncodedContent = New FormUrlEncodedContent(queryParams)
            query = "?" + content.ReadAsStringAsync().Result
        End If

        url += query
        Using client As HttpClient = New HttpClient()
            client.DefaultRequestHeaders.Clear()
            client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/json"))

            Dim response As HttpResponseMessage = Await client.GetAsync(url)

            Dim result As New HttpResponse()
            result.StatusCode = response.StatusCode
            result.StatusDescription = response.ReasonPhrase
            result.ResponseBody = response.Content.ReadAsStringAsync().Result

            Return result
        End Using

    End Function

End Class
