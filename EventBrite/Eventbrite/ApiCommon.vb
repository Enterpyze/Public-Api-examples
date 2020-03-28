Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class ApiCommon

#Region "Declarations"
    Private oFuncs As New Funcs
#End Region
    Public Function ParseConnectApiResponse(ByVal apiType As Integer, ByVal result As HttpResponse) As Boolean
        Try
            Dim response As JObject = JsonConvert.DeserializeObject(result.ResponseBody)
            Select Case result.StatusCode
                Case HttpStatusCode.OK
                    If apiType = 0 Then
                        If response.Item("surferAuth") IsNot Nothing Then
                            sEntSurferAuth = response.Item("surferAuth").ToString()
                        End If
                        If response.Item("surferOrganisationId") IsNot Nothing Then
                            sEntSurferOrganisationId = response.Item("surferOrganisationId").ToString()
                        End If
                    Else
                        If response.Item("name") IsNot Nothing Then
                            sEvntUser = response.Item("name").ToString()
                        End If
                        If response.Item("emails") IsNot Nothing Then
                            Dim emailsJson As JArray = response.Item("emails")
                            Dim emailList As List(Of Info_EventbriteUserEmail) = emailsJson.ToObject(Of List(Of Info_EventbriteUserEmail))
                            For Each email As Info_EventbriteUserEmail In emailList
                                If email.primary Then
                                    sEvntEmail = email.email
                                    Exit For
                                End If
                            Next
                        End If
                    End If
                    Return True
                Case Else
                    Dim sCaption As String = sAppName
                    Dim sError As String = String.Empty
                    If apiType = 0 Then
                        sCaption += " - Enterpryze Error"
                        If response.Item("enterpryzeError") IsNot Nothing Then
                            Dim enterpryzeError As JToken = response.Item("enterpryzeError")
                            If enterpryzeError.Item("errorCode") IsNot Nothing Then
                                sError = enterpryzeError.Item("errorCode").ToString()
                            End If
                            If enterpryzeError.Item("message") IsNot Nothing Then
                                sError += " - " + enterpryzeError.Item("message").ToString()
                            End If
                        End If
                    Else
                        sCaption += " - Eventbrite Error"
                        If response.Item("error") IsNot Nothing Then
                            sError = response.Item("error").ToString()
                        End If
                        If response.Item("error_description") IsNot Nothing Then
                            sError += " - " + response.Item("error_description").ToString()
                        End If
                    End If
                    MessageBox.Show(sError, sCaption)
                    Return False
            End Select

        Catch ex As Exception
            oFuncs.ErrorLog(ex.Message.ToString, ex.StackTrace)
            Return False
        End Try
    End Function

    Public Function ParseEventbriteApiResponse(ByVal apiType As Integer, ByVal result As HttpResponse) As Boolean
        Try
            Dim response As JObject = JsonConvert.DeserializeObject(result.ResponseBody)
            Select Case result.StatusCode
                Case HttpStatusCode.OK
                    If apiType = 0 Then
                        If response.Item("surferAuth") IsNot Nothing Then
                            sEntSurferAuth = response.Item("surferAuth").ToString()
                        End If
                        If response.Item("surferOrganisationId") IsNot Nothing Then
                            sEntSurferOrganisationId = response.Item("surferOrganisationId").ToString()
                        End If
                    Else
                        If response.Item("name") IsNot Nothing Then
                            sEvntUser = response.Item("name").ToString()
                        End If
                        If response.Item("emails") IsNot Nothing Then
                            Dim emailsJson As JArray = response.Item("emails")
                            Dim emailList As List(Of Info_EventbriteUserEmail) = emailsJson.ToObject(Of List(Of Info_EventbriteUserEmail))
                            Dim email As Info_EventbriteUserEmail
                            For Each email In emailList
                                If email.primary Then
                                    sEvntEmail = email.email
                                    Exit For
                                End If
                            Next
                        End If
                    End If
                    Return True
                Case Else
                    Dim sCaption As String = sAppName
                    Dim sError As String = String.Empty
                    If apiType = 0 Then
                        sCaption += " - Enterpryze Error"
                        If response.Item("enterpryzeError") IsNot Nothing Then
                            Dim enterpryzeError As JToken = response.Item("enterpryzeError")
                            If enterpryzeError.Item("errorCode") IsNot Nothing Then
                                sError = enterpryzeError.Item("errorCode").ToString()
                            End If
                            If enterpryzeError.Item("message") IsNot Nothing Then
                                sError += " - " + enterpryzeError.Item("message").ToString()
                            End If
                        End If
                    Else
                        sCaption += " - Eventbrite Error"
                        If response.Item("error") IsNot Nothing Then
                            sError = response.Item("error").ToString()
                        End If
                        If response.Item("error_description") IsNot Nothing Then
                            sError += " - " + response.Item("error_description").ToString()
                        End If
                    End If
                    MessageBox.Show(sError, sCaption)
                    Return False
            End Select

        Catch ex As Exception
            oFuncs.ErrorLog(ex.Message.ToString, ex.StackTrace)
            Return False
        End Try
    End Function

    Public Function ParseEnterpryzeError(ByVal responseBody As JObject)
        Dim sError As String = String.Empty

        If responseBody.Item("error") IsNot Nothing Then
            sError = responseBody.Item("error").ToString()
            If responseBody.Item("error_description") IsNot Nothing Then
                sError += " - " + responseBody.Item("error_description").ToString()
            End If
        ElseIf responseBody.Item("enterpryzeError") IsNot Nothing Then
            Dim enterpryzeError As JObject = responseBody.Item("enterpryzeError")
            If enterpryzeError.Item("errorCode") IsNot Nothing Then
                sError = enterpryzeError.Item("errorCode").ToString()
            End If
            If enterpryzeError.Item("parameters") IsNot Nothing Then
                Dim parameters As JArray = enterpryzeError.Item("parameters")
                Dim errParams = parameters.ToObject(Of List(Of Info_EntIntegrationErrorParameter))
                If errParams IsNot Nothing AndAlso errParams.Count > 0 Then
                    sError += ": " + errParams.Item(0).value
                End If
            End If
        End If

        Return sError
    End Function

End Class
