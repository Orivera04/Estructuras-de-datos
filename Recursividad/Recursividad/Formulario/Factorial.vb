Public Class LecturaEscritura
    Dim Contador As Integer = 0
    Private Sub UltraButton2_Click(sender As Object, e As EventArgs) Handles UltraButton2.Click
        Me.Close()
        Principal.Show()
    End Sub

    Private Sub UltraButton1_Click(sender As Object, e As EventArgs) Handles UltraButton1.Click
        Label5.Visible = False
        Label6.Visible = False
        Dim Cadena As String = ""
        For I = Val(UltraNumericEditor1.Value) To 1 Step -1
            Cadena = Cadena + I.ToString + "*"
        Next
        Me.UltraFormattedTextEditor1.Text = UltraFormattedTextEditor1.Text + "******************************" + vbNewLine + UltraNumericEditor1.Value.ToString + "!~" + Cadena + "=" + (Recursividad.Principal.Instancia.Factor(UltraNumericEditor1.Value)).ToString + vbNewLine + "******************************"
        DataGridView1.Rows.Add("!" + UltraNumericEditor1.Value.ToString, Recursividad.Principal.Instancia.Factor(UltraNumericEditor1.Value).ToString)
        Contador += 1
        Label4.Text = "Total de N° ingresados ->  " + Contador.ToString
    End Sub
    Private Sub UltraButton3_Click(sender As Object, e As EventArgs) Handles UltraButton3.Click
        UltraFormattedTextEditor1.Text = ""
        Contador = 0
        Label4.Text = "Total de N° ingresados ->  0"
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