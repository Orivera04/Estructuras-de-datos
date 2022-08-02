Public Class Matriz_Principal

    Private Sub UltraButton1_Click(sender As Object, e As EventArgs) Handles UltraButton1.Click
        Principal_Menu.Instancia.Inicializar(4, 3)
        Dim Cadena As String = "[  "
        For I = 0 To 5
            For J = 0 To 4
                Cadena = Cadena + Principal_Menu.Instancia.P_Matriz_A(I, J).ToString + "  "
            Next
            Cadena = Cadena + " ]"
            If Not (I < 5) Then
            Else
                Cadena = Cadena + vbNewLine + "[  "
            End If
            UltraFormattedTextEditor1.Text = Cadena
            Label5.Visible = False
            UltraButton1.Enabled = False
        Next
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub UltraButton2_Click(sender As Object, e As EventArgs) Handles UltraButton2.Click
        Me.Close()
    End Sub
End Class