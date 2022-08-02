Public Class Identidad
    Private Sub UltraNumericEditor1_KeyPress(sender As Object, e As KeyPressEventArgs)
        If (e.KeyChar = vbCr) Then
            UltraButton1.PerformClick()
        End If
    End Sub

    Private Sub UltraButton1_Click(sender As Object, e As EventArgs) Handles UltraButton1.Click

        UltraFormattedTextEditor1.Text = Principal_Menu.Instancia.Identidad((UltraNumericEditor1.Value) - 1)
        Label5.Visible = False
    End Sub

    Private Sub UltraNumericEditor1_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles UltraNumericEditor1.KeyPress
        If (e.KeyChar = vbCr) Then
            UltraButton1.PerformClick()
        End If
    End Sub

    Private Sub UltraButton2_Click(sender As Object, e As EventArgs) Handles UltraButton2.Click
        Me.Close()
    End Sub

    Private Sub UltraFormattedTextEditor1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UltraFormattedTextEditor1.KeyPress
        e.Handled = True
    End Sub
End Class