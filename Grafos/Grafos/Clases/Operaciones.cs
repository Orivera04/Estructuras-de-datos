using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Arboles.Clases
{

    class Operaciones
    {
        public Clase_Arboles Raiz = null;
        public Clase_Arboles Anterior = null;
        public String Cadena = "";
        public int[] Niveles = new int[] { 30, 40, 50, 55 };
        public int Cantidad = 0;
        public int Hojas = 0;
        public int Altura = 0;
        public bool Paso = false;
        public Queue<int> Cola = new Queue<int>() ;
        public Arboles Instancia;
        public int Velocidad = 200;
        public int Añadir_Item_Arbol(int Dato)
        {
            Cantidad = 0;
            Hojas = 0;
            Altura = 0;
            Clase_Arboles Aux = null;
            Clase_Arboles Recorrer;
            Clase_Arboles Nodo = null;


            if (Raiz == null)
            {
                Nodo = new Clases.Clase_Arboles(null, null, Dato, 348 / 2 - 30, 2, null);
                Raiz = Nodo; return 1;
            }

            else
            {
                if (Dato == Raiz.Dato)
                {
                    return -1;
                }
                if (Buscar(Raiz, Dato) == 1)
                {
                    return -1;
                }
                Recorrer = Raiz;
                int X = 0;
                int Y = 0;
                while (Recorrer != null)
                {
                    Aux = Recorrer;
                    if (Dato < Recorrer.Dato)
                    {
                        X = Recorrer.Punto.X;
                        Y = Recorrer.Punto.Y;
                        Recorrer = Recorrer.Enlace_Izquierdo;
                    }
                    else
                    {
                        X = Recorrer.Punto.X;
                        Y = Recorrer.Punto.Y;

                        Recorrer = Recorrer.Enlace_Derecho;
                    }
                }
                if (Dato < Aux.Dato)
                {
                    Nodo = new Clases.Clase_Arboles(null, null, Dato, X, Y, Aux);
                    Aux.Enlace_Izquierdo = Nodo;
                    int Niv = Nivel(Nodo.Dato);
                    if (Niv!= 4)
                    {
                        if (Niv == 1)
                        {
                            Aux.Enlace_Izquierdo.Punto.X = Aux.Enlace_Izquierdo.Punto.X - 85;
                            Aux.Enlace_Izquierdo.Punto.Y = Aux.Enlace_Izquierdo.Punto.Y + 50;
                        }
                        else if (Niv== 2)
                        {
                            Aux.Enlace_Izquierdo.Punto.X = Aux.Enlace_Izquierdo.Punto.X - 40;
                            Aux.Enlace_Izquierdo.Punto.Y = Aux.Enlace_Izquierdo.Punto.Y + 50;
                        }
                        else if (Niv == 3)
                        {
                            Aux.Enlace_Izquierdo.Punto.X = Aux.Enlace_Izquierdo.Punto.X - 20;
                            Aux.Enlace_Izquierdo.Punto.Y = Aux.Enlace_Izquierdo.Punto.Y + 70;
                        }
                        return 1;
                    }
                    else
                    {
                        MessageBox.Show("La altura maxima permitida es de 3", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Aux.Enlace_Izquierdo = null;
                        return -1;
                    }
                }
                else if (Dato > Aux.Dato)
                {
                    Nodo = new Clases.Clase_Arboles(null, null, Dato, X, Y, Aux);
                    Aux.Enlace_Derecho = Nodo;
                    int Niv = Nivel(Nodo.Dato);
                    if (Niv != 4)
                    {
                        if (Niv == 1)
                        {
                            Aux.Enlace_Derecho.Punto.X = Aux.Enlace_Derecho.Punto.X + 85;
                            Aux.Enlace_Derecho.Punto.Y = Aux.Enlace_Derecho.Punto.Y + 50;
                        }
                        else if (Niv == 2)
                        {
                            Aux.Enlace_Derecho.Punto.X = Aux.Enlace_Derecho.Punto.X + 40;
                            Aux.Enlace_Derecho.Punto.Y = Aux.Enlace_Derecho.Punto.Y + 50;
                        }
                        else if (Niv == 3)
                        {
                            Aux.Enlace_Derecho.Punto.X = Aux.Enlace_Derecho.Punto.X + 20;
                            Aux.Enlace_Derecho.Punto.Y = Aux.Enlace_Derecho.Punto.Y + 70;
                        }
                    }
                    else
                    {
                        MessageBox.Show("La altura maxima permitida es de 3", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //Borrar el enlace correcto //
                        Aux.Enlace_Derecho= null;
                        return -1;
                    }

                    return 1;
                }

                else { return -1; }

            }
        }
        public string Preorden(Clase_Arboles Nodo,int Bandera = 0)
        {
            if (Nodo != null)
            {

                Cadena = Cadena + " " + Nodo.Dato.ToString();
                if (Bandera == 0)
                {
                    Cola.Enqueue(Nodo.Dato);               
                    System.Threading.Thread.Sleep(Velocidad);

                    Instancia.Inorden(Raiz, 1, Cola.ToArray(), true);
                    Instancia.UltraFormattedTextEditor2.Text = "●-----------------------------●\n●     Recorrido PreOrden      ●\n" + "●-----------------------------●\n-> " + "[" + Cadena.ToString() + "]\n";
                }
                Preorden(Nodo.Enlace_Izquierdo,Bandera);
                Preorden(Nodo.Enlace_Derecho,Bandera);
            }
            return Cadena;
        }
        public string Inorden(Clase_Arboles Nodo)
        {
            if (Nodo != null)
            {
                Inorden(Nodo.Enlace_Izquierdo);                             
                Cadena = Cadena + " " + Nodo.Dato.ToString();
                Cola.Enqueue(Nodo.Dato);
                System.Threading.Thread.Sleep(Velocidad);
                Instancia.Inorden(Raiz, 1, Cola.ToArray(), true);
                Instancia.UltraFormattedTextEditor2.Text = "●-----------------------------●\n●        Recorrido Inorden      ●\n" + "●-----------------------------●\n-> " + "[" + Cadena+"]\n";
                Inorden(Nodo.Enlace_Derecho);
            }
            return Cadena;
        }

        public string PostOrden(Clase_Arboles Nodo)
        {
            if (Nodo != null)
            {
                PostOrden(Nodo.Enlace_Izquierdo);
                PostOrden(Nodo.Enlace_Derecho);
                Cadena = Cadena + " " + Nodo.Dato.ToString();
                Cola.Enqueue(Nodo.Dato);
                System.Threading.Thread.Sleep(Velocidad);               
                Instancia.Inorden(Raiz, 1, Cola.ToArray(), true);
                Instancia.UltraFormattedTextEditor2.Text = "●-----------------------------●\n●    Recorrido PostOrden      ●\n" + "●-----------------------------●\n-> " + "[" +Cadena.ToString() +"]\n";

            }
            return Cadena;
        }

        public int Cantidad_De_Nodo(Clase_Arboles Recorrer)
        {
            if (Recorrer != null)
            {
                Cantidad = Cantidad + 1;
                Cantidad_De_Nodo(Recorrer.Enlace_Izquierdo);
                Cantidad_De_Nodo(Recorrer.Enlace_Derecho);
            }
            return Cantidad;
        }
        public int Hojas_F(Clase_Arboles Recorrer)
        {
            if (Recorrer != null)
            {
                if (Recorrer.Enlace_Izquierdo == null && Recorrer.Enlace_Derecho == null)
                {
                    Hojas = Hojas + 1;
                }
                Hojas_F(Recorrer.Enlace_Izquierdo);
                Hojas_F(Recorrer.Enlace_Derecho);
            }
            return Hojas;
        }
        public int Altura_F(Clase_Arboles Recorrer, int Nivel)
        {
            if (Recorrer != null)
            {
                Altura_F(Recorrer.Enlace_Izquierdo, Nivel + 1);
                if (Nivel > Altura) { Altura = Nivel; }
                Altura_F(Recorrer.Enlace_Derecho, Nivel + 1);
            }
            return Altura;
        }

        public int Buscar(Clase_Arboles Recorer, int Dato)
        {
            if (Recorer != null)
            {
                if (Dato < Recorer.Dato)
                {
                    return Buscar(Recorer.Enlace_Izquierdo, Dato);
                }
                else if (Dato > Recorer.Dato)
                {
                    return Buscar(Recorer.Enlace_Derecho, Dato);
                }
                else
                {
                    return 1;
                }
            }
            else { return -1; };
        }

        public int Eliminar(Clase_Arboles Recorer, int Dato)
        {
            try
            {
                if (Dato < Recorer.Dato) { Anterior = Recorer;
                    return Eliminar(Recorer.Enlace_Izquierdo, Dato); }
                else if (Dato > Recorer.Dato) { Anterior = Recorer;
                    return Eliminar(Recorer.Enlace_Derecho, Dato); }
                if (Recorer.Dato == Dato)
                {

                    if (Recorer.Enlace_Izquierdo == null & Recorer.Enlace_Derecho == null)
                    {
                        Paso = false;
                        if (Anterior.Enlace_Derecho != null && Anterior.Enlace_Derecho.Equals(Recorer))
                        {
                            Anterior.Enlace_Derecho = null;
                            return 1;
                        }
                        else
                        {
                            Anterior.Enlace_Izquierdo = null;
                            return 1;
                        }
                    }
                    else if ((Recorer.Enlace_Izquierdo == null && Recorer.Enlace_Derecho != null) || (Recorer.Enlace_Izquierdo != null && Recorer.Enlace_Derecho == null))
                    {
                        Paso = false;
                        if (Recorer.Enlace_Derecho != null)
                        {
                            if (Anterior.Enlace_Derecho != null && Anterior.Enlace_Derecho.Equals(Recorer))
                            {
                                int AuxX = Anterior.Enlace_Derecho.Enlace_Derecho.Punto.X;
                                int AuxY = Anterior.Enlace_Derecho.Enlace_Derecho.Punto.Y;
                                Anterior.Enlace_Derecho = Anterior.Enlace_Derecho.Enlace_Derecho;
                                Anterior.Enlace_Derecho.Punto.X = AuxX;
                                Anterior.Enlace_Derecho.Punto.Y = AuxY;
                            }
                            else
                            {
                                try
                                {
                                    int AuxX = Anterior.Enlace_Izquierdo.Enlace_Izquierdo.Punto.X;
                                    int AuxY = Anterior.Enlace_Izquierdo.Enlace_Izquierdo.Punto.Y;
                                    Anterior.Enlace_Izquierdo = Anterior.Enlace_Izquierdo.Enlace_Izquierdo;
                                    Anterior.Enlace_Izquierdo.Punto.X = AuxX;
                                    Anterior.Enlace_Derecho.Punto.Y = AuxY;
                                }
                                catch
                                {
                                    int AuxX = Anterior.Enlace_Izquierdo.Punto.X;
                                    int AuxY = Anterior.Enlace_Izquierdo.Punto.Y;
                                    Anterior.Enlace_Izquierdo = Anterior.Enlace_Izquierdo.Enlace_Derecho;
                                    Anterior.Enlace_Izquierdo.Punto.X = AuxX;
                                    Anterior.Enlace_Derecho.Punto.Y = AuxY;
                                }
                            }

                        }
                    }
                    else
                    {
                        Paso = true;
                        Clase_Arboles Mayor_De_Los_Menores = null;
                        Clase_Arboles Recorrer2 = Recorer.Enlace_Derecho;
                        Clase_Arboles Papa = null;
                        while (Recorrer2 != null)
                        {
                            Papa = Mayor_De_Los_Menores;
                            Mayor_De_Los_Menores = Recorrer2;
                            Recorrer2 = Recorrer2.Enlace_Izquierdo;
                        }

                        if (Mayor_De_Los_Menores.Padre.Enlace_Izquierdo != null && Mayor_De_Los_Menores.Padre.Enlace_Izquierdo.Equals(Mayor_De_Los_Menores))
                        {
                            //Papa.Enlace_Izquierdo  = null;

                            Mayor_De_Los_Menores.Padre.Enlace_Izquierdo = null;

                        }
                        else
                        {
                            if (Mayor_De_Los_Menores.Enlace_Derecho  == null)
                            {
                                Mayor_De_Los_Menores.Padre.Enlace_Derecho = null;
                            }
                            else
                            {
                                Paso = false;
                                Mayor_De_Los_Menores.Padre.Enlace_Derecho = Mayor_De_Los_Menores.Enlace_Derecho;
                            }
                        }
                        Recorer.Dato = Mayor_De_Los_Menores.Dato;
                        return 1;
                    }
                }
              
            }
            catch
            {
                return -1;
            }
            return 1;
        }

        public int Nivel(int Dato)
        {
            Clase_Arboles Recorrer = Raiz;
            int Nivel = 0;
            while (Recorrer != null)
            {
                if (Dato < Recorrer.Dato)
                {
                    Recorrer = Recorrer.Enlace_Izquierdo;
                    Nivel++;
                }
                else if (Dato > Recorrer.Dato)
                {
                    Recorrer = Recorrer.Enlace_Derecho;
                    Nivel++;
                }
                if (Dato == Recorrer.Dato)
                {
                    return Nivel;
                }
            }
            return 3;
        }
        public int Es_Hoja(Clase_Arboles Recorrer, int Dato)
        {
            if (Recorrer != null)
            {
                if (Recorrer.Dato == Dato)
                {
                    if (Recorrer.Enlace_Derecho == null & Recorrer.Enlace_Izquierdo == null)
                    {
                        return 1;
                    }
                }

                if (Dato < Recorrer.Dato)
                {
                    return Es_Hoja(Recorrer.Enlace_Izquierdo, Dato);
                }
                else if (Dato > Recorrer.Dato)
                {
                    return Es_Hoja(Recorrer.Enlace_Derecho, Dato);
                }
            }

            else
            {
                return -1;
            }
            return -1;
        }
        public void Actualizar(int[] A,int  Del)
        {
            Raiz = null;
            foreach(int Numero in A)
            {
                if (Numero != Del)
                {
                    Añadir_Item_Arbol(Numero);
                }
            }            
        }

        public Clase_Arboles Buscar_Nodo(int Dato , Clase_Arboles Raiz)
        {
            if (Dato == Raiz.Dato)
            {
                return Raiz;
            }
            if (Dato > Raiz.Dato)
            {
                return Buscar_Nodo(Dato, Raiz.Enlace_Derecho);
            }
            else
            {
                return Buscar_Nodo(Dato, Raiz.Enlace_Izquierdo);
            }         
        }

        public void Guardar()
        {
            SaveFileDialog Dialogo = new SaveFileDialog();
            Dialogo.Filter = "Archivo Grafo |*.arbol";
            string Prefix = Preorden(Raiz,1);
            if (Dialogo.ShowDialog() == DialogResult.OK)
            {

                FileStream Conector = new FileStream(Dialogo.FileName, FileMode.Create, FileAccess.Write);
                StreamWriter Escribir = new StreamWriter(Conector);

                string[] Nodos = Prefix.Split(' ');
                for(int I = 1; I<= Nodos.Length-1; I++)
                {
                    Escribir.WriteLine(Nodos[I]);
                }
                Escribir.Close();
                Dialogo.Dispose();
                MessageBox.Show("El arbol se guardo con exito", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Leer()
        {
            OpenFileDialog Dialogo = new OpenFileDialog();
            Dialogo.Filter = "Archivo Arbol |*.arbol";
            if (Dialogo.ShowDialog() == DialogResult.OK)
            {
                Raiz = null;
                this.Hojas = 0;
                this.Cantidad = 0;
                string[] Lineas = File.ReadAllLines(Dialogo.FileName);
                for (int I = 1; I <= Lineas.Length - 1; I++)
                {
                    Añadir_Item_Arbol(Convert.ToInt32(Lineas[I]));
                }
            }            
            
            }
    }
        
}

