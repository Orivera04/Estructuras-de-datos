Public Class Ordenar
    Dim Instancia As Operaciones()
    Private Sub UltraButton3_Click(sender As Object, e As EventArgs)
        'Evento manual'
    End Sub

    Private Sub UltraButton1_Click(sender As Object, e As EventArgs) Handles UltraButton1.Click
        'Evento Base de datos'
        'try
        Arreglos.Principal_Menu.Instancia.Llenar_Vector()
        UltraFormattedTextEditor1.Text = Arreglos.Principal_Menu.Instancia.Imprimir()
        Arreglos.Principal_Menu.Instancia.Llenar_Nombres()
        UltraGroupBox3.Visible = True
            Label5.Visible = False
        'Catch expeciont As Exception
        'MessageBox.Show("Error al conectar con la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub Ordenar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UltraComboEditor1.Text = UltraComboEditor1.Items.Item(0).ToString
    End Sub

    Private Sub UltraButton8_Click(sender As Object, e As EventArgs) Handles UltraButton8.Click
        UltraGroupBox3.Visible = False
        UltraFormattedTextEditor1.Text = "" : UltraFormattedTextEditor2.Text = ""
        Label5.Visible = True : Label8.Visible = True
    End Sub

    Private Sub UltraButton7_Click(sender As Object, e As EventArgs) Handles UltraButton7.Click
        'Ordenar Codigo'
        If (UltraComboEditor1.Text = UltraComboEditor1.Items.Item(0).ToString) Then
            UltraFormattedTextEditor1.Text = Arreglos.Principal_Menu.Instancia.Imprimir()
            Arreglos.Principal_Menu.Instancia.Burbuja_1(100)
            UltraFormattedTextEditor2.Text = Arreglos.Principal_Menu.Instancia.Imprimir()

        ElseIf (UltraComboEditor1.Text = UltraComboEditor1.Items.Item(1).ToString) Then
            UltraFormattedTextEditor1.Text = Arreglos.Principal_Menu.Instancia.Imprimir()
            Arreglos.Principal_Menu.Instancia.Burbuja_2(100)
            UltraFormattedTextEditor2.Text = Arreglos.Principal_Menu.Instancia.Imprimir()

        ElseIf (UltraComboEditor1.Text = UltraComboEditor1.Items.Item(2).ToString) Then
            UltraFormattedTextEditor1.Text = Arreglos.Principal_Menu.Instancia.Imprimir()
            Arreglos.Principal_Menu.Instancia.Burbujaconseñal(99)
        ElseIf (UltraComboEditor1.Text = UltraComboEditor1.Items.Item(3).ToString) Then
            UltraFormattedTextEditor1.Text = Arreglos.Principal_Menu.Instancia.Imprimir()
            Arreglos.Principal_Menu.Instancia.ShakerSort1()
            UltraFormattedTextEditor2.Text = Arreglos.Principal_Menu.Instancia.Imprimir()

        ElseIf (UltraComboEditor1.Text = UltraComboEditor1.Items.Item(4).ToString) Then
            UltraFormattedTextEditor1.Text = Arreglos.Principal_Menu.Instancia.Imprimir()
            Arreglos.Principal_Menu.Instancia.InsertionSort1()
            UltraFormattedTextEditor2.Text = Arreglos.Principal_Menu.Instancia.Imprimir()

        ElseIf (UltraComboEditor1.Text = UltraComboEditor1.Items.Item(5).ToString) Then
            UltraFormattedTextEditor1.Text = Arreglos.Principal_Menu.Instancia.Imprimir()
            Arreglos.Principal_Menu.Instancia.Binario(99)
            UltraFormattedTextEditor2.Text = Arreglos.Principal_Menu.Instancia.Imprimir()

        ElseIf (UltraComboEditor1.Text = UltraComboEditor1.Items.Item(6).ToString) Then
            UltraFormattedTextEditor1.Text = Arreglos.Principal_Menu.Instancia.Imprimir()
            Arreglos.Principal_Menu.Instancia.SelectionSort1()
            UltraFormattedTextEditor2.Text = Arreglos.Principal_Menu.Instancia.Imprimir()

        ElseIf (UltraComboEditor1.Text = UltraComboEditor1.Items.Item(7).ToString) Then
            UltraFormattedTextEditor1.Text = Arreglos.Principal_Menu.Instancia.Imprimir()
            Arreglos.Principal_Menu.Instancia.ShellSort1()
            UltraGroupBox2.Visible = True
            Label15.Visible = True
            Label14.Visible = True
            UltraGroupBox2.Text = "Shell"
            Label6.Text = "Pasadas(Promedio): " + (100 / 2).ToString
            Label7.Text = "Intercambios(Promedio)): " + Math.Truncate(Math.Log((100 ^ 3 / 2))).ToString
            Label10.Text = "Pasadas(Clasificadas): " + ((100 / 2) / 2).ToString
            Label11.Text = "Intercambios(Clasificadas): " + Math.Truncate(Math.Log((100 * Math.Pow(Math.Log(100), 2)))).ToString
            Label15.Text = "Pasadas(Inversa): " + Math.Truncate(((100 / 1.5))).ToString
            Label14.Text = "Intercambios(Inversa): " + Math.Truncate((Math.Pow(Math.Log(100), 2))).ToString
            UltraFormattedTextEditor2.Text = Arreglos.Principal_Menu.Instancia.Imprimir()

        ElseIf (UltraComboEditor1.Text = UltraComboEditor1.Items.Item(8).ToString) Then
            UltraFormattedTextEditor1.Text = Arreglos.Principal_Menu.Instancia.Imprimir()
            Arreglos.Principal_Menu.Instancia.MedianThreeQuickSort1(Principal_Menu.Instancia.Vector, 0, 99)
            Label15.Visible = False
            Label14.Visible = False
            UltraGroupBox2.Visible = True
            UltraGroupBox2.Text = "Quicksort"
            Label10.Text = "Particiones(Ordenada): " + (3 * (100 / 4)).ToString
            Label6.Text = "Particiones(Promedio): " + Math.Truncate((Math.Log(Math.Pow(100, 2)) * 2)).ToString
            Label7.Text = "Intercambios(Promedio): " + Math.Truncate(Math.Log(100 * Math.Log10(100) * (100 * 100))).ToString
            Label11.Text = "Intercambios(Ordenada): " + Math.Truncate((Math.Log10(100) * 50)).ToString()
            UltraFormattedTextEditor2.Text = Arreglos.Principal_Menu.Instancia.Imprimir()

        Else
            UltraFormattedTextEditor1.Text = Arreglos.Principal_Menu.Instancia.Leer_Nombres()
            Arreglos.Principal_Menu.Instancia.RadixSort()
            UltraFormattedTextEditor2.Text = Arreglos.Principal_Menu.Instancia.Leer_Nombres()
        End If
        MetroTabControl1.SelectedTab = MetroTabPage2
        Label8.Visible = False
    End Sub

    Private Sub UltraButton2_Click(sender As Object, e As EventArgs) Handles UltraButton2.Click
        Me.Hide()
        Principal_Menu.Show()
    End Sub

    Private Sub UltraButton9_Click(sender As Object, e As EventArgs) Handles UltraButton9.Click
        Arreglos.Principal_Menu.Instancia.Llenar_Vector()
        Arreglos.Principal_Menu.Instancia.Llenar_Nombres()
        Label8.Visible = True
        UltraFormattedTextEditor2.Text = ""
    End Sub

    Private Sub UltraComboEditor1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UltraComboEditor1.KeyPress
        If (e.KeyChar = vbCr) Then
            UltraButton7.PerformClick()
        End If
    End Sub
End Class