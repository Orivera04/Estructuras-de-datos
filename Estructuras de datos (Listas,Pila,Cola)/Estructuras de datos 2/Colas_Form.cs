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

namespace Estructuras_de_datos
{
    public partial class Colas_Form : Form
    {
        private Clases.Colas Raiz, Fondo;
        public string Global;
        public string Cadena = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + "\\Base_De_Datos.mdf" + ";Integrated Security=True;Connect Timeout=15";
        DataTable Tabla = new DataTable();
        public int Validador = 0;
        Estructuras_de_datos.Clases.Colas Pen;

        private void Colas_Form_Load(object sender, EventArgs e)
        {
            Raiz = null;
            Fondo = null;
            ultraPanel3.Visible = false;
            ultraPanel1.Visible = false;
            ultraComboEditor2.Text = Convert.ToString(ultraComboEditor2.Items.GetItem(0));
        }

        public Colas_Form()
        {
            InitializeComponent();
        }


        #region Metodos

        public bool Vacia()
        {
            if (Raiz == null)
                return true;
            else
                return false;
        }

        //Insertar un elemento al final de la cola//
        public void Insertar(int Elemento)
        {
            Estructuras_de_datos.Clases.Colas Nuevo;
            Nuevo = new Estructuras_de_datos.Clases.Colas();
            Nuevo.Numero = Elemento;
            Nuevo.Siguiente = null;
            if (Vacia())
            {
                Raiz = Nuevo;
                Fondo= Nuevo;
            }
            else
            {
                    Fondo.Siguiente = Nuevo;
                    Fondo = Nuevo;
            }
        }

        //Insertar un elemento al inicio de la cola//
        public void Insertar_Inicio(int Elemento)
        {
            //Validador = 1;
            Estructuras_de_datos.Clases.Colas Nuevo;
            Estructuras_de_datos.Clases.Colas Aux;
            Nuevo = new Estructuras_de_datos.Clases.Colas();
            Aux = new Estructuras_de_datos.Clases.Colas();
            Nuevo.Numero = Elemento;
            Nuevo.Siguiente = Raiz;
            if (!Vacia())
            {
                Aux = Raiz;
                Raiz = Nuevo;
                Raiz.Siguiente = Aux;
            }
            else
            {
                Raiz = Nuevo;
                Fondo = Nuevo;
            }
        }

        //Extraer Primer Elemento Ingresado//
        public int Extraer()
        {
            if (!Vacia())
            {
                int Elemento = Raiz.Numero ;
                if (Raiz == Fondo)
                {
                    Raiz = null;
                    Fondo = null;
                }
                else
                {
                    Raiz = Raiz.Siguiente ;
                }
                return Elemento;
            }
            else
                return -1;
        }

        //Extraer Ultimo Elemento Ingresado//
        public int Extraer_Ultimo()
        {
            Pen = null;
            if (!Vacia())
            {
                int Elemento = Fondo.Numero;
                if (Raiz == Fondo)
                {
                    Raiz = null;
                    Fondo = null;
                }
                else
                {
                    Penultimo();
                   Fondo = Pen;
                }
                return Elemento;
            }
            else
                return -1;
        }

        public int Penultimo()
        {
            int Contador = 0;
            Estructuras_de_datos.Clases.Colas Recorrer = Raiz;
            while (Recorrer != null)
            {
                try
                {
                    if (Recorrer.Siguiente.Siguiente == null)
                    {
                        Pen = Recorrer;
                        Pen.Numero = Recorrer.Numero;
                        Pen.Siguiente = null;
                        break;
                    }
                }
                catch { }
                Recorrer = Recorrer.Siguiente;
                Contador++;
            }
            return Contador;
        }

        public int Recorrer()
        {
            int Contador =0;
            Estructuras_de_datos.Clases.Colas Recorrer = Raiz;
            while (Recorrer != null)
            {
                DataGridView1.Rows.Add(Convert.ToString(Recorrer.Numero));
                Recorrer = Recorrer.Siguiente;
                Contador++;
            }
            return Contador;
        }
        public void Vaciar_Cola()
        {
            Raiz = null;
            Fondo = null;
        }

        public int Buscar(int Numero)
        {
            int Encontrado = 0;
            Estructuras_de_datos.Clases.Colas Recorrer = Raiz;
            while (Recorrer != null)
            {
                if(Recorrer.Numero  == Numero)
                {
                    return Encontrado;
                }
                Recorrer = Recorrer.Siguiente;
                Encontrado++;
            } 
            return -1;
        }
        #endregion
        private void ultraButton1_Click(object sender, EventArgs e)
        {
            //Fuente BBDD de los datos //
            try
            {
                DataGridView1.Rows.Clear();
                Raiz = null;
                Tabla.Clear();
                SqlDataAdapter Adaptador = new SqlDataAdapter("select Nota from Notas", Cadena);
                Adaptador.Fill(Tabla);
                foreach (DataRow row in Tabla.Rows)
                {
                    int Nota = Int32.Parse((row["Nota"].ToString()));
                    Insertar(Nota);
                }
                ultraPanel1.Visible = true;
                ultraPanel3.Visible = false;
                Recorrer();
                label4.Visible = false;
            }
            catch
            {
                MessageBox.Show("Error al conectar con la base de datos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ultraButton4_Click(object sender, EventArgs e)
        {
            ultraPanel1.Visible = true;
            ultraPanel3.Visible = false;
            ultraPanel6.Visible = false;
            ultraPanel2.Visible = false;
        }

        private void ultraButton7_Click(object sender, EventArgs e)
        {
            //Atras añadir elementos a la cola//
            ultraPanel3.Visible = false;
            //Insertar(Convert.ToInt32(ultraNumericEditor1.Value));
        }

        private void ultraButton6_Click(object sender, EventArgs e)
        {
            //Añadir elementos a la cola//
            if (Global == "Insertar un elemento en la cola")
            { label4.Visible = false;
                DataGridView1.Rows.Clear();
                Insertar(Convert.ToInt32(ultraNumericEditor1.Value));
            }
            else if (Global == "Insertar al inicio")
            {
                label4.Visible = false;
                DataGridView1.Rows.Clear();
                Insertar_Inicio(Convert.ToInt32(ultraNumericEditor1.Value));
            }

            Recorrer();
        }

        private void ultraNumericEditor1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((int)e.KeyChar == (int)Keys.Enter)
            {
                ultraButton6.PerformClick();
            }
        }

        private void ultraButton12_Click(object sender, EventArgs e)
        {
            this.Close();
            Presentacion Instancia = new Presentacion();
            Instancia.Show();
        }

        private void UltraButton2_Click(object sender, EventArgs e)
        {
            label4.Visible = true;
            DataGridView1.Rows.Clear();
            ultraPanel1.Visible = false;
        }

        private void ultraButton5_Click(object sender, EventArgs e)
        {
            //Operaciones con colas
            //Boton Seleccionar operacion//
            string Operacion = ultraComboEditor2.Text;
            Global = Operacion;
            if (Operacion == "Recorrer Cola")
            {
                DataGridView1.Rows.Clear();
                Recorrer();
            }
            else if (Operacion == "Insertar un elemento en la cola")
            {
                ultraPanel3.Visible = true;
                ultraPanel1.Visible = true;
                ultraPanel2.Visible = false;

            }
            else if (Operacion == "Extraer el primer elemento de la cola")
            {
                label8.Text = "Extraer el primer elemento de la cola";
                ultraPanel3.Visible = true;
                ultraPanel1.Visible = true;
                ultraPanel2.Visible = true;
                ultraPanel6.Visible = false;
            }
            else if (Operacion  == "Longitud de la cola")
            {
                DataGridView1.Rows.Clear();
                MessageBox.Show("Cantidad de elementos en la cola ->" + Convert.ToString(Recorrer()), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(Operacion == "Vaciar Cola")
            {
                DataGridView1.Rows.Clear();
                Vaciar_Cola();
                label4.Visible = true;
                Recorrer();
                MessageBox.Show("Se ha vaciado la cola","Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(Operacion == "Busqueda en cola")
            {
                ultraPanel3.Visible = true;
                ultraPanel1.Visible = true;
                ultraPanel2.Visible = true;
                ultraPanel6.Visible = true;
            }
            else if (Operacion == "Insertar al inicio")
            {
                ultraPanel3.Visible = true;
                ultraPanel1.Visible = true;
                ultraPanel2.Visible = false;

            }
            else if (Operacion == "Eliminar el final")
            {
                label8.Text = "Extraer el ultimo elemento de la cola";               
                ultraPanel3.Visible = true;
                ultraPanel1.Visible = true;
                ultraPanel2.Visible = true;
                ultraPanel6.Visible = false;
            }
        }

        private void ultraComboEditor2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((int)e.KeyChar == (int)Keys.Enter)
            {
                ultraButton5.PerformClick();
            }
        }

        private void ultraButton8_Click(object sender, EventArgs e)
        {
            ultraPanel2.Visible = false;
            ultraPanel3.Visible = false;
        }

        private void ultraButton16_Click(object sender, EventArgs e)
        {
            int N = Buscar(Convert.ToInt16(ultraNumericEditor2.Value));
            MetroTabControl1.SelectedTab = metroTabPage1;
            label11.Visible = false;
            if (N != -1)
            {
                UltraFormattedTextEditor2.Text = UltraFormattedTextEditor2.Text + "******************************\nValor a buscar :" + Convert.ToString(ultraNumericEditor2.Value) + "\nResultado: Encontrado en el nodo[" + Convert.ToString(N + 1) + "]" + "\n******************************";
            }
            else
            {
                UltraFormattedTextEditor2.Text = UltraFormattedTextEditor2.Text + "******************************\nValor a buscar :" + Convert.ToString(ultraNumericEditor2.Value) + "\nResultado: No encontrado"+"\n******************************";
            }
           
        }

        private void ultraNumericEditor2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((int)e.KeyChar == (int)Keys.Enter)
            {
                ultraButton16.PerformClick();
            }
        }

        private void ultraButton15_Click(object sender, EventArgs e)
        {
            ultraPanel3.Visible = false;
            ultraPanel1.Visible = true;
            ultraPanel2.Visible = false;
            ultraPanel6.Visible = false;
        }

        private void UltraButton3_Click(object sender, EventArgs e)
        {

        }

        private void ultraButton9_Click(object sender, EventArgs e)
        {
            //Sacar el primer elemento//
            int Numero = 0;
            MetroTabControl1.SelectedTab = metroTabPage1;
            label11.Visible = false;
            if (Global == "Extraer el primer elemento de la cola")
            {
                Numero = Extraer();
            }

            else if (Global == "Eliminar el final")
            {
                Numero = Extraer_Ultimo();
            }
            
            if (Numero != -1)
            {
                UltraFormattedTextEditor2.Text = UltraFormattedTextEditor2.Text + "******************************\nValor extraido :[" + Convert.ToString(Numero) + "]\n******************************";
                DataGridView1.Rows.Clear();
                Recorrer();
            }
            else
            {
                MessageBox.Show("La cola esta vacia", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
