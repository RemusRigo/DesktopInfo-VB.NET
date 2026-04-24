'--------------------------------------------------------------------------------------------------
' DesktopInfo
'    (C) 2026 Remus Rigo
'       v1.0.2026-04-24
'--------------------------------------------------------------------------------------------------

Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Module SysTray

   Private WithEvents tray As NotifyIcon
   Private trayContextMenu As ContextMenuStrip
   Private frm As frmDesktopInfo

   <STAThread>
   Sub Main()
      Application.EnableVisualStyles()
      Application.SetCompatibleTextRenderingDefault(False)

      trayContextMenu = New ContextMenuStrip()
      trayContextMenu.Items.Add("About", Nothing, AddressOf Menu_About)
      trayContextMenu.Items.Add(New ToolStripSeparator())
      trayContextMenu.Items.Add("Options", Nothing, AddressOf Menu_Options)
      trayContextMenu.Items.Add(New ToolStripSeparator())
      trayContextMenu.Items.Add("Exit", Nothing, AddressOf Menu_Exit)

      ' Configure tray icon
      tray = New NotifyIcon()
      tray.Text = "DesktopInfo v1.1"
      'tray.Icon = SystemIcons.Application
      tray.Icon = My.Resources.Resources.Desktop
      tray.ContextMenuStrip = trayContextMenu
      tray.Visible = True
      tray.ShowBalloonTip(500, "DesktopInfo", "Running in background.", ToolTipIcon.Info)

      frm = New frmDesktopInfo()
      frm.ShowInTaskbar = False

      Application.Run(frm)
   End Sub

   Private Sub Menu_About(sender As Object, e As EventArgs)
      Dim frmAbout As New frmAbout()
      frmAbout.ShowDialog()
   End Sub

   Private Sub Menu_Options(sender As Object, e As EventArgs)
      Dim frmOptions As New frmOptions(frm)
      frmOptions.Show()
   End Sub

   Private Sub Menu_Exit(sender As Object, e As EventArgs)
      tray.Visible = False
      tray.Dispose()

      If frm IsNot Nothing AndAlso Not frm.IsDisposed Then
         frm.Close()
      End If
   End Sub

End Module
