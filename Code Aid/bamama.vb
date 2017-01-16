Public Class bamama
    Dim bamama As Boolean = True
    Dim increment As Integer = 0
    Dim rnd As New System.Random

    Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles Timer5.Tick
        If bamama = True Then
            Me.BackgroundImage = PictureBox1.Image
            bamama = False
        Else
            Me.BackgroundImage = PictureBox2.Image
            bamama = True
        End If
        If Timer5.Interval <= 100 Then
            increment = rnd.Next(0, 99)
        End If
        If Timer5.Interval >= 500 Then
            increment = rnd.Next(-100, -1)
        End If
        Timer5.Interval += increment
    End Sub

End Class