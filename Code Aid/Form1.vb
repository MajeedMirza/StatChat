
Public Class CodeAid

    Dim special As String = ""
    Dim spaces As String = ""
    Dim countBy As Integer = 1
    Dim countBy2 As Integer = 1
    Dim countBy3 As Integer = 1
    Dim loops As Integer = 1
    Dim counter As String = "-i-"
    Dim counter2 As String = "-j-"
    Dim counter3 As String = "-k-"
    Dim break As String = "-b-"
    Dim result As String = ""
    Dim startfrom As Integer = 0
    Dim startfrom2 As Integer = 0
    Dim startfrom3 As Integer = 0
    Dim cap As Integer
    Dim cap2 As Integer
    Dim cap3 As Integer

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        Try
            If txtCap.Text <> "" Then
                cap = txtCap.Text
            End If
            If txtCap2.Text <> "" Then
                cap2 = txtCap2.Text
            End If
            If txtCap3.Text <> "" Then
                cap3 = txtCap3.Text
            End If
            startfrom = txtStart.Text
            startfrom2 = txtStart2.Text
            startfrom3 = txtStart3.Text
            loops = txtLoops.Text
            countBy = txtCountby.Text
            countBy2 = txtCountby2.Text
            countBy3 = txtCountby3.Text
        Catch ex As Exception
            MessageBox.Show("Please enter valid values.")
            txtStart.Text = 0
            txtStart2.Text = 0
            txtStart3.Text = 0
            txtLoops.Text = 1
            txtCountby.Text = 1
            txtCountby2.Text = 1
            txtCountby3.Text = 1
            txtCap.Text = ""
            txtCap2.Text = ""
            txtCap3.Text = ""
        End Try

        If chkOther.Checked = True Then
            special = txtOther.Text
        ElseIf chkCommas.Checked = True Then
            special = ","
        Else
            special = ""
        End If
        If chkSpace.Checked = True Then
            spaces = " "
        Else
            spaces = ""
        End If
        Dim j As Integer = startfrom
        Dim j2 As Integer = startfrom2
        Dim j3 As Integer = startfrom3
        For i As Integer = 0 To loops
            result += txtText.Text & special & spaces
            If result.Contains(counter) Then
                result = result.Replace(counter, j)
                j += countBy
            End If
            If result.Contains(counter2) Then
                result = result.Replace(counter2, j2)
                j2 += countBy2
            End If
            If result.Contains(counter3) Then
                result = result.Replace(counter3, j3)
                j3 += countBy3
            End If
            If result.Contains(break) Then
                result = result.Replace(break, vbCrLf)
            End If
            If chkLine.Checked = True Then
                result += vbCrLf
            End If
            If txtCap.Text <> "" Then
                If j > cap Then
                    j = startfrom
                End If
            End If
            If txtCap2.Text <> "" Then
                If j2 > cap2 Then
                    j2 = startfrom2
                End If
            End If
            If txtCap3.Text <> "" Then
                If j3 > cap3 Then
                    j3 = startfrom3
                End If
            End If
        Next
        rtbResult.Text = result
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        rtbResult.Text = Nothing
        result = Nothing
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtStart.Text = 0
        txtStart2.Text = 0
        txtStart3.Text = 0
        txtLoops.Text = 1
        txtCountby.Text = 1
        txtCountby2.Text = 1
        txtCountby3.Text = 1
        txtCap.Text = ""
        txtCap2.Text = ""
        txtCap3.Text = ""
    End Sub

    Private Sub btnChat_Click(sender As Object, e As EventArgs) Handles btnChat.Click
        Dim chat As New Form2
        chat.ShowDialog()
        chat.closethis()
    End Sub
End Class
