Option Explicit On

Module SubMain

    Public Sub Main()

        Dim args() As String = Environment.GetCommandLineArgs()

        If args.Length = 1 Then
            Dim frmMain As New frmMain
            'frmMain.Show()
            Application.EnableVisualStyles()
            Application.Run(frmMain)
        Else
            Console.WriteLine("Load config file - connect - get orders not imported - import - exit")
            End
        End If

    End Sub

End Module
