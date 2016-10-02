<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HFUKioskSytem
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HFUKioskSytem))
        Me.browser = New Gecko.GeckoWebBrowser()
        Me.loadingImage = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.posterCloseButton = New System.Windows.Forms.PictureBox()
        Me.OPACButton = New System.Windows.Forms.PictureBox()
        Me.DienstleistungenButton = New System.Windows.Forms.PictureBox()
        Me.FachgebieteButton = New System.Windows.Forms.PictureBox()
        Me.HomeButton = New System.Windows.Forms.PictureBox()
        Me.SignaturenButton = New System.Windows.Forms.PictureBox()
        Me.animationContainer = New System.Windows.Forms.PictureBox()
        Me.posterImage = New System.Windows.Forms.PictureBox()
        Me.animationLabelPanel = New System.Windows.Forms.Panel()
        Me.signatureLabel = New System.Windows.Forms.Label()
        Me.animationLabel = New System.Windows.Forms.Label()
        Me.animationLabelDes = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.timerForImage = New System.Windows.Forms.Timer(Me.components)
        Me.timerForResumeSlide = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.pdfReader = New AxAcroPDFLib.AxAcroPDF()
        CType(Me.loadingImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.posterCloseButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OPACButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DienstleistungenButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FachgebieteButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HomeButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SignaturenButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.animationContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.posterImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.animationLabelPanel.SuspendLayout()
        CType(Me.pdfReader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'browser
        '
        Me.browser.Location = New System.Drawing.Point(855, 24)
        Me.browser.Name = "browser"
        Me.browser.Size = New System.Drawing.Size(272, 300)
        Me.browser.TabIndex = 0
        Me.browser.UseHttpActivityObserver = False
        '
        'loadingImage
        '
        Me.loadingImage.Image = Global.GeckoV3.My.Resources.Resources.ajax_loader
        Me.loadingImage.Location = New System.Drawing.Point(969, 347)
        Me.loadingImage.Name = "loadingImage"
        Me.loadingImage.Size = New System.Drawing.Size(24, 24)
        Me.loadingImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.loadingImage.TabIndex = 1
        Me.loadingImage.TabStop = False
        Me.loadingImage.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Panel2.Controls.Add(Me.posterCloseButton)
        Me.Panel2.Controls.Add(Me.OPACButton)
        Me.Panel2.Controls.Add(Me.DienstleistungenButton)
        Me.Panel2.Controls.Add(Me.FachgebieteButton)
        Me.Panel2.Controls.Add(Me.HomeButton)
        Me.Panel2.Controls.Add(Me.SignaturenButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 843)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1596, 210)
        Me.Panel2.TabIndex = 71
        '
        'posterCloseButton
        '
        Me.posterCloseButton.Image = Global.GeckoV3.My.Resources.Resources.Posterbar_closed
        Me.posterCloseButton.Location = New System.Drawing.Point(1314, 62)
        Me.posterCloseButton.Name = "posterCloseButton"
        Me.posterCloseButton.Size = New System.Drawing.Size(100, 50)
        Me.posterCloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.posterCloseButton.TabIndex = 5
        Me.posterCloseButton.TabStop = False
        '
        'OPACButton
        '
        Me.OPACButton.Image = Global.GeckoV3.My.Resources.Resources.OPAC
        Me.OPACButton.Location = New System.Drawing.Point(865, 3)
        Me.OPACButton.Name = "OPACButton"
        Me.OPACButton.Size = New System.Drawing.Size(200, 200)
        Me.OPACButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.OPACButton.TabIndex = 4
        Me.OPACButton.TabStop = False
        '
        'DienstleistungenButton
        '
        Me.DienstleistungenButton.Image = Global.GeckoV3.My.Resources.Resources.Dienstleistungen
        Me.DienstleistungenButton.Location = New System.Drawing.Point(649, 3)
        Me.DienstleistungenButton.Name = "DienstleistungenButton"
        Me.DienstleistungenButton.Size = New System.Drawing.Size(200, 200)
        Me.DienstleistungenButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.DienstleistungenButton.TabIndex = 3
        Me.DienstleistungenButton.TabStop = False
        '
        'FachgebieteButton
        '
        Me.FachgebieteButton.Image = Global.GeckoV3.My.Resources.Resources.Fachgebiete
        Me.FachgebieteButton.Location = New System.Drawing.Point(217, 3)
        Me.FachgebieteButton.Name = "FachgebieteButton"
        Me.FachgebieteButton.Size = New System.Drawing.Size(200, 200)
        Me.FachgebieteButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.FachgebieteButton.TabIndex = 2
        Me.FachgebieteButton.TabStop = False
        '
        'HomeButton
        '
        Me.HomeButton.Image = Global.GeckoV3.My.Resources.Resources.Home
        Me.HomeButton.Location = New System.Drawing.Point(1, 3)
        Me.HomeButton.Name = "HomeButton"
        Me.HomeButton.Size = New System.Drawing.Size(200, 200)
        Me.HomeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.HomeButton.TabIndex = 2
        Me.HomeButton.TabStop = False
        '
        'SignaturenButton
        '
        Me.SignaturenButton.Image = Global.GeckoV3.My.Resources.Resources.Signaturen
        Me.SignaturenButton.Location = New System.Drawing.Point(433, 3)
        Me.SignaturenButton.Name = "SignaturenButton"
        Me.SignaturenButton.Size = New System.Drawing.Size(200, 200)
        Me.SignaturenButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.SignaturenButton.TabIndex = 2
        Me.SignaturenButton.TabStop = False
        '
        'animationContainer
        '
        Me.animationContainer.Location = New System.Drawing.Point(800, 409)
        Me.animationContainer.Name = "animationContainer"
        Me.animationContainer.Size = New System.Drawing.Size(163, 264)
        Me.animationContainer.TabIndex = 72
        Me.animationContainer.TabStop = False
        '
        'posterImage
        '
        Me.posterImage.Image = Global.GeckoV3.My.Resources.Resources.defaultposter
        Me.posterImage.Location = New System.Drawing.Point(1007, 409)
        Me.posterImage.Name = "posterImage"
        Me.posterImage.Size = New System.Drawing.Size(177, 264)
        Me.posterImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.posterImage.TabIndex = 73
        Me.posterImage.TabStop = False
        '
        'animationLabelPanel
        '
        Me.animationLabelPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.animationLabelPanel.Controls.Add(Me.signatureLabel)
        Me.animationLabelPanel.Controls.Add(Me.animationLabel)
        Me.animationLabelPanel.Controls.Add(Me.animationLabelDes)
        Me.animationLabelPanel.Location = New System.Drawing.Point(998, 787)
        Me.animationLabelPanel.Name = "animationLabelPanel"
        Me.animationLabelPanel.Size = New System.Drawing.Size(634, 126)
        Me.animationLabelPanel.TabIndex = 74
        '
        'signatureLabel
        '
        Me.signatureLabel.AutoSize = True
        Me.signatureLabel.Location = New System.Drawing.Point(6, 33)
        Me.signatureLabel.Name = "signatureLabel"
        Me.signatureLabel.Size = New System.Drawing.Size(76, 13)
        Me.signatureLabel.TabIndex = 83
        Me.signatureLabel.Text = "signatureLabel"
        '
        'animationLabel
        '
        Me.animationLabel.AutoSize = True
        Me.animationLabel.BackColor = System.Drawing.Color.Transparent
        Me.animationLabel.Location = New System.Drawing.Point(6, 10)
        Me.animationLabel.Name = "animationLabel"
        Me.animationLabel.Size = New System.Drawing.Size(78, 13)
        Me.animationLabel.TabIndex = 81
        Me.animationLabel.Text = "animationLabel"
        '
        'animationLabelDes
        '
        Me.animationLabelDes.AutoSize = True
        Me.animationLabelDes.BackColor = System.Drawing.Color.Transparent
        Me.animationLabelDes.Location = New System.Drawing.Point(6, 63)
        Me.animationLabelDes.Name = "animationLabelDes"
        Me.animationLabelDes.Size = New System.Drawing.Size(97, 13)
        Me.animationLabelDes.TabIndex = 82
        Me.animationLabelDes.Text = "animationLabelDes"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'timerForImage
        '
        Me.timerForImage.Interval = 500
        '
        'timerForResumeSlide
        '
        Me.timerForResumeSlide.Interval = 1000
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'Timer3
        '
        Me.Timer3.Interval = 10
        '
        'pdfReader
        '
        Me.pdfReader.Enabled = True
        Me.pdfReader.Location = New System.Drawing.Point(1152, 964)
        Me.pdfReader.Name = "pdfReader"
        Me.pdfReader.OcxState = CType(resources.GetObject("pdfReader.OcxState"), System.Windows.Forms.AxHost.State)
        Me.pdfReader.Size = New System.Drawing.Size(192, 192)
        Me.pdfReader.TabIndex = 75
        '
        'HFUKioskSytem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1596, 1053)
        Me.Controls.Add(Me.pdfReader)
        Me.Controls.Add(Me.animationLabelPanel)
        Me.Controls.Add(Me.posterImage)
        Me.Controls.Add(Me.animationContainer)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.loadingImage)
        Me.Controls.Add(Me.browser)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "HFUKioskSytem"
        Me.Text = "HFUKioskSytem"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.loadingImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.posterCloseButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OPACButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DienstleistungenButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FachgebieteButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HomeButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SignaturenButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.animationContainer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.posterImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.animationLabelPanel.ResumeLayout(False)
        Me.animationLabelPanel.PerformLayout()
        CType(Me.pdfReader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents browser As Gecko.GeckoWebBrowser
    Friend WithEvents loadingImage As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents OPACButton As System.Windows.Forms.PictureBox
    Friend WithEvents DienstleistungenButton As System.Windows.Forms.PictureBox
    Friend WithEvents FachgebieteButton As System.Windows.Forms.PictureBox
    Friend WithEvents HomeButton As System.Windows.Forms.PictureBox
    Friend WithEvents SignaturenButton As System.Windows.Forms.PictureBox
    Friend WithEvents animationContainer As System.Windows.Forms.PictureBox
    Friend WithEvents posterImage As System.Windows.Forms.PictureBox
    Friend WithEvents animationLabelPanel As System.Windows.Forms.Panel
    Friend WithEvents signatureLabel As System.Windows.Forms.Label
    Friend WithEvents animationLabel As System.Windows.Forms.Label
    Friend WithEvents animationLabelDes As System.Windows.Forms.Label
    Friend WithEvents posterCloseButton As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents timerForImage As System.Windows.Forms.Timer
    Friend WithEvents timerForResumeSlide As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Timer3 As System.Windows.Forms.Timer
    Friend WithEvents pdfReader As AxAcroPDFLib.AxAcroPDF

End Class
