'--------------------------------------------------------------------------------------------------
' Networking
'    (C) 2026 Remus Rigo
'       v1.0.2026-04-24
'--------------------------------------------------------------------------------------------------

Imports System.Net
Imports System.Net.Http

Module Networking

   ' Reuse a single HttpClient instance for better performance
   Private ReadOnly _httpClient As New HttpClient()

   Function GetPrivateIP() As String
      Dim hostName As String = Dns.GetHostName()
      Dim addresses = Dns.GetHostAddresses(hostName)

      For Each addr In addresses
         ' Filter to IPv4 only, skip loopback
         If addr.AddressFamily = Sockets.AddressFamily.InterNetwork AndAlso
            Not IPAddress.IsLoopback(addr) Then
            Return addr.ToString()
         End If
      Next

      Return "Not found"
   End Function

   Function GetPublicIP() As String
      Try
         Return _httpClient.GetStringAsync("https://api.ipify.org").Result.Trim()
      Catch ex As Exception
         Return "Not found: " & ex.Message
      End Try
   End Function

End Module
