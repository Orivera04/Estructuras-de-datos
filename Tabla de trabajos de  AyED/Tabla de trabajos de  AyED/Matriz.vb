Public Class Matriz
    Dim Cadena As String = ""
    Private Sub Matriz_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 0 To 3
            Cadena = Cadena + "("
            For j = 0 To 3
                Cadena = Cadena + Principal.Instancia.PMatriz(i, j).ToString + "                             "
            Next
            Cadena = Cadena + " )" + vbNewLine
        Next
        RichTextBox1.Text = Cadena
    End Sub

    Private Sub UltraButton1_Click(sender As Object, e As EventArgs) Handles UltraButton1.Click
        Me.Close()
    End Sub
End Class