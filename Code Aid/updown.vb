Imports System.Runtime.InteropServices
Public Class Form1
    Dim curr As System.Drawing.Point
    Dim checkpos As System.Drawing.Point = Cursor.Position

    Dim speedR As Integer = speed
    Dim speedL As Integer = speed
    Dim speedU As Integer = speed
    Dim speedD As Integer = speed

    Dim right1 As Boolean = False
    Dim left1 As Boolean = False
    Dim up1 As Boolean = False
    Dim down1 As Boolean = False
    Dim enter1 As Boolean = False

    Dim tickcount As Integer = 0
    Dim counte As Integer = 0

    Dim accrate As Integer = 10
    Dim speed As Integer = 3
    Dim acc As Double = 2

    <DllImport("user32.dll")> Private Shared Sub mouse_event(dwflags As UInteger, dx As UInteger, dy As UInteger, dwData As UInteger, dwExtraInfo As Integer)
    End Sub
    Private Const MOUSEEVENTF_LEFTDOWN = &H2
    Private Const MOUSEEVENTF_LEFTUP = &H4


    Private Sub form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim handeled As Boolean = False
        Select Case e.KeyCode
            Case Keys.Right
                right1 = True
                e.Handled = True
            Case Keys.Left
                left1 = True
                e.Handled = True
            Case Keys.Up
                up1 = True
                e.Handled = True
            Case Keys.Down
                down1 = True
                e.Handled = True
            Case Keys.Enter
                mouse_event(MOUSEEVENTF_LEFTDOWN Or MOUSEEVENTF_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0)
                enter1 = True
                e.Handled = True
            Case Keys.Space
                mouse_event(MOUSEEVENTF_LEFTDOWN Or MOUSEEVENTF_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0)
                e.Handled = True
            Case Keys.Escape
                Me.Close()
                e.Handled = True
        End Select
    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Dim handeled As Boolean = False
        Select Case e.KeyCode
            Case Keys.Right
                speedR = speed
                right1 = False
                e.Handled = True
            Case Keys.Left
                speedL = speed
                left1 = False
                e.Handled = True
            Case Keys.Up
                speedU = speed
                up1 = False
                e.Handled = True
            Case Keys.Down
                speedD = speed
                down1 = False
                e.Handled = True
        End Select
        checkpos = Cursor.Position
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        tickcount += 1
        If right1 = True Then
            If tickcount > accrate Then
                speedR = speedR + acc
            End If
            curr.X = Cursor.Position.X + speedR
            curr.Y = Cursor.Position.Y
            Cursor.Position = curr
        End If

        If left1 = True Then
            If tickcount > accrate Then
                speedL = speedL + acc
            End If
            curr.X = Cursor.Position.X - speedL
            curr.Y = Cursor.Position.Y
            Cursor.Position = curr
        End If

        If up1 = True Then
            If tickcount > accrate Then
                speedU = speedU + acc
            End If
            curr.X = Cursor.Position.X
            curr.Y = Cursor.Position.Y - speedU
            Cursor.Position = curr
        End If
        If down1 = True Then
            If tickcount > accrate Then
                speedD = speedD + acc
            End If
            curr.X = Cursor.Position.X
            curr.Y = Cursor.Position.Y + speedD
            Cursor.Position = curr
        End If
        If enter1 = True Then
            Me.Activate()
            enter1 = False
        End If

        If right1 = False And left1 = False And down1 = False And up1 = False And enter1 = False Then
            If checkpos <> Cursor.Position Then
                Me.Close()
            End If
        End If
            

        If tickcount > accrate Then
            tickcount = 0
        End If
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim curr2134 As System.Drawing.Point
        curr2134.X = -200
        curr2134.Y = -200
        Me.Location = curr2134
    End Sub

End Class
