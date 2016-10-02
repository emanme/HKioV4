Imports System.Drawing.Text
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Imports System.Threading.Tasks
Imports System.IO

Imports MySql.Data.MySqlClient
Imports System.Net
Imports System.Threading
Public Class HFUKioskSytem
    Dim NewPoint As New System.Drawing.Point
    Dim broswerDone = False
    Dim formsize As Integer
    Dim equalz As Double
    Dim ButtonClick As String = "Home"

    Dim batch As String = 1

    Dim batchNight As String = 1

    Dim batchOne = False
    Dim batchTwo = False

    Dim batchOneNight = False
    Dim batchTwoNight = False

    Dim batchOneCounts = 0
    Dim batchTwoCounts = 0
    Dim batchCounts = 0

    Dim batchOneCountsNight = 0
    Dim batchTwoCountsNight = 0
    Dim batchCountsNight = 0

    Dim conn As MySqlConnection
    Dim connGet As MySqlConnection
    Dim connNigth As MySqlConnection
    Dim noOfRows As Integer
    Dim noOfRowsNight As Integer
    Dim a As Integer = 2 'timer counter
    Dim downloading = True
    Dim doneLoadingPoster As Boolean = False

    Dim downloadingNight = True
    Dim doneLoadingPosterNight As Boolean = False

    Dim postersDay1(11) As String
    Dim postersDay2(11) As String
    Dim postersDay(11) As String

    Dim resumSlide As Integer = 1
    Dim tillSlide As Integer = 1
    Public imageSetNum As Integer = 1

    Public timer2count As Integer = 1

    Dim posterBOOL1 As Boolean = False
    Dim posterBOOL2 As Boolean = False
    Dim posterBOOL3 As Boolean = False
    Dim posterBOOL4 As Boolean = False
    Dim posterBOOL5 As Boolean = False
    Dim posterBOOL6 As Boolean = False
    Dim posterBOOL7 As Boolean = False
    Dim posterBOOL8 As Boolean = False
    Dim posterBOOL9 As Boolean = False
    Dim posterBOOL10 As Boolean = False

    Dim posterNightBOOL1 As Boolean = False
    Dim posterNightBOOL2 As Boolean = False
    Dim posterNightBOOL3 As Boolean = False
    Dim posterNightBOOL4 As Boolean = False
    Dim posterNightBOOL5 As Boolean = False
    Dim posterNightBOOL6 As Boolean = False
    Dim posterNightBOOL7 As Boolean = False
    Dim posterNightBOOL8 As Boolean = False
    Dim posterNightBOOL9 As Boolean = False
    Dim posterNightBOOL10 As Boolean = False

    Dim posterActivited1 As Boolean = False
    Dim posterActivited2 As Boolean = False
    Dim posterActivited3 As Boolean = False
    Dim posterActivited4 As Boolean = False
    Dim posterActivited5 As Boolean = False
    Dim posterActivited6 As Boolean = False
    Dim posterActivited7 As Boolean = False
    Dim posterActivited8 As Boolean = False
    Dim posterActivited9 As Boolean = False
    Dim posterActivited10 As Boolean = False

    Dim Poster1(11) As Bitmap
    Dim Poster2(11) As Bitmap

    Dim PosterDB1 As Bitmap
    Dim PosterDB2 As Bitmap
    Dim PosterDB3 As Bitmap
    Dim PosterDB4 As Bitmap
    Dim PosterDB5 As Bitmap
    Dim PosterDB6 As Bitmap
    Dim PosterDB7 As Bitmap
    Dim PosterDB8 As Bitmap
    Dim PosterDB9 As Bitmap
    Dim PosterDB10 As Bitmap

    Dim PosterD1 As Bitmap
    Dim PosterD2 As Bitmap
    Dim PosterD3 As Bitmap
    Dim PosterD4 As Bitmap
    Dim PosterD5 As Bitmap
    Dim PosterD6 As Bitmap
    Dim PosterD7 As Bitmap
    Dim PosterD8 As Bitmap
    Dim PosterD9 As Bitmap
    Dim PosterD10 As Bitmap

    Dim PosterNB1 As Bitmap
    Dim PosterNB2 As Bitmap
    Dim PosterNB3 As Bitmap
    Dim PosterNB4 As Bitmap
    Dim PosterNB5 As Bitmap
    Dim PosterNB6 As Bitmap
    Dim PosterNB7 As Bitmap
    Dim PosterNB8 As Bitmap
    Dim PosterNB9 As Bitmap
    Dim PosterNB10 As Bitmap

    Dim PosterN1 As Bitmap
    Dim PosterN2 As Bitmap
    Dim PosterN3 As Bitmap
    Dim PosterN4 As Bitmap
    Dim PosterN5 As Bitmap
    Dim PosterN6 As Bitmap
    Dim PosterN7 As Bitmap
    Dim PosterN8 As Bitmap
    Dim PosterN9 As Bitmap
    Dim PosterN10 As Bitmap

    Dim PosterNight1(11) As Bitmap
    Dim PosterNight2(11) As Bitmap
    Dim keyboardText As String

    Dim dayOrNight As String = "night"
    Dim dayOrNightJustChange As Boolean = False

    Public mymin As Integer = 0
    Public myhour As Integer = 0
    Public mysec As Integer = 0
    Public mydate As String
    Public myyear As String
    Public mymonth As String
    Public myday As String

    Public firstquery As Boolean = False
    Public secondquery As Boolean = False
    Public thirdquery As Boolean = False
    Public fromDefault As Boolean = True

    Public NOpen As TimeSpan
    Public NClose As TimeSpan
    Public Nopen2 As TimeSpan
    Public NClose2 As TimeSpan
    Public time As TimeSpan
    Public datenow As Date
    Public hours24 As TimeSpan = New TimeSpan(1, 0, 0, 0, 0)
    Private Shared WhiteList As New List(Of String)()

    Dim HomebuttonStateSmall = False
    Dim FachgebietebuttonStateSmall = False
    Dim SignaturenbuttonStateSmall = False
    Dim DienstleistungenbuttonStateSmall = False
    Dim OPACbuttonStateSmall = False

    Dim HomebuttonXa = 0
    Dim FachgebieteXa = 0
    Dim SignaturenXa = 0
    Dim DienstleistungenXa = 0
    Dim OPACbuttonXa = 0

    Public pdfIsactive = False
    Dim lasturl As String = ""

    Dim Homebuttonclick = False
    Dim Fachgebieteclick = False
    Dim Signaturenclick = False
    Dim Dienstleistungenclick = False
    Dim OPACbuttonclick = False

    Public dbsingle As String = "1"
    Public closeallday As String = "1"
    Public close2 = True
    '  Dim filestream As New FileStream(Application.StartupPath & "\fs.txt", FileMode.Open)
    Dim icf As PrivateFontCollection = New PrivateFontCollection
    Dim pfc As PrivateFontCollection = New PrivateFontCollection

    Private buttonClicked As String = "Home"
    Dim curDir As String = Directory.GetCurrentDirectory()



    Public browserSetToMobile = False
    Public count = 0
    'Public Sub New()
    '    InitializeComponent()
    '    Dim t As New Task(Sub() loadWhiteList())
    '    t.Start() ' do not forget to start the task
    'End Sub
    ' Load the WhiteList only unique and converted to lower case


    Private Sub Form1_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles Me.GotFocus
        clicked()
    End Sub
    Private Sub getExitCode()


        Dim connGetExit = New MySqlConnection()
        Dim myAdapterGet As New MySqlDataAdapter


        connGetExit.ConnectionString = serverstring
        Try
            connGetExit.Open()
            Dim sqlqueryGet = " SELECT *  FROM  `furtwangen_meta` where meta='KioskExitCode' "
            Dim dtGet As New DataTable
            Dim myCommandGet As New MySqlCommand()
            Dim get_RowsGet As New MySqlDataAdapter
            myCommandGet.Connection = connGetExit
            myCommandGet.CommandText = sqlqueryGet
            get_RowsGet.SelectCommand = myCommandGet
            Dim myDataGet As MySqlDataReader
            'TextBox3.Text =  'TextBox3.Text & "177 sqlqueryGet " & Environment.NewLine
            myDataGet = myCommandGet.ExecuteReader()
            If myDataGet.HasRows = 0 Then

                'TextBox3.Text =  'TextBox3.Text & " no rows" & Environment.NewLine
                connGetExit.Close()
            Else

                connGetExit.Close()

                get_RowsGet.Fill(dtGet)

                ExitCodeFromDB = dtGet.Rows(0).Item("value")

            End If
            myCommandGet.Dispose()
            get_RowsGet.Dispose()

        Catch ex As Exception
            '     MsgBox("getExitCode" & ex.ToString)
        End Try
    End Sub


    Private Sub getDayAndNight()
        connGet = New MySqlConnection()
        Dim myAdapterGet As New MySqlDataAdapter


        connGet.ConnectionString = serverstring
        Try
            connGet.Open()
            Dim sqlqueryGet = "SELECT  DATE_FORMAT(NOW(),'%Y-%m-%d') as date, DATE_FORMAT(NOW(),'%Y') as year, DATE_FORMAT(NOW(),'%m') as month, DATE_FORMAT(NOW(),'%d') as day," _
                              & " DATE_FORMAT(NOW(),'%H:%i:%s') as time, DATE_FORMAT(NOW(),'%i') as min ,DATE_FORMAT(NOW(),'%H') as hour ,DATE_FORMAT(NOW(),'%s') as seconds"
            Dim dtGet As New DataTable
            Dim dtGet2 As New DataTable
            Dim dtGet3 As New DataTable
            Dim myCommandGet As New MySqlCommand()
            Dim get_RowsGet As New MySqlDataAdapter
            myCommandGet.Connection = connGet
            myCommandGet.CommandText = sqlqueryGet
            get_RowsGet.SelectCommand = myCommandGet
            Dim myDataGet As MySqlDataReader
            'TextBox3.Text =  'TextBox3.Text & "177 sqlqueryGet " & Environment.NewLine
            myDataGet = myCommandGet.ExecuteReader()
            If myDataGet.HasRows = 0 Then

                'TextBox3.Text =  'TextBox3.Text & " no rows" & Environment.NewLine
                connGet.Close()
            Else

                connGet.Close()

                get_RowsGet.Fill(dtGet)


                mydate = dtGet.Rows(0).Item("date")
                mymin = dtGet.Rows(0).Item("min")
                myhour = dtGet.Rows(0).Item("hour")
                mysec = dtGet.Rows(0).Item("seconds")

                myyear = dtGet.Rows(0).Item("year")
                mymonth = dtGet.Rows(0).Item("month")
                myday = dtGet.Rows(0).Item("day")
                '  time = dtGet.Rows(0).Item("time")

                '  Dim time1() As TimeSpan = {TimeSpan.FromHours(myhour), TimeSpan.FromMinutes(mymin), TimeSpan.FromSeconds(mysec)}
                time = New TimeSpan(0, myhour, mymin, mysec, 0) 'DateTime constructor: parameters year, month, day, hour, min, sec
                datenow = New Date(myyear, mymonth, myday, 0, 0, 0)

                'TextBox3.Text =  'TextBox3.Text & "193  mydate " & mydate & Environment.NewLine
                'TextBox3.Text =  'TextBox3.Text & "  myhour " & myhour & Environment.NewLine
                'TextBox3.Text =  'TextBox3.Text & "  mymin " & mymin & Environment.NewLine
                'TextBox3.Text =  'TextBox3.Text & "  mysec " & mysec & Environment.NewLine
                'TextBox3.Text =  'TextBox3.Text & "196  time " & time.ToString("c") & Environment.NewLine

                dtGet.Dispose()

            End If
            connGet.Close()
            connGet.Open()
            sqlqueryGet = "SELECT open, close, open2, close2, closeallday, single  FROM `furtwangen_day` where datestart=DATE(NOW()) and enable='yes'"

            myCommandGet.Connection = connGet
            myCommandGet.CommandText = sqlqueryGet
            get_RowsGet.SelectCommand = myCommandGet

            '    'TextBox3.Text =  'TextBox3.Text & "209  sqlqueryGet " & sqlqueryGet & Environment.NewLine
            myDataGet = myCommandGet.ExecuteReader()
            If myDataGet.HasRows = 0 Then
                secondquery = False
                'TextBox3.Text =  'TextBox3.Text & "213 no rows" & Environment.NewLine
                connGet.Close()
            Else

                connGet.Close()
                secondquery = True
                fromDefault = False
                get_RowsGet.Fill(dtGet2)
                dbsingle = dtGet2.Rows(0).Item("single")
                closeallday = dtGet2.Rows(0).Item("closeallday")


                NOpen = dtGet2.Rows(0).Item("open")
                Nopen2 = dtGet2.Rows(0).Item("open2")
                NClose = dtGet2.Rows(0).Item("close")
                NClose2 = dtGet2.Rows(0).Item("close2")


                dtGet2.Dispose()

            End If

            If secondquery = False Then 'if no diviation now get the default from this day of the week
                connGet.Close()
                connGet.Open()
                sqlqueryGet = "SELECT * from  furtwangen_default where day=( WEEKDAY(DATE_ADD(NOW(), INTERVAL 7 DAY))  +1)"

                myCommandGet.Connection = connGet
                myCommandGet.CommandText = sqlqueryGet
                get_RowsGet.SelectCommand = myCommandGet

                'TextBox3.Text =  'TextBox3.Text & " sqlqueryGet " & sqlqueryGet & Environment.NewLine
                myDataGet = myCommandGet.ExecuteReader()
                If myDataGet.HasRows = 0 Then

                    'TextBox3.Text =  'TextBox3.Text & " no rows" & Environment.NewLine
                    connGet.Close()
                Else

                    connGet.Close()

                    get_RowsGet.Fill(dtGet3)

                    dbsingle = dtGet3.Rows(0).Item("single")
                    closeallday = dtGet3.Rows(0).Item("closeallday")

                    NOpen = dtGet3.Rows(0).Item("open")
                    Nopen2 = dtGet3.Rows(0).Item("open2")
                    NClose = dtGet3.Rows(0).Item("close")
                    NClose2 = dtGet3.Rows(0).Item("close2")


                    dtGet3.Dispose()

                End If
            End If
            dayOrNightJustChange = True
            compairetime()

        Catch ex As Exception
            'TextBox3.Text =  'TextBox3.Text & " ex  " & ex.ToString & Environment.NewLine
        Finally

        End Try



    End Sub
    Private Sub compairetime()
        If closeallday = "yes" Then 'if library is close activate nigth/close
            If dayOrNight = "day" Then
                dayOrNight = "night"
                dayOrNightJustChange = True
            Else
                dayOrNight = "night"
            End If


            'TextBox3.Text =  'TextBox3.Text & "##closeallday=yes dayOrNight " & dayOrNight & Environment.NewLine

        ElseIf dbsingle = "yes" Then                    'if library is open with single time range

            If NOpen <= time And NClose >= time Then    'if now is on time range  library is open

                If dayOrNight = "night" Then
                    dayOrNight = "day"
                    dayOrNightJustChange = True
                Else
                    dayOrNight = "day"
                End If


                'TextBox3.Text =  'TextBox3.Text & "##dbsingle =yes dayOrNight " & dayOrNight & Environment.NewLine
            Else                                        'if now is not on time range  library is close

                If dayOrNight = "day" Then
                    dayOrNight = "night"
                    dayOrNightJustChange = True
                Else
                    dayOrNight = "night"
                End If

                ' dayOrNight = "night"
                'dayOrNightJustChange = True
                'TextBox3.Text =  'TextBox3.Text & "##dbsingle =no dayOrNight " & dayOrNight & Environment.NewLine
            End If

        Else                                             'if library is open with two time range
            If (NOpen <= time And NClose >= time) Or (Nopen2 <= time And NClose2 >= time) Then 'if now is on time range  library is open

                If dayOrNight = "night" Then
                    dayOrNight = "day"
                    dayOrNightJustChange = True
                Else
                    dayOrNight = "day"
                End If
                ' dayOrNight = "day"
                'TextBox3.Text =  'TextBox3.Text & "##all =yes dayOrNight " & dayOrNight & Environment.NewLine
            Else                                        'if now is not on time range  library is close
                If dayOrNight = "day" Then
                    dayOrNight = "night"
                    dayOrNightJustChange = True
                Else
                    dayOrNight = "night"
                End If

                ' dayOrNight = "night"
                'dayOrNightJustChange = True
                'TextBox3.Text =  'TextBox3.Text & "##all =no dayOrNight " & dayOrNight & Environment.NewLine
            End If

            ' sqlqueryGet = "SELECT * FROM `furtwangen_day`where datestart=DATE(NOW()) and ( open<=TIME(NOW()) and close>=TIME(NOW()) ) or ( open2<=TIME(NOW()) and close2>=TIME(NOW()) )"
        End If 'end of closeallday = "yes" 
    End Sub

    Private Sub Timer2_Tick_1(ByVal sender As Object, ByVal e As EventArgs) Handles Timer2.Tick

        '  Label2.Text = datenow & " " & time.ToString & " " & TimeSpan.FromSeconds(1).ToString
        time = time.Add(TimeSpan.FromSeconds(1))
        compairetime()
        ' mydate = mydate.Add(TimeSpan.FromSeconds(1))
        If time >= hours24 Then
            time = New TimeSpan(0, 0, 0, 0, 0)
            datenow = datenow.AddDays(1)
            Dim mythread3 = New Thread(AddressOf Me.getDayAndNight)
            mythread3.Start()
        End If

        'If WhiteList.Contains(tbAddressBar.Text.ToLower()) And broswerDone = False Then

        'Else

        '    loadingImage.Visible = False
        '    browser.Navigate(New Uri(String.Format("file:///{0}/Blocked.htm", curDir)))
        '    broswerDone = True

        'End If

    End Sub

    Private Sub hidebuttons()
        HomeButton.Visible = False
        FachgebieteButton.Visible = False
        SignaturenButton.Visible = False
        DienstleistungenButton.Visible = False
        OPACButton.Visible = False
        Panel2.BackColor = Color.White

        posterCloseButton.Dock = DockStyle.Fill
        posterCloseButton.Visible = True
        '  errorMsg.Hide()
        Signaturen.errorMsgPic.Visible = False
        ' Panel2.BackColor = Color.FromArgb(66, 66, 66)
    End Sub
    Private Sub showbuttons()
        HomeButton.Visible = True
        FachgebieteButton.Visible = True
        SignaturenButton.Visible = True
        DienstleistungenButton.Visible = True
        OPACButton.Visible = True
        '  Panel2.BackColor = Color.White
        Panel2.BackColor = Color.FromArgb(66, 66, 66)

        posterCloseButton.Dock = DockStyle.None
        posterCloseButton.Visible = False

    End Sub


    Public Sub setButtonlocations()
        Dim divi As Double

        formsize = 1080
        equalz = formsize / 5
        divi = 1
        equalz = Math.Floor(equalz)
        Me.HomeButton.Location = New Point(divi, Me.HomeButton.Location.Y)
        Me.FachgebieteButton.Location = New Point(equalz + divi, Me.FachgebieteButton.Location.Y)
        Me.SignaturenButton.Location = New Point(equalz + equalz + divi, Me.SignaturenButton.Location.Y)
        Me.DienstleistungenButton.Location = New Point(equalz + equalz + equalz + divi, Me.DienstleistungenButton.Location.Y)
        Me.OPACButton.Location = New Point(equalz + equalz + equalz + equalz + divi, Me.OPACButton.Location.Y)
    End Sub
    Public Sub setActiveButton(ByVal buttonClick As String)
        If buttonClick = "Home" Then

            'titlePanel.Visible = False
            '  description.Visible = False

            disable_fachgebeite()
            disable_diens()



            ' searchbox.Visible = False
            ' searchButton.Visible = False

            keyboard.Hide()

            buttonClicked = "Home"
            animationContainer.Hide()
            posterImage.Show()
            ' browserMenu.Hide()
            browser.Hide()

            imageSetNum = 1
            timer2count = 1
            timerForImage.Start()
            timerForResumeSlide.Stop()


            'keyboard.Visible = False
            ' WebKitBrowser1.Navigate(serverURL + "kiosk/")
        ElseIf buttonClick = "Fachgebiete" Then

            'titlePanel.Visible = True
            'description.Visible = True
            'diensTitle.Text = "FACHGEBIET3333E"
            'description.Text = "Wähle ein Fachgebiet, das Dich interessiert und wir zeigen Dir," & vbCrLf & "in welchem Regal die Medien stehen:"

            disable_diens()


            '   WebKitBrowser1.Navigate(serverURL + "kiosk/fachgebiete/")

            buttonClicked = "Fachgebiete"
            animationContainer.Hide()
            posterImage.Hide()
            '  browserMenu.Hide()
            browser.Hide()

            imageSetNum = 1
            timer2count = 1
            timerForImage.Stop()

            clicked()


            '.Visible = False
            '  searchButton.Visible = False
            ' keyboard.Visible = False
            keyboard.Hide()
        ElseIf buttonClick = "Signaturen" Then
            keyboardOnSignaturen = True
            '  description.Visible = False
            'titlePanel.Visible = True
            ' diensTitle.Text = "SIGNATUREN"
            ' description.Visible = True
            '  description.Text = "Gib die ersten beiden Buchstaben der gesuchten Signatur ein und wir zeigen Dir," & vbCrLf & "in welchem Regal die Medien stehen:"

            disable_fachgebeite()
            disable_diens()


            '   WebKitBrowser1.Navigate(serverURL + "kiosk/signaturen/")
            'Gib die ersten beiden Buchstaben der gesuchten Signatur ein und wir zeigen Dir, in welchem Regal die Medien stehen:

            buttonClicked = "Signaturen"
            animationContainer.Hide()
            ' browserMenu.Hide()
            browser.Hide()
            posterImage.Hide()
            imageSetNum = 1
            timer2count = 1
            timerForImage.Stop()
            ' searchbox.Focus()
            clicked()


            '  searchbox.Visible = True
            '  searchButton.Visible = True
            '  keyboard.Visible = True

            keyboard.Show()
        ElseIf buttonClick = "Dienstleistungen" Then
            'titlePanel.Visible = True
            'description.Visible = True
            'diensTitle.Text = "DIENSTLEISTUNGEN"
            'description.Text = "Wähle die Dienstleistung, die Dich interessiert und wir zeigen Dir," & vbCrLf & "wo Du sie erhältst:"

            disable_fachgebeite()

            buttonClicked = "Dienstleistungen"
            animationContainer.Hide()
            posterImage.Hide()
            '  browserMenu.Hide()
            browser.Hide()

            imageSetNum = 1
            timer2count = 1
            timerForImage.Stop()

            clicked()
            'searchbox.Visible = False
            'searchButton.Visible = False
            'keyboard.Visible = False
            keyboard.Hide()
            '   WebKitBrowser1.Navigate(serverURL + "kiosk/dienstleistungen/")
        ElseIf buttonClick = "OPAC" Then
            keyboardOnSignaturen = False
            'titlePanel.Visible = False
            'description.Visible = False

            disable_fachgebeite()
            disable_diens()


            '   WebKitBrowser1.Navigate(serverURL + "kiosk/opac/")

            buttonClicked = "OPAC"
            animationContainer.Hide()
            posterImage.Hide()
            '  titlePanel.Visible = False
            ' description.Visible = False
            browser.Show()
            browser.Dock = DockStyle.Fill
            ' browserMenu.Show()
            ' browserMenu.Dock = DockStyle.Top


            imageSetNum = 1
            timer2count = 1
            timerForImage.Stop()
            '  tbAddressBar.Focus()
            clicked()
            keyboardText = ""

            '  keyboard.Visible = True
            keyboard.Show()


        End If




    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        '   Me.Close()
        '  dayOrNight = "night"
        dayOrNightJustChange = True
        If dayOrNight = "night" Then
            dayOrNight = "day"
        Else
            dayOrNight = "night"
        End If
    End Sub

    Public Sub clicked()
        tillSlide = 0
        closeButChangetime = 1
        If buttonClicked <> "Home" Then
            timerForResumeSlide.Stop()
            timerForResumeSlide.Start()

        ElseIf buttonClicked = "Home" Then
            timerForResumeSlide.Stop()
        End If


    End Sub
    Private Sub disable_diens()
        '-------------visible false diens button-----------------
        'beratung.Visible = False
        'beratungLabel.Visible = False

        'gruppenarbeitsplatze.Visible = False
        'gruppenarbeitsplatzeLabel.Visible = False

        'ebooks.Visible = False
        'ebooksLabel.Visible = False

        'entleihbare.Visible = False
        'entleihbareLabel.Visible = False

        'workshopbucher.Visible = False
        'workshopbucherLabel.Visible = False

        'filme.Visible = False
        'filmeLabel.Visible = False

        'selbstverbucher.Visible = False
        'selbstverbucherLabel.Visible = False

        'garderobe.Visible = False
        'garderobeLabel.Visible = False

        'einzelarbeitsplatze.Visible = False
        'einzelarbeitsplatzeLabel.Visible = False

        'datenbankin.Visible = False
        'datenbankinLabel.Visible = False

        'ejournal.Visible = False
        'ejournalsLabel.Visible = False

        'prasenzbucher.Visible = False
        'prasenzbucherLabel.Visible = False

        'zeitschriften.Visible = False
        'zeitschriftenLabel.Visible = False

        'scanner.Visible = False
        'scannerLabel.Visible = False

        'terminal.Visible = False
        'terminalLabel.Visible = False


        'schliebtacher.Visible = False
        'schliebtacherLabel.Visible = False


        '--------------end visible-------------
    End Sub

    Private Sub disable_fachgebeite()

        ''-------------visible false fach button-----------------
        'allgemeines.Visible = False
        'allgemeinesLabel.Visible = False

        'chemie.Visible = False
        'chemieLabel.Visible = False

        'informatik.Visible = False
        'informatikLabel.Visible = False

        'mathematik.Visible = False
        'mathematikLabel.Visible = False

        'medezin.Visible = False
        'medizinLabel.Visible = False

        'physik.Visible = False
        'physikLabel.Visible = False

        'regelungs.Visible = False
        'regelungsLabel.Visible = False

        'technik.Visible = False
        'tecknikLabel.Visible = False

        'volkswirtschaftslehre.Visible = False
        'VolksLabel.Visible = False

        'betrieb.Visible = False
        'betriebLabel.Visible = False

        'elektrotechnik.Visible = False
        'elektrotechnikLabel.Visible = False


        'maschinenbau.Visible = False
        'maschinenbauLabel.Visible = False

        'medien.Visible = False
        'medienLabel.Visible = False

        'messtechnik.Visible = False
        'messtechnikLabel.Visible = False

        'psychologie.Visible = False
        'psychologieLabel.Visible = False

        'soziologie.Visible = False
        'soziologieLabel.Visible = False

        'umwelt.Visible = False
        'umweltLabel.Visible = False

        'werkstoffe.Visible = False
        'werkstoffeLabel.Visible = False
        ''-------------end of visible false--------------------------

    End Sub



    Private Sub go_btn_Click(ByVal sender As Object, ByVal e As EventArgs)

        'If tbAddressBar.Text.Length > 0 Then
        '    If WhiteList.Contains(tbAddressBar.Text.ToString().ToLower()) Then
        '        browser.Navigate(tbAddressBar.Text)
        '    Else
        '        Dim curDir As String = Directory.GetCurrentDirectory()
        '        browser.Navigate(New Uri(String.Format("file:///{0}/Blocked.htm", curDir)))
        '    End If
        'Else

        'End If
        clicked()
    End Sub

    'Private Sub tbAddressBar_KeyDown(sender As Object, e As KeyEventArgs)
    '    If e.KeyCode = Keys.Enter Then
    '        If tbAddressBar.Text.Length > 0 Then
    '            If WhiteList.Contains(tbAddressBar.Text.ToString().ToLower()) Then
    '                browser.Navigate(tbAddressBar.Text)
    '            Else
    '                Dim curDir As String = Directory.GetCurrentDirectory()
    '                browser.Navigate(New Uri(String.Format("file:///{0}/Blocked.htm", curDir)))

    '            End If
    '        Else

    '        End If
    '    End If

    '    clicked()
    'End Sub

    Private Sub refresh_Click(ByVal sender As Object, ByVal e As EventArgs)
        'If tbAddressBar.Text.Length > 0 Then
        '    If WhiteList.Contains(tbAddressBar.Text.ToString().ToLower()) Then
        '        browser.Navigate(tbAddressBar.Text)
        '    Else
        '        Dim curDir As String = Directory.GetCurrentDirectory()
        '        browser.Navigate(New Uri(String.Format("file:///{0}/Blocked.htm", curDir)))
        '    End If
        'Else

        'End If
        'clicked()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick

        '  Label1.Text = "ExitActive=" & ExitActive & " ExitCode=" & ExitCode & " ExitCodeFromDB=" & ExitCodeFromDB & " tillSlide=" & tillSlide & " ExitCodeTimer=" & ExitCodeTimer
        If ExitCode = ExitCodeFromDB Then
            Me.Close()
        End If
        If ExitActive Then
            ExitCodeTimer += 1
        End If
        If ExitCodeTimer >= 180 Then
            ExitActive = False
            ExitCodeTimer = 0
            ExitCode = "8hdiwj"
        End If
        If OpenIEActive Then
            OpenIETimer += 1
        End If
        If OpenIETimer >= 180 Then
            OpenIEActive = False
            OpenIETimer = 0
            OpenIECode = "XC"
        End If
        If OpenIECode = OpenIECodePass Then
            OpenIECode = "XC"
            Process.Start("http://www.hs-furtwangen.de/willkommen/die-hochschule/zentrale-services/informations-und-medienzentrum/aktuelles/die-bibliotheken.html")
            keyboard.Hide()
            setActiveForm("Home")
            Process.Start("TabTip.exe")

        End If
        If dayOrNightJustChange = True Then


            If dayOrNight = "day" Then
                showbuttons()
                imageSetNum = batchCounts
                '   If batch = 2 Then
                'batchCounts = batchOneCounts
                '  End If
                'If batch = 1 Then
                'batchCounts = batchTwoCounts
                ' End If
                '#######
            ElseIf dayOrNight = "night" Then
                hidebuttons()
                imageSetNum = batchCountsNight
                setActiveButton_all("Home")
                setActiveForm("Home")
                'If batchNight = 2 Then
                '    batchCountsNight = batchOneCountsNight
                'End If
                'If batchNight = 1 Then
                '    batchCountsNight = batchTwoCountsNight
                'End If

            End If


            dayOrNightJustChange = False

        End If
        If doneLoadingPoster = True And downloading = False And buttonClicked = "Home" Then
            timerForImage.Stop()
            timerForImage.Start()
            If downloading = False Then
                downloading = True

            End If
            'TextBox1.Text =  'TextBox1.Text & "1041 Timer1_Tick doneLoadingPoster=" & doneLoadingPoster & " downloading=" & downloading & " buttonClicked=" & buttonClicked & Environment.NewLine

        End If


        If doneLoadingPosterNight = True And downloadingNight = False And buttonClicked = "Home" Then
            timerForImage.Stop()
            timerForImage.Start()
            If downloadingNight = False Then
                downloadingNight = True
                'TextBox2.Text =  'TextBox2.Text & "1056 Timer1_Tick" & Environment.NewLine
            End If
            'TextBox2.Text =  'TextBox2.Text & "1041 Timer1_Tick doneLoadingPosterNight=" & doneLoadingPosterNight & " downloadingNight=" & downloadingNight & " buttonClicked=" & buttonClicked & Environment.NewLine

        End If


        If closeButChange Then
            closeButChangetime += 1
            If closeButChangetime >= 180 Then
                closeButChangetime = 1
                dayOrNightJustChange = True
                dayOrNight = "night"

                closeButChange = False
            End If
        End If

        'End If

        ' If doneLoadingPoster = True Then
        '   'TextBox1.Text =  'TextBox1.Text & ""
        ' Label1.Text = "1110 " & a ' update poster
        a = a + 1
        '   'TextBox1.Text = "timer tick " & a
        If a >= 300 Then

            ' If closeButChange = False Then
            Dim mythread3 = New Thread(AddressOf Me.getDayAndNight)
            mythread3.Start()

            'End If


            If dayOrNight = "day" Then
                Dim mythread = New Thread(AddressOf Me.getPosterFromDatabase)
                mythread.Start()

            ElseIf dayOrNight = "night" Then
                Dim mythread2 = New Thread(AddressOf Me.getNigthPosterFromDatabase)
                mythread2.Start()
            End If
            Dim connGetExit = New Thread(AddressOf Me.getExitCode)
            connGetExit.Start()
            a = 0
        End If


        If posterBOOL1 = True Then
            ' label19.Text = label19.Text & " posterBOOL1 = True  " & a
            '  'TextBox1.Text =  'TextBox1.Text & "posterBOOL1" & Environment.NewLine
            Dim mythread1 = New Thread(Sub() Me.download_poster(posterURL(0), "1", "day", batch))
            mythread1.Start()
            posterBOOL1 = False
        End If

        If posterBOOL2 = True Then
            ' label19.Text = label19.Text & " posterBOOL2 = True  " & a
            '  'TextBox1.Text =  'TextBox1.Text & "posterBOOL2" & Environment.NewLine
            Dim mythread2 = New Thread(Sub() Me.download_poster(posterURL(1), "2", "day", batch))
            mythread2.Start()
            posterBOOL2 = False
        End If

        If posterBOOL3 = True Then
            ' label19.Text = label19.Text & " posterBOOL3 = True  " & a
            '  'TextBox1.Text =  'TextBox1.Text & "posterBOOL3" & Environment.NewLine
            Dim mythread3 = New Thread(Sub() Me.download_poster(posterURL(2), "3", "day", batch))
            mythread3.Start()
            posterBOOL3 = False
        End If

        If posterBOOL4 = True Then
            '  label19.Text = label19.Text & " posterBOOL4 = True  " & a
            '  'TextBox1.Text =  'TextBox1.Text & "posterBOOL4" & Environment.NewLine
            Dim mythread4 = New Thread(Sub() Me.download_poster(posterURL(3), "4", "day", batch))
            mythread4.Start()
            posterBOOL4 = False
        End If

        If posterBOOL5 = True Then
            '  label19.Text = label19.Text & " posterBOOL5 = True  " & a
            '   'TextBox1.Text =  'TextBox1.Text & "posterBOOL5" & Environment.NewLine
            Dim mythread5 = New Thread(Sub() Me.download_poster(posterURL(4), "5", "day", batch))
            mythread5.Start()
            posterBOOL5 = False
        End If
        If posterBOOL6 = True Then
            '   label19.Text = label19.Text & " posterBOOL6 = True  " & a
            '    'TextBox1.Text =  'TextBox1.Text & "posterBOOL6" & Environment.NewLine
            Dim mythread6 = New Thread(Sub() Me.download_poster(posterURL(5), "6", "day", batch))
            mythread6.Start()
            posterBOOL6 = False
        End If
        If posterBOOL7 = True Then
            '    label19.Text = label19.Text & " posterBOOL7 = True  " & a
            '    'TextBox1.Text =  'TextBox1.Text & "posterBOOL7" & Environment.NewLine
            Dim mythread7 = New Thread(Sub() Me.download_poster(posterURL(6), "7", "day", batch))
            mythread7.Start()
            posterBOOL7 = False
        End If
        If posterBOOL8 = True Then
            '   label19.Text = label19.Text & " posterBOOL8 = True  " & a
            '   'TextBox1.Text =  'TextBox1.Text & "posterBOOL8" & Environment.NewLine
            Dim mythread8 = New Thread(Sub() Me.download_poster(posterURL(7), "8", "day", batch))
            mythread8.Start()
            posterBOOL8 = False
        End If
        If posterBOOL9 = True Then
            '  label19.Text = label19.Text & " posterBOOL9 = True  " & a
            '   'TextBox1.Text =  'TextBox1.Text & "posterBOOL9" & Environment.NewLine
            Dim mythread9 = New Thread(Sub() Me.download_poster(posterURL(8), "9", "day", batch))
            mythread9.Start()
            posterBOOL9 = False
        End If
        If posterBOOL10 = True Then
            '   label19.Text = label19.Text & " posterBOOL10 = True  " & a
            '    'TextBox1.Text =  'TextBox1.Text & "posterBOOL10" & Environment.NewLine
            Dim mythread10 = New Thread(Sub() Me.download_poster(posterURL(9), "10", "day", batch))
            mythread10.Start()
            posterBOOL10 = False
        End If


        '###################

        If posterNightBOOL1 = True Then
            ' label19.Text = label19.Text & " posterNightBOOL1 = True  " & a
            '  'TextBox1.Text =  'TextBox1.Text & "posterNightBOOL1" & Environment.NewLine
            Dim mythread11 = New Thread(Sub() Me.download_posterNight(posterURLNight(0), "1", "night", batchNight))
            mythread11.Start()
            posterNightBOOL1 = False
        End If

        If posterNightBOOL2 = True Then
            ' label19.Text = label19.Text & " posterNightBOOL2 = True  " & a
            '  'TextBox1.Text =  'TextBox1.Text & "posterNightBOOL2" & Environment.NewLine
            Dim mythread12 = New Thread(Sub() Me.download_posterNight(posterURLNight(1), "2", "night", batchNight))
            mythread12.Start()
            posterNightBOOL2 = False
        End If

        If posterNightBOOL3 = True Then
            ' label19.Text = label19.Text & " posterNightBOOL3 = True  " & a
            '  'TextBox1.Text =  'TextBox1.Text & "posterNightBOOL3" & Environment.NewLine
            Dim mythread13 = New Thread(Sub() Me.download_posterNight(posterURLNight(2), "3", "night", batchNight))
            mythread13.Start()
            posterNightBOOL3 = False
        End If

        If posterNightBOOL4 = True Then
            '  label19.Text = label19.Text & " posterNightBOOL4 = True  " & a
            '  'TextBox1.Text =  'TextBox1.Text & "posterNightBOOL4" & Environment.NewLine
            Dim mythread14 = New Thread(Sub() Me.download_posterNight(posterURLNight(3), "4", "night", batchNight))
            mythread14.Start()
            posterNightBOOL4 = False
        End If

        If posterNightBOOL5 = True Then
            '  label19.Text = label19.Text & " posterNightBOOL5 = True  " & a
            '   'TextBox1.Text =  'TextBox1.Text & "posterNightBOOL5" & Environment.NewLine
            Dim mythread15 = New Thread(Sub() Me.download_posterNight(posterURLNight(4), "5", "night", batchNight))
            mythread15.Start()
            posterNightBOOL5 = False
        End If
        If posterNightBOOL6 = True Then
            '   label19.Text = label19.Text & " posterNightBOOL6 = True  " & a
            '    'TextBox1.Text =  'TextBox1.Text & "posterNightBOOL6" & Environment.NewLine
            Dim mythread16 = New Thread(Sub() Me.download_posterNight(posterURLNight(5), "6", "night", batchNight))
            mythread16.Start()
            posterNightBOOL6 = False
        End If
        If posterNightBOOL7 = True Then
            '    label19.Text = label19.Text & " posterNightBOOL7 = True  " & a
            '    'TextBox1.Text =  'TextBox1.Text & "posterNightBOOL7" & Environment.NewLine
            Dim mythread17 = New Thread(Sub() Me.download_posterNight(posterURLNight(6), "7", "night", batchNight))
            mythread17.Start()
            posterNightBOOL7 = False
        End If
        If posterNightBOOL8 = True Then
            '   label19.Text = label19.Text & " posterNightBOOL8 = True  " & a
            '   'TextBox1.Text =  'TextBox1.Text & "posterNightBOOL8" & Environment.NewLine
            Dim mythread18 = New Thread(Sub() Me.download_posterNight(posterURLNight(7), "8", "night", batchNight))
            mythread18.Start()
            posterNightBOOL8 = False
        End If
        If posterNightBOOL9 = True Then
            '  label19.Text = label19.Text & " posterNightBOOL9 = True  " & a
            '   'TextBox1.Text =  'TextBox1.Text & "posterNightBOOL9" & Environment.NewLine
            Dim mythread19 = New Thread(Sub() Me.download_posterNight(posterURLNight(8), "9", "night", batchNight))
            mythread19.Start()
            posterNightBOOL9 = False
        End If
        If posterNightBOOL10 = True Then
            '   label19.Text = label19.Text & " posterNightBOOL10 = True  " & a
            '    'TextBox1.Text =  'TextBox1.Text & "posterNightBOOL10" & Environment.NewLine
            Dim mythread20 = New Thread(Sub() Me.download_posterNight(posterURLNight(9), "10", "night", batchNight))
            mythread20.Start()
            posterNightBOOL10 = False
        End If


        '  End If

        resetOPACTimer += 1
        If resetOPACTimer = 180 Then
            resetOPAC = True
            resetOPACTimer = 0
        End If


    End Sub
    Private Sub getPosterFromDatabase()
        conn = New MySqlConnection()
        Dim myAdapter As New MySqlDataAdapter

        conn.ConnectionString = serverstring
        Try
            'TextBox1.Text =  'TextBox1.Text & "getPosterFromDatabase try-" & Environment.NewLine
            conn.Open()
            Dim sqlquery = "SELECT  COUNT(*) AS TotalNORows FROM furtwangen_poster  WHERE  posterfor='day' and hasposter='true' order by p_order asc "
            Dim dt As New DataTable
            Dim myCommand As New MySqlCommand()
            Dim get_Rows As New MySqlDataAdapter
            myCommand.Connection = conn
            myCommand.CommandText = sqlquery
            get_Rows.SelectCommand = myCommand
            Dim myData As MySqlDataReader
            'TextBox1.Text =  'TextBox1.Text & "getPosterFromDatabase MySqlDataReader" & Environment.NewLine

            myData = myCommand.ExecuteReader()

            If myData.HasRows = 0 Then
                'TextBox1.Text =  'TextBox1.Text & "getPosterFromDatabase no rows" & Environment.NewLine

                conn.Close()

            Else
                conn.Close()
                get_Rows.Fill(dt)
                noOfRows = dt.Rows(0).Item("TotalNORows")
                dt.Dispose()

                'TextBox1.Text =  'TextBox1.Text & " getPosterFromDatabase  dt.Rows(0).Item(url" & Environment.NewLine

                conn.Open()
                sqlquery = "SELECT * FROM furtwangen_poster  WHERE  posterfor='day' and hasposter='true' order by p_order asc "
                Dim get_data As New MySqlDataAdapter
                Dim dt2 As New DataTable
                myCommand.Connection = conn
                myCommand.CommandText = sqlquery
                get_data.SelectCommand = myCommand

                'TextBox1.Text =  'TextBox1.Text & "getNigthPosterFromDatabase q" & sqlquery & Environment.NewLine

                'TextBox1.Text =  'TextBox1.Text & "getPosterFromDatabase Downloading your profile" & Environment.NewLine
                myData = myCommand.ExecuteReader()

                If myData.HasRows = 0 Then
                    '#######
                    'TextBox1.Text =  'TextBox1.Text & "getPosterFromDatabase HasRows=0" & Environment.NewLine
                    conn.Close()
                Else
                    conn.Close()
                    get_data.Fill(dt2)
                    dt2.Dispose()
                    '   MsgBox("noOfRows " & dt2.Rows(0).Item("url"))
                    Dim c As Integer = 0

                    While noOfRows > c
                        posterURL(c) = dt2.Rows(c).Item("url")


                        ' posterThread(c) = New Thread(Sub() Me.download_poster(posterURL(c), c))
                        '  posterThread(c).Start()
                        '#######
                        'TextBox1.Text =  'TextBox1.Text & "1315 " & posterURL(c) & Environment.NewLine
                        c += 1

                        If c = 1 Then
                            posterBOOL1 = True
                        End If
                        If c = 2 Then
                            posterBOOL2 = True
                        End If
                        If c = 3 Then
                            posterBOOL3 = True
                        End If
                        If c = 4 Then
                            posterBOOL4 = True
                        End If
                        If c = 5 Then
                            posterBOOL5 = True
                        End If
                        If c = 6 Then
                            posterBOOL6 = True
                        End If
                        If c = 7 Then
                            posterBOOL7 = True
                        End If
                        If c = 8 Then
                            posterBOOL8 = True
                        End If
                        If c = 9 Then
                            posterBOOL9 = True
                        End If
                        If c = 10 Then
                            posterBOOL10 = True
                        End If
                        If batch = 1 Then
                            batchOneCounts = c
                        End If
                        If batch = 2 Then
                            batchTwoCounts = c
                        End If

                    End While
                    doneLoadingPoster = True

                    If batch = 1 Then
                        batch = 2
                        batchOne = True
                    ElseIf batch = 2 Then
                        batch = 1
                        batchOne = False
                    End If

                End If

            End If



        Catch ex As Exception

            'TextBox1.Text = ex.ToString

        Finally
            imageSetNum = 1
            conn.Close()
            myAdapter.Dispose()

        End Try
    End Sub
    Private Sub getNigthPosterFromDatabase() 'Night
        connNigth = New MySqlConnection()
        Dim myAdapterNigth As New MySqlDataAdapter

        connNigth.ConnectionString = serverstring

        Try
            'TextBox2.Text =  'TextBox2.Text & "getNigthPosterFromDatabase try-" & Environment.NewLine

            connNigth.Open()
            Dim sqlqueryNigth = "SELECT  COUNT(*) AS TotalNORows FROM furtwangen_poster  WHERE  posterfor='night' and hasposter='true' order by p_order asc "
            Dim dtNigth As New DataTable
            Dim myCommandNigth As New MySqlCommand()
            Dim get_RowsNigth As New MySqlDataAdapter
            myCommandNigth.Connection = connNigth
            myCommandNigth.CommandText = sqlqueryNigth
            get_RowsNigth.SelectCommand = myCommandNigth
            Dim myData As MySqlDataReader
            'TextBox2.Text =  'TextBox2.Text & "getNigthPosterFromDatabase MySqlDataReader" & Environment.NewLine
            myData = myCommandNigth.ExecuteReader()
            If myData.HasRows = 0 Then
                'TextBox2.Text =  'TextBox2.Text & " no rows" & Environment.NewLine
                connNigth.Close()
            Else
                connNigth.Close()
                get_RowsNigth.Fill(dtNigth)
                noOfRowsNight = dtNigth.Rows(0).Item("TotalNORows")
                dtNigth.Dispose()
                'TextBox2.Text =  'TextBox2.Text & "getNigthPosterFromDatabase dt.Rows(0).Item(url" & Environment.NewLine

                connNigth.Open()
                sqlqueryNigth = "SELECT * FROM furtwangen_poster  WHERE  posterfor='night' and hasposter='true' order by p_order asc "
                Dim get_dataNigth As New MySqlDataAdapter
                Dim dt2Nigth As New DataTable
                myCommandNigth.Connection = connNigth
                myCommandNigth.CommandText = sqlqueryNigth
                get_dataNigth.SelectCommand = myCommandNigth
                'TextBox2.Text =  'TextBox2.Text & "getNigthPosterFromDatabase q" & sqlqueryNigth & Environment.NewLine

                'TextBox2.Text =  'TextBox2.Text & "getNigthPosterFromDatabase Downloading your profile" & Environment.NewLine
                myData = myCommandNigth.ExecuteReader()
                If myData.HasRows = 0 Then
                    'TextBox2.Text =  'TextBox2.Text & "getNigthPosterFromDatabase HasRows=0" & Environment.NewLine
                    connNigth.Close()
                Else

                    connNigth.Close()
                    get_dataNigth.Fill(dt2Nigth)
                    dt2Nigth.Dispose()

                    Dim cNigth As Integer = 0
                    While noOfRowsNight > cNigth
                        posterURLNight(cNigth) = dt2Nigth.Rows(cNigth).Item("url")

                        'TextBox2.Text =  'TextBox2.Text & " " & posterURLNight(cNigth) & Environment.NewLine
                        cNigth += 1

                        If cNigth = 1 Then
                            posterNightBOOL1 = True
                        End If
                        If cNigth = 2 Then
                            posterNightBOOL2 = True
                        End If
                        If cNigth = 3 Then
                            posterNightBOOL3 = True
                        End If
                        If cNigth = 4 Then
                            posterNightBOOL4 = True
                        End If
                        If cNigth = 5 Then
                            posterNightBOOL5 = True
                        End If
                        If cNigth = 6 Then
                            posterNightBOOL6 = True
                        End If
                        If cNigth = 7 Then
                            posterNightBOOL7 = True
                        End If
                        If cNigth = 8 Then
                            posterNightBOOL8 = True
                        End If
                        If cNigth = 9 Then
                            posterNightBOOL9 = True
                        End If
                        If cNigth = 10 Then
                            posterNightBOOL10 = True
                        End If

                        If batchNight = 1 Then
                            batchOneCountsNight = cNigth
                        End If
                        If batchNight = 2 Then
                            batchTwoCountsNight = cNigth
                        End If

                    End While
                    doneLoadingPosterNight = True
                    If batchNight = 1 Then
                        batchNight = 2
                        batchOneNight = True
                    ElseIf batchNight = 2 Then
                        batchNight = 1
                        batchOneNight = False
                    End If

                End If
            End If



        Catch ex As Exception
            'TextBox2.Text =  'TextBox2.Text & ex.ToString



        Finally
            imageSetNum = 1
            connNigth.Close()
            myAdapterNigth.Dispose()
        End Try
    End Sub
    Private Sub download_posterNight(ByVal url As String, ByVal filename As String, ByVal posterfor As String, ByVal batchw As String)
        downloadingNight = True


        Dim Client As New WebClient
        Dim path As String = Application.StartupPath & "\poster\" & batchw & "_" & posterfor & "_" & filename & ".png"

        Try
            If System.IO.File.Exists(path) = True Then

                System.IO.File.Delete(path)
            End If

        Catch ex As Exception

        End Try
        Try
            Client.DownloadFile(url, path)
            'TextBox2.Text =  'TextBox2.Text & path & Environment.NewLine
            Client.Dispose()
        Catch ex As Exception

        Finally
            'TextBox1.Text =  'TextBox1.Text & "downloadingNight=False" & Environment.NewLine
            downloadingNight = False
        End Try

    End Sub


    Private Sub download_poster(ByVal url As String, ByVal filename As String, ByVal posterfor As String, ByVal batchw As String)
        downloading = True



        Dim Client As New WebClient
        Dim path As String = Application.StartupPath & "\poster\" & batchw & "_" & posterfor & "_" & filename & ".png"

        Try
            If System.IO.File.Exists(path) = True Then
                System.IO.File.Delete(path)
            End If

        Catch ex As Exception

        End Try
        Try

            Client.DownloadFile(url, path)
            'TextBox1.Text =  'TextBox1.Text & path & Environment.NewLine
            If batchw = 2 Then

            End If
            If batchw = 1 Then

            End If
            Client.Dispose()

        Catch ex As Exception

        Finally
            'TextBox1.Text =  'TextBox1.Text & "downloading=False" & Environment.NewLine
            downloading = False
        End Try
    End Sub
    Private Sub timerForImage_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timerForImage.Tick



        '   Label1.Text = "1628 " & timer2count & "- dayOrNight-" & dayOrNight & "  imageSetNum=" & imageSetNum _
        '   & " batch=" & batch & " batchCounts=" & batchCounts & " batchOneCounts=" & batchOneCounts & " batchTwoCounts=" & batchTwoCounts _
        '    & "#### batchNight=" & batchNight & " batchCountsNight=" & batchCountsNight & " batchOneCountsNight=" & batchOneCountsNight & " batchTwoCountsNight=" & batchTwoCountsNight

        If batch = 2 Then
            batchCounts = batchOneCounts
        End If
        If batch = 1 Then
            batchCounts = batchTwoCounts
        End If


        '#######
        If batchNight = 2 Then
            batchCountsNight = batchOneCountsNight
        End If
        If batchNight = 1 Then
            batchCountsNight = batchTwoCountsNight
        End If

        If timer2count = 40 Then

            If dayOrNight = "day" Then
                If batchCounts >= imageSetNum Then
                    If batch = 2 Then

                        If imageSetNum = 0 Then
                            Try
                                posterImage.Image.Dispose()
                            Catch ex As Exception

                            End Try
                            posterImage.Image = My.Resources.defaultposter
                        Else
                            Try
                                posterImage.Image.Dispose()
                            Catch ex As Exception

                            End Try

                            Try
                                posterImage.Image = Image.FromFile(Application.StartupPath & "\poster\" & batch & "_" & dayOrNight & "_" & imageSetNum & ".png")
                            Catch ex As Exception
                                posterImage.Image = My.Resources.defaultposter
                            End Try

                        End If

                    End If
                    If batch = 1 Then

                        If imageSetNum = 0 Then
                            Try
                                posterImage.Image.Dispose()
                            Catch ex As Exception

                            End Try
                            posterImage.Image = My.Resources.defaultposter
                        Else
                            Try
                                posterImage.Image.Dispose()
                            Catch ex As Exception

                            End Try
                            Try
                                posterImage.Image = Image.FromFile(Application.StartupPath & "\poster\" & batch & "_" & dayOrNight & "_" & imageSetNum & ".png")
                            Catch ex As Exception
                                posterImage.Image = My.Resources.defaultposter
                            End Try


                            ' posterImage.Image = Poster2(imageSetNum)
                        End If


                    End If
                    timer2count = 1
                    If batchCounts = imageSetNum Then
                        imageSetNum = 0
                    End If
                    imageSetNum += 1
                End If

            ElseIf dayOrNight = "night" Then
                If batchCountsNight >= imageSetNum Then
                    If batchNight = 2 Then
                        If imageSetNum = 0 Then
                            Try
                                posterImage.Image.Dispose()
                            Catch ex As Exception

                            End Try
                            posterImage.Image = My.Resources.defaultposter
                        Else
                            Try
                                posterImage.Image.Dispose()
                            Catch ex As Exception

                            End Try
                            Try
                                posterImage.Image = Image.FromFile(Application.StartupPath & "\poster\" & batch & "_" & dayOrNight & "_" & imageSetNum & ".png")
                            Catch ex As Exception
                                posterImage.Image = My.Resources.defaultposter
                            End Try
                        End If





                    End If
                    If batchNight = 1 Then
                        If imageSetNum = 0 Then
                            Try
                                posterImage.Image.Dispose()
                            Catch ex As Exception

                            End Try
                            posterImage.Image = My.Resources.defaultposter
                        Else
                            Try
                                posterImage.Image.Dispose()
                            Catch ex As Exception

                            End Try
                            Try
                                posterImage.Image = Image.FromFile(Application.StartupPath & "\poster\" & batch & "_" & dayOrNight & "_" & imageSetNum & ".png")
                            Catch ex As Exception
                                posterImage.Image = My.Resources.defaultposter
                            End Try
                        End If




                    End If
                    timer2count = 1
                    If batchCountsNight = imageSetNum Then
                        imageSetNum = 0
                    End If
                    imageSetNum += 1
                End If

            End If

            '#######################
            'If batchCounts >= imageSetNum Then

            '    If dayOrNight = "day" Then
            '        If batch = 2 Then
            '            posterImage.Image = Poster1(imageSetNum)

            '            '      'TextBox2.Text = postersDay1(imageSetNum)


            '        End If
            '        If batch = 1 Then
            '            posterImage.Image = Poster2(imageSetNum)

            '            '     posterImage.Image = PosterNight2(imageSetNum)

            '        End If

            '        timer2count = 1
            '        If batchCounts = imageSetNum Then
            '            imageSetNum = 0
            '        End If
            '        imageSetNum += 1
            '    ElseIf dayOrNight = "night" Then
            '        If batchNight = 2 Then
            '            posterImage.Image = PosterNight1(imageSetNum)

            '            '      'TextBox2.Text = postersDay1(imageSetNum)


            '        End If
            '        If batchNight = 1 Then
            '            posterImage.Image = PosterNight2(imageSetNum)

            '            '     posterImage.Image = PosterNight2(imageSetNum)

            '        End If

            '        timer2count = 1
            '        If batchCountsNight = imageSetNum Then
            '            imageSetNum = 0
            '        End If
            '        imageSetNum += 1
            '    End If



            'End If


        End If
        If dayOrNight = "day" Then
            If batchCounts < imageSetNum Then
                imageSetNum = 0
            End If
        ElseIf dayOrNight = "night" Then
            If batchCountsNight < imageSetNum Then
                imageSetNum = 0
            End If
        End If

        timer2count += 1
    End Sub

    Private Sub timerForResumeSlide_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timerForResumeSlide.Tick

        tillSlide += 1
        ' Label1.Text = "1818 " & tillSlide ' resume slide
        If tillSlide >= 180 Then
            '  setActiveButton("Home")
            setActiveButton_all("Home")
            setActiveForm("Home")
            animationContainer.Visible = False
            animationLabelPanel.Visible = False
            posterImage.Show()
            loadingImage.Visible = False
            '  browserMenu.Hide()
            browser.Hide()

            imageSetNum = 1
            timer2count = 1
            timerForImage.Start()

            tillSlide = 0
            timerForResumeSlide.Stop()
            posterImage.Image = My.Resources.defaultposter
            pdfIsactive = False
        End If

    End Sub

    Private Sub browser_CreateWindow(sender As Object, e As Gecko.GeckoCreateWindowEventArgs) Handles browser.CreateWindow

    End Sub

    Private Sub browser_CreateWindow2(sender As Object, e As Gecko.GeckoCreateWindow2EventArgs) Handles browser.CreateWindow2

    End Sub


    Private Sub browser_DocumentCompleted(ByVal sender As Object, ByVal e As WebBrowserDocumentCompletedEventArgs) Handles browser.DocumentCompleted

        loadingImage.Visible = False
        ' browser.sender.Document.Window.Error += New HtmlElementErrorEventHandler(Window_Error)
        '  MsgBox(buttonClicked)
        'If browserSetToMobile = False Then

        '    'browser.DocumentText = browser.DocumentText.Replace("</HTML>", "<style type='text/css'>html {	-webkit-text-size-adjust: none; }body { background: none; background-color: #fff; }</style></HTML>")
        '    'browser.Refresh()
        '    browserSetToMobile = True
        'End If

        ' InputBox("Hi", "title", browser.DocumentText)
        'If WhiteList.Contains(browser.ToString().ToLower()) Then
        '    '  browser.Navigate(tbAddressBar.Text)
        'Else

        '    '  e.Cancel = True
        '    loadingImage.Visible = False
        '    If broswerDone = True Then
        '        browser.Navigate(New Uri(String.Format("file:///{0}/Blocked.htm", curDir)))
        '        broswerDone = False
        '    End If


        'End If

        '        Try
        '            Dim doc As HtmlDocument = sender.Document
        '            Dim he As HtmlElement = doc.GetElementById("wrapper_inside")
        '            Dim rich As String



        '            rich = "<style type=" & Chr(34) & "text/css" & Chr(34) & ">html {	-webkit-text-size-adjust: none; }" & _
        '"body { background: none; background-color: #fff; }" & _
        '"p, h2 { margin: 0 0 0 0; }" & _
        '"#topleiste { margin-bottom: 0px; }" & _
        '"#fontsizer, #spruch {" & _
        ' "   top: auto; right: auto; bottom: auto; left: auto;" & _
        '  "  position: relative; width: auto;" & _
        '"}" & _
        '"#ort { position: relative; right: auto; bottom: auto; }" & _
        '"#left, #right, #main {" & _
        ' "   width: 100% !important; margin: 0 !important; padding: 0 !important; float: none !important;" & _
        '"}#left .inside, #right .inside { margin: 0; padding: 0px 8px; border: 0px none !important; }" & _
        '"#left .inside, #right .inside { background: #fff none }" & _
        '"#main .inside  { margin: 8px 0 0 0; padding: 8px 8px; border: 0px none !important; }" & _
        '".klar { clear: both; }" & _
        '"/* Ausblendungen */" & _
        '"#header, #footer, #breadcrumb, #sprunglinks, #settings, " & _
        '".sprung, .outside, .invisible, .noprint, .button_gesamt," & _
        '" .noprint, .toolbar_txt, .toolbar_txt_dis { display: none }" & _
        '"/* Navigation */" & _
        '"#navi { display:none }" & _
        '"#showNavi { display:block }" & _
        '"#showNavi a {  " & _
        '"  display: block; padding: .4em 0 0.4em 8px; " & _
        '"  background-image: none;" & _
        '"  background-repeat: no-repeat; " & _
        '"  background-position: 0px 0.7em;" & _
        '"}" & _
        '".buttonl {" & _
        ' " float: none; cursor: pointer; " & _
        '  "overflow:visible; text-align: center; vertical-align:top; font-size:110%;" & _
        '  "background-color: #E1E1E1; " & _
        ' " color: #333; border: 1px solid #C0C0C0;" & _
        '"}/* Trefferliste: 1.Spalte ausblenden */" & _
        '"#main #R07 table.rTable_table th:first-child { display:none }" & _
        '"#main #R07 table.rTable_table td:first-child { display:none }" & _
        '"#main #R07 table.rTable_table col { width:auto }" & _
        '"/* Einzeltreffer: linke Spalte ausblenden     */" & _
        '"/* deaktiviert wegen Bandliste, Ticket #16545 */" & _
        '"/* #main #R06 table.gi th { display:none }    */" & _
        '"/* Einzeltreffer: variable Spaltenbreite, keine Rahmen */" & _
        '"#main #R06 table.gi th  { width:auto }" & _
        '"#main #R06 table.gi col { width:auto }" & _
        '".gi th, .gi tr, .gi td { padding: 0 0 0 8; border: 0px }" & _
        '"/* Einzeltreffer: Exemplartabelle auto */" & _
        '"#main #R08 table.rTable_table { table-layout: auto; }" & _
        '"/*---- rechte Spalte: Alles ausblenden bis auf den Bestellbutton (#R04) ----*/" & _
        '"#right .cbtree_div, #right ul, #right h2, #right #R03, #right #R05, #right #R06, " & _
        '"#right #R08, #right #R11, #right #R14, #right #R30, #right input.buttong { display:none }" & _
        '"#right input.wichtig { border-color: #002780; color: #fff; width: 100%; font-size: 110%;" & _
        '" margin-top: 8px; padding: 0.4em 0 0.4em 0 }" & _
        '"/* 12.3.14: Message Box bei Kontoanmeldung */" & _
        '".message { width: 100%; text-align: left; margin: 10px auto; padding: 5px; border: none; }" & _
        '".message p { text-align: center; margin: 0; }" & _
        '".message p.lnk { padding-left: 0px; }" & _
        '"/* ---- Clearfix ---- */" & _
        '".clearfix:after {  content: " & Chr(34) & "." & Chr(34) & ";  display: block;  height: 0;  clear: both; visibility: hidden; }" & _
        '".clearfix {display: inline-block;}" & _
        '"/* Hides from IE-mac \*/" & _
        '"* html .clearfix {height: 1%;}" & _
        '".clearfix {display: block;}" & _
        '" </style>"
        '            RichTextBox1.Text = RichTextBox1.Text & " 1" & vbNewLine
        '            If browserSetToMobile = False Then
        '                RichTextBox1.Text = RichTextBox1.Text & " browserSetToMobile False " & vbNewLine
        '                'browser.DocumentText = browser.DocumentText.Replace("</HTML>", "<style type='text/css'>html {	-webkit-text-size-adjust: none; }body { background: none; background-color: #fff; }</style></HTML>")
        '                'browser.Refresh()

        '                'Dim axObj As New Object
        '                'axObj = browser.ActiveXInstance
        '                'axObj.document.designmode = "On"



        '                Dim str As String = browser.DocumentText

        '                str = str.Replace("</body>", rich)
        '                browser.DocumentText = str
        '                browser.Refresh()
        '                '  RichTextBox1.Visible = False
        '                ' he.InnerText += rich
        '                'he.InnerHtml = rich & he.OuterHtml
        '                RichTextBox1.Text = browser.DocumentText
        '                ' If count < 2 Then
        '                'count += 1
        '                '    RichTextBox1.Text = RichTextBox1.Text & " count " & count & vbNewLine
        '                '  Else
        '                browserSetToMobile = True
        '                RichTextBox1.Text = RichTextBox1.Text & " browserSetToMobile True" & vbNewLine
        '                '  End If

        '            End If
        '            ' MsgBox(he.InnerText)
        '        Catch ex As Exception
        '            ' MsgBox(ex.ToString())
        '        End Try
    End Sub



    Private Sub browser_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles browser.GotFocus
        If keyboardform <> "HFUKioskSytem" Then
            FocusJustChange = True
            ' keyboard.Signaturetextbox.Focused = False
            ' keyboard.DefaultTexbox.Focus()
            ' browser.Focus()
        End If

        keyboardform = "HFUKioskSytem"

        '  MsgBox("browser got focus")
    End Sub

    Private Sub browser_Navigated(ByVal sender As Object, ByVal e As WebBrowserNavigatedEventArgs) Handles browser.DocumentCompleted
        Dim curDir As String = Directory.GetCurrentDirectory()
        curDir = curDir.Replace("\", "/")
        Dim st = String.Format("file:///{0}/Blocked.htm", curDir)

        If browser.Url.ToString() = st Then

        Else
            keyboard.Url_text.Text = browser.Url.ToString()
            ' If tbAddressBar.Text = New Uri("http://stackoverflow.com") Then

        End If

        If browser.CanGoBack Then
            hasback = True
            keyboard.Url_back.Image = My.Resources.url_prev
        Else
            keyboard.Url_back.Image = My.Resources.url_prevGray
            hasback = False
        End If

        If browser.CanGoForward Then
            hasnext = True
            keyboard.Url_forward.Image = My.Resources.url_next
        Else
            keyboard.Url_forward.Image = My.Resources.url_nextGray
            hasnext = False
        End If
        'MsgBox(browser.Url.ToString() & " " & st)




    End Sub

    Private Sub browser_Navigating(ByVal sender As Object, ByVal e As WebBrowserNavigatingEventArgs) Handles browser.Navigating
        loadingImage.Visible = True
        If lasturl <> e.Url.ToString Then
            lasturl = e.Url.ToString
            If e.Url.ToString.Contains(".pdf") Then
                e.Cancel = True
                browser.Stop()
                '  browser.AllowNavigation = False
                loadingImage.Visible = False
                '  MsgBox("DEBUG line 1898")
                Try
                    pdfReader.Dock = DockStyle.Fill
                    pdfReader.Visible = True
                    pdfReader.src = e.Url.ToString
                    pdfIsactive = True
                Catch ex As Exception

                End Try
                '   browser.AllowNavigation = True
            End If
            ' MsgBox(e.Url.ToString)
        End If
        For Each file As String In My.Settings.Files
            If e.Url.ToString.EndsWith(file) Then
                e.Cancel = True
                ' MsgBox("no download")
                loadingImage.Visible = False
            End If
        Next
        If browser.CanGoBack Then
            hasback = True
            keyboard.Url_back.Image = My.Resources.url_prev
        Else
            keyboard.Url_back.Image = My.Resources.url_prevGray
            hasback = False
        End If

        If browser.CanGoForward Then
            hasnext = True
            keyboard.Url_forward.Image = My.Resources.url_next
        Else
            keyboard.Url_forward.Image = My.Resources.url_nextGray
            hasnext = False
        End If



        'If WhiteList.Contains(e.Url.ToString) Then

        'Else
        '    Dim curDir As String = Directory.GetCurrentDirectory()
        '    browser.Navigate(New Uri(String.Format("file:///{0}/Blocked.htm", curDir)))

        'End If
        'Label1.Text = e.Url.ToString

    End Sub

    Private Sub Form1_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseClick
        clicked()
    End Sub

    Private Sub undo_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        browser.GoBack()
    End Sub

    Private Sub redo_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        browser.GoForward()
    End Sub




    Private Sub searchbox_GotFocus(ByVal sender As Object, ByVal e As EventArgs)

        clicked()
    End Sub

    Private Sub searchbox_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs)

        clicked()
    End Sub

    Private Sub searchbox_TextChanged(ByVal sender As Object, ByVal e As EventArgs)

        clicked()
    End Sub


    Private Sub tbAddressBar_TextChanged(ByVal sender As Object, ByVal e As EventArgs)

        clicked()
    End Sub


    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim mythread = New Thread(AddressOf Me.getPosterFromDatabase)
        mythread.Start()

        '  Dim mythread2 = New Thread(AddressOf Me.getNigthPosterFromDatabase)
        '  mythread2.Start()
    End Sub

    Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs)
        '  Dim mythread = New Thread(AddressOf Me.getPosterFromDatabase)
        '  mythread.Start()

        Dim mythread2 = New Thread(AddressOf Me.getNigthPosterFromDatabase)
        mythread2.Start()
    End Sub



    Private Sub beratung_Click_1(ByVal sender As Object, ByVal e As EventArgs)
        animationContainer.Image = My.Resources.bein
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub beratungLabel_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.bein
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub
    Private Sub gruppenarbeitsplatze_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.gap
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub gruppenarbeitsplatzeLabel_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.gap
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub ebooks_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub ebooksLabel_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub entleihbare_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.enbue
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub entleihbareLabel_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.enbue
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub workshopbucher_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.wopro
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub workshopbucherLabel_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.wopro
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub filme_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.fivi
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub filmeLabel_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.fivi
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub selbstverbucher_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.selb
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub selbstverbucherLabel_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.selb
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub garderobe_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.gard
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub garderobeLabel_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.gard
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub einzelarbeitsplatze_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.eap
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub einzelarbeitsplatzeLabel_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.eap
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub prasenzbucher_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.prae
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub prasenzbucherLabel_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.prae
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub zeitschriften_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.zeizei
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub zeitschriftenLabel_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.zeizei
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub scanner_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.sca
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub scannerLabel_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.sca
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub terminal_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.kat
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub terminalLabel_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.kat
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub schliebtacher_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.schli
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub schliebtacherLabel_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.schli
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub allgemeines_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.a
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub allgemeinesLabel_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.a
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub chemie_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.c
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub chemieLabel_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.c
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub informatik_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.i
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub informatikLabel_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.i
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub medezin_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.d
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub medizinLabel_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.d
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub mathematik_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.m
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub mathematikLabel_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.m
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub physik_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.p
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub physikLabel_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.p
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub regelungs_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.rs
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub regelungsLabel_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.rs
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub technik_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.t
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub tecknikLabel_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.t
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub volkswirtschaftslehre_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.v
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub VolksLabel_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.v
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub betrieb_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.b
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub betriebLabel_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.b
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub elektrotechnik_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.e
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub elektrotechnikLabel_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.e
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub maschinenbau_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.f
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub maschinenbauLabel_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.f
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub medien_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.n
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub medienLabel_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.n
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub messtechnik_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.x
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub messtechnikLabel_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.x
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub psychologie_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.g
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub psychologieLabel_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.g
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub soziologie_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.h
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub soziologieLabel_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.h
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub umwelt_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.u
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub umweltLabel_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.u
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub werkstoffe_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.w
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub werkstoffeLabel_Click(ByVal sender As Object, ByVal e As EventArgs)
        clicked()
        animationContainer.Image = My.Resources.w
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

        disable_fachgebeite()
        disable_diens()
    End Sub

    Private Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs)
        time = time.Add(TimeSpan.FromMinutes(1))
    End Sub

    Private Sub Button5_Click(ByVal sender As Object, ByVal e As EventArgs)
        time = time.Add(TimeSpan.FromHours(1))
    End Sub

    Private Sub Button6_Click(ByVal sender As Object, ByVal e As EventArgs)
        time = time.Add(TimeSpan.FromSeconds(1))
    End Sub

    'Private Sub searchButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles searchButton.Click
    '    searchclick(searchbox.Text)
    'End Sub
    Private Sub FillAnimation()

        setActiveButton("Signaturen")
        animationContainer.Show()
        animationContainer.Dock = DockStyle.Fill

    End Sub
    Public Function searchclick(ByVal keyword As String)

        Dim result = True
        clicked()

        Select Case keyword
            Case "AE"



                animationLabelPanel.Show()
                animationLabelPanel.BringToFront()
                animationLabel.Text = "Dienstleistungen:"
                animationLabelPanel.Location = New Point(70, 138)
                animationLabelDes.Text = "Beratung und information"

                animationLabelPanel.Show()
                animationLabelPanel.BringToFront()
                animationLabelPanel.Visible = True
                animationLabel.Text = ""
                animationLabelPanel.Location = New Point(70, 138)
                animationLabelDes.Text = ""
                signatureLabel.Text = "Signatur: AE"

                animationLabelDes.Visible = True
                animationLabel.Visible = True
                signatureLabel.Visible = True

                animationContainer.Image = My.Resources.ae
                FillAnimation()
                keyboard.Hide()

            Case "AF"

                animationLabelPanel.Show()
                animationLabelPanel.BringToFront()
                animationLabelPanel.Visible = True
                animationLabel.Text = ""
                animationLabelPanel.Location = New Point(70, 138)
                animationLabelDes.Text = ""
                signatureLabel.Text = "Signatur: AF"

                animationLabelDes.Visible = False
                animationLabel.Visible = False
                signatureLabel.Visible = True

                animationContainer.Image = My.Resources.af
                FillAnimation()
                keyboard.Hide()

            Case "AG"

                animationLabelPanel.Show()
                animationLabelPanel.BringToFront()
                animationLabelPanel.Visible = True
                animationLabel.Text = ""
                animationLabelPanel.Location = New Point(70, 138)
                animationLabelDes.Text = ""
                signatureLabel.Text = "Signatur: AG"


                animationLabelDes.Visible = False
                animationLabel.Visible = False
                signatureLabel.Visible = True

                animationContainer.Image = My.Resources.ag
                FillAnimation()
                keyboard.Hide()

            Case "AH"
                animationLabelPanel.Visible = True
                animationLabelPanel.Show()
                animationLabelPanel.BringToFront()
                animationLabel.Text = ""
                animationLabelPanel.Location = New Point(70, 138)
                animationLabelDes.Text = ""
                signatureLabel.Text = "Signatur: AH"


                animationLabelDes.Visible = False
                animationLabel.Visible = False
                signatureLabel.Visible = True

                animationContainer.Image = My.Resources.ah
                FillAnimation()
                keyboard.Hide()

            Case "AK"
                animationContainer.Image = My.Resources.ak
                FillAnimation()
                keyboard.Hide()

            Case "AL"
                animationContainer.Image = My.Resources.al
                FillAnimation()
                keyboard.Hide()

            Case "AP"
                animationContainer.Image = My.Resources.ap
                FillAnimation()
                keyboard.Hide()

            Case "AR"
                animationContainer.Image = My.Resources.ar
                FillAnimation()
                keyboard.Hide()

            Case "AS"
                animationContainer.Image = My.Resources._as
                FillAnimation()
                keyboard.Hide()

            Case "BA"
                animationContainer.Image = My.Resources.ba
                FillAnimation()
                keyboard.Hide()

            Case "BE"
                animationContainer.Image = My.Resources.be_bl
                FillAnimation()
                keyboard.Hide()

            Case "BL"
                animationContainer.Image = My.Resources.be_bl
                FillAnimation()
                keyboard.Hide()

            Case "BM"
                animationContainer.Image = My.Resources.bm_bn
                FillAnimation()
                keyboard.Hide()

            Case "BN"
                animationContainer.Image = My.Resources.bm_bn
                FillAnimation()
                keyboard.Hide()

            Case "BO"
                animationContainer.Image = My.Resources.bo
                FillAnimation()
                keyboard.Hide()

            Case "BP"
                animationContainer.Image = My.Resources.bp_br
                FillAnimation()
                keyboard.Hide()

            Case "BR"
                animationContainer.Image = My.Resources.bp_br
                FillAnimation()
                keyboard.Hide()

            Case "CA"
                animationContainer.Image = My.Resources.ca_cb_cl_cn_co_cv_cy_da_db_de_df_dh_dl_dm
                FillAnimation()
                keyboard.Hide()

            Case "CB"
                animationContainer.Image = My.Resources.ca_cb_cl_cn_co_cv_cy_da_db_de_df_dh_dl_dm
                FillAnimation()
                keyboard.Hide()

            Case "CL"
                animationContainer.Image = My.Resources.ca_cb_cl_cn_co_cv_cy_da_db_de_df_dh_dl_dm
                FillAnimation()
                keyboard.Hide()

            Case "CN"
                animationContainer.Image = My.Resources.ca_cb_cl_cn_co_cv_cy_da_db_de_df_dh_dl_dm
                FillAnimation()
                keyboard.Hide()

            Case "CO"
                animationContainer.Image = My.Resources.ca_cb_cl_cn_co_cv_cy_da_db_de_df_dh_dl_dm
                FillAnimation()
                keyboard.Hide()

            Case "CV"
                animationContainer.Image = My.Resources.ca_cb_cl_cn_co_cv_cy_da_db_de_df_dh_dl_dm
                FillAnimation()
                keyboard.Hide()

            Case "CY"
                animationContainer.Image = My.Resources.ca_cb_cl_cn_co_cv_cy_da_db_de_df_dh_dl_dm
                FillAnimation()
                keyboard.Hide()

            Case "DA"
                animationContainer.Image = My.Resources.ca_cb_cl_cn_co_cv_cy_da_db_de_df_dh_dl_dm
                FillAnimation()
                keyboard.Hide()

            Case "DB"
                animationContainer.Image = My.Resources.ca_cb_cl_cn_co_cv_cy_da_db_de_df_dh_dl_dm
                FillAnimation()
                keyboard.Hide()

            Case "DE"
                animationContainer.Image = My.Resources.ca_cb_cl_cn_co_cv_cy_da_db_de_df_dh_dl_dm
                FillAnimation()
                keyboard.Hide()

            Case "DF"
                animationContainer.Image = My.Resources.ca_cb_cl_cn_co_cv_cy_da_db_de_df_dh_dl_dm
                FillAnimation()
                keyboard.Hide()

            Case "DH"
                animationContainer.Image = My.Resources.ca_cb_cl_cn_co_cv_cy_da_db_de_df_dh_dl_dm
                FillAnimation()
                keyboard.Hide()

            Case "DL"
                animationContainer.Image = My.Resources.ca_cb_cl_cn_co_cv_cy_da_db_de_df_dh_dl_dm
                FillAnimation()
                keyboard.Hide()

            Case "DM"
                animationContainer.Image = My.Resources.ca_cb_cl_cn_co_cv_cy_da_db_de_df_dh_dl_dm
                FillAnimation()
                keyboard.Hide()

                'Case " "
                '    animationContainer.Image = My.Resources.
                '    FillAnimation()
                '    keyboard.Hide()

            Case "DP"
                animationContainer.Image = My.Resources.dp_dx_ea_eb
                FillAnimation()
                keyboard.Hide()

            Case "DX"
                animationContainer.Image = My.Resources.dp_dx_ea_eb
                FillAnimation()
                keyboard.Hide()

            Case "EA"
                animationContainer.Image = My.Resources.dp_dx_ea_eb
                FillAnimation()
                keyboard.Hide()

            Case "EB"
                animationContainer.Image = My.Resources.dp_dx_ea_eb
                FillAnimation()
                keyboard.Hide()

            Case "EF"
                animationContainer.Image = My.Resources.ef
                FillAnimation()
                keyboard.Hide()

            Case "EK"
                animationContainer.Image = My.Resources.ek
                FillAnimation()
                keyboard.Hide()

            Case "EL"
                animationContainer.Image = My.Resources.el_em
                FillAnimation()
                keyboard.Hide()

            Case "EM"
                animationContainer.Image = My.Resources.el_em
                FillAnimation()
                keyboard.Hide()

            Case "EN"
                animationContainer.Image = My.Resources.en
                FillAnimation()
                keyboard.Hide()

            Case "EO"
                animationContainer.Image = My.Resources.eo_er_es_et
                FillAnimation()
                keyboard.Hide()

            Case "ER"
                animationContainer.Image = My.Resources.eo_er_es_et
                FillAnimation()
                keyboard.Hide()

            Case "ES"
                animationContainer.Image = My.Resources.eo_er_es_et
                FillAnimation()
                keyboard.Hide()

            Case "ET"
                animationContainer.Image = My.Resources.eo_er_es_et
                FillAnimation()
                keyboard.Hide()

            Case "EU"
                animationContainer.Image = My.Resources.eu
                FillAnimation()
                keyboard.Hide()

            Case "FK"
                animationContainer.Image = My.Resources.fk
                FillAnimation()
                keyboard.Hide()

            Case "FL"
                animationContainer.Image = My.Resources.fl_fm_fq_fu
                FillAnimation()
                keyboard.Hide()

            Case "FM"
                animationContainer.Image = My.Resources.fl_fm_fq_fu
                FillAnimation()
                keyboard.Hide()

            Case "FQ"
                animationContainer.Image = My.Resources.fl_fm_fq_fu
                FillAnimation()
                keyboard.Hide()

            Case "FU"
                animationContainer.Image = My.Resources.fl_fm_fq_fu
                FillAnimation()
                keyboard.Hide()

            Case "GA"
                animationContainer.Image = My.Resources.ga_gb_ge_gl_gx_ha_he_hl_hn
                FillAnimation()
                keyboard.Hide()

            Case "GB"
                animationContainer.Image = My.Resources.ga_gb_ge_gl_gx_ha_he_hl_hn
                FillAnimation()
                keyboard.Hide()

            Case "GE"
                animationContainer.Image = My.Resources.ga_gb_ge_gl_gx_ha_he_hl_hn
                FillAnimation()
                keyboard.Hide()

            Case "GL"
                animationContainer.Image = My.Resources.ga_gb_ge_gl_gx_ha_he_hl_hn
                FillAnimation()
                keyboard.Hide()

            Case "GX"
                animationContainer.Image = My.Resources.ga_gb_ge_gl_gx_ha_he_hl_hn
                FillAnimation()
                keyboard.Hide()

            Case "HA"
                animationContainer.Image = My.Resources.ga_gb_ge_gl_gx_ha_he_hl_hn
                FillAnimation()
                keyboard.Hide()

            Case "HE"
                animationContainer.Image = My.Resources.ga_gb_ge_gl_gx_ha_he_hl_hn
                FillAnimation()
                keyboard.Hide()

            Case "HL"
                animationContainer.Image = My.Resources.ga_gb_ge_gl_gx_ha_he_hl_hn
                FillAnimation()
                keyboard.Hide()

            Case "HN"
                animationContainer.Image = My.Resources.ga_gb_ge_gl_gx_ha_he_hl_hn
                FillAnimation()
                keyboard.Hide()

            Case "HS"
                animationContainer.Image = My.Resources.hs_hx
                FillAnimation()
                keyboard.Hide()

            Case "HX"
                animationContainer.Image = My.Resources.hs_hx
                FillAnimation()
                keyboard.Hide()

            Case "IA"
                animationContainer.Image = My.Resources.ia
                FillAnimation()
                keyboard.Hide()

            Case "IB"
                animationContainer.Image = My.Resources.ib
                FillAnimation()
                keyboard.Hide()

            Case "IC"
                animationContainer.Image = My.Resources.ic
                FillAnimation()
                keyboard.Hide()

            Case "ID"
                animationContainer.Image = My.Resources.id
                FillAnimation()
                keyboard.Hide()

            Case "IL"
                animationContainer.Image = My.Resources.il_io_ip_iq
                FillAnimation()
                keyboard.Hide()

            Case "IO"
                animationContainer.Image = My.Resources.il_io_ip_iq
                FillAnimation()
                keyboard.Hide()

            Case "IP"
                animationContainer.Image = My.Resources.il_io_ip_iq
                FillAnimation()
                keyboard.Hide()

            Case "IQ"
                animationContainer.Image = My.Resources.il_io_ip_iq
                FillAnimation()
                keyboard.Hide()

            Case "IR"
                animationContainer.Image = My.Resources.ir
                FillAnimation()
                keyboard.Hide()

            Case "IS"
                animationContainer.Image = My.Resources._is
                FillAnimation()
                keyboard.Hide()

            Case "IT"
                animationContainer.Image = My.Resources.it_iw_ix
                FillAnimation()
                keyboard.Hide()

            Case "IW"
                animationContainer.Image = My.Resources.it_iw_ix
                FillAnimation()
                keyboard.Hide()

            Case "IX"
                animationContainer.Image = My.Resources.it_iw_ix
                FillAnimation()
                keyboard.Hide()

            Case "MA"
                animationContainer.Image = My.Resources.ma
                FillAnimation()
                keyboard.Hide()

            Case "MB"
                animationContainer.Image = My.Resources.mb_mc
                FillAnimation()
                keyboard.Hide()

            Case "MC"
                animationContainer.Image = My.Resources.mb_mc
                FillAnimation()
                keyboard.Hide()

            Case Else
                result = False

        End Select



        disable_fachgebeite()
        disable_diens()

        Return result
    End Function



    Private Sub browserMenu_ItemClicked(ByVal sender As Object, ByVal e As ToolStripItemClickedEventArgs)

    End Sub

    'Private Sub searchbox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles searchbox.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        searchclick(searchbox.Text)
    '    End If
    'End Sub

    'Private Sub searchbox_TextChanged_1(ByVal sender As Object, ByVal e As EventArgs) Handles searchbox.TextChanged
    '    Me.searchbox.CharacterCasing = CharacterCasing.Upper
    'End Sub

    Private Sub browser_NewWindow(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles browser.CreateWindow

        Dim myelement As HtmlElement = browser.Document.ActiveElement
        Dim target As String = myelement.GetAttribute("href")
        '  Dim newinstance As New WebBrowser
        'newinstance.Show()
        ' e.Cancel = True
        If target.Contains(".pdf") Then
            '  MsgBox("DEBUG line 3145")
            pdfReader.Dock = DockStyle.Fill
            pdfReader.Visible = True
            pdfReader.src = target
            pdfIsactive = True

        Else
            browser.Navigate(target)
        End If
        e.Cancel = True
    End Sub
    ' Private Sub browser_FileDownload(ByVal sender As Object, ByVal e As EventArgs) Handles browser.FileDownload
    '  browser.AllowNavigation = False
    '  MsgBox("AllowNavigation = False")

    '  End Sub

    Private Sub Button1_Click_1(ByVal sender As Object, ByVal e As EventArgs)
        dayOrNightJustChange = True
        If dayOrNight = "night" Then
            dayOrNight = "day"
        Else
            dayOrNight = "night"
        End If
    End Sub

    Private Sub Button2_Click_1(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub


    Private Sub HFUKioskSytem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        animationLabelPanel.Visible = False
        ' Timer2.Start()
        Control.CheckForIllegalCrossThreadCalls = False
        If Not Directory.Exists(Application.StartupPath & "\poster\") Then
            Directory.CreateDirectory(Application.StartupPath & "\poster\")
        End If
        Timer1.Start()

        Fach.Show()
        Diens.Show()
        Signaturen.Show()

        setActiveButton("Home")
        setActiveButton_all("Home")
        buttonClicked = "Home"
        posterImage.Show()
        posterImage.Dock = DockStyle.Fill


        loadingImage.Location = New Point(1080 / 2 - 5, 560)
        loadingImage.Visible = False
        '  searchbox.Location = New Point(75, 561)
        ' searchButton.Location = New Point(389, 561)
        ' keyboard.Location = New Point(0, 1408)


        '------------------diens set font---------------------

        pfc.AddFontFile("Fonts\H\UniversLTW02-67BoldCn.ttf")

        icf.AddFontFile("Fonts\H\UniversLTW02-47LightCn.ttf")

        animationLabel.Font = New Font(pfc.Families(0), 33, FontStyle.Regular)
        animationLabel.ForeColor = Color.White
        animationLabelDes.Font = New Font(icf.Families(0), 30, FontStyle.Bold)
        animationLabelDes.ForeColor = Color.White
        signatureLabel.Font = New Font(pfc.Families(0), 33, FontStyle.Regular)
        signatureLabel.ForeColor = Color.White



        Dim mythread3 = New Thread(AddressOf Me.getDayAndNight)
        mythread3.Start()


        Dim mythread = New Thread(AddressOf Me.getPosterFromDatabase)
        mythread.Start()

        Dim mythread2 = New Thread(AddressOf Me.getNigthPosterFromDatabase)
        mythread2.Start()

        Dim connGetExit = New Thread(AddressOf Me.getExitCode)
        connGetExit.Start()

        hidebuttons()
        Timer3.Start()
    End Sub
    Private Sub HomeButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles HomeButton.Click
        Homebuttonclick = True

    End Sub

    Private Sub FachgebieteButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles FachgebieteButton.Click
        Fachgebieteclick = True

    End Sub

    Private Sub SignaturenButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SignaturenButton.Click
        Signaturenclick = True
    End Sub


    Private Sub DienstleistungenButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DienstleistungenButton.Click
        Dienstleistungenclick = True

    End Sub

    Private Sub OPACButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles OPACButton.Click
        OPACbuttonclick = True

    End Sub
    Private Sub HomeButton_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles HomeButton.MouseDown
        HomeButton.Image = My.Resources.HomeActiveClick
        HomebuttonStateSmall = True
    End Sub
    Private Sub FachgebieteButton_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles FachgebieteButton.MouseDown
        FachgebieteButton.Image = My.Resources.FachgebieteClick
        FachgebietebuttonStateSmall = True
    End Sub

    Private Sub SignaturenButton_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles SignaturenButton.MouseDown
        SignaturenButton.Image = My.Resources.SignaturenClick
        SignaturenbuttonStateSmall = True
    End Sub

    Private Sub DienstleistungenButton_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DienstleistungenButton.MouseDown
        DienstleistungenButton.Image = My.Resources.DienstleistungenClick
        DienstleistungenbuttonStateSmall = True
    End Sub

    Private Sub OPACButton_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles OPACButton.MouseDown
        OPACButton.Image = My.Resources.OPACClick
        OPACbuttonStateSmall = True
    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        '   TextBox1.Text = "HomebuttonXa " & HomebuttonXa & vbNewLine & _
        '   "FachgebieteXa " & FachgebieteXa & vbNewLine & _
        '   "SignaturenXa " & SignaturenXa & vbNewLine & _
        '  "DienstleistungenXa " & DienstleistungenXa & vbNewLine & _
        '  "OPACbuttonXa " & OPACbuttonXa & vbNewLine

        If HomebuttonStateSmall = True Then
            HomebuttonXa += 1

            If HomebuttonXa >= 2 Then
                HomeButton.Image = My.Resources.HomeActive
                HomebuttonStateSmall = False
                HomebuttonXa = 0

                If Homebuttonclick Then
                    setActiveButton("Home")
                    setActiveButton_all("Home")
                    'keyboard.Hide()
                    'animationLabelPanel.Visible = False


                    setActiveForm("Home")

                    NewPoint.Y = 265
                    Diens.diensPanel.Location = NewPoint
                    Homebuttonclick = False
                End If

            End If

        End If
        If FachgebietebuttonStateSmall = True Then
            FachgebieteXa += 1

            If FachgebieteXa >= 2 Then
                FachgebieteButton.Image = My.Resources.Fachgebiete
                FachgebietebuttonStateSmall = False
                FachgebieteXa = 0
                If Fachgebieteclick Then
                    setActiveButton("Fachgebiete")
                    setActiveButton_all("Fachgebiete")
                    'keyboard.Hide()
                    'animationLabelPanel.Visible = False
                    keyboard.Hide()
                    Fach.Show()
                    setActiveForm("Fachgebiete")

                    NewPoint.Y = 265
                    Diens.diensPanel.Location = NewPoint
                    Fachgebieteclick = False
                End If
            End If

        End If
        If SignaturenbuttonStateSmall = True Then
            SignaturenXa += 1

            If SignaturenXa >= 2 Then
                SignaturenButton.Image = My.Resources.Signaturen
                SignaturenbuttonStateSmall = False
                SignaturenXa = 0
                If Signaturenclick Then
                    setActiveButton("Signaturen")
                    setActiveButton_all("Signaturen")
                    ' Signaturen.searchbox.Focus()
                    '  animationLabelPanel.Visible = False
                    Signaturen.Show()
                    '  Me.BringToFront()
                    keyboardform = "Signaturen"
                    setActiveForm("Signaturen")

                    NewPoint.Y = 265
                    Diens.diensPanel.Location = NewPoint

                    Signaturenclick = False
                End If
            End If

        End If
        If DienstleistungenbuttonStateSmall = True Then
            DienstleistungenXa += 1

            If DienstleistungenXa >= 2 Then
                DienstleistungenButton.Image = My.Resources.Dienstleistungen
                DienstleistungenbuttonStateSmall = False
                DienstleistungenXa = 0
                If Dienstleistungenclick Then

                    keyboard.Hide()
                    setActiveButton("Dienstleistungen")
                    setActiveButton_all("Dienstleistungen")
                    '  Dim i = 0.0
                    ' browser.Size = New Size(1, 1)
                    animationLabelPanel.Visible = False
                    Diens.Show()


                    setActiveForm("Dienstleistungen")

                    NewPoint.Y = 265
                    Diens.diensPanel.Location = NewPoint
                    Dienstleistungenclick = False
                End If
            End If

        End If
        If OPACbuttonStateSmall = True Then
            OPACbuttonXa += 1

            If OPACbuttonXa >= 2 Then
                OPACButton.Image = My.Resources.OPAC
                OPACbuttonStateSmall = False
                OPACbuttonXa = 0
                If OPACbuttonclick Then
                    animationLabelPanel.Visible = False
                    'Me.TopMost = True
                    ' keyboard.TopMost = True
                    ' Me.TopMost = False
                    setActiveButton("OPAC")
                    setActiveButton_all("OPAC")
                    'tbAddressBar.Focus()
                    keyboardform = "HFUKioskSytem"
                    setActiveForm("OPAC")
                    'ebook ejournal dbis



                    If BrowserNavigated Then
                        '  MsgBox("BrowserNavigated")
                    Else
                        If resetOPAC Then
                            browser.Navigate(opaclink)
                            resetOPAC = False
                            '      MsgBox("resetOPAC")
                        ElseIf browser.Url.ToString = "about:blank" Then
                            browser.Navigate(opaclink)
                            '    MsgBox("browser.Url.ToString")
                        ElseIf opacHomeLink <> "opac" Then
                            browser.Navigate(opaclink)
                            '    MsgBox("browser.Url.ToString")
                        Else

                        End If
                    End If

                    opacHomeLink = "opac"

                    NewPoint.Y = 265
                    Diens.diensPanel.Location = NewPoint
                    OPACbuttonclick = False
                End If
            End If

        End If


    End Sub

    Private Sub animationLabelPanel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles animationLabelPanel.Click
        ExitActive = True
        ExitCode = ""
    End Sub


    Private Sub animationLabelPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles animationLabelPanel.Paint

    End Sub

    Private Sub animationLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles animationLabel.Click
        ExitActive = True
        ExitCode = ""
    End Sub

    Private Sub signatureLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles signatureLabel.Click
        ExitActive = True
        ExitCode = ""
    End Sub

    Private Sub animationLabelDes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles animationLabelDes.Click
        ExitActive = True
        ExitCode = ""
    End Sub

    Private Sub posterImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles posterImage.Click
        If dayOrNight = "night" Then
            showbuttons()
            imageSetNum = batchCounts
            closeButChange = True
            closeButChangetime = 1
            dayOrNight = "day"
        End If
    End Sub

    Private Sub posterCloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles posterCloseButton.Click
        If dayOrNight = "night" Then
            showbuttons()
            imageSetNum = batchCounts
            closeButChange = True
            closeButChangetime = 1
            dayOrNight = "day"
        End If
    End Sub

End Class
