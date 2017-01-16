Imports System.IO
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices

Public Class Cards
    Dim constr = "Data Source=SERVERNAME;Initial Catalog=DATABASENAME;Integrated Security=True"
    Dim tablestr = "[DATABASENAME].[SCHEMANAME].[TABLENAME]"
    Dim userlist As String = "col2 = 'mm' or col2 = 'rs' or col2 = 'as' or col2 = 'am' or col2 = 'ft' or col2 = 'ol' or col2 ='md'"
    Dim past As New DataTable
    Dim players As New ArrayList()
    Dim players1 As New ArrayList()
    Dim players2 As New ArrayList()
    Dim players3 As New ArrayList()
    Dim players4 As New ArrayList()
    Dim players5 As New ArrayList()
    Dim players6 As New ArrayList()
    Dim players7 As New ArrayList()
    Dim players1b As Boolean = False
    Dim players2b As Boolean = False
    Dim players3b As Boolean = False
    Dim players4b As Boolean = False
    Dim players5b As Boolean = False
    Dim players6b As Boolean = False
    Dim players7b As Boolean = False
    Dim user1 As String = ""
    Dim dev As Boolean = False
    Dim read As Boolean = False

    Private Sub Cards_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getUsername()
        setUsers()
    End Sub

    Private Sub getOnline()
        players1b = False
        players2b = False
        players3b = False
        players4b = False
        players5b = False
        players6b = False
        players7b = False
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim da As SqlClient.SqlDataAdapter
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            con.Open()
            da = New SqlClient.SqlDataAdapter("SELECT col2 FROM " & tablestr & " where " & "col4 = '-c-'", con)
            da.Fill(ds)
            dt = ds.Tables(0)
        Catch ex As Exception
            Timer1.Enabled = False
            MessageBox.Show("Error.")
        Finally
            con.Close()
            For Each usern As DataRow In dt.Rows
                If usern.Item(0) = "MM" Then
                    players1b = True
                    rtb1.AppendText(usern.Item(0).ToString & " has connected" & vbCrLf)
                ElseIf usern.Item(0) = "RS" Then
                    players2b = True
                    rtb1.AppendText(usern.Item(0).ToString & " has connected" & vbCrLf)
                ElseIf usern.Item(0) = "AM" Then
                    players3b = True
                    rtb1.AppendText(usern.Item(0).ToString & " has connected" & vbCrLf)
                ElseIf usern.Item(0) = "AS" Then
                    players4b = True
                    rtb1.AppendText(usern.Item(0).ToString & " has connected" & vbCrLf)
                ElseIf usern.Item(0) = "FT" Then
                    players5b = True
                    rtb1.AppendText(usern.Item(0).ToString & " has connected" & vbCrLf)
                ElseIf usern.Item(0) = "OL" Then
                    players6b = True
                    rtb1.AppendText(usern.Item(0).ToString & " has connected" & vbCrLf)
                ElseIf usern.Item(0) = "MD" Then
                    players7b = True
                    rtb1.AppendText(usern.Item(0).ToString & " has connected" & vbCrLf)
                End If
            Next
            If user1 = "MM" Then
                players1b = True
            ElseIf user1 = "RS" Then
                players2b = True
            ElseIf user1 = "AM" Then
                players3b = True
            ElseIf user1 = "AS" Then
                players4b = True
            ElseIf user1 = "FT" Then
                players5b = True
            ElseIf user1 = "OL" Then
                players6b = True
            ElseIf user1 = "MD" Then
                players7b = True
            End If
        End Try
    End Sub

    Private Sub setUsers()
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand = New SqlCommand
        Try
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "update " & tablestr & " set col4 = '" & "-c-" & "' where col2 = '" & user1 & "'"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub shuffle()
        getOnline()
        Dim arrCards As New List(Of String)(New String() {"2  D", "3  D", "4  D", "5  D", "6  D", "7  D", "8  D", "9  D", "10D", "J  D", "Q  D", "K  D", "A  D", "2  H", "3  H", "4  H", "5  H", "6  H", "7  H", "8  H", "9  H", "10H", "J  H", "Q  H", "K  H", "A  H", "2  S", "3  S", "4  S", "5  S", "6  S", "7  S", "8  S", "9  S", "10S", "J  S", "Q  S", "K  S", "A  S", "2  C", "3  C", "4  C", "5  C", "6  C", "7  C", "8  C", "9  C", "10C", "J  C", "Q  C", "K  C", "A  C"})
        Dim rnd As New System.Random
        Dim x, swap As String
        For i As Integer = 0 To arrCards.Count - 1
            x = rnd.Next(0, i)
            swap = arrCards(x)
            arrCards(x) = arrCards(i)
            arrCards(i) = swap
        Next
        Dim check As Integer = 0
        While arrCards.Count <> 0
            If arrCards.Count <> 0 And players1b = True Then
                players1.Add(arrCards(0))
                arrCards.RemoveAt(0)
            End If
            If arrCards.Count <> 0 And players2b = True Then
                players2.Add(arrCards(0))
                arrCards.RemoveAt(0)
            End If
            If arrCards.Count <> 0 And players3b = True Then
                players3.Add(arrCards(0))
                arrCards.RemoveAt(0)
            End If
            If arrCards.Count <> 0 And players4b = True Then
                players4.Add(arrCards(0))
                arrCards.RemoveAt(0)
            End If
            If arrCards.Count <> 0 And players5b = True Then
                players5.Add(arrCards(0))
                arrCards.RemoveAt(0)
            End If
            If arrCards.Count <> 0 And players6b = True Then
                players6.Add(arrCards(0))
                arrCards.RemoveAt(0)
            End If
            If arrCards.Count <> 0 And players7b = True Then
                players7.Add(arrCards(0))
                arrCards.RemoveAt(0)
            End If
            check += 1
            If check > 52 Then
                MsgBox("No active players.")
                Me.Close()
            End If
        End While
        sortarray()
        For Each btn As Button In Panel1.Controls
            If user1 = "MM" Then
                If btn.TabIndex < players1.Count Then
                    btn.Text = players1(btn.TabIndex).ToString
                    btn.Enabled = True
                Else
                    btn.Visible = False
                End If
            ElseIf user1 = "RS" Then
                If btn.TabIndex < players2.Count Then
                    btn.Text = players2(btn.TabIndex).ToString
                    btn.Enabled = True
                Else
                    btn.Visible = False
                End If
            ElseIf user1 = "AM" Then
                If btn.TabIndex < players3.Count Then
                    btn.Text = players3(btn.TabIndex).ToString
                    btn.Enabled = True
                Else
                    btn.Visible = False
                End If
            ElseIf user1 = "AS" Then
                If btn.TabIndex < players4.Count Then
                    btn.Text = players4(btn.TabIndex).ToString
                    btn.Enabled = True
                Else
                    btn.Visible = False
                End If
            ElseIf user1 = "FT" Then
                If btn.TabIndex < players5.Count Then
                    btn.Text = players5(btn.TabIndex).ToString
                    btn.Enabled = True
                Else
                    btn.Visible = False
                End If
            ElseIf user1 = "OL" Then
                If btn.TabIndex < players6.Count Then
                    btn.Text = players6(btn.TabIndex).ToString
                    btn.Enabled = True
                Else
                    btn.Visible = False
                End If
            ElseIf user1 = "MD" Then
                If btn.TabIndex < players7.Count Then
                    btn.Text = players7(btn.TabIndex).ToString
                    btn.Enabled = True
                Else
                    btn.Visible = False
                End If
            End If
        Next

        If players1b = True Then
            arraytoString(players1, "MM")
        End If
        If players2b = True Then
            arraytoString(players2, "RS")
        End If
        If players3b = True Then
            arraytoString(players3, "AM")
        End If
        If players4b = True Then
            arraytoString(players4, "AS")
        End If
        If players5b = True Then
            arraytoString(players5, "FT")
        End If
        If players6b = True Then
            arraytoString(players6, "OL")
        End If
        If players7b = True Then
            arraytoString(players7, "MD")
        End If
        Suites()
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand = New SqlCommand
        Try
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "update " & tablestr & " set col3 = 's' where col2 = 'GG'"
            cmd.ExecuteNonQuery()
            If txtOrder.Text.Trim <> Nothing Then
                cmd.CommandText = "update " & tablestr & " set col4 = '" & scramble(txtOrder.Text.Trim) & "' where col2 = 'EG'"
                cmd.ExecuteNonQuery()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
        End Try

    End Sub


    Private Sub arraytoString(arrstr As ArrayList, usr As String)
        Dim str1 As String = ""
        For Each str As String In arrstr
            str1 += str & ". "
        Next
        If str1.Length = 0 Then
            Exit Sub
        End If
        str1 = str1.Remove(str1.Length - 2)
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand = New SqlCommand
        Try
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "update " & tablestr & " set col4 = '" & str1 & "' where col2 = '" & usr & "'"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
        End Try
    End Sub


    Private Sub Suites()
        For Each btn As Button In Panel1.Controls
            If btn.Text.Contains("D") Then
                btn.ForeColor = Color.Red
                btn.Text = btn.Text.Replace("D", "♦")
            ElseIf btn.Text.Contains("S") Then
                btn.ForeColor = Color.Black
                btn.Text = btn.Text.Replace("S", "♠")
            ElseIf btn.Text.Contains("C") Then
                btn.ForeColor = Color.Black
                btn.Text = btn.Text.Replace("C", "♣")
            ElseIf btn.Text.Contains("H") Then
                btn.ForeColor = Color.Red
                btn.Text = btn.Text.Replace("H", "♥")
            End If
        Next
    End Sub

    Private Sub Suiteslast()
        If btnLastPressed.Text.Contains("P") Then
            Exit Sub
        End If
        If btnLastPressed.Text.Contains("D") Then
            btnLastPressed.ForeColor = Color.Red
            btnLastPressed.Text = btnLastPressed.Text.Replace("D", "♦")
        ElseIf btnLastPressed.Text.Contains("S") Then
            btnLastPressed.ForeColor = Color.Black
            btnLastPressed.Text = btnLastPressed.Text.Replace("S", "♠")
        ElseIf btnLastPressed.Text.Contains("C") Then
            btnLastPressed.ForeColor = Color.Black
            btnLastPressed.Text = btnLastPressed.Text.Replace("C", "♣")
        ElseIf btnLastPressed.Text.Contains("H") Then
            btnLastPressed.ForeColor = Color.Red
            btnLastPressed.Text = btnLastPressed.Text.Replace("H", "♥")
        End If
        If btnLastPressed.Text.Contains("♦") Then
            btnLastPressed.ForeColor = Color.Red
        ElseIf btnLastPressed.Text.Contains("♠") Then
            btnLastPressed.ForeColor = Color.Black
        ElseIf btnLastPressed.Text.Contains("♣") Then
            btnLastPressed.ForeColor = Color.Black
        ElseIf btnLastPressed.Text.Contains("♥") Then
            btnLastPressed.ForeColor = Color.Red
        End If
    End Sub

    Private Function SuitesStr(cardtext As String)
        If cardtext.Contains(" ") Then
            cardtext = cardtext.Replace(" ", "")
        End If
        If cardtext.Contains("D") Then
            cardtext = cardtext.Replace("D", " ♦")
        ElseIf cardtext.Contains("S") Then
            cardtext = cardtext.Replace("S", " ♠")
        ElseIf cardtext.Contains("C") Then
            cardtext = cardtext.Replace("C", " ♣")
        ElseIf cardtext.Contains("H") Then
            cardtext = cardtext.Replace("H", " ♥")
        End If
        Return cardtext
    End Function


    Private Sub NoSuites()
        For Each btn As Button In Panel1.Controls
            If btn.Text.Contains("♦") Then
                btn.Text = btn.Text.Replace("♦", "D")
            ElseIf btn.Text.Contains("♠") Then
                btn.Text = btn.Text.Replace("♠", "S")
            ElseIf btn.Text.Contains("♣") Then
                btn.Text = btn.Text.Replace("♣", "C")
            ElseIf btn.Text.Contains("♥") Then
                btn.Text = btn.Text.Replace("♥", "H")
            End If
        Next
    End Sub


    Private Sub btnShuffle_Click(sender As Object, e As EventArgs) Handles btnShuffle.Click
        players1.Clear()
        players2.Clear()
        players3.Clear()
        players4.Clear()
        players5.Clear()
        players6.Clear()
        players7.Clear()
        For Each btn As Button In Panel1.Controls
            btn.Visible = True
            btn.Enabled = False
            btn.Text = Nothing
        Next
        shuffle()
    End Sub

    Private Sub Button_Click(sender As Button, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click, Button10.Click, Button11.Click, Button12.Click, Button13.Click, Button14.Click, Button15.Click, Button16.Click, Button17.Click, Button18.Click, Button19.Click, Button20.Click, Button21.Click, Button22.Click, Button23.Click, Button24.Click, Button25.Click, Button26.Click, Button27.Click, Button28.Click, Button29.Click, Button30.Click, Button31.Click, Button32.Click, Button33.Click, Button34.Click, Button35.Click, Button36.Click, Button37.Click, Button38.Click, Button39.Click, Button40.Click, Button41.Click, Button42.Click, Button43.Click, Button44.Click, Button45.Click, Button46.Click, Button47.Click, Button48.Click, Button49.Click, Button50.Click, Button51.Click, Button52.Click
        NoSuites()
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand = New SqlCommand
        Try
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "update " & tablestr & " set col3 = '" & user1 & sender.Text & "' where col2 = '" & "GG" & "'"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
        End Try
        btnLastPressed.Enabled = True
        sender.Enabled = False
        Suites()
        Suiteslast()
        Dim checkcount As Integer = 0
        Dim checkcount2 As Integer = 0
        For Each btn As Button In Panel1.Controls
            If btn.Enabled = False And btn.Visible = True Then
                checkcount += 1
            End If
            If btn.Visible = True Then
                checkcount2 += 1
            End If
        Next
        If checkcount = checkcount2 Then
            Try
                con.Open()
                cmd = con.CreateCommand()
                cmd.CommandText = "update " & tablestr & " set col5 = '" & user1 & "PC" & "' where col2 = '" & "GG" & "'"
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End If
    End Sub

    Public Sub getUsername()
        Dim user As String = ""
        If TypeOf My.User.CurrentPrincipal Is Security.Principal.WindowsPrincipal Then
            Dim parts() As String = Split(My.User.Name, "\")
            Dim username As String = parts(1)
            user = username
        Else
            user = My.User.Name
        End If
        If user.Contains("SomeUser") Then
            dev = True
            user = "MM"
        ElseIf user.Contains("SomeUser2") Then
            user = "AS"
        ElseIf user.Contains("SomeUser3") Then
            user = "AM"
        ElseIf user.Contains("SomeUser4") Then
            user = "ME"
        ElseIf user.Contains("SomeUser5") Then
            user = "AY"
        ElseIf user.Contains("SomeUser6") Then
            user = "JL"
        ElseIf user.Contains("SomeUser7") Then
            user = "MD"
        ElseIf user.Contains("SomeUser8") Then
            user = "OL"
        ElseIf user.Contains("SomeUser9") Then
            user = "RS"
        ElseIf user.Contains("SomeUser10") Then
            user = "FT"
        ElseIf user.Contains("SomeUser11") Then
            user = "BH"
        ElseIf user.Contains("SomeUser12") Then
            user = "KB"
        Else
            Me.Close()
        End If
        user1 = user
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim da As SqlClient.SqlDataAdapter
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            con.Open()
            da = New SqlClient.SqlDataAdapter("SELECT col2,col3,col5 FROM " & tablestr & " where " & "col2 = 'gg'", con)
            da.Fill(ds)
            dt = ds.Tables(0)
        Catch ex As Exception
            Timer1.Enabled = False
            MessageBox.Show("Error.")
        Finally
            con.Close()
        End Try
        If dt.Rows(0).Item(1) = "s" And read = False Then
            btnRestart.Enabled = True
            rtb1.AppendText("The deck was shuffled." & vbCrLf)
            btnShuffle.Enabled = False
            Readit()
            read = True
            Exit Sub
        End If
        If dt.Rows(0).Item(1) = "s" Then
            btnLastPressed.Text = ""
        ElseIf dt.Rows(0).Item(1).ToString.Contains("P") And Not dt.Rows(0).Item(1).ToString.Contains("PC") Then
            Dim writeto As String = dt.Rows(0).Item(1)
            Dim user As String = writeto(0) & writeto(1)
            If btnLastPressed.Text <> user & " P" And Not writeto.Contains("PC") Then
                btnLastPressed.Text = user & " P"
                rtb1.AppendText(user & " has passed" & vbCrLf)
            End If
        ElseIf dt.Rows(0).Item(1) <> Nothing Then
            Dim writeto As String = dt.Rows(0).Item(1)
            Dim user As String = writeto(0) & writeto(1)
            Dim played As String = writeto.Remove(0, 2)
            writeto = SuitesStr(played)
            If Not rtb1.Text.Contains(user & " has played: " & writeto) Then
                rtb1.AppendText(user & " has played: " & writeto & vbCrLf)
            End If
            btnLastPressed.Text = played
        End If

        If dt.Rows(0).Item(2).ToString.Contains("PC") Then
            Dim writeto As String = dt.Rows(0).Item(1)
            Dim user As String = writeto(0) & writeto(1)
            rtb1.AppendText(user & " has no cards remaining" & vbCrLf)
            If user = user1 Then

                nothingg()
            End If
        End If
        past = dt.Copy
        Suiteslast()
    End Sub

    Private Sub nothingg()
        Timer1.Enabled = False
        Dim con2 As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand = New SqlCommand
        Try
            con2.Open()
            cmd = con2.CreateCommand()
            cmd.CommandText = "update " & tablestr & " set col5 = '' where col2 = '" & "GG" & "'"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            con2.Close()
        End Try
        Timer1.Enabled = True
    End Sub

    Private Sub Readit()
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand = New SqlCommand
        Dim allcards As String = ""
        Try
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT col4 FROM " & tablestr & " where col2 = '" & user1 & "'"
            allcards = cmd.ExecuteScalar()
            cmd.CommandText = "update " & tablestr & " set col4 = '' where col2 = '" & user1 & "'"
            cmd.ExecuteNonQuery()
            If txtOrder.ReadOnly = False Then
                cmd.CommandText = "SELECT col4 FROM " & tablestr & " where col2 = 'EG'"
                txtOrder.Text = scramble(cmd.ExecuteScalar())
                txtOrder.ReadOnly = True
            End If
        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
        End Try
        If user1 = "MM" Then
            createlist(allcards, players1)
        ElseIf user1 = "RS" Then
            createlist(allcards, players2)
        ElseIf user1 = "AM" Then
            createlist(allcards, players3)
        ElseIf user1 = "AS" Then
            createlist(allcards, players4)
        ElseIf user1 = "FT" Then
            createlist(allcards, players5)
        ElseIf user1 = "OL" Then
            createlist(allcards, players6)
        ElseIf user1 = "MD" Then
            createlist(allcards, players7)
        End If
    End Sub

    Private Sub createlist(cardstr As String, ply As ArrayList)
        ply.Clear()
        Dim card As String = ""
        For Each Ch As Char In cardstr
            If Ch <> "." Then
                card += Ch
            ElseIf Ch = "." Then
                ply.Add(card.Trim)
                card = ""
            End If
        Next
        ply.Add(card)
        For Each btn As Button In Panel1.Controls
            If btn.TabIndex < ply.Count Then
                btn.Text = ply(btn.TabIndex).ToString
                btn.Enabled = True
            Else
                btn.Visible = False
            End If
        Next
        Suites()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand = New SqlCommand
        Dim allcards As String = ""
        Try
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "update " & tablestr & " set col4 = '' where " & userlist & ""
            cmd.ExecuteNonQuery()
            cmd.CommandText = "update " & tablestr & " set col3 = '' where col2 = 'GG'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "update " & tablestr & " set col5 = '' where col2 = 'GG'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "update " & tablestr & " set col3 = '-g-ZHQWB zpubyw' where col2 = '" & user1 & "'"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
        End Try
        Me.Close()
    End Sub

    Private Sub btnPass_Click(sender As Object, e As EventArgs) Handles btnPass.Click
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand = New SqlCommand
        Try
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "update " & tablestr & " set col3 = '" & user1 & "P' where col2 = '" & "GG" & "'"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnRestart_Click(sender As Object, e As EventArgs) Handles btnRestart.Click
        txtOrder.ReadOnly = False
        txtOrder.Text = Nothing
        btnRestart.Enabled = False
        getUsername()
        setUsers()
        btnShuffle.Enabled = True
        rtb1.Clear()
        btnLastPressed.Text = Nothing
        read = False
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand = New SqlCommand
        Try
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "update " & tablestr & " set col3 = '' where col2 = 'GG'"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub sortarray()
        players1.Sort()
        players2.Sort()
        players3.Sort()
        players4.Sort()
        players5.Sort()
        players6.Sort()
        players7.Sort()
    End Sub

    Private Function sortarray2(gg As ArrayList)
        gg.Sort()
        Return gg
    End Function

    Private Function scramble(encptstr As String) As String
        Dim b(encptstr.Length) As Char
        Dim uletters(26) As Char
        Dim lletters(26) As Char
        uletters = {"C", "D", "E", "F", "N", "O", "G", "B", "A", "M", "L", "K", "Q", "R", "J", "P", "I", "H", "S", "T", "U", "V", "X", "Y", "W", "Z"}
        lletters = {"c", "d", "e", "f", "n", "o", "g", "b", "a", "m", "l", "k", "q", "r", "j", "p", "i", "h", "s", "t", "u", "v", "x", "y", "w", "z"}
        b = encptstr.ToCharArray
        For i = 0 To encptstr.Length - 1
            If Char.IsLower(b(i)) And lletters.Contains(b(i)) Then
                b(i) = lletters(25 - Array.LastIndexOf(lletters, b(i)))
            ElseIf Char.IsUpper(b(i)) And uletters.Contains(b(i)) Then
                b(i) = uletters(25 - Array.LastIndexOf(uletters, b(i)))
            Else
                b(i) = b(i)
            End If
        Next
        Return b
    End Function
End Class