Public Class TTO
    Dim player As String = "x"
    Dim EndCheck As String = ""


    Private Sub Button_Click(sender As Button, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click
        sender.Text = player
        Dim checkwin As Integer = checkWin1()
        If checkwin <> 0 Then
            If checkwin = 1 Or checkwin = -1 Then
                MsgBox(player)
            ElseIf checkwin = 10 Then
                MsgBox("Draw")
            End If
        End If
        changePlayer()
        Dim newboard As New TTO
        newboard = copy(Me)
        For Each Btn As Button In newboard.Panel1.Controls


        Next
        MsgBox(ai(0, newboard) & "wefweaawg")
    End Sub

    Private Sub changePlayer()
        If player = "x" Then
            player = "o"
        Else
            player = "x"
        End If
    End Sub

    Private Function checkWin1() As Integer
        If (Button1.Text = player And Button2.Text = player And Button3.Text = player) Or (Button4.Text = player And Button5.Text = player And Button6.Text = player) Or (Button7.Text = player And Button8.Text = player And Button9.Text = player) Or (Button1.Text = player And Button4.Text = player And Button7.Text = player) Or (Button2.Text = player And Button5.Text = player And Button8.Text = player) Or (Button3.Text = player And Button6.Text = player And Button9.Text = player) Or (Button1.Text = player And Button5.Text = player And Button9.Text = player) Or (Button3.Text = player And Button5.Text = player And Button7.Text = player) Then
            If player = "x" Then
                Return 1
            Else
                Return -1
            End If
        Else
            Dim count As Integer = 0
            For Each btn As Button In Panel1.Controls
                If btn.Text <> "" Then
                    count += 1
                End If
            Next
            If count = 9 Then
                Return 10
            End If
        End If
        Return 0
    End Function


    Private Function ai(level As Integer, board As TTO)
        For Each Btn As Button In board.Panel1.Controls
            If Btn.Text = Nothing Then
                Btn.Text = board.player
                Dim checkwin As Integer = board.checkWin1()
                If checkwin = 1 Then
                    Return 1
                ElseIf checkwin = -1 Then
                    Return -1
                Else
                    board.changePlayer()
                    Dim newboard As New TTO
                    newboard = copy(board)
                    ai(level + 1, newboard)
                End If
            End If
        Next
    End Function

    'Public Sub viewBoard()
    '    rows = {"", "", ""}
    '    Dim board As String = ""
    '    For i As Integer = 0 To 8
    '        For Each Btn As Button In Panel1.Controls
    '            If Btn.TabIndex = i Then
    '                If Btn.Text <> Nothing Then
    '                    board += Btn.Text
    '                Else
    '                    board += "."
    '                End If
    '            End If
    '        Next
    '    Next
    '    Dim count As Integer = 0
    '    While board <> Nothing
    '        rows(count) += board(0)
    '        rows(count) += board(1)
    '        rows(count) += board(2)
    '        board = board.Remove(0, 3)
    '        count += 1
    '    End While
    '    'MsgBox(rows(0) & vbCrLf & rows(1) & vbCrLf & rows(2))
    '    Console.Write(rows(0) & vbCrLf & rows(1) & vbCrLf & rows(2) & vbCrLf)
    'End Sub

    Public Function copy(old As TTO) As TTO
        Dim newb As New TTO
        newb.player = old.player
        For Each Btn As Button In newb.Panel1.Controls
            For Each Btn2 As Button In old.Panel1.Controls
                If Btn.Name = Btn2.Name Then
                    Btn.Text = Btn2.Text
                    Exit For
                End If
            Next
        Next
        Return newb
    End Function

    'Public Sub playBtn(btnP As Button)
    '    If btnP.Text <> "Restart" And ((Button1.Text = player And Button2.Text = player And Button3.Text = player) Or (Button4.Text = player And Button5.Text = player And Button6.Text = player) Or (Button7.Text = player And Button8.Text = player And Button9.Text = player) Or (Button1.Text = player And Button4.Text = player And Button7.Text = player) Or (Button2.Text = player And Button5.Text = player And Button8.Text = player) Or (Button3.Text = player And Button6.Text = player And Button9.Text = player) Or (Button1.Text = player And Button5.Text = player And Button9.Text = player) Or (Button3.Text = player And Button5.Text = player And Button7.Text = player)) Then Exit Sub 'Else If btnP.Text = Nothing Then If player = "x" Then player = "o" Else player = "x"
    '    For Each Btn As Button In Panel1.Controls
    '        If Btn.Name = Button6.Name And ((Button1.Text = player And Button2.Text = player And Button3.Text = player) Or (Button4.Text = player And Button5.Text = player And Button6.Text = player) Or (Button7.Text = player And Button8.Text = player And Button9.Text = player) Or (Button1.Text = player And Button4.Text = player And Button7.Text = player) Or (Button2.Text = player And Button5.Text = player And Button8.Text = player) Or (Button3.Text = player And Button6.Text = player And Button9.Text = player) Or (Button1.Text = player And Button5.Text = player And Button9.Text = player) Or (Button3.Text = player And Button5.Text = player And Button7.Text = player)) Then winner = player Else If btnP.Text = Nothing Then btnP.Text = player Else If btnP.Name.Contains("Restart") Then If Not Btn.Text.Contains("Restart") Then Btn.Text = Nothing Else If btnP.Name.Contains("Restart") Then player = "o"
    '    Next
    '    Dim count As Integer = 0
    '    For Each btn As Button In Panel1.Controls
    '        If btn.Text <> "Restart" And btn.Text <> "" Then
    '            count += 1
    '        End If
    '    Next
    '    If count = 9 And winner = Nothing Then
    '        winner = "Draw"
    '    End If
    '    'If winner = Nothing Then
    '    '    If player = "x" Then
    '    '        startAI("o")
    '    '    Else
    '    '        startAI("x")
    '    '    End If

    '    'End If
    'End Sub



    Private Sub btnRestart_Click(sender As Object, e As EventArgs) Handles btnRestart.Click
        player = "x"
        For Each btn As Button In Panel1.Controls
            btn.Text = Nothing
        Next
    End Sub
End Class