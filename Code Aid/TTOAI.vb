'Public Class TTOAI
'    Dim main As New TTO
'    Public score As Integer = 0
'    Public wins As Integer = 0
'    Public losses As Integer = 0
'    Public draws As Integer = 0
'    Public counting As Integer = 0
'    Public Sub New(orig As TTO)
'        main = copy(orig)
'        ' MsgBox(main.player)
'        If main.player = "x" Then
'            ttop(0, main, "o")
'        Else
'            ttop(0, main, "x")
'        End If
'        'testing(main)
'        'MsgBox(counting)
'    End Sub
'    Public Function ttop(level As Integer, board As TTO, player As String) As Integer
'        Dim newboard As New TTO
'        newboard = copy(board)
'        newboard.player = player
'        'testing(newboard)
'        'For Each btn As Button In newboard.Panel1.Controls
'        '    If btn.Text = Nothing Then
'        '        newboard.playBtn(btn)

'        If newboard.winner <> Nothing Then
'            'newboard.ailogic2()

'            Return 0
'        Else
'            If player = "x" Then
'                'newboard.startAI("o")
'            Else
'                'newboard.startAI("x")
'            End If
'            'If level Mod 2 = 0 Then
'            '    player = "o"
'            'Else
'            '    player = "x"
'            'End If
'            'testing(board)
'            'testing(newboard)
'            'ttop(level + 1, newboard, player)
'        End If
'        'btn.Text = Nothing
'        ''Exit For
'        '    End If
'        'Next
'        Return 0
'    End Function

'    Private Sub ailogic1(newboard As TTO)
'        If newboard.winner = "x" Then
'            losses += 1
'            If losses > wins Then
'                score -= 2
'            Else
'                score -= 1
'            End If
'        End If
'        If newboard.winner = "o" Then
'            wins += 1
'            If wins >= draws Then
'                score += 2
'            Else
'                score += 1
'            End If
'        End If
'        If newboard.winner = "Draw" Then
'            draws += 1
'            If draws > wins Then
'                score += 2
'            ElseIf wins > draws Then
'                score += 1
'            End If
'        End If
'    End Sub

'    Private Sub ailogic2(newboard As TTO)

'        If newboard.winner = "x" Then
'            losses += 1
'            'score -= 1
'        End If
'        If newboard.winner = "o" Then
'            wins += 1
'            score += 1
'        End If
'        If newboard.winner = "Draw" Then
'            draws += 1
'            'score += 1
'        End If
'        testing(newboard)
'    End Sub


'    Public Function copy(old As TTO) As TTO
'        Dim newb As New TTO
'        newb.player = old.player
'        newb.winner = old.winner
'        For Each Btn As Button In newb.Panel1.Controls
'            For Each Btn2 As Button In old.Panel1.Controls
'                If Btn.Name = Btn2.Name Then
'                    Btn.Text = Btn2.Text
'                    Exit For
'                End If
'            Next
'        Next
'        Return newb
'    End Function

'    Private Sub testing(board As TTO)
'        board.viewBoard()
'        Console.Write("Wins: " & wins & " Losses: " & losses & " Draws: " & draws & " Score: " & score & vbCrLf)
'    End Sub
'End Class
