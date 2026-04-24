<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOptions
   Inherits System.Windows.Forms.Form

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      Try
         If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
         End If
      Finally
         MyBase.Dispose(disposing)
      End Try
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOptions))
      grpBoxPosition = New GroupBox()
      rBtnBottomRight = New RadioButton()
      rBtnBottomLeft = New RadioButton()
      rBtnTopRight = New RadioButton()
      rBtnTopLeft = New RadioButton()
      btnOk = New Button()
      grpBoxPosition.SuspendLayout()
      SuspendLayout()
      ' 
      ' grpBoxPosition
      ' 
      grpBoxPosition.Controls.Add(rBtnBottomRight)
      grpBoxPosition.Controls.Add(rBtnBottomLeft)
      grpBoxPosition.Controls.Add(rBtnTopRight)
      grpBoxPosition.Controls.Add(rBtnTopLeft)
      grpBoxPosition.Location = New Point(3, 3)
      grpBoxPosition.Name = "grpBoxPosition"
      grpBoxPosition.Size = New Size(232, 124)
      grpBoxPosition.TabIndex = 1
      grpBoxPosition.TabStop = False
      grpBoxPosition.Text = "Position"
      ' 
      ' rBtnBottomRight
      ' 
      rBtnBottomRight.AutoSize = True
      rBtnBottomRight.Location = New Point(6, 97)
      rBtnBottomRight.Name = "rBtnBottomRight"
      rBtnBottomRight.Size = New Size(96, 19)
      rBtnBottomRight.TabIndex = 3
      rBtnBottomRight.TabStop = True
      rBtnBottomRight.Text = "Bottom Right"
      rBtnBottomRight.UseVisualStyleBackColor = True
      ' 
      ' rBtnBottomLeft
      ' 
      rBtnBottomLeft.AutoSize = True
      rBtnBottomLeft.Location = New Point(6, 72)
      rBtnBottomLeft.Name = "rBtnBottomLeft"
      rBtnBottomLeft.Size = New Size(88, 19)
      rBtnBottomLeft.TabIndex = 2
      rBtnBottomLeft.TabStop = True
      rBtnBottomLeft.Text = "Bottom Left"
      rBtnBottomLeft.UseVisualStyleBackColor = True
      ' 
      ' rBtnTopRight
      ' 
      rBtnTopRight.AutoSize = True
      rBtnTopRight.Location = New Point(6, 47)
      rBtnTopRight.Name = "rBtnTopRight"
      rBtnTopRight.Size = New Size(76, 19)
      rBtnTopRight.TabIndex = 1
      rBtnTopRight.TabStop = True
      rBtnTopRight.Text = "Top Right"
      rBtnTopRight.UseVisualStyleBackColor = True
      ' 
      ' rBtnTopLeft
      ' 
      rBtnTopLeft.AutoSize = True
      rBtnTopLeft.Location = New Point(6, 22)
      rBtnTopLeft.Name = "rBtnTopLeft"
      rBtnTopLeft.Size = New Size(68, 19)
      rBtnTopLeft.TabIndex = 0
      rBtnTopLeft.TabStop = True
      rBtnTopLeft.Text = "Top Left"
      rBtnTopLeft.UseVisualStyleBackColor = True
      ' 
      ' btnOk
      ' 
      btnOk.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
      btnOk.Location = New Point(246, 104)
      btnOk.Name = "btnOk"
      btnOk.Size = New Size(40, 23)
      btnOk.TabIndex = 2
      btnOk.Text = "O&k"
      btnOk.UseVisualStyleBackColor = True
      ' 
      ' frmOptions
      ' 
      AutoScaleDimensions = New SizeF(7F, 15F)
      AutoScaleMode = AutoScaleMode.Font
      ClientSize = New Size(294, 131)
      Controls.Add(btnOk)
      Controls.Add(grpBoxPosition)
      FormBorderStyle = FormBorderStyle.FixedSingle
      Icon = CType(resources.GetObject("$this.Icon"), Icon)
      Name = "frmOptions"
      ShowInTaskbar = False
      StartPosition = FormStartPosition.CenterScreen
      Text = "Options"
      grpBoxPosition.ResumeLayout(False)
      grpBoxPosition.PerformLayout()
      ResumeLayout(False)
   End Sub

   Friend WithEvents grpBoxPosition As GroupBox
   Friend WithEvents rBtnBottomRight As RadioButton
   Friend WithEvents rBtnBottomLeft As RadioButton
   Friend WithEvents rBtnTopRight As RadioButton
   Friend WithEvents rBtnTopLeft As RadioButton
   Friend WithEvents btnOk As Button
End Class
