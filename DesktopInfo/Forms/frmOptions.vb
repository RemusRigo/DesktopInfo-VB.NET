'--------------------------------------------------------------------------------------------------
' DesktopInfo
'    (C) 2026 Remus Rigo
'       v1.0.2026-04-24
'--------------------------------------------------------------------------------------------------

Imports Microsoft.Win32

Public Class frmOptions

   Private _frmMain As frmDesktopInfo
   Private cfg As AppSettings

   Private Const regPath As String = "Software\Microsoft\Windows\CurrentVersion\Run"
   Private Const appName As String = "Remus Rigo DesktopInfo"

   Private Shared ReadOnly appPath As String = Application.ExecutablePath

   Public Sub New(frmMain As frmDesktopInfo)
      InitializeComponent()
      _frmMain = frmMain
   End Sub

   Private Sub frmOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      cfg = SettingsJSON.Load()
      If cfg.Position = "TL" Then rBtnTopLeft.Checked = True
      If cfg.Position = "TR" Then rBtnTopRight.Checked = True
      If cfg.Position = "BL" Then rBtnBottomLeft.Checked = True
      If cfg.Position = "BR" Then rBtnBottomRight.Checked = True

      ' Local Machine requires admin rights
      If Not IsAdministrator() Then
         chkBoxLM.Enabled = False
      End If

      ' Check if app is set to run at startup in either CU or LM
      If RegValueExists(Registry.CurrentUser, regPath, appName) Then
         chkBoxCU.Checked = True
      End If
      If RegValueExists(Registry.LocalMachine, regPath, appName) Then
         chkBoxLM.Checked = True
      End If
   End Sub

   Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
      ' Save settings
      If rBtnTopLeft.Checked Then cfg.Position = "TL"
      If rBtnTopRight.Checked Then cfg.Position = "TR"
      If rBtnBottomLeft.Checked Then cfg.Position = "BL"
      If rBtnBottomRight.Checked Then cfg.Position = "BR"
      SettingsJSON.Save(cfg)
      Me.Close()
   End Sub

   Private Sub rBtnTopLeft_CheckedChanged(sender As Object, e As EventArgs) Handles rBtnTopLeft.CheckedChanged
      If rBtnTopLeft.Checked Then
         _frmMain.Location = New Point(5, 5)
      End If
   End Sub

   Private Sub rBtnTopRight_CheckedChanged(sender As Object, e As EventArgs) Handles rBtnTopRight.CheckedChanged
      If rBtnTopRight.Checked Then
         _frmMain.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - _frmMain.Width - 5, 5)
      End If
   End Sub

   Private Sub rBtnBottomLeft_CheckedChanged(sender As Object, e As EventArgs) Handles rBtnBottomLeft.CheckedChanged
      If rBtnBottomLeft.Checked Then
         _frmMain.Location = New Point(5, Screen.PrimaryScreen.WorkingArea.Height - _frmMain.Height - 5)
      End If
   End Sub

   Private Sub rBtnBottomRight_CheckedChanged(sender As Object, e As EventArgs) Handles rBtnBottomRight.CheckedChanged
      If rBtnBottomRight.Checked Then
         _frmMain.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - _frmMain.Width - 5, Screen.PrimaryScreen.WorkingArea.Height - _frmMain.Height - 5)
      End If
   End Sub

   Private Sub chkBoxCU_CheckedChanged(sender As Object, e As EventArgs) Handles chkBoxCU.CheckedChanged
      If chkBoxCU.Checked Then
         RegWriteSZ(Registry.CurrentUser, regPath, appName, appPath)
      Else
         RegDeleteValue(Registry.CurrentUser, regPath, appName)
      End If
   End Sub

   Private Sub chkBoxLM_CheckedChanged(sender As Object, e As EventArgs) Handles chkBoxLM.CheckedChanged
      If chkBoxLM.Checked Then
         ' delete from CU to avoid app showing twice if user has both checked
         RegDeleteValue(Registry.CurrentUser, regPath, appName)
         RegWriteSZ(Registry.LocalMachine, regPath, appName, appPath)
      Else
         RegDeleteValue(Registry.LocalMachine, regPath, appName)
      End If
   End Sub
End Class