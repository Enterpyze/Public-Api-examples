<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblEvntToken = New System.Windows.Forms.Label()
        Me.txtEvntToken = New System.Windows.Forms.TextBox()
        Me.chkEvntTokenShow = New System.Windows.Forms.CheckBox()
        Me.lblEntEmail = New System.Windows.Forms.Label()
        Me.txtEntEmail = New System.Windows.Forms.TextBox()
        Me.txtEntPassword = New System.Windows.Forms.TextBox()
        Me.lblEntPassword = New System.Windows.Forms.Label()
        Me.chkEntPwdShow = New System.Windows.Forms.CheckBox()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.grpConnection = New System.Windows.Forms.GroupBox()
        Me.cboDefBP = New System.Windows.Forms.ComboBox()
        Me.txtEntOrgId = New System.Windows.Forms.TextBox()
        Me.lblIncludeFee = New System.Windows.Forms.Label()
        Me.lblCreateBP = New System.Windows.Forms.Label()
        Me.lblEntOrgId = New System.Windows.Forms.Label()
        Me.lblDefBP = New System.Windows.Forms.Label()
        Me.txtEvntEmail = New System.Windows.Forms.TextBox()
        Me.chkCreateBP = New System.Windows.Forms.CheckBox()
        Me.lblEvntEmail = New System.Windows.Forms.Label()
        Me.txtEvntUser = New System.Windows.Forms.TextBox()
        Me.chkIncludeFee = New System.Windows.Forms.CheckBox()
        Me.lblEvntUser = New System.Windows.Forms.Label()
        Me.cboEntEnvType = New System.Windows.Forms.ComboBox()
        Me.lblEntEvnType = New System.Windows.Forms.Label()
        Me.btnConfigLoad = New System.Windows.Forms.Button()
        Me.btnConfigSave = New System.Windows.Forms.Button()
        Me.grpDataImport = New System.Windows.Forms.GroupBox()
        Me.chkIgnoreImported = New System.Windows.Forms.CheckBox()
        Me.grpInstructions = New System.Windows.Forms.GroupBox()
        Me.lblInstructions = New System.Windows.Forms.Label()
        Me.btnGetOrders = New System.Windows.Forms.Button()
        Me.btnGetEvents = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblOrders = New System.Windows.Forms.Label()
        Me.dgvEntDocs = New System.Windows.Forms.DataGridView()
        Me.cboEvents = New System.Windows.Forms.ComboBox()
        Me.lblEvents = New System.Windows.Forms.Label()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.dgvEvntOrders = New System.Windows.Forms.DataGridView()
        Me.StatusStrip1.SuspendLayout()
        Me.grpConnection.SuspendLayout()
        Me.grpDataImport.SuspendLayout()
        Me.grpInstructions.SuspendLayout()
        CType(Me.dgvEntDocs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvEvntOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(1008, 714)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblEvntToken
        '
        Me.lblEvntToken.AutoSize = True
        Me.lblEvntToken.Location = New System.Drawing.Point(6, 19)
        Me.lblEvntToken.Name = "lblEvntToken"
        Me.lblEvntToken.Size = New System.Drawing.Size(125, 13)
        Me.lblEvntToken.TabIndex = 0
        Me.lblEvntToken.Text = "Eventbrite OAuth Token:"
        '
        'txtEvntToken
        '
        Me.txtEvntToken.Location = New System.Drawing.Point(137, 16)
        Me.txtEvntToken.Name = "txtEvntToken"
        Me.txtEvntToken.Size = New System.Drawing.Size(212, 20)
        Me.txtEvntToken.TabIndex = 0
        Me.txtEvntToken.UseSystemPasswordChar = True
        '
        'chkEvntTokenShow
        '
        Me.chkEvntTokenShow.AutoSize = True
        Me.chkEvntTokenShow.Location = New System.Drawing.Point(355, 17)
        Me.chkEvntTokenShow.Name = "chkEvntTokenShow"
        Me.chkEvntTokenShow.Size = New System.Drawing.Size(53, 17)
        Me.chkEvntTokenShow.TabIndex = 10
        Me.chkEvntTokenShow.Text = "Show"
        Me.chkEvntTokenShow.UseVisualStyleBackColor = True
        '
        'lblEntEmail
        '
        Me.lblEntEmail.AutoSize = True
        Me.lblEntEmail.Location = New System.Drawing.Point(6, 72)
        Me.lblEntEmail.Name = "lblEntEmail"
        Me.lblEntEmail.Size = New System.Drawing.Size(88, 13)
        Me.lblEntEmail.TabIndex = 3
        Me.lblEntEmail.Text = "Enterpryze Email:"
        '
        'txtEntEmail
        '
        Me.txtEntEmail.Location = New System.Drawing.Point(137, 69)
        Me.txtEntEmail.Name = "txtEntEmail"
        Me.txtEntEmail.Size = New System.Drawing.Size(212, 20)
        Me.txtEntEmail.TabIndex = 2
        '
        'txtEntPassword
        '
        Me.txtEntPassword.Location = New System.Drawing.Point(137, 95)
        Me.txtEntPassword.Name = "txtEntPassword"
        Me.txtEntPassword.Size = New System.Drawing.Size(212, 20)
        Me.txtEntPassword.TabIndex = 3
        Me.txtEntPassword.UseSystemPasswordChar = True
        '
        'lblEntPassword
        '
        Me.lblEntPassword.AutoSize = True
        Me.lblEntPassword.Location = New System.Drawing.Point(6, 98)
        Me.lblEntPassword.Name = "lblEntPassword"
        Me.lblEntPassword.Size = New System.Drawing.Size(109, 13)
        Me.lblEntPassword.TabIndex = 6
        Me.lblEntPassword.Text = "Enterpryze Password:"
        '
        'chkEntPwdShow
        '
        Me.chkEntPwdShow.AutoSize = True
        Me.chkEntPwdShow.Location = New System.Drawing.Point(355, 95)
        Me.chkEntPwdShow.Name = "chkEntPwdShow"
        Me.chkEntPwdShow.Size = New System.Drawing.Size(53, 17)
        Me.chkEntPwdShow.TabIndex = 11
        Me.chkEntPwdShow.Text = "Show"
        Me.chkEntPwdShow.UseVisualStyleBackColor = True
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(6, 141)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(75, 23)
        Me.btnConnect.TabIndex = 4
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 740)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1095, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "Connecting..."
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 17)
        '
        'grpConnection
        '
        Me.grpConnection.Controls.Add(Me.cboDefBP)
        Me.grpConnection.Controls.Add(Me.txtEntOrgId)
        Me.grpConnection.Controls.Add(Me.lblIncludeFee)
        Me.grpConnection.Controls.Add(Me.lblCreateBP)
        Me.grpConnection.Controls.Add(Me.lblEntOrgId)
        Me.grpConnection.Controls.Add(Me.lblDefBP)
        Me.grpConnection.Controls.Add(Me.txtEvntEmail)
        Me.grpConnection.Controls.Add(Me.chkCreateBP)
        Me.grpConnection.Controls.Add(Me.lblEvntEmail)
        Me.grpConnection.Controls.Add(Me.txtEvntUser)
        Me.grpConnection.Controls.Add(Me.chkIncludeFee)
        Me.grpConnection.Controls.Add(Me.lblEvntUser)
        Me.grpConnection.Controls.Add(Me.cboEntEnvType)
        Me.grpConnection.Controls.Add(Me.lblEntEvnType)
        Me.grpConnection.Controls.Add(Me.lblEvntToken)
        Me.grpConnection.Controls.Add(Me.btnConnect)
        Me.grpConnection.Controls.Add(Me.chkEvntTokenShow)
        Me.grpConnection.Controls.Add(Me.txtEntEmail)
        Me.grpConnection.Controls.Add(Me.chkEntPwdShow)
        Me.grpConnection.Controls.Add(Me.txtEntPassword)
        Me.grpConnection.Controls.Add(Me.lblEntEmail)
        Me.grpConnection.Controls.Add(Me.lblEntPassword)
        Me.grpConnection.Controls.Add(Me.txtEvntToken)
        Me.grpConnection.Location = New System.Drawing.Point(12, 12)
        Me.grpConnection.Name = "grpConnection"
        Me.grpConnection.Size = New System.Drawing.Size(1071, 170)
        Me.grpConnection.TabIndex = 8
        Me.grpConnection.TabStop = False
        Me.grpConnection.Text = "Configuration"
        '
        'cboDefBP
        '
        Me.cboDefBP.FormattingEnabled = True
        Me.cboDefBP.Location = New System.Drawing.Point(855, 54)
        Me.cboDefBP.Name = "cboDefBP"
        Me.cboDefBP.Size = New System.Drawing.Size(169, 21)
        Me.cboDefBP.TabIndex = 22
        '
        'txtEntOrgId
        '
        Me.txtEntOrgId.Location = New System.Drawing.Point(515, 72)
        Me.txtEntOrgId.Name = "txtEntOrgId"
        Me.txtEntOrgId.ReadOnly = True
        Me.txtEntOrgId.Size = New System.Drawing.Size(197, 20)
        Me.txtEntOrgId.TabIndex = 15
        '
        'lblIncludeFee
        '
        Me.lblIncludeFee.AutoSize = True
        Me.lblIncludeFee.Location = New System.Drawing.Point(718, 16)
        Me.lblIncludeFee.Name = "lblIncludeFee"
        Me.lblIncludeFee.Size = New System.Drawing.Size(117, 13)
        Me.lblIncludeFee.TabIndex = 20
        Me.lblIncludeFee.Text = "Include Eventbrite Fee:"
        '
        'lblCreateBP
        '
        Me.lblCreateBP.AutoSize = True
        Me.lblCreateBP.Location = New System.Drawing.Point(718, 35)
        Me.lblCreateBP.Name = "lblCreateBP"
        Me.lblCreateBP.Size = New System.Drawing.Size(124, 13)
        Me.lblCreateBP.TabIndex = 19
        Me.lblCreateBP.Text = "Create BP Per Customer:"
        '
        'lblEntOrgId
        '
        Me.lblEntOrgId.AutoSize = True
        Me.lblEntOrgId.Location = New System.Drawing.Point(414, 74)
        Me.lblEntOrgId.Name = "lblEntOrgId"
        Me.lblEntOrgId.Size = New System.Drawing.Size(95, 13)
        Me.lblEntOrgId.TabIndex = 14
        Me.lblEntOrgId.Text = "Enterpryze Org. Id:"
        '
        'lblDefBP
        '
        Me.lblDefBP.AutoSize = True
        Me.lblDefBP.Location = New System.Drawing.Point(718, 57)
        Me.lblDefBP.Name = "lblDefBP"
        Me.lblDefBP.Size = New System.Drawing.Size(61, 13)
        Me.lblDefBP.TabIndex = 16
        Me.lblDefBP.Text = "Default BP:"
        '
        'txtEvntEmail
        '
        Me.txtEvntEmail.Location = New System.Drawing.Point(515, 45)
        Me.txtEvntEmail.Name = "txtEvntEmail"
        Me.txtEvntEmail.ReadOnly = True
        Me.txtEvntEmail.Size = New System.Drawing.Size(197, 20)
        Me.txtEvntEmail.TabIndex = 13
        '
        'chkCreateBP
        '
        Me.chkCreateBP.AutoSize = True
        Me.chkCreateBP.Location = New System.Drawing.Point(855, 34)
        Me.chkCreateBP.Name = "chkCreateBP"
        Me.chkCreateBP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkCreateBP.Size = New System.Drawing.Size(15, 14)
        Me.chkCreateBP.TabIndex = 12
        Me.chkCreateBP.UseVisualStyleBackColor = True
        '
        'lblEvntEmail
        '
        Me.lblEvntEmail.AutoSize = True
        Me.lblEvntEmail.Location = New System.Drawing.Point(414, 47)
        Me.lblEvntEmail.Name = "lblEvntEmail"
        Me.lblEvntEmail.Size = New System.Drawing.Size(86, 13)
        Me.lblEvntEmail.TabIndex = 12
        Me.lblEvntEmail.Text = "Eventbrite Email:"
        '
        'txtEvntUser
        '
        Me.txtEvntUser.Location = New System.Drawing.Point(515, 17)
        Me.txtEvntUser.Name = "txtEvntUser"
        Me.txtEvntUser.ReadOnly = True
        Me.txtEvntUser.Size = New System.Drawing.Size(197, 20)
        Me.txtEvntUser.TabIndex = 11
        '
        'chkIncludeFee
        '
        Me.chkIncludeFee.AutoSize = True
        Me.chkIncludeFee.Location = New System.Drawing.Point(855, 14)
        Me.chkIncludeFee.Name = "chkIncludeFee"
        Me.chkIncludeFee.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkIncludeFee.Size = New System.Drawing.Size(15, 14)
        Me.chkIncludeFee.TabIndex = 11
        Me.chkIncludeFee.UseVisualStyleBackColor = True
        '
        'lblEvntUser
        '
        Me.lblEvntUser.AutoSize = True
        Me.lblEvntUser.Location = New System.Drawing.Point(414, 19)
        Me.lblEvntUser.Name = "lblEvntUser"
        Me.lblEvntUser.Size = New System.Drawing.Size(83, 13)
        Me.lblEvntUser.TabIndex = 10
        Me.lblEvntUser.Text = "Eventbrite User:"
        '
        'cboEntEnvType
        '
        Me.cboEntEnvType.FormattingEnabled = True
        Me.cboEntEnvType.Location = New System.Drawing.Point(137, 42)
        Me.cboEntEnvType.Name = "cboEntEnvType"
        Me.cboEntEnvType.Size = New System.Drawing.Size(212, 21)
        Me.cboEntEnvType.TabIndex = 1
        '
        'lblEntEvnType
        '
        Me.lblEntEvnType.AutoSize = True
        Me.lblEntEvnType.Location = New System.Drawing.Point(6, 45)
        Me.lblEntEvnType.Name = "lblEntEvnType"
        Me.lblEntEvnType.Size = New System.Drawing.Size(122, 13)
        Me.lblEntEvnType.TabIndex = 8
        Me.lblEntEvnType.Text = "Enterpryze Environment:"
        '
        'btnConfigLoad
        '
        Me.btnConfigLoad.Location = New System.Drawing.Point(909, 23)
        Me.btnConfigLoad.Name = "btnConfigLoad"
        Me.btnConfigLoad.Size = New System.Drawing.Size(75, 23)
        Me.btnConfigLoad.TabIndex = 21
        Me.btnConfigLoad.Text = "Load Config"
        Me.btnConfigLoad.UseVisualStyleBackColor = True
        Me.btnConfigLoad.Visible = False
        '
        'btnConfigSave
        '
        Me.btnConfigSave.Location = New System.Drawing.Point(990, 23)
        Me.btnConfigSave.Name = "btnConfigSave"
        Me.btnConfigSave.Size = New System.Drawing.Size(75, 23)
        Me.btnConfigSave.TabIndex = 16
        Me.btnConfigSave.Text = "Save Config"
        Me.btnConfigSave.UseVisualStyleBackColor = True
        '
        'grpDataImport
        '
        Me.grpDataImport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDataImport.Controls.Add(Me.chkIgnoreImported)
        Me.grpDataImport.Controls.Add(Me.grpInstructions)
        Me.grpDataImport.Controls.Add(Me.btnConfigLoad)
        Me.grpDataImport.Controls.Add(Me.btnGetOrders)
        Me.grpDataImport.Controls.Add(Me.btnConfigSave)
        Me.grpDataImport.Controls.Add(Me.btnGetEvents)
        Me.grpDataImport.Controls.Add(Me.Label3)
        Me.grpDataImport.Controls.Add(Me.lblOrders)
        Me.grpDataImport.Controls.Add(Me.dgvEntDocs)
        Me.grpDataImport.Controls.Add(Me.cboEvents)
        Me.grpDataImport.Controls.Add(Me.lblEvents)
        Me.grpDataImport.Controls.Add(Me.btnImport)
        Me.grpDataImport.Controls.Add(Me.dgvEvntOrders)
        Me.grpDataImport.Location = New System.Drawing.Point(12, 188)
        Me.grpDataImport.Name = "grpDataImport"
        Me.grpDataImport.Size = New System.Drawing.Size(1071, 520)
        Me.grpDataImport.TabIndex = 9
        Me.grpDataImport.TabStop = False
        Me.grpDataImport.Text = "Data Import"
        '
        'chkIgnoreImported
        '
        Me.chkIgnoreImported.AutoSize = True
        Me.chkIgnoreImported.Location = New System.Drawing.Point(517, 33)
        Me.chkIgnoreImported.Name = "chkIgnoreImported"
        Me.chkIgnoreImported.Size = New System.Drawing.Size(134, 17)
        Me.chkIgnoreImported.TabIndex = 23
        Me.chkIgnoreImported.Text = "Ignore Imported Orders"
        Me.chkIgnoreImported.UseVisualStyleBackColor = True
        Me.chkIgnoreImported.Visible = False
        '
        'grpInstructions
        '
        Me.grpInstructions.Controls.Add(Me.lblInstructions)
        Me.grpInstructions.Location = New System.Drawing.Point(805, 14)
        Me.grpInstructions.Name = "grpInstructions"
        Me.grpInstructions.Size = New System.Drawing.Size(88, 36)
        Me.grpInstructions.TabIndex = 10
        Me.grpInstructions.TabStop = False
        Me.grpInstructions.Text = "Instructions"
        Me.grpInstructions.Visible = False
        '
        'lblInstructions
        '
        Me.lblInstructions.AutoSize = True
        Me.lblInstructions.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInstructions.Location = New System.Drawing.Point(6, 16)
        Me.lblInstructions.Name = "lblInstructions"
        Me.lblInstructions.Size = New System.Drawing.Size(97, 13)
        Me.lblInstructions.TabIndex = 0
        Me.lblInstructions.Text = "Instructions..."
        '
        'btnGetOrders
        '
        Me.btnGetOrders.Location = New System.Drawing.Point(436, 27)
        Me.btnGetOrders.Name = "btnGetOrders"
        Me.btnGetOrders.Size = New System.Drawing.Size(75, 23)
        Me.btnGetOrders.TabIndex = 19
        Me.btnGetOrders.Text = "Get Orders"
        Me.btnGetOrders.UseVisualStyleBackColor = True
        '
        'btnGetEvents
        '
        Me.btnGetEvents.Location = New System.Drawing.Point(355, 27)
        Me.btnGetEvents.Name = "btnGetEvents"
        Me.btnGetEvents.Size = New System.Drawing.Size(75, 23)
        Me.btnGetEvents.TabIndex = 18
        Me.btnGetEvents.Text = "Get Events"
        Me.btnGetEvents.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 294)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Results:"
        '
        'lblOrders
        '
        Me.lblOrders.AutoSize = True
        Me.lblOrders.Location = New System.Drawing.Point(6, 59)
        Me.lblOrders.Name = "lblOrders"
        Me.lblOrders.Size = New System.Drawing.Size(41, 13)
        Me.lblOrders.TabIndex = 14
        Me.lblOrders.Text = "Orders:"
        '
        'dgvEntDocs
        '
        Me.dgvEntDocs.AllowUserToAddRows = False
        Me.dgvEntDocs.AllowUserToDeleteRows = False
        Me.dgvEntDocs.AllowUserToOrderColumns = True
        Me.dgvEntDocs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEntDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEntDocs.Location = New System.Drawing.Point(137, 294)
        Me.dgvEntDocs.Name = "dgvEntDocs"
        Me.dgvEntDocs.ReadOnly = True
        Me.dgvEntDocs.Size = New System.Drawing.Size(928, 220)
        Me.dgvEntDocs.TabIndex = 11
        '
        'cboEvents
        '
        Me.cboEvents.FormattingEnabled = True
        Me.cboEvents.Location = New System.Drawing.Point(137, 29)
        Me.cboEvents.Name = "cboEvents"
        Me.cboEvents.Size = New System.Drawing.Size(212, 21)
        Me.cboEvents.TabIndex = 5
        '
        'lblEvents
        '
        Me.lblEvents.AutoSize = True
        Me.lblEvents.Location = New System.Drawing.Point(6, 29)
        Me.lblEvents.Name = "lblEvents"
        Me.lblEvents.Size = New System.Drawing.Size(43, 13)
        Me.lblEvents.TabIndex = 8
        Me.lblEvents.Text = "Events:"
        '
        'btnImport
        '
        Me.btnImport.Location = New System.Drawing.Point(9, 243)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(75, 23)
        Me.btnImport.TabIndex = 6
        Me.btnImport.Text = "Import"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'dgvEvntOrders
        '
        Me.dgvEvntOrders.AllowUserToAddRows = False
        Me.dgvEvntOrders.AllowUserToDeleteRows = False
        Me.dgvEvntOrders.AllowUserToOrderColumns = True
        Me.dgvEvntOrders.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEvntOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEvntOrders.Location = New System.Drawing.Point(137, 59)
        Me.dgvEvntOrders.Name = "dgvEvntOrders"
        Me.dgvEvntOrders.Size = New System.Drawing.Size(928, 207)
        Me.dgvEvntOrders.TabIndex = 12
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1095, 762)
        Me.Controls.Add(Me.grpDataImport)
        Me.Controls.Add(Me.grpConnection)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnClose)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Enterpryze - Eventbrite Integration"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.grpConnection.ResumeLayout(False)
        Me.grpConnection.PerformLayout()
        Me.grpDataImport.ResumeLayout(False)
        Me.grpDataImport.PerformLayout()
        Me.grpInstructions.ResumeLayout(False)
        Me.grpInstructions.PerformLayout()
        CType(Me.dgvEntDocs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvEvntOrders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As Button
    Friend WithEvents chkEntPwdShow As CheckBox
    Friend WithEvents lblEntPassword As Label
    Friend WithEvents txtEntPassword As TextBox
    Friend WithEvents txtEntEmail As TextBox
    Friend WithEvents lblEntEmail As Label
    Friend WithEvents chkEvntTokenShow As CheckBox
    Friend WithEvents txtEvntToken As TextBox
    Friend WithEvents lblEvntToken As Label
    Friend WithEvents btnConnect As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents grpConnection As GroupBox
    Friend WithEvents grpDataImport As GroupBox
    Friend WithEvents lblOrders As Label
    Friend WithEvents cboEvents As ComboBox
    Friend WithEvents lblEvents As Label
    Friend WithEvents btnImport As Button
    Friend WithEvents dgvEvntOrders As DataGridView
    Friend WithEvents dgvEntDocs As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents cboEntEnvType As ComboBox
    Friend WithEvents lblEntEvnType As Label
    Friend WithEvents txtEvntUser As TextBox
    Friend WithEvents lblEvntUser As Label
    Friend WithEvents txtEvntEmail As TextBox
    Friend WithEvents lblEvntEmail As Label
    Friend WithEvents txtEntOrgId As TextBox
    Friend WithEvents lblEntOrgId As Label
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents btnGetEvents As Button
    Friend WithEvents btnGetOrders As Button
    Friend WithEvents grpInstructions As GroupBox
    Friend WithEvents lblInstructions As Label
    Friend WithEvents chkIncludeFee As CheckBox
    Friend WithEvents chkCreateBP As CheckBox
    Friend WithEvents lblCreateBP As Label
    Friend WithEvents lblDefBP As Label
    Friend WithEvents lblIncludeFee As Label
    Friend WithEvents btnConfigLoad As Button
    Friend WithEvents btnConfigSave As Button
    Friend WithEvents cboDefBP As ComboBox
    Friend WithEvents chkIgnoreImported As CheckBox
End Class
