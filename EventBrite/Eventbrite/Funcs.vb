Option Explicit On

Public Class Funcs

    Public Sub ErrorLog(ByVal ErrorDesc As String,
                            ByVal ErrLocation As String)
        Dim sFile As String = String.Empty

        Try

            'Write to text file.
            sFile = sAppPath & sError_File_Name
            Using oWrite As New IO.StreamWriter(sFile, True)
                oWrite.WriteLine("-----------------------------")
                oWrite.WriteLine(CStr(Date.Now))
                oWrite.WriteLine("Error: " & ErrorDesc)
                oWrite.WriteLine("Location: " & ErrLocation)
                oWrite.WriteLine("-----------------------------")

                oWrite.Close()
                oWrite.Dispose()
            End Using

            Dim sMsg As String = "Error Detected!" & sNewLine & sNewLine &
                    "Error: " & ErrorDesc & sNewLine &
                    "Location: " & ErrLocation

            MessageBox.Show(sMsg, sAppName & " Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception
        End Try
    End Sub

End Class
