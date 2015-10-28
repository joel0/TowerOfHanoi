Public Class Pile
    Private Contents As New Stack(Of Integer)

    ''' <summary>
    ''' Returns the number of pieces in this pile.
    ''' </summary>
    ''' <returns>the number of pieces in this pile</returns>
    Public ReadOnly Property Height As Integer
        Get
            Return Contents.Count
        End Get
    End Property

    ''' <summary>
    ''' Adds a pice to this pile if the piece is not larger than the top piece in this pile.
    ''' </summary>
    ''' <param name="width">the width of the piece to add</param>
    ''' <returns>true if the piece has been added, false if the piece has not been added because it's larger than the top item</returns>
    Public Function Add(width As Integer) As Boolean
        If Contents.Count = 0 Then
            Contents.Push(width)
            Return True
        Else
            If width > Contents.Peek Then
                Return False
            Else
                Contents.Push(width)
                Return True
            End If
        End If
    End Function

    ''' <summary>
    ''' Takes the top piece off this pile.
    ''' </summary>
    ''' <returns>the width of the piece that was taken off</returns>
    Public Function Take() As Integer
        Return Contents.Pop
    End Function

    ''' <summary>
    ''' Returns the maximum width in this pile.
    ''' </summary>
    ''' <returns>the maximum width of the pieces in this pile</returns>
    Public Function MaxWidth() As Integer
        Return Contents.Max
    End Function

    Public Overrides Function ToString() As String
        If Contents.Count = 0 Then
            ' Empty tower
            Return "|" & vbCrLf
        End If
        Dim out As String = ""
        For Each width As Integer In Contents
            out += RepeatString(width, "#") & vbCrLf
        Next
        Return out
    End Function

    Private Function RepeatString(count As Integer, data As String) As String
        Dim out As String = ""
        For x As Integer = 0 To count - 1
            out += data
        Next
        Return out
    End Function
End Class
