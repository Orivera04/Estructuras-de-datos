Public Class Suma
    Private Sub UltraButton1_Click(sender As Object, e As EventArgs) Handles UltraButton1.Click
        Label5.Visible = False
        Label6.Visible = False
        Me.UltraFormattedTextEditor1.Text = UltraFormattedTextEditor1.Text + "******************************" + vbNewLine + "Suma(" + UltraNumericEditor1.Value.ToString + "," + UltraNumericEditor2.Value.ToString + ")" + " = " + (Recursividad.Principal.Instancia.Suma(UltraNumericEditor1.Value, UltraNumericEditor2.Value)).ToString + vbNewLine + "******************************"
        DataGridView1.Rows.Add("(" + UltraNumericEditor1.Value.ToString + "," + UltraNumericEditor2.Value.ToString + ")", Recursividad.Principal.Instancia.Suma(UltraNumericEditor1.Value, UltraNumericEditor2.Value).ToString)
    End Sub

    Private Sub UltraGroupBox1_Click(sender As Object, e As EventArgs) Handles UltraGroupBox1.Click

    End Sub

    Private Sub UltraButton2_Click(sender As Object, e As EventArgs) Handles UltraButton2.Click
        Me.Hide()
        Principal.Show()
    End Sub

    Private Sub UltraButton3_Click(sender As Object, e As EventArgs) Handles UltraButton3.Click
        UltraFormattedTextEditor1.Text = ""
        Label5.Visible = True
        DataGridView1.Rows.Clear()
        Label6.Visible = True
    End Sub

    Private Sub UltraNumericEditor1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UltraNumericEditor1.KeyPress
        If (e.KeyChar = vbCr) Then
            UltraNumericEditor2.Focus()
        End If
    End Sub

    Private Sub UltraNumericEditor2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UltraNumericEditor2.KeyPress
        If (e.KeyChar = vbCr) Then
            UltraButton1.PerformClick()
        End If
    End Sub
End Class