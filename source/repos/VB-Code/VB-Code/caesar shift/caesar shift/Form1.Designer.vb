<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.btnENCRYPT = New System.Windows.Forms.Button()
        Me.btnDECRYPT = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnENCRYPT
        '
        Me.btnENCRYPT.Location = New System.Drawing.Point(146, 53)
        Me.btnENCRYPT.Name = "btnENCRYPT"
        Me.btnENCRYPT.Size = New System.Drawing.Size(75, 23)
        Me.btnENCRYPT.TabIndex = 0
        Me.btnENCRYPT.Text = "Encrypt"
        Me.btnENCRYPT.UseVisualStyleBackColor = True
        '
        'btnDECRYPT
        '
        Me.btnDECRYPT.Location = New System.Drawing.Point(146, 203)
        Me.btnDECRYPT.Name = "btnDECRYPT"
        Me.btnDECRYPT.Size = New System.Drawing.Size(75, 23)
        Me.btnDECRYPT.TabIndex = 1
        Me.btnDECRYPT.Text = "Decrypt"
        Me.btnDECRYPT.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(388, 81)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(463, 230)
        Me.TextBox1.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(975, 383)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btnDECRYPT)
        Me.Controls.Add(Me.btnENCRYPT)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnENCRYPT As Button
    Friend WithEvents btnDECRYPT As Button
    Friend WithEvents TextBox1 As TextBox
End Class
