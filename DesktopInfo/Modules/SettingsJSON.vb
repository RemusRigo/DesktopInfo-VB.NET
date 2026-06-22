'--------------------------------------------------------------------------------------------------
' DesktopInfo
'    (C) 2026 Remus Rigo
'       v1.0.2026-04-24
'--------------------------------------------------------------------------------------------------

Imports System.Text.Json
Imports System.IO

Module SettingsJSON

   Public Class AppSettings
      Public Property Position As String = "TL"
   End Class

   Private ReadOnly SettingsPath As String = Path.Combine(Application.StartupPath, "DesktopInfo.json")

   Function Load() As AppSettings
      Try
         If Not File.Exists(SettingsPath) Then Return New AppSettings()

         Dim json As String = File.ReadAllText(SettingsPath)

         Return JsonSerializer.Deserialize(Of AppSettings)(json)
      Catch
         Return New AppSettings()   ' fall back to defaults on corrupt file
      End Try
   End Function

   Sub Save(settings As AppSettings)
      Dim options As New JsonSerializerOptions With {.WriteIndented = True}
      File.WriteAllText(SettingsPath, JsonSerializer.Serialize(settings, options))
   End Sub

End Module
