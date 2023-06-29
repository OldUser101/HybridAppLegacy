Imports System.IO
Imports System.Net
Public Class Main
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Public Sub LoadData()
        Dim webInfo As String() = File.ReadAllLines(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "webInfo.txt"))
        If webInfo(0) = "NULL" Then
            MessageBox.Show("HybridApp is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End If
        Me.Text = webInfo(0)
        WebView21.Source = New Uri(webInfo(1))

        Try
            Me.Icon = IconFromImage(Image.FromFile(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "favicon", "0.png")))
        Catch ex As Exception
            MessageBox.Show("Failed to load application resources. Please create this Web App again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'End If
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

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        My.Settings.windowState = Me.WindowState
        My.Settings.Save()
    End Sub
End Class
