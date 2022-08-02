Public Class LecturaEscritura
    Dim Contador As Integer = 0
    Private Sub UltraButton2_Click(sender As Object, e As EventArgs) Handles UltraButton2.Click
        Me.Close()
    End Sub

    Private Sub UltraButton1_Click(sender As Object, e As EventArgs) Handles UltraButton1.Click
        If (UltraTextEditor1.Text <> "") Then
            Principal_Menu.Instancia.P_Vector(Contador) = UltraTextEditor1.Value
            Label4.Text = "Total de N° ingresados ->  " + (Contador + 1).ToString
            Contador += 1
            If (Contador = 10) Then
                Label5.Visible = False
                UltraFormattedTextEditor1.Text = Principal_Menu.Instancia.F_Vector(0, 9)
                UltraButton1.Enabled = False
            End If
        Else
            MessageBox.Show("No ha introducido ningun valor", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub UltraNumericEditor1_KeyPress(sender As Object, e As KeyPressEventArgs)
        If (e.KeyChar = vbCr) Then
            UltraButton1.PerformClick()
        End If
    End Sub

    Private Sub UltraButton3_Click(sender As Object, e As EventArgs) Handles UltraButton3.Click
        Principal_Menu.Instancia.F_Vector(1, 9)
        UltraButton1.Enabled = True
        Contador = 0
        Label5.Visible = True
        Label4.Text = "Total de N° ingresados ->  "
        UltraFormattedTextEditor1.Text = ""
        MessageBox.Show("Los datos del vector han sido borrados", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub UltraFormattedTextEditor1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UltraFormattedTextEditor1.KeyPress
        e.Handled = True
    End Sub

    Private Sub UltraTextEditor1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UltraTextEditor1.KeyPress
        If (IsNumeric(e.KeyChar) Or e.KeyChar = vbBack Or e.KeyChar = "-" Or e.KeyChar = vbCr) Then
            If (e.KeyChar = vbCr) Then
                UltraButton1.PerformClick()
            End If
        Else
            e.Handled = True
        End If
    End Sub
End Class