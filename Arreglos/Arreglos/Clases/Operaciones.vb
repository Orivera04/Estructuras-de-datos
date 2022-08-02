Imports System.Data.SqlClient
Public Class Operaciones
    'Declaración de las variables a utilizar'
    Public Vector(99) As Integer : Private Matriz_A(10, 10) As Integer : Private Matriz_B(10, 10) As Integer : Private Matriz_C(10, 10) As Integer : Private Promedio As Decimal : Private Mayores As Integer = 0
    Dim Aux As Integer : Dim Band As Boolean : Dim J As Integer
    Private Adaptador As New SqlDataAdapter()
    Private Tabla As New DataTable()
    Private Cadena_De_Conexion As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + "\Base_De_Datos.mdf" + ";Integrated Security=True;Connect Timeout=15"
    Public Iteraciones As Integer = 0
    Public Nombres(99) As String
    'Asi como de las propiedades con las que extraeremos o introduciremos datos'
#Region "Propiedades"
    Public Property P_Vector(I As Integer) As Integer
        Get
            Return Vector(I)
        End Get
        Set(value As Integer)
            Vector(I) = value
        End Set
    End Property
    Public Property P_Matriz_A(I As Integer, J As Integer) As Integer
        Get
            Return Matriz_A(I, J)
        End Get
        Set(value As Integer)
            Matriz_A(I, J) = value
        End Set
    End Property
    Public Property P_Matriz_B(I As Integer, J As Integer) As Integer
        Get
            Return Matriz_B(I, J)
        End Get
        Set(value As Integer)
            Matriz_B(I, J) = value
        End Set
    End Property
    Public Property P_Matriz_Suma(I As Integer, J As Integer) As Integer
        Get
            Return Matriz_C(I, J)
        End Get
        Set(value As Integer)
            Matriz_C(I, J) = value
        End Set
    End Property
    Public ReadOnly Property P_Promedio As Decimal
        Get
            Return Promedio
        End Get
    End Property
    Public Property P_Mayores As Decimal
        Get
            Return Mayores
        End Get
        Set(value As Decimal)
            Mayores = value
        End Set
    End Property
#End Region

#Region "Funciones y Metodos"
    'Esta función devuelve el promedio de los valores almacenados en una matriz o un vector depediendo del tipo de parametro que se le sea suministrado a la función'
    Public Function F_Promedio(Parametro As Byte, N As Integer)
        'Se declara una variable suma'
        Dim Suma As Decimal = 0
        'Se evalua si el promedio a efectura sera con los datos de una matriz o con un vector'
        If (Parametro = 1) Then
            For I = 0 To 8
                For J = 0 To 8
                    Suma = Suma + P_Matriz_A(I, J)
                Next
            Next
        Else
            For J = 0 To N
                Suma = Suma + P_Vector(J)
            Next
        End If
        Promedio = Math.Truncate(Suma / N)
        'Se retorna el promedio'
        Return Math.Truncate(Suma / N)
    End Function

    'Esta función genera una matriz identidad de orden N (La matriz es cuadrada)'
    Public Function Identidad(N As Integer)
        For I = 0 To N
            For J = 0 To N
                'Si i = J entonces dicho elemento de la matriz forma parte de la diagonal principal'
                If (I = J) Then
                    Matriz_A(I, J) = 1
                Else
                    Matriz_A(I, J) = 0
                End If
            Next
        Next
        Dim Cadena As String = "[  "
        For I = 0 To N
            For J = 0 To N
                Cadena = Cadena + Principal_Menu.Instancia.P_Matriz_A(I, J).ToString + "  "
            Next
            Cadena = Cadena + " ]"
            If Not (I < N) Then
            Else
                Cadena = Cadena + vbNewLine + "[  "
            End If
        Next
        'Finalmente se hace una concatenación del texto y se devuelve dicho concatenación para que el usuario la pueda ver en un control'
        Return Cadena
    End Function

    'Procedimiento que efectua la suma de dos matrices '
    Public Sub Suma(M As Integer, N As Integer)
        For I = 0 To M
            For J = 0 To N
                'Primeramente se recorre las dos matrices y se efectua la suma y dicho resultado se almacena en una matriz C'
                Matriz_C(I, J) = Matriz_A(I, J) + Matriz_B(I, J)
            Next
        Next
    End Sub
    'Este metodo inicializa una matriz con valor 0 '
    Public Sub Inicializar(M As Integer, N As Integer)
        For I = 0 To M
            For J = 0 To N
                Matriz_A(I, J) = 0
            Next
        Next
    End Sub

    Public Sub Llenar_Nombres()
        Dim Contador As Integer
        Tabla.Clear()
        Adaptador = New SqlDataAdapter("select Nombre from Notas", Cadena_De_Conexion)
        Adaptador.Fill(Tabla)

        For I = 0 To 99
            Nombres(I) = Tabla.Rows.Item(I).Item(1).ToString

            Contador += 1
        Next
    End Sub
    Public Function Leer_Nombres()
        Dim Cadena As String = "// Nombres //" + vbNewLine + vbNewLine + ""
        For i = 0 To 99
            Cadena = Cadena + "● " + Principal_Menu.Instancia.Nombres(i).ToString + vbNewLine
        Next
        Return Cadena
    End Function
    'Esta función retorna la concatenación entre los elementos de un vector asi como la inicialización del mismo con valor 0' 
    'Dependiendo del parmetro que se le sea enviado'
    Public Function F_Vector(Parametro As Integer, Longitud As Integer)
        If (Parametro = 0) Then
            Dim Cadena As String = "// Inicio del vector //" + vbNewLine + vbNewLine + "[  "
            For I = 0 To Longitud
                Cadena = Cadena + Principal_Menu.Instancia.P_Vector(I).ToString + "  "
                If (P_Vector(I) > Promedio) Then
                    Mayores += 1
                End If
            Next
            Cadena = Cadena + " ]" + vbNewLine + vbNewLine + "// Fin del vector //"
            Return Cadena
        Else
            For I = 0 To UBound(Vector)
                Vector(I) = 0
            Next
            Return 1
        End If
    End Function
    'Caso 2 se jalan los '
    Public Sub Inicio()
        Dim Contador As Integer = 0
        Try
            Tabla.Clear()
            Adaptador = New SqlDataAdapter("select Nota from Notas", Cadena_De_Conexion)
            Adaptador.Fill(Tabla)
            For I = 0 To 9
                For J = 0 To 9
                    P_Matriz_A(I, J) = Val(Tabla.Rows.Item(Contador).Item(0).ToString)
                    Contador += 1
                Next
            Next
        Catch
            MessageBox.Show("Error al conectar con la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End Try
    End Sub

    Public Sub Llenar_Vector()
        Try
            Dim Contador As Integer = 0
            Tabla.Clear()
            Adaptador = New SqlDataAdapter("select Nota from Notas", Cadena_De_Conexion)
            Adaptador.Fill(Tabla)
            For I = 0 To 99
                P_Vector(I) = Val(Tabla.Rows.Item(Contador).Item(0).ToString)
                Contador += 1
            Next
        Catch
            MessageBox.Show("Error : Al conectar con la base de datos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Public Function Imprimir()
        Dim Contador As Integer = 0
        Dim Cadena As String = "// Inicio del vector //" + vbNewLine + vbNewLine + "[  "
        For I = 0 To 99
            Cadena = Cadena + Principal_Menu.Instancia.P_Vector(I).ToString + "  "
            Contador += 1
        Next
        Cadena = Cadena + " ]" + vbNewLine + vbNewLine + "// Fin del vector //"
        Return Cadena
    End Function

#Region "Metodos de ordenación"
    Public Sub Burbuja_1(N As Integer)
        For i = 0 To N - 1
            For J = i To 1 Step -1
                If (P_Vector(J - 1) > P_Vector(J)) Then
                    Aux = P_Vector(J - 1)
                    P_Vector(J - 1) = P_Vector(J)
                    P_Vector(J) = Aux
                End If
            Next
        Next
    End Sub
    Public Sub Burbuja_2(N As Integer)
        For i = 1 To N - 1
            For J = 0 To N - i - 1
                If (P_Vector(J) > P_Vector(J + 1)) Then
                    Aux = P_Vector(J + 1)
                    P_Vector(J + 1) = P_Vector(J)
                    P_Vector(J) = Aux
                End If
            Next
        Next
    End Sub
    Public Sub Burbujaconseñal(N As Integer)
        Dim Ordenado As Boolean = True
        For i = 0 To N - 1
            For J = 0 To N - 1
                If (P_Vector(J) > P_Vector(J + 1)) Then
                    Dim temp As Integer = P_Vector(J)
                    P_Vector(J) = P_Vector(J + 1)
                    P_Vector(J + 1) = temp
                    Ordenado = False
                End If
            Next
        Next

        If (Ordenado) Then : Return : End If
    End Sub

    Public Function ShakerSort1()
        Dim i As Long
        Dim j As Long
        Dim k As Long
        Dim iMin As Long
        Dim iMax As Long
        Dim varSwap As Object
        Dim blnSwapped As Boolean

        iMin = LBound(Vector)
        iMax = UBound(Vector)
        i = (iMax - iMin) \ 2 + iMin
        Do While i > iMin
            j = i
            Do While j > iMin
                For k = iMin To i - j
                    If Vector(k) > Vector(k + j) Then
                        varSwap = Vector(k)
                        Vector(k) = Vector(k + j)
                        Vector(k + j) = varSwap
                    End If
                Next
                j = j \ 2
            Loop
            i = i \ 2
        Loop
        iMax = iMax - 1
        Do
            blnSwapped = False
            For i = iMin To iMax
                If Vector(i) > Vector(i + 1) Then
                    varSwap = Vector(i)
                    Vector(i) = Vector(i + 1)
                    Vector(i + 1) = varSwap
                    blnSwapped = True
                End If
            Next i
            If blnSwapped Then
                blnSwapped = False
                iMax = iMax - 1
                For i = iMax To iMin Step -1
                    If Vector(i) > Vector(i + 1) Then
                        varSwap = Vector(i)
                        Vector(i) = Vector(i + 1)
                        Vector(i + 1) = varSwap
                        blnSwapped = True
                    End If
                Next i
                iMin = iMin + 1
            End If
        Loop Until Not blnSwapped
        Return -1
    End Function

    Public Sub InsertionSort1()
        Dim i As Long
        Dim j As Long
        Dim iMin As Long
        Dim iMax As Long
        Dim varSwap As Object

        iMin = LBound(Vector) + 1
        iMax = UBound(Vector)
        For i = iMin To iMax
            varSwap = Vector(i)
            For j = i To iMin Step -1
                If varSwap < Vector(j - 1) Then Vector(j) = Vector(j - 1) Else Exit For
            Next j
            Vector(j) = varSwap
        Next i
    End Sub
    Public Sub Binario(N As Integer)
        Dim Aux, izq, der, m As Integer
        For i = 0 To N
            Aux = Vector(i)
            izq = 0
            der = i - 1
            While izq <= der
                m = (izq + der) / 2
                If Aux <= Vector(m) Then
                    der = m - 1
                Else
                    izq = m + 1
                End If

            End While
            J = i - 1
            While J >= izq
                Vector(J + 1) = Vector(J)
                J = J - 1
            End While
            Vector(izq) = Aux
        Next
    End Sub
    Public Sub SelectionSort1()
        Dim i As Long
        Dim j As Long
        Dim iMin As Long
        Dim iMax As Long
        Dim varSwap As Object

        iMin = LBound(Vector)
        iMax = UBound(Vector)
        For i = iMin To iMax - 1
            iMin = i
            For j = (i + 1) To iMax
                If Vector(j) < Vector(iMin) Then iMin = j
            Next
            varSwap = Vector(i)
            Vector(i) = Vector(iMin)
            Vector(iMin) = varSwap
        Next
    End Sub

    Public Sub ShellSort1()
        Dim lngHold As Long
        Dim lngGap As Long
        Dim i As Long
        Dim iMin As Long
        Dim iMax As Long
        Dim varSwap As Object

        iMin = LBound(Vector)
        iMax = UBound(Vector)
        lngGap = iMin
        Do
            lngGap = 3 * lngGap + 1
        Loop Until lngGap > iMax
        Do
            lngGap = lngGap \ 3
            For i = lngGap + iMin To iMax
                varSwap = Vector(i)
                lngHold = i
                Do While Vector(lngHold - lngGap) > varSwap
                    Vector(lngHold) = Vector(lngHold - lngGap)
                    lngHold = lngHold - lngGap
                    If lngHold < iMin + lngGap Then Exit Do
                Loop
                Vector(lngHold) = varSwap
            Next i
        Loop Until lngGap = 1
    End Sub
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
#End Region

#Region "Metodos De Busqueda"
    Public Function Busqueda_Secuencial(N As Integer, Elemento As Integer)
        Dim I As Integer = 0
        While ((I <= N) And (P_Vector(I) <> Elemento))
            I += 1
            Iteraciones += 1
        End While
        If (P_Vector(I) = Elemento) Then
            Return I + 1
        Else
            Return -1
        End If
    End Function

    Public Function Busqueda_Centinela(Elemento As Integer, N As Integer)
        P_Vector(N + 1) = Elemento
        Dim I As Integer = 1
        While (P_Vector(I) <> Elemento)
            I += 1
            Iteraciones += 1
        End While
        If (I <> N + 1) Then
            Return 1
        Else
            Return -1
        End If
    End Function

    Public Function Busqued_Binaria(Parametro As Integer)
        Dim Bajo As Integer = 0
        Dim Alto As Integer = UBound(Vector)
        Dim Medio As Integer

        While Bajo <= Alto
            Medio = (Bajo + Alto) \ 2
            Iteraciones += 1
            If Parametro = Vector(Medio) Then
                Return Medio
            ElseIf Parametro < Vector(Medio) Then
                Alto = Medio - 1
            Else
                Bajo = Medio + 1
            End If

        End While

        Return -1
    End Function

#End Region

#Region "Operaciones"
    Public Sub Duplicados()
        For I = 0 To UBound(Vector)
            If (Vector(I) <> 0) Then
                For J = 0 To Vector.Length - 1
                    If (Vector(I) = Vector(J) And I <> J) Then
                        Vector(I) = 0
                        Exit For
                    End If
                Next
            End If
        Next
    End Sub
    Public Function Lectura_Duplicados()
        Dim Cadena As String = "// Inicio //" + vbNewLine + vbNewLine + "[  "
        For I = 0 To UBound(Vector)
            If (Vector(I) <> 0) Then
                Cadena = Cadena + Principal_Menu.Instancia.P_Vector(I).ToString + "  "
            End If
        Next
        Cadena = Cadena + " ]" + vbNewLine + vbNewLine + "// Fin //"
        Return Cadena
    End Function
    Public Sub RadixSort()
        Dim i As Integer, j As Integer
        Dim temp As String() = New String(Nombres.Length - 1) {}

        For shift As Integer = 31 To -1 + 1 Step -1
            j = 0

            For i = 0 To Nombres.Length - 1
                Dim move As Boolean = (Strings.Asc(Nombres(i)) << shift) >= 0

                If If(shift = 0, Not move, move) Then
                    Nombres(i - j) = Nombres(i)
                Else
                    temp(j) = Nombres(i)
                    j += 1
                End If
            Next

            Array.Copy(temp, 0, Nombres, Nombres.Length - j, j)
        Next
    End Sub
#End Region
#End Region
End Class
