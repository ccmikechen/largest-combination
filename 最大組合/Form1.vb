Imports System.IO
Public Class Form1
    Dim sw As New StreamWriter("out.txt")
    Dim sr As New StreamReader("in.txt")
    Sub check()
        Dim str As String = sr.ReadLine
        Dim M() As String = Split(str, " ")
        Dim A(UBound(M), UBound(M)) As Integer

        For i = 0 To UBound(M)
            For j = 0 To UBound(M) - i
                Dim max As Integer = 0
                If i <= 1 Then
                    For k = j To j + i
                        max += Val(M(k))
                    Next
                Else
                    Dim sum As Integer = 0
                    For k = j To j + i
                        If k = j Then
                            sum = A(i - 1, j + 1)
                        ElseIf k = j + i Then
                            sum = A(i - 1, j)
                        Else
                            sum = A(k - 1 - j, j) + A(j + i - k - 1, k + 1)
                        End If
                        If sum > max Then max = sum
                    Next
                End If
                A(i, j) = max
            Next
        Next
        sw.WriteLine(A(UBound(M), 0))

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Do While sr.Peek > -1
            check()
        Loop
        sw.Flush() : End
    End Sub

    
End Class
