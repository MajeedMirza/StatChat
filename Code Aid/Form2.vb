Imports System.IO
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices

Public Class Form2
    Dim lastline As String = ""
    Public constr = "Data Source=SERVERNAME;Initial Catalog=DATABASENAME;Integrated Security=True;Connect Timeout=3"
    Public tablestr = "[DATABASENAME].[SCHEMANAME].[TABLENAME]"
    Dim said As Boolean = False
    Dim group As Boolean = False
    Dim past As New DataTable
    Public userlist As String = "col2 = 'mm' or col2 = 'as' or col2 = 'am' or col2 = 'ol' or col2 = 'fgw' or col2 = 'md' or col2 = 'rs' or col2 = 'ft' or col2 = 'bh' or col2 = 'kb'"
    Dim pastSize As Integer = Me.Width
    Dim original As String = ""
    Dim latext2 As Boolean = False
    Dim curr As System.Drawing.Point
    Dim curr1 As System.Drawing.Point
    Dim encryptSTR As String = "acegikmoqsuwy"
    Dim dev As Boolean = False
    Dim PrivUser As String = ""
    Public UserInitials As String = ""
    Dim logoff As Boolean = False
    Dim defaultcolor As Color = Me.BackColor
    Dim ofdAttachment As New OpenFileDialog()
    Dim ofdAttachment2 As New SaveFileDialog()
    Dim count10 As Integer = 0
    Dim mute As Boolean = False
    Public ctfOpen As Boolean = False


    <DllImport("user32.dll")> _
    Public Shared Function FlashWindow(ByVal hwnd As Integer, ByVal bInvert As Integer) As Integer
    End Function


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim result_E As String = ""
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand = New SqlCommand
        Try
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT col3 FROM " & tablestr & " where col2 = '" & PrivUser & "'"
            result_E = cmd.ExecuteScalar().ToString & vbCrLf
            If result_E.Trim <> "" And Not (result_E.Contains("-g-")) Then
                result_E = result_E.Replace("-p-", "")
                Dim result As String = scramble(result_E)
                If result.Contains(scramble("129s")) Then
                    If said = False Then
                        rtbText.AppendText("User offline" & vbCrLf)
                        said = True
                    End If
                Else
                    If Me.WindowState = FormWindowState.Minimized Or result.Contains("PING") Then
                        FlashWindow(Me.Handle, 1)
                    End If
                    If result.Contains("updateasd") Then
                        result = result.Replace("updateasd", "update")
                    End If
                    If result.Contains("deleteasd") Then
                        result = result.Replace("deleteasd", "delete")
                    End If
                    If result.Contains("selectasd") Then
                        result = result.Replace("selectasd", "select")
                    End If
                    If result.Contains("dropasd") Then
                        result = result.Replace("dropasd", "drop")
                    End If
                    If result.Contains("createasd") Then
                        result = result.Replace("createasd", "create")
                    End If
                    If result.Contains("fromasd") Then
                        result = result.Replace("fromasd", "from")
                    End If
                    If result.Contains("whereasd") Then
                        result = result.Replace("whereasd", "where")
                    End If
                    If result.Contains("intoasd") Then
                        result = result.Replace("intoasd", "into")
                    End If
                    If result.Contains("tableasd") Then
                        result = result.Replace("tableasd", "table")
                    End If
                    If result.Contains("-at-") Then
                        result = result.Replace("-at-", "")
                        rtbText.AppendText("\\" & result.Replace(" ", "") & "_from_" & PrivUser & vbCrLf)
                        result = ""
                    End If
                    rtbText.AppendText("Other: " & result)
                    cmd.CommandText = "update " & tablestr & " set col3 = ' ' where col2 = '" & PrivUser & "'"
                    cmd.ExecuteNonQuery()
                End If
            End If
        Catch ex As Exception
            txtText.ReadOnly = True
            Timer1.Enabled = False
            PrivUser = ""
            connectSC()
            MessageBox.Show("This user does not exist.")
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim da As SqlClient.SqlDataAdapter
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            con.Open()
            da = New SqlClient.SqlDataAdapter("SELECT col2,col3 FROM " & tablestr & " where " & userlist, con)
            da.Fill(ds)
            dt = ds.Tables(0)
        Catch ex As Exception
            txtText.ReadOnly = True
            Timer2.Enabled = False
            MessageBox.Show("Error.")
        Finally
            con.Close()
        End Try
        For i As Integer = 0 To dt.Rows.Count - 1
            If past.Rows.Count = 0 Then
                Exit For
            ElseIf dt.Rows(i).Item(1).ToString <> past.Rows(i).Item(1).ToString And past.Rows(i).Item(1).ToString = "129s" Then
                rtbText.AppendText("User " & dt.Rows(i).Item(0).ToString & " has connected. " & vbCrLf)
                If Not Me.Text.Contains(dt.Rows(i).Item(0).ToString.Trim) Then
                    Me.Text += dt.Rows(i).Item(0).ToString.Trim & " "
                End If
            ElseIf dt.Rows(i).Item(1).ToString <> past.Rows(i).Item(1).ToString And dt.Rows(i).Item(1).ToString.Trim = "129s" Then
                rtbText.AppendText("User " & dt.Rows(i).Item(0).ToString & " has disconnected. " & vbCrLf)
                Me.Text = Me.Text.Replace(dt.Rows(i).Item(0).ToString.Trim & " ", "")
            End If
            If dt.Rows(i).Item(1).ToString.Trim <> "" And dt.Rows(i).Item(1).ToString.Trim <> "129s" And dt.Rows(i).Item(0).ToString.Trim <> UserInitials.Trim And dt.Rows(i).Item(1).ToString <> past.Rows(i).Item(1).ToString And Not (dt.Rows(i).Item(1).ToString.Contains("-p-")) And dt.Rows(i).Item(1).ToString.Contains("-g-") Then
                Dim insert_E As String = ""
                insert_E = dt.Rows(i).Item(1).ToString
                insert_E = insert_E.Replace("-g-", "")
                Dim insert As String = scramble(insert_E)
                If insert = Nothing Then
                    Exit Sub
                End If
                If insert.Contains("-at-") Then
                    insert = insert.Replace("-at-", "")
                    rtbText.AppendText("\\" & insert.Replace(" ", "") & "_from_" & dt.Rows(i).Item(0).ToString & vbCrLf)
                    insert = ""
                End If
                If insert.Contains(":)") Then
                    insert = insert.Replace(":)", "")
                End If
                If insert.Contains("pce") Then
                    insert = insert.Replace("pce", "")
                End If
                If insert.Contains("x(") Then
                    insert = insert.Replace("x(", "")
                End If
                If insert.Contains("-HAND-") Then
                    insert = insert.Replace("-HAND-", "")
                End If
                If insert.Contains("-UP-") Then
                    insert = insert.Replace("-UP-", "")
                End If
                If insert.Contains("-DOWN-") Then
                    insert = insert.Replace("-DOWN-", "")
                End If
                If insert.Contains("-LEFT-") Then
                    insert = insert.Replace("-LEFT-", "")
                End If
                If insert.Contains("-RIGHT-") Then
                    insert = insert.Replace("-RIGHT-", "")
                End If
                If insert.Contains("-.-") Then
                    insert = insert.Replace("-.-", "")
                End If
                If insert.Contains(":(") Then
                    insert = insert.Replace(":(", "")
                End If
                If insert.Contains("ihgbsdSdihgerwgA!In?E.") Then
                    If insert.Contains(UserInitials) Then
                        Me.Close()
                    End If
                    insert = ""
                End If
                If insert.Contains("updateasd") Then
                    insert = insert.Replace("updateasd", "update")
                End If
                If insert.Contains("deleteasd") Then
                    insert = insert.Replace("deleteasd", "delete")
                End If
                If insert.Contains("selectasd") Then
                    insert = insert.Replace("selectasd", "select")
                End If
                If insert.Contains("dropasd") Then
                    insert = insert.Replace("dropasd", "drop")
                End If
                If insert.Contains("createasd") Then
                    insert = insert.Replace("createasd", "create")
                End If
                If insert.Contains("fromasd") Then
                    insert = insert.Replace("fromasd", "from")
                End If
                If insert.Contains("whereasd") Then
                    insert = insert.Replace("whereasd", "where")
                End If
                If insert.Contains("intoasd") Then
                    insert = insert.Replace("intoasd", "into")
                End If
                If insert.Contains("tableasd") Then
                    insert = insert.Replace("tableasd", "table")
                End If

                If (Me.WindowState = FormWindowState.Minimized Or insert.Contains("PING")) And mute = False Then
                    FlashWindow(Me.Handle, 1)
                End If
                If insert.Trim <> Nothing Then
                    rtbText.AppendText(dt.Rows(i).Item(0).ToString & ": " & insert & vbCrLf)
                End If
            End If
        Next
        past = dt.Copy
    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        If testConnection() = False Then
            Exit Sub
        End If
        If txtText.ReadOnly = True Then
            MessageBox.Show("Please connect first.")
            Exit Sub
        End If
        If Timer1.Enabled = True Then
            Timer1.Enabled = False
        ElseIf Timer2.Enabled = True Then
            Timer2.Enabled = False
        End If
        Timer3.Stop()

        Dim con As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand = New SqlCommand
        Dim textToSend As String = txtText.Text
        Try
            con.Open()
            cmd = con.CreateCommand()
            If textToSend.Contains("'") Then
                textToSend = textToSend.Replace("'", "''")
            End If
            If textToSend.Contains("ihgbsdSdihgerwgA!In?E.") And dev = False Then
                textToSend = ""
            End If
            If textToSend.Contains("-LATEXT-") Then
                If latext2 = False Then
                    latext2 = True
                Else
                    latext2 = False
                End If
                textToSend = ""
            End If
            If textToSend.Contains("-BAMAMA-") Then
                Dim bamama As New bamama
                bamama.Show()
                textToSend = ""
            End If
            If textToSend.Contains("FIND(") Then
                textToSend = textToSend.Replace("FIND(", "")
                textToSend = textToSend.Replace(")", "")
                If textToSend = "" Then
                    rtbText.AppendText("-" & vbCrLf)
                    rtbText.AppendText("Please enter a string e.g. FIND(Hello)" & vbCrLf)
                    rtbText.AppendText("-" & vbCrLf)
                Else
                    If rtbText.Text.Contains(textToSend) Then
                        rtbText.AppendText("-" & vbCrLf)
                        rtbText.AppendText(textToSend & " was found" & vbCrLf)
                        rtbText.AppendText("-" & vbCrLf)
                    Else
                        rtbText.AppendText("-" & vbCrLf)
                        rtbText.AppendText(textToSend & " was not Found" & vbCrLf)
                        rtbText.AppendText("-" & vbCrLf)
                    End If
                End If
                textToSend = ""
            End If
            If textToSend.Contains("PC(") Then
                textToSend = textToSend.Replace("PC(", "")
                textToSend = textToSend.Replace(")", "")
                PrivUser = textToSend
                connectSC()
                If PrivUser <> "" Then
                    rtbText.AppendText("-" & vbCrLf)
                    rtbText.AppendText("Private Chatting with " & textToSend & vbCrLf)
                    rtbText.AppendText("-" & vbCrLf)
                Else
                    rtbText.AppendText("-" & vbCrLf)
                    rtbText.AppendText("Group Chat" & vbCrLf)
                    rtbText.AppendText("-" & vbCrLf)
                End If
                textToSend = ""
            End If
            If textToSend.Contains("-LOOP-") Then
                If Timer4.Enabled = False Then
                    Timer4.Enabled = True
                Else
                    Timer4.Enabled = False
                End If
                textToSend = ""
            End If
            If textToSend.Contains("-MOUSE-") Then
                Dim mousey As New Form1
                mousey.Show()
                textToSend = ""
            End If
            'If textToSend.Contains("-POPS-") Then
            '    Dim popsg As New Pops
            '    popsg.Show()
            '    textToSend = ""
            'End If
            If textToSend.Contains("-PONG-") Then
                Dim pong As New G
                G.Show()
                rtbText.AppendText("-" & vbCrLf)
                rtbText.AppendText("Controls: C for computer, D for impossible computer and enable mouse, SPACE to restart, UP to move up (w for p2), DOWN to move down (s for p2), RIGHT to hide and pause everything, P to pause, everything else closes the game." & vbCrLf)
                rtbText.AppendText("-" & vbCrLf)
                textToSend = ""
            End If
            If textToSend.Contains("-CARDS-") Then
                Dim cards As New Cards
                cards.Show()
            End If
            If textToSend.Contains("-CTF-") Then
                If ctfOpen = False Then
                    Dim ctf As New ctf
                    ctf.Show()
                    ctfOpen = True
                End If

            End If
            If textToSend.Contains("-AID-") Then
                Dim aid As New CodeAid
                aid.Show()
                textToSend = ""
            End If
            If textToSend.Contains("-TTO-") Then
                Dim tto As New Form3
                tto.Show()
                textToSend = ""
            End If
            If textToSend.Contains("-OPEN-") Then
                If File.Exists("C:\temp\SCLog.txt") Then
                    Dim readall As String = File.ReadAllText("C:\temp\SCLog.txt")
                    rtbText.AppendText(scramble(readall))
                End If
                textToSend = ""
            End If
            If textToSend.Contains("-TMS-") Then
                Process.Start("http://adminsystems/Applications/Pal/PAL40/stc.finance.pal.application?Function=launchapplication&AppUrl=http://AdminSystems/applications/TALES/STC.Finance.TALES.WinUI.dll&AppMainForm=STC.Finance.TALES.WinUI.frmMain&AppDBServer=fld3sql1&AppDBName=TALES")
                textToSend = ""
            End If
            If textToSend.Contains("-OGS-") Then
                rtbText.AppendText("-" & vbCrLf)
                rtbText.AppendText(ogs())
                rtbText.AppendText("-" & vbCrLf)
                textToSend = ""
            End If
            If textToSend.ToLower.Contains("update") Then
                textToSend = textToSend.ToLower.Replace("update", "updateasd")
            End If
            If textToSend.ToLower.Contains("delete") Then
                textToSend = textToSend.ToLower.Replace("delete", "deleteasd")
            End If
            If textToSend.ToLower.Contains("select") Then
                textToSend = textToSend.ToLower.Replace("select", "selectasd")
            End If
            If textToSend.ToLower.Contains("drop") Then
                textToSend = textToSend.ToLower.Replace("drop", "dropasd")
            End If
            If textToSend.ToLower.Contains("create") Then
                textToSend = textToSend.ToLower.Replace("create", "createasd")
            End If
            If textToSend.ToLower.Contains("from") Then
                textToSend = textToSend.ToLower.Replace("from", "fromasd")
            End If
            If textToSend.ToLower.Contains("where") Then
                textToSend = textToSend.ToLower.Replace("where", "whereasd")
            End If
            If textToSend.ToLower.Contains("into") Then
                textToSend = textToSend.ToLower.Replace("into", "intoasd")
            End If
            If textToSend.ToLower.Contains("table") Then
                textToSend = textToSend.ToLower.Replace("table", "tableasd")
            End If

            If textToSend.Contains("-USERS-") Then
                rtbText.AppendText("-" & vbCrLf)
                getOnline()
                textToSend = ""
                rtbText.AppendText("-" & vbCrLf)
            End If

            Dim textToSend_E As String = scramble(textToSend)
            If group = False Then
                textToSend_E = "-p-" & textToSend_E
            Else
                textToSend_E = "-g-" & textToSend_E
            End If
            If textToSend_E.Trim <> "-g-" Then
                cmd.CommandText = "update " & tablestr & " set col3 = '" & textToSend_E & "' where col2 = '" & UserInitials & "'"
                cmd.ExecuteNonQuery()
            End If
        Catch ex As Exception
            Me.Close()
            Throw ex
        Finally
            con.Close()
        End Try
        If textToSend.Contains(":)") Then
            textToSend = textToSend.Replace(":)", "")
        End If
        If textToSend.Contains("pce") Then
            textToSend = textToSend.Replace("pce", "")
        End If
        If textToSend.Contains("x(") Then
            textToSend = textToSend.Replace("x(", "")
        End If
        If textToSend.Contains("-HAND-") Then
            textToSend = textToSend.Replace("-HAND-", "")
        End If
        If textToSend.Contains("-UP-") Then
            textToSend = textToSend.Replace("-UP-", "")
        End If
        If textToSend.Contains("-DOWN-") Then
            textToSend = textToSend.Replace("-DOWN-", "")
        End If
        If textToSend.Contains("-LEFT-") Then
            textToSend = textToSend.Replace("-LEFT-", "")
        End If
        If textToSend.Contains("-RIGHT-") Then
            textToSend = textToSend.Replace("-RIGHT-", "")
        End If
        If textToSend.Contains("-.-") Then
            textToSend = textToSend.Replace("-.-", "")
        End If
        If textToSend.Contains(":(") Then
            textToSend = textToSend.Replace(":(", "")
        End If
        If textToSend.Contains("-at-") Then
            textToSend = ""
        End If
        If textToSend.Contains("updateasd") Then
            textToSend = textToSend.Replace("updateasd", "update")
        End If
        If textToSend.Contains("deleteasd") Then
            textToSend = textToSend.Replace("deleteasd", "delete")
        End If
        If textToSend.Contains("selectasd") Then
            textToSend = textToSend.Replace("selectasd", "select")
        End If
        If textToSend.Contains("dropasd") Then
            textToSend = textToSend.Replace("dropasd", "drop")
        End If
        If textToSend.Contains("createasd") Then
            textToSend = textToSend.Replace("createasd", "create")
        End If
        If textToSend.Contains("fromasd") Then
            textToSend = textToSend.Replace("fromasd", "from")
        End If
        If textToSend.Contains("whereasd") Then
            textToSend = textToSend.Replace("whereasd", "where")
        End If
        If textToSend.Contains("intoasd") Then
            textToSend = textToSend.Replace("intoasd", "into")
        End If
        If textToSend.Contains("tableasd") Then
            textToSend = textToSend.Replace("tableasd", "table")
        End If
        If textToSend.Contains("''") Then
            textToSend = textToSend.Replace("''", "'")
        End If

        If textToSend.Contains("-p-") Then
            textToSend = textToSend.Replace("-p-", "")
        End If
        If textToSend.Contains("-g-") Then
            textToSend = textToSend.Replace("-g-", "")
        End If


        If textToSend.Trim <> "" Then
            rtbText.AppendText("You: " & textToSend & vbCrLf)
        End If

        txtText.Text = Nothing
        If group = True Then
            Timer2.Enabled = True
        Else
            Timer1.Enabled = True
        End If
        Timer3.Start()
    End Sub

    Private Function ogs()
        Dim PSC As String = ""
        PSC = "DH:" & vbCrLf & "Imagine a white guy t bagging a field of wheat while the sun sets behind him. That’s me." & vbCrLf & vbCrLf
        PSC += "SI:" & vbCrLf & "The r8ings of others do not matter. The most important thing is whether you r8 yourself." & vbCrLf
        Return PSC
    End Function

    Protected Overrides Function processCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If ActiveControl.Name = txtText.Name And keyData = Keys.Return Then
            btnSend.PerformClick()
            Return True
        ElseIf keyData = Keys.Escape Then
            Me.Close()
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub connectSC()
        Timer3.Enabled = True
        rtbText.Text = ""
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand = New SqlCommand
        Try
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "update " & tablestr & " set col3 = ' ' where col2 = '" & UserInitials & "'"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
        End Try
        If PrivUser.Trim = Nothing Then
            Timer2.Enabled = True
            Timer1.Enabled = False
            group = True
        Else
            Timer2.Enabled = False
            Timer1.Enabled = True
            group = False
        End If

        txtText.ReadOnly = False
        said = False
        rtbText.AppendText("Connected as " & UserInitials & vbCrLf)
        getOnlineBar()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        closethis()
        Me.Close()
    End Sub


    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = My.Settings.bcolor
        rtbText.BackColor = My.Settings.tcolor
        txtText.BackColor = My.Settings.tcolor
        rtbText.ForeColor = My.Settings.fcolor
        txtText.ForeColor = My.Settings.fcolor
        If testConnection() Then
            getUsername()
            connectSC()
        End If

    End Sub

    Private Function testConnection()
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand = New SqlCommand
        Try
            con.Open()
        Catch ex As SqlException
            MessageBox.Show("Please connect to a valid SQL Database then restart Stat Chat")
            Return False
        Finally
            con.Close()
        End Try
        Return True
    End Function

    Public Sub closethis()
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand = New SqlCommand
        Try
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "update " & tablestr & " set col3 = '129s' where col2 = '" & UserInitials & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "update " & tablestr & " set tstatt = null where col2 = '" & UserInitials & "'"
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Environment.Exit(0)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Dim timen As String = Date.Now.ToShortTimeString.ToString
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand = New SqlCommand
        If count10 < 300 Then
            count10 += 1
        End If
        Try
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "update " & tablestr & " set col3 = ' ' where col2 = '" & UserInitials & "'"
            cmd.ExecuteNonQuery()
            If count10 >= 300 Then
                cmd.CommandText = "update " & tablestr & " set tstatt = null where col2 = '" & UserInitials & "'"
                cmd.ExecuteNonQuery()
                count10 = 0
            End If
            If timen.Contains("6:30") And timen.Contains("PM") And logoff = False Then
                logoff = True
                cmd.CommandText = "update " & tablestr & " set col3 = '129s' where " & userlist & ""
                cmd.ExecuteNonQuery()
                cmd.CommandText = "update " & tablestr & " set tstatt = null where tstatt is not null"
                cmd.ExecuteNonQuery()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
        End Try
        If logoff = True Then
            Me.Close()
        End If
    End Sub


    Private Sub Form2_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Latext2 = False Then
            Exit Sub
        End If
        Dim Latext As String = ""
        If pastSize < Me.Width - 100 Then
            For i As Integer = 0 To rtbText.Text.Length - 1
                If rtbText.Text(i) <> "*" Then
                    Latext += "*" & rtbText.Text(i)
                End If
            Next
            pastSize = Me.Width
            original = Latext
            rtbText.Text = Latext.Replace("*", " ")
        ElseIf pastSize > Me.Width + 100 Then
            rtbText.Text = original.Replace("*", "")
            original = original.Replace(" ", "")
            pastSize = Me.Width
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
            'Uncomment if unknown users should not be allowed to log in
            'Me.Close()
            Dim rand As New Random
            user = "Guest" + rand.Next(0, 1000)
        End If
        UserInitials = user
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        curr.X = 1
        curr.Y = Cursor.Position.Y
        curr1.X = 3838
        curr1.Y = Cursor.Position.Y
        If Cursor.Position.X = 3839 Then
            Cursor.Position = curr
        ElseIf Cursor.Position.X = 0 Then
            Cursor.Position = curr1
        End If
    End Sub

    Private Sub getOnline()
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim da As SqlClient.SqlDataAdapter
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            con.Open()
            da = New SqlClient.SqlDataAdapter("SELECT col2,col3 FROM " & tablestr & " where " & userlist, con)
            da.Fill(ds)
            dt = ds.Tables(0)
        Catch ex As Exception
            txtText.ReadOnly = True
            Timer2.Enabled = False
            MessageBox.Show("Error.")
        Finally
            con.Close()
        End Try
        rtbText.AppendText("Online: ")
        For i As Integer = 0 To dt.Rows.Count - 1
            If dt.Rows(i).Item(0).ToString.Trim <> UserInitials.Trim And dt.Rows(i).Item(1).ToString.Trim <> "129s" Then
                rtbText.AppendText(dt.Rows(i).Item(0).ToString.Trim & " ")
            End If
        Next
        rtbText.AppendText(vbCrLf & "Offline: ")
        For i As Integer = 0 To dt.Rows.Count - 1
            If dt.Rows(i).Item(0).ToString.Trim <> UserInitials.Trim And dt.Rows(i).Item(1).ToString.Trim = "129s" Then
                rtbText.AppendText(dt.Rows(i).Item(0).ToString.Trim & " ")
            End If
        Next
        rtbText.AppendText(vbCrLf)
    End Sub

    Private Sub getOnlineBar()
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim da As SqlClient.SqlDataAdapter
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            con.Open()
            da = New SqlClient.SqlDataAdapter("SELECT col2,col3 FROM " & tablestr & " where " & userlist, con)
            da.Fill(ds)
            dt = ds.Tables(0)
        Catch ex As Exception
            txtText.ReadOnly = True
            Timer2.Enabled = False
            MessageBox.Show("Error.")
        Finally
            con.Close()
        End Try
        Dim userlistt As String = ""
        For i As Integer = 0 To dt.Rows.Count - 1
            If dt.Rows(i).Item(0).ToString.Trim <> UserInitials.Trim And dt.Rows(i).Item(1).ToString.Trim <> "129s" Then
                userlistt += dt.Rows(i).Item(0).ToString.Trim & " "
            End If
        Next
        Me.Text = "Stat Chat - " & userlistt
    End Sub

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

    Private Sub rtbText_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles rtbText.LinkClicked
        If e.LinkText.Contains("\\") And Not Directory.Exists(e.LinkText) Then
            If e.LinkText.Contains("_from_") Then
                Dim usern1 As String = e.LinkText(e.LinkText.Length - 2) & e.LinkText(e.LinkText.Length - 1)
                Dim name1 As String = e.LinkText.Remove(e.LinkText.Length - 2)
                name1 = name1.Replace("_from_", "")
                name1 = name1.Replace("\\", "")
                getAttachment(name1, usern1)
                Exit Sub
            ElseIf Not File.Exists(e.LinkText) Then
                    Exit Sub
            End If
        End If
        Process.Start(e.LinkText)
    End Sub

    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        closethis()
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        connectSC()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        My.Computer.FileSystem.WriteAllText("C:\temp\SCLog.txt", scramble(rtbText.Text & "~" & Date.Now & "~" & vbCrLf), True)
    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        rtbText.AppendText("-" & vbCrLf)
        rtbText.AppendText("Commands: -LOOP- -TMS- -USERS- -AID- -OPEN- -MOUSE- -OGS- FIND( )" & vbCrLf & vbCrLf)
        rtbText.AppendText("Emotes: :) :( -.- pce x( -HAND- -UP- -DOWN- -LEFT- -RIGHT-" & vbCrLf & vbCrLf)
        rtbText.AppendText("Games: -PONG- -TTO- -CARDS- (may not work for all users) -CTF-" & vbCrLf & vbCrLf)
        rtbText.AppendText("Type PING to alert all users" & vbCrLf)
        rtbText.AppendText("Type PC( ) to Private Chat with a user" & vbCrLf)
        rtbText.AppendText("-" & vbCrLf)
    End Sub

    Private Sub ChangeColourToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeColourToolStripMenuItem.Click
        Dim cDialog As New ColorDialog
        cDialog.Color = Me.BackColor
        If cDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.BackColor = cDialog.Color
            My.Settings.bcolor = cDialog.Color
            My.Settings.Save()
        End If
    End Sub

    Private Sub DefaultToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DefaultToolStripMenuItem.Click
        Me.BackColor = SystemColors.Control
        My.Settings.bcolor = SystemColors.Control
        My.Settings.Save()
    End Sub

    Private Sub ScrollToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScrollToolStripMenuItem.Click
        If rtbText.HideSelection = False Then
            ScrollToolStripMenuItem.Checked = False
            rtbText.HideSelection = True
        Else
            ScrollToolStripMenuItem.Checked = True
            rtbText.HideSelection = False
        End If
        txtText.Focus()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim cDialog As New ColorDialog
        cDialog.Color = Me.BackColor
        If cDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            rtbText.BackColor = cDialog.Color
            txtText.BackColor = cDialog.Color
            My.Settings.tcolor = cDialog.Color
            My.Settings.Save()
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        rtbText.BackColor = SystemColors.Window
        txtText.BackColor = SystemColors.Window
        rtbText.ForeColor = SystemColors.WindowText
        txtText.ForeColor = SystemColors.WindowText
        My.Settings.tcolor = SystemColors.Window
        My.Settings.fcolor = SystemColors.WindowText
        My.Settings.Save()
    End Sub

    Private Sub ChangeFontColourToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeFontColourToolStripMenuItem.Click
        rtbText.BorderStyle = BorderStyle.None
        Dim cDialog As New ColorDialog
        cDialog.Color = Me.BackColor
        If cDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            rtbText.ForeColor = cDialog.Color
            txtText.ForeColor = cDialog.Color
            My.Settings.fcolor = cDialog.Color
            My.Settings.Save()
        End If
    End Sub

    Private Sub AttachFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AttachFileToolStripMenuItem.Click
        Timer3.Stop()
        Dim strFilename As String

        SetupFileDialog()

        If ofdAttachment.ShowDialog() = Windows.Forms.DialogResult.OK Then
            strFilename = Microsoft.VisualBasic.Mid(ofdAttachment.FileName, InStrRev(ofdAttachment.FileName, "\") + 1)
            Dim Contents() As Byte
            Try
                Contents = My.Computer.FileSystem.ReadAllBytes(ofdAttachment.FileName)
                Contents = scrambleByte(Contents)
                Dim con As SqlConnection = New SqlConnection(constr)
                Dim cmd As SqlCommand = New SqlCommand
                Try
                    con.Open()
                    cmd = con.CreateCommand()
                    cmd.Parameters.AddWithValue("@byteins", Contents)
                    cmd.CommandText = "update " & tablestr & " set tstatt = @byteins where col2 = '" & UserInitials & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "update " & tablestr & " set col3 = '-g-" & scramble("-at-" & strFilename) & "' where col2 = '" & UserInitials & "'"
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    Throw ex
                Finally
                    con.Close()
                End Try
                rtbText.AppendText(strFilename & " has been sent." & vbCrLf)
            Catch ex As ArgumentException
                Windows.Forms.MessageBox.Show(ex.Message)
                strFilename = ""
            End Try
        Else
        End If
        count10 = 0
        Timer3.Start()
    End Sub

    Private Sub SetupFileDialog()
        ' ofdAttachment.InitialDirectory = "c:\"
        ofdAttachment.Filter = "All files (*.*)|*.*" 'Users are responsible for what file they are choosing.
        ofdAttachment.FilterIndex = 1
        ofdAttachment.RestoreDirectory = True
    End Sub

    Private Sub SetupFileDialog2()
        'ofdAttachment2.InitialDirectory = "c:\"
        ofdAttachment2.Filter = "All files (*.*)|*.*" 'Users are responsible for what file they are choosing.
        ofdAttachment2.FilterIndex = 1
        ofdAttachment2.AddExtension = True
        ofdAttachment2.OverwritePrompt = False
        ofdAttachment2.CreatePrompt = False
        ofdAttachment2.RestoreDirectory = False
    End Sub

    Private Sub getAttachment(name As String, usern1 As String)
        Dim expired As Boolean = False
        If Timer1.Enabled = True Then
            Timer1.Stop()
        End If
        Timer2.Stop()
        Dim attachmentdata() As Byte
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand = New SqlCommand
        Try
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "select tstatt FROM " & tablestr & " where col2 = '" & usern1 & "'"
            attachmentdata = cmd.ExecuteScalar()
            attachmentdata = scrambleByte(attachmentdata)
        Catch ex As Exception
            rtbText.AppendText("This attachment has expired" & vbCrLf)
            expired = True
        Finally
            con.Close()
        End Try
        If expired = False Then
            ofdAttachment2.FileName = name
            If ofdAttachment2.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                My.Computer.FileSystem.WriteAllBytes(ofdAttachment2.FileName, attachmentdata, False)
                Dim psi As System.Diagnostics.ProcessStartInfo = New ProcessStartInfo(ofdAttachment2.FileName, "")
                psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
                psi.CreateNoWindow = False
                psi.UseShellExecute = True
                Process.Start(psi)
            End If
        End If
        Timer2.Start()
        If Timer1.Enabled = True Then
            Timer1.Start()
        End If
    End Sub

    Private Function scrambleByte(attachment As Byte())
        Dim SCByte As Byte()
        SCByte = attachment.Reverse.ToArray
        Return SCByte
    End Function

   
    Private Sub MuteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MuteToolStripMenuItem.Click
        If mute = False Then
            MuteToolStripMenuItem.Checked = True
            mute = True
            Console.Write("true")
        Else
            MuteToolStripMenuItem.Checked = False
            mute = False
            Console.Write("false")
        End If
    End Sub

End Class