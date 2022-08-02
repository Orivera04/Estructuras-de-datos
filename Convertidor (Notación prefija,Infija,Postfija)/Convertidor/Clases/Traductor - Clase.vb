Imports System.Text

Public Class Traductor___Clase

    Public Function Infija_A_Postfija(Expresion As String)
        Dim Postfija As String = ""
        Dim Pila As New Stack()
        For I = 0 To Expresion.Length - 1
            If (IsNumeric(Expresion.Chars(I)) Or (Char.IsLetter(Expresion.Chars(I)))) Then
                Dim Contador As Integer = I
                Try
                    While (IsNumeric(Expresion.Chars(Contador)) Or (Char.IsLetter(Expresion.Chars(Contador))))
                        I = Contador
                        Postfija = Postfija + (Expresion.Chars(Contador))
                        Contador += 1
                    End While
                Catch : End Try
                Postfija = Postfija + " "
            ElseIf (Expresion.Chars(I) = "(") Then
                Pila.Push(Expresion.Chars(I))
            ElseIf (Expresion.Chars(I) = ")") Then
                While (Pila.Peek <> "(" And Pila.Count <> 0)
                    Postfija = Postfija + (Pila.Pop)
                End While
                If (Pila.Count > 0) Then
                    Pila.Pop()
                End If
            ElseIf (Expresion.Chars(I) = "+" Or Expresion.Chars(I) = "-" Or Expresion.Chars(I) = "*" Or Expresion.Chars(I) = "/" Or Expresion.Chars(I) = "^") Then
                If (Pila.Count > 0) Then
                    While ((Pila.Count > 0) AndAlso (Pila.Peek() <> "("))
                        If (Prioridad(Pila.Peek) >= Prioridad(Expresion.Chars(I))) Then
                            Postfija = Postfija + (Pila.Pop)
                        Else
                            Exit While
                        End If
                    End While
                End If
                Pila.Push(Expresion.Chars(I))
            End If
        Next
        While (Pila.Count <> 0)
            If (Pila.Peek <> "(" And Pila.Peek <> ")") Then
                Postfija = Postfija + (Pila.Pop)
            Else
                Pila.Pop()
            End If
        End While
        Convertidor.Traductor.DataGridView1.Rows.Add(Expresion, Postfija + " (Postfija)")
        Dim Aux As String = Sustituir(Postfija)
        If (Aux <> "-1") Then
            Return "*****************************************" + vbNewLine + "Expresión original:" + vbNewLine + Expresion + vbNewLine + "*****************************************" + vbNewLine + "Expresion postfija" + vbNewLine + Aux + vbNewLine + "*****************************************" + vbNewLine + "Resultado -> " + Evaluar_Postfija(Aux).ToString + vbNewLine + "*****************************************"
        Else
            Return "*****************************************" + vbNewLine + "Expresión original:" + vbNewLine + Expresion + vbNewLine + "*****************************************" + vbNewLine + "Expresion postfija" + vbNewLine + Postfija + vbNewLine + "*****************************************" + vbNewLine + "Resultado -> " + Evaluar_Postfija(Postfija).ToString + vbNewLine + "*****************************************"
        End If
    End Function

    Public Function Infija_A_Prefija(Expresion As String)
        Dim Prefija As String = ""
        Dim Pila As New Stack()
        For I = Expresion.Length - 1 To 0 Step -1
            Dim Contador As Integer = I
            If (IsNumeric(Expresion.Chars(I)) OrElse Char.IsLetter(Expresion.Chars(I))) Then
                While (Contador >= 0 AndAlso (IsNumeric(Expresion.Chars(Contador)) Or (Char.IsLetter(Expresion.Chars(Contador)))))
                    I = Contador
                    Prefija = Prefija + (Expresion.Chars(Contador))
                    Contador -= 1
                End While
                Prefija = Prefija + " "
            ElseIf (Expresion.Chars(I) = ")") Then
                Pila.Push(Expresion.Chars(I))
            ElseIf (Expresion.Chars(I) = "(") Then
                While (Pila.Count > 0 AndAlso Pila.Peek <> ")")
                    Prefija = Prefija + (Pila.Pop)
                End While
                If (Pila.Count > 0) Then
                    Pila.Pop()
                End If
            ElseIf (Expresion.Chars(I) = "+" Or Expresion.Chars(I) = "-" Or Expresion.Chars(I) = "*" Or Expresion.Chars(I) = "/" Or Expresion.Chars(I) = "^") Then
                While (Pila.Count > 0 AndAlso Prioridad(Pila.Peek) > Prioridad(Expresion.Chars(I)))
                    If (Pila.Peek <> "(" And Pila.Peek <> ")") Then
                        Prefija = Prefija + Pila.Pop()
                    Else
                        Pila.Pop()
                    End If
                End While
                Pila.Push(Expresion.Chars(I))
            Else
                Pila.Push(Expresion.Chars(I))
            End If
        Next
        While (Pila.Count <> 0)
            If (Pila.Peek <> "(" And Pila.Peek <> ")") Then
                Prefija = Prefija + (Pila.Pop)
            Else
                Pila.Pop()
            End If
        End While
        Convertidor.Traductor.DataGridView1.Rows.Add(Expresion, StrReverse(Prefija) + "(Prefija)")
        Dim Aux As String = Sustituir(StrReverse(Prefija))
        If (Aux <> "-1") Then
            Return "*****************************************" + vbNewLine + "Expresión original:" + vbNewLine + Expresion + vbNewLine + "*****************************************" + vbNewLine + "Expresion prefija" + vbNewLine + Aux + vbNewLine + "*****************************************" + vbNewLine + "Resultado -> " + Evaluar_Prefija(Aux).ToString + vbNewLine + "*****************************************"
        Else
            Return "*****************************************" + vbNewLine + "Expresión original: " + vbNewLine + Expresion + vbNewLine + "*****************************************" + vbNewLine + "Expresion prefija" + vbNewLine + StrReverse(Prefija) + vbNewLine + "*****************************************" + vbNewLine + "Resultado -> " + Evaluar_Prefija(StrReverse(Prefija)).ToString + vbNewLine + "*****************************************"
        End If
    End Function

    Public Function Prioridad(Simbolo As Char)
        If (Simbolo = "^") Then
            Return 4
        ElseIf (Simbolo = "*" Or Simbolo = "/") Then
            Return 3
        ElseIf (Simbolo = "+" Or Simbolo = "-") Then
            Return 2
        Else
            Return 1
        End If
    End Function

    Public Function Sustituir(Expresion As String)
        'Primero recorremos la cadena en busca de variables'
        Dim Variables As String()
        Dim Contador As Integer = 0
        For I = 0 To Expresion.Length - 1
            If (Char.IsLetter(Expresion.Chars(I))) Then
                ReDim Preserve Variables(Contador)
                Variables(Contador) = Expresion.Chars(I)
                Contador += 1
            End If
        Next
        If (Contador = 0) Then
            Return -1
        End If

        Variables = Variables.Union(Variables).ToArray()
        For I = 0 To Variables.Length - 1
            Dim Cadena = InputBox("Valor de " + Variables(I), "Variables")
            Expresion = Expresion.Replace(Variables(I), Cadena)
        Next
        Return Expresion
    End Function

    Public Function Evaluar_Postfija(Expresion As String)
        Dim Pila As New Stack()
        Try
            Dim Contador As Integer = 0
            For I = 0 To Expresion.Length - 1
                Contador = I
                Dim Expresión_Aux As String = ""
                If (IsNumeric(Expresion.Chars(I))) Then
                    While (IsNumeric(Expresion.Chars(Contador)))
                        I = Contador
                        Expresión_Aux = Expresión_Aux + (Expresion.Chars(I))
                        Contador += 1
                    End While
                    Pila.Push(Expresión_Aux)
                Else
                    If (Expresion.Chars(I) <> " ") Then

                        If (Pila.Count > 0) Then
                            Dim Numa As Long = Math.Truncate(Val(Pila.Pop()))
                            Dim Numb As Long = Math.Truncate(Val(Pila.Pop()))
                            Pila.Push(Math.Truncate(Evaluación(Expresion.Chars(I), Numb, Numa)))
                        End If
                    End If
                End If
            Next
            Return Pila.Pop()
        Catch ex As Exception

            MessageBox.Show("Hubo un error", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return "Error"
        End Try
    End Function

    Public Function Evaluar_Prefija(Expresion As String)
        Dim Pila As New Stack()
        Try
            Dim Contador As Integer = 0
            For I = Expresion.Length - 1 To 0 Step -1
                Contador = I
                Dim Expresión_Aux As String = ""
                If (IsNumeric(Expresion.Chars(I))) Then
                    While (IsNumeric(Expresion.Chars(Contador)))
                        I = Contador
                        Expresión_Aux = Expresión_Aux + (Expresion.Chars(I))
                        Contador -= 1
                    End While
                    Pila.Push(StrReverse(Expresión_Aux))
                Else
                    If (Expresion.Chars(I) <> " ") Then

                        If (Pila.Count > 0) Then
                            Dim Numa As Long = Math.Truncate(Val(Pila.Pop()))
                            Dim Numb As Long = Math.Truncate(Val(Pila.Pop()))
                            Pila.Push(Math.Truncate(Evaluación(Expresion.Chars(I), Numa, Numb)))
                        End If
                    End If
                End If
            Next
            Return Pila.Pop()
        Catch ex As Exception

            MessageBox.Show("Hubo un error", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return "Error"
        End Try
    End Function

    Public Function Evaluación(Simbolo As Char, Numa As Integer, Numb As Integer)
        Select Case Simbolo
            Case "+"
                Return Numa + Numb
            Case "-"
                Return Numa - Numb
            Case "*"
                Return Numa * Numb
            Case "/"
                Return Numa / Numb
            Case "^"
                Return Math.Pow(Numa, Numb)
        End Select
        Return -1
    End Function

    Public Function Validar(Cadena As String)
        Dim Izquierdo As Integer = 0
        Dim Derecho As Integer = 0
        Dim Caracteres_Invalidos As Integer = 0
        Dim Operadores As Integer = 0
        For I = 0 To Cadena.Length - 1 Step 1
            If (Cadena.Chars(I) = "(") Then
                Izquierdo += 1
            End If
            If (Cadena.Chars(I) = ")") Then
                Derecho += 1
            End If

            If ((Cadena.Chars(I) = "+") OrElse (Cadena.Chars(I) = "-") OrElse (Cadena.Chars(I) = "*") OrElse (Cadena.Chars(I) = "/") OrElse (Cadena.Chars(I) = "^")) Then
                Operadores += 1
            End If
        Next
        If (Izquierdo = Derecho And Operadores > Izquierdo - 1) Then
            Return 1
        Else
            Return -1
        End If
    End Function
End Class
