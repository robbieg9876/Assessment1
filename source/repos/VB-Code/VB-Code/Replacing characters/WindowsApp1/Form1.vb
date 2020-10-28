Public Class Form1
    Dim word As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        word = TextBox1.Text
        word = word.Replace("£"c, " "c)
        TextBox1.Text = word
    End Sub
End Class
