Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Visible = True
        Me.Visible = False
        AxWindowsMediaPlayer2.Ctlcontrols.stop()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        AxWindowsMediaPlayer2.URL = videofile
        AxWindowsMediaPlayer2.Ctlcontrols.play()
    End Sub
End Class