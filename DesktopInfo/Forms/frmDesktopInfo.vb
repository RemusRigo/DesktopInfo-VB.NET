'--------------------------------------------------------------------------------------------------
' DesktopInfo
'    (C) 2026 Remus Rigo
'       v1.0.2026-04-24
'--------------------------------------------------------------------------------------------------

Imports System.ComponentModel
Imports System.Management
Imports System.Runtime.InteropServices
Imports System.Runtime.Versioning
Imports System.Threading

Public Class frmDesktopInfo
   Inherits clsAcrylicForm

   Private cfg As AppSettings

   Protected Overrides Sub OnVisibleChanged(e As EventArgs)
      MyBase.OnVisibleChanged(e)
      ' Ensure it stays behind other windows when shown
      SetWindowPos(Me.Handle, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOSIZE Or SWP_NOMOVE Or SWP_NOACTIVATE)
   End Sub

   Private Sub frmDesktop_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
      SetWindowPos(Me.Handle, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOSIZE Or SWP_NOMOVE Or SWP_NOACTIVATE)
   End Sub

   Private Sub frmDesktopInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      cfg = SettingsJSON.Load()
      Me.StartPosition = FormStartPosition.Manual
      Me.AutoSize = True
      Me.AutoSizeMode = AutoSizeMode.GrowAndShrink

      Dim BackgroundWorker As New System.ComponentModel.BackgroundWorker()
      AddHandler BackgroundWorker.DoWork, AddressOf BackgroundWorker_DoWork
      AddHandler BackgroundWorker.RunWorkerCompleted, AddressOf BackgroundWorker_RunWorkerCompleted
      BackgroundWorker.RunWorkerAsync()
      SendToBack()
   End Sub

   Private Sub BackgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
      Dim myConnection As New ConnectionOptions()
      Dim scopePath As String
      scopePath = "\\.\root\cimv2"
      Dim scope As New ManagementScope(scopePath, myConnection)
      Dim items As New Dictionary(Of String, String)

      Try
         scope.Connect()
         Dim myQuery As New ObjectQuery("SELECT * FROM Win32_OperatingSystem")

         Using searcher As New ManagementObjectSearcher(scope, myQuery)

            For Each obj As ManagementObject In searcher.Get()
               If obj.Properties.Cast(Of PropertyData)().Any(Function(p) p.Name = "Caption") Then
                  If obj("Caption") IsNot Nothing Then
                     items.Add("OS", obj("Caption").ToString())
                  End If
               End If

               If obj.Properties.Cast(Of PropertyData)().Any(Function(p) p.Name = "Version") Then
                  If (obj("Version") IsNot Nothing) Then
                     items.Add("Version", obj("Version").ToString())
                  End If
               End If

               If obj.Properties.Cast(Of PropertyData)().Any(Function(p) p.Name = "BuildNumber") Then
                  If (obj("BuildNumber") IsNot Nothing) Then
                     items.Add("Build Number", obj("BuildNumber").ToString())
                     Dim osVer As String = ""
                     Dim osCode As String = ""

                     Select Case obj("BuildNumber")
                        Case "002"
                           osVer = "3.11"
                           osCode = ""

                        Case "102"
                           osVer = "3.10"
                           osCode = "Sparta"

                        Case "103"
                           osVer = "3.10"
                           osCode = "Janus"

                        Case "153"
                           osVer = "3.2"

                        Case "300"
                           osVer = "3.11"
                           osCode = "Snowball"

                        Case "528"
                           osVer = "NT 3.1"
                           osCode = "Razzle"

                        Case "807"
                           osVer = "NT 3.5"
                           osCode = "Daytona"

                        Case "950"
                           osVer = "4.00"
                           osCode = "Chicago"

                        Case "1057"
                           osVer = "NT 3.51"
                           osCode = "Daytona"

                        Case "1381"
                           osVer = "NT 4.0"
                           osCode = "Shell Update Release (Tukwila)"

                        Case "1998"
                           osVer = "4.10"
                           osCode = "Memphis"

                        Case "2195"
                           osVer = "NT 5.0"
                           osCode = "Windows NT 5.0"

                        Case "2222A"
                           osVer = "4.10"
                           osCode = "Memphis"

                        Case "2600"
                           osVer = "NT 5.1"
                           osCode = "Whistler / Freestyle / Harmony"

                        Case "2700"
                           osVer = "NT 5.1"
                           osCode = "Symphony"

                        Case "2710"
                           osVer = "NT 5.1"
                           osCode = "Emerald"

                        Case "3000"
                           osVer = "4.90"
                           osCode = "Millennium"

                        Case "3790"
                           osVer = "NT 5.2"
                           osCode = "Anvil"

                        Case "6002"
                           osVer = "NT 6.0"
                           osCode = "Longhorn"

                        Case "7601"
                           osVer = "NT 6.1"
                           osCode = "Windows 7"

                        Case "9200"
                           osVer = "NT 6.2"
                           osCode = "Windows 8"

                        Case "9600"
                           osVer = "NT 6.3"
                           osCode = "Blue"

                        Case "10240"
                           osVer = "NT 10.0 / 1507"
                           osCode = "Threshold"

                        Case "10586"
                           osVer = "1511"
                           osCode = "Threshold 2"

                        Case "14393"
                           osVer = "1607"
                           osCode = "Redstone 1"

                        Case "15063"
                           osVer = "1703"
                           osCode = "Redstone 2"

                        Case "16299"
                           osVer = "1709"
                           osCode = "Redstone 3"

                        Case "17134"
                           osVer = "1803"
                           osCode = "Redstone 4"

                        Case "17763"
                           osVer = "1809"
                           osCode = "Redstone 5"

                        Case "18362"
                           osVer = "1903"
                           osCode = "19H1"

                        Case "18363"
                           osVer = "1909"
                           osCode = "Vanadium"

                        Case "19041"
                           osVer = "2004"
                           osCode = "Vibranium"

                        Case "19042"
                           osVer = "20H2"
                           osCode = "Vibranium"

                        Case "19043"
                           osVer = "21H1"
                           osCode = "Vibranium"

                        Case "19044"
                           osVer = "21H2"
                           osCode = "Vibranium"

                        Case "19045"
                           osVer = "22H2"
                           osCode = "Vibranium"

                        Case "22000"
                           osVer = "21H2"
                           osCode = "Cobalt"

                        Case "22621"
                           osVer = "22H2"
                           osCode = "Nickel"

                        Case "22631"
                           osVer = "23H2"
                           osCode = "Nickel"

                        Case "26100"
                           osVer = "24H2"
                           osCode = "Germanium"

                        Case "26200"
                           osVer = "25H2"
                           osCode = "Germanium"

                        Case Else
                           osVer = "Unknown"
                           osCode = "Unknown"

                     End Select
                     items.Add("Feature Update", osVer)
                     items.Add("Codename", osCode)
                  End If
               End If
            Next
         End Using

         ' get Private and Public IPs (if any)
         Dim ips = GetAllPrivateIPs()

         For Each ip In ips
            items.Add("Private IP", ip)
         Next

         items.Add("Public IP", GetPublicIP())

         e.Result = items
      Catch ex As Exception
         MsgBox(ex.Message)
      End Try

   End Sub
   Private Sub BackgroundWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs)
      If e.Error IsNot Nothing Then
         MsgBox("WMI Error: " & e.Error.Message)
         Return
      End If

      Dim items = TryCast(e.Result, Dictionary(Of String, String))
      Dim currentY As Integer = 10
      Dim rowHeight As Integer = 20 ' Distance between rows
      Dim titleFont As New Font("Segoe UI", 10, FontStyle.Bold)
      Dim keyFont As New Font("Segoe UI", 10, FontStyle.Bold)
      Dim valFont As New Font("Segoe UI", 10, FontStyle.Bold)

      Dim lblUserOnHost As New Label()
      lblUserOnHost.Text = Environment.UserName & " on " & Environment.MachineName
      lblUserOnHost.Location = New Point(10, currentY)
      lblUserOnHost.AutoSize = True
      'lblUserOnHost.Dock = DockStyle.Top
      lblUserOnHost.Height = rowHeight
      lblUserOnHost.Font = titleFont
      lblUserOnHost.ForeColor = Color.White ' Contrast color for keys
      lblUserOnHost.BackColor = Color.Transparent
      lblUserOnHost.UseCompatibleTextRendering = True
      Me.Controls.Add(lblUserOnHost)
      currentY += rowHeight

      For Each kvp As KeyValuePair(Of String, String) In items
         Dim lblKey As New Label()
         lblKey.Text = kvp.Key & ":"
         lblKey.Location = New Point(10, currentY)
         lblKey.AutoSize = True
         lblKey.Font = keyFont
         lblKey.ForeColor = Color.White ' Contrast color for keys
         lblKey.BackColor = Color.Transparent
         lblKey.UseCompatibleTextRendering = True

         ' Label 2: The Value
         Dim lblValue As New Label()
         lblValue.Text = kvp.Value
         lblValue.Location = New Point(120, currentY) ' Offset to the right
         lblValue.AutoSize = True
         lblValue.Font = valFont
         lblValue.ForeColor = Color.White
         lblValue.BackColor = Color.Transparent
         lblValue.UseCompatibleTextRendering = True

         ' Add to form
         Me.Controls.Add(lblKey)
         Me.Controls.Add(lblValue)

         ' Increment Y for the next iteration
         currentY += rowHeight
      Next

      Select Case cfg.Position
         Case "TL"
            Me.Location = New Point(5, 5)
         Case "TR"
            Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Me.Width - 5, 5)
         Case "BL"
            Me.Location = New Point(5, Screen.PrimaryScreen.WorkingArea.Height - Me.Height - 5)
         Case "BR"
            Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Me.Width - 5, Screen.PrimaryScreen.WorkingArea.Height - Me.Height - 5)
         Case Else
            Me.Location = New Point(5, 5)
      End Select

   End Sub

End Class
