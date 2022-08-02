Public Class Modulos
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Principal_Modulo_1.ShowDialog()
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Principal_Modulo_1.ShowDialog()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Try
            Dim Inicio As New ProcessStartInfo()
            Inicio.Arguments = "Estructuras de datos.exe"
            Inicio.FileName = "Estructuras de datos.exe"
            Using proceso As Process = Process.Start(Inicio)

                proceso.WaitForExit()
            End Using
        Catch
        End Try
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Try
            Dim Inicio As New ProcessStartInfo()
            Inicio.Arguments = "Modulo3.exe"
            Inicio.FileName = "Modulo3.exe"
            Using proceso As Process = Process.Start(Inicio)

                proceso.WaitForExit()
            End Using
        Catch
        End Try
    End Sub
End Class
