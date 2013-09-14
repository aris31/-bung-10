Module Module1

    Class Punkt
        Public Property x1 As Integer
        Public Property y1 As Integer

        Sub New(ByVal x As Integer, ByVal y As Integer)
            x1 = x
            y1 = y
        End Sub

        Sub New(ByVal P As Punkt)
            x1 = P.x1
            y1 = P.y1
        End Sub

        Public Function berechneEntfernung(ByVal P As Punkt)
            Dim a As Integer = P.x1 - x1
            Dim b As Integer = P.y1 - y1

            'Bedeutet: c = Wurzel aus a^2 + b^2
            Dim c As Double = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2))
            Return c
        End Function
    End Class

    Class Kreis
        Public Property mittelpunkt As Punkt
        Private radius As Double
        Private umfang As Double
        Private flaeche As Double


        Sub New(ByVal r As Double, ByVal p As Punkt)
            mittelpunkt = p
            setRadius(r)
            umfang = 2 * Math.PI * r
            flaeche = Math.PI * r ^ 2
        End Sub

        ' Eine Setter Methode fuer den Radius (Kapselung)
        Public Sub setRadius(ByVal r As Double)
            If (r >= 0) Then
                radius = r
            Else
                Throw New SystemException("Ungueltiger Radius")
            End If
        End Sub

        ' getter Methode fuer den Radius
        Public Function getRadius() As Double
            Return radius
        End Function

        ' getter fuer Umfang
        Public Function getUmfang() As Double
            Return umfang
        End Function

        ' getter der Flaeche
        Public Function getFlaeche() As Double
            Return flaeche
        End Function

        ' Test ob Kreis groesser ist
        Public Function vergleicheKreis(ByVal aKreis As Kreis) As Boolean
            If radius > aKreis.getRadius() Then
                Return True
            Else
                Return False
            End If
        End Function

        ' Test ob Punkt innerhalb eines Kreises liegt
        Public Function testPunkt(ByVal p As Punkt) As Boolean
            Dim mdelta As Double = mittelpunkt.berechneEntfernung(p)
            If mdelta < radius Then
                Return True
            Else
                Return False
            End If 
            Return True
        End Function

        Public Function testKreis(ByVal aKreis As Kreis) As Integer
            Dim d As Double = mittelpunkt.berechneEntfernung(aKreis.mittelpunkt)
            Dim R As Double = aKreis.getRadius
            ' Fall 1 Kreis liegt innerhalb des zweiten Kreises. 
            ' Fall 2 Kreis schneidet den zweiten Kreis.
            ' Fall 3 Kreis liegt ausserhalb des zweiten Kreises.
            If d + radius < R Then
                Return 0
            ElseIf d + radius > R And d - radius < R Then
                Return 1
            ElseIf d - radius > R Then
                Return 2
            Else
                Return 3
            End If
        End Function


    End Class

    Sub Main()
        Dim P1 As Punkt = Nothing
        Dim P2 As Punkt = Nothing
        Dim EntfernungP1P2 As Double = Nothing
        
        P1 = New Punkt(5, 2)
        P2 = New Punkt(1, 2)
        EntfernungP1P2 = P1.berechneEntfernung(P2)

        If EntfernungP1P2 = 4 Then
            Console.WriteLine("Entfernung ok.")
        Else
            Console.WriteLine("Entfernung fehlerhaft.")
        End If

        EntfernungP1P2 = P1.berechneEntfernung(P2)
        Console.WriteLine(EntfernungP1P2)

        Dim P3 As Punkt = New Punkt(0, 0)
        Dim P4 As Punkt = New Punkt(5, 6)
        Dim K1 As Kreis = New Kreis(1, P3)

        ' Ueberpruefe Umfang
        If K1.getUmfang = 2 * Math.PI Then
            Console.WriteLine("Umfangberechnung ok.")
        Else
            Console.WriteLine("Umfangberechnung fehlerhaft.")
        End If

        ' Ueberpreufe Flaeche: Pi
        If K1.getFlaeche = Math.PI Then
            Console.WriteLine("Flaechenberechnung ok.")
        Else
            Console.WriteLine("Flaechenberechnung fehlerhaft.")
        End If

        ' Test ob Kreis groesser ist
        Dim K2 As Kreis = New Kreis(3, P4)
        If K1.vergleicheKreis(K2) = False Then
            Console.WriteLine("Kreisvergleich ok.")
        Else
            Console.WriteLine("Kreisvergleich fehlerhaft.")
        End If

        ' Test ob Punkt innerhalb eines Kreises liegt
        Dim K3 As Kreis = New Kreis(3, New Punkt(2, 1))
        If K3.testPunkt(P2) = True Then
            Console.WriteLine("Test Punkt innerhalb Kreis ok.")
        Else
            Console.WriteLine("Test Punkt innerhalb Kreis fehlerhaft.")
        End If

        ' Test Kreis innerhalb des Kreises
        Dim K4 As Kreis = New Kreis(2, New Punkt(0, 0))
        Dim K5 As Kreis = New Kreis(4, New Punkt(0, 0))
        If K4.testKreis(K5) = 0 Then
            Console.WriteLine("Test Kreis innerhalb ok.")
        Else
            Console.WriteLine("Test Kreis innerhalb fehlerhaft.")
        End If

        'Test ob Kreis schneidet
        Dim K6 As Kreis = New Kreis(2, New Punkt(0, 0))
        Dim K7 As Kreis = New Kreis(2, New Punkt(1, 1))
        If K6.testKreis(K7) = 1 Then
            Console.WriteLine("Test Kreis schneidet ok.")
        Else
            Console.WriteLine("Test Kreis schneidet fehlerhaft.")
        End If

        'Test ob Kreis außerhalb liegt
        Dim K8 As Kreis = New Kreis(2, New Punkt(0, 0))
        Dim K9 As Kreis = New Kreis(1, New Punkt(5, 5))
        If K8.testKreis(K9) = 2 Then
            Console.WriteLine("Test Kreis außerhalb ok.")
        Else
            Console.WriteLine("Test Kreis außerhalb fehlerhaft.")
        End If

        Console.ReadKey()
    End Sub

End Module
