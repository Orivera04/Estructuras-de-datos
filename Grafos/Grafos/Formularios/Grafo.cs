using Grafos.Clases;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections;
using System.Linq;
using System.Threading;
using System.Diagnostics;

namespace Grafos

{

    public partial class Grafo : Form
    {
        Clases.Operaciones_Grafos Instancia = new Clases.Operaciones_Grafos();
        public string Operacion;
        int X; int Y;public  int Contador = 1;
        public bool Borrar = true;
        bool Color_Swap_Par = true;
        bool Color_Swap_Pares = true;
        bool Hubo_Interseccion = false;
        bool Aristas = false;
        bool Clic = false;
        bool Aviso = true;
        public int Contador_Vertex = 0;
        bool Borrar_Arista = false;
        Point Arista;
        Clases.Clase_Grafo Aux;
        Clases.Clase_Grafo Nodo_1;
        Clases.Clase_Grafo Nodo_2;
        Graphics Graficos_Del_PictureBox;
        
        enum Operaciones
        {
            Añadir_Vertice, Añadir_Arista, Eliminar_Vertice, Eliminar_Arista,Busqueda,Recorrido_En_Anchura,Dikstra
        }
        public Grafo()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
            CheckForIllegalCrossThreadCalls = false;
         }

        private void Grafo_Load(object sender, EventArgs e)
        {
             ultraComboEditor1.Text = Convert.ToString(ultraComboEditor1.Items.GetItem(0));
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI Light", 12.75f, FontStyle.Regular);
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView2.DefaultCellStyle.Font = new Font("Segoe UI Light", 11.75f, FontStyle.Regular);
            dataGridView2.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView3.DefaultCellStyle.Font = new Font("Segoe UI Light", 11.75f, FontStyle.Regular);
            dataGridView3.DefaultCellStyle.ForeColor = Color.Black;
            this.SetStyle(ControlStyles.DoubleBuffer |
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint,
            true);
            this.UpdateStyles();
            Instancia.Instancia = this;

            
        }

        private void ultraButton6_Click(object sender, EventArgs e)
        {
            if (ultraComboEditor1.Text == Convert.ToString(ultraComboEditor1.Items.GetItem(0)))
            {
                ultraPanel5.Visible = true; 
                ultraPanel1.Visible = false;
                ultraPanel7.Visible = false;
                Operacion = Convert.ToString(Operaciones.Añadir_Vertice);
            }
            else if (ultraComboEditor1.Text == Convert.ToString(ultraComboEditor1.Items.GetItem(1)))
            {
                ultraPanel5.Visible = true;
                ultraPanel1.Visible = true;
                ultraPanel3.Visible = false;
                ultraPanel7.Visible = false;
                ultraPanel8.Visible = false;
                ultraPanel9.Visible = false;
                Operacion = Convert.ToString(Operaciones.Añadir_Arista);
            }
            else if (ultraComboEditor1.Text == Convert.ToString(ultraComboEditor1.Items.GetItem(2)))
            {
                ultraPanel5.Visible = true;
                ultraPanel1.Visible = true;
                ultraPanel3.Visible = true;
                ultraPanel6.Visible = false;
                ultraPanel7.Visible = false;
                ultraPanel8.Visible = false;
                ultraPanel9.Visible = false;
                Operacion = Convert.ToString(Operaciones.Eliminar_Vertice);
            }
            else if (ultraComboEditor1.Text == Convert.ToString(ultraComboEditor1.Items.GetItem(3)))
            {
                ultraPanel5.Visible = true;
                ultraPanel1.Visible = true;
                ultraPanel3.Visible = true;
                ultraPanel4.Visible = true;
                ultraPanel6.Visible = false;
                ultraPanel7.Visible = false;
                ultraPanel8.Visible = false;
                ultraPanel9.Visible = false;
                Operacion = Convert.ToString(Operaciones.Eliminar_Arista);
            }
            else if (ultraComboEditor1.Text == Convert.ToString(ultraComboEditor1.Items.GetItem(4)))
            {
                Instancia.Raiz = null;
                Instancia.Raiz_Aristas  = null;
                Instancia.Fondo  = null;
                Instancia.Contador_Aristas = 0;
                Contador = 1;
                Contador_Vertex  = 0;
                dataGridView1.Rows.Clear();
                dataGridView2.Columns.Clear();
                dataGridView2.Rows.Clear();
                dataGridView3.Columns.Clear();
                dataGridView3.Rows.Clear();
                ultraButton14.PerformClick();
                label4.Visible = true
                                       ;
                label32.Visible = true;
                label21.Visible = true;                
                label10.Text = "Nodos -> 0";
                label14.Text = "Aristas -> 0";
                ultraFormattedTextEditor1.Text = "";
                label26.Visible = true;                
                MessageBox.Show("El grafo se ha eliminado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (ultraComboEditor1.Text == Convert.ToString(ultraComboEditor1.Items.GetItem(5)))
            {
                ultraPanel5.Visible = true;
                ultraPanel1.Visible = true;
                ultraPanel3.Visible = true;
                ultraPanel4.Visible = true;
                ultraPanel4.Visible = true;
                ultraPanel6.Visible = true;
                ultraPanel7.Visible = false;
                ultraPanel8.Visible = false;
                ultraPanel9.Visible = false;
                Operacion = Convert.ToString(Operaciones.Busqueda);
            }

            else if((ultraComboEditor1.Text == Convert.ToString(ultraComboEditor1.Items.GetItem(6))))
                {
                ultraPanel1.Visible = true;
                ultraPanel3.Visible = true;
                ultraPanel4.Visible = true;
                ultraPanel5.Visible = true;
                ultraPanel6.Visible = true;
                ultraPanel7.Visible = true;
                ultraPanel8.Visible = false;
                ultraPanel9.Visible = false;
                Operacion = Convert.ToString(Operaciones.Recorrido_En_Anchura);
                            }
            else if ((ultraComboEditor1.Text == Convert.ToString(ultraComboEditor1.Items.GetItem(7))))
            {
                ultraPanel1.Visible = true;
                ultraPanel3.Visible = true;
                ultraPanel4.Visible = true;
                ultraPanel5.Visible = true;
                ultraPanel6.Visible = true;
                ultraPanel7.Visible = true;
                ultraPanel8.Visible = true;
                ultraPanel9.Visible = false;
            }
            else
            {
                ultraPanel1.Visible = true;
                ultraPanel3.Visible = true;
                ultraPanel4.Visible = true;
                ultraPanel5.Visible = true;
                ultraPanel6.Visible = true;
                ultraPanel7.Visible = true;
                ultraPanel8.Visible = true;
                ultraPanel9.Visible = true ;
                Operacion = Convert.ToString(Operaciones.Dikstra);
            }
        }

        private void ultraButton1_Click_1(object sender, EventArgs e)
        {
            ultraPanel5.Visible = false;
        }



        private void pictureBox14_MouseMove(object sender, MouseEventArgs e)
        {
            X = e.X;
            Y = e.Y;
            label6.Text = "(" + X.ToString() + "," + Y.ToString() + ")";
            Aux = this.Intersección(e.X, e.Y);           
            if (Operacion == Convert.ToString(Operaciones.Añadir_Vertice))
            {
                if (Intersección(e.X, e.Y) != null)
                {
                    Cursor = Cursors.SizeAll;
                    Hubo_Interseccion = true;
                }
                else
                {
                    Hubo_Interseccion = false;
                    Cursor = Cursors.Default;
                }
                if (MouseButtons.Equals(MouseButtons.Left))
                {
                    try
                    {
                        Aux.Locacion.X = e.X - 7;
                        Aux.Locacion.Y = e.Y - 7;
                        Borrar = true;                                                
                        Instancia.Visitados.Clear();                        
                        Dibujar(null, 0, 0,0);
                    }
                    catch { }

                }


            }
            else if (Operacion == Convert.ToString(Operaciones.Añadir_Arista))
            {                
                Hubo_Interseccion = false;
                if (Intersección(e.X, e.Y) != null)
                {
                    Cursor = Cursors.Hand;
                    Borrar = true;
                    Hubo_Interseccion = true;
                    if (Aristas == false)
                    {
                        if (Clic == true)
                        {
                            Nodo_1 = Aux;
                            Aristas = true;
                            Arista = new Point(Aux.Locacion.X + 5, Aux.Locacion.Y + 5);                                                                                                                
                        }
                    }
                    else
                    {
                        Nodo_2 = Aux;
                        if (Clic == true)
                        {
                            if(Nodo_1  != null & Nodo_2 != null )
                            { 
                            if (Instancia.Validar_Arista(Nodo_1, Nodo_2) != 1)
                            {
                                Instancia.Añadir_Arista(Nodo_1, Nodo_2);
                                Actualizar_Datagrid_Matriz(Instancia.Matriz_De_Adyacencia(Contador_Vertex ));
                                Actualizar_Datagridview();
                                label14.Text = "Aristas -> " + Instancia.Contador_Aristas.ToString();
                                    Actualizar_Datagrid_Matriz_De_Incidencia(Instancia.Matriz_De_Incidencia(Contador_Vertex, Instancia.Contador_Aristas));
                                    Tipo_Grafo();
                                }
                            else
                            {
                                MessageBox.Show("La arista ya existe", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            Aristas = false;
                        }
                            else
                            {
                                MessageBox.Show("No se selccionaron los nodos", "Atenciòn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    Borrar = true;
                    Dibujar(null, Aux.Dato, 0,0);
                }
                else
                {
                    Cursor = Cursors.Default;
                    Borrar = true;
                    Dibujar(null, 0, 0,0);

                }

            }
            else if (Operacion == Convert.ToString(Operaciones.Eliminar_Vertice))
            {
                
                Hubo_Interseccion = false;
                if (Intersección(e.X, e.Y) != null)
                {
                    Cursor = Cursors.Cross;                    
                    Borrar = true;
                    Hubo_Interseccion = true;
                    Borrar = true;
                    Dibujar(null, Aux.Dato, 1,0);
                        if (Clic == true)
                        {
                        if (MessageBox.Show("¿Desea borrar este nodo? se eliminaran las aristas marcadas en rojo","Atención",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                             Instancia.Eliminar_Aristas(Aux.Dato);
                             Instancia.Eliminar_Aristas(Aux.Dato);
                             Instancia.Eliminar_Aristas(Aux.Dato);
                            Aviso = false;
                            int Posicion = 0;
                            int Ar  = 0;
                            for (int I = 0; I<= dataGridView1.Rows.Count-1;I++)
                            {
                                Posicion = I;
                                if (Convert.ToInt16(dataGridView1.Rows[I].Cells[0].Value) == Aux.Dato)
                                {
                                    Ar = Convert.ToInt16(dataGridView1.Rows[I].Cells[1].Value);
                                    break;
                                }                                
                            }
                            Instancia.Contador_Aristas = Instancia.Contador_Aristas - Ar;
                            label14.Text = "Aristas -> " + Instancia.Contador_Aristas.ToString();
                            Instancia.Eliminar_Nodos(Aux.Dato);
                            Instancia.Eliminar_Lista(Aux.Dato);
                            Cursor.Position = new Point(this.Location.X+800, this.Location.Y+350);
                            Actualizar_Datagridview();
                            dataGridView1.Rows.RemoveAt(Posicion);
                            Contador_Vertex--;
                            Actualizar_Datagrid_Matriz(Instancia.Matriz_De_Adyacencia(Contador_Vertex));
                            label10.Text = "Nodos -> " + Contador_Vertex.ToString();
                            Tipo_Grafo();

                        }
                    }
                }
                
            else
                {
                    Aviso = false;
                    Cursor = Cursors.Default;
                    Borrar = true;
                    Hubo_Interseccion = false;
                    Dibujar(null, 0, 0,0);
                }
            }
            else if(Operacion == Convert.ToString(Operaciones.Eliminar_Arista))
            {
                
                Hubo_Interseccion = false;
                if (Intersección(e.X, e.Y) != null)
                {
                    Cursor = Cursors.Hand;
                    
                    Hubo_Interseccion = true;
                    if (Borrar_Arista == false)
                    {
                        if (Clic == true)
                        {
                            Nodo_1 = Aux;
                            Borrar_Arista = true;
                        }
                        Borrar = true;
                        Dibujar(null, Aux.Dato, 0,0);
                    }
                    else
                    {
                        if ((Aux != Nodo_1) )
                        {
                                                        
                            if (Clic == true)
                            {
                                Nodo_2 = Aux;
                                if (Instancia.Existe_Arista(Nodo_1, Nodo_2) == 1)
                                {
                                    Borrar = true;
                                    Dibujar(null, Aux.Dato, 2,0);
                                    if (MessageBox.Show("¿Desea borrar la arista", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        Instancia.Borrar_Arista(Nodo_1, Nodo_2);
                                        Instancia.Contador_Aristas--;                                        
                                        label14.Text = "Aristas -> " + Instancia.Contador_Aristas;
                                        Actualizar_Datagridview();
                                        Borrar_Arista = false;
                                        Actualizar_Datagrid_Matriz(Instancia.Matriz_De_Adyacencia(Contador_Vertex));
                                        Actualizar_Datagrid_Matriz_De_Incidencia(Instancia.Matriz_De_Incidencia(Contador_Vertex,Instancia.Contador_Aristas));
                                        Tipo_Grafo();
                                    }
                                    else
                                    {
                                        Borrar_Arista = false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No existe ninguna arista entre estos nodos ", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Borrar_Arista = false;

                                }
                            }
                        }
                        Borrar = true;
                        Dibujar(null, Aux.Dato, 0,0);
                    }
                }
                else
                {
                    Borrar = true;
                    Dibujar(null, 0, 0,0);
                    Cursor = Cursors.Default;
                }

            }
            Clic = false;
        }
        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Clic = true;
            if (Hubo_Interseccion != true)
            {
                if (Operacion == Convert.ToString(Operaciones.Añadir_Vertice))
                {
                    dataGridView1.Rows.Add(Contador.ToString(), "0", "Ninguno");
                    label3.Visible = false;                    
                    if (Contador % 2 != 0)
                    {
                        if (Color_Swap_Par == true)
                        {
                            Instancia.Añadir_Grafo(Contador, X, Y, Color.LightSalmon);
                            //253,178,9                       
                            Color_Swap_Par = false;
                        }
                        else
                        {
                            Instancia.Añadir_Grafo(Contador, X, Y, Color.RoyalBlue);
                            Color_Swap_Par = true;
                        }
                    }
                    else
                    {
                        if (Color_Swap_Pares == true)
                        {
                            Instancia.Añadir_Grafo(Contador, X, Y, Color.LightGreen);
                            Color_Swap_Pares = false;
                        }
                        else
                        {
                            Instancia.Añadir_Grafo(Contador, X, Y, Color.LightPink);
                            Color_Swap_Pares = true;
                        }
                    }
                    label4.Visible = false;
                    label21.Visible = false;                    
                    Actualizar_Datagrid_Matriz(Instancia.Matriz_De_Adyacencia(Contador_Vertex+1));
                    Actualizar_Datagrid_Matriz_De_Incidencia(Instancia.Matriz_De_Incidencia(Contador_Vertex+1, Instancia.Contador_Aristas));
                    Borrar = true;
                    Dibujar(null, 0, 0,0);
                    Contador_Vertex++;
                    label10.Text = "Nodos-> " + Contador_Vertex.ToString();
                    Contador++;
                    Tipo_Grafo();
                }
            }
        }

        public void Dibujar(int[] Cola ,int Dato = 0, int Parametro= 0,int Parametro_2 = 0,int Adyacente  = -1,int Nodo1 =0 ,int  Nodo2 = 0,int [] C = null)
        {

            bool Bandera = false;
            Bitmap Dibujo = default(Bitmap);
            Dibujo = new Bitmap(pictureBox14.Width, pictureBox14.Height);
            Graphics Buf = Graphics.FromImage(Dibujo);
            Graficos_Del_PictureBox = pictureBox14.CreateGraphics();
            Pen Lapiz = new Pen(Color.LightGray, 3);
            Pen Lapiz2 = new Pen(Color.OrangeRed, 3); // PaleVioletRED
            Pen Lapiz3 = new Pen(Color.PaleVioletRed, 3); // PaleVioletRED
            Pen Lapiz4 = new Pen(Color.MediumPurple , 3);
            Pen Lapiz5 = new Pen(Color.White , 3);
            Pen Lapiz6 = new Pen(Color.Red, 3);
            Lapiz6.DashStyle = DashStyle.Dash;
            Lapiz.DashStyle = DashStyle.Solid;            
            Buf.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Rectangle rectangulo = new Rectangle(0, 0, 353, 243);
            if (Borrar == true)
            {
                Buf.FillRectangle(Brushes.White, rectangulo);
                Borrar = false;
            }
            if (Instancia.Raiz == null)
            {
                Buf.FillRectangle(Brushes.White, rectangulo);
            }
            else
            {
                Point Aux = new Point(Arista.X + 7, Arista.Y + 3);
                if (Aristas == true)
                {
                    Buf.DrawLine(Lapiz, Aux, new Point(X, Y));
                }
                Aristas Recorr = Instancia.Raiz_Aristas;
                while (Recorr != null)
                {
                    Font Fuente = new Font("Roboto Condensed", 12);

                    Point Prueba_1 = new Point(Recorr.Grafo_Inicio.Locacion.X + 9, Recorr.Grafo_Inicio.Locacion.Y + 10);
                    Point Prueba_2 = new Point(Recorr.Grafo_Fin.Locacion.X + 9, Recorr.Grafo_Fin.Locacion.Y + 13);
                    Point Prueba_4 = new Point(((Prueba_1.X + Prueba_2.X) / 2), ((Prueba_1.Y + Prueba_2.Y) / 2));
                    if (Parametro != 1 & Parametro != 2)
                    {
                        bool Existe = false;
                        if (C != null)
                        {
                            for (int M = 0; M <= C.Length - 2; M++)
                            {
                                {
                                    if ((C[M] == Recorr.Grafo_Fin.Dato && C[M + 1] == Recorr.Grafo_Inicio.Dato) || (C[M] == Recorr.Grafo_Inicio.Dato && C[M + 1] == Recorr.Grafo_Fin.Dato))
                                    {
                                        Existe = true;
                                    }
                                }

                            }
                            
                        }
                        if (Existe == false)
                        {
                            Buf.DrawLine(Lapiz, Prueba_1, Prueba_2);
                        }
                    }                    
                    else if (Parametro == 1)
                    {
                        if (Recorr.Grafo_Inicio.Dato == Dato | Recorr.Grafo_Fin.Dato == Dato)
                        {
                            Buf.DrawLine(Lapiz2, Prueba_1, Prueba_2);
                        }
                        else
                        {
                            Buf.DrawLine(Lapiz, Prueba_1, Prueba_2);
                        }
                    }
                    else
                    {
                        if ((Nodo_1.Equals(Recorr.Grafo_Inicio) & Nodo_2.Equals(Recorr.Grafo_Fin)) | (Nodo_2.Equals(Recorr.Grafo_Inicio) & Nodo_1.Equals(Recorr.Grafo_Fin)))
                        {
                            Buf.DrawLine(Lapiz3, Prueba_1, Prueba_2);
                        }
                        else
                        {
                            Buf.DrawLine(Lapiz, Prueba_1, Prueba_2);
                        }
                    }
                    if (Cola != null)
                    {
                        if (Operacion == Convert.ToString(Operaciones.Recorrido_En_Anchura))
                        {
                            if (Cola.Contains(Recorr.Grafo_Inicio.Dato) || Cola.Contains(Recorr.Grafo_Fin.Dato))
                            {
                                Buf.DrawLine(Lapiz5, Prueba_1, Prueba_2);
                                Buf.DrawLine(Lapiz4, Prueba_1, Prueba_2);
                            }
                        }
                        else
                        {
                            if (Cola.Contains(Recorr.Grafo_Fin.Dato))
                            {
                                if (Cola.Length > 1)
                                {
                                    Buf.DrawLine(Lapiz5, Prueba_1, Prueba_2);
                                    Buf.DrawLine(Lapiz4, Prueba_1, Prueba_2);
                                }
                            }
                            //    for (int E = 0; E <= Cola.Length - 1; E++)
                            //    {
                            //        if (E == 0)
                            //        {
                            //            try
                            //            {
                            //                Clase_Grafo Nodo = Instancia.Retornar_Nood(Cola[0]);
                            //                Clase_Grafo No = Instancia.Retornar_Nood(Cola[1]);

                            //                Point P = new Point(Nodo.Locacion.X , Nodo.Locacion.Y+15 );
                            //                Point P2 = new Point(No.Locacion.X+3 , No.Locacion.Y +15);
                            //                Buf.DrawLine(Lapiz5, Prueba_1, Prueba_2);
                            //                Buf.DrawLine(Lapiz4, Prueba_1, Prueba_2);
                            //            }
                            //            catch { }
                            //        }
                            //        else
                            //        {
                            //            try
                            //            {
                            //                Clase_Grafo Nodo22 = Instancia.Retornar_Nood(Cola[E]);
                            //                Clase_Grafo No22 = Instancia.Retornar_Nood(Cola[E + 1]);

                            //                Point P = new Point(Nodo22.Locacion.X , Nodo22.Locacion.Y+10);
                            //                Point P2 = new Point(No22.Locacion.X+25 , No22.Locacion.Y+12 );
                            //                Buf.DrawLine(Lapiz5, Prueba_1, Prueba_2);
                            //                Buf.DrawLine(Lapiz4, Prueba_1, Prueba_2);
                            //                Borrar = true;
                            //            }
                            //            catch { }
                            //        }
                            //    }
                            }
                        }
                    if (C != null)
                    {
                        for (int M = 0; M <= C.Length - 2; M++)
                        {
                            {
                                if ((C[M] == Recorr.Grafo_Fin.Dato && C[M + 1] == Recorr.Grafo_Inicio.Dato) || (C[M] == Recorr.Grafo_Inicio.Dato && C[M + 1] == Recorr.Grafo_Fin.Dato))
                                {
                                    
                                    Buf.DrawLine(Lapiz6, Prueba_1, Prueba_2);
                                }
                            }

                        }
                    }             
                    Buf.DrawString(Recorr.Peso.ToString(), Fuente, Brushes.Black, Prueba_4);
                    Recorr = Recorr.Enlace;
                }
                Clase_Grafo Grafo = Instancia.Raiz;                
                while (Grafo != null)
                {
                    Rectangle Rectangulo = new Rectangle(Grafo.Locacion.X, Grafo.Locacion.Y, 27, 27);
                    Font Fuente = new Font("Roboto Condensed", 12);
                    SolidBrush Pincel = new SolidBrush(Color.White);
                    Buf.FillEllipse(Brushes.White, Rectangulo);                    
                    if (Dato != 0)
                    {
                        if (Grafo.Dato == Dato)
                        {
                            if (!(Operacion == Convert.ToString(Operaciones.Eliminar_Vertice)))
                            {                                                                
                                Buf.FillEllipse(Brushes.Orchid, Rectangulo);
                                if (Operacion == Convert.ToString(Operaciones.Busqueda)) 
                                {                                    
                                    Bandera = true;
                                }
                            }                           
                            else
                            {
                                Buf.FillEllipse(Brushes.Red, Rectangulo);
                            }                       
                        }
                        else
                        {
                            Buf.FillEllipse(Grafo.Pincel, Rectangulo);
                        }
                    }
                    else
                    {
                        if (Cola != null && Cola.Contains(Grafo.Dato))
                        {
                            Buf.FillEllipse(Brushes.LightSkyBlue, Rectangulo);
                        }
                        else
                        {
                            Buf.FillEllipse(Grafo.Pincel, Rectangulo);
                        }
                        if(Nodo1 == Grafo.Dato || Nodo2 == Grafo.Dato)
                        {
                            Buf.FillEllipse(Brushes.White, Rectangulo);
                            Buf.FillEllipse(Brushes.Orchid,Rectangulo);
                        }
                    }

                    if (Grafo.Dato < 10)
                    {
                        Buf.DrawString(Convert.ToString(Grafo.Dato), Fuente, Pincel, Grafo.Locacion.X + 7, Grafo.Locacion.Y + 3);
                    }
                    else
                    {
                        Buf.DrawString(Convert.ToString(Grafo.Dato), Fuente, Pincel, Grafo.Locacion.X + 3, Grafo.Locacion.Y + 3);
                    }
                    Grafo = Grafo.Enlace;
                }
            }
            if(Bandera == false & Operacion == Convert.ToString(Operaciones.Busqueda) & Parametro_2 == 1)
            {
                MessageBox.Show("El nodo no existe en el grafo ","Atención",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            try
            {
                Graficos_Del_PictureBox.DrawImage(Dibujo, new Point(0, 0));
                Graficos_Del_PictureBox.Dispose();
                Buf.Dispose();
                Dibujo.Dispose();
            }
            catch { }

        }

        public Clase_Grafo Intersección(int Mouse_X, int Mouse_Y)
        {
            Clase_Grafo Recorrer = Instancia.Raiz;
            while (Recorrer != null)
            {
                Rectangle Rectangulo_1 = new Rectangle(Recorrer.Locacion.X, Recorrer.Locacion.Y, 27, 27);
                Rectangle Rectangulo_2 = new Rectangle(Mouse_X, Mouse_Y, 27, 27);

                if (Rectangulo_1.IntersectsWith(Rectangulo_2))
                {
                    return Recorrer;
                }
                Recorrer = Recorrer.Enlace;
            }
            return null;
        }

        private void ultraComboEditor1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)e.KeyChar)
            {
                ultraButton6.PerformClick();
            }
        }

        private void ultraButton4_Click(object sender, EventArgs e)
        {
            ultraPanel1.Visible = false;
            ultraPanel5.Visible = false;
            Operacion = "Ninguno";
        }

        private void ultraButton3_Click(object sender, EventArgs e)
        {
            ultraPanel5.Visible = true;
            ultraPanel1.Visible = false;
            Operacion = Convert.ToString(Operaciones.Añadir_Vertice);
        }

        private void ultraButton5_Click(object sender, EventArgs e)
        {
            ultraPanel5.Visible = true;
            ultraPanel1.Visible = true;
            ultraPanel3.Visible = false;
            Operacion = Convert.ToString(Operaciones.Añadir_Arista);
        }

        private void ultraButton9_Click(object sender, EventArgs e)
        {
            ultraPanel5.Visible = false;
            Operacion = "Ninguno";
        }

        public void Actualizar_Datagridview()
        {
            for (int I = 0; I <= dataGridView1.Rows.Count - 1; I++)
            {
                dataGridView1.Rows[I].Cells[1].Value = Instancia.Adyacentes(Convert.ToInt16(dataGridView1.Rows[I].Cells[0].Value.ToString()));
                dataGridView1.Rows[I].Cells[2].Value = Instancia.Nodos_Adyacentes(Convert.ToInt16(dataGridView1.Rows[I].Cells[0].Value.ToString()));
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.ColumnIndex == 0)
            //    {
            //        Borrar = true;
            //        Dibujar(null, Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[0].Value), 1,0);
            //    }
            //}
            //catch
            //{

            //}
        }

        private void ultraButton14_Click(object sender, EventArgs e)
        {
            Borrar = true;
            Dibujar(null, 0, 0,0);
        }

        private void ultraButton7_Click(object sender, EventArgs e)
        {
            ultraPanel5.Visible = true;
            ultraPanel1.Visible = true;
            ultraPanel3.Visible = true;
            ultraPanel4.Visible = false;
            Operacion = Convert.ToString(Operaciones.Eliminar_Vertice);
        }

        private void ultraButton10_Click(object sender, EventArgs e)
        {
            ultraPanel5.Visible = false;
            ultraPanel1.Visible = false;
            ultraPanel3.Visible = false;
            Operacion = "N";
        }

        private void Grafo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((int)e.KeyChar == (int)Keys.Escape)
            {
                Aristas = false;
                Cursor.Position = new Point(this.Location.X + 800, this.Location.Y + 350);
            }
        }

        private void ultraButton11_Click(object sender, EventArgs e)
        {
            ultraPanel5.Visible = false;
            ultraPanel1.Visible = false;
            ultraPanel3.Visible = false;
            ultraPanel4.Visible = false;
            Operacion = "";
        }

        private void ultraButton8_Click(object sender, EventArgs e)
        {
            ultraPanel5.Visible = true;
            ultraPanel1.Visible = true;
            ultraPanel3.Visible = true;
            ultraPanel4.Visible = true;
            ultraPanel6.Visible = false;
            ultraPanel7.Visible = false;
            ultraPanel8.Visible = false;
            Operacion = Convert.ToString(Operaciones.Eliminar_Arista);
        }

        public void Actualizar_Datagrid_Matriz(int[,] Matriz)
        {
            Clase_Grafo Abi = Instancia.Abismo;

            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            dataGridView2.Columns.Add("d","Vertices");
            while (Abi != null)
            {
                dataGridView2.Columns.Add("d", Abi.Dato.ToString());
                Abi = Abi.Enlace;
            }
                                    
            Clase_Grafo Ab = Instancia.Abismo;
            while (Ab != null)
            {
                dataGridView2.Rows.Add(Ab.Dato.ToString());
                Ab= Ab.Enlace;
            }
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            try
            {
            
                for (int I = 0;I<(Matriz.GetLength(1)); I++ )
            {
                for (int J = 0; J < (Matriz.GetLength(0)); J++)
                {
                    dataGridView2.Rows[I].Cells[J+1].Value = Convert.ToString(Matriz[I, J]);
                        if (Matriz[I, J] == 0) {
                            dataGridView2.Rows[I].Cells[J + 1].Style.ForeColor = Color.Red;
                                }
                        else
                        {
                            dataGridView2.Rows[I].Cells[J + 1].Style.ForeColor = Color.Black;
                        }
                }
            }
                dataGridView2.AutoSizeRowsMode =
        DataGridViewAutoSizeRowsMode.DisplayedHeaders ;
            }            
            catch
            {
            }
        }



        public void Actualizar_Datagrid_Matriz_De_Incidencia(int[,] Matriz)
        {

            Aristas Abi = Instancia.Raiz_Aristas;
            label32.Visible = false;
            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();
            dataGridView3.Columns.Add("d", "Vertices");
            while (Abi != null)
            {
                dataGridView3.Columns.Add("d", Abi.Grafo_Inicio.Dato.ToString() + "-" + Abi.Grafo_Fin.Dato.ToString());
                Abi = Abi.Enlace;
            }

            Clase_Grafo Ab = Instancia.Abismo;
            while (Ab != null)
            {
                dataGridView3.Rows.Add(Ab.Dato.ToString());
                Ab = Ab.Enlace;
            }
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            for (int I = 0; I < Contador_Vertex ; I++)
            {
                for (int J = 0; J < (Matriz.GetLength(1)) ; J++)
                {
                                        
                    {
                        dataGridView3.Rows[I].Cells[J + 1].Value = Convert.ToString(Matriz[I, J]);
                        if (Matriz[I, J] == 0)
                        {
                            dataGridView3.Rows[I].Cells[J + 1].Style.ForeColor = Color.Red;
                        }
                        else
                        {
                            dataGridView3.Rows[I].Cells[J + 1].Style.ForeColor = Color.Black;
                        }
                    }        
            }              
            }
            try
            {
                dataGridView2.AutoSizeRowsMode =
            DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            }
            catch { }
        }


        private void pictureBox14_MouseLeave(object sender, EventArgs e)
        {
            if (Aviso == false)
            {

                this.Cursor = Cursors.Default;
                ultraButton14.PerformClick();
            }
        }

        private void ultraButton15_Click(object sender, EventArgs e)
        {
            //Busqueda//
            Borrar = true;
            Dibujar(null, Convert.ToInt16(ultraNumericEditor1.Value), 5,1);
        }

        private void ultraButton13_Click(object sender, EventArgs e)
        {
            ultraPanel5.Visible = false;
            ultraPanel1.Visible = false;
            ultraPanel3.Visible = false;
            ultraPanel4.Visible = false;
            ultraPanel6.Visible = false;
        }

        private void ultraNumericEditor1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((int)e.KeyChar == (int)Keys.Enter )
            {
                ultraButton15.PerformClick();
            }
        }

        private void ultraButton16_Click(object sender, EventArgs e)
        {
            int Dato = Convert.ToInt32(ultraNumericEditor2.Value);
            if (Instancia.Existe_Nodo(Dato))
            {
                label26.Visible = false;
                Thread Hilo = new Thread(() => Instancia.Recorrido_Anchura(Dato, Contador));
                Hilo.Start();
            }
            else
            {
                MessageBox.Show("El nodo digitado no existe", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }     
        }


        private void pictureBox18_Click(object sender, EventArgs e)
        {

        }

        private void ultraButton19_Click(object sender, EventArgs e)
        {
            ultraButton9.PerformClick();
        }

        private void ultraButton18_Click(object sender, EventArgs e)
        {
            int Nodo = Int32.Parse(Convert.ToString(ultraNumericEditor3.Value));
            if (Instancia.Existe_Nodo(Nodo))
            {
                label26.Visible = false;
                Thread Hilo = new Thread(() => Instancia.Recorrido_Profundidad(Nodo, Contador));
                Instancia.Visitados.Clear();
                Hilo.Start();
            }
            else
            {
                MessageBox.Show("El nodo digitado no existe", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ultraButton17_Click(object sender, EventArgs e)
        {
            ultraButton9.PerformClick();
        }
    
        private void contextMenuStrip2_Click(object sender, EventArgs e)
        {
            
        }

        private void contextMenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string Dato = e.ClickedItem.Text  ;
            switch (Dato)
                {
                case "200 Milisegundos":
                    Instancia.Velocidad = 200;
                    
                  

                    break;
                case "500 Milisegundos":
                    Instancia.Velocidad = 500;                 
                    break;
                case "1 Segundo":
                    
                    Instancia.Velocidad = 1000;
                    break;
                default:
             
                    Instancia.Velocidad = 2000;
                    break;
            }
        }

        private void ultraNumericEditor2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((int)e.KeyChar == (int)Keys.Enter)
            {
                ultraButton16.PerformClick();
            }
        }

        private void ultraNumericEditor3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                ultraButton18.PerformClick();
            }
        }

        private void ultraNumericEditor3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string Dato = e.ClickedItem.Text;
            switch (Dato)
            {
                case "Guardar Grafo":
                    Instancia.Guardar_Grafo();
                    break;
                case "Cargar Grafo":
                    Instancia.Leer_Grafo();
                    label21.Visible = false;
                    label4.Visible = false;
                    label26.Visible = true;
                    label10.Text = "Nodos -> " + Contador_Vertex.ToString();
                    label14.Text = "Aristas -> " + Instancia.Contador_Aristas.ToString();
                    ultraFormattedTextEditor1.Text = "";
                    break;                    
            }
        }

        private void ultraButton21_Click(object sender, EventArgs e)
        {
            ultraButton9.PerformClick();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void ultraButton20_Click(object sender, EventArgs e)
        {
            int PrimerNodo = Convert.ToInt32(ultraNumericEditor4.Value);
            int SegundoNodo = Convert.ToInt32(ultraNumericEditor5.Value);
            if (Instancia.Esta_En_Alguna_Arista(PrimerNodo) == true && Instancia.Esta_En_Alguna_Arista(SegundoNodo) == true)
            {
                if (Instancia.Existe_Nodo(PrimerNodo) == true && Instancia.Existe_Nodo(SegundoNodo) == true)
                {
                    if (PrimerNodo != SegundoNodo)
                    {
                        label26.Visible = false;
                        ultraFormattedTextEditor1.Text = "●---------------------------------------●\n";
                        ultraFormattedTextEditor1.Text = ultraFormattedTextEditor1.Text + "●              Camino Minimo                  ●\n";
                        ultraFormattedTextEditor1.Text = ultraFormattedTextEditor1.Text + "●---------------------------------------●\n";
                        ultraFormattedTextEditor1.Text = ultraFormattedTextEditor1.Text + "#Camino minimo entre " + SegundoNodo.ToString() + " a " + PrimerNodo.ToString() + ":\n";
                        ultraFormattedTextEditor1.Text = ultraFormattedTextEditor1.Text + "Ruta -> (" + Instancia.Dijkstra(PrimerNodo, SegundoNodo, Contador_Vertex) + ")\n";
                        ultraFormattedTextEditor1.Text = ultraFormattedTextEditor1.Text + "Distancia total -> " + Instancia.Distancia_Final.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Los nodos no pueden ser iguales", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Uno o mas nodos no existen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
           else
            {
                MessageBox.Show("Uno o mas nodos no estan enlazadas por una arista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ultraNumericEditor4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((int)e.KeyChar == (int)Keys.Enter )
            {
                ultraNumericEditor5.Focus();
            }
        }

        private void ultraNumericEditor5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                ultraButton20.PerformClick();
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    Borrar = true;
                    Dibujar(null, Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[0].Value), 1, 0);
                }
            }
            catch
            {

            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
        public void Tipo_Grafo()
        {
            if(Contador_Vertex*Math.Log10(Contador_Vertex ) > Instancia.Contador_Aristas)
            {
                label33.Text = "Tipo de grafo -> Grafo Disperso";
            }
            else
            {
                label33.Text = "Tipo de grafo -> Grafo Denso";
            }
            if (Instancia.Contador_Aristas  == 0)
            {
                label33.Text = "Tipo de grafo -> Grafo Vacio";
            }            
            else if(Contador_Vertex*((Contador_Vertex-1))/2 == Instancia.Contador_Aristas)
            {
                label33.Text = "Tipo de grafo -> Grafo Completo";
            }
        }

        private void ultraButton12_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ultraButton22_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("Documentos\\Grafos.docx");
            }
            catch
            {
                MessageBox.Show("Error : El archivo no existe", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("Documentos\\Grafos Final.mp4");
            }
            catch
            {
                MessageBox.Show("Error : El archivo no existe", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ultraButton14_Click_1(object sender, EventArgs e)
        {
            Borrar = true;
            Dibujar(null, 0, 0, 0);
        }
    }
    }