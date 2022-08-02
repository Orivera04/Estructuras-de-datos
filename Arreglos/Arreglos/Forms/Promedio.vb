Public Class Promedio
    Dim Contador As Integer
    Dim Mayores As Integer = 0
    Private Sub UltraButton2_Click(sender As Object, e As EventArgs) Handles UltraButton2.Click
        Me.Hide()
    End Sub

    Private Sub UltraButton1_Click(sender As Object, e As EventArgs) Handles UltraButton1.Click
        Principal_Menu.Instancia.Inicio()
        Label4.Text = "Promedio -> " + Principal_Menu.Instancia.F_Promedio(1, 100).ToString + " %"
        Dim Cadena As String = "[  "
        For I = 0 To 9
            For J = 0 To 9
                Cadena = Cadena + Principal_Menu.Instancia.P_Matriz_A(I, J).ToString + "  "
                If (Principal_Menu.Instancia.P_Matriz_A(I, J) > Principal_Menu.Instancia.P_Promedio) Then
                    Mayores += 1
                End If
            Next
        Next
        Cadena = Cadena + vbNewLine + " ]"
        UltraFormattedTextEditor1.Text = Cadena
        Label8.Text = "Superiores al promedio ->  " + Mayores.ToString
        Mayores = 0
        Label5.Visible = False
    End Sub

    Private Sub UltraFormattedTextEditor1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UltraFormattedTextEditor1.KeyPress
        e.Handled = False
    End Sub

    Private Sub UltraButton3_Click(sender As Object, e As EventArgs) Handles UltraButton3.Click
        UltraGroupBox2.Visible = True
        Principal_Menu.Instancia.F_Vector(1, 100)
    End Sub

    Private Sub UltraTextEditor1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UltraTextEditor1.KeyPress
        If (IsNumeric(e.KeyChar) Or e.KeyChar = vbBack Or e.KeyChar = "-" Or e.KeyChar = vbCr) Then
            If (e.KeyChar = vbCr) Then
                UltraButton4.PerformClick()
            End If
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub UltraButton4_Click(sender As Object, e As EventArgs) Handles UltraButton4.Click
        If (UltraTextEditor1.Text <> "") Then
            Principal_Menu.Instancia.P_Vector(Contador) = UltraTextEditor1.Value
            Label6.Text = "Total de Notas ingresados ->  " + (Contador + 1).ToString
            Contador += 1
            If (Contador = 20) Then
                Label4.Text = "Promedio -> " + Principal_Menu.Instancia.F_Promedio(5, 19).ToString + " %"
                UltraButton4.Enabled = False
                Label5.Visible = False
                UltraFormattedTextEditor1.Text = Principal_Menu.Instancia.F_Vector(0, 19)
                Label8.Text = "Superiores al promedio ->  " + Principal_Menu.Instancia.P_Mayores.ToString
                Principal_Menu.Instancia.P_Mayores = 0
            End If
        Else
            MessageBox.Show("No ha introducido ningun valor", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub UltraButton5_Click(sender As Object, e As EventArgs) Handles UltraButton5.Click
        Contador = 0
        UltraGroupBox2.Visible = False
    End Sub

    Private Sub Promedio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class