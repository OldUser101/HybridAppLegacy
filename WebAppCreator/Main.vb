Imports System.IO     ' Import these for file handling and compression purposes
Imports System.IO.Compression
Public Class Main
    Dim createDesktopShortcut As Boolean       ' Create variables for the Background Worker
    Dim createStartMenuShortcut As Boolean
    Dim appName As String
    Dim webAddress As String

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        End    ' Exit the program when the close button is pressed
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        txtAppName.Enabled = False       ' Disable most components while creating HybridApp
        txtWebAddress.Enabled = False
        chkStartShortcut.Enabled = False
        chkDesktopShortcut.Enabled = False
        lblAppName.Enabled = False
        lblWebAddress.Enabled = False
        btnCreate.Enabled = False
        btnClose.Enabled = False

        createDesktopShortcut = chkDesktopShortcut.Checked      ' Assign values for use by the Background Worker
        createStartMenuShortcut = chkStartShortcut.Checked
        appName = txtAppName.Text
        webAddress = txtWebAddress.Text

        worker.RunWorkerAsync()    ' Start the Background Worker
    End Sub

    Private Sub CreateShortcut(ByVal TargetPath As String, ByVal ShortcutPath As String, ByVal IconPath As String)
        Dim oShell As Object    ' Create objects for interfacing with the Windows shell
        Dim oLink As Object
        Try
            oShell = CreateObject("WScript.Shell")       ' Create a shortcut with the specified path, name, and icon
            oLink = oShell.CreateShortcut(ShortcutPath)
            oLink.TargetPath = TargetPath
            oLink.WindowStyle = 1
            oLink.IconLocation = IconPath
            oLink.Save()
        Catch ex As Exception
            MsgBox(ex.Message)     ' If it cannot create the shortcut, a message is displayed
            MessageBox.Show("Unable to create shortcut.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' --------------------------------------------------------------------------------------------------------------------------------------
    ' Credits to Hans Passant - https://stackoverflow.com/questions/21387391/how-to-convert-an-image-to-an-icon-without-losing-transparency/
    '---------------------------------------------------------------------------------------------------------------------------------------
    Public Shared Function IconFromImage(ByVal img As Image) As Icon
        Dim ms = New MemoryStream()
        Dim bw = New BinaryWriter(ms)
        ' Header
        bw.Write(CShort(0))   ' 0 : reserved
        bw.Write(CShort(1))   ' 2 : 1=ico, 2=cur
        bw.Write(CShort(1))   ' 4 : number of images
        ' Image directory
        Dim w = img.Width
        If w >= 256 Then w = 0
        bw.Write(CByte(w))    ' 0 : width of image
        Dim h = img.Height
        If h >= 256 Then h = 0
        bw.Write(CByte(h))    ' 1 : height of image
        bw.Write(CByte(0))    ' 2 : number of colors in palette
        bw.Write(CByte(0))    ' 3 : reserved
        bw.Write(CShort(0))   ' 4 : number of color planes
        bw.Write(CShort(0))   ' 6 : bits per pixel
        Dim sizeHere = ms.Position
        bw.Write(0)     ' 8 : image size
        Dim start = CInt(ms.Position) + 4
        bw.Write(start)      ' 12: offset of image data
        ' Image data
        img.Save(ms, Drawing.Imaging.ImageFormat.Png)
        Dim imageSize = CInt(ms.Position) - start
        ms.Seek(sizeHere, SeekOrigin.Begin)
        bw.Write(imageSize)
        ms.Seek(0, SeekOrigin.Begin)

        ' And load it
        Return New Icon(ms)
    End Function

    Private Sub worker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles worker.DoWork

        worker.ReportProgress(1)     ' Report a status of one to the main thread

        If Not IO.File.Exists(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "WebAppPackage.zip")) Then      ' Check if 'WebAppPackage.zip' exists. If not, warn the user
            MessageBox.Show("WebAppPackage.zip was not found. Please re-install HybridApp Creator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End If

        Dim programPath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), appName)     ' Create the directory for the HybridApp to be placed in
        If Not Directory.Exists(programPath) Then
            Directory.CreateDirectory(programPath)
        Else
            Directory.Delete(programPath, True)
            Directory.CreateDirectory(programPath)
        End If

        worker.ReportProgress(2)      ' Report a status of two to the main thread

        Dim za As ZipArchive = ZipFile.OpenRead(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "WebAppPackage.zip"))     ' Open the zip archive
        For Each entry As ZipArchiveEntry In za.Entries
            Dim destinationPath As String = Path.GetFullPath(Path.Combine(programPath, entry.FullName))
            If destinationPath.StartsWith(programPath, StringComparison.Ordinal) Then
                Directory.CreateDirectory(Path.GetDirectoryName(destinationPath))      ' ZipArchive does not handle directories, so create them when needed
                Try
                    entry.ExtractToFile(destinationPath)      ' Extract the target file
                Catch ex As Exception
                    Continue For
                End Try
            End If
        Next

        worker.ReportProgress(3)      ' Report a status of three to the main thread

        Directory.CreateDirectory(Path.Combine(programPath, "favicon"))     ' Create a directory to store the favicon of the website. This will become the program icon
        Dim client = New Net.WebClient()
        Dim webSiteDomain = webAddress
        Dim googleService = New Uri("https://www.google.com/s2/favicons?sz=128&domain=" & webSiteDomain)
        client.DownloadFile(googleService, Path.Combine(programPath, "favicon", "0.png"))               ' Download the favicon from Google's service
        client.Dispose()

        worker.ReportProgress(4)       ' Report a status of four to the main thread

        Dim ico As Icon = IconFromImage(Image.FromFile(Path.Combine(programPath, "favicon", "0.png")))      ' Convert the .png file to a .ico file for use on the shortcut
        Dim fs As New FileStream(Path.Combine(programPath, "favicon", "0.ico"), FileMode.Create)
        ico.Save(fs)
        fs.Close()

        worker.ReportProgress(5)        ' Report a status of five to the main thread

        If Not IO.File.Exists(Path.Combine(programPath, "webInfo.txt")) Then         ' Checks for the file 'webInfo.txt'. This contains information such as the title and URL fo the website to run
            MessageBox.Show("WebAppPackage.zip is corrupt. Please re-install HybridApp Creator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End If

        Dim webInfo As New List(Of String)     ' Add the website name and URL to a list
        webInfo.Add(appName)
        webInfo.Add(webAddress)

        IO.File.Delete(Path.Combine(programPath, "webInfo.txt"))    ' Delete any existing files and write the contents of the list into a new one
        IO.File.WriteAllLines(Path.Combine(programPath, "webInfo.txt"), webInfo)

        worker.ReportProgress(6)        ' Report a status of six to the main thread

        Try
            IO.File.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu), "Programs\", appName + ".lnk"))     ' Delete any existing shortcuts to the application
            IO.File.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), appName + ".lnk"))
        Catch ex As Exception
            ' v1.0.1 We should really do something here.
        End Try

        If createStartMenuShortcut Then    ' Create the start menu shortcut if the user has asked for it
            CreateShortcut(Path.Combine(programPath, "WebApp.exe"), Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu), "Programs", appName + ".lnk"), Path.Combine(programPath, "favicon", "0.ico"))
        End If

        If createDesktopShortcut Then      ' Create the desktop shortcut if the user has asked for it
            CreateShortcut(Path.Combine(programPath, "WebApp.exe"), Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), appName + ".lnk"), Path.Combine(programPath, "favicon", "0.ico"))
        End If

        worker.ReportProgress(7)     ' Report a status of seven to the main program

    End Sub

    Private Sub worker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles worker.RunWorkerCompleted
        txtAppName.Enabled = True       ' Enable all the components when complete
        txtWebAddress.Enabled = True
        chkStartShortcut.Enabled = True
        chkDesktopShortcut.Enabled = True
        lblAppName.Enabled = True
        lblWebAddress.Enabled = True
        btnCreate.Enabled = True
        btnClose.Enabled = True
        txtAppName.Text = ""       ' Reset the values to their defaults
        txtWebAddress.Text = ""
        pbProgress.Value = 0
        lblStatus.Text = "Status: Restarting..."
        My.Settings.creationComplete = True    ' Set the value for a 'completed' message when the application restarts
        My.Settings.Save()
        Application.Restart()     ' Restart the application to close any open file handles
    End Sub

    Private Sub worker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles worker.ProgressChanged
        ' Processes status messages sent from the Background Worker
        ' Status 1: Checking for 'WebAppPackage.zip' and creating directories
        ' Status 2: Extracting critical files from 'WebAppPackage.zip' into the target directory
        ' Status 3: Downloading the favicon of the website
        ' Status 4: Converting the .png file to a .ico file to be used on the shortcut
        ' Status 5: Modifying 'webInfo.txt' to include application information
        ' Status 6: Creating start menu and desktop shortcuts if needed
        ' Status 7: Creation of HybridApp is complete
        If e.ProgressPercentage = 1 Then
            pbProgress.Value = 14
            lblStatus.Text = "Status: Processing..."
        ElseIf e.ProgressPercentage = 2 Then
            pbProgress.Value = 28
            lblStatus.Text = "Status: Extracting files..."
        ElseIf e.ProgressPercentage = 3 Then
            pbProgress.Value = 42
            lblStatus.Text = "Status: Downloading..."
        ElseIf e.ProgressPercentage = 4 Then
            pbProgress.Value = 56
            lblStatus.Text = "Status: Processing..."
        ElseIf e.ProgressPercentage = 5 Then
            pbProgress.Value = 70
            lblStatus.Text = "Status: Updating settings..."
        ElseIf e.ProgressPercentage = 6 Then
            pbProgress.Value = 84
            lblStatus.Text = "Status: Creating shortcuts..."
        ElseIf e.ProgressPercentage = 7 Then
            pbProgress.Value = 98
            lblStatus.Text = "Status: Done"
        End If
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.creationComplete Then     ' If the value was set to true, a HybridApp has just been created. Display a message to the user to inform them
            MessageBox.Show("HybridApp was created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            My.Settings.creationComplete = False     ' Un-set this value after to prevent it from displaying a message when a HybridApp has not been created
            My.Settings.Save()
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("notepad.exe", Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "LICENSE.txt"))     ' Start 'notepad.exe' to display the program license agreement
    End Sub

    Private Sub Panel1_Click(sender As Object, e As EventArgs) Handles Panel1.Click
        ' Commented out the old message. But kept it because why not. This is the final version anyway.
        ' MessageBox.Show(System.Text.Encoding.ASCII.GetString(GetBytes(Strings.StrReverse("C6C6967402E616864716E40233230323029234820247867696279707F634"))), "IMPORTANT!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        ' EXERCISE FOR THE READER: Figure out how to encode one of these strings. If you do not have the VS designer, figure out how this code is called as well.
        MessageBox.Show(System.Text.Encoding.ASCII.GetString(GetBytes(Strings.StrReverse("92A3021297164602563696E6021602566716840202020202020202A01303132756375546C6F4F2D6F636E2265786479676F2F2A337074747860202A0E23796864702564616D60294029786770277F6E6B6024772E6F6460294020202A0C6C6967402E616864716E40253230323D233230323029234820247867696279707F634A013E203E2136702929736167656C482020707144696272697840202020202"))), "IMPORTANT!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    End Sub

    ' Retrives a byte array from a hexadecimal string
    Private Function GetBytes(s As String)
        Dim nBytes = s.Length \ 2
        Dim a(nBytes - 1) As Byte
        For i = 0 To nBytes - 1
            a(i) = Convert.ToByte(s.Substring(i * 2, 2), 16)
        Next
        Return a
    End Function
End Class
