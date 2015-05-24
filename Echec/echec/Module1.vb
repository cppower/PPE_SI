Module Module1


    Function couperdroite(ByVal mot As String)
        Dim droite As String = Right(mot, 1)
        Return droite
    End Function


    Function coupergauche(ByVal mot As String)
        Dim gauche As String = Left(mot, 1)
        Return gauche
    End Function


End Module
