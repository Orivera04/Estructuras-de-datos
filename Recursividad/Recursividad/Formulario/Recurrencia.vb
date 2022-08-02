Public Class Recurrencia
    Private Sub UltraButton2_Click(sender As Object, e As EventArgs) Handles UltraButton2.Click
        Me.Close()
        Principal.Show()
    End Sub

    Private Sub UltraButton3_Click(sender As Object, e As EventArgs) Handles UltraButton3.Click
        UltraFormattedTextEditor1.Text = ""
        Label5.Visible = True
        DataGridView1.Rows.Clear()
        Label6.Visible = True
    End Sub

    Private Sub UltraButton1_Click(sender As Object, e As EventArgs) Handles UltraButton1.Click
        Label5.Visible = False
        Label6.Visible = False
        Dim N As Integer = (Recursividad.Principal.Instancia.Recurrencia(UltraNumericEditor1.Value))
        Me.UltraFormattedTextEditor1.Text = UltraFormattedTextEditor1.Text + "******************************" + vbNewLine + "[T" + UltraNumericEditor1.Value.ToString + "]" + "=" + N.ToString + vbNewLine + "******************************"
        DataGridView1.Rows.Add("[T" + UltraNumericEditor1.Value.ToString + "]", N.ToString)
    End Sub

    Private Sub UltraNumericEditor1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UltraNumericEditor1.KeyPress
        If (e.KeyChar = vbCr) Then
            UltraButton1.PerformClick()
        End If
    End Sub

    Private Sub UltraGroupBox1_Click(sender As Object, e As EventArgs) Handles UltraGroupBox1.Click

    End Sub
End Class