Public Class Busqueda
    Dim N As Integer
    Dim Contador As Integer = 0
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub UltraButton1_Click(sender As Object, e As EventArgs) Handles UltraButton1.Click
        Recursividad.Principal.Instancia.Llenar_Vector()
        Panel2.Visible = True
        UltraFormattedTextEditor2.Text = Recursividad.Principal.Instancia.Imprimir(99)
        Label6.Visible = False
        Panel2.Visible = True
        UltraGroupBox3.Visible = True
        UltraGroupBox2.Visible = True
        Panel3.Visible = True
        N = 99
        Contador = 99
    End Sub

    Private Sub UltraNumericEditor1_KeyPress(sender As Object, e As KeyPressEventArgs)
        If (e.KeyChar = vbCr) Then
            UltraButton5.PerformClick()
        End If
    End Sub

    Private Sub Busqueda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel2.Visible = False
        Panel3.Visible = False
        UltraGroupBox3.Visible = False
    End Sub

    Private Sub UltraGroupBox1_Click(sender As Object, e As EventArgs) Handles UltraGroupBox1.Click

    End Sub

    Private Sub UltraButton3_Click(sender As Object, e As EventArgs) Handles UltraButton3.Click
        Label11.Text = "Cantidad de numeros ingresados -> " + Contador.ToString
        Contador = 0
        UltraFormattedTextEditor1.Text = ""
        UltraFormattedTextEditor2.Text = ""
        Label6.Visible = True
        Label5.Visible = True
        Panel2.Visible = False
        Panel3.Visible = False
        UltraGroupBox3.Visible = False
        UltraGroupBox2.Visible = False
    End Sub

    Private Sub UltraButton6_Click(sender As Object, e As EventArgs) Handles UltraButton6.Click
        'Boton Ingresar'
        N = UltraNumericEditor2.Value
        ReDim Recursividad.Principal.Instancia.Vector_BBDD(N)
        Panel2.Visible = True
    End Sub

    Private Sub UltraButton7_Click(sender As Object, e As EventArgs) Handles UltraButton7.Click
        Recursividad.Principal.Instancia.P_Vector_BBDD(Contador) = UltraNumericEditor3.Value

        If (Contador = N - 1) Then
            UltraGroupBox2.Visible = True
            UltraFormattedTextEditor2.Text = Recursividad.Principal.Instancia.Imprimir(Contador)
            Label6.Visible = False
        End If
        Contador = Contador + 1
        Label11.Text = "Cantidad de numeros ingresados -> " + Contador.ToString
    End Sub

    Private Sub UltraNumericEditor3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UltraNumericEditor3.KeyPress
        If (e.KeyChar = vbCr) Then
            UltraButton7.PerformClick()
        End If
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub UltraButton4_Click(sender As Object, e As EventArgs) Handles UltraButton4.Click
        'Boton Manual'
        Panel3.Visible = True
        UltraGroupBox3.Visible = True
    End Sub

    Private Sub UltraNumericEditor2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UltraNumericEditor2.KeyPress
        If (e.KeyChar = vbCr) Then
            UltraButton6.PerformClick()
        End If
    End Sub

    Private Sub UltraButton5_Click_1(sender As Object, e As EventArgs) Handles UltraButton5.Click
        If (MetroRadioButton1.Checked) Then
            Dim N1 As Integer = Recursividad.Principal.Instancia.Busqueda_Secuencial(N, UltraNumericEditor1.Value)
            If (N1 = -1) Then
                Me.UltraFormattedTextEditor1.Text = "******************************" + vbNewLine + "Metodo de busqueda: Secuencial" +
                vbNewLine + "Valor a buscar :" + UltraNumericEditor1.Value.ToString + vbNewLine + "Resultado: No encontrado" + vbNewLine + "******************************"
            Else
                Me.UltraFormattedTextEditor1.Text = "******************************" + vbNewLine + "Metodo de busqueda: Secuencial" +
                vbNewLine + "Valor a buscar :" + UltraNumericEditor1.Value.ToString + vbNewLine + "Resultado: Encontrado en posición:[" + N1.ToString + "]" + vbNewLine + "******************************"
            End If
        Else
            Recursividad.Principal.Instancia.MedianThreeQuickSort1(Recursividad.Principal.Instancia.Vector_BBDD, 0, N - 1)
            Dim N1 As Integer = Recursividad.Principal.Instancia.Busqueda_Binaria(0, N, UltraNumericEditor1.Value)
            UltraFormattedTextEditor2.Text = Recursividad.Principal.Instancia.Imprimir(Contador - 1)
            If (N1 = -1) Then
                Me.UltraFormattedTextEditor1.Text = "******************************" + vbNewLine + "Metodo de busqueda: Binaria" +
                vbNewLine + "Valor a buscar :" + UltraNumericEditor1.Value.ToString + vbNewLine + "Resultado: No encontrado" + vbNewLine + "******************************"
            Else
                Me.UltraFormattedTextEditor1.Text = "******************************" + vbNewLine + "Metodo de busqueda: Binaria" +
                vbNewLine + "Valor a buscar :" + UltraNumericEditor1.Value.ToString + vbNewLine + "Resultado: Encontrado en posición:[" + N1.ToString + "]" + vbNewLine + "******************************"
            End If
        End If
        Panel3.Visible = True
        Label5.Visible = False
        Label6.Visible = False
    End Sub

    Private Sub UltraNumericEditor1_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles UltraNumericEditor1.KeyPress
        If (e.KeyChar = vbCr) Then
            UltraButton5.PerformClick()
        End If
    End Sub

    Private Sub UltraButton2_Click(sender As Object, e As EventArgs) Handles UltraButton2.Click
        Me.Close()
        Principal.Show()
    End Sub
End Class