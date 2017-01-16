Public Class G
    Dim speed As Integer = 10
    Dim bspeedh As Integer = 7
    Dim bspeedh2 As Integer = bspeedh * -1
    Dim bspeedv As Integer = 4
    Dim curr As System.Drawing.Point
    Dim curr1 As System.Drawing.Point
    Dim curr2 As System.Drawing.Point
    Dim count1 As Integer = 0
    Dim count2 As Integer = 0
    Dim check As Integer = 1
    Dim cpu As Boolean = False
    Dim cpu2 As Boolean = False
    Dim pause As Boolean = False
    'Dim mouse As Boolean = False
    Dim invis As Boolean = False

    Private Sub form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim handeled As Boolean = False
        Select Case e.KeyCode
            Case Keys.Up
                curr.X = ButtonR.Location.X
                curr.Y = ButtonR.Location.Y - speed
                ButtonR.Location = curr
                e.Handled = True
            Case Keys.Down
                curr.X = ButtonR.Location.X
                curr.Y = ButtonR.Location.Y + speed
                ButtonR.Location = curr
                e.Handled = True
            Case Keys.W
                curr1.X = ButtonL.Location.X
                curr1.Y = ButtonL.Location.Y - speed
                ButtonL.Location = curr1
                e.Handled = True
            Case Keys.S
                curr1.X = ButtonL.Location.X
                curr1.Y = ButtonL.Location.Y + speed
                ButtonL.Location = curr1
                e.Handled = True
            Case Keys.C
                If cpu = False Then
                    cpu = True
                    Timer2.Enabled = True
                Else
                    Timer2.Enabled = False
                    cpu = False
                End If
                e.Handled = True
            Case Keys.R
                count1 = 0
                count2 = 0
                Label1.Text = 0
                Label3.Text = 0
                e.Handled = True
            Case Keys.P
                If pause = False Then
                    pause = True
                    Timer1.Enabled = False
                Else
                    Timer1.Enabled = True
                    pause = False
                End If
                e.Handled = True
            Case Keys.D
                If cpu2 = False Then
                    cpu2 = True
                    'mouse = False
                Else
                    cpu2 = False
                    'mouse = False
                End If
                e.Handled = True
            Case Keys.Space
                count1 = 0
                count2 = 0
                Label1.Text = 0
                Label3.Text = 0
                Dim center As System.Drawing.Point
                center.X = 486
                center.Y = 188
                Ball.Location = center
                e.Handled = True
                'Case Keys.M
                '    If mouse = False Then
                '        mouse = True
                '        cpu2 = False
                '    Else
                '        mouse = False
                '        cpu2 = False
                '    End If
                '    e.Handled = True
            Case Keys.Right
                If invis = False Then
                    invis = True
                    Ball.Visible = False
                    ButtonL.Visible = False
                    ButtonR.Visible = False
                    VScrollBar1.Visible = False
                    VScrollBar3.Visible = False
                    Label1.Visible = False
                    Label2.Visible = False
                    Label3.Visible = False
                    Timer1.Enabled = False
                Else
                    invis = False
                    Ball.Visible = True
                    ButtonL.Visible = True
                    ButtonR.Visible = True
                    VScrollBar1.Visible = True
                    VScrollBar3.Visible = True
                    Label1.Visible = True
                    Label2.Visible = True
                    Label3.Visible = True
                    Timer1.Enabled = True
                End If
                e.Handled = True
        End Select
        If e.Handled = False Then
            Me.Close()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        curr2.X = Ball.Location.X + bspeedh
        curr2.Y = Ball.Location.Y + bspeedv
        Ball.Location = curr2
        If Ball.Location.X < 0 Then
            bspeedh = bspeedh * -1
            count1 = count1 + 1
            Label3.Text = count1
        End If
        If Ball.Location.X > Me.Size.Width - 20 Then
            bspeedh = bspeedh2
            count2 = count2 + 1
            Label1.Text = count2
        End If
        If (Ball.Location.Y > ButtonR.Location.Y - 10 And Ball.Location.X > ButtonR.Location.X - 10) And (Ball.Location.Y < ButtonR.Location.Y + ButtonR.Size.Height And Ball.Location.X > ButtonR.Location.X - 10) Then
            bspeedh = bspeedh * -1
            bspeedv = CInt(Math.Ceiling(Rnd() * 4))
            If check = 1 Then
                bspeedv = bspeedv * -1
            End If
        End If
        If (Ball.Location.Y > ButtonL.Location.Y - 10 And Ball.Location.X < ButtonL.Location.X + 10) And (Ball.Location.Y < ButtonL.Location.Y + ButtonL.Size.Height And Ball.Location.X < ButtonL.Location.X + 10) Then
            bspeedh = bspeedh * -1
            bspeedv = CInt(Math.Ceiling(Rnd() * 4))
            If check = 1 Then
                bspeedv = bspeedv * -1
            End If
        End If

        If Ball.Location.Y < 0 Or Ball.Location.Y > Me.Size.Height - 45 Then
            bspeedv = bspeedv * -1
            check = check * -1
        End If
        If cpu2 = True Then
            curr.X = ButtonR.Location.X
            curr.Y = Cursor.Position.Y - 200
            ButtonR.Location = curr
            curr1.X = ButtonL.Location.X
            curr1.Y = Ball.Location.Y - 10
            ButtonL.Location = curr1
        End If
        'If mouse = True Then
        '    Dim ontop As System.Drawing.Point
        '    ontop.X = Ball.Location.X + 25
        '    ontop.Y = Ball.Location.Y + 143
        '    Cursor.Position = ontop
        'End If
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        If cpu = True Then
            If ButtonL.Location.Y < Ball.Location.Y - 10 Then
                curr1.X = ButtonL.Location.X
                curr1.Y = ButtonL.Location.Y + 3
            ElseIf ButtonL.Location.Y > Ball.Location.Y - 10 Then
                curr1.X = ButtonL.Location.X
                curr1.Y = ButtonL.Location.Y - 3
            End If
            ButtonL.Location = curr1
        End If
    End Sub

    Private Sub Form1_Click(sender As Object, e As System.EventArgs) Handles Me.Click
        Me.Close()
    End Sub

    'Private Sub Form1_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) ' Handles Me.MouseMove
    '    If cpu2 = False And mouse = False Then
    '        Me.Close()
    '    End If
    'End Sub

End Class
