Module Main

    Sub Main()
        'Dim p1 As New Pile
        'Dim p2 As New Pile
        'Dim p3 As New Pile
        'p1.Add(2)
        'p1.Add(1)
        'Tests()
        Dim g As New Game(5)
        g.Play()
        Console.ReadLine()
    End Sub

    ''' <summary>
    ''' Tests on the objects.
    ''' </summary>
    Private Sub Tests()
        Dim g As New Game(5)
        Console.WriteLine(g.ToString)

        Dim p1 As New Pile
        If (Not p1.Add(5)) Then
            Console.WriteLine("Adding a piece to an empty pile should work.")
        End If
        If (Not p1.Add(4)) Then
            Console.WriteLine("Adding a smaller piece to a pile should work.")
        End If
        If (Not p1.Add(4)) Then
            Console.WriteLine("Adding an equal size piece to a pile should work.")
        End If
        If (p1.Add(10)) Then
            Console.WriteLine("Adding a larger pice to a pile should not work.")
        End If

        Console.WriteLine(p1.ToString)
    End Sub

End Module
