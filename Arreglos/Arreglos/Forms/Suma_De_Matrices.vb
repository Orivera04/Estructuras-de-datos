Public Class Suma_De_Matrices
    Dim M As Integer = 0, N = 0, Dimension As Integer

    Private Sub UltraButton1_Click(sender As Object, e As EventArgs) Handles UltraButton1.Click
        Dimension = (UltraNumericEditor1.Value) - 1
        UltraGroupBox2.Visible = True
    End Sub

    Private Sub UltraButton3_Click(sender As Object, e As EventArgs) Handles UltraButton3.Click
        UltraGroupBox2.Visible = False
        M = 0 : N = 0 : Dimension = 0
        UltraTextEditor1.Text = ""
        UltraTextEditor2.Text = ""
        UltraFormattedTextEditor1.Text = ""
        UltraFormattedTextEditor2.Text = ""
        UltraFormattedTextEditor3.Text = ""
        Label9.Text = "1 X 1"
        UltraButton4.Enabled = True
        Label5.Visible = True
        Label8.Visible = True
        Label10.Visible = True
    End Sub

    Private Sub UltraButton4_Click(sender As Object, e As EventArgs) Handles UltraButton4.Click
        If (UltraTextEditor1.Text <> "" And UltraTextEditor2.Text <> "") Then
            Principal_Menu.Instancia.P_Matriz_A(M, N) = Val(UltraTextEditor1.Text)
            Principal_Menu.Instancia.P_Matriz_B(M, N) = Val(UltraTextEditor2.Text)
            If (M = Dimension And N = Dimension) Then
                Principal_Menu.Instancia.Suma(Dimension, Dimension)
                Dim Cadena As String = "[  "
                Dim Cadena2 As String = "[  "
                Dim Cadena3 As String = "[  "
                For I = 0 To Dimension
                    For J = 0 To Dimension
                        Cadena = Cadena + Principal_Menu.Instancia.P_Matriz_A(I, J).ToString + "  "
                        Cadena2 = Cadena2 + Principal_Menu.Instancia.P_Matriz_B(I, J).ToString + "  "
                        Cadena3 = Cadena3 + Principal_Menu.Instancia.P_Matriz_Suma(I, J).ToString + " "
                    Next
                    Cadena = Cadena + " ]"
                    Cadena2 = Cadena2 + " ]"
                    Cadena3 = Cadena3 + " ]"
                    If Not (I < N) Then
                    Else
                        Cadena = Cadena + vbNewLine + "[  "
                        Cadena2 = Cadena2 + vbNewLine + "[  "
                        Cadena3 = Cadena3 + vbNewLine + "[  "
                    End If
                Next
                UltraFormattedTextEditor1.Text = Cadena
                UltraFormattedTextEditor2.Text = Cadena2
                UltraFormattedTextEditor3.Text = Cadena3
                UltraButton4.Enabled = False
                Label5.Visible = False
                Label8.Visible = False
                Label10.Visible = False
            End If
            Label9.Text = (M + 1).ToString + " X " + (N + 1).ToString
            If (N < Dimension) Then
                N += 1
            Else
                M += 1
                N = 0
            End If
        Else
            MessageBox.Show("Algunos campos estan vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub UltraFormattedTextEditor1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UltraFormattedTextEditor1.KeyPress
        e.Handled = True
    End Sub

    Private Sub UltraFormattedTextEditor2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UltraFormattedTextEditor2.KeyPress
        e.Handled = True
    End Sub

    Private Sub UltraFormattedTextEditor3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UltraFormattedTextEditor3.KeyPress
        e.Handled = True
    End Sub

    Private Sub UltraNumericEditor1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UltraNumericEditor1.KeyPress
        If (e.KeyChar = vbCr) Then
            UltraButton1.PerformClick()
        End If
    End Sub

    Private Sub UltraButton2_Click(sender As Object, e As EventArgs) Handles UltraButton2.Click
        Me.Close()
    End Sub

    Private Sub UltraTextEditor1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UltraTextEditor1.KeyPress
        If (IsNumeric(e.KeyChar) Or e.KeyChar = vbBack Or e.KeyChar = "-" Or e.KeyChar = vbCr) Then
            If (e.KeyChar = vbCr) Then
                UltraTextEditor2.Focus()
            End If
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub UltraTextEditor2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UltraTextEditor2.KeyPress
        If (IsNumeric(e.KeyChar) Or e.KeyChar = vbBack Or e.KeyChar = "-" Or e.KeyChar = vbCr) Then
            If (e.KeyChar = vbCr) Then
                UltraButton4.PerformClick()
            End If
        Else
            e.Handled = True
        End If
    End Sub
End Class