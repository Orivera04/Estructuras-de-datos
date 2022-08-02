Imports System.Data.SqlClient
Public Class Datos
    Private Cadena_De_Conexion As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + "\Base_De_Datos.mdf" + ";Integrated Security=True;Connect Timeout=15"
    Private Tabla As New DataTable()
    Private Tabla_Combobox As New DataTable()
    Private Tabla_Aux As New DataTable()
    Private Nombre As String
    Private Codigo As String
    Private Grupo As String
    Private Nota As Integer
    Private Adaptador As New SqlDataAdapter()
    Private Matriz(3, 3) As Integer
    Dim Contador As Integer = 0
#Region "Propiedades"
    Public Property PNombre As String
        Get
            Return Nombre
        End Get
        Set(value As String)
            Nombre = value
        End Set
    End Property
    Public Property PCodigo As String
        Get
            Return Codigo
        End Get
        Set(value As String)
            Codigo = value
        End Set
    End Property
    Public Property PGrupo As String
        Get
            Return Grupo
        End Get
        Set(value As String)
            Grupo = value
        End Set
    End Property
    Public Property PNota As Integer
        Get
            Return Nota
        End Get
        Set(value As Integer)
            Nota = value
        End Set
    End Property
    Public ReadOnly Property PMatriz(i As Integer, j As Integer) As Integer
        Get
            Return Matriz(i, j)
        End Get
    End Property
#End Region
#Region "Metodos y funciones"
    Public Function Inicio() As DataTable
        Try
            Tabla.Clear()
            Adaptador = New SqlDataAdapter("select * from Notas", Cadena_De_Conexion)
            Adaptador.Fill(Tabla)
            For I = 0 To 3
                For J = 0 To 3
                    Matriz(I, J) = Val(Tabla.Rows.Item(Contador).Item(3).ToString)
                    Contador += 1
                Next
            Next
            Return Tabla
        Catch
            MessageBox.Show("Error al conectar con la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End Try
    End Function
    Public Function Nombres() As DataTable
        Tabla_Combobox.Clear()
        Adaptador = New SqlDataAdapter("select Nombre from Notas", Cadena_De_Conexion)
        Adaptador.Fill(Tabla_Combobox)
        Return Tabla_Combobox
    End Function
    Public Sub Insertar()
        Adaptador = New SqlDataAdapter("insert into Notas(Nombre,Codigo,Grupo,Nota) values('" + PNombre + "','" + PCodigo + "','" + PGrupo + "','" + PNota.ToString + "')", Cadena_De_Conexion)
        Adaptador.Fill(New DataTable)
    End Sub
    Public Function Información(Nombre As String)
        Adaptador = New SqlDataAdapter("select * from Notas where Nombre ='" + Nombre + "'", Cadena_De_Conexion)
        Adaptador.Fill(Tabla_Aux)
        If (Tabla_Aux.Rows.Count > 0) Then
            PNombre = Tabla_Aux.Rows.Item(0).Item(0)
            PCodigo = Tabla_Aux.Rows.Item(0).Item(1)
            PGrupo = Tabla_Aux.Rows.Item(0).Item(2)
            PNota = Tabla_Aux.Rows.Item(0).Item(3)
            Tabla_Aux.Clear()
            Return 1
        Else
            MessageBox.Show("El nombre no existe", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return -1
        End If
    End Function

    Public Function Op(Consulta As String)
        Try
            Adaptador = New SqlDataAdapter(Consulta, Cadena_De_Conexion)
            Adaptador.Fill(New DataTable)
        Catch : Return -1 : End Try
        Return 1
    End Function
#End Region
End Class
