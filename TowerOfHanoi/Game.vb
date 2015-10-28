Public Class Game
    Private piles() As Pile = {New Pile, New Pile, New Pile}

    ''' <summary>
    ''' Constructs a tower with the correct number of pieces.
    ''' </summary>
    ''' <param name="initialHeight"></param>
    Sub New(initialHeight As Integer)
        'Make a pile with the correct pieces
        For x As Integer = initialHeight To 1 Step -1
            piles(0).Add(x)
        Next
    End Sub

    ''' <summary>
    ''' Plays the game.
    ''' </summary>
    Public Sub Play()
        MovePieces(0, 2, piles(0).Height)
        Console.WriteLine(ToString)
    End Sub

    ''' <summary>
    ''' Moves the specified number of pieces from the source pile to the target pile.
    ''' </summary>
    ''' <param name="srcPileIndex">the pile to get pieces out of</param>
    ''' <param name="trgtPileIndex">the pile to put the pieces in</param>
    ''' <param name="count">the number of pieces to move</param>
    Private Sub MovePieces(srcPileIndex As Integer, trgtPileIndex As Integer, count As Integer)
        Console.WriteLine(ToString)
        Console.WriteLine("-------")

        If count > piles(srcPileIndex).Height Then
            Throw New ArgumentOutOfRangeException("count", "The count must be no larger than the source pile's height")
        End If
        Dim helperPileIndex As Integer = CalculateHelperPile(srcPileIndex, trgtPileIndex)
        Dim src As Pile = piles(srcPileIndex)
        Dim trgt As Pile = piles(trgtPileIndex)
        Dim helper As Pile = piles(helperPileIndex)

        'Trivial case
        If count = 1 Then
            Dim tempPiece As Integer = src.Take

            If Not trgt.Add(tempPiece) Then
                'Put the piece back on the source pile in case the parent handles this exception
                src.Add(tempPiece)
                Throw New Exception("The source piece is too large to fit on the target pile.")
            End If
            'The piece has been successfully moved, we are done here.
            Return
        End If

        ' 1. move count - 1 to the helper pile
        ' 2. move the last piece to the target pile
        ' 3. move count - 1 from the helper pile to the target pile
        MovePieces(srcPileIndex, helperPileIndex, count - 1)
        MovePieces(srcPileIndex, trgtPileIndex, 1)
        MovePieces(helperPileIndex, trgtPileIndex, count - 1)
    End Sub

    ''' <summary>
    ''' Calculates the pile to use as an intermediate location.  It is the pile that is not the source or target.
    ''' </summary>
    ''' <param name="srcPile">the source pile that is being worked with</param>
    ''' <param name="trgtPile">the target pile that is being worked with</param>
    ''' <returns>the index of the pile to use as a helper pile</returns>
    Private Function CalculateHelperPile(srcPile As Integer, trgtPile As Integer) As Integer
        Select Case srcPile
            Case 0
                Select Case trgtPile
                    Case 1
                        Return 2
                    Case 2
                        Return 1
                End Select
            Case 1
                Select Case trgtPile
                    Case 0
                        Return 2
                    Case 2
                        Return 0
                End Select
            Case 2
                Select Case trgtPile
                    Case 0
                        Return 1
                    Case 1
                        Return 0
                End Select
        End Select
    End Function

    Public Overrides Function ToString() As String
        Return piles(0).ToString & vbCrLf & piles(1).ToString & vbCrLf & piles(2).ToString
    End Function

End Class
