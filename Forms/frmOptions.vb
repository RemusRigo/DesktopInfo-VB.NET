'--------------------------------------------------------------------------------------------------
' DesktopInfo
'    (C) 2026 Remus Rigo
'       v1.0.2026-04-24
'--------------------------------------------------------------------------------------------------

Public Class frmOptions

   Private _frmMain As frmDesktopInfo
   Private cfg As AppSettings

   Public Sub New(frmMain As frmDesktopInfo)
      InitializeComponent()
      _frmMain = frmMain
   End Sub

   Private Sub frmOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      cfg = Settings.Load()
      If cfg.Position = "TL" Then rBtnTopLeft.Checked = True
      If cfg.Position = "TR" Then rBtnTopRight.Checked = True
      If cfg.Position = "BL" Then rBtnBottomLeft.Checked = True
      If cfg.Position = "BR" Then rBtnBottomRight.Checked = True
   End Sub

   Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
      ' Save settings
      If rBtnTopLeft.Checked Then cfg.Position = "TL"
      If rBtnTopRight.Checked Then cfg.Position = "TR"
      If rBtnBottomLeft.Checked Then cfg.Position = "BL"
      If rBtnBottomRight.Checked Then cfg.Position = "BR"
      Settings.Save(cfg)
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
End Class