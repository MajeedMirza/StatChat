Imports System.IO
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Public Class ctf

    Dim constr As String
    Dim tablestr As String
    Dim Up1 As Boolean = False
    Dim Down1 As Boolean = False
    Dim Right1 As Boolean = False
    Dim Left1 As Boolean = False
    Dim xSend As Integer
    Dim ySend As Integer
    Dim xReceive As Integer = 50
    Dim yReceive As Integer = 50
    Dim speed As Integer = 2
    Dim moveList As New List(Of String)
    Dim flagX As Integer
    Dim flagY As Integer
    Dim limit As Integer = 10
    Dim haveFlag As Boolean = False
    Dim wait As Boolean = False
    Dim timerCount As Integer = 0
    Dim myCol As Brush = Brushes.Black
    Dim space As Boolean = False
    Dim drawList As New HashSet(Of Point)

    Private Sub ctf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form2.getUsername()
        Me.BackgroundImageLayout = ImageLayout.None
        Me.DoubleBuffered = True
        constr = Form2.constr
        tablestr = Form2.tablestr
        flagX = 250
        flagY = 220
    End Sub

    Public Sub DrawScreen()

        Using bmp As Bitmap = New Bitmap(Me.Width, Me.Height)

            Using g As Graphics = Graphics.FromImage(bmp)

                With g
                    .Clear(Color.White)

                    If space = True And haveFlag = True Then
                        drawList.Add(New Point(xReceive, yReceive))
                    End If
                    For Each p As Point In drawList
                        g.DrawRectangle(New Pen(Brushes.Blue, 10), p.X, p.Y, 5, 5)
                    Next

                    Dim bPen As Pen = New Pen(myCol, 10)
                    g.DrawRectangle(bPen, xReceive, yReceive, 5, 5)
                    Dim rPen As Pen = New Pen(Brushes.Red, 10)
                    For Each p As String In moveList
                        Dim xv As Integer = p.Split(".")(0)
                        Dim yv As Integer = p.Split(".")(1)
                        Dim name As String = p.Split(".")(2)
                        g.DrawRectangle(rPen, xv, yv, 5, 5)
                        g.DrawString(name, New Font("Tahoma", 8), Brushes.Black, New Point(xv - 6, yv - 17))
                    Next
                    Dim gPen As Pen = New Pen(Brushes.Green, 10)
                    g.DrawArc(gPen, flagX, flagY, 3, 3, 0, 360)
                    Me.BackgroundImage = bmp.Clone

                    Me.Invalidate()

                End With

            End Using

        End Using

    End Sub

    Private Sub Main_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Up
                Up1 = True
                e.Handled = True
            Case Keys.Down
                Down1 = True
                e.Handled = True
            Case Keys.Right
                Right1 = True
                e.Handled = True
            Case Keys.Left
                Left1 = True
                e.Handled = True
            Case (Keys.Escape)
                Me.Close()
            Case (Keys.Space)
                space = True
        End Select
    End Sub

    Private Sub Main_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Select Case e.KeyCode
            Case Keys.Up
                Up1 = False
                e.Handled = True
            Case Keys.Down
                Down1 = False
                e.Handled = True
            Case Keys.Right
                Right1 = False
                e.Handled = True
            Case Keys.Left
                Left1 = False
                e.Handled = True
            Case (Keys.Space)
                space = False
        End Select
    End Sub

    Private Sub useArrows()
        If Up1 = True Then
            If Not ySend <= 0 Then
                ySend -= speed
            End If
        End If
        If Down1 = True Then
            If Not ySend >= Me.Height - 40 Then
                ySend += speed
            End If
        End If
        If Left1 = True Then
            If Not xSend < 0 + 5S Then
                xSend -= speed
            End If
        End If
        If Right1 = True Then
            If Not xSend > Me.Width - 23 Then
                xSend += speed
            End If
        End If
    End Sub

    Private Sub sendPosition()
        Dim sendString As String = "qwfrqwfqwfqwfqwf," & xSend & "," & ySend
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand = New SqlCommand
        Try
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "update " & tablestr & " set col5 = '" & sendString & "' where col2 = '" & Form2.UserInitials & "'"
            cmd.ExecuteNonQuery()
            If (flagX < xSend + limit And flagX > xSend - limit And flagY < ySend + limit And flagY > ySend - limit) And wait = False Then
                haveFlag = True
                cmd.CommandText = "update " & tablestr & " set col5 = '" & sendString & "' where col2 = 'FGW'"
                cmd.ExecuteNonQuery()
            Else
                If haveFlag = True Then
                    wait = True
                End If
                haveFlag = False
                If wait = True Then
                    myCol = Brushes.Gray
                    Timer2.Enabled = True

                End If
            End If
        Catch ex As Exception
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub receivePosition()
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim da As SqlClient.SqlDataAdapter
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            con.Open()
            da = New SqlClient.SqlDataAdapter("SELECT col2,col5 FROM " & tablestr & " where " & Form2.userlist, con)
            da.Fill(ds)
            dt = ds.Tables(0)
        Catch ex As Exception
        Finally
            con.Close()
        End Try
        moveList.Clear()
        For Each row As DataRow In dt.Rows
            If row.Item(1).ToString.Contains("qwfrqwfqwfqwfqwf,") Then
                Dim posString As String() = row.Item(1).ToString.Split(",")
                If row.Item(0) = Form2.UserInitials Then
                    xReceive = posString(1)
                    yReceive = posString(2)
                ElseIf row.Item(0) = "FGW" Then
                    flagX = posString(1)
                    flagY = posString(2)
                Else
                    'Dim addP As New Point(posString(1), posString(2) + "." + row.Item(0))
                    moveList.Add(posString(1) + "." + posString(2) + "." + row.Item(0))
                End If
            End If
        Next
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        useArrows()
        sendPosition()
        receivePosition()
        DrawScreen()
    End Sub

    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        closethis()
        Form2.ctfopen = False
    End Sub

    Public Sub closethis()
        Dim rand As New Random
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand = New SqlCommand
        Try
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "update " & tablestr & " set col5 = '" & rand.Next(0, 1000) & "' where col2 = '" & Form2.UserInitials & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "update " & tablestr & " set col5 = '" & rand.Next(0, 1000) & "' where col2 = 'FGW'"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        timerCount += 1
        If timerCount = 1 Then
            wait = False
            Timer2.Enabled = False
            timerCount = 0
            myCol = Brushes.Black
        End If
    End Sub
End Class