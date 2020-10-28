Public Class Form1
    Private Sub btnENCRYPT_Click(sender As Object, e As EventArgs) Handles btnENCRYPT.Click
        Dim key As Integer
        Dim num As Integer
        Dim num2 As Integer
        Dim output As String = String.Empty
        key = 20
        For Each ch As Char In TextBox1.Text
            ch = Char.ToUpper(ch)
            If Not Char.IsLetter(ch) Then
                output = output + ch
            Else
                num = Convert.ToInt32(ch)
                num2 = num + key
                While num2 > 90
                    num2 = num2 - 26
                End While
                output = output + Convert.ToChar(num2)
            End If
        Next
        TextBox1.Text = output
    End Sub

    Private Sub btnDECRYPT_Click(sender As Object, e As EventArgs) Handles btnDECRYPT.Click
        Dim key As Integer
        Dim num As Integer
        Dim num2 As Integer
        Dim output As String = String.Empty
        key = 20
        For Each ch As Char In TextBox1.Text
            ch = Char.ToUpper(ch)
            If Not Char.IsLetter(ch) Then
                output = output + ch
            Else
                num = Convert.ToInt32(ch)
                num2 = num - key
                While num2 < 65
                    num2 = num2 + 26
                End While
                output = output + Convert.ToChar(num2)
            End If
        Next
        TextBox1.Text = output
    End Sub
End Class
