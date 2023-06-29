<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.lblAppName = New System.Windows.Forms.Label()
        Me.lblWebAddress = New System.Windows.Forms.Label()
        Me.chkStartShortcut = New System.Windows.Forms.CheckBox()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtAppName = New System.Windows.Forms.TextBox()
        Me.txtWebAddress = New System.Windows.Forms.TextBox()
        Me.chkDesktopShortcut = New System.Windows.Forms.CheckBox()
        Me.worker = New System.ComponentModel.BackgroundWorker()
        Me.pbProgress = New System.Windows.Forms.ProgressBar()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblAppName
        '
        Me.lblAppName.AutoSize = True
        Me.lblAppName.Location = New System.Drawing.Point(13, 50)
        Me.lblAppName.Name = "lblAppName"
        Me.lblAppName.Size = New System.Drawing.Size(60, 13)
        Me.lblAppName.TabIndex = 0
        Me.lblAppName.Text = "App Name:"
        '
        'lblWebAddress
        '
        Me.lblWebAddress.AutoSize = True
        Me.lblWebAddress.Location = New System.Drawing.Point(13, 77)
        Me.lblWebAddress.Name = "lblWebAddress"
        Me.lblWebAddress.Size = New System.Drawing.Size(74, 13)
        Me.lblWebAddress.TabIndex = 1
        Me.lblWebAddress.Text = "Web Address:"
        '
        'chkStartShortcut
        '
        Me.chkStartShortcut.AutoSize = True
        Me.chkStartShortcut.Checked = True
        Me.chkStartShortcut.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkStartShortcut.Location = New System.Drawing.Point(13, 104)
        Me.chkStartShortcut.Name = "chkStartShortcut"
        Me.chkStartShortcut.Size = New System.Drawing.Size(111, 17)
        Me.chkStartShortcut.TabIndex = 2
        Me.chkStartShortcut.Text = "Add to Start menu"
        Me.chkStartShortcut.UseVisualStyleBackColor = True
        '
        'btnCreate
        '
        Me.btnCreate.Location = New System.Drawing.Point(163, 152)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(75, 23)
        Me.btnCreate.TabIndex = 3
        Me.btnCreate.Text = "Create"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(244, 152)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtAppName
        '
        Me.txtAppName.Location = New System.Drawing.Point(77, 47)
        Me.txtAppName.Name = "txtAppName"
        Me.txtAppName.Size = New System.Drawing.Size(242, 20)
        Me.txtAppName.TabIndex = 5
        '
        'txtWebAddress
        '
        Me.txtWebAddress.Location = New System.Drawing.Point(92, 75)
        Me.txtWebAddress.Name = "txtWebAddress"
        Me.txtWebAddress.Size = New System.Drawing.Size(227, 20)
        Me.txtWebAddress.TabIndex = 6
        '
        'chkDesktopShortcut
        '
        Me.chkDesktopShortcut.AutoSize = True
        Me.chkDesktopShortcut.Checked = True
        Me.chkDesktopShortcut.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDesktopShortcut.Location = New System.Drawing.Point(13, 127)
        Me.chkDesktopShortcut.Name = "chkDesktopShortcut"
        Me.chkDesktopShortcut.Size = New System.Drawing.Size(139, 17)
        Me.chkDesktopShortcut.TabIndex = 7
        Me.chkDesktopShortcut.Text = "Add shortcut to desktop"
        Me.chkDesktopShortcut.UseVisualStyleBackColor = True
        '
        'worker
        '
        Me.worker.WorkerReportsProgress = True
        '
        'pbProgress
        '
        Me.pbProgress.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pbProgress.Location = New System.Drawing.Point(0, 183)
        Me.pbProgress.Maximum = 98
        Me.pbProgress.Name = "pbProgress"
        Me.pbProgress.Size = New System.Drawing.Size(325, 21)
        Me.pbProgress.TabIndex = 8
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(7, 163)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(60, 13)
        Me.lblStatus.TabIndex = 9
        Me.lblStatus.Text = "Status: Idle"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(173, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(52, 34)
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(216, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 26)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Powered by Microsoft" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "WebView2"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(13, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 20)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "HybridApp"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(93, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 20)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Creator"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(220, 105)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(98, 13)
        Me.LinkLabel1.TabIndex = 14
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "License Agreement"
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(286, 31)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(31, 5)
        Me.Panel1.TabIndex = 15
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(325, 204)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.pbProgress)
        Me.Controls.Add(Me.chkDesktopShortcut)
        Me.Controls.Add(Me.txtWebAddress)
        Me.Controls.Add(Me.txtAppName)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnCreate)
        Me.Controls.Add(Me.chkStartShortcut)
        Me.Controls.Add(Me.lblWebAddress)
        Me.Controls.Add(Me.lblAppName)
        Me.Controls.Add(Me.Label6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HybridApp Creator"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblAppName As Label
    Friend WithEvents lblWebAddress As Label
    Friend WithEvents chkStartShortcut As CheckBox
    Friend WithEvents btnCreate As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents txtAppName As TextBox
    Friend WithEvents txtWebAddress As TextBox
    Friend WithEvents chkDesktopShortcut As CheckBox
    Friend WithEvents worker As System.ComponentModel.BackgroundWorker
    Friend WithEvents pbProgress As ProgressBar
    Friend WithEvents lblStatus As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Panel1 As Panel
End Class
