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
    public partial class Pilas_Form : Form
    {
        private Estructuras_de_datos.Clases.Pila Raiz;
        public string Cadena = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + "\\Base_De_Datos.mdf" + ";Integrated Security=True;Connect Timeout=15";
        DataTable Tabla = new DataTable();
        public Pilas_Form()
        {
            InitializeComponent();
        }

        private void Pilas_Form_Load(object sender, EventArgs e)
        {
            Raiz = null;
            ultraPanel1.Visible = false;
            ultraComboEditor2.Text = Convert.ToString(ultraComboEditor2.Items.GetItem(0));
        }



        #region Metodos
        public void Push(int X)
        {
            Estructuras_de_datos.Clases.Pila Nuevo;
            Nuevo = new Estructuras_de_datos.Clases.Pila();
            Nuevo.Numero  = X;
            if (Raiz == null)
            {
                Nuevo.Siguiente  = null;
                Raiz = Nuevo;
            }
            else
            {
                Nuevo.Siguiente  = Raiz;
                Raiz= Nuevo;
            }
        }

        public int Pop()
        {
            if (Raiz != null)
            {
                int Numero = Raiz.Numero;
                Raiz  = Raiz.Siguiente;
                return Numero;
            }
            else
            {                
                return -1;
            }
        }
        public int Recorrer_Pila()
        {
            int Cont = 0;
            Estructuras_de_datos.Clases.Pila Recorrer  = Raiz;            
            while (Recorrer != null)
            {
                DataGridView1.Rows.Add(Convert.ToString (Recorrer.Numero));   
                Recorrer = Recorrer .Siguiente ;
                Cont = Cont + 1;
            }
            return Cont;
        }

        public void Vacia_Pila()
        {
            Raiz = null;
        }
        public int Buscar(int Numero)
        {
            int Encontrado = 0;
            Estructuras_de_datos.Clases.Pila Recorrer = Raiz;
            while (Recorrer != null)
            {
                if (Recorrer.Numero == Numero)
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
                    Push(Nota);
                }
                ultraPanel1.Visible = true;
                ultraPanel3.Visible = false;
                Recorrer_Pila();
                Label6.Visible = false;
            }
            catch
            {
                MessageBox.Show("Error al conectar con la base de datos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ultraButton6_Click(object sender, EventArgs e)
        {
            Label6.Visible = false;
            DataGridView1.Rows.Clear();
            Push(Convert.ToInt32(ultraNumericEditor1.Value));
            Recorrer_Pila();
        }

        private void ultraNumericEditor1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                ultraButton6.PerformClick();
            }
        }

        private void ultraButton4_Click(object sender, EventArgs e)
        {
            //Boton Ingresasr datos manualmente//
            Raiz = null;
            DataGridView1.Rows.Clear();
            ultraPanel1.Visible = true;
            ultraPanel3.Visible = true;
            ultraPanel2.Visible = false;
        }

        private void ultraButton7_Click(object sender, EventArgs e)
        {
            //Atras Panel ingresar datos//
            ultraPanel3.Visible = false;            
        }

        private void ultraButton5_Click(object sender, EventArgs e)
        {
            //Boton Seleccionar operacion//
            String Operacion = ultraComboEditor2.Text;

            if (Operacion == "Recorrer Pila")
            {
                DataGridView1.Rows.Clear();
                Recorrer_Pila();
            }
            else if (Operacion == "Insertar un elemento en la pila (Push)")
            {
                ultraPanel3.Visible = true;
                ultraPanel2.Visible = false;
            }
            else if (Operacion == "Extraer el ultimo elemento de la pila (Pop)")
            {
                ultraPanel3.Visible = true;
                ultraPanel2.Visible = true;
                ultraPanel6.Visible = false;
            }
            else if (Operacion == "Longitud de la pila")
            {
                DataGridView1.Rows.Clear();
                MessageBox.Show("Cantidad de elementos en la pila ->" + Convert.ToString(Recorrer_Pila()),"Atención",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else if (Operacion == "Vaciar Pila")
            {
                DataGridView1.Rows.Clear();
                Vacia_Pila();
                label4.Visible = true;
                Recorrer_Pila();
                MessageBox.Show("Se ha vaciado la pila", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Operacion == "Busqueda en la pila")
            {
                ultraPanel3.Visible = true;
                ultraPanel1.Visible = true;
                ultraPanel2.Visible = true;
                ultraPanel6.Visible = true;
            }
        }

        private void ultraButton12_Click(object sender, EventArgs e)
        {
            //Boton regresar menu//
            this.Close();
            Presentacion Instancia = new Presentacion();
            Instancia.Show();
        }

        private void UltraButton2_Click(object sender, EventArgs e)
        {
            Label6.Visible = true;
            DataGridView1.Rows.Clear();
            ultraPanel1.Visible = false;            
        }

        private void ultraComboEditor2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((int)e.KeyChar == (int)Keys.Enter )
            {
                ultraButton5.PerformClick();
            }
        }

        private void ultraButton9_Click(object sender, EventArgs e)
        {
            MetroTabControl1.SelectedTab = metroTabPage1;
            label11.Visible = false;
            int Numero = Pop();
            if (Numero != -1)
            {
                UltraFormattedTextEditor2.Text = UltraFormattedTextEditor2.Text + "******************************\nValor extraido :[" + Convert.ToString(Numero) + "]\n******************************";
                DataGridView1.Rows.Clear();
                Recorrer_Pila();
            }
            else
            {
                MessageBox.Show("La pila esta vacia", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ultraButton8_Click(object sender, EventArgs e)
        {
            ultraPanel3.Visible = false;
            ultraPanel2.Visible = false;
        }

        private void UltraButton3_Click(object sender, EventArgs e)
        {
            UltraFormattedTextEditor2.Text = "";
            label11.Visible = true;
            DataGridView1.Rows.Clear();
//            Label6.Visible = true;            
        }

        private void ultraButton15_Click(object sender, EventArgs e)
        {
            ultraPanel3.Visible = false;
            ultraPanel1.Visible = true;
            ultraPanel2.Visible = false;
            ultraPanel6.Visible = false;
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
                UltraFormattedTextEditor2.Text = UltraFormattedTextEditor2.Text + "******************************\nValor a buscar :" + Convert.ToString(ultraNumericEditor2.Value) + "\nResultado: No encontrado" + "\n******************************";
            }
        }

        private void ultraNumericEditor2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((int)e.KeyChar == (int)Keys.Enter)
            {
                ultraButton16.PerformClick();
            }
        }
    }
}
