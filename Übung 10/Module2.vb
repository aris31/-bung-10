Module Module2

    Class Punkt
        Public Property Punktnummer As Integer = 0
        Public Property Rechtswert As Integer = 0
        Public Property Hochwert As Integer = 0
        Public Property Hoehe As Integer = 0

        ' Punktnummer Konstruktor
        Sub New(ByVal pNr As Integer)
            Punktnummer = checkParam(pNr)
        End Sub

        ' Punktnummer, Rechtswert und Hochwert Konstruktor
        Sub New(ByVal pNr As Integer, ByVal rWert As Integer, ByVal hWert As Integer)
            Punktnummer = checkParam(pNr)
            Rechtswert = rWert
            Hochwert = hWert
        End Sub

        ' Punktnummer, Rechtswert, Hochwert und Hoehe Konstruktor
        Sub New(ByVal pNr As Integer, ByVal rWert As Integer, ByVal hWert As Integer, ByVal h As Integer)
            Punktnummer = checkParam(pNr)
            Rechtswert = rWert
            Hochwert = hWert
            Hoehe = h
        End Sub

        ' private Methode zum Pruefen der Konstruktoren Parameter
        ' nur nicht negative integer sind als parameter erlaubt
        Private Function checkParam(ByVal val As Integer)
            If val >= 0 Then
                Return val
            Else
                Throw New SystemException("Ungueltiger Parameter")
            End If
        End Function


        ' Methode berechne Strecke zu zweiten Punkt
        Public Function berechneStrecke(ByVal P As Punkt)
            Dim a As Integer = P.Rechtswert - Rechtswert
            Dim b As Integer = P.Hochwert - Hochwert

            'c = Wurzel aus a^2 + b^2
            Dim c As Double = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2))
            Return c
        End Function

        ' Methode Richtungswinkel zu zweiten Punkt
        Public Function berechneWinkel(ByVal P As Punkt)
            Dim alpha As Double
            ' hier muss noch Code und Fehlerbehandlung eingefuegt werden
            Return alpha
        End Function

        ' Methode polares Anhaengen eines Punktes
        Public Sub punktAnhaengen(ByVal P As Punkt)
            ' hier Code/Fehlerbehandlung einfuegen
        End Sub

    End Class



    Sub Main()
        ' Code um alle Sonderfaelle zu testen, mit Fehlerbehandlung
        ' zum Beispiel
        Dim a As Punkt

        Try
            ' -12 ist nicht erlaubt als Punkt nummer, wir erwarten also eine Ausnahme
            a = New Punkt(-12, 13, 13)
        Catch e As SystemException
            Console.WriteLine("Fehler beim Initialisieren von Punkt a")
            Console.WriteLine(e.Message)
        End Try




        ' Ueberpruefung der Richtigkeit der Funktionenen

    End Sub

End Module
