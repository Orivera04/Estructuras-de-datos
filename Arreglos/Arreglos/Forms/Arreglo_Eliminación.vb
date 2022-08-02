Imports System.Diagnostics
Public Class Arreglo_Eliminación
    Private Sub UltraButton2_Click(sender As Object, e As EventArgs) Handles UltraButton2.Click
        Me.Close()
    End Sub

    Private Sub UltraButton1_Click(sender As Object, e As EventArgs) Handles UltraButton1.Click
        Try
            If (MetroRadioButton1.Checked) Then
                Arreglos.Principal_Menu.Instancia.Llenar_Vector()
                UltraFormattedTextEditor1.Text = Arreglos.Principal_Menu.Instancia.Imprimir()
                Dim Timer = Stopwatch.StartNew()
                Arreglos.Principal_Menu.Instancia.Duplicados()
                UltraFormattedTextEditor2.Text = Arreglos.Principal_Menu.Instancia.Lectura_Duplicados()
                Timer.Stop()
                Label6.Text = "Sin ordenar:" + Timer.Elapsed.ToString
                Label4.Visible = False
                Label5.Visible = False

            Else
                Arreglos.Principal_Menu.Instancia.Llenar_Vector()
                UltraFormattedTextEditor1.Text = Arreglos.Principal_Menu.Instancia.Imprimir()
                Dim Timer = Stopwatch.StartNew()
                Arreglos.Principal_Menu.Instancia.ShellSort1()
                Arreglos.Principal_Menu.Instancia.Duplicados()
                UltraFormattedTextEditor2.Text = Arreglos.Principal_Menu.Instancia.Lectura_Duplicados()
                Label7.Text = "Ordenado:" + Timer.Elapsed.ToString
                Label4.Visible = False
                Label5.Visible = False
            End If
        Catch
        End Try
    End Sub
End Class