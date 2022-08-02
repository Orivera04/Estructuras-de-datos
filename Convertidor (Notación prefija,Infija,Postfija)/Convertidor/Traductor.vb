Public Class Traductor
    Dim Instancia As New Traductor___Clase()
    Private Sub ultraButton12_Click(sender As Object, e As EventArgs) Handles ultraButton12.Click
        If (UltraTextEditor1.Text <> "") Then
            If (Instancia.Validar(UltraTextEditor1.Text) = 1) Then
                Label4.Visible = False
                Label5.Visible = False
                If (MetroRadioButton1.Checked) Then
                    UltraFormattedTextEditor3.Text = Instancia.Infija_A_Prefija(UltraTextEditor1.Text.Replace(" ", "").ToString)
                Else
                    UltraFormattedTextEditor3.Text = Instancia.Infija_A_Postfija(UltraTextEditor1.Text.Replace(" ", "")).ToString
                End If
            Else
                MessageBox.Show("Ingrese una expresión valida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("No se ha ingresado ninguna expresión", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub UltraButton3_Click(sender As Object, e As EventArgs) Handles UltraButton3.Click
        UltraFormattedTextEditor3.Text = ""
        Label4.Visible = True
        DataGridView1.Rows.Clear()
        Label5.Visible = True
    End Sub

    Private Sub UltraTextEditor1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UltraTextEditor1.KeyPress
        If (e.KeyChar = vbCr) Then
            ultraButton12.PerformClick()
        End If
    End Sub

    Private Sub MetroListView1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Traductor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MetroTabControl1.SelectedTab = MetroTabPage2
        UltraTextEditor1.Focus()
        Me.StartPosition = FormStartPosition.CenterScreen
    End Sub
End Class
