using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using Infragistics.Win.FormattedLinkLabel;
using System.Threading;
using System.IO;
using Microsoft.VisualBasic;

namespace Grafos.Clases
{
    class Operaciones_Grafos
    {
        public Clase_Grafo Raiz;
        public Clase_Grafo Fondo;
        public Clase_Grafo Abismo;
        public Aristas Raiz_Aristas;
        public int Contador_Aristas = 0;
        public Grafo Instancia;
        public Queue Visitados = new Queue();
        public int Velocidad = 200;
        public int Distancia_Final = 0;
        public void Añadir_Grafo(int Elemento, int X, int Y, Color R)
        {
            Clase_Grafo Nuevo;
            Clase_Grafo Nuevo2;
            Nuevo2 = new Clases.Clase_Grafo(Elemento, X, Y, null, R);
            if (Raiz != null)
            {
                Nuevo = new Clases.Clase_Grafo(Elemento, X, Y, Raiz, R);
                Fondo.Enlace = Nuevo2;
                Fondo = Nuevo2;
                Raiz = Nuevo;

            }
            else
            {
                Nuevo = new Clases.Clase_Grafo(Elemento, X, Y, null, R);
                Raiz = Nuevo;
                Abismo = Nuevo2;
                Fondo = Nuevo2;
            }

        }
        public void Añadir_Arista(Clase_Grafo Nodo1, Clase_Grafo Nodo2,int Parametro = 0,int P = 0)
        {
            Aristas Nuevo = null;
            bool Valio_Versh = false;
            if (Nodo1.Dato != Nodo2.Dato)
            {
                if (Raiz != null)
                {
                    try
                    {
                        if (Parametro == 0)
                        {
                            int Peso = Int32.Parse(Microsoft.VisualBasic.Interaction.InputBox("Ingrese un peso a la arista", "Peso", "1"));
                            if (Peso >= 1)
                            {
                                Nuevo = new Aristas(Nodo1, Nodo2, Raiz_Aristas, Peso);                                
                            }
                            else
                            {
                                Valio_Versh = true;
                                MessageBox.Show("El peso debe ser mayor que 0","Atención",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            
                            Nuevo = new Aristas(Nodo1, Nodo2, Raiz_Aristas, P);
                        }

                        if (Valio_Versh == false)
                        {
                            Raiz_Aristas = Nuevo;
                            Contador_Aristas++;
                        }
                    }
                    catch {
                        MessageBox.Show("La cadena no es valida", "Atencióm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    try
                    {
                        if (Parametro != 0)
                        {
                            int Peso = Int32.Parse(Microsoft.VisualBasic.Interaction.InputBox("Ingrese un peso a la arista", "Peso", "1"));
                            Nuevo = new Aristas(Nodo1, Nodo2, null, Peso);
                        }
                        else
                        {
                            Nuevo = new Aristas(Nodo1, Nodo2, null, P);
                        }
                        Raiz_Aristas = Nuevo;
                        Contador_Aristas++;
                    }
                    catch
                    {
                        MessageBox.Show("La cadena no es valida", "Atencióm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {

            }
        }

        public int Validar_Arista(Clase_Grafo Nodo1, Clase_Grafo Nodo2)
        {
            Aristas Recorrer = Raiz_Aristas;
            while (Recorrer != null)
            {
                if ((Recorrer.Grafo_Inicio.Equals(Nodo1) & Recorrer.Grafo_Fin.Equals(Nodo2)) | (Recorrer.Grafo_Fin.Equals(Nodo1) & Recorrer.Grafo_Inicio.Equals(Nodo2)))
                {
                    return 1;
                }
                Recorrer = Recorrer.Enlace;
            }
            return -1;
        }
        public int Adyacentes(int Dato)
        {
            Aristas Recorrer = Raiz_Aristas;
            int Contador = 0;
            while (Recorrer != null)
            {
                if (Recorrer.Grafo_Inicio.Dato == Dato || Recorrer.Grafo_Fin.Dato == Dato)
                {
                    Contador++;
                }
                Recorrer = Recorrer.Enlace;
            }
            return Contador;
        }
        public string Nodos_Adyacentes(int Dato)
        {
            string Cadena = "[";
            Aristas Recorrer = Raiz_Aristas;
            int Conta = 0;
            while (Recorrer != null)
            {
                if (Recorrer.Grafo_Inicio.Dato == Dato || Recorrer.Grafo_Fin.Dato == Dato)
                {
                    if (Recorrer.Grafo_Inicio.Dato == Dato)
                    {
                        Cadena = Cadena + Recorrer.Grafo_Fin .Dato + " ";
                        Conta++;
                    }
                    else
                    {
                        Cadena = Cadena + Recorrer.Grafo_Inicio.Dato + " ";
                        Conta++;
                    }
                }              
                Recorrer = Recorrer.Enlace;
            }
            if (Conta != 0)
            {
                return Cadena + "]";
            }
            else
            {
                return Cadena + "Ninguno]";
            }
        }
        public void Eliminar_Nodos(int Dato)
        {
            Clase_Grafo Recorrer = Raiz;
            Clase_Grafo Aux = null;
            while (Recorrer != null)
            {

                if (Dato == Recorrer.Dato)
                {
                    if (Aux != null)
                    {

                        Aux.Enlace = Aux.Enlace.Enlace;
                    }
                    else
                    {
                        Raiz = Raiz.Enlace;
                    }

                    break;
                }
                Aux = Recorrer;
                Recorrer = Recorrer.Enlace;
            }
        }
        public int Eliminar_Aristas(int Dato)
        {
            Aristas Recorrer = Raiz_Aristas;
            Aristas Aux = null;
            int Eliminadas = 0;
            while (Recorrer != null)
            {

                if (Recorrer.Grafo_Inicio.Dato == Dato || Recorrer.Grafo_Fin.Dato == Dato)
                {
                    if (Aux != null)
                    {
                        Aux.Enlace = Aux.Enlace.Enlace;
                        Eliminadas++;
                    }
                    else
                    {
                        Raiz_Aristas = Raiz_Aristas.Enlace;
                        Eliminadas++;
                    }

                }
                Aux = Recorrer;
                if (Recorrer != null)
                {
                    Recorrer = Recorrer.Enlace;
                }
            }
            return Eliminadas;
        }

        public void Borrar_Arista(Clase_Grafo Nodo_1, Clase_Grafo Nodo_2)
        {
            Aristas Recorrer = Raiz_Aristas;
            Aristas Aux = null;
            while (Recorrer != null)
            {

                if ((Recorrer.Grafo_Inicio.Equals(Nodo_1) && Recorrer.Grafo_Fin.Equals(Nodo_2)) | (Recorrer.Grafo_Fin.Equals(Nodo_1) && Recorrer.Grafo_Inicio.Equals(Nodo_2)))
                {
                    if (Aux != null)
                    {
                        Aux.Enlace = Aux.Enlace.Enlace;
                        break;
                    }
                    else
                    {
                        Raiz_Aristas = Raiz_Aristas.Enlace;
                    }
                }
                Aux = Recorrer;
                Recorrer = Recorrer.Enlace;
            }
        }
        public int Existe_Arista(Clase_Grafo Nodo_1, Clase_Grafo Nodo_2)
        {
            Aristas Recorrer = Raiz_Aristas;
            while (Recorrer != null)
            {
                try
                {
                    if ((Recorrer.Grafo_Inicio.Dato.Equals(Nodo_1.Dato) && Recorrer.Grafo_Fin.Dato.Equals(Nodo_2.Dato)) | ((Recorrer.Grafo_Fin.Dato.Equals(Nodo_1.Dato) & Recorrer.Grafo_Inicio.Dato.Equals(Nodo_2.Dato))))
                    {
                        return 1;
                    }
                }
                catch
                {
                    return 1;
                }
                Recorrer = Recorrer.Enlace;

            }
            return -1;
        }
        public int[,] Matriz_De_Adyacencia(int N)
        {
            int[,] Matriz;
            Clase_Grafo Recorrer1 = Abismo;
            Matriz = new int[N, N];
            for (int I = 0; I <= N - 1; I++)
            {
                Clase_Grafo Recorrer2 = Abismo;
                for (int J = 0; J <= N - 1; J++)
                {
                    if (Recorrer1 != null && Recorrer2 != null)
                    {
                        if (Existe_Arista(Recorrer1, Recorrer2) == 1)
                        {
                            Matriz[I, J] = 1;
                        }
                        else
                        {
                            Matriz[I, J] = 0;
                        }
                        if (Recorrer2 != null)
                        {
                            Recorrer2 = Recorrer2.Enlace;
                        }
                    }
                }

                if (Recorrer1 != null)
                {
                    Recorrer1 = Recorrer1.Enlace;
                }
            }
            return Matriz;
        }

        public void Eliminar_Lista(int Dato)
        {
            Clase_Grafo Recorrer = Abismo;
            Clase_Grafo Aux = null;
            while (Recorrer != null)
            {
                if (Dato == Recorrer.Dato)
                {
                    if (Aux != null)
                    {

                        Aux.Enlace = Aux.Enlace.Enlace;
                    }
                    else
                    {
                        Abismo = Abismo.Enlace;
                    }

                    break;
                }
                Aux = Recorrer;
                Recorrer = Recorrer.Enlace;
            }
        }

        public string Nodo_Adyacente_A_Un_Nodo(int Dato)
        {
            string Cadena = "";
            Aristas Recorrer = Raiz_Aristas;
            while (Recorrer != null)
            {
                if (Recorrer.Grafo_Inicio.Dato == Dato)
                {
                    Cadena = Cadena + Recorrer.Grafo_Fin.Dato + " ";
                }
                if (Recorrer.Grafo_Fin.Dato == Dato)
                {
                    Cadena = Cadena + Recorrer.Grafo_Inicio.Dato + " ";
                }
                Recorrer = Recorrer.Enlace;
            }
            return Cadena;
        }

        public string Nodo_Adyacente_A_Un_Nodo_Dirigido(int Dato)
        {
            string Cadena = "";
            Aristas Recorrer = Raiz_Aristas;
            while (Recorrer != null)
            {
                if(Recorrer.Grafo_Inicio.Dato == Dato)
                {
                    Cadena = Cadena + Recorrer.Grafo_Fin.Dato + " ";
                }
                if (Recorrer.Grafo_Fin.Dato == Dato)
                {
                    Cadena = Cadena + Recorrer.Grafo_Inicio.Dato + " ";
                }
                Recorrer = Recorrer.Enlace;
            }
            return Cadena;
        }
        public void Recorrido_Anchura(int Dato, int Total)
        {

            Queue Visitados = new Queue();
            Queue PorExplorar = new Queue();
            Visitados.Enqueue(Dato);
            PorExplorar.Enqueue(Dato);                     
            while (Visitados.Count != Total)
            {

                try
                {                    
                    int Sacar = Convert.ToInt32(Convert.ToString(PorExplorar.Dequeue()));
                    string[] Adyacentes = (Nodo_Adyacente_A_Un_Nodo(Sacar)).Split(' ');                   
                    Int32[] Arreglo = Array.ConvertAll<object, Int32>(Visitados.ToArray(), Convert.ToInt32);                    
                    for (int I = 0; I <= Adyacentes.Length - 2; I++)
                    {
                        if (Arreglo.Contains(Convert.ToInt32(Adyacentes[I])) == false)
                        {
                            PorExplorar.Enqueue(Convert.ToInt16(Adyacentes[I]));
                            Visitados.Enqueue((Convert.ToInt16(Adyacentes[I])));

                        }                        
                        Instancia.Borrar = true;                        
                        Instancia.Dibujar(Arreglo, 0, 0, 0);
                        System.Threading.Thread.Sleep(Velocidad);
                    }
                }

                catch { break; }
            }
            Instancia.ultraFormattedTextEditor1.Text = "";
            Instancia.ultraFormattedTextEditor1.Text = Instancia.ultraFormattedTextEditor1.Text + "●---------------------------------------●\n";
            Instancia.ultraFormattedTextEditor1.Text = Instancia.ultraFormattedTextEditor1.Text + "●             Recorrido en anchura          ● \n";
            Instancia.ultraFormattedTextEditor1.Text = Instancia.ultraFormattedTextEditor1.Text + "●---------------------------------------● \n";
            Instancia.ultraFormattedTextEditor1.Text = Instancia.ultraFormattedTextEditor1.Text + "-> Visitados {";
            Int32[] Aux = Array.ConvertAll<object, Int32>(Visitados.ToArray(), Convert.ToInt32);
            for (int O = 0; O <= Aux.Length - 1; O++)
            {
                Instancia.ultraFormattedTextEditor1.Text = Instancia.ultraFormattedTextEditor1.Text + " " + Aux[O];
            }

            Instancia.ultraFormattedTextEditor1.Text = Instancia.ultraFormattedTextEditor1.Text + "} \n";

        }

        public Queue Recorrido_Profundidad(int Dato, int Total)
        {
            Visitados.Enqueue(Dato);
            string[] Adyacentes = (Nodo_Adyacente_A_Un_Nodo(Dato)).Split(' ');
            Int32[] Vis = Array.ConvertAll<object, Int32>(Visitados.ToArray(), Convert.ToInt32);
            Instancia.Borrar = true;
            Instancia.Dibujar(Vis, 0, 0, 0);
            System.Threading.Thread.Sleep(Velocidad);
            Stack Pila = new Stack();


            for (int I = 0; I <= Adyacentes.Length - 2; I++)
            {

                if (Visitados.Contains(Convert.ToInt32(Adyacentes[I])) == false)
                {
                    Pila.Push(Convert.ToInt32(Adyacentes[I]));
                }
            }
            for (int J = 0; J <= Adyacentes.Length - 1; J++)
            { if (Pila.Count != 0)
                {
                    if (Visitados.Contains(Pila.Peek()) == false){
                        Recorrido_Profundidad(Convert.ToInt32(Pila.Pop()), Total); }
                    else
                    {
                        Pila.Pop();
                    }
                }
                else
                {
                    Int32[] Aux = Array.ConvertAll<object, Int32>(Visitados.ToArray(), Convert.ToInt32);
                    Instancia.ultraFormattedTextEditor1.Text = "";
                    Instancia.ultraFormattedTextEditor1.Text = Instancia.ultraFormattedTextEditor1.Text + "●---------------------------------------●\n";
                    Instancia.ultraFormattedTextEditor1.Text = Instancia.ultraFormattedTextEditor1.Text + "●          Recorrido en Profundidad       ● \n";
                    Instancia.ultraFormattedTextEditor1.Text = Instancia.ultraFormattedTextEditor1.Text + "●---------------------------------------● \n";
                    Instancia.ultraFormattedTextEditor1.Text = Instancia.ultraFormattedTextEditor1.Text + "-> Visitados {";
                    for (int O = 0; O <= Aux.Length - 1; O++)
                    {
                        Instancia.ultraFormattedTextEditor1.Text = Instancia.ultraFormattedTextEditor1.Text + " " + Aux[O];
                    }

                    Instancia.ultraFormattedTextEditor1.Text = Instancia.ultraFormattedTextEditor1.Text + "} \n";

                    return Visitados;
                }

            }

            return Visitados;
        }
        public bool Existe_Nodo(int Dato)
        { 
            Clase_Grafo Recorrer = Raiz;
            while(Recorrer != null)
            {
               if(Recorrer.Dato == Dato)
                {
                    return true;
                }
                Recorrer = Recorrer.Enlace;
            }

            return false;
        }    
        public Clase_Grafo Retornar_Nood(int Dato)
        {
            Clase_Grafo Recorrer = Raiz;
            while (Recorrer != null)
            {
                if (Recorrer.Dato == Dato)
                {
                    return Recorrer;
                }
                Recorrer = Recorrer.Enlace;
            }

            return null;        
    }

        public int Peso_Entre_Dos_Aristas(Clase_Grafo Nodo1,Clase_Grafo Nodo2)
        {
            Aristas Recorrer = Raiz_Aristas;
            while (Recorrer != null)
            {
               
                if((Recorrer.Grafo_Inicio.Equals(Nodo1) && Recorrer.Grafo_Fin.Equals(Nodo2)) || (Recorrer.Grafo_Inicio.Equals(Nodo2) && Recorrer.Grafo_Fin.Equals(Nodo1)))
                {
                    return Recorrer.Peso;
                }
                Recorrer = Recorrer.Enlace;
            }

            return 0;
        }
        
        public void Guardar_Grafo()
        {
            SaveFileDialog Dialogo = new SaveFileDialog();
            Dialogo.Filter = "Archivo Grafo |*.grafo";
            if (Dialogo.ShowDialog() == DialogResult.OK)
            {
                Clase_Grafo Guardar =Raiz;
                FileStream Conector = new FileStream(Dialogo.FileName , FileMode.Create, FileAccess.Write);
                StreamWriter Escribir = new StreamWriter(Conector);
                while (Guardar != null)
                {
                    Escribir.WriteLine(Guardar.Dato.ToString() + "," + Guardar.Locacion.X.ToString() + "," + Guardar.Locacion.Y.ToString() + "," + Guardar.Pincel.Color.ToString());
                    Guardar = Guardar.Enlace;
                }
                Escribir.WriteLine("----------------------------------------------------------------------------------");
                Aristas Prueb = Raiz_Aristas;
                while (Prueb != null)
                {
                    Escribir.WriteLine(Prueb.Grafo_Inicio.Dato.ToString() + "," + Prueb.Grafo_Fin.Dato.ToString() + "," + Prueb.Peso.ToString());
                    Prueb = Prueb.Enlace;
                }
                Escribir.Close();
                Dialogo.Dispose();
                MessageBox.Show("El grafo se guardo con exito", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Leer_Grafo()
        {
            OpenFileDialog  Dialogo = new OpenFileDialog();
            Dialogo.Filter = "Archivo Grafo |*.grafo";
            if (Dialogo.ShowDialog() == DialogResult.OK)
            {
                Raiz = null;
                Raiz_Aristas = null;
                Fondo = null;
                Abismo = null;               
                string[] Lineas = File.ReadAllLines(Dialogo.FileName);
                int Contador = 0;
                int Contador_Aux = 0;
                Instancia.dataGridView1.Rows.Clear();
                for (int I = 0; I <= Lineas.Length - 1; I++)
                {
                    if (Lineas[I].Contains("-") == false)
                    {
                        string[] Datos = Lineas[I].Split(',');
                        if (Datos[3] == "Color [LightSalmon]")
                        {
                            Añadir_Grafo(Convert.ToInt32(Datos[0]), Convert.ToInt32(Datos[1]), Convert.ToInt32(Datos[2]), Color.LightSalmon);
                        }
                        else if (Datos[3] == "Color [LightGreen]")
                        {
                            Añadir_Grafo(Convert.ToInt32(Datos[0]), Convert.ToInt32(Datos[1]), Convert.ToInt32(Datos[2]), Color.LightGreen);
                        }
                        else if (Datos[3] == "Color [RoyalBlue]")
                        {
                            Añadir_Grafo(Convert.ToInt32(Datos[0]), Convert.ToInt32(Datos[1]), Convert.ToInt32(Datos[2]), Color.RoyalBlue);
                        }
                        else
                        {
                            Añadir_Grafo(Convert.ToInt32(Datos[0]), Convert.ToInt32(Datos[1]), Convert.ToInt32(Datos[2]), Color.LightPink);
                        }
                        Instancia.dataGridView1.Rows.Add(Datos[0],"0","Ninguno");
                    }
                    else { break; }
                    Contador++;
                    Contador_Aux++;
                }
                Contador++;
                int Contador_Aristas = 0;                
                for (int J = Contador; J <= Lineas.Length - 1; J++)
                {

                    string[] Datos = Lineas[J].Split(',');
                    Añadir_Arista(Retornar_Nood(Convert.ToInt32(Datos[0])), Retornar_Nood(Convert.ToInt32(Datos[1])), 1, Convert.ToInt32(Datos[2]));
                    Contador_Aristas++;
                }
                string[] Data = Lineas[Lineas.Length-1].Split(',');
                this.Contador_Aristas = Contador_Aristas;
                Instancia.Contador = Contador;
                Instancia.Contador_Vertex = Instancia.Contador - 1;
                Instancia.Borrar = true;
                Instancia.Dibujar(null);
                Instancia.Actualizar_Datagridview();
                Instancia.Actualizar_Datagrid_Matriz(Matriz_De_Adyacencia(Contador_Aux));
                Instancia.Actualizar_Datagrid_Matriz_De_Incidencia(Matriz_De_Incidencia(Contador_Aux + 1,Contador_Aristas));
                MessageBox.Show("Se ha cargado el grafo", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
       Rotulación Devolver_Rotulo(int Dato,Rotulación Raiz)
        {
            Rotulación Recorrer = Raiz;
            while(Recorrer != null)
            {
                if(Recorrer.Nodo.Dato == Dato)
                {
                    return Recorrer;
                }
                Recorrer = Recorrer.Enlace;
            }
            return null;
        }
        public bool Esta_En_Alguna_Arista(int Dato)
        {
            Aristas Recorrer = Raiz_Aristas;
            while (Recorrer != null)
            {
                if (Recorrer.Grafo_Inicio.Dato == Dato || Recorrer.Grafo_Fin.Dato == Dato)
                {
                    return true;
                }
                Recorrer = Recorrer.Enlace;
            }     
            return false;
        }
        public string Dijkstra(int PrimerNodo,int SegundoNodo,int Contador)
        {
            string Ruta = "";
            Rotulación RaizVertices = null;
            Stack<int> Nodos_Definitivos = new Stack<int>();
            Nodos_Definitivos.Push(PrimerNodo);
            RaizVertices = new Clases.Rotulación(Retornar_Nood(PrimerNodo),null,0,RaizVertices);
            bool Termino = false;
            while (Termino == false)
            {
                int Distancia_Lista = 0;
                string[] Adyacentes = (Nodo_Adyacente_A_Un_Nodo_Dirigido(Nodos_Definitivos.Peek()).Split(' '));

                Rotulación Rec = RaizVertices;
                while (Rec != null)
                {
                    Clase_Grafo M = Retornar_Nood((Nodos_Definitivos.Peek()));
                    if (Rec.Nodo.Dato.Equals(M.Dato ))
                    {
                        Distancia_Lista = Rec.Distancia;
                        break;
                    }
                    Rec = Rec.Enlace;
                }
                int Peso_Minimo = Int32.MaxValue;
                int Nodo_Nombre = 0;
                for (int I = 0; I <= Adyacentes.Length - 2; I++)
                {
                    Clase_Grafo Nodo = Retornar_Nood(Convert.ToInt32(Adyacentes[I]));
//                    if (Nodos_Definitivos.Contains(Nodo.Dato) == false)
                   {
                            int Distancia = (Peso_Entre_Dos_Aristas((Retornar_Nood(Nodos_Definitivos.Peek())), Nodo)) + Distancia_Lista;
                        Rotulación Re = RaizVertices;
                        bool Esta = false;
                        while(Re != null)
                        {
                            /*if(Nodos_Definitivos.Contains(Nodo.Dato) == false)*/ {
                                if (Re.Nodo.Dato.Equals(Nodo.Dato))
                                {
                                    if (Distancia < Re.Distancia)
                                    {
                                        Re.Distancia = Distancia;
                                        Re.Nodo_Precedente = Retornar_Nood(Nodos_Definitivos.Peek());
                                    }
                                    Esta = true;
                                    break;
                                }
                            }
                            Re = Re.Enlace;
                        }
                        if (Esta != true)
                        {
                            RaizVertices = new Clases.Rotulación(Retornar_Nood(Convert.ToInt32(Adyacentes[I])), Retornar_Nood(Nodos_Definitivos.Peek()), Distancia, RaizVertices);
                        }
                    }
                }
                Rotulación Recorre = RaizVertices;
                while(Recorre != null)
                {
                    if (Nodos_Definitivos.Contains(Recorre.Nodo.Dato) == false)
                    {
                        int Distancia = Recorre.Distancia;
                        if (Peso_Minimo > Distancia)
                        {
                            Peso_Minimo = Distancia;
                            Nodo_Nombre = Recorre.Nodo.Dato;
                        }
                    }
                    Recorre = Recorre.Enlace;
                }
                if (Nodos_Definitivos.Count < Contador)
                {
                    if (Nodo_Nombre != 0)
                    {
                        Nodos_Definitivos.Push(Nodo_Nombre);
                    }
                }
                else
                {                                       
                    Rotulación No = Devolver_Rotulo(SegundoNodo,RaizVertices);
                    Distancia_Final = No.Distancia;
                    Ruta = SegundoNodo .ToString() + "-";
                    Termino = true;                    
                    while (true)
                    {
                        Rotulación Do = (Devolver_Rotulo(No.Nodo_Precedente.Dato , RaizVertices));
                        int Dato = Do.Nodo.Dato; 
                        if (Dato != PrimerNodo)
                        {
                            Ruta = Ruta+Dato.ToString() + "-";
                            No = Devolver_Rotulo(Dato, RaizVertices);
                            Do = Do.Enlace;
                        }
                        else
                        {
                            Ruta = Ruta+Dato.ToString() ;
                            string[] Cola = (Ruta).Split('-');
                            Int32[] Vis = Array.ConvertAll<object, Int32>(Cola.ToArray(), Convert.ToInt32);
                            Instancia.Borrar  =true;
                            Instancia.Dibujar(null, 0, 0, 0, 0, PrimerNodo, SegundoNodo,Vis);
                            break;
                        }
                    }                    
                }
            }

            return (Ruta);
        }
        
        public int[,] Matriz_De_Incidencia(int M,int N)
        {
            //M : Numero de vertices//
            //N : Numero de aristas
            int[,] Matriz;
            Clase_Grafo Recorrer1 = Abismo;
            Matriz = new int[M, N];
            for (int I = 0; I <= M - 1; I++)
            {
                Aristas Recorrer2 = Raiz_Aristas;
                for (int J = 0; J <= N - 1; J++)
                {
                    if (Recorrer1 != null && Recorrer2 != null)
                    {
                      if((Recorrer1.Dato == Recorrer2.Grafo_Inicio.Dato) || (Recorrer1.Dato == Recorrer2.Grafo_Fin.Dato))
                        {
                            Matriz[I,J] = 1;
                        }
                         else
                        {
                            Matriz[I, J] = 0;
                        }
                    }
                    if(Recorrer2!= null)
                    {
                        Recorrer2 = Recorrer2.Enlace;
                    }
                }

                if (Recorrer1 != null)
                {
                    Recorrer1 = Recorrer1.Enlace;
                }
            }
            return Matriz;
        }
    }


}
