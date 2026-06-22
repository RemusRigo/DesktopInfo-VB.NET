'--------------------------------------------------------------------------------------------------
' gdi32.dll API declarations
'
'   (C) 2026 Remus Rigo
'      v1.0 - 2026-04-24
'--------------------------------------------------------------------------------------------------

Imports System.Runtime.InteropServices

Friend Module gdi32

   '-----------------------------------------------------------------------------------------------
   ' Structures

   <StructLayout(LayoutKind.Sequential)>
   Friend Structure GDI_POINT
      Public X As Integer
      Public Y As Integer
      Sub New(x As Integer, y As Integer)
         Me.X = x : Me.Y = y
      End Sub
   End Structure

   <StructLayout(LayoutKind.Sequential)>
   Friend Structure GDI_SIZE
      Public Width As Integer
      Public Height As Integer
      Sub New(w As Integer, h As Integer)
         Width = w : Height = h
      End Sub
   End Structure

   '-----------------------------------------------------------------------------------------------
   ' Functions

   <DllImport("gdi32.dll")>
   Friend Function CreateCompatibleDC(hDC As IntPtr) As IntPtr
   End Function

   <DllImport("gdi32.dll")>
   Friend Function DeleteDC(hDC As IntPtr) As Boolean
   End Function

   <DllImport("gdi32.dll")>
   Friend Function DeleteObject(hObj As IntPtr) As Boolean
   End Function

   <DllImport("gdi32.dll")>
   Friend Function SelectObject(hDC As IntPtr, hObj As IntPtr) As IntPtr
   End Function

End Module
