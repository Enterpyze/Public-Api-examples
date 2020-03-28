Module Globals

    Public sAppName As String = My.Application.Info.ProductName
    Public sNewLine As String = System.Environment.NewLine
    Public sAppPath As String = String.Empty
    Public Const sError_File_Name As String = "IssueLog.txt"

    'User input.
    Public sEvntToken As String = String.Empty
    Public sEntEnvironmentType As String = String.Empty
    Public sEntEmail As String = String.Empty
    Public sEntPassword As String = String.Empty
    Public bEntIncludeFee As Boolean = False
    Public bEntCreateBP As Boolean = False
    Public sEntDefaultBP As String = String.Empty
    Public sSelectedEventId As String = String.Empty
    Public bIgnoreImportedOrders As Boolean = False

    'Api responses.
    Public sEvntUser As String = String.Empty
    Public sEvntEmail As String = String.Empty
    Public sEntSurferAuth As String = String.Empty
    Public sEntSurferOrganisationId As String = String.Empty

    Public Const sGenerateBPCode_Prefix As String = "EB_"
    Public Const iGenerateBPCode_Suffix_MaxLength As Integer = 8
    Public bImportedOrdersFileExists As Boolean = False

    Public Enum ApiType
        Enterpryze = 0
        Eventbrite = 1
    End Enum

    'Public Enum EnterpryzeEnvType
    '    Test = 0
    '    Staging = 1
    '    Live = 2
    'End Enum

    Friend Const EnterpryzeEnvTypeTest As String = "Test"
    Friend Const EnterpryzeEnvTypeStaging As String = "Staging"
    Friend Const EnterpryzeEnvTypeLive As String = "Live"

    Public sEventbriteApiBaseUrl As String = "https://www.eventbriteapi.com/v3"

End Module
