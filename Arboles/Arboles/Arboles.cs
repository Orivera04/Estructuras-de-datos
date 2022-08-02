using Arboles.Clases;
using Infragistics.Win.UltraWinEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Threading;

namespace Arboles
{
    public partial class Arboles : Form
    {
        Operaciones Instancia = new Operaciones();
        int Contador = 1;
        int X = 0, Y = 0,Cx = 0,Cy = 0;
        public bool Borrar = true;
        int Numero = 0;
        Queue<int> Dibujados = new Queue<int>();
        public Arboles()
        {
            InitializeComponent();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void Arboles_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            ultraComboEditor1.Text = ultraComboEditor1.Items.GetItem(0).ToString();
            Instancia.Instancia = this;                     
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            UltraButton3.PerformClick();
            Dibujar_Nulo();
            DataTable Tabla = new DataTable();
            string Cadena = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + "\\Base_De_Datos.mdf" + ";Integrated Security=True;Connect Timeout=15";
            SqlDataAdapter Adaptador = new SqlDataAdapter("select Top 12 Nota from Notas", Cadena);
            try
            {
                Adaptador.Fill(Tabla);
                foreach (DataRow Rows in Tabla.Rows)
                {
                    string Numero = Rows["Nota"].ToString();
                    if (Instancia.Añadir_Item_Arbol(int.Parse(Numero)) == 1)
                    {
                    }
                }
                    label3.Visible = false;
                    Tabla.Dispose();
                    Adaptador.Dispose();

                    ultraPanel2.Visible = true;
                    ultraPanel5.Visible = false;
                    ultraPanel1.Visible = false;
                    Inorden(Instancia.Raiz, 1);
                Instancia.Cantidad = 0;
                Instancia.Altura = 0;
                Instancia.Hojas = 0;

                label10.Text = "Nodos -> " + Instancia.Cantidad_De_Nodo(Instancia.Raiz);
                label14.Text = "Hojas -> " + Instancia.Hojas_F(Instancia.Raiz);
                label17.Text = "Altura -> " + Instancia.Altura_F(Instancia.Raiz, 0);
                ultraButton14.PerformClick();

            }
            catch
            {
                MessageBox.Show("Error al conectar con la base de datos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ultraButton6_Click(object sender, EventArgs e)
        {
            if (ultraComboEditor1.Text == Convert.ToString(ultraComboEditor1.Items.GetItem(0)))
            {
                ultraPanel5.Visible = true;
            }
            else if (ultraComboEditor1.Text == Convert.ToString(ultraComboEditor1.Items.GetItem(1)))
            {
                Instancia.Cadena = "";
                label4.Visible = false;
                Instancia.Instancia = this;
                Instancia.Cola.Clear();
                Dibujados.Clear();
                ultraButton14.PerformClick();
                Thread Hilo = new Thread(() => Instancia.Preorden(Instancia.Raiz));
                Hilo.Start();
            }
            else if (ultraComboEditor1.Text == Convert.ToString(ultraComboEditor1.Items.GetItem(2)))
            {
                Instancia.Cadena = "";
                label4.Visible = false;
                Instancia.Instancia = this;
                Instancia.Cola.Clear();
                Dibujados.Clear();
                ultraButton14.PerformClick();                                
                Thread Hilo = new Thread(() => Instancia.Inorden(Instancia.Raiz));
                Hilo.Start();
            }
            else if (ultraComboEditor1.Text == Convert.ToString(ultraComboEditor1.Items.GetItem(3)))
            {
                Instancia.Cadena = "";
                label4.Visible = false;
                Instancia.Instancia = this;
                Instancia.Cola.Clear();
                Dibujados.Clear();
                ultraButton14.PerformClick();
                Thread Hilo = new Thread(() => Instancia.PostOrden(Instancia.Raiz));
                Hilo.Start();
            }
            else if (ultraComboEditor1.Text == Convert.ToString(ultraComboEditor1.Items.GetItem(4)))
            {
                ultraPanel5.Visible = true;
                ultraPanel4.Visible = true;
            }
            else if (ultraComboEditor1.Text == Convert.ToString(ultraComboEditor1.Items.GetItem(5)))
            {
                ultraPanel5.Visible = true;
                ultraPanel4.Visible = true;
                ultraPanel1.Visible = true;
            }
            else if (ultraComboEditor1.Text == Convert.ToString(ultraComboEditor1.Items.GetItem(6)))
            {
                
                if (Instancia.Raiz != null)
                {
                    MessageBox.Show("El arbol no esta vacio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information );
                }
                else
                {
                    MessageBox.Show("El arbol esta vacio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (ultraComboEditor1.Text == Convert.ToString(ultraComboEditor1.Items.GetItem(7)))
            {
                
                Instancia.Raiz = null;
                pictureBox14.Visible = false;
                listView1.Items.Clear();
                label10.Text = "Nodos -> 0";
                label14.Text = "Hojas -> 0";
                label17.Text = "Altura -> 0";
                MessageBox.Show("Se ha eliminado el arbol", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void ultraButton5_Click(object sender, EventArgs e)
        {
            ultraPanel5.Visible = false;
        }

        private void ultraButton7_Click(object sender, EventArgs e)
        {
            Contador = 1;           
            int Retorno = Instancia.Añadir_Item_Arbol(Int32.Parse(Convert.ToString(ultraNumericEditor3.Value)));
            if (Retorno == 1)
            {
                listView1.Items.Clear();
                X = 0; Y = 0;
                pictureBox14.Visible = true;
                pictureBox14.Refresh();

                Inorden(Instancia.Raiz,1);                
               label10.Text = "Nodos -> " + Instancia.Cantidad_De_Nodo(Instancia.Raiz);
                label14.Text = "Hojas -> " + Instancia.Hojas_F(Instancia.Raiz);
                label17.Text = "Altura -> " + Instancia.Altura_F(Instancia.Raiz,0);
            }            
            else if (Retorno == 3) { }
                else
            {
                MessageBox.Show("El elemento no se pudo añadir dado que ya existe en el arbol", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Contador--;

            }
            Contador ++;
            label3.Visible = false;
        }

        private void ultraNumericEditor3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((int)e.KeyChar == (int)Keys.Enter )
            {
                ultraButton7.PerformClick();
            }
        }

        private void ultraComboEditor1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((int)e.KeyChar == (int)Keys.Enter )
            {
                ultraButton6.PerformClick();
            }
        }

        private void ultraButton4_Click(object sender, EventArgs e)
        {
            //Ingresar al principio//
            ultraPanel2.Visible = true;
            ultraPanel5.Visible = true;
            ultraPanel4.Visible = false;
        }

        private void UltraButton3_Click(object sender, EventArgs e)
        {
            Instancia.Raiz = null;
            listView1.Items.Clear();
            label4.Visible = true;
            label3.Visible = true;
            pictureBox14.BackColor = Color.Transparent;

            //pictureBox14.Visible = false;                 
            MetroTabControl1.Visible = false;
            MetroTabControl1.Visible = true;
            UltraFormattedTextEditor2.Text = "";
            Dibujar_Nulo();
            label10.Text = "Nodos -> 0";
            label10.Text = "Nodos -> 0";
            label17.Text = "Altura -> 0";
            
            
        }

        private void ultraButton12_Click(object sender, EventArgs e)
        {
            //menu//
        }

        private void UltraButton2_Click(object sender, EventArgs e)
        {
            ultraPanel2.Visible = false;
        }

        private void ultraButton8_Click(object sender, EventArgs e)
        {
            ultraPanel5.Visible = false;
            ultraPanel4.Visible = false;
        }

        private void ultraButton9_Click(object sender, EventArgs e)
        {
            if (Instancia.Raiz != null)
            {
                pictureBox14.Visible = true;
                Borrar = true;
                listView1.Items.Clear();
                Inorden(Instancia.Raiz, 2);
                if (Instancia.Buscar(Instancia.Raiz, Convert.ToInt32(ultraNumericEditor1.Value)) == 1)
                {
                    MessageBox.Show("Encontrado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No encontrado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("El arbol esta vacio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ultraNumericEditor1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((int)e.KeyChar == (int)Keys.Enter)
            {
                ultraButton9.PerformClick();
            }
        }

        private void ultraButton11_Click(object sender, EventArgs e)
        {
            Contador = 1;                       
            if (Instancia.Raiz != null)
            {
                ultraButton13.PerformClick();
                if (MessageBox.Show("¿Seguro que desea borrar el nodo?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Instancia.Cadena = "";
                    string Cadena = Instancia.Preorden(Instancia.Raiz,1);
                    Cadena = Cadena.Substring(1, Cadena.Length - 1);
                    char Delimitador = ' ';
                    String[] Subnumeros = Cadena.Split(Delimitador);
                    int[] Interos = Array.ConvertAll(Subnumeros, s => int.Parse(s));
                    //Instancia.Actualizar(new);
                    Contador = 1;
                    pictureBox14.Visible = true;
                    if (Instancia.Eliminar(Instancia.Raiz, Convert.ToInt32(ultraNumericEditor2.Value)) == 1)
                    {
                        if (Instancia.Paso == false)
                        {
                            Instancia.Actualizar(Interos, Convert.ToInt32(ultraNumericEditor2.Value));
                        }
                        listView1.Items.Clear();
                        MessageBox.Show("Nodo eliminado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Contador = 1;
                        MessageBox.Show("El valor digitado no existe en ningun nodo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Contador = 1;
                    Borrar = true;
                    Inorden(Instancia.Raiz, 1);
                    Instancia.Cantidad = 0;
                    Instancia.Altura = 0;
                    Instancia.Hojas = 0;

                    label10.Text = "Nodos -> " + Instancia.Cantidad_De_Nodo(Instancia.Raiz);
                    label14.Text = "Hojas -> " + Instancia.Hojas_F(Instancia.Raiz);
                    label17.Text = "Altura -> " + Instancia.Altura_F(Instancia.Raiz, 0);
                    if (Instancia.Raiz == null)                        
                {
                        ultraButton14.PerformClick();
                    }
              }
                else
                {
                    Contador = 1;
                    ultraButton14.PerformClick();
                }
            }
            else
            {
                MessageBox.Show("El arbol esta vacio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ultraButton10_Click(object sender, EventArgs e)
        {
            ultraPanel5.Visible = false;
            ultraPanel4.Visible = false;
            ultraPanel1.Visible = false;
        }

        private void ultraNumericEditor2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((int)e.KeyChar == (int)Keys.Enter)
            {
                ultraButton11.PerformClick();
            }
        }

        private void MetroTabControl1_Deselecting(object sender, TabControlCancelEventArgs e)
        {
                         
               
            
            
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }


        private void PictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ultraButton13_Click(object sender, EventArgs e)
        {
            Contador = 1;
            if (Instancia.Raiz != null)

            {
                listView1.Items.Clear();
                pictureBox14.Visible = true;
                Borrar = true;
                Inorden(Instancia.Raiz, 3);
            }
            else
            {
                MessageBox.Show("El arbol esta vacio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ultraButton14_Click(object sender, EventArgs e)
        {            
            if (Instancia.Raiz != null)
           {
                Contador = 1;
                Borrar = true;
                listView1.Items.Clear();
                Inorden(Instancia.Raiz, 1);
            }
            else
            {
                Dibujar_Nulo();
            }
        }

        public void Dibujar(int Parametro,int[] Cola = null,bool Dibujar = false,int Verde = 0)
       {
            Bitmap Dibujo = default(Bitmap);
            Dibujo = new Bitmap(pictureBox14.Width, pictureBox14.Height);
            Graphics Buf = Graphics.FromImage(Dibujo);
            Graphics Graficos_Del_Picturebox = pictureBox14.CreateGraphics();
            Pen Lapiz = new Pen(Color.LightGray ,3);
            Lapiz.DashStyle = DashStyle.Dash ;
        
            Buf.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality ;
           Rectangle rectangulo = new Rectangle(0, 0, 353, 243);
            if (Borrar == true)
            {
                Buf.FillRectangle(Brushes.White, rectangulo);
                Borrar = false;
            }
            if (Instancia.Raiz == null)
            {
                                
            }
            else
            {
                
                
                Rectangle Rectangulo = new Rectangle(X, Y, 25, 25);
                Rectangle Rectangulo2 = new Rectangle(X, Y, 28, 28);
                try
                {
                    if (Dibujar == false)
                    {
                        Buf.DrawLine(Lapiz, new Point(Cx + 10, Cy + 25), new Point(X + 10, Y + 6));
                    }
                }
                catch { };
                Font Fuente = new Font("Roboto Condensed", 11);
                SolidBrush Pincel = new SolidBrush(Color.White);

                if (Dibujar == false)
                {
                    Buf.FillEllipse(Brushes.White, Rectangulo);
                }
                                                                                
                if (Parametro == 0)
                {                    
                    if (Instancia.Es_Hoja(Instancia.Raiz, Numero) == 1)
                    {
                        if (Cola == null || (Cola.Contains(Numero) == false))
                        {
                            if (Dibujar == false)
                            {
                                Buf.FillEllipse(Brushes.White, Rectangulo2);
                                Buf.FillEllipse(Brushes.LightGreen, Rectangulo);
                            }
                            else
                            {
                                if (Cola.Contains(Numero) == true)
                                {
                                    if (Dibujados.Contains(Numero) == false)
                                    {
                                        Buf.FillEllipse(Brushes.White, Rectangulo2);
                                        Buf.FillEllipse(Brushes.Orchid , Rectangulo);
                                        if (Numero >= 0 && Numero < 10)
                                        {
                                            Buf.DrawString(Convert.ToString(Numero), Fuente, Pincel, X + 7, Y + 3);
                                        }
                                        else if (Numero >= 10)
                                        {
                                            Buf.DrawString(Convert.ToString(Numero), Fuente, Pincel, X + 5, Y + 3);
                                        }
                                        else if (Numero > -10 && Numero < -1)
                                        {
                                            Buf.DrawString(Convert.ToString(Numero), Fuente, Pincel, X + 4, Y + 3);
                                        }
                                        else
                                        {
                                            Buf.DrawString(Convert.ToString(Numero), Fuente, Pincel, X + 1, Y + 3);
                                        }
                                        Dibujados.Enqueue(Numero);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (Dibujar == true)
                            {
                                if (Dibujados.Contains(Numero) == false)
                                {
                                    Buf.FillEllipse(Brushes.White, Rectangulo2);                           
                                    Buf.FillEllipse(Brushes.Orchid, Rectangulo);
                                    if (Numero >= 0 && Numero < 10)
                                    {
                                        Buf.DrawString(Convert.ToString(Numero), Fuente, Pincel, X + 7, Y + 3);
                                    }
                                    else if (Numero >= 10)
                                    {
                                        Buf.DrawString(Convert.ToString(Numero), Fuente, Pincel, X + 5, Y + 3);
                                    }
                                    else if (Numero > -10 && Numero < -1)
                                    {
                                        Buf.DrawString(Convert.ToString(Numero), Fuente, Pincel, X + 4, Y + 3);
                                    }
                                    else
                                    {
                                        Buf.DrawString(Convert.ToString(Numero), Fuente, Pincel, X + 1, Y + 3);
                                    }
                                    Dibujados.Enqueue(Numero);
                                }
                            }       
                        }
                    }

                    else {

                        if (Cola == null || (Cola.Contains(Numero) == false))
                        {
                            if (Dibujar == false)
                            {
                                if (Verde == 0)
                                {
                                    Buf.FillEllipse(Brushes.White, Rectangulo2);
                                    Buf.FillEllipse(Brushes.CornflowerBlue, Rectangulo);
                                }
                                else
                                {
                                    Buf.FillEllipse(Brushes.White, Rectangulo2);
                                    Buf.FillEllipse(Brushes.LightGreen, Rectangulo);
                                }
                            }
                        }
                        else
                        {
                            if (Dibujar == true)
                            {
                                if (Dibujados.Contains(Numero) == false)
                                {
                                    Buf.FillEllipse(Brushes.White, Rectangulo2);
                                    Buf.FillEllipse(Brushes.Orchid , Rectangulo);
                                    if (Numero >= 0 && Numero < 10)
                                    {
                                        Buf.DrawString(Convert.ToString(Numero), Fuente, Pincel, X + 7, Y + 3);
                                    }
                                    else if (Numero >= 10)
                                    {
                                        Buf.DrawString(Convert.ToString(Numero), Fuente, Pincel, X + 5, Y + 3);
                                    }
                                    else if (Numero > -10 && Numero < -1)
                                    {
                                        Buf.DrawString(Convert.ToString(Numero), Fuente, Pincel, X + 4, Y + 3);
                                    }
                                    else
                                    {
                                        Buf.DrawString(Convert.ToString(Numero), Fuente, Pincel, X + 1, Y + 3);
                                    }
                                    Dibujados.Enqueue(Numero);
                                }
                            }
                        }
                    }
                }
                else if (Parametro == 1)
                {
                    if (Int32.Parse(Convert.ToString(ultraNumericEditor1.Value)) == Numero)
                    {
                        Buf.FillEllipse(Brushes.Orchid, Rectangulo);
                    }
                    else
                    {
                        Buf.FillEllipse(Brushes.CornflowerBlue , Rectangulo);
                    }
                }
                else
                {
                    if (Int32.Parse(Convert.ToString(ultraNumericEditor2.Value)) == Numero)
                    {
                        Buf.FillEllipse(Brushes.Red, Rectangulo);
                    }
                    else
                    {
                        Buf.FillEllipse(Brushes.CornflowerBlue, Rectangulo);
                    }
                }
                if (Dibujar == false)
                {
                    if (Numero >= 0 && Numero < 10)
                    {
                        Buf.DrawString(Convert.ToString(Numero), Fuente, Pincel, X + 7, Y + 3);
                    }
                    else if (Numero >= 10)
                    {
                        Buf.DrawString(Convert.ToString(Numero), Fuente, Pincel, X + 5, Y + 3);
                    }
                    else if (Numero > -10 && Numero < -1)
                    {
                        Buf.DrawString(Convert.ToString(Numero), Fuente, Pincel, X + 4, Y + 3);
                    }
                    else
                    {
                        Buf.DrawString(Convert.ToString(Numero), Fuente, Pincel, X + 1, Y + 3);
                    }
                }
                Graficos_Del_Picturebox.DrawImage(Dibujo,new Point(0, 0));
                Graficos_Del_Picturebox.Dispose();
                Buf.Dispose();
                Dibujo.Dispose();
            }            
        }

        private void pictureBox14_Paint(object sender, PaintEventArgs e)
        {
                                                 
        }

        private void Arboles_VisibleChanged(object sender, EventArgs e)
        {            
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string Dato = e.ClickedItem.Text;
            switch (Dato)
            {
                case "Guardar Arbol":
                    Instancia.Cadena = "";
                    Instancia.Guardar();
                    break;
                case "Cargar Arbol":
                    UltraFormattedTextEditor2.Text = "";
                    label3.Visible = false;
                    label4.Visible = false;
                    Instancia.Leer();
                    ultraButton14.PerformClick();
                    label10.Text = "Nodos -> " + Instancia.Cantidad_De_Nodo(Instancia.Raiz);
                    label14.Text = "Hojas -> " + Instancia.Hojas_F(Instancia.Raiz);
                    label17.Text = "Altura -> " + Instancia.Altura_F(Instancia.Raiz, 0);
                    MessageBox.Show("Se ha cargado el arbol", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        private void contextMenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string Dato = e.ClickedItem.Text;
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

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        public string Inorden(Clase_Arboles Nodo,int Parametro,int [] Cola = null,bool Dibu = false)
        {
            if (Nodo != null)
            {
                if (Cola == null) { 
                ListViewItem Lista = new ListViewItem(Convert.ToString(Contador));
                Lista.SubItems.Add(Convert.ToString(Nodo.Dato));
                if (Instancia.Es_Hoja(Instancia.Raiz, Nodo.Dato) == 1)
                {
                    Lista.SubItems.Add("Si");
                }
                else
                {
                    Lista.SubItems.Add("No");
                }
                Lista.SubItems.Add((Instancia.Nivel(Nodo.Dato)+1).ToString());
                    Lista.SubItems.Add((Instancia.Nivel(Nodo.Dato)).ToString());
                    if (Contador % 2 == 0) { Lista.BackColor = Color.AliceBlue; }
                listView1.Items.Add(Lista);
                Contador++;
            }
                Inorden(Nodo.Enlace_Izquierdo,Parametro,Cola,Dibu);
                X = Nodo.Punto.X + 25;
                Y = Nodo.Punto.Y + 5;
                Numero = Nodo.Dato;
                try
                {
                    Cx = Nodo.Padre.Punto.X + 25;
                    Cy = Nodo.Padre.Punto.Y + 5;
                }
                catch { Cx = X; Cy = Y; };
                if (Parametro == 1)
                {                  
                        Dibujar(0, Cola, Dibu);                                          
                }
                else if (Parametro == 2)
                {                    
                    Dibujar(1,null,Dibu);
                }
                else
                {                    
                    Dibujar(2,null,Dibu);
                }
                X = 0; Y = 0;
                Inorden(Nodo.Enlace_Derecho,Parametro,Cola,Dibu);
            }                        
            return ""; 
        }       

        public void Dibujar_Nulo()
        {
            Bitmap Dibujo = default(Bitmap);
            Dibujo = new Bitmap(pictureBox14.Width, pictureBox14.Height);
            Graphics Buf = pictureBox14.CreateGraphics();
            Pen Lapiz = new Pen(Color.FromArgb(255, 44, 62, 80), 1);
            Lapiz.DashStyle = DashStyle.Dot;
            Buf.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Rectangle rectangulo = new Rectangle(0, 0, 353, 243);            
            Buf.FillRectangle(Brushes.White, rectangulo);
            Buf.DrawImage(Image.FromFile("Empty Box-80.png"),new Point(143,61));
                                
              Font Fuente = new Font("Roboto Condensed", 9.25f);
              SolidBrush Brush = new SolidBrush(Color.Crimson);
              Buf.DrawString("No hay ningun nodo en el arbol",Fuente,Brush,108,145);
            }
        }
}

