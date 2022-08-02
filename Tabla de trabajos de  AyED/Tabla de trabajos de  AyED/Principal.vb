Public Class Principal
    Public Instancia As New Datos()
    Private Sub UltraButton2_Click(sender As Object, e As EventArgs) Handles UltraButton2.Click
        If (UltraTextEditor1.Text <> "" And UltraTextEditor2.Text <> "" And UltraTextEditor3.Text <> "") Then
            Instancia.PNombre = UltraTextEditor1.Text
            Instancia.PCodigo = UltraTextEditor3.Text
            Instancia.PGrupo = UltraTextEditor2.Text
            Instancia.PNota = UltraNumericEditor1.Value
            Instancia.Insertar()
            DataGridView1.DataSource = Instancia.Inicio()
            Instancia.Nombres()
            UltraComboEditor1.DataSource = Instancia.Nombres()
            UltraComboEditor1.Text = UltraComboEditor1.Items.Item(0).ToString
            UltraComboEditor2.DataSource = Instancia.Nombres()
            UltraComboEditor2.Text = UltraComboEditor2.Items.Item(0).ToString
            MessageBox.Show("Información añadida con exito", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Algunos campos estan vacios", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub UltraTextEditor1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UltraTextEditor1.KeyPress
        If (e.KeyChar = vbCr) Then
            UltraTextEditor3.Focus()
        End If
    End Sub

    Private Sub UltraTextEditor3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UltraTextEditor3.KeyPress
        If (e.KeyChar = vbCr) Then
            UltraTextEditor2.Focus()
        End If
    End Sub

    Private Sub UltraTextEditor2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UltraTextEditor2.KeyPress
        If (e.KeyChar = vbCr) Then
            UltraNumericEditor1.Focus()
        End If
    End Sub

    Private Sub UltraTextEditor4_KeyPress(sender As Object, e As KeyPressEventArgs)
        If (e.KeyChar = vbCr) Then
            UltraButton2.PerformClick()
        End If
    End Sub

    Private Sub UltraButton1_Click(sender As Object, e As EventArgs) Handles UltraButton1.Click
        If (MetroRadioButton1.Checked) Then
            Panel3.Visible = False
        ElseIf (MetroRadioButton4.Checked) Then
            Panel3.Visible = True
        End If
    End Sub

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel3.Visible = False
        DataGridView1.DataSource = Instancia.Inicio()
        UltraComboEditor1.DataSource = Instancia.Nombres()
        UltraComboEditor1.Text = UltraComboEditor1.Items.Item(0).ToString
        UltraComboEditor2.DataSource = Instancia.Nombres()
        UltraComboEditor2.Text = UltraComboEditor2.Items.Item(0).ToString
        Call UltraButton5_Click(Nothing, Nothing)
    End Sub
    Private Sub UltraNumericEditor1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UltraNumericEditor1.KeyPress
        If (e.KeyChar = vbCr) Then
            UltraButton2.PerformClick()
        End If
    End Sub

    Private Sub MetroRadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles MetroRadioButton1.CheckedChanged
        If (MetroRadioButton1.Checked) Then
            Panel3.Visible = False
        End If
    End Sub

    Private Sub MetroRadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles MetroRadioButton4.CheckedChanged
        If (MetroRadioButton4.Checked) Then
            Panel4.Visible = False
            Panel3.Visible = True
        End If
    End Sub

    Private Sub MetroRadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles MetroRadioButton2.CheckedChanged
        If (MetroRadioButton2.Checked) Then
            Panel3.Visible = True
            Panel4.Visible = True
            Panel5.Visible = False
        End If
    End Sub

    Private Sub UltraButton5_Click(sender As Object, e As EventArgs) Handles UltraButton5.Click
        If (Instancia.Información(UltraComboEditor1.Text) = 1) Then
            UltraTextEditor6.Text = Instancia.PNombre
            UltraTextEditor4.Text = Instancia.PCodigo
            UltraTextEditor5.Text = Instancia.PGrupo
            UltraNumericEditor2.Value = Instancia.PNota
        End If
    End Sub

    Private Sub UltraComboEditor1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UltraComboEditor1.KeyPress
        If (e.KeyChar = vbCr) Then
            UltraButton5.PerformClick()
        End If
    End Sub

    Private Sub UltraButton4_Click(sender As Object, e As EventArgs) Handles UltraButton4.Click
        If (UltraTextEditor4.Text <> "" And UltraTextEditor5.Text <> "") Then
            If (Instancia.Op("update Notas set Codigo ='" + UltraTextEditor4.Text + "',Grupo='" + UltraTextEditor5.Text + "',Nota='" + UltraNumericEditor2.Value.ToString + "' where Nombre ='" + UltraTextEditor6.Text + "'") = 1) Then
                Instancia.Inicio()
                MessageBox.Show("Actualizado con exito", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Error -> Revisa que hallas introducido bien los datos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Algunos campos estan vacios", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub UltraTextEditor4_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles UltraTextEditor4.KeyPress
        If (e.KeyChar = vbCr) Then
            UltraTextEditor5.Focus()
        End If
    End Sub

    Private Sub UltraTextEditor5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UltraTextEditor5.KeyPress
        If (e.KeyChar = vbCr) Then
            UltraNumericEditor2.Focus()
        End If
    End Sub

    Private Sub UltraNumericEditor2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UltraNumericEditor2.KeyPress
        If (e.KeyChar = vbCr) Then
            UltraButton4.PerformClick()
        End If
    End Sub

    Private Sub MetroRadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles MetroRadioButton3.CheckedChanged
        Panel3.Visible = True
        Panel4.Visible = True
        Panel5.Visible = True
    End Sub

    Private Sub UltraComboEditor2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UltraComboEditor2.KeyPress
        UltraButton7.PerformClick()
    End Sub

    Private Sub UltraButton7_Click(sender As Object, e As EventArgs) Handles UltraButton7.Click
        If (MessageBox.Show("¿Seguro que desea eliminar este registro ?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then

            If (Instancia.Op("delete from Notas where Nombre='" + UltraComboEditor2.Text + "'") = 1) Then
                DataGridView1.DataSource = Instancia.Inicio()
                UltraComboEditor1.DataSource = Instancia.Nombres()
                UltraComboEditor1.Text = UltraComboEditor1.Items.Item(0).ToString
                UltraComboEditor2.DataSource = Instancia.Nombres()
                UltraComboEditor2.Text = UltraComboEditor2.Items.Item(0).ToString
                MessageBox.Show("Registro borrado con exito", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("El regstro digitado no existe", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub UltraButton3_Click(sender As Object, e As EventArgs) Handles UltraButton3.Click
        Matriz.ShowDialog()
    End Sub
End Class