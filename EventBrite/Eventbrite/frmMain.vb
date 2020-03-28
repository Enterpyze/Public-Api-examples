Option Explicit Off

Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Xml.Linq

Public Class frmMain

#Region "Declarations"
    Private oFuncs As New Funcs
    Private apiCommon As New ApiCommon
    Private eventbriteApi As EventbriteApi
    Private enterpryzeApi As EnterpryzeApi
    Private EntDefaultBPs As New List(Of Info_EntBusinessPartner)
    Private EventListData As New List(Of Info_EventbriteEventData)
    Private EventOrders As New List(Of Info_EventOrders.Order)
    Private ImportedOrders As New List(Of Info_ImportedOrder)
    Private ImportResults As New List(Of Info_ImportData)
    Dim xDocConfigTemplate As New XDocument
    Dim xDocImportedOrders As New XDocument
#End Region

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        End
    End Sub

    Private Sub chkEventTokenShow_CheckedChanged(sender As Object, e As EventArgs) Handles chkEvntTokenShow.CheckedChanged
        txtEvntToken.UseSystemPasswordChar = Not chkEvntTokenShow.Checked
    End Sub

    Private Sub chkEntPwdShow_CheckedChanged(sender As Object, e As EventArgs) Handles chkEntPwdShow.CheckedChanged
        txtEntPassword.UseSystemPasswordChar = Not chkEntPwdShow.Checked
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        sAppPath = Path.GetDirectoryName(Reflection.Assembly.GetExecutingAssembly.Location()) & "\"
        btnGetEvents.Enabled = False
        btnGetOrders.Enabled = False
        btnImport.Enabled = False
        chkIncludeFee.Checked = True
        chkCreateBP.Checked = False

        'Dim sInstructions = String.Empty
        'sInstructions = "1. Enter credentials - Connect." & vbCrLf
        'sInstructions &= "2. Get Events - select Event." & vbCrLf
        'sInstructions &= "3. Get Orders - select Order(s)." & vbCrLf
        'sInstructions &= "4. Import."
        'lblInstructions.Text = sInstructions

        PopulateDefaults()
        DefineGridColumnsOrders()
        DefineGridColumnsResults()
        cboEntEnvType.SelectedIndex = 1
        txtEvntToken.Select()

    End Sub

    Private Sub PopulateDefaults()

        Dim sTemplatePath = Path.Combine(sAppPath, "Config.xml")
        If Not File.Exists(sTemplatePath) Then
            MessageBox.Show("Config.xml not found: " & sNewLine & sNewLine & sTemplatePath & sNewLine & sNewLine & "Closing application.", sAppName & " - Error")
            End
        End If
        xDocConfigTemplate = XDocument.Load(sTemplatePath)

        Dim sImportedOrdersPath = Path.Combine(sAppPath, "ImportedOrders.xml")
        If File.Exists(sImportedOrdersPath) Then
            bImportedOrdersFileExists = True
            xDocImportedOrders = XDocument.Load(sImportedOrdersPath)
        End If

        sEvntToken = My.Settings.EvntToken.Trim
        sEntEnvironmentType = My.Settings.EntEnvType.Trim
        sEntEmail = My.Settings.EntEmail.Trim
        sEntPassword = My.Settings.EntPassword.Trim
        bEntIncludeFee = My.Settings.EntIncludeFee
        bEntCreateBP = My.Settings.EntCreateBP
        sEntDefaultBP = My.Settings.EntDefaultBP.Trim
        bIgnoreImportedOrders = My.Settings.EvntIgnoreImported

        txtEvntToken.Text = sEvntToken
        txtEntEmail.Text = sEntEmail
        txtEntPassword.Text = sEntPassword
        chkIncludeFee.Checked = bEntIncludeFee
        chkCreateBP.Checked = bEntCreateBP
        chkIgnoreImported.Checked = bIgnoreImportedOrders

        cboEntEnvType.Items.Add(EnterpryzeEnvTypeTest)
        cboEntEnvType.Items.Add(EnterpryzeEnvTypeStaging)
        cboEntEnvType.Items.Add(EnterpryzeEnvTypeLive)

        Try
            If sEntEnvironmentType <> "" Then
                For counter As Integer = 0 To cboEntEnvType.Items.Count
                    If cboEntEnvType.Items(counter).ToString = sEntEnvironmentType Then
                        cboEntEnvType.SelectedIndex = counter
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        Connect()
    End Sub

    Private Async Sub Connect()
        Try
            If txtEvntToken.Text.ToString.Trim = "" Then
                MessageBox.Show("Please enter Eventbrite OAuth Token.", sAppName)
                Exit Try
            End If
            If cboEntEnvType.SelectedItem.ToString.Trim = "" Then
                MessageBox.Show("Please select Enterpryze Environment.", sAppName)
                Exit Try
            End If
            If txtEntEmail.Text.ToString.Trim = "" Then
                MessageBox.Show("Please enter Enterpryze User.", sAppName)
                Exit Try
            End If
            If txtEntPassword.Text.ToString.Trim = "" Then
                MessageBox.Show("Please enter Enterpryze Password.", sAppName)
                Exit Try
            End If

            sEvntToken = txtEvntToken.Text.ToString.Trim
            sEntEnvironmentType = cboEntEnvType.SelectedItem.ToString.Trim
            sEntEmail = txtEntEmail.Text.ToString.Trim
            sEntPassword = txtEntPassword.Text.ToString.Trim
            btnGetEvents.Enabled = False
            btnGetOrders.Enabled = False

            lblStatus.Text = "Connecting to Eventbrite..."

            Me.Cursor = Cursors.WaitCursor

            'Clear values.
            txtEvntUser.Text = ""
            txtEvntEmail.Text = ""
            txtEntOrgId.Text = ""
            sEvntUser = ""
            sEvntEmail = ""
            sEntSurferAuth = ""
            sEntSurferOrganisationId = ""

            Dim apiResult As HttpResponse

            eventbriteApi = New EventbriteApi()
            Dim queryParams As New Dictionary(Of String, String) From {{"token", sEvntToken}}
            apiResult = Await eventbriteApi.GetApiCall(sEventbriteApiBaseUrl + "/users/me", queryParams)
            If Not apiCommon.ParseConnectApiResponse(ApiType.Eventbrite, apiResult) Then
                Me.Cursor = Cursors.Arrow
                Exit Try
            End If

            lblStatus.Text = "Connecting to Enterpryze..."

            enterpryzeApi = New EnterpryzeApi(sEntEnvironmentType, sEntEmail, sEntPassword)
            apiResult = Await enterpryzeApi.Authenticate()
            If Not apiCommon.ParseConnectApiResponse(ApiType.Enterpryze, apiResult) Then
                Me.Cursor = Cursors.Arrow
                Exit Try
            End If

            lblStatus.Text = "Connected."
            txtEvntUser.Text = sEvntUser
            txtEvntEmail.Text = sEvntEmail
            txtEntOrgId.Text = sEntSurferOrganisationId

            My.Settings.EvntToken = sEvntToken
            My.Settings.EntEnvType = sEntEnvironmentType
            My.Settings.EntEmail = sEntEmail
            My.Settings.EntPassword = sEntPassword
            My.Settings.Save()

            Me.Cursor = Cursors.Arrow

            GetEntDefaultBPs()

            btnGetEvents.Enabled = True
            btnGetEvents.Select()

        Catch ex As Exception
            lblStatus.Text = "Connection failed."
            Me.Cursor = Cursors.Arrow
            oFuncs.ErrorLog(ex.Message.ToString, ex.StackTrace)
        End Try
    End Sub

    Private Async Sub GetEntDefaultBPs()
        Try

            lblStatus.Text = "Retreiving Default BPs..."
            cboDefBP.Items.Clear()

            Me.Cursor = Cursors.WaitCursor

            apiResult = Await enterpryzeApi.GetBPList()
            responseBody = JsonConvert.DeserializeObject(apiResult.ResponseBody)
            If apiResult.StatusCode <> HttpStatusCode.OK Then
                Dim sError As String = apiResult.StatusCode.ToString() + " - " + apiResult.StatusDescription
                sError = apiCommon.ParseEnterpryzeError(responseBody)
                sError = If(sError <> "", sError, "Unknown error occurred.")
                lblStatus.Text = sError
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            Dim jsonData As JArray = responseBody
            EntDefaultBPs = jsonData.ToObject(Of List(Of Info_EntBusinessPartner))
            cboDefBP.Items.Add("")

            EntDefaultBPs.Sort(Function(x, y) x.name.CompareTo(y.name))

            Dim index = 1
            Dim selectedIndex = -1
            For Each bp In EntDefaultBPs
                bp.bpIndex = index
                cboDefBP.Items.Add(If(bp.name <> "", bp.name, bp.cardCode))
                If (sEntDefaultBP <> "" AndAlso sEntDefaultBP.ToLower() = bp.cardCode.ToLower()) Then
                    selectedIndex = index
                End If
                index += 1
            Next
            cboDefBP.SelectedIndex = selectedIndex

            Me.Cursor = Cursors.Arrow
            lblStatus.Text = "Default BPs retrieval complete."

        Catch ex As Exception
            lblStatus.Text = "Default BPs retrieval failed."
            Me.Cursor = Cursors.Arrow
            oFuncs.ErrorLog(ex.Message.ToString, ex.StackTrace)
        End Try
    End Sub

    Private Sub RefreshDefaultBPList()
        'Clear combobox and re-populate from sorted BP list.
        Try

            lblStatus.Text = "Refreshing Default BPs..."
            cboDefBP.Items.Clear()

            Me.Cursor = Cursors.WaitCursor
            cboDefBP.Items.Add("")

            EntDefaultBPs.Sort(Function(x, y) x.name.CompareTo(y.name))

            Dim index = 1
            Dim selectedIndex = -1
            For Each bp In EntDefaultBPs
                bp.bpIndex = index
                cboDefBP.Items.Add(If(bp.name <> "", bp.name, bp.cardCode))
                If (sEntDefaultBP <> "" AndAlso sEntDefaultBP.ToLower() = bp.cardCode.ToLower()) Then
                    selectedIndex = index
                End If
                index += 1
            Next
            cboDefBP.SelectedIndex = selectedIndex

            Me.Cursor = Cursors.Arrow

        Catch ex As Exception
            Me.Cursor = Cursors.Arrow
            oFuncs.ErrorLog(ex.Message.ToString, ex.StackTrace)
        End Try
    End Sub

    Private Async Sub GetEventbriteEvents()
        'Get list of events related to the current user.
        'Only available after successful connection.
        'Ignoring pagination in the response since this is just a PoC.
        Try

            EventListData.Clear()
            cboEvents.Items.Clear()
            cboEvents.Items.Add("")
            ClearEventData()
            btnGetOrders.Enabled = False
            btnImport.Enabled = False

            Me.Cursor = Cursors.WaitCursor
            lblStatus.Text = "Getting Events..."

            Dim queryParams As New Dictionary(Of String, String) From {
                {"token", sEvntToken}
            }
            Dim apiResult As HttpResponse = Await eventbriteApi.GetApiCall(sEventbriteApiBaseUrl + "/users/me/events", queryParams)
            Dim responseBody = JsonConvert.DeserializeObject(apiResult.ResponseBody)
            If apiResult.StatusCode <> HttpStatusCode.OK Then
                Dim sError As String = String.Empty
                If responseBody.Item("error") IsNot Nothing Then
                    sError = responseBody.Item("error").ToString()
                End If
                If responseBody.Item("error_description") IsNot Nothing Then
                    sError += " - " + responseBody.Item("error_description").ToString()
                End If
                Me.Cursor = Cursors.Arrow
                MessageBox.Show("Error retrieving Event list: " + sNewLine + sError, sAppName + " - Eventbrite Error")
                Exit Try
            End If

            'Populate events.
            'Index starts at 1 because we have added an empty value to the combobox.
            Dim iEventIndex As Integer = 1
            If responseBody.Item("events") IsNot Nothing Then
                Dim jsonData As JArray = responseBody.Item("events")
                Dim eventList As List(Of Info_EventbriteEvent) = jsonData.ToObject(Of List(Of Info_EventbriteEvent))
                'Dim eventObject As Info_EventbriteEvent
                For Each eventObject As Info_EventbriteEvent In eventList
                    Dim sEventId As String = eventObject.id.ToString().Trim
                    Dim sEventName As String = eventObject.name.text.ToString().Trim
                    If sEventId <> "" Then
                        cboEvents.Items.Add(sEventName + " <" + sEventId + ">")
                        'Store event data.
                        EventListData.Add(New Info_EventbriteEventData(iEventIndex, sEventId, sEventName))
                        iEventIndex += 1
                    End If

                Next
            End If

            lblStatus.Text = "Event list retrieved."

            If cboEvents.Items.Count > 1 Then
                cboEvents.SelectedIndex = 1
                btnGetOrders.Enabled = True
                btnGetOrders.Select()
            End If

            Me.Cursor = Cursors.Arrow

        Catch ex As Exception
            Me.Cursor = Cursors.Arrow
            lblStatus.Text = "Error retrieving Event list."
            oFuncs.ErrorLog(ex.Message.ToString, ex.StackTrace)
        End Try
    End Sub

    Private Sub DisplayEventbriteEventOrders()
        Try

            Me.Cursor = Cursors.WaitCursor

            ImportResults.Clear()
            dgvEvntOrders.Rows.Clear()
            dgvEntDocs.Rows.Clear()

            'Get event id.
            Dim eventData As Info_EventbriteEventData = (From x In EventListData Where x.EventIndex = cboEvents.SelectedIndex).FirstOrDefault()
            If eventData Is Nothing Then
                Me.Cursor = Cursors.Arrow
                Exit Try
            End If

            Dim orders As New List(Of XElement)
            If bImportedOrdersFileExists Then
                orders = (From order In xDocImportedOrders.Descendants("order") Select order).ToList
            End If

            Dim iRowCount = 1
            For Each order As Info_EventOrders.Order In EventOrders

                Dim sOrderId As String = order.id.ToString()
                If bImportedOrdersFileExists Then
                    Dim xOrder As XElement = (From x In orders Where x.Attribute("id").Value = sOrderId).FirstOrDefault()
                    If xOrder IsNot Nothing Then Continue For
                End If

                Dim sName As String = order.name
                Dim sEmail As String = order.email
                Dim sStatus As String = order.status
                Dim sCurrency As String = order.costs.gross.currency
                Dim dTotalValueExclFee As Double = 0
                Dim dTotalValueInclFee As Double = 0
                Dim iTicketQty As Integer = 1
                If order.attendees IsNot Nothing Then
                    iTicketQty = order.attendees.Count
                    For Each attendee In order.attendees
                        Dim attendeeFeeExcl As Double = (attendee.costs.base_price.value +
                            attendee.costs.payment_fee.value +
                            attendee.costs.tax.value) / 100
                        Dim attendeeFeeIncl As Double = (attendee.costs.base_price.value +
                            attendee.costs.eventbrite_fee.value +
                            attendee.costs.payment_fee.value +
                            attendee.costs.tax.value) / 100
                        dTotalValueExclFee += attendeeFeeExcl
                        dTotalValueInclFee += attendeeFeeIncl
                    Next
                End If
                dgvEvntOrders.Rows.Add(New String() {iRowCount, False, eventData.EventId, eventData.EventName, sOrderId,
                                           sName, sEmail, sStatus, iTicketQty, sCurrency, dTotalValueExclFee, dTotalValueInclFee})
                iRowCount += 1
            Next

            dgvEvntOrders.AutoResizeColumns()

            Me.Cursor = Cursors.Arrow

        Catch ex As Exception
            Me.Cursor = Cursors.Arrow
            oFuncs.ErrorLog(ex.Message.ToString, ex.StackTrace)
        End Try
    End Sub

    Private Async Sub GetEventbriteEventOrders(ByVal eventIndex As Integer)
        'Only called if non-empty Event is selected.
        'Ignoring pagination in the response since this is just a PoC.
        Try

            btnImport.Enabled = False
            btnGetOrders.Enabled = False
            dgvEvntOrders.Columns.Item("TotalValueExclFee").Visible = Not bEntIncludeFee
            dgvEvntOrders.Columns.Item("TotalValueInclFee").Visible = bEntIncludeFee

            Me.Cursor = Cursors.WaitCursor
            lblStatus.Text = "Getting Event Orders..."

            'Get event id.
            Dim eventData As Info_EventbriteEventData = (From x In EventListData Where x.EventIndex = eventIndex).FirstOrDefault()
            If eventData Is Nothing Then
                btnGetOrders.Enabled = True
                Me.Cursor = Cursors.Arrow
                lblStatus.Text = "Cannot find Event Index " + eventIndex.ToString()
                Exit Try
            End If

            Dim queryParams As New Dictionary(Of String, String) From {
                {"token", sEvntToken},
                {"expand", "attendees"}
            }
            Dim apiResult As HttpResponse = Await eventbriteApi.GetApiCall(sEventbriteApiBaseUrl + "/events/" + eventData.EventId + "/orders", queryParams)
            Dim responseBody As JObject = JsonConvert.DeserializeObject(apiResult.ResponseBody)
            If apiResult.StatusCode <> HttpStatusCode.OK Then
                Dim sError As String = String.Empty
                If responseBody.Item("error") IsNot Nothing Then
                    sError = responseBody.Item("error").ToString()
                End If
                If responseBody.Item("error_description") IsNot Nothing Then
                    sError += " - " + responseBody.Item("error_description").ToString()
                End If
                btnGetOrders.Enabled = True
                Me.Cursor = Cursors.Arrow
                lblStatus.Text = "Error retrieving Order list."
                MessageBox.Show("Error retrieving Order list: " + sNewLine + sError, sAppName + " - Eventbrite Error")
                Exit Try
            End If

            Me.Cursor = Cursors.Arrow

            'Populate order grid.
            If responseBody.Item("orders") IsNot Nothing Then
                Dim jsonData As JArray = responseBody.Item("orders")
                EventOrders = jsonData.ToObject(Of List(Of Info_EventOrders.Order))

                DisplayEventbriteEventOrders()
            End If

            lblStatus.Text = "Event Orders retrieved."

            If dgvEvntOrders.Rows.Count > 0 Then
                btnImport.Enabled = True
                btnImport.Select()
            End If

            btnGetOrders.Enabled = True

        Catch ex As Exception
            btnGetOrders.Enabled = True
            Me.Cursor = Cursors.Arrow
            lblStatus.Text = "Error retrieving Event Orders."
            oFuncs.ErrorLog(ex.Message.ToString, ex.StackTrace)
        End Try
    End Sub

    Private Sub btnGetEvents_Click(sender As Object, e As EventArgs) Handles btnGetEvents.Click
        GetEventbriteEvents()
    End Sub

    Private Sub cboEvents_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEvents.SelectedIndexChanged
        ClearEventData()
        sSelectedEventId = ""
        'Get event id.
        Dim eventData As Info_EventbriteEventData = (From x In EventListData Where x.EventIndex = cboEvents.SelectedIndex).FirstOrDefault()
        If eventData IsNot Nothing Then
            sSelectedEventId = eventData.EventId
        End If
        btnGetOrders.Enabled = True
        btnImport.Enabled = False
        btnGetEvents.Select()
    End Sub

    Private Sub ClearEventData()
        EventOrders.Clear()
        ImportResults.Clear()
        dgvEvntOrders.Rows.Clear()
        dgvEntDocs.Rows.Clear()
    End Sub

    Private Sub btnGetOrders_Click(sender As Object, e As EventArgs) Handles btnGetOrders.Click
        ClearEventData()
        If cboEvents.SelectedIndex = 0 Then
            MessageBox.Show("Please select an Event.", sAppName)
            Exit Sub
        End If
        GetEventbriteEventOrders(cboEvents.SelectedIndex)
    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        ImportOrders()
    End Sub

    Private Async Sub ImportOrders()
        'Loop through grid.
        'Import Sales Invoice.
        '- store results.
        'Import Incoming Payment if Order value > 0.
        '- store results.
        'Display results.
        Try

            If sEntDefaultBP = "" Then
                MessageBox.Show("Please select a default BP.", sAppName)
                Exit Try
            End If

            btnGetEvents.Enabled = False
            btnGetOrders.Enabled = False
            ImportedOrders.Clear()
            ImportResults.Clear()
            dgvEntDocs.Rows.Clear()

            Me.Cursor = Cursors.WaitCursor

            lblStatus.Text = "Importing Orders..."

            Dim selectedCount = 0

            'Set to true if at least one BP was created successfully. 
            'See below for usage.
            Dim bCreateBPSuccessful = False

            'Assign BP defaults.
            Dim defaultBp As Info_EntBusinessPartner = (From x In EntDefaultBPs Where x.bpIndex = cboDefBP.SelectedIndex).FirstOrDefault()
            Dim sBPCode As String = defaultBp.cardCode
            Dim sBPName As String = defaultBp.name

            For Each row As DataGridViewRow In dgvEvntOrders.Rows
                If row.Cells("Import").Value = False Then Continue For

                Dim sEventId As String = row.Cells("EventId").Value
                Dim sEventName As String = row.Cells("EventName").Value
                Dim sOrderId As String = row.Cells("OrderId").Value
                Dim sOrderName As String = row.Cells("Name").Value
                Dim sOrderEmail As String = row.Cells("Email").Value
                Dim sOrderCurrency As String = row.Cells("Currency").Value
                Dim dOrderTotalValue As Double = If(bEntIncludeFee, row.Cells("TotalValueInclFee").Value, row.Cells("TotalValueExclFee").Value)

                Dim apiResult As HttpResponse
                Dim responseBody As JObject
                Dim bIsLocalCurrency = True

                Dim eventOrder As Info_EventOrders.Order = (From x In EventOrders Where x.id = sOrderId).FirstOrDefault()
                If eventOrder Is Nothing Then Continue For

                'Assign non-default BP if required.
                Dim bCreateBP = False
                If sOrderEmail.Trim <> "" Then
                    'Check if BP already exists. 
                    Dim existingBp As Info_EntBusinessPartner = (From x In EntDefaultBPs Where x.email = sOrderEmail.Trim).FirstOrDefault()
                    If existingBp IsNot Nothing Then
                        sBPCode = existingBp.cardCode
                        sBPName = existingBp.name
                    ElseIf bEntCreateBP Then
                        sBPCode = GenerateNewBPCode()
                        sBPName = sOrderName
                        bCreateBP = True
                    End If
                End If

                selectedCount += 1

                'Create Sales Invoice.
                Dim salesDataLines As New List(Of Info_ImportData.Info_ImportDataLine)
                For Each attendee In eventOrder.attendees
                    Dim itemDetails As String = String.Empty
                    Dim barcode As Info_EventOrders.BarCode = attendee.barcodes.FirstOrDefault()
                    If barcode IsNot Nothing Then
                        itemDetails = barcode.barcode
                    End If
                    Dim freeText As String = attendee.ticket_class_name
                    Dim attendeeFeeExcl As Double = (attendee.costs.base_price.value +
                                attendee.costs.payment_fee.value +
                                attendee.costs.tax.value) / 100
                    Dim attendeeFeeIncl As Double = (attendee.costs.base_price.value +
                                attendee.costs.eventbrite_fee.value +
                                attendee.costs.payment_fee.value +
                                attendee.costs.tax.value) / 100
                    Dim priceAfterVat As Double = If(bEntIncludeFee, attendeeFeeIncl, attendeeFeeExcl)

                    salesDataLines.Add(New Info_ImportData.Info_ImportDataLine("TICKET", itemDetails, freeText, 1, priceAfterVat))
                Next

                Dim salesData As New Info_ImportData(sEventId, sEventName, sOrderId, sOrderEmail, sOrderEmail, sOrderCurrency.ToUpper(), dOrderTotalValue,
                                                     "Invoice", sBPCode, sBPName, -1, -1, "", "", 0, 0, "", "", salesDataLines)
                'Create Business Partner if required.
                If bCreateBP Then
                    Dim bpData As New Info_EntBusinessPartner(-1, sBPCode, sBPName, If(sOrderCurrency <> "", sOrderCurrency.ToUpper(), ""), sOrderEmail.Trim)
                    apiResult = Await enterpryzeApi.CreateBusinessPartner(bpData)
                    responseBody = JsonConvert.DeserializeObject(apiResult.ResponseBody)
                    If apiResult.StatusCode <> HttpStatusCode.OK Then
                        Dim sError As String = apiResult.StatusCode.ToString() + " - " + apiResult.StatusDescription
                        sError = apiCommon.ParseEnterpryzeError(responseBody)
                        sError = If(sError <> "", sError, "Unknown error occurred.")
                        salesData.entDocError = sError
                        ImportResults.Add(salesData)
                        Continue For
                    Else
                        bCreateBPSuccessful = True
                        EntDefaultBPs.Add(bpData)
                    End If
                End If

                apiResult = Await enterpryzeApi.CreateSalesInvoice(salesData)
                responseBody = JsonConvert.DeserializeObject(apiResult.ResponseBody)
                If apiResult.StatusCode <> HttpStatusCode.OK Then
                    Dim sError As String = apiResult.StatusCode.ToString() + " - " + apiResult.StatusDescription
                    sError = apiCommon.ParseEnterpryzeError(responseBody)
                    sError = If(sError <> "", sError, "Unknown error occurred.")
                    salesData.entDocError = sError
                Else
                    'Get success response data.
                    If responseBody.Item("_id") IsNot Nothing Then
                        salesData.entDocEntry = Convert.ToInt32(responseBody.Item("docEntry"))
                        salesData.entDocNum = Convert.ToInt32(responseBody.Item("docNum"))
                        salesData.entDocDate = responseBody.Item("docDate").ToString()
                        salesData.entDocCur = responseBody.Item("docCur").ToString()
                        If responseBody.Item("currencySource").ToString() = "L" Then
                            salesData.entDocTax = Convert.ToDouble(responseBody.Item("vatSum"))
                            salesData.entDocTotal = Convert.ToDouble(responseBody.Item("docTotal"))
                        Else
                            bIsLocalCurrency = False
                            salesData.entDocTax = Convert.ToDouble(responseBody.Item("vatSumFc"))
                            salesData.entDocTotal = Convert.ToDouble(responseBody.Item("docTotalFc"))
                        End If
                        salesData.entDocRem = responseBody.Item("comments").ToString()
                    End If
                    ImportedOrders.Add(New Info_ImportedOrder(sOrderId, sEventId, sOrderName, sOrderEmail, sEntSurferOrganisationId))

                End If
                ImportResults.Add(salesData)

                If salesData.entDocEntry = -1 Then Continue For
                If dOrderTotalValue = 0 Then Continue For

                'Create Incoming Payment.
                Dim payData As New Info_ImportData(sEventId, sEventName, sOrderId, sOrderEmail, sOrderEmail, sOrderCurrency, dOrderTotalValue,
                                                   "Payment", sBPCode, sBPName, -1, -1, "", "", 0, 0, "", "", Nothing)
                apiResult = Await enterpryzeApi.CreateIncomingPayment(payData, salesData.entDocEntry)
                responseBody = JsonConvert.DeserializeObject(apiResult.ResponseBody)
                If apiResult.StatusCode <> HttpStatusCode.OK Then
                    Dim sError As String = apiResult.StatusCode.ToString() + " - " + apiResult.StatusDescription
                    sError = apiCommon.ParseEnterpryzeError(responseBody)
                    sError = If(sError <> "", sError, "Unknown error occurred.")
                    payData.entDocError = sError
                Else
                    'Get success response data.
                    If responseBody.Item("_id") IsNot Nothing Then
                        payData.entDocEntry = Convert.ToInt32(responseBody.Item("docEntry"))
                        payData.entDocNum = Convert.ToInt32(responseBody.Item("docNum"))
                        payData.entDocDate = responseBody.Item("docDate").ToString()
                        payData.entDocCur = responseBody.Item("docCur").ToString()
                        If bIsLocalCurrency Then
                            payData.entDocTotal = Convert.ToDouble(responseBody.Item("docTotal")) * -1
                        Else
                            payData.entDocTotal = Convert.ToDouble(responseBody.Item("docTotalFc")) * -1
                        End If
                        payData.entDocRem = responseBody.Item("comments").ToString()
                    End If
                End If
                ImportResults.Add(payData)

            Next

            Me.Cursor = Cursors.Arrow

            DisplayImportDataResults()

            'Populate ImportedOrders.xml.

            'After import is complete we need to refresh the Default BP list:
            '- Get BP List from Enterprzye again (it will include the newly create BP(s)).
            '- Repopulate combobox.
            '- Select Default BP.
            If bCreateBPSuccessful Then
                RefreshDefaultBPList()
            End If

            btnGetEvents.Enabled = True
            btnGetOrders.Enabled = True

            If selectedCount = 0 Then
                MessageBox.Show("Nothing selected for Import.", sAppName)
            Else
                lblStatus.Text = "Import complete."
            End If

        Catch ex As Exception
            btnGetEvents.Enabled = True
            btnGetOrders.Enabled = True
            Me.Cursor = Cursors.Arrow
            lblStatus.Text = "Error importing Orders."
            oFuncs.ErrorLog(ex.Message.ToString, ex.StackTrace)
        End Try
    End Sub

    Private Sub DisplayImportDataResults()
        'Also populate ImportOrders.xml. 
        Try

            Me.Cursor = Cursors.WaitCursor
            dgvEntDocs.Rows.Clear()

            If Not bImportedOrdersFileExists Then
                xDocImportedOrders = New XDocument(New XDeclaration("1.0", "UTF-8", "yes"), New XElement("orders"))
            End If
            Dim orders As XElement = xDocImportedOrders.Descendants().Where(Function(x) x.Name.LocalName = "orders").FirstOrDefault

            Dim newOrders As New List(Of XElement)
            For Each importedOrder As Info_ImportedOrder In ImportedOrders

                Dim order As New XElement("order", New XAttribute("id", importedOrder.id),
                                                     New XAttribute("eventId", importedOrder.eventId),
                                                     New XAttribute("name", importedOrder.name),
                                                     New XAttribute("email", importedOrder.email),
                                                     New XAttribute("organisationId", importedOrder.organisationId))
                newOrders.Add(order)

            Next

            Dim iRowCount = 1
            Dim bImportError = False

            Dim orderIds As New List(Of String)

            For Each data As Info_ImportData In ImportResults

                Dim sDocDate As String = String.Empty
                If data.entDocDate.Length >= 10 Then
                    sDocDate = data.entDocDate.Substring(0, 10)
                End If
                dgvEntDocs.Rows.Add(New String() {iRowCount, data.entDocType, data.entDocEntry, data.entDocNum,
                                        data.entDocBpCode, data.entDocBpName, sDocDate, data.entDocRem,
                                        data.entDocTax, data.entDocTotal, data.entDocCur, data.orderId, data.entDocError})
                iRowCount += 1

                Dim doc As New XElement("document", New XAttribute("type", data.entDocType),
                                                     New XAttribute("docEntry", data.entDocEntry),
                                                     New XAttribute("docNum", data.entDocNum))

                'Dim eventData As Info_EventbriteEventData = (From x In EventListData Where x.EventIndex = cboEvents.SelectedIndex).FirstOrDefault()
                Dim newOrder As XElement = (From x In newOrders Where x.Attribute("id").Value = data.orderId).FirstOrDefault()
                If newOrder IsNot Nothing Then
                    newOrder.Add(doc)
                End If

                If data.entDocError <> "" Then
                    bImportError = True
                End If

            Next

            orders.Add(newOrders)

            Dim sTargetFileName = Path.Combine(sAppPath, "ImportedOrders.xml")
            xDocImportedOrders.Save(sTargetFileName)
            bImportedOrdersFileExists = True

            dgvEntDocs.Columns.Item("DocError").Visible = bImportError
            dgvEntDocs.AutoResizeColumns()

            Me.Cursor = Cursors.Arrow

        Catch ex As Exception
            btnGetEvents.Enabled = True
            btnGetOrders.Enabled = True
            Me.Cursor = Cursors.Arrow
            oFuncs.ErrorLog(ex.Message.ToString, ex.StackTrace)
        End Try
    End Sub

    Private Sub DefineGridColumnsOrders()
        Dim sColumnNameAndHeaderText As String = String.Empty
        Dim colId As New DataGridViewTextBoxColumn
        Dim colImport As New DataGridViewCheckBoxColumn
        Dim colEventId As New DataGridViewTextBoxColumn
        Dim colEventName As New DataGridViewTextBoxColumn
        Dim colOrderId As New DataGridViewTextBoxColumn
        Dim colName As New DataGridViewTextBoxColumn
        Dim colEmail As New DataGridViewTextBoxColumn
        Dim colStatus As New DataGridViewTextBoxColumn
        Dim colTicketQty As New DataGridViewTextBoxColumn
        Dim colCurrency As New DataGridViewTextBoxColumn
        Dim colTotalValueExclFee As New DataGridViewTextBoxColumn
        Dim colTotalValueInclFee As New DataGridViewTextBoxColumn

        colId.Name = "Id"
        colId.HeaderText = "#"
        colId.ReadOnly = True
        dgvEvntOrders.Columns.Add(colId)

        sColumnNameAndHeaderText = "Import"
        colImport.Name = sColumnNameAndHeaderText
        colImport.HeaderText = sColumnNameAndHeaderText
        dgvEvntOrders.Columns.Add(colImport)

        sColumnNameAndHeaderText = "EventId"
        colEventId.Name = sColumnNameAndHeaderText
        colEventId.HeaderText = sColumnNameAndHeaderText
        colEventId.Visible = False
        dgvEvntOrders.Columns.Add(colEventId)

        sColumnNameAndHeaderText = "EventName"
        colEventName.Name = sColumnNameAndHeaderText
        colEventName.HeaderText = sColumnNameAndHeaderText
        colEventName.Visible = False
        dgvEvntOrders.Columns.Add(colEventName)

        sColumnNameAndHeaderText = "OrderId"
        colOrderId.Name = sColumnNameAndHeaderText
        colOrderId.HeaderText = sColumnNameAndHeaderText
        colOrderId.ReadOnly = True
        dgvEvntOrders.Columns.Add(colOrderId)

        sColumnNameAndHeaderText = "Name"
        colName.Name = sColumnNameAndHeaderText
        colName.HeaderText = sColumnNameAndHeaderText
        colName.ReadOnly = True
        dgvEvntOrders.Columns.Add(colName)

        sColumnNameAndHeaderText = "Email"
        colEmail.Name = sColumnNameAndHeaderText
        colEmail.HeaderText = sColumnNameAndHeaderText
        colEmail.ReadOnly = True
        dgvEvntOrders.Columns.Add(colEmail)

        sColumnNameAndHeaderText = "Status"
        colStatus.Name = sColumnNameAndHeaderText
        colStatus.HeaderText = sColumnNameAndHeaderText
        colStatus.ReadOnly = True
        dgvEvntOrders.Columns.Add(colStatus)

        sColumnNameAndHeaderText = "TicketQty"
        colTicketQty.Name = sColumnNameAndHeaderText
        colTicketQty.HeaderText = sColumnNameAndHeaderText
        colTicketQty.ReadOnly = True
        dgvEvntOrders.Columns.Add(colTicketQty)

        sColumnNameAndHeaderText = "Currency"
        colCurrency.Name = sColumnNameAndHeaderText
        colCurrency.HeaderText = sColumnNameAndHeaderText
        colCurrency.ReadOnly = True
        dgvEvntOrders.Columns.Add(colCurrency)

        sColumnNameAndHeaderText = "TotalValueExclFee"
        colTotalValueExclFee.Name = sColumnNameAndHeaderText
        colTotalValueExclFee.HeaderText = "Total Value"
        colTotalValueExclFee.ReadOnly = True
        colTotalValueExclFee.Visible = False
        colTotalValueExclFee.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvEvntOrders.Columns.Add(colTotalValueExclFee)

        sColumnNameAndHeaderText = "TotalValueInclFee"
        colTotalValueInclFee.Name = sColumnNameAndHeaderText
        colTotalValueInclFee.HeaderText = "Total Value"
        colTotalValueInclFee.ReadOnly = True
        colTotalValueInclFee.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvEvntOrders.Columns.Add(colTotalValueInclFee)

        dgvEvntOrders.RowHeadersVisible = False
        dgvEvntOrders.AutoResizeColumns()

    End Sub

    Private Sub DefineGridColumnsResults()

        Dim colId As New DataGridViewTextBoxColumn
        Dim colDocType As New DataGridViewTextBoxColumn
        Dim colDocEntry As New DataGridViewTextBoxColumn
        Dim colDocNum As New DataGridViewTextBoxColumn

        Dim colBpCode As New DataGridViewTextBoxColumn
        Dim colBpName As New DataGridViewTextBoxColumn

        Dim colDocDate As New DataGridViewTextBoxColumn
        Dim colDocRem As New DataGridViewTextBoxColumn
        Dim colDocTax As New DataGridViewTextBoxColumn
        Dim colDocTotal As New DataGridViewTextBoxColumn
        Dim colDocCur As New DataGridViewTextBoxColumn
        Dim colOrderId As New DataGridViewTextBoxColumn
        Dim colDocError As New DataGridViewTextBoxColumn

        colId.Name = "Id"
        colId.HeaderText = "#"
        colId.ReadOnly = True
        dgvEntDocs.Columns.Add(colId)

        colDocType.Name = "Type"
        colDocType.HeaderText = "Type"
        dgvEntDocs.Columns.Add(colDocType)

        colDocEntry.Name = "DocEntry"
        colDocEntry.HeaderText = "DocEntry"
        colDocEntry.Visible = False
        dgvEntDocs.Columns.Add(colDocEntry)

        colDocNum.Name = "DocNum"
        colDocNum.HeaderText = "Document No."
        dgvEntDocs.Columns.Add(colDocNum)

        colBpCode.Name = "BpCode"
        colBpCode.HeaderText = "Code"
        dgvEntDocs.Columns.Add(colBpCode)

        colBpName.Name = "BpName"
        colBpName.HeaderText = "Name"
        dgvEntDocs.Columns.Add(colBpName)

        colDocDate.Name = "DocDate"
        colDocDate.HeaderText = "Date"
        dgvEntDocs.Columns.Add(colDocDate)

        colDocRem.Name = "DocRem"
        colDocRem.HeaderText = "Remarks"
        dgvEntDocs.Columns.Add(colDocRem)

        colDocTax.Name = "DocTax"
        colDocTax.HeaderText = "Tax"
        colDocTax.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        colDocTax.Visible = False
        dgvEntDocs.Columns.Add(colDocTax)

        colDocTotal.Name = "DocTotal"
        colDocTotal.HeaderText = "Amount"
        colDocTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvEntDocs.Columns.Add(colDocTotal)

        colDocCur.Name = "DocCur"
        colDocCur.HeaderText = "Currency"
        dgvEntDocs.Columns.Add(colDocCur)

        colOrderId.Name = "OrderId"
        colOrderId.HeaderText = "OrderId"
        dgvEntDocs.Columns.Add(colOrderId)

        colDocError.Name = "DocError"
        colDocError.HeaderText = "Import Error"
        colDocError.Visible = False
        dgvEntDocs.Columns.Add(colDocError)

        dgvEntDocs.RowHeadersVisible = False
        dgvEntDocs.AutoResizeColumns()

    End Sub

    Private Sub dgvEntDocs_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dgvEntDocs.MouseDoubleClick
        'If user double clicks on DocNum value then try open document in Web App.
        Try
            If dgvEntDocs.Rows.Count > 0 Then
                'DocNum.
                If dgvEntDocs.SelectedCells.Item(0).ColumnIndex = 3 Then
                    Me.Cursor = Cursors.WaitCursor
                    Dim iRowIndex = dgvEntDocs.SelectedCells.Item(0).RowIndex
                    Dim sDocType = dgvEntDocs.Rows(iRowIndex).Cells(1).Value.ToString()
                    Dim sDocEntry = dgvEntDocs.Rows(iRowIndex).Cells(2).Value.ToString()

                    Dim sBaseUrl = ""
                    Select Case sEntEnvironmentType
                        Case EnterpryzeEnvTypeTest
                            sBaseUrl = "https://apps-test.enterpryze.com/"
                        Case EnterpryzeEnvTypeStaging
                            sBaseUrl = "https://apps-staging.enterpryze.com/"
                        Case EnterpryzeEnvTypeLive
                            sBaseUrl = "https://apps.enterpryze.com/"
                        Case Else
                            sBaseUrl = "https://apps-staging.enterpryze.com/"
                    End Select
                    Dim sDocUrl = ""
                    Select Case sDocType
                        Case "Invoice"
                            sDocUrl = "/sales/sales-invoice/"
                        Case Else
                            sDocUrl = "/banking/customer-receipt/"
                    End Select

                    Dim sUrl = sBaseUrl + sEntSurferOrganisationId + sDocUrl + sDocEntry
                    Process.Start(sUrl)
                    Me.Cursor = Cursors.Arrow
                End If
            End If

        Catch ex As Exception
            Me.Cursor = Cursors.Arrow
            oFuncs.ErrorLog(ex.Message.ToString, ex.StackTrace)
        End Try
    End Sub

    Private Sub chkIncludeFee_CheckedChanged(sender As Object, e As EventArgs) Handles chkIncludeFee.CheckedChanged
        My.Settings.EntIncludeFee = chkIncludeFee.Checked
        My.Settings.Save()
        bEntIncludeFee = chkIncludeFee.Checked
        If dgvEvntOrders.Rows.Count > 0 Then
            dgvEvntOrders.Columns.Item("TotalValueExclFee").Visible = Not chkIncludeFee.Checked
            dgvEvntOrders.Columns.Item("TotalValueInclFee").Visible = chkIncludeFee.Checked
        End If
    End Sub

    Private Sub lblCreateBP_Click(sender As Object, e As EventArgs) Handles lblCreateBP.Click
        chkCreateBP.Checked = Not chkCreateBP.Checked
    End Sub

    Private Sub lblIncludeFee_Click(sender As Object, e As EventArgs) Handles lblIncludeFee.Click
        chkIncludeFee.Checked = Not chkIncludeFee.Checked
    End Sub

    Private Function GenerateNewBPCode()

        Dim allowable As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        Dim result(iGenerateBPCode_Suffix_MaxLength - 1) As Char
        Dim current As Integer = 0
        Dim sBPCodeSuffix As String = String.Empty

        Using r As New System.Security.Cryptography.RNGCryptoServiceProvider()
            Do
                Dim buffer(255) As Byte
                r.GetBytes(buffer)

                For Each b As Byte In buffer
                    If b < allowable.Length Then
                        result(current) = allowable(b)
                        current += 1
                        If current = iGenerateBPCode_Suffix_MaxLength Then
                            sBPCodeSuffix = New String(result)
                            Exit Do
                        End If
                    End If
                Next
            Loop
        End Using

        Return sGenerateBPCode_Prefix + sBPCodeSuffix

    End Function

    Private Sub btnConfigSave_Click(sender As Object, e As EventArgs) Handles btnConfigSave.Click
        SaveConfiguration()
    End Sub

    Private Sub cboDefBP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDefBP.SelectedIndexChanged
        sEntDefaultBP = ""
        Dim bp As Info_EntBusinessPartner = (From x In EntDefaultBPs Where x.bpIndex = cboDefBP.SelectedIndex).FirstOrDefault()
        If bp IsNot Nothing Then
            sEntDefaultBP = bp.cardCode
        End If
        My.Settings.EntDefaultBP = sEntDefaultBP
        My.Settings.Save()
    End Sub

    Private Sub chkCreateBP_CheckedChanged(sender As Object, e As EventArgs) Handles chkCreateBP.CheckedChanged
        My.Settings.EntCreateBP = chkCreateBP.Checked
        My.Settings.Save()
        bEntCreateBP = chkCreateBP.Checked
    End Sub

    Private Sub SaveConfiguration()
        Try

            If sEntDefaultBP = "" Then
                MessageBox.Show("Please select a Default BP.", sAppName)
                Exit Try
            End If
            If sSelectedEventId = "" Then
                MessageBox.Show("Please select an Event.", sAppName)
                Exit Try
            End If

            Me.Cursor = Cursors.WaitCursor

            'Generate config XML and save to local file.
            Dim xDoc As New XDocument(xDocConfigTemplate)
            Dim config As XElement = xDoc.Descendants().Where(Function(x) x.Name.LocalName = "config").FirstOrDefault
            If config IsNot Nothing Then

                Dim connection As XElement = config.Descendants().Where(Function(x) x.Name.LocalName = "connection").FirstOrDefault
                If connection IsNot Nothing Then
                    Dim eventbrite As XElement = config.Descendants().Where(Function(x) x.Name.LocalName = "eventbrite").FirstOrDefault
                    If eventbrite IsNot Nothing Then
                        eventbrite.Attribute("oauthToken").SetValue(sEvntToken)
                    End If
                    Dim enterpryze As XElement = connection.Descendants().Where(Function(x) x.Name.LocalName = "enterpryze").FirstOrDefault
                    If enterpryze IsNot Nothing Then
                        enterpryze.Attribute("environment").SetValue(sEntEnvironmentType)
                        enterpryze.Attribute("email").SetValue(sEntEmail)
                        enterpryze.Attribute("password").SetValue(sEntPassword)
                    End If
                End If

                Dim settings As XElement = config.Descendants().Where(Function(x) x.Name.LocalName = "settings").FirstOrDefault
                If settings IsNot Nothing Then
                    Dim eventbrite As XElement = settings.Descendants().Where(Function(x) x.Name.LocalName = "eventbrite").FirstOrDefault
                    If eventbrite IsNot Nothing Then
                        eventbrite.Attribute("user").SetValue(sEvntUser)
                        eventbrite.Attribute("email").SetValue(sEvntEmail)
                        eventbrite.Attribute("eventId").SetValue(sSelectedEventId)
                    End If
                    Dim enterpryze As XElement = settings.Descendants().Where(Function(x) x.Name.LocalName = "enterpryze").FirstOrDefault
                    If enterpryze IsNot Nothing Then
                        enterpryze.Attribute("organisationId").SetValue(sEntSurferOrganisationId)
                        enterpryze.Attribute("includeFee").SetValue(bEntIncludeFee.ToString())
                        enterpryze.Attribute("createBP").SetValue(bEntCreateBP.ToString())
                        enterpryze.Attribute("defaultBP").SetValue(sEntDefaultBP)
                    End If
                End If

            End If

            Dim sTargetFileName = Path.Combine(sAppPath, "Config_" & sSelectedEventId & ".xml")
            xDoc.Save(sTargetFileName)
            lblStatus.Text = "Config saved: " & sTargetFileName

            Me.Cursor = Cursors.Arrow

        Catch ex As Exception
            Me.Cursor = Cursors.Arrow
            oFuncs.ErrorLog(ex.Message.ToString, ex.StackTrace)
        End Try
    End Sub

    Private Sub StatusStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles StatusStrip1.ItemClicked
        MessageBox.Show(lblStatus.Text)
    End Sub

    Private Sub chkIgnoreImported_CheckedChanged(sender As Object, e As EventArgs) Handles chkIgnoreImported.CheckedChanged
        bIgnoreImportedOrders = chkIgnoreImported.Checked
        My.Settings.EvntIgnoreImported = bIgnoreImportedOrders
        My.Settings.Save()
        DisplayEventbriteEventOrders()
    End Sub

End Class
