<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.txtFORENAME = New System.Windows.Forms.TextBox()
        Me.txtSURNAME = New System.Windows.Forms.TextBox()
        Me.btnDELETE = New System.Windows.Forms.Button()
        Me.btnADDNEW = New System.Windows.Forms.Button()
        Me.lblSURNAME = New System.Windows.Forms.Label()
        Me.lblFORENAME = New System.Windows.Forms.Label()
        Me.btnCLOSE = New System.Windows.Forms.Button()
        Me.btnOPEN = New System.Windows.Forms.Button()
        Me.btnUNCONFIRMED = New System.Windows.Forms.Button()
        Me.btnRESET = New System.Windows.Forms.Button()
        Me.lblPARENT = New System.Windows.Forms.Label()
        Me.txtPARENT = New System.Windows.Forms.TextBox()
        Me.txtPHONE = New System.Windows.Forms.TextBox()
        Me.lblPHONE = New System.Windows.Forms.Label()
        Me.lblDOB = New System.Windows.Forms.Label()
        Me.lblDAYS = New System.Windows.Forms.Label()
        Me.btnCANCEL = New System.Windows.Forms.Button()
        Me.txtDOB = New System.Windows.Forms.TextBox()
        Me.txtEMAIL = New System.Windows.Forms.TextBox()
        Me.txtADDRESS = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnCONFIRM = New System.Windows.Forms.Button()
        Me.btnUPDATE = New System.Windows.Forms.Button()
        Me.btnCOMMIT = New System.Windows.Forms.Button()
        Me.rbFIXED = New System.Windows.Forms.RadioButton()
        Me.rbVARIABLE = New System.Windows.Forms.RadioButton()
        Me.lblADDRESS = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtFORENAME
        '
        Me.txtFORENAME.Location = New System.Drawing.Point(396, 41)
        Me.txtFORENAME.Name = "txtFORENAME"
        Me.txtFORENAME.Size = New System.Drawing.Size(100, 20)
        Me.txtFORENAME.TabIndex = 14
        '
        'txtSURNAME
        '
        Me.txtSURNAME.Location = New System.Drawing.Point(396, 70)
        Me.txtSURNAME.Name = "txtSURNAME"
        Me.txtSURNAME.Size = New System.Drawing.Size(100, 20)
        Me.txtSURNAME.TabIndex = 13
        '
        'btnDELETE
        '
        Me.btnDELETE.Location = New System.Drawing.Point(630, 89)
        Me.btnDELETE.Name = "btnDELETE"
        Me.btnDELETE.Size = New System.Drawing.Size(75, 23)
        Me.btnDELETE.TabIndex = 20
        Me.btnDELETE.Text = "Delete"
        Me.btnDELETE.UseVisualStyleBackColor = True
        '
        'btnADDNEW
        '
        Me.btnADDNEW.Location = New System.Drawing.Point(630, 60)
        Me.btnADDNEW.Name = "btnADDNEW"
        Me.btnADDNEW.Size = New System.Drawing.Size(75, 23)
        Me.btnADDNEW.TabIndex = 17
        Me.btnADDNEW.Text = "Add New"
        Me.btnADDNEW.UseVisualStyleBackColor = True
        '
        'lblSURNAME
        '
        Me.lblSURNAME.AutoSize = True
        Me.lblSURNAME.Location = New System.Drawing.Point(336, 73)
        Me.lblSURNAME.Name = "lblSURNAME"
        Me.lblSURNAME.Size = New System.Drawing.Size(49, 13)
        Me.lblSURNAME.TabIndex = 19
        Me.lblSURNAME.Text = "Surname"
        '
        'lblFORENAME
        '
        Me.lblFORENAME.AutoSize = True
        Me.lblFORENAME.Location = New System.Drawing.Point(336, 48)
        Me.lblFORENAME.Name = "lblFORENAME"
        Me.lblFORENAME.Size = New System.Drawing.Size(54, 13)
        Me.lblFORENAME.TabIndex = 18
        Me.lblFORENAME.Text = "Forename"
        '
        'btnCLOSE
        '
        Me.btnCLOSE.Location = New System.Drawing.Point(178, 67)
        Me.btnCLOSE.Name = "btnCLOSE"
        Me.btnCLOSE.Size = New System.Drawing.Size(75, 23)
        Me.btnCLOSE.TabIndex = 16
        Me.btnCLOSE.Text = "Close"
        Me.btnCLOSE.UseVisualStyleBackColor = True
        '
        'btnOPEN
        '
        Me.btnOPEN.Location = New System.Drawing.Point(178, 39)
        Me.btnOPEN.Name = "btnOPEN"
        Me.btnOPEN.Size = New System.Drawing.Size(75, 23)
        Me.btnOPEN.TabIndex = 15
        Me.btnOPEN.Text = "Open"
        Me.btnOPEN.UseVisualStyleBackColor = True
        '
        'btnUNCONFIRMED
        '
        Me.btnUNCONFIRMED.Location = New System.Drawing.Point(630, 282)
        Me.btnUNCONFIRMED.Name = "btnUNCONFIRMED"
        Me.btnUNCONFIRMED.Size = New System.Drawing.Size(75, 23)
        Me.btnUNCONFIRMED.TabIndex = 68
        Me.btnUNCONFIRMED.Text = "Unconfirm"
        Me.btnUNCONFIRMED.UseVisualStyleBackColor = True
        '
        'btnRESET
        '
        Me.btnRESET.Location = New System.Drawing.Point(630, 180)
        Me.btnRESET.Name = "btnRESET"
        Me.btnRESET.Size = New System.Drawing.Size(75, 23)
        Me.btnRESET.TabIndex = 67
        Me.btnRESET.Text = "Reset"
        Me.btnRESET.UseVisualStyleBackColor = True
        '
        'lblPARENT
        '
        Me.lblPARENT.AutoSize = True
        Me.lblPARENT.Location = New System.Drawing.Point(294, 240)
        Me.lblPARENT.Name = "lblPARENT"
        Me.lblPARENT.Size = New System.Drawing.Size(89, 13)
        Me.lblPARENT.TabIndex = 66
        Me.lblPARENT.Text = "Parent/ Guardian"
        '
        'txtPARENT
        '
        Me.txtPARENT.Location = New System.Drawing.Point(396, 237)
        Me.txtPARENT.Name = "txtPARENT"
        Me.txtPARENT.Size = New System.Drawing.Size(100, 20)
        Me.txtPARENT.TabIndex = 65
        '
        'txtPHONE
        '
        Me.txtPHONE.Location = New System.Drawing.Point(396, 263)
        Me.txtPHONE.Name = "txtPHONE"
        Me.txtPHONE.Size = New System.Drawing.Size(100, 20)
        Me.txtPHONE.TabIndex = 63
        '
        'lblPHONE
        '
        Me.lblPHONE.AutoSize = True
        Me.lblPHONE.Location = New System.Drawing.Point(247, 266)
        Me.lblPHONE.Name = "lblPHONE"
        Me.lblPHONE.Size = New System.Drawing.Size(134, 13)
        Me.lblPHONE.TabIndex = 64
        Me.lblPHONE.Text = "Emergency Phone Number"
        '
        'lblDOB
        '
        Me.lblDOB.AutoSize = True
        Me.lblDOB.Location = New System.Drawing.Point(345, 190)
        Me.lblDOB.Name = "lblDOB"
        Me.lblDOB.Size = New System.Drawing.Size(36, 13)
        Me.lblDOB.TabIndex = 59
        Me.lblDOB.Text = "D.O.B"
        '
        'lblDAYS
        '
        Me.lblDAYS.AutoSize = True
        Me.lblDAYS.Location = New System.Drawing.Point(308, 292)
        Me.lblDAYS.Name = "lblDAYS"
        Me.lblDAYS.Size = New System.Drawing.Size(73, 13)
        Me.lblDAYS.TabIndex = 62
        Me.lblDAYS.Text = "Email Address"
        '
        'btnCANCEL
        '
        Me.btnCANCEL.Location = New System.Drawing.Point(630, 240)
        Me.btnCANCEL.Name = "btnCANCEL"
        Me.btnCANCEL.Size = New System.Drawing.Size(75, 23)
        Me.btnCANCEL.TabIndex = 53
        Me.btnCANCEL.Text = "Cancel"
        Me.btnCANCEL.UseVisualStyleBackColor = True
        '
        'txtDOB
        '
        Me.txtDOB.Location = New System.Drawing.Point(396, 187)
        Me.txtDOB.Name = "txtDOB"
        Me.txtDOB.Size = New System.Drawing.Size(100, 20)
        Me.txtDOB.TabIndex = 58
        '
        'txtEMAIL
        '
        Me.txtEMAIL.Location = New System.Drawing.Point(396, 289)
        Me.txtEMAIL.Name = "txtEMAIL"
        Me.txtEMAIL.Size = New System.Drawing.Size(100, 20)
        Me.txtEMAIL.TabIndex = 61
        '
        'txtADDRESS
        '
        Me.txtADDRESS.Location = New System.Drawing.Point(396, 213)
        Me.txtADDRESS.Name = "txtADDRESS"
        Me.txtADDRESS.Size = New System.Drawing.Size(100, 20)
        Me.txtADDRESS.TabIndex = 57
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(630, 210)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 52
        Me.Button1.Text = "Delete"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnCONFIRM
        '
        Me.btnCONFIRM.Location = New System.Drawing.Point(549, 282)
        Me.btnCONFIRM.Name = "btnCONFIRM"
        Me.btnCONFIRM.Size = New System.Drawing.Size(75, 23)
        Me.btnCONFIRM.TabIndex = 54
        Me.btnCONFIRM.Text = "CONFIRM"
        Me.btnCONFIRM.UseVisualStyleBackColor = True
        '
        'btnUPDATE
        '
        Me.btnUPDATE.Location = New System.Drawing.Point(630, 122)
        Me.btnUPDATE.Name = "btnUPDATE"
        Me.btnUPDATE.Size = New System.Drawing.Size(75, 23)
        Me.btnUPDATE.TabIndex = 51
        Me.btnUPDATE.Text = "Update"
        Me.btnUPDATE.UseVisualStyleBackColor = True
        '
        'btnCOMMIT
        '
        Me.btnCOMMIT.Location = New System.Drawing.Point(630, 152)
        Me.btnCOMMIT.Name = "btnCOMMIT"
        Me.btnCOMMIT.Size = New System.Drawing.Size(75, 23)
        Me.btnCOMMIT.TabIndex = 50
        Me.btnCOMMIT.Text = "Commit"
        Me.btnCOMMIT.UseVisualStyleBackColor = True
        '
        'rbFIXED
        '
        Me.rbFIXED.AutoSize = True
        Me.rbFIXED.Location = New System.Drawing.Point(547, 158)
        Me.rbFIXED.Name = "rbFIXED"
        Me.rbFIXED.Size = New System.Drawing.Size(56, 17)
        Me.rbFIXED.TabIndex = 55
        Me.rbFIXED.TabStop = True
        Me.rbFIXED.Text = "FIXED"
        Me.rbFIXED.UseVisualStyleBackColor = True
        '
        'rbVARIABLE
        '
        Me.rbVARIABLE.AutoSize = True
        Me.rbVARIABLE.Location = New System.Drawing.Point(547, 196)
        Me.rbVARIABLE.Name = "rbVARIABLE"
        Me.rbVARIABLE.Size = New System.Drawing.Size(77, 17)
        Me.rbVARIABLE.TabIndex = 56
        Me.rbVARIABLE.TabStop = True
        Me.rbVARIABLE.Text = "VARIABLE"
        Me.rbVARIABLE.UseVisualStyleBackColor = True
        '
        'lblADDRESS
        '
        Me.lblADDRESS.AutoSize = True
        Me.lblADDRESS.Location = New System.Drawing.Point(290, 215)
        Me.lblADDRESS.Name = "lblADDRESS"
        Me.lblADDRESS.Size = New System.Drawing.Size(95, 13)
        Me.lblADDRESS.TabIndex = 60
        Me.lblADDRESS.Text = "NO. Hours per day"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1133, 477)
        Me.Controls.Add(Me.btnUNCONFIRMED)
        Me.Controls.Add(Me.btnRESET)
        Me.Controls.Add(Me.lblPARENT)
        Me.Controls.Add(Me.txtPARENT)
        Me.Controls.Add(Me.txtPHONE)
        Me.Controls.Add(Me.lblPHONE)
        Me.Controls.Add(Me.lblDOB)
        Me.Controls.Add(Me.lblDAYS)
        Me.Controls.Add(Me.btnCANCEL)
        Me.Controls.Add(Me.txtDOB)
        Me.Controls.Add(Me.txtEMAIL)
        Me.Controls.Add(Me.txtADDRESS)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnCONFIRM)
        Me.Controls.Add(Me.btnUPDATE)
        Me.Controls.Add(Me.btnCOMMIT)
        Me.Controls.Add(Me.rbFIXED)
        Me.Controls.Add(Me.rbVARIABLE)
        Me.Controls.Add(Me.lblADDRESS)
        Me.Controls.Add(Me.txtFORENAME)
        Me.Controls.Add(Me.txtSURNAME)
        Me.Controls.Add(Me.btnDELETE)
        Me.Controls.Add(Me.btnADDNEW)
        Me.Controls.Add(Me.lblSURNAME)
        Me.Controls.Add(Me.lblFORENAME)
        Me.Controls.Add(Me.btnCLOSE)
        Me.Controls.Add(Me.btnOPEN)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtFORENAME As TextBox
    Friend WithEvents txtSURNAME As TextBox
    Friend WithEvents btnDELETE As Button
    Friend WithEvents btnADDNEW As Button
    Friend WithEvents lblSURNAME As Label
    Friend WithEvents lblFORENAME As Label
    Friend WithEvents btnCLOSE As Button
    Friend WithEvents btnOPEN As Button
    Friend WithEvents btnUNCONFIRMED As Button
    Friend WithEvents btnRESET As Button
    Friend WithEvents lblPARENT As Label
    Friend WithEvents txtPARENT As TextBox
    Friend WithEvents txtPHONE As TextBox
    Friend WithEvents lblPHONE As Label
    Friend WithEvents lblDOB As Label
    Friend WithEvents lblDAYS As Label
    Friend WithEvents btnCANCEL As Button
    Friend WithEvents txtDOB As TextBox
    Friend WithEvents txtEMAIL As TextBox
    Friend WithEvents txtADDRESS As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents btnCONFIRM As Button
    Friend WithEvents btnUPDATE As Button
    Friend WithEvents btnCOMMIT As Button
    Friend WithEvents rbFIXED As RadioButton
    Friend WithEvents rbVARIABLE As RadioButton
    Friend WithEvents lblADDRESS As Label
End Class
