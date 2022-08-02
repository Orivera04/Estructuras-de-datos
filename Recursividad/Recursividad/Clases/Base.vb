Imports System.Data.SqlClient
Public Class Base
    Private Cadena_De_Conexion As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + "\Base_De_Datos.mdf" + ";Integrated Security=True;Connect Timeout=15"
    Private Adaptador As New SqlDataAdapter()
    Private Tabla As New DataTable()
    Public Vector_BBDD(99) As Integer

#Region "Propiedades"
    Public Property P_Vector_BBDD(i As Integer)
        Get
            Return Vector_BBDD(i)
        End Get
        Set(value)
            Vector_BBDD(i) = value
        End Set
    End Property
#End Region
#Region "Metodos y funciones"
    Public Function Factor(N)
        If (N = 0) Then
            Factor = 1
        Else
            Factor = N * Factor(N - 1)
        End If
    End Function
    Public Function Fib(N As Integer)
        If (N < 2) Then
            Return N
        Else
            Return Fib(N - 1) + Fib(N - 2)
        End If
    End Function

    Public Function Exp(Base As Integer, Exponente As Integer)
        Dim menor As Boolean
        If Exponente < 0 Then
            menor = True
        End If
        If (Exponente = 0) Then
            Return 1
        Else
            If menor Then
                Return 1 / (Base * Exp(Base, (Exponente * -1) - 1))
            Else
                Return Base * Exp(Base, Exponente - 1)
            End If
        End If
    End Function

    Public Function Suma(Numa As Integer, Numb As Integer)
        If (Numa = 0) Then
            Suma = Numb
        ElseIf (Numb = 0) Then
            Suma = Numa
        Else
            If Numb < 0 Then
                Suma = 1 + Suma(Numa - 1, Numb)
            Else
                Suma = 1 + Suma(Numa, Numb - 1)
            End If

        End If
    End Function

    Public Function Combinaciones(N As Integer, K As Integer)
        If (N = K Or K = 1) Then
            If (K = 1) Then
                Return N
            End If
            If (N = K) Then
                Return 1
            End If
        Else
            Return Combinaciones(N - 1, K - 1) + Combinaciones(N - 1, K)
        End If
    End Function
    Public Sub Llenar_Vector()
        Try
            ReDim Vector_BBDD(100)
            Dim Contador As Integer = 0
            Tabla.Clear()
            Adaptador = New SqlDataAdapter("select Nota from Notas", Cadena_De_Conexion)
            Adaptador.Fill(Tabla)
            For I = 0 To 99
                Vector_BBDD(I) = Val(Tabla.Rows.Item(Contador).Item(0).ToString)
                Contador += 1
            Next
        Catch
            MessageBox.Show("Error : Al conectar con la base de datos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Public Function Busqueda_Secuencial(N As Integer, X As Integer)
        If (N = -1) Then
            Return -1
        Else
            If (P_Vector_BBDD(N) = X) Then
                Return N
            Else
                Return Busqueda_Secuencial(N - 1, X)
            End If
        End If
    End Function

    Public Function Busqueda_Binaria(Primero, Ultimo, X)
        Dim Medio As Integer
        If (Primero > Ultimo) Then
            Return -1
        End If
        Medio = Math.Truncate((Primero + Ultimo) / 2)
        If (P_Vector_BBDD(Medio) = X) Then
            Return Medio
        ElseIf (P_Vector_BBDD(Medio) > X) Then
            Return Busqueda_Binaria(Primero, Medio - 1, X)
        Else
            Return Busqueda_Binaria(Medio + 1, Ultimo, X)
        End If
    End Function
    Public Function Imprimir(N As Integer)
        Dim Contador As Integer = 0
        Dim Cadena As String = "// Inicio del vector //" + vbNewLine + vbNewLine + "[  "
        For I = 0 To N
            Cadena = Cadena + Recursividad.Principal.Instancia.P_Vector_BBDD(I).ToString + "  "
            Contador += 1
        Next
        Cadena = Cadena + " ]" + vbNewLine + vbNewLine + "// Fin del vector //"
        Return Cadena
    End Function
    Public Sub MedianThreeQuickSort1(ByRef pvarArray As Object, ByVal plngLeft As Long, ByVal plngRight As Long)
        Dim lngFirst As Long
        Dim lngLast As Long
        Dim varMid As Object
        Dim lngIndex As Long
        Dim varSwap As Object
        Dim a As Long
        Dim b As Long
        Dim c As Long

        If plngRight = 0 Then
            plngLeft = LBound(pvarArray)
            plngRight = UBound(pvarArray)
        End If
        lngFirst = plngLeft
        lngLast = plngRight
        lngIndex = plngRight - plngLeft + 1
        a = Int(lngIndex * Rnd()) + plngLeft
        b = Int(lngIndex * Rnd()) + plngLeft
        c = Int(lngIndex * Rnd()) + plngLeft
        If pvarArray(a) <= pvarArray(b) And pvarArray(b) <= pvarArray(c) Then
            lngIndex = b
        Else
            If pvarArray(b) <= pvarArray(a) And pvarArray(a) <= pvarArray(c) Then
                lngIndex = a
            Else
                lngIndex = c
            End If
        End If
        varMid = pvarArray(lngIndex)
        Do
            Do While pvarArray(lngFirst) < varMid And lngFirst < plngRight
                lngFirst = lngFirst + 1
            Loop
            Do While varMid < pvarArray(lngLast) And lngLast > plngLeft
                lngLast = lngLast - 1
            Loop
            If lngFirst <= lngLast Then
                varSwap = pvarArray(lngFirst)
                pvarArray(lngFirst) = pvarArray(lngLast)
                pvarArray(lngLast) = varSwap
                lngFirst = lngFirst + 1
                lngLast = lngLast - 1
            End If
        Loop Until lngFirst > lngLast
        If lngLast - plngLeft < plngRight - lngFirst Then
            If plngLeft < lngLast Then MedianThreeQuickSort1(pvarArray, plngLeft, lngLast)
            If lngFirst < plngRight Then MedianThreeQuickSort1(pvarArray, lngFirst, plngRight)
        Else
            If lngFirst < plngRight Then MedianThreeQuickSort1(pvarArray, lngFirst, plngRight)
            If plngLeft < lngLast Then MedianThreeQuickSort1(pvarArray, plngLeft, lngLast)
        End If
    End Sub

    Public Function MCD(A As Integer, B As Integer)
        If (B = 0) Then
            Return A
        Else
            Return MCD(B, A Mod B)
        End If
    End Function

    Public Function Recurrencia(N As Integer)
        If (N = 0) Then
            Return 1
        Else
            Return 2 ^ N + Recurrencia(N - 1)
        End If
    End Function
#End Region
End Class
