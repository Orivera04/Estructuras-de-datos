Public Class Busqueda
    Private Sub Busqueda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UltraComboEditor1.Text = UltraComboEditor1.Items.Item(0).ToString
        UltraGroupBox3.Visible = False
        UltraFormattedTextEditor1.Text = ""
        Label5.Visible = True
    End Sub

    Private Sub UltraButton8_Click(sender As Object, e As EventArgs) Handles UltraButton8.Click
        UltraGroupBox3.Visible = False
    End Sub

    Private Sub UltraButton1_Click(sender As Object, e As EventArgs) Handles UltraButton1.Click
        Try
            Arreglos.Principal_Menu.Instancia.Llenar_Vector()
            UltraFormattedTextEditor1.Text = Arreglos.Principal_Menu.Instancia.Imprimir()
            Label5.Visible = False
            UltraGroupBox3.Visible = True
        Catch

        End Try
    End Sub

    Private Sub UltraButton2_Click(sender As Object, e As EventArgs) Handles UltraButton2.Click
        Me.Close()
    End Sub

    Private Sub UltraButton7_Click(sender As Object, e As EventArgs) Handles UltraButton7.Click
        Label4.Visible = False
        Principal_Menu.Instancia.Iteraciones = 0
        If (UltraComboEditor1.SelectedIndex() = 0) Then
            If (Arreglos.Principal_Menu.Instancia.Busqueda_Secuencial(98, UltraNumericEditor1.Value) <> -1) Then
                MessageBox.Show("Elemento Encontrado en posición - >" + Arreglos.Principal_Menu.Instancia.Busqueda_Secuencial(98, UltraNumericEditor1.Value).ToString, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Label4.Text = "Iteraciones: " + Arreglos.Principal_Menu.Instancia.Iteraciones.ToString
            Else
                MessageBox.Show("Elemento No Encontrado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        ElseIf (UltraComboEditor1.SelectedIndex = 1) Then
            Arreglos.Principal_Menu.Instancia.ShellSort1()
            If (Arreglos.Principal_Menu.Instancia.Busqued_Binaria(UltraNumericEditor1.Value) <> -1) Then
                MessageBox.Show("Elemento Encontrado ", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Label4.Text = "Iteraciones: " + Arreglos.Principal_Menu.Instancia.Iteraciones.ToString
                Label4.Visible = True
            Else
                MessageBox.Show("Elemento No Encontrado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            'Else
            '    If (Arreglos.Principal_Menu.Instancia.Busqueda_Centinela(UltraNumericEditor1.Value, 99) <> -1) Then
            '        MessageBox.Show("Elemento Encontrado ", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Else
            '        MessageBox.Show("Elemento No Encontrado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    End If
        End If
    End Sub

    Private Sub UltraComboEditor1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UltraComboEditor1.KeyPress
        If (e.KeyChar = vbCr) Then
            UltraNumericEditor1.Focus()
        End If
    End Sub

    Private Sub UltraNumericEditor1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UltraNumericEditor1.KeyPress
        If (e.KeyChar = vbCr) Then
            UltraButton7.PerformClick()
        End If
    End Sub
End Class