﻿Public Class Form3
    Private Sub Button_Click(sender As Button, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click, btnRestart.Click
        If sender.Text <> "Restart" And ((Button1.Text = Me.Name And Button2.Text = Me.Name And Button3.Text = Me.Name) Or (Button4.Text = Me.Name And Button5.Text = Me.Name And Button6.Text = Me.Name) Or (Button7.Text = Me.Name And Button8.Text = Me.Name And Button9.Text = Me.Name) Or (Button1.Text = Me.Name And Button4.Text = Me.Name And Button7.Text = Me.Name) Or (Button2.Text = Me.Name And Button5.Text = Me.Name And Button8.Text = Me.Name) Or (Button3.Text = Me.Name And Button6.Text = Me.Name And Button9.Text = Me.Name) Or (Button1.Text = Me.Name And Button5.Text = Me.Name And Button9.Text = Me.Name) Or (Button3.Text = Me.Name And Button5.Text = Me.Name And Button7.Text = Me.Name)) Then Exit Sub Else If sender.Text = Nothing Then If Me.Name = "x" Then Me.Name = "o" Else Me.Name = "x"
        For Each Btn As Button In Panel1.Controls
            If Btn.Name = Button6.Name And ((Button1.Text = Me.Name And Button2.Text = Me.Name And Button3.Text = Me.Name) Or (Button4.Text = Me.Name And Button5.Text = Me.Name And Button6.Text = Me.Name) Or (Button7.Text = Me.Name And Button8.Text = Me.Name And Button9.Text = Me.Name) Or (Button1.Text = Me.Name And Button4.Text = Me.Name And Button7.Text = Me.Name) Or (Button2.Text = Me.Name And Button5.Text = Me.Name And Button8.Text = Me.Name) Or (Button3.Text = Me.Name And Button6.Text = Me.Name And Button9.Text = Me.Name) Or (Button1.Text = Me.Name And Button5.Text = Me.Name And Button9.Text = Me.Name) Or (Button3.Text = Me.Name And Button5.Text = Me.Name And Button7.Text = Me.Name)) Then MsgBox(Me.Name & " WINS") Else If sender.Text = Nothing Then sender.Text = Me.Name Else If sender.Name.Contains("Restart") Then If Not Btn.Text.Contains("Restart") Then Btn.Text = Nothing Else If sender.Name.Contains("Restart") Then Me.Name = "o"
        Next
    End Sub
End Class