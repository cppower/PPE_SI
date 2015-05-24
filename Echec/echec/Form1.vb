
'Imports System.IO.Ports


Public Class Form1

    Dim NORTH As Integer = 100
    Dim NORTH_EAST As Integer = 101
    Dim EAST As Integer = 102
    Dim SOUTH_EAST As Integer = 103
    Dim SOUTH As Integer = 104
    Dim SOUTH_WEST As Integer = 105
    Dim WEST As Integer = 106
    Dim NORTH_WEST As Integer = 107
    Dim CAVALIER_1 As Integer = 110
    Dim CAVALIER_2 As Integer = 111
    Dim CAVALIER_3 As Integer = 112
    Dim CAVALIER_4 As Integer = 113
    Dim CAVALIER_5 As Integer = 114
    Dim CAVALIER_6 As Integer = 115
    Dim CAVALIER_7 As Integer = 116
    Dim CAVALIER_8 As Integer = 117
    Dim NO_MOVE As Integer = 199




    Dim action As Boolean = False
    Dim depart As Integer
    Dim goodtrip As Boolean
    Dim echiquier(7, 7) As String
    Dim currX As Integer = 1
    Dim currY As Integer = 1
    Dim Xarr As Integer = 1
    Dim Yarr As Integer = 1
    Dim butt As Button


    Sub Delay(ByVal dblSecs As Double)

        Const OneSec As Double = 1.0# / (1440.0# * 60.0#)
        Dim dblWaitTil As Date
        Now.AddSeconds(OneSec)
        dblWaitTil = Now.AddSeconds(OneSec).AddSeconds(dblSecs)
        Do Until Now > dblWaitTil
            Application.DoEvents() ' Allow windows messages to be processed
        Loop

    End Sub
    Function init()
        Dim echiquier(7, 7) As String
        echiquier(0, 0) = A1.Text
        echiquier(0, 1) = A2.Text
        echiquier(0, 2) = A3.Text
        echiquier(0, 3) = A4.Text
        echiquier(0, 4) = A5.Text
        echiquier(0, 5) = A6.Text
        echiquier(0, 6) = A7.Text
        echiquier(0, 7) = A8.Text
        echiquier(1, 0) = B1.Text
        echiquier(1, 1) = B2.Text
        echiquier(1, 2) = B3.Text
        echiquier(1, 3) = B4.Text
        echiquier(1, 4) = B5.Text
        echiquier(1, 5) = B6.Text
        echiquier(1, 6) = B7.Text
        echiquier(1, 7) = B8.Text
        echiquier(2, 0) = C1.Text
        echiquier(2, 1) = C2.Text
        echiquier(2, 2) = C3.Text
        echiquier(2, 3) = C4.Text
        echiquier(2, 4) = C5.Text
        echiquier(2, 5) = C6.Text
        echiquier(2, 6) = C7.Text
        echiquier(2, 7) = C8.Text
        echiquier(3, 0) = D1.Text
        echiquier(3, 1) = D2.Text
        echiquier(3, 2) = D3.Text
        echiquier(3, 3) = D4.Text
        echiquier(3, 4) = D5.Text
        echiquier(3, 5) = D6.Text
        echiquier(3, 6) = D7.Text
        echiquier(3, 7) = D8.Text
        echiquier(4, 0) = E1.Text
        echiquier(4, 1) = E2.Text
        echiquier(4, 2) = E3.Text
        echiquier(4, 3) = E4.Text
        echiquier(4, 4) = E5.Text
        echiquier(4, 5) = E6.Text
        echiquier(4, 6) = E7.Text
        echiquier(4, 7) = E8.Text
        echiquier(5, 0) = F1.Text
        echiquier(5, 1) = F2.Text
        echiquier(5, 2) = F3.Text
        echiquier(5, 3) = F4.Text
        echiquier(5, 4) = F5.Text
        echiquier(5, 5) = F6.Text
        echiquier(5, 6) = F7.Text
        echiquier(5, 7) = F8.Text
        echiquier(6, 0) = G1.Text
        echiquier(6, 1) = G2.Text
        echiquier(6, 2) = G3.Text
        echiquier(6, 3) = G4.Text
        echiquier(6, 4) = G5.Text
        echiquier(6, 5) = G6.Text
        echiquier(6, 6) = G7.Text
        echiquier(6, 7) = G8.Text
        echiquier(7, 0) = H1.Text
        echiquier(7, 1) = H2.Text
        echiquier(7, 2) = H3.Text
        echiquier(7, 3) = H4.Text
        echiquier(7, 4) = H5.Text
        echiquier(7, 5) = H6.Text
        echiquier(7, 6) = H7.Text
        echiquier(7, 7) = H8.Text
        Return echiquier
    End Function
    Function coordX(ByVal Button As Button, ByVal X As Integer)
        Dim gauche As Char = coupergauche(Button.Name)
        Select Case gauche
            Case "A"
                X = 0
            Case "B"
                X = 1
            Case "C"
                X = 2
            Case "D"
                X = 3
            Case "E"
                X = 4
            Case "F"
                X = 5
            Case "G"
                X = 6
            Case "H"
                X = 7
        End Select
        Return X
    End Function
    Function coordY(ByVal Button As Button, ByVal Y As Integer)
        Dim droite As Char = couperdroite(Button.Name)
        Select Case droite
            Case "1"
                Y = 0
            Case "2"
                Y = 1
            Case "3"
                Y = 2
            Case "4"
                Y = 3
            Case "5"
                Y = 4
            Case "6"
                Y = 5
            Case "7"
                Y = 6
            Case "8"
                Y = 7
        End Select
        Return Y
    End Function


    Function from(ByVal Buttfrom As Button, ByVal label As Label)
        label.Text = Buttfrom.Text
        currX = coordX(Buttfrom, currX)
        currY = coordY(Buttfrom, currY)
        butt = Buttfrom
    End Function

    Function vers(ByVal Buttto As Button, ByVal label As Label)
        Xarr = coordX(Buttto, Xarr)
        Yarr = coordY(Buttto, Yarr)
        goodtrip = goodmove(Buttto)
        If goodtrip = True Then
            If Buttto.Text <> "" Then
                Label3.Text = Label3.Text + vbNewLine + Buttto.Text
            End If
            Buttto.Text = label.Text
            label.Text = ""
            butt.Text = ""
        Else
            label.Text = ""
            Dim color = Buttto.BackColor
            Buttto.BackColor = color.Red
            Delay(0.5)
            Buttto.BackColor = color
        End If
    End Function

    Function direct(ByVal deltaX As Integer, ByVal deltaY As Integer)
        If deltaX = 0 And deltaY = 0 Then
            Return NO_MOVE
        ElseIf deltaX = 0 Then
            If deltaY < 0 Then
                Return NORTH
            Else
                Return SOUTH
            End If
        ElseIf deltaY = 0 Then
            If deltaX < 0 Then
                Return WEST
            Else
                Return EAST
            End If
        Else
            If deltaX = deltaY And deltaX > 0 Then
                Return SOUTH_EAST
            ElseIf deltaX = deltaY And deltaX < 0 Then
                Return NORTH_WEST
            ElseIf deltaX = -deltaY And deltaX > 0 Then
                Return NORTH_EAST
            ElseIf deltaX = -deltaY And deltaX < 0 Then
                Return SOUTH_WEST
            ElseIf deltaX = 2 And deltaY = 1 Then
                Return CAVALIER_1
            ElseIf deltaX = -2 And deltaY = 1 Then
                Return CAVALIER_2
            ElseIf deltaX = 2 And deltaY = -1 Then
                Return CAVALIER_3
            ElseIf deltaX = -2 And deltaY = -1 Then
                Return CAVALIER_4
            ElseIf deltaX = 1 And deltaY = 2 Then
                Return CAVALIER_5
            ElseIf deltaX = -1 And deltaY = 2 Then
                Return CAVALIER_6
            ElseIf deltaX = 1 And deltaY = -2 Then
                Return CAVALIER_5
            ElseIf deltaX = -1 And deltaY = -2 Then
                Return CAVALIER_8
            Else
                Return NO_MOVE
            End If
        End If
    End Function

    Function passagelibre(ByVal Xarr As Integer, ByVal Yarr As Integer, ByVal direction As Integer)
        If direction = NORTH Then
            For i = Yarr + 1 To currY - 1
                If echiquier(currX, i) <> "" Then
                    Return False
                End If
            Next
            Return True
        ElseIf direction = SOUTH Then
            For i = currY + 1 To Yarr - 1
                If echiquier(currX, i) <> "" Then
                    Return False
                End If
            Next
            Return True
        ElseIf direction = EAST Then
            For i = currX + 1 To Xarr - 1
                If echiquier(i, currY) <> "" Then
                    Return False
                End If
            Next
            Return True
        ElseIf direction = WEST Then
            For i = Xarr + 1 To currX - 1
                If echiquier(i, currY) <> "" Then
                    Return False
                End If
            Next
            Return True
        ElseIf direction = NORTH_WEST Then
            For i = 1 To currX - 1 - Xarr
                If echiquier(currX - i, currY - i) <> "" Then
                    Return False
                End If
            Next
            Return True
        ElseIf direction = SOUTH_EAST Then
            For i = 1 To Xarr - 1 - currX
                If echiquier(currX + i, currY + i) <> "" Then
                    Return False
                End If
            Next
            Return True
        ElseIf direction = SOUTH_WEST Then
            For i = 1 To currX - 1 - Xarr
                If echiquier(currX - i, currY + i) <> "" Then
                    Return False
                End If
            Next
            Return True
        ElseIf direction = NORTH_EAST Then
            For i = 1 To Xarr - currX - 1
                If echiquier(currX + i, currY - i) <> "" Then
                    Return False
                End If
            Next
            Return True
        ElseIf direction = CAVALIER_1 Or CAVALIER_2 Or CAVALIER_3 Or CAVALIER_4 Or CAVALIER_5 Or CAVALIER_6 Or CAVALIER_7 Or CAVALIER_8 Then
            Return True
        Else
            Return False
        End If
    End Function

    Function goodmove(ByVal buttto As Button)
        If echiquier(currX, currY) = "" Or currX < 0 Or currY < 0 Then
            Return False
        End If
        Dim deltaX As Integer = Xarr - currX
        Dim deltaY As Integer = Yarr - currY
        Dim norme As Integer = (deltaX ^ 2 + deltaY ^ 2) ^ (1 / 2)
        Dim team As Char = couperdroite(echiquier(currX, currY))
        If team = "B" Then
            deltaY = -deltaY
        End If
        Dim direction As Integer = direct(deltaX, deltaY)
        Dim piece As String = echiquier(currX, currY)
        If piece = "pion B" Or piece = "Pion N" Then
            If buttto.Text = "" Then
                Dim lim As Integer
                If (piece = "pion B" And currY = 6) Or (piece = "Pion N" And currY = 1) Then
                    lim = 2
                Else
                    lim = 1
                End If
                If direction <> SOUTH Or norme > lim Then
                    Return False
                End If
            Else
                If (direction <> SOUTH_EAST And direction <> SOUTH_WEST) Or norme > 1 Then
                    Return False
                End If
            End If
        ElseIf piece = "fou B" Or piece = "Fou N" Then
            If direction <> NORTH_WEST And direction <> NORTH_EAST And direction <> SOUTH_EAST And direction <> SOUTH_WEST Then
                Return False
            End If
        ElseIf piece = "tour B" Or piece = "Tour N" Then
            If direction <> NORTH And direction <> SOUTH And direction <> EAST And direction <> WEST Then
                Return False
            End If
        ElseIf piece = "cavalier B" Or piece = "Cavalier N" Then
            If direction <> CAVALIER_1 And direction <> CAVALIER_2 And direction <> CAVALIER_3 And direction <> CAVALIER_4 And direction <> CAVALIER_5 And direction <> CAVALIER_6 And direction <> CAVALIER_7 And direction <> CAVALIER_8 Then
                Return False
            End If
        ElseIf piece = "roi B" Or piece = "Roi N" Then
            If norme > 1 Then
                Return False
            End If
        ElseIf piece = "reine B" Or piece = "Reine N" Then
            If direction <> SOUTH And direction <> NORTH And direction <> EAST And direction <> WEST And direction <> SOUTH_EAST And direction <> SOUTH_WEST And direction <> NORTH_EAST And direction <> NORTH_WEST Then
                Return False
            End If
        End If
        If passagelibre(Xarr, Yarr, direction) Then
            Return True
        Else
            Return False
        End If
    End Function




    Private Sub A1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles A1.Click

        echiquier = init()
        If action = False And A1.Text <> "" Then
            from(A1, Label2)
            action = True
        ElseIf action = True Then
            vers(A1, Label2)
            action = False
        End If

    End Sub
    Private Sub A2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles A2.Click
        echiquier = init()
        If action = False And A2.Text <> "" Then
            from(A2, Label2)
            action = True
        ElseIf action = True Then
            vers(A2, Label2)
            action = False
        End If
    End Sub
    Private Sub A3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles A3.Click
        echiquier = init()
        If action = False And A3.Text <> "" Then
            from(A3, Label2)
            action = True
        ElseIf action = True Then
            vers(A3, Label2)
            action = False
        End If
    End Sub
    Private Sub A4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles A4.Click
        echiquier = init()
        If action = False And A4.Text <> "" Then
            from(A4, Label2)
            action = True
        ElseIf action = True Then
            vers(A4, Label2)
            action = False
        End If
    End Sub
    Private Sub A5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles A5.Click
        echiquier = init()
        If action = False And A5.Text <> "" Then
            from(A5, Label2)
            action = True
        ElseIf action = True Then
            vers(A5, Label2)
            action = False
        End If
    End Sub
    Private Sub A6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles A6.Click
        echiquier = init()
        If action = False And A6.Text <> "" Then
            from(A6, Label2)
            action = True
        ElseIf action = True Then
            vers(A6, Label2)
            action = False
        End If
    End Sub
    Private Sub A7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles A7.Click
        echiquier = init()
        If action = False And A7.Text <> "" Then
            from(A7, Label2)
            action = True
        ElseIf action = True Then
            vers(A7, Label2)
            action = False
        End If
    End Sub
    Private Sub A8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles A8.Click
        echiquier = init()
        If action = False And A8.Text <> "" Then
            from(A8, Label2)
            action = True
        ElseIf action = True Then
            vers(A8, Label2)
            action = False
        End If
    End Sub
    Private Sub B1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B1.Click
        echiquier = init()
        If action = False And B1.Text <> "" Then
            from(B1, Label2)
            action = True
        ElseIf action = True Then
            vers(B1, Label2)
            action = False
        End If
    End Sub
    Private Sub B2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B2.Click
        echiquier = init()
        If action = False And B2.Text <> "" Then
            from(B2, Label2)
            action = True
        ElseIf action = True Then
            vers(B2, Label2)
            action = False
        End If
    End Sub
    Private Sub B3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B3.Click
        echiquier = init()
        If action = False And B3.Text <> "" Then
            from(B3, Label2)
            action = True
        ElseIf action = True Then
            vers(B3, Label2)
            action = False
        End If
    End Sub
    Private Sub B4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B4.Click
        echiquier = init()
        If action = False And B4.Text <> "" Then
            from(B4, Label2)
            action = True
        ElseIf action = True Then
            vers(B4, Label2)
            action = False
        End If
    End Sub
    Private Sub B5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B5.Click
        echiquier = init()
        If action = False And B5.Text <> "" Then
            from(B5, Label2)
            action = True
        ElseIf action = True Then
            vers(B5, Label2)
            action = False
        End If
    End Sub
    Private Sub B6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B6.Click
        echiquier = init()
        If action = False And B6.Text <> "" Then
            from(B6, Label2)
            action = True
        ElseIf action = True Then
            vers(B6, Label2)
            action = False
        End If
    End Sub
    Private Sub B7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B7.Click
        echiquier = init()
        If action = False And B7.Text <> "" Then
            from(B7, Label2)
            action = True
        ElseIf action = True Then
            vers(B7, Label2)
            action = False
        End If
    End Sub
    Private Sub B8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B8.Click
        echiquier = init()
        If action = False And B8.Text <> "" Then
            from(B8, Label2)
            action = True
        ElseIf action = True Then
            vers(B8, Label2)
            action = False
        End If
    End Sub
    Private Sub C1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1.Click
        echiquier = init()
        If action = False And C1.Text <> "" Then
            from(C1, Label2)
            action = True
        ElseIf action = True Then
            vers(C1, Label2)
            action = False
        End If
    End Sub
    Private Sub C2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C2.Click
        echiquier = init()
        If action = False And C2.Text <> "" Then
            from(C2, Label2)
            action = True
        ElseIf action = True Then
            vers(C2, Label2)
            action = False
        End If
    End Sub
    Private Sub C3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C3.Click
        echiquier = init()
        If action = False And C3.Text <> "" Then
            from(C3, Label2)
            action = True
        ElseIf action = True Then
            vers(C3, Label2)
            action = False
        End If
    End Sub
    Private Sub C4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C4.Click
        echiquier = init()
        If action = False And C4.Text <> "" Then
            from(C4, Label2)
            action = True
        ElseIf action = True Then
            vers(C4, Label2)
            action = False
        End If
    End Sub
    Private Sub C5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C5.Click
        echiquier = init()
        If action = False And C5.Text <> "" Then
            from(C5, Label2)
            action = True
        ElseIf action = True Then
            vers(C5, Label2)
            action = False
        End If
    End Sub
    Private Sub C6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C6.Click
        echiquier = init()
        If action = False And C6.Text <> "" Then
            from(C6, Label2)
            action = True
        ElseIf action = True Then
            vers(C6, Label2)
            action = False
        End If
    End Sub
    Private Sub C7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C7.Click
        echiquier = init()
        If action = False And C7.Text <> "" Then
            from(C7, Label2)
            action = True
        ElseIf action = True Then
            vers(C7, Label2)
            action = False
        End If
    End Sub
    Private Sub C8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C8.Click
        echiquier = init()
        If action = False And C8.Text <> "" Then
            from(C8, Label2)
            action = True
        ElseIf action = True Then
            vers(C8, Label2)
            action = False
        End If
    End Sub
    Private Sub D1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles D1.Click
        echiquier = init()
        If action = False And D1.Text <> "" Then
            from(D1, Label2)
            action = True
        ElseIf action = True Then
            vers(D1, Label2)
            action = False
        End If
    End Sub
    Private Sub D2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles D2.Click
        echiquier = init()
        If action = False And D2.Text <> "" Then
            from(D2, Label2)
            action = True
        ElseIf action = True Then
            vers(D2, Label2)
            action = False
        End If
    End Sub
    Private Sub D3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles D3.Click
        echiquier = init()
        If action = False And D3.Text <> "" Then
            from(D3, Label2)
            action = True
        ElseIf action = True Then
            vers(D3, Label2)
            action = False
        End If
    End Sub
    Private Sub D4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles D4.Click
        echiquier = init()
        If action = False And D4.Text <> "" Then
            from(D4, Label2)
            action = True
        ElseIf action = True Then
            vers(D4, Label2)
            action = False
        End If
    End Sub
    Private Sub D5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles D5.Click
        echiquier = init()
        If action = False And D5.Text <> "" Then
            from(D5, Label2)
            action = True
        ElseIf action = True Then
            vers(D5, Label2)
            action = False
        End If
    End Sub
    Private Sub D6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles D6.Click
        echiquier = init()
        If action = False And D6.Text <> "" Then
            from(D6, Label2)
            action = True
        ElseIf action = True Then
            vers(D6, Label2)
            action = False
        End If
    End Sub
    Private Sub D7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles D7.Click
        echiquier = init()
        If action = False And D7.Text <> "" Then
            from(D7, Label2)
            action = True
        ElseIf action = True Then
            vers(D7, Label2)
            action = False
        End If
    End Sub
    Private Sub D8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles D8.Click
        echiquier = init()
        If action = False And D8.Text <> "" Then
            from(D8, Label2)
            action = True
        ElseIf action = True Then
            vers(D8, Label2)
            action = False
        End If
    End Sub
    Private Sub E1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles E1.Click
        echiquier = init()
        If action = False And E1.Text <> "" Then
            from(E1, Label2)
            action = True
        ElseIf action = True Then
            vers(E1, Label2)
            action = False
        End If
    End Sub
    Private Sub E2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles E2.Click
        echiquier = init()
        If action = False And E2.Text <> "" Then
            from(E2, Label2)
            action = True
        ElseIf action = True Then
            vers(E2, Label2)
            action = False
        End If
    End Sub
    Private Sub E3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles E3.Click
        echiquier = init()
        If action = False And E3.Text <> "" Then
            from(E3, Label2)
            action = True
        ElseIf action = True Then
            vers(E3, Label2)
            action = False
        End If
    End Sub
    Private Sub E4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles E4.Click
        echiquier = init()
        If action = False And E4.Text <> "" Then
            from(E4, Label2)
            action = True
        ElseIf action = True Then
            vers(E4, Label2)
            action = False
        End If
    End Sub
    Private Sub E5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles E5.Click
        echiquier = init()
        If action = False And E5.Text <> "" Then
            from(E5, Label2)
            action = True
        ElseIf action = True Then
            vers(E5, Label2)
            action = False
        End If
    End Sub
    Private Sub E6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles E6.Click
        echiquier = init()
        If action = False And E6.Text <> "" Then
            from(E6, Label2)
            action = True
        ElseIf action = True Then
            vers(E6, Label2)
            action = False
        End If
    End Sub
    Private Sub E7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles E7.Click
        echiquier = init()
        If action = False And E7.Text <> "" Then
            from(E7, Label2)
            action = True
        ElseIf action = True Then
            vers(E7, Label2)
            action = False
        End If
    End Sub
    Private Sub E8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles E8.Click
        echiquier = init()
        If action = False And E8.Text <> "" Then
            from(E8, Label2)
            action = True
        ElseIf action = True Then
            vers(E8, Label2)
            action = False
        End If
    End Sub
    Private Sub F1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles F1.Click
        echiquier = init()
        If action = False And F1.Text <> "" Then
            from(F1, Label2)
            action = True
        ElseIf action = True Then
            vers(F1, Label2)
            action = False
        End If
    End Sub
    Private Sub F2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles F2.Click
        echiquier = init()
        If action = False And F2.Text <> "" Then
            from(F2, Label2)
            action = True
        ElseIf action = True Then
            vers(F2, Label2)
            action = False
        End If
    End Sub
    Private Sub F3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles F3.Click
        echiquier = init()
        If action = False And F3.Text <> "" Then
            from(F3, Label2)
            action = True
        ElseIf action = True Then
            vers(F3, Label2)
            action = False
        End If
    End Sub
    Private Sub F4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles F4.Click
        echiquier = init()
        If action = False And F4.Text <> "" Then
            from(F4, Label2)
            action = True
        ElseIf action = True Then
            vers(F4, Label2)
            action = False
        End If
    End Sub
    Private Sub F5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles F5.Click
        echiquier = init()
        If action = False And F5.Text <> "" Then
            from(F5, Label2)
            action = True
        ElseIf action = True Then
            vers(F5, Label2)
            action = False
        End If
    End Sub
    Private Sub F6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles F6.Click
        echiquier = init()
        If action = False And F6.Text <> "" Then
            from(F6, Label2)
            action = True
        ElseIf action = True Then
            vers(F6, Label2)
            action = False
        End If
    End Sub
    Private Sub F7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles F7.Click
        echiquier = init()
        If action = False And F7.Text <> "" Then
            from(F7, Label2)
            action = True
        ElseIf action = True Then
            vers(F7, Label2)
            action = False
        End If
    End Sub
    Private Sub F8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles F8.Click
        echiquier = init()
        If action = False And F8.Text <> "" Then
            from(F8, Label2)
            action = True
        ElseIf action = True Then
            vers(F8, Label2)
            action = False
        End If
    End Sub
    Private Sub G1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles G1.Click
        echiquier = init()
        If action = False And G1.Text <> "" Then
            from(G1, Label2)
            action = True
        ElseIf action = True Then
            vers(G1, Label2)
            action = False
        End If
    End Sub
    Private Sub G2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles G2.Click
        echiquier = init()
        If action = False And G2.Text <> "" Then
            from(G2, Label2)
            action = True
        ElseIf action = True Then
            vers(G2, Label2)
            action = False
        End If
    End Sub
    Private Sub G3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles G3.Click
        echiquier = init()
        If action = False And G3.Text <> "" Then
            from(G3, Label2)
            action = True
        ElseIf action = True Then
            vers(G3, Label2)
            action = False
        End If
    End Sub
    Private Sub G4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles G4.Click
        echiquier = init()
        If action = False And G4.Text <> "" Then
            from(G4, Label2)
            action = True
        ElseIf action = True Then
            vers(G4, Label2)
            action = False
        End If
    End Sub
    Private Sub G5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles G5.Click
        echiquier = init()
        If action = False And G5.Text <> "" Then
            from(G5, Label2)
            action = True
        ElseIf action = True Then
            vers(G5, Label2)
            action = False
        End If
    End Sub
    Private Sub G6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles G6.Click
        echiquier = init()
        If action = False And G6.Text <> "" Then
            from(G6, Label2)
            action = True
        ElseIf action = True Then
            vers(G6, Label2)
            action = False
        End If
    End Sub
    Private Sub G7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles G7.Click
        echiquier = init()
        If action = False And G7.Text <> "" Then
            from(G7, Label2)
            action = True
        ElseIf action = True Then
            vers(G7, Label2)
            action = False
        End If
    End Sub
    Private Sub G8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles G8.Click
        echiquier = init()
        If action = False And G8.Text <> "" Then
            from(G8, Label2)
            action = True
        ElseIf action = True Then
            vers(G8, Label2)
            action = False
        End If
    End Sub
    Private Sub H1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles H1.Click
        echiquier = init()
        If action = False And H1.Text <> "" Then
            from(H1, Label2)
            action = True
        ElseIf action = True Then
            vers(H1, Label2)
            action = False
        End If
    End Sub
    Private Sub H2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles H2.Click
        echiquier = init()
        If action = False And H2.Text <> "" Then
            from(H2, Label2)
            action = True
        ElseIf action = True Then
            vers(H2, Label2)
            action = False
        End If
    End Sub
    Private Sub H3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles H3.Click
        echiquier = init()
        If action = False And H3.Text <> "" Then
            from(H3, Label2)
            action = True
        ElseIf action = True Then
            vers(H3, Label2)
            action = False
        End If
    End Sub
    Private Sub H4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles H4.Click
        echiquier = init()
        If action = False And H4.Text <> "" Then
            from(H4, Label2)
            action = True
        ElseIf action = True Then
            vers(H4, Label2)
            action = False
        End If
    End Sub
    Private Sub H5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles H5.Click
        echiquier = init()
        If action = False And H5.Text <> "" Then
            from(H5, Label2)
            action = True
        ElseIf action = True Then
            vers(H5, Label2)
            action = False
        End If
    End Sub
    Private Sub H6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles H6.Click
        echiquier = init()
        If action = False And H6.Text <> "" Then
            from(H6, Label2)
            action = True
        ElseIf action = True Then
            vers(H6, Label2)
            action = False
        End If
    End Sub
    Private Sub H7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles H7.Click
        echiquier = init()
        If action = False And H7.Text <> "" Then
            from(H7, Label2)
            action = True
        ElseIf action = True Then
            vers(H7, Label2)
            action = False
        End If
    End Sub
    Private Sub H8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles H8.Click
        echiquier = init()
        If action = False And H8.Text <> "" Then
            from(H8, Label2)
            action = True
        ElseIf action = True Then
            vers(H8, Label2)
            action = False
        End If
    End Sub

End Class