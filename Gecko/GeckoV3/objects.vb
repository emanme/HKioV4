Imports System.Threading


Module objects


    'Public serverstring As String = "server=localhost;" _
    '      & "user id=root;" _
    '      & "password=;" _
    '      & "database=oeffnungszeiten;"

    Public serverstring As String = "server=dbs.hs-furtwangen.de;" _
         & "user id=hfu_bib;" _
         & "password=5wVfSgIfcD;" _
         & "database=hfu_bib;"

    Public serverURL As String = "http://192.168.254.102/"
    Public theimageurl As String = "http://webuser.hs-furtwangen.de/~biblio/oeffnungszeiten/admin/"
    Public url As String = theimageurl & "furtwangen/images/"

    Public myHomeURL = "https://bsz.ibs-bw.de/aDISWeb/app?service=direct/0/Home/$DirectLink&sp=S127.0.0.1:23292"

    Public posterURL(9) As String
    Public posterURLNight(9) As String
    Public posterThread(9) As Thread

    Public ExitActive = False
    Public ExitCode = ""
    Public ExitCodeFromDB = "8hdiwj"
    Public ExitCodeTimer = 0

    Public OpenIEActive = False
    Public OpenIETimer = 0
    Public OpenIECode = "XC"
    Public OpenIECodePass = "FS"
    Public gh = 0

    Public posterURL1 As String
    Public posterURL2 As String
    Public posterURL3 As String
    Public posterURL4 As String
    Public posterURL5 As String
    Public posterURL6 As String
    Public posterURL7 As String
    Public posterURL8 As String
    Public posterURL9 As String
    Public posterURL10 As String

    Public posterURLNigth1 As String
    Public posterURLNigth12 As String
    Public posterURLNigth13 As String
    Public posterURLNigth4 As String
    Public posterURLNigth5 As String
    Public posterURLNigth6 As String
    Public posterURLNigth7 As String
    Public posterURLNigth8 As String
    Public posterURLNigth9 As String
    Public posterURLNigth10 As String

    Public buttonMouseDown = False
    Public buttonclicked = ""
    Public buttonStateSmall = False
    Public buttonIsCLick = False
    Public xa As Integer = 0
    Public ya As Integer = 0

    Public MaxTop = 0
    Public MaxTopSmall = 396
    Public MaxBottom = 1182
    Public keysizeadjust = 428 + 36

    Public MaxBottomsignaturen = 1316
    Public keysizeadjustsignaturen = 330
    'Public MaxTop = -32 keysizeadjustsignaturen = 461 - 66
    'Public MaxTopSmall = 396
    'Public MaxBottom = 1218 - 68
    'Public keysizeadjust = 428 + 68


    Public keyboardform = "HFUKioskSytem"

    Public opacHomeLink = "opac" 'ebook ejournal dbis
    Public opaclink = "https://bsz.ibs-bw.de/aDISWeb/app?service=direct/0/Home/$DirectLink&sp=S127.0.0.1:23292"
    Public ebooklink = "https://bsz.ibs-bw.de/aDISWeb/app?service=direct/0/Home/$DirectLink&sp=S127.0.0.1:23292"
    Public ejournalslink = "http://hs-furtwangen.de/~biblio/hfu_bib_app_v2/weiche2/"
    Public DBISlink = "http://rzblx10.uni-regensburg.de/dbinfo/fachliste.php"
    Public keyboardOnSignaturen As Boolean = False 'if true the green on keyboard is invisible
    Public resetOPAC = True
    Public resetOPACTimer = 0
    Public BrowserNavigated = False

    Public hasback = False
    Public hasnext = False

    Public closeButChange = False
    Public closeButChangetime = 1
    Public FocusJustChange = False
    Public Sub homebutton()
        If opacHomeLink = "opac" Then

            HFUKioskSytem.browser.Navigate(opaclink)

            HFUKioskSytem.pdfReader.Dock = DockStyle.None
            HFUKioskSytem.pdfReader.Visible = False
            HFUKioskSytem.pdfIsactive = False

        ElseIf opacHomeLink = "ebook" Then
            HFUKioskSytem.browser.Navigate(ebooklink)
            HFUKioskSytem.pdfReader.Dock = DockStyle.None
            HFUKioskSytem.pdfReader.Visible = False
            HFUKioskSytem.pdfIsactive = False

        ElseIf opacHomeLink = "ejournal" Then
            HFUKioskSytem.browser.Navigate(ejournalslink)
            HFUKioskSytem.pdfReader.Dock = DockStyle.None
            HFUKioskSytem.pdfReader.Visible = False
            HFUKioskSytem.pdfIsactive = False

        ElseIf opacHomeLink = "dbis" Then
            HFUKioskSytem.browser.Navigate(DBISlink)
            HFUKioskSytem.pdfReader.Dock = DockStyle.None
            HFUKioskSytem.pdfReader.Visible = False
            HFUKioskSytem.pdfIsactive = False

        End If
        ' opaclink = "ejournal" 'ebook ejournal dbis = "ejournal" 'ebook ejournal dbis
    End Sub
    Public Sub setActiveButton_all(ByVal buttonClick As String)
        If buttonClick = "Home" Then

            HFUKioskSytem.HomeButton.Image = My.Resources.HomeActive
            HFUKioskSytem.FachgebieteButton.Image = My.Resources.Fachgebiete
            HFUKioskSytem.SignaturenButton.Image = My.Resources.Signaturen
            HFUKioskSytem.DienstleistungenButton.Image = My.Resources.Dienstleistungen
            HFUKioskSytem.OPACButton.Image = My.Resources.OPAC

            Diens.HomeButton.Image = My.Resources.HomeActive
            Diens.FachgebieteButton.Image = My.Resources.Fachgebiete
            Diens.SignaturenButton.Image = My.Resources.Signaturen
            Diens.DienstleistungenButton.Image = My.Resources.Dienstleistungen
            Diens.OPACButton.Image = My.Resources.OPAC


            Fach.HomeButton.Image = My.Resources.HomeActive
            Fach.FachgebieteButton.Image = My.Resources.Fachgebiete
            Fach.SignaturenButton.Image = My.Resources.Signaturen
            Fach.DienstleistungenButton.Image = My.Resources.Dienstleistungen
            Fach.OPACButton.Image = My.Resources.OPAC

            Signaturen.HomeButton.Image = My.Resources.HomeActive
            Signaturen.FachgebieteButton.Image = My.Resources.Fachgebiete
            Signaturen.SignaturenButton.Image = My.Resources.Signaturen
            Signaturen.DienstleistungenButton.Image = My.Resources.Dienstleistungen
            Signaturen.OPACButton.Image = My.Resources.OPAC

        ElseIf buttonClick = "Fachgebiete" Then

            HFUKioskSytem.HomeButton.Image = My.Resources.Home
            HFUKioskSytem.FachgebieteButton.Image = My.Resources.FachgebieteActive
            HFUKioskSytem.SignaturenButton.Image = My.Resources.Signaturen
            HFUKioskSytem.DienstleistungenButton.Image = My.Resources.Dienstleistungen
            HFUKioskSytem.OPACButton.Image = My.Resources.OPAC




            Diens.HomeButton.Image = My.Resources.Home
            Diens.FachgebieteButton.Image = My.Resources.FachgebieteActive
            Diens.SignaturenButton.Image = My.Resources.Signaturen
            Diens.DienstleistungenButton.Image = My.Resources.Dienstleistungen
            Diens.OPACButton.Image = My.Resources.OPAC


            Fach.HomeButton.Image = My.Resources.Home
            Fach.FachgebieteButton.Image = My.Resources.FachgebieteActive
            Fach.SignaturenButton.Image = My.Resources.Signaturen
            Fach.DienstleistungenButton.Image = My.Resources.Dienstleistungen
            Fach.OPACButton.Image = My.Resources.OPAC


            Signaturen.HomeButton.Image = My.Resources.Home
            Signaturen.FachgebieteButton.Image = My.Resources.FachgebieteActive
            Signaturen.SignaturenButton.Image = My.Resources.Signaturen
            Signaturen.DienstleistungenButton.Image = My.Resources.Dienstleistungen
            Signaturen.OPACButton.Image = My.Resources.OPAC
        ElseIf buttonClick = "Signaturen" Then

            HFUKioskSytem.HomeButton.Image = My.Resources.Home
            HFUKioskSytem.FachgebieteButton.Image = My.Resources.Fachgebiete
            HFUKioskSytem.SignaturenButton.Image = My.Resources.SignaturenActive
            HFUKioskSytem.DienstleistungenButton.Image = My.Resources.Dienstleistungen
            HFUKioskSytem.OPACButton.Image = My.Resources.OPAC

            Diens.HomeButton.Image = My.Resources.Home
            Diens.FachgebieteButton.Image = My.Resources.Fachgebiete
            Diens.SignaturenButton.Image = My.Resources.SignaturenActive
            Diens.DienstleistungenButton.Image = My.Resources.Dienstleistungen
            Diens.OPACButton.Image = My.Resources.OPAC


            Fach.HomeButton.Image = My.Resources.Home
            Fach.FachgebieteButton.Image = My.Resources.Fachgebiete
            Fach.SignaturenButton.Image = My.Resources.SignaturenActive
            Fach.DienstleistungenButton.Image = My.Resources.Dienstleistungen
            Fach.OPACButton.Image = My.Resources.OPAC

            Signaturen.HomeButton.Image = My.Resources.Home
            Signaturen.FachgebieteButton.Image = My.Resources.Fachgebiete
            Signaturen.SignaturenButton.Image = My.Resources.SignaturenActive
            Signaturen.DienstleistungenButton.Image = My.Resources.Dienstleistungen
            Signaturen.OPACButton.Image = My.Resources.OPAC


        ElseIf buttonClick = "Dienstleistungen" Then

            HFUKioskSytem.HomeButton.Image = My.Resources.Home
            HFUKioskSytem.FachgebieteButton.Image = My.Resources.Fachgebiete
            HFUKioskSytem.SignaturenButton.Image = My.Resources.Signaturen
            HFUKioskSytem.DienstleistungenButton.Image = My.Resources.DienstleistungenActive
            HFUKioskSytem.OPACButton.Image = My.Resources.OPAC

            Diens.HomeButton.Image = My.Resources.Home
            Diens.FachgebieteButton.Image = My.Resources.Fachgebiete
            Diens.SignaturenButton.Image = My.Resources.Signaturen
            Diens.DienstleistungenButton.Image = My.Resources.DienstleistungenActive
            Diens.OPACButton.Image = My.Resources.OPAC


            Fach.HomeButton.Image = My.Resources.Home
            Fach.FachgebieteButton.Image = My.Resources.Fachgebiete
            Fach.SignaturenButton.Image = My.Resources.Signaturen
            Fach.DienstleistungenButton.Image = My.Resources.DienstleistungenActive
            Fach.OPACButton.Image = My.Resources.OPAC

            Signaturen.HomeButton.Image = My.Resources.Home
            Signaturen.FachgebieteButton.Image = My.Resources.Fachgebiete
            Signaturen.SignaturenButton.Image = My.Resources.Signaturen
            Signaturen.DienstleistungenButton.Image = My.Resources.DienstleistungenActive
            Signaturen.OPACButton.Image = My.Resources.OPAC

        ElseIf buttonClick = "OPAC" Then
            HFUKioskSytem.HomeButton.Image = My.Resources.Home
            HFUKioskSytem.FachgebieteButton.Image = My.Resources.Fachgebiete
            HFUKioskSytem.SignaturenButton.Image = My.Resources.Signaturen
            HFUKioskSytem.DienstleistungenButton.Image = My.Resources.Dienstleistungen
            HFUKioskSytem.OPACButton.Image = My.Resources.OPACActive

            Diens.HomeButton.Image = My.Resources.Home
            Diens.FachgebieteButton.Image = My.Resources.Fachgebiete
            Diens.SignaturenButton.Image = My.Resources.Signaturen
            Diens.DienstleistungenButton.Image = My.Resources.Dienstleistungen
            Diens.OPACButton.Image = My.Resources.OPACActive


            Fach.HomeButton.Image = My.Resources.Home
            Fach.FachgebieteButton.Image = My.Resources.Fachgebiete
            Fach.SignaturenButton.Image = My.Resources.Signaturen
            Fach.DienstleistungenButton.Image = My.Resources.Dienstleistungen
            Fach.OPACButton.Image = My.Resources.OPACActive

            Signaturen.HomeButton.Image = My.Resources.Home
            Signaturen.FachgebieteButton.Image = My.Resources.Fachgebiete
            Signaturen.SignaturenButton.Image = My.Resources.Signaturen
            Signaturen.DienstleistungenButton.Image = My.Resources.Dienstleistungen
            Signaturen.OPACButton.Image = My.Resources.OPACActive

        End If

    End Sub

    Public Sub setActiveForm(ByVal buttonClick As String)
        If buttonClick = "Home" Then
            If ExitActive Then
                ExitCode = ExitCode & "H"
            ElseIf OpenIEActive Then

                OpenIECode = OpenIECode & "H"

            End If
            Signaturen.searchbox.Visible = False
            buttonclicked = "Home"
            HFUKioskSytem.animationContainer.Hide()
            HFUKioskSytem.animationLabelPanel.Visible = False
            HFUKioskSytem.posterImage.Show()
            HFUKioskSytem.browser.Hide()

            HFUKioskSytem.imageSetNum = 1
            HFUKioskSytem.timer2count = 1
            HFUKioskSytem.timerForImage.Start()
            HFUKioskSytem.timerForResumeSlide.Stop()
            'HFUKioskSytem.TopMost = True
            'Fach.TopMost = False
            'Diens.TopMost = False
            'Signaturen.TopMost = False

            Fach.BringToFront()
            Diens.BringToFront()
            Signaturen.BringToFront()
            '   keyboard.BringToFront()
            HFUKioskSytem.BringToFront()
            keyboard.Hide()
            HFUKioskSytem.loadingImage.Visible = False
            HFUKioskSytem.browser.Stop()

            HFUKioskSytem.pdfReader.Dock = DockStyle.None
            HFUKioskSytem.pdfReader.Visible = False

            '    InputBox("", "", HFUKioskSytem.browser.Url.ToString)
        ElseIf buttonClick = "Fachgebiete" Then
            If ExitActive Then
                ExitCode = ExitCode & "F"
            ElseIf OpenIEActive Then

                OpenIECode = OpenIECode & "F"
            End If
            Signaturen.searchbox.Visible = False
            HFUKioskSytem.BringToFront()
            buttonclicked = "Fachgebiete"
            Diens.BringToFront()
            Signaturen.BringToFront()
            ' keyboard.BringToFront()
            Fach.BringToFront()
            'HFUKioskSytem.TopMost = False
            'Fach.TopMost = True
            'Diens.TopMost = False
            'Signaturen.TopMost = False
            keyboard.Hide()
            HFUKioskSytem.loadingImage.Visible = False
            HFUKioskSytem.browser.Stop()
            HFUKioskSytem.pdfReader.Dock = DockStyle.None
            HFUKioskSytem.pdfReader.Visible = False

            '    MsgBox(HFUKioskSytem.browser.Url.ToString)
        ElseIf buttonClick = "Signaturen" Then
            If ExitActive Then
                ExitCode = ExitCode & "S"

            ElseIf OpenIEActive Then
                OpenIECode = OpenIECode & "S"
            End If
            buttonclicked = "Signaturen"
            Signaturen.searchbox.Visible = True

            keyboardOnSignaturen = True
            HFUKioskSytem.BringToFront()
            Fach.BringToFront()
            Diens.BringToFront()

            '  keyboard.BringToFront()
            Signaturen.BringToFront()

            'keyboard.Show()  
            'Signaturen.TopMost = True
            'HFUKioskSytem.TopMost = False
            'Fach.TopMost = False
            'Diens.TopMost = False


            ''keyboard.BringToFront()
            ''Signaturen.SendToBack()
            keyboard.Show()
            keyboard.TopMost = True

            keyboard.Location = New Point(keyboard.Location.X, 1316)
            '# errorMsg.BringToFront()
            '#  errorMsg.TopMost = True
            'keyboard.Focus()
            HFUKioskSytem.loadingImage.Visible = False
            HFUKioskSytem.browser.Stop()

            HFUKioskSytem.pdfReader.Dock = DockStyle.None
            HFUKioskSytem.pdfReader.Visible = False

            '    InputBox("", "", HFUKioskSytem.browser.Url.ToString)
            keyboardform = "Signaturen"
        ElseIf buttonClick = "Dienstleistungen" Then
            If ExitActive Then
                ExitCode = ExitCode & "D"
            ElseIf OpenIEActive Then

                OpenIECode = OpenIECode & "D"
            End If
            Signaturen.searchbox.Visible = False
            buttonclicked = "Dienstleistungen"
            HFUKioskSytem.BringToFront()
            Fach.BringToFront()

            Signaturen.BringToFront()
            '   keyboard.BringToFront()
            Diens.BringToFront()
            'HFUKioskSytem.TopMost = False 
            'Fach.TopMost = False
            'Diens.TopMost = True
            'Signaturen.TopMost = False
            keyboard.Hide()
            HFUKioskSytem.loadingImage.Visible = False
            HFUKioskSytem.browser.Stop()
            HFUKioskSytem.pdfReader.Dock = DockStyle.None
            HFUKioskSytem.pdfReader.Visible = False

            '   InputBox("", "", HFUKioskSytem.browser.Url.ToString)
        ElseIf buttonClick = "OPAC" Then

            If ExitActive Then
                ExitCode = ExitCode & "O"
            ElseIf OpenIEActive Then

                OpenIECode = OpenIECode & "O"
            End If
            Signaturen.searchbox.Visible = False
            keyboardOnSignaturen = False
            buttonclicked = "OPAC"
            HFUKioskSytem.animationContainer.Hide()
            HFUKioskSytem.posterImage.Hide()
            HFUKioskSytem.animationLabelPanel.Visible = False
            HFUKioskSytem.browser.Show()
            HFUKioskSytem.browser.Dock = DockStyle.Fill



            HFUKioskSytem.imageSetNum = 1
            HFUKioskSytem.timer2count = 1
            HFUKioskSytem.timerForImage.Stop()
            HFUKioskSytem.browserSetToMobile = False
            HFUKioskSytem.count = 0
            HFUKioskSytem.clicked()

            keyboard.keyboard_Error.Visible = False
            keyboard.keyboard_ErrorLabel.Visible = False

            Fach.BringToFront()
            Diens.BringToFront()
            Signaturen.BringToFront()
            '  keyboard.BringToFront()
            HFUKioskSytem.BringToFront()
            'HFUKioskSytem.TopMost = True
            'Fach.TopMost = False
            'Diens.TopMost = False
            'Signaturen.TopMost = False


            'HFUKioskSytem.TopMost = False
            keyboard.Show()
            keyboard.TopMost = True
            keyboard.Location = New Point(keyboard.Location.X, MaxBottom)
            keyboardform = "HFUKioskSytem"

            If HFUKioskSytem.pdfIsactive = True Then
                HFUKioskSytem.pdfReader.Dock = DockStyle.Fill
                HFUKioskSytem.pdfReader.Visible = True

            Else
                HFUKioskSytem.pdfReader.Dock = DockStyle.None
                HFUKioskSytem.pdfReader.Visible = False

            End If

        ElseIf buttonClick = "DBIS" Then


            keyboardOnSignaturen = False
            buttonclicked = "Dienstleistungen"
            HFUKioskSytem.animationContainer.Hide()
            HFUKioskSytem.posterImage.Hide()
            HFUKioskSytem.animationLabelPanel.Visible = False
            HFUKioskSytem.browser.Show()
            HFUKioskSytem.browser.Dock = DockStyle.Fill



            HFUKioskSytem.imageSetNum = 1
            HFUKioskSytem.timer2count = 1
            HFUKioskSytem.timerForImage.Stop()
            HFUKioskSytem.browserSetToMobile = False
            HFUKioskSytem.count = 0
            HFUKioskSytem.clicked()

            keyboard.keyboard_Error.Visible = False
            keyboard.keyboard_ErrorLabel.Visible = False

            Fach.BringToFront()
            Diens.BringToFront()
            Signaturen.BringToFront()
            '  keyboard.BringToFront()
            HFUKioskSytem.BringToFront()
            'HFUKioskSytem.TopMost = True
            'Fach.TopMost = False
            'Diens.TopMost = False
            'Signaturen.TopMost = False


            'HFUKioskSytem.TopMost = False
            keyboard.Show()
            keyboard.TopMost = True
            keyboard.Location = New Point(keyboard.Location.X, MaxBottom)
            keyboardform = "HFUKioskSytem"

            If HFUKioskSytem.pdfIsactive = True Then
                HFUKioskSytem.pdfReader.Dock = DockStyle.Fill
                HFUKioskSytem.pdfReader.Visible = True

            Else
                HFUKioskSytem.pdfReader.Dock = DockStyle.None
                HFUKioskSytem.pdfReader.Visible = False

            End If

        ElseIf buttonClick = "animation" Then
            Fach.BringToFront()

            Signaturen.BringToFront()
            '   keyboard.BringToFront()
            Diens.BringToFront()
            HFUKioskSytem.BringToFront()
            HFUKioskSytem.loadingImage.Visible = False
            keyboard.Hide()
            HFUKioskSytem.pdfReader.Dock = DockStyle.None
            HFUKioskSytem.pdfReader.Visible = False
            Signaturen.errorMsgPic.Visible = False
        End If


    End Sub

End Module
