Public Class Fibonacci
    Private Sub UltraButton2_Click(sender As Object, e As EventArgs) Handles UltraButton2.Click
        Me.Close()
        Principal.Show()
    End Sub

    Private Sub UltraButton1_Click(sender As Object, e As EventArgs) Handles UltraButton1.Click
        Label5.Visible = False
        Label6.Visible = False
        Me.UltraFormattedTextEditor1.Text = UltraFormattedTextEditor1.Text + "******************************" + vbNewLine + "F" + UltraNumericEditor1.Value.ToString + "=" + (Recursividad.Principal.Instancia.Fib(UltraNumericEditor1.Value)).ToString + vbNewLine + "******************************"
        DataGridView1.Rows.Add("F" + UltraNumericEditor1.Value.ToString, Recursividad.Principal.Instancia.Fib(UltraNumericEditor1.Value).ToString)
    End Sub

    Private Sub UltraButton3_Click(sender As Object, e As EventArgs) Handles UltraButton3.Click
        UltraFormattedTextEditor1.Text = ""
        Label5.Visible = True
        DataGridView1.Rows.Clear()
        Label6.Visible = True
    End Sub

    Private Sub UltraNumericEditor1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UltraNumericEditor1.KeyPress
        If (e.KeyChar = vbCr) Then
            UltraButton1.PerformClick()
        End If
    End Sub
End Class