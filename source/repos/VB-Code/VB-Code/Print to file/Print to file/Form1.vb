Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fileDialog As New Windows.Forms.SaveFileDialog
        Dim fileToSave As String
        fileDialog.Title = "Save to PostScript file"
        fileDialog.AddExtension = True
        fileDialog.Filter = "Encapsulated PostScript (*.eps)|"
        fileDialog.InitialDirectory =
          My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData
        fileDialog.ShowDialog()
        fileToSave = fileDialog.FileName & ".eps"
        PrintForm1.PrintFileName = filePath
    End Sub
End Class
