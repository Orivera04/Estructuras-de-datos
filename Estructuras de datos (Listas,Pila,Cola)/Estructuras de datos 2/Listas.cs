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

    public partial class Listas : Form
    {
        //Punteros de inicio y fin de la lista//
        public Estructuras_de_datos.Clases.Listas Inicio, Fin, Primer, Ultimo, Vale, Extra;
        public int Numero = 0, Cuenta = 0, Aviso = 0, Global =0, Global2 = 0, Improvisado = 0, Generico = 0;


        public int Universal = 0;
        public int[] Posiciones = new int[12];
        public int[] Guardando_Posicion_Anterior= new int[12];
        public string Cadena = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + "\\Base_De_Datos.mdf" + ";Integrated Security=True;Connect Timeout=15";
        DataTable Tabla = new DataTable();
        public Listas()
        {
            InitializeComponent();
        }

        private void Listas_Load(object sender, EventArgs e)
        {
            //Inicialización de los punteros//
            Inicio = null;
            Fin = null;
            Primer = null;
            Ultimo = null;
            Universal = 0;
            ultraComboEditor1.Text = Convert.ToString(ultraComboEditor1.Items.GetItem(0));
            ultraPanel2.Visible = false;
            ultraComboEditor2.Text = Convert.ToString(ultraComboEditor2.Items.GetItem(0));
            ultraComboEditor3.Text = Convert.ToString(ultraComboEditor3.Items.GetItem(0));
/*            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;*/
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();

            for (int i = 1; i <= 12; i++)
            {
                Cargar(null, null, null);
            }
            radioButton3.Checked=true;
            radioButton1.Checked = true;
        }

        //Permite insertar un dato en la lista//
        public void Insertar(int Nota, string Nombre, string Grupo, string Carnet)
        {
            Inicio = new Estructuras_de_datos.Clases.Listas(Nombre, Grupo, Nota, Carnet, Inicio);
            if (Fin == null)
            {
                Fin = Inicio;
            }
        }

        //Se inserta un dato en la lista
        public void Insertar(string Dato)
        {
            Primer = new Estructuras_de_datos.Clases.Listas(Dato, Primer, null,null);
            if (Ultimo == null)
            {
                Ultimo = Primer;
            }

        }

        public void Cargar(string Dato, string Orden, string Orden2)
        {
            Primer = new Estructuras_de_datos.Clases.Listas(Dato, Primer, Orden, Orden2);
            if (Ultimo == null)
            {
                Ultimo = Primer;
            }
        }


        //Recorre la lista e inserta los valores en el datagridview//
        private void UltraButton2_Click(object sender, EventArgs e)
        {
            ultraPanel2.Visible = false;

        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Inicio = null;
                Fin = null;
                Tabla.Clear();
                SqlDataAdapter Adaptador = new SqlDataAdapter("select * from Notas", Cadena);
                Adaptador.Fill(Tabla);
                foreach (DataRow row in Tabla.Rows)
                {
                    string Nombre = row["Nombre"].ToString();
                    string Codigo = row["Codigo"].ToString();
                    string Grupo = row["Grupo"].ToString();
                    int Nota = Int32.Parse((row["Nota"].ToString()));
                    Insertar(Nota, Nombre, Grupo, Codigo);
                }
                ultraPanel2.Visible = true;
                ultraPanel1.Visible = false;
                ultraPanel4.Visible = false;
            }
            catch
            {
                MessageBox.Show("Error al conectar con la base de datos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ultraTextEditor1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ultraTextEditor1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                ultraTextEditor2.Focus();
            }
        }

        private void ultraTextEditor2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                ultraTextEditor3.Focus();
            }
        }

        private void ultraTextEditor3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                ultraNumericEditor1.Focus();
            }
        }

        private void ultraNumericEditor1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                ultraButton5.PerformClick();
            }
        }

        private void ultraButton5_Click(object sender, EventArgs e)
        {
            if (ultraTextEditor1.Text != "" & ultraTextEditor2.Text != "" & ultraTextEditor3.Text != "")
            {
                Insertar(Convert.ToInt16(ultraNumericEditor1.Value), ultraTextEditor1.Text, ultraTextEditor2.Text, ultraTextEditor3.Text);
                Recorrer();
                MessageBox.Show("Registro añadido a la lista", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Faltan datos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ultraPanel2_PaintClient(object sender, PaintEventArgs e)
        {

        }

        private void ultraCeomboEditor1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ultraButton4_Click(object sender, EventArgs e)
        {
            Inicio = null;
            Fin = null;
            // Ingresar datos // 
            ultraPanel2.Visible = true;
            ultraPanel1.Visible = true;
            ultraPanel3.Visible = false;
        }

        private void UltraGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void ultraButton6_Click(object sender, EventArgs e)
        {
            //Boton  Operaciones//
            //Recorrido de una lista//
            string Valor = ultraComboEditor1.Text;
            if (Valor == "Recorrido de una lista")
            {
                Recorrer();
                /*radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;*/
            }
            //Busqueda
            else if (Valor == "Busqueda en una lista")
            {
                ultraPanel1.Visible = true;
                ultraPanel3.Visible = true;
                ultraPanel4.Visible = false;
                /*radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;*/
            }
            //Inserción en una lista enlazada al comienzo//
            else if (Valor == "Inserción en una lista enlazada al comienzo")
            {
                ultraPanel3.Visible = false;
                ultraPanel1.Visible = true;
                ultraPanel2.Visible = true;
                ultraPanel4.Visible = false;
               /* radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;*/
            }
            //Inserción a continuación de un nodo determinado//
            else if (Valor == "Inserción a continuación de un nodo determinado")
            {
                ultraPanel3.Visible = true;
                ultraPanel1.Visible = true;
                ultraPanel2.Visible = true;
                ultraPanel4.Visible = true;
                ultraPanel5.Visible = false;
                /*radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;*/
            }
            //Eliminación de un nodo sucesor de uno determinado//
            else if (Valor == "Eliminación de un nodo sucesor de uno determinado")
            {
                ultraPanel3.Visible = true;
                ultraPanel1.Visible = true;
                ultraPanel2.Visible = true;
                ultraPanel4.Visible = true;
                ultraPanel5.Visible = true;
                ultraPanel6.Visible = false;
                /*radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;*/
            }
            //Eliminación de un nodo que contiene un determinado elemento de información//
            else if (Valor == "Eliminación de un nodo que contiene un determinado elemento de información")
            {
                ultraPanel3.Visible = true;
                ultraPanel1.Visible = true;
                ultraPanel2.Visible = true;
                ultraPanel4.Visible = true;
                ultraPanel5.Visible = true;
                ultraPanel6.Visible = true;
                ultraPanel7.Visible = false ;
                /*radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;*/
            }
            
            //Insercion a la lista de un dato//
            else if (Valor == "Añadir a lista simple")
            {                
                ultraTextEditor8.Text = "";
                ultraPanel1.Visible = true;
                ultraPanel2.Visible = true;
                ultraPanel3.Visible = true;
                ultraPanel4.Visible = true;
                ultraPanel5.Visible = true;
                ultraPanel6.Visible = true;
                ultraPanel7.Visible = true;
                ultraNumericEditor5.Visible = true;
                ultraTextEditor8.Visible = true;
                ultraLabel2.Visible = true;
               ultraNumericEditor5.Value = 1;
                ultraButton16.Text = "Insertar";
                ultraLabel6.Text = "Insercion en la lista";
                radioButton1.Visible =true;
                radioButton2.Visible = true;
                radioButton3.Visible =true;
                pictureBox15.Visible = false;
                pictureBox13.Visible = true;
                ultraLabel1.Visible = true;
            }

            //Insercion en medio de la lista de un dato//
            else if (Valor == "Insercion primero")
            {
                ultraTextEditor8.Visible = true;
                
                ultraTextEditor8.Text = "";
                ultraPanel1.Visible = true;
                ultraPanel2.Visible = true;
                ultraPanel3.Visible = true;
                ultraPanel4.Visible = true;
                ultraPanel5.Visible = true;
                ultraPanel6.Visible = true;
                ultraPanel7.Visible = true;
                ultraNumericEditor5.Visible = true;
                ultraLabel2.Visible = true;
                ultraLabel2.Visible = true;
                ultraNumericEditor5.Value = 1;
                ultraButton16.Text = "Insertar";
                ultraLabel6.Text = "Insercion primero";
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
                pictureBox15.Visible = false;
                pictureBox13.Visible = true;
                ultraLabel1.Visible = true;
            }

            //Insercion en medio de la lista de un dato//
            else if (Valor == "Insercion en medio de la lista")
            {
                ultraTextEditor8.Visible = true;                
                ultraTextEditor8.Text = "";
                ultraPanel1.Visible = true;
                ultraPanel2.Visible = true;
                ultraPanel3.Visible = true;
                ultraPanel4.Visible = true;
                ultraPanel5.Visible = true;
                ultraPanel6.Visible = true;
                ultraPanel7.Visible = true;
                ultraNumericEditor5.Visible = true;
                ultraLabel2.Visible = true;
                ultraLabel2.Visible = true;
                ultraNumericEditor5.Value = 1;
                ultraButton16.Text = "Insertar";
                ultraLabel6.Text = "Insercion en medio";
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
                pictureBox15.Visible = false;
                pictureBox13.Visible = true                   ;
                ultraLabel1.Visible = true;
            }

            //Insercion al final de la lista de un dato//
            else if (Valor == "Insercion al final")
            {
                ultraTextEditor8.Visible = true;                
                ultraTextEditor8.Text = "";
                ultraPanel1.Visible = true;
                ultraPanel2.Visible = true;
                ultraPanel3.Visible = true;
                ultraPanel4.Visible = true;
                ultraPanel5.Visible = true;
                ultraPanel6.Visible = true;
                ultraPanel7.Visible = true;
                ultraNumericEditor5.Visible = true;
                ultraLabel2.Visible = true;
                ultraLabel2.Visible = true;
                ultraNumericEditor5.Value = 1;
                ultraButton16.Text = "Insertar";
                ultraLabel6.Text = "Insercion al final";
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
                pictureBox15.Visible = false;
                pictureBox13.Visible = true;
                ultraLabel1.Visible = true;
            }

            //Eliminar al inicio de la lista un dato//
            else if (Valor == "Eliminar primero")
            {                
                ultraTextEditor8.Visible = false;
                ultraPanel1.Visible = true;
                ultraPanel2.Visible = true;
                ultraPanel3.Visible = true;
                ultraPanel4.Visible = true;
                ultraPanel5.Visible = true;
                ultraPanel6.Visible = true;
                ultraPanel7.Visible = true;
                ultraNumericEditor5.Visible = false;
                ultraLabel1.Visible = false;
                ultraLabel2.Visible = false;
                ultraLabel2.Visible = false;
                ultraButton16.Text = "Eliminar";
                ultraLabel6.Text = "Eliminar primero";
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
                pictureBox15.Visible = true;
                pictureBox13.Visible = false ;
            }

            //Eliminar en medio de la lista un dato//
            else if (Valor == "Eliminar en medio")
            {             
                ultraTextEditor8.Visible = false;
                ultraPanel1.Visible = true;
                ultraPanel2.Visible = true;
                ultraPanel3.Visible = true;
                ultraPanel4.Visible = true;
                ultraPanel5.Visible = true;
                ultraPanel6.Visible = true;
                ultraPanel7.Visible = true;
                ultraNumericEditor5.Visible = false;
                ultraLabel1.Visible = false;
                ultraLabel2.Visible = false;
                ultraButton16.Text = "Eliminar";
                ultraLabel6.Text = "Eliminar en medio";
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
                pictureBox15.Visible = true;
                pictureBox13.Visible = false ;
            }

            //Eliminar al final de la lista un dato//
            else if (Valor == "Eliminar final")
            {             
                ultraTextEditor8.Visible = false;
                ultraPanel1.Visible = true;
                ultraPanel2.Visible = true;
                ultraPanel3.Visible = true;
                ultraPanel4.Visible = true;
                ultraPanel5.Visible = true;
                ultraPanel6.Visible = true;
                ultraPanel7.Visible = true;
                ultraNumericEditor5.Visible = false;
                ultraLabel1.Visible = false;
                ultraLabel2.Visible = false;
                ultraButton16.Text = "Eliminar";
                ultraLabel6.Text = "Eliminar final";
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
                pictureBox15.Visible = true;
                pictureBox13.Visible = false ;
            }
        }

        private void ultraComboEditor1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                ultraButton6.PerformClick();
            }
        }

        private void ultraButton7_Click(object sender, EventArgs e)
        {
            ultraPanel1.Visible = false;
        }

        public void Recorrer()
        {
            int Contador = 1;
            DataGridView1.Rows.Clear();
            // Se inicializa el puntero//
            Estructuras_de_datos.Clases.Listas Recorrer = Inicio;
            Label6.Visible = false;
            //Se va recorriendo el puntero hasta que encuentre que este sea null //
            while (Recorrer != null)
            {
                DataGridView1.Rows.Add(Contador.ToString(), Recorrer.Nombre, Recorrer.Grupo, Recorrer.Carnet, Recorrer.Nota);
                Recorrer = Recorrer.Enlace;
                Contador++;
            }
        }

        private void ultraTextEditor4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ultraButton8_Click(object sender, EventArgs e)
        {
            ultraPanel1.Visible = false;
            ultraPanel3.Visible = false;
        }

        private void ultraComboEditor2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                ultraTextEditor4.Focus();
            }
        }

        private void ultraTextEditor4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                ultraButton9.PerformClick();
            }
        }

        private void ultraButton9_Click(object sender, EventArgs e)
        {
            if (ultraTextEditor4.Text != "")
            {
                if (ultraComboEditor2.Text == "Nota")
                {
                    try
                    {
                        int.Parse(ultraTextEditor4.Text);
                        Busqueda(ultraTextEditor4.Text, ultraComboEditor2.Text, 0);
                        MetroTabControl1.SelectedTab = metroTabPage1;
                    }
                    catch
                    {
                        MessageBox.Show("El valor introducido no parece ser un numero valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    Busqueda(ultraTextEditor4.Text, ultraComboEditor2.Text, 0);
                    MetroTabControl1.SelectedTab = metroTabPage1;
                }
            }
            else
            {
                MessageBox.Show("Faltan datos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UltraButton3_Click(object sender, EventArgs e)
        {
            UltraFormattedTextEditor2.Text = "";
            DataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
            Label6.Visible = true;
            label11.Visible = true;
            Primer = null;
            Ultimo = null;
            Universal = 0;
            Aviso = 0;
            Global = 0;
            Global2 = 0;
            Numero = 0;
            Improvisado = 0;
            Generico = 0;
            for (int i = 1; i <= 12; i++)
            {
                Cargar(null, null, null);
            }
        }

        private void UltraFormattedTextEditor2_LinkClicked(object sender, Infragistics.Win.FormattedLinkLabel.LinkClickedEventArgs e)
        {

        }

        public void Busqueda(string Elemento, string Clave, int Parametro)
        {
            bool Encontrado = false;
            int Nodo = 0;
            if (Clave == "Nombre")
            {
                Estructuras_de_datos.Clases.Listas Recorrer = Inicio;
                label11.Visible = false;
                //Se va recorriendo el puntero hasta que encuentre que este sea null //
                while (Recorrer != null)
                {
                    if (Recorrer.Nombre == Elemento)
                    {
                        UltraFormattedTextEditor2.Text = UltraFormattedTextEditor2.Text + "******************************\nValor a buscar :" + ultraTextEditor4.Text + "\nResultado: encontrado en el nodo[" + Convert.ToString(Nodo + 1) + "]" + "\n******************************";
                        Encontrado = true;
                        if (Parametro == 1)
                        {
                            UltraFormattedTextEditor2.Text = "******************************\nValor a buscar :" + ultraTextEditor11.Text + "\nResultado: encontrado en el nodo[" + Convert.ToString(Nodo + 1) + "]" + "\n******************************";
                            Eliminar_Nodo(Nodo + 1);
                            if (metroRadioButton1.Checked)
                            {
                                break;
                            }
                        }
                    }
                    Nodo = Nodo + 1;
                    Recorrer = Recorrer.Enlace;
                }
                if (Encontrado == false)
                {
                    UltraFormattedTextEditor2.Text = UltraFormattedTextEditor2.Text + "******************************" + "\nResultado: No encontrado" + "\n******************************";
                }
            }
            else if (Clave == "Grupo")
            {
                Estructuras_de_datos.Clases.Listas Recorrer = Inicio;
                label11.Visible = false;
                //Se va recorriendo el puntero hasta que encuentre que este sea null //
                while (Recorrer != null)
                {
                    if (Recorrer.Grupo == Elemento)
                    {
                        UltraFormattedTextEditor2.Text = UltraFormattedTextEditor2.Text + "******************************\nValor a buscar :" + ultraTextEditor4.Text + "\nResultado: encontrado en el nodo[" + Convert.ToString(Nodo + 1) + "]" + "\n******************************";
                        Encontrado = true;
                        if (Parametro == 1)
                        {
                            UltraFormattedTextEditor2.Text = "******************************\nValor a buscar :" + ultraTextEditor11.Text + "\nResultado: encontrado en el nodo[" + Convert.ToString(Nodo + 1) + "]" + "\n******************************";
                            Eliminar_Nodo(Nodo + 1);
                            if (metroRadioButton1.Checked)
                            {
                                break;
                            }
                        }
                    }
                    Nodo = Nodo + 1;
                    Recorrer = Recorrer.Enlace;
                }
                if (Encontrado == false)
                {
                    UltraFormattedTextEditor2.Text = UltraFormattedTextEditor2.Text + "******************************\n" + "Resultado: No encontrado" + "\n******************************";
                }
            }
            else if (Clave == "Carnet")
            {
                Estructuras_de_datos.Clases.Listas Recorrer = Inicio;
                label11.Visible = false;
                //Se va recorriendo el puntero hasta que encuentre que este sea null //
                while (Recorrer != null)
                {
                    if (Recorrer.Carnet == Elemento)
                    {
                        UltraFormattedTextEditor2.Text = UltraFormattedTextEditor2.Text + "******************************\nValor a buscar :" + ultraTextEditor4.Text + "\nResultado: encontrado en el nodo[" + Convert.ToString(Nodo + 1) + "]" + "\n******************************";
                        Encontrado = true;
                        if (Parametro == 1)
                        {
                            UltraFormattedTextEditor2.Text = "******************************\nValor a buscar :" + ultraTextEditor11.Text + "\nResultado: encontrado en el nodo[" + Convert.ToString(Nodo + 1) + "]" + "\n******************************";
                            Eliminar_Nodo(Nodo + 1);
                            if (metroRadioButton1.Checked)
                            {
                                break;
                            }
                        }
                    }
                    Nodo = Nodo + 1;
                    Recorrer = Recorrer.Enlace;
                }
                if (Encontrado == false)
                {
                    UltraFormattedTextEditor2.Text = UltraFormattedTextEditor2.Text + "******************************" + "\nResultado: No encontrado" + "\n******************************";
                }
            }
            else if (Clave == "Nota")
            {
                Estructuras_de_datos.Clases.Listas Recorrer = Inicio;
                label11.Visible = false;
                //Se va recorriendo el puntero hasta que encuentre que este sea null //
                while (Recorrer != null)
                {
                    if (Recorrer.Nota == (Convert.ToInt16(Elemento)))
                    {
                        UltraFormattedTextEditor2.Text = UltraFormattedTextEditor2.Text + "******************************\nValor a buscar :" + ultraTextEditor4.Text + "\nResultado: encontrado en el nodo[" + Convert.ToString(Nodo + 1) + "]" + "\n******************************";
                        Encontrado = true;
                        if (Parametro == 1)
                        {
                            Eliminar_Nodo(Nodo + 1);
                            if (metroRadioButton1.Checked)
                            {
                                break;
                            }
                        }
                    }
                    Nodo = Nodo + 1;
                    Recorrer = Recorrer.Enlace;
                }
                if (Encontrado == false)
                {
                    UltraFormattedTextEditor2.Text = UltraFormattedTextEditor2.Text + "******************************\nValor a buscar :" + "\nResultado: No encontrado" + "\n******************************";
                }
            }

        }

        private void ultraButton11_Click(object sender, EventArgs e)
        {
            if (ultraTextEditor7.Text != "" & ultraTextEditor6.Text != "" & ultraTextEditor5.Text != "")
            {
                Insercion_Despues_De_Un_Nodo(Convert.ToInt16(ultraNumericEditor3.Value));
            }
            else
            {
                MessageBox.Show("Faltan datos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ultraTextEditor7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                ultraTextEditor6.Focus();
            }
        }

        private void ultraTextEditor6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                ultraTextEditor5.Focus();
            }
        }

        private void ultraTextEditor5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                ultraNumericEditor2.Focus();
            }
        }

        private void ultraNumericEditor2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                ultraNumericEditor3.Focus();
            }
        }

        private void ultraNumericEditor3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                ultraButton11.PerformClick();
            }
        }

        private void ultraButton10_Click(object sender, EventArgs e)
        {
            ultraPanel4.Visible = false;
            ultraPanel3.Visible = false;
            ultraPanel1.Visible = false;
        }

        private void ultraButton12_Click(object sender, EventArgs e)
        {
            this.Close();
            Presentacion Instancia = new Presentacion();
            Instancia.Show();
        }

        private void ultraButton13_Click(object sender, EventArgs e)
        {
            ultraPanel5.Visible = false;
            ultraPanel4.Visible = false;
            ultraPanel3.Visible = false;
            ultraPanel1.Visible = false;
        }

        private void ultraButton14_Click(object sender, EventArgs e)
        {
            Eliminación_Despues_De_Un_Nodo(Convert.ToInt32(ultraNumericEditor4.Value));
            this.Recorrer();
        }

        public void Insercion_Despues_De_Un_Nodo(int Nodo)
        {
            int Contador = 0;
            Estructuras_de_datos.Clases.Listas Recorrer = Inicio;
            Estructuras_de_datos.Clases.Listas Aux = null;
            while (Recorrer != null)
            {
                if (Nodo - 1 == Contador)
                {
                    Aux = new Estructuras_de_datos.Clases.Listas(ultraTextEditor7.Text, ultraTextEditor6.Text, Convert.ToUInt16(ultraNumericEditor2.Value), ultraTextEditor5.Text, Recorrer.Enlace);
                    Recorrer.Enlace = Aux;
                    this.Recorrer();
                    MessageBox.Show("Registro añadido a la lista", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }
                Recorrer = Recorrer.Enlace;
                Contador++;
            }
            if (Aux == null)
            {
                MessageBox.Show("El nodo escogido por el usuario sobrepasa al conteo total de nodos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ultraNumericEditor4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                ultraButton14.PerformClick();
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void ultraButton19_Click(object sender, EventArgs e)
        {
            ultraPanel5.Visible = false;
            ultraPanel4.Visible = false;
            ultraPanel3.Visible = false;
            ultraPanel1.Visible = false;
        }

        private void ultraButton20_Click(object sender, EventArgs e)
        {
            if (ultraTextEditor11.Text != "")
            {
                if (ultraComboEditor3.Text == "Nota")
                {
                    try
                    {
                        Int32.Parse(ultraTextEditor11.Text);
                        Busqueda(ultraTextEditor11.Text, ultraComboEditor3.Text, 1);
                        MetroTabControl1.SelectedTab = metroTabPage1;
                    }
                    catch
                    {
                        MessageBox.Show("La nota digitada no parece ser un numero valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    Busqueda(ultraTextEditor11.Text, ultraComboEditor3.Text, 1);
                    MetroTabControl1.SelectedTab = metroTabPage1;
                }
            }

            else
            {
                MessageBox.Show("Faltan datos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void ultraComboEditor3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                ultraTextEditor11.Focus();
            }
        }

        private void ultraTextEditor11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                ultraButton20.PerformClick();
            }
        }

        public void Eliminación_Despues_De_Un_Nodo(int Nodo)
        {
            int Contador = 0;
            Estructuras_de_datos.Clases.Listas Recorrer = Inicio;
            while (Recorrer != null)
            {
                if (Nodo - 1 == Contador)
                {
                    try
                    {
                        Recorrer.Enlace = Recorrer.Enlace.Enlace;
                    }
                    catch
                    {
                        MessageBox.Show("El ultimo nodo no tiene un sucessor que se pueda eliminar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                    this.Recorrer();
                    MessageBox.Show("Registro eliminado a la lista", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }
                Recorrer = Recorrer.Enlace;
                Contador++;
            }
            if (Recorrer == null)
            {
                MessageBox.Show("El nodo digitado sobrepasa el limite de la lista", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void ultraLabel1_Click(object sender, EventArgs e)
        {

        }

        private void ultraLabel2_Click(object sender, EventArgs e)
        {

        }

        private void ultraLabel3_Click(object sender, EventArgs e)
        {

        }

        private void ultraLabel4_Click(object sender, EventArgs e)
        {

        }

        private void ultraTextEditor8_ValueChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
            Primer = null;
            Ultimo = null;

            if (radioButton1.Checked == true)
            {
                dataGridView2.Visible = true;
                dataGridView3.Visible = false;
                dataGridView4.Visible = false;
                for (int i = 1; i <= 12; i++)
                {
                    Cargar(null, null, null);
                }
                ultraTextEditor8.Clear();
                ultraNumericEditor5.Value = 1;
                dataGridView2.Rows.Clear();
                dataGridView3.Rows.Clear();
                dataGridView4.Rows.Clear();
                                
            }
            else {                
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
            Primer = null;
            Ultimo = null;
            if (radioButton2.Checked == true)
            {
                dataGridView2.Visible = true;
                dataGridView3.Visible = true;
                dataGridView4.Visible = false;
                for (int i = 1; i <= 12; i++)
                {
                    Cargar(null, null, null);
                }
                ultraTextEditor8.Clear();
                ultraNumericEditor5.Value = 1;                                
            }
            else {                
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
            Primer = null;
            Ultimo = null;
            if (radioButton3.Checked == true)
            {
                dataGridView2.Visible = true;
                dataGridView3.Visible = true;
                dataGridView4.Visible = true;
                for (int i = 1; i <= 12; i++)
                {
                    Cargar(null, null, null);
                }
                ultraTextEditor8.Clear();
                ultraNumericEditor5.Value = 1;                                
            }
            else {             
            }
        }

        private void ultraNumericEditor5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                ultraButton16.PerformClick();
            }
        }

        private void ultraButton17_Click(object sender, EventArgs e)
        {
         
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ultraTextEditor8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                ultraNumericEditor5.Focus();
            }
        }

        private void ultraButton15_Click(object sender, EventArgs e)
        {
            ultraPanel1.Visible = false;
            ultraPanel2.Visible = true;
            ultraPanel3.Visible = false;
            ultraPanel4.Visible = false;
            ultraPanel5.Visible = false;
            ultraPanel6.Visible = false;
            ultraPanel7.Visible = false;

        }

        private void ultraButton16_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false)
            {
                MessageBox.Show("Selecciona un tipo de estructura");
            }

            Global = 0;
         
            if (Numero == 0)
            {
                Global2 = Convert.ToInt32(ultraNumericEditor5.Value);
                Generico = Convert.ToInt32(ultraNumericEditor5.Value);
                Numero++;
            }
            if (ultraTextEditor8.Text != "")
            {
                if (ultraLabel6.Text == "Insercion en la lista")
                {
                    Insercion_lista(Convert.ToInt32(ultraNumericEditor5.Value));
                    this.RecorrerLista();
                    MetroTabControl1.SelectedTab = metroTabPage3;
                }

                else if (ultraLabel6.Text == "Insercion primero")
                {
                    
                    Insercion_Inicio(Convert.ToInt32(ultraNumericEditor5.Value));
                    this.RecorrerLista();
                    MetroTabControl1.SelectedTab = metroTabPage3;
                }

                else if (ultraLabel6.Text == "Insercion en medio")
                {
                   Insercion_Medio(Convert.ToInt32(ultraNumericEditor5.Value));
                    this.RecorrerLista();
                    MetroTabControl1.SelectedTab = metroTabPage3;
                }

                else if (ultraLabel6.Text == "Insercion al final")
                {
                    Insercion_lista(Convert.ToInt32(ultraNumericEditor5.Value));
                    this.RecorrerLista();
                    MetroTabControl1.SelectedTab = metroTabPage3;
                }

            }
            else { MessageBox.Show("Ingresa un dato en la lista", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning); }


            if (ultraLabel6.Text == "Eliminar primero")
                {
                try
                {
                    Eliminar_Inicio();
                    this.RecorrerLista();
                    MetroTabControl1.SelectedTab = metroTabPage3;
                }
                catch
                {
                    MessageBox.Show("La lista esta vacia", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                }

                else if (ultraLabel6.Text == "Eliminar en medio")
                {
                    Eliminar_Medio();
                    this.RecorrerLista();
                    MetroTabControl1.SelectedTab = metroTabPage3;
                }

                else if (ultraLabel6.Text == "Eliminar final")
                {
                    Eliminar_Final();
                    this.RecorrerLista();
                    MetroTabControl1.SelectedTab = metroTabPage3;
                }
   
        }

        public void Eliminar_Nodo(int Nodo)
        {
            int Contador = 0;
            Estructuras_de_datos.Clases.Listas Recorrer = Inicio;
            Estructuras_de_datos.Clases.Listas Aux = null;
            while (Recorrer != null)
            {
                if (Nodo - 1 == Contador)
                {
                    if (Aux == null)
                    {
                        Inicio = Recorrer.Enlace;
                    }
                    if (Recorrer.Enlace == null)
                    {
                        if (Aux != null)
                        {
                            Aux.Enlace = null;
                        }
                    }
                    try
                    {
                        Aux.Enlace = Recorrer.Enlace;
                    }
                    catch
                    { }
                    this.Recorrer();
                    MessageBox.Show("Registro eliminado a la lista", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }
                Aux = Recorrer;
                Recorrer = Recorrer.Enlace;
                Contador++;
            }
            if (Recorrer == null)
            {
                MessageBox.Show("El nodo digitado sobrepasa el limite de la lista", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        //Creacion de metodos extras para un dato en la Segunda lista//
        public void Insercion_lista(int Nodo)
        {
            if (Aviso == 0)
            {
                try
                {
                    int Contador = 0;
                    Estructuras_de_datos.Clases.Listas Recorrer = Primer;
                    while (Recorrer != null)
                    {
                        if (Nodo- 1 == Contador)
                        {
                            Recorrer.Dato = (ultraTextEditor8.Value).ToString();
                            Recorrer.Orden = 0.ToString();
                            Recorrer.Orden2= 0.ToString();
                            Vale = Recorrer;
                            if (radioButton3.Checked == true)
                            {
                                RecorrerLista();
                                Recorrer.Orden = Posiciones[0].ToString();
                            }
                        }
                        Contador++;
                        Recorrer = Recorrer.Enlace2;
                    }
                   
                    Aviso = 1;
                    Cuenta = Convert.ToInt16(ultraNumericEditor5.Value);
                }
                catch { }
            }

            else
            {
                try
                {
                    int Contador = 0;
                    Estructuras_de_datos.Clases.Listas Recorrer = Primer;
                    while (Recorrer != null)
                    {
                        if (Cuenta - 1 == Contador)
                        {
                            Vale.Orden = (ultraNumericEditor5.Value).ToString();
                            Recorrer.Dato = Vale.Dato;
                            Recorrer.Orden = Vale.Orden;
                            Recorrer.Orden2 = Vale.Orden2;
                        }
                        Contador++;
                        Recorrer = Recorrer.Enlace2;
                    }

                    int Contador1 = 0;
                    Estructuras_de_datos.Clases.Listas Recorrer1 = Primer;
                    while (Recorrer1 != null)
                    {
                        if (Nodo - 1 == Contador1)
                        {
                            Recorrer1.Dato = (ultraTextEditor8.Value).ToString();
                            Recorrer1.Orden = 0.ToString();
                            Recorrer1.Orden2 = Cuenta.ToString();
                            Vale = Recorrer1;

                            if (radioButton3.Checked == true)
                            {
                                RecorrerLista();
                                Recorrer1.Orden = Posiciones[0].ToString() ;
                            }
                        }
                        Contador1++;
                        Recorrer1 = Recorrer1.Enlace2;
                    }
                    Cuenta = Convert.ToInt16(ultraNumericEditor5.Value);
                }
                catch { }
            }

        }

        public void Insercion_Inicio(int Nodo)
        {
            int Auxi = 0;
            int PosicionAntes = 0, Ubicacion = 0;
            int Contador = 0, Contador1 = 0;
            Estructuras_de_datos.Clases.Listas Recorrer = Primer;
            Estructuras_de_datos.Clases.Listas Recorrer1 = Primer;
            Estructuras_de_datos.Clases.Listas Aux = Primer;

            while (Recorrer != null)
            {
                if (Nodo - 1 == Contador)
                {
                    RecorrerLista();
                    if (Global != 0)
                    {
                        Recorrer.Dato = (ultraTextEditor8.Value).ToString();
                        
                        if (Global2 != Convert.ToInt32(ultraNumericEditor5.Value))
                        {
                            Recorrer.Orden = (Global2).ToString();
                            Recorrer.Orden2 = 0.ToString();

                            PosicionAntes = Nodo;
                            Ubicacion = Global2;
                            Auxi++;
                        }

                        else if (Improvisado == 0)
                        {
                            Recorrer.Orden = 0.ToString();
                            Recorrer.Orden2 = 0.ToString();
                        }
                    }
                    else {
                        Recorrer.Dato = (ultraTextEditor8.Value).ToString();
                        Recorrer.Orden = 0.ToString();
                        Recorrer.Orden2 = 0.ToString();
                        if (radioButton3.Checked == true)
                        {
                            RecorrerLista();
                            Recorrer.Orden = Posiciones[0].ToString();
                        }
                    }

                    RecorrerLista();
                    Global2 = Convert.ToInt32(ultraNumericEditor5.Value);
                    Auxi++;
                    break;
                }
                Aux = Recorrer;
                Recorrer = Recorrer.Enlace2;
                Contador++;
            
            }

              //Adicional//
            if (Auxi > 0) {
                try {

                    RecorrerLista();
                    while (Recorrer1 != null)
                    {
                        if ( Ubicacion- 1 == Contador1)
                        {
                            Recorrer1.Orden2 = PosicionAntes.ToString();
                            Auxi = 0;
                            break;
                        }
                        Recorrer1 = Recorrer1.Enlace2;
                        Contador1++;
                    }
                 }
                catch { }
            }

        }

        public void Insercion_Medio(int Nodo)
        {
            int Contador = 0, Contador1 = 0, Contador2 = 0 ;
            int NuevaPosicion = Improvisado - 1;
            Estructuras_de_datos.Clases.Listas Recorrer1 = Primer;
            Estructuras_de_datos.Clases.Listas Recorrer2 = Primer;
            Estructuras_de_datos.Clases.Listas Recorrer3 = Primer;
            
                if (Improvisado > 1)
                {
                try
                {
                    Improvisado = ((Improvisado) / 2);
                    while (Recorrer1 != null)
                    {
                        if (Nodo - 1 == Contador)
                        {
                            Recorrer1.Dato = (ultraTextEditor8.Value).ToString();
                            Recorrer1.Orden = (Posiciones[Improvisado]).ToString();
                            Recorrer1.Orden2 = (Posiciones[Improvisado-1]).ToString();
                        }
                        Recorrer1 = Recorrer1.Enlace2;
                        Contador++;
                    }

                    while (Recorrer3 != null)
                    {
                        if (Posiciones[Improvisado - 1] - 1 == Contador1)
                        {
                            Recorrer3.Orden = (ultraNumericEditor5.Value).ToString();
                        }
                        Recorrer3 = Recorrer3.Enlace2;
                        Contador1++;
                    }

                    while (Recorrer2 != null)
                    {
                        if (Posiciones[Improvisado] - 1 == Contador2)
                        {
                            Recorrer2.Orden2 = (ultraNumericEditor5.Value).ToString();
                        }
                        Recorrer2 = Recorrer2.Enlace2;
                        Contador2++;
                    }

                }
                catch { }
        }
            
            else
            {
                MessageBox.Show("Debe ingresar como minimo dos datos a la lista", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        
        public void Eliminar_Inicio()
        {
            int Contador = 0, Contador1 = 0;
            Estructuras_de_datos.Clases.Listas Recorrer = Primer;
            Estructuras_de_datos.Clases.Listas Recorrer1 = Primer;

            while (Recorrer != null)
            {
                try
                {
                    if (Posiciones[0] - 1 == Contador)
                    {
                        Recorrer.Dato = "---------";
                        Recorrer.Orden = "--------";
                    }
                    Recorrer = Recorrer.Enlace2;
                    Contador++;
                }
                catch
                {
                    break;
                }
            }

            while (Recorrer1 != null)
            {
                if (Posiciones[1] - 1 == Contador1)
                {
                    Recorrer1.Orden2 = "0";
                }
                try
                {

                    if (Posiciones[Improvisado - 1] - 1 == Contador1)
                    {
                        Recorrer1.Orden = Posiciones[Improvisado - 1].ToString();
                        if (radioButton3.Checked == true)
                        {
                            RecorrerLista();
                            Recorrer1.Orden = Posiciones[0].ToString();
                        }
                    }
                    Recorrer1 = Recorrer1.Enlace2;
                    Contador1++;
                }
                catch { break; }
            }


        }

        public void Eliminar_Medio()
        {
            int Contador = 0, Contador1 = 0, Contador2=0;
            int NuevaPosicion = Improvisado - 1;
            Estructuras_de_datos.Clases.Listas Recorrer1 = Primer;
            Estructuras_de_datos.Clases.Listas Recorrer2 = Primer;
            Estructuras_de_datos.Clases.Listas Recorrer3 = Primer;

            if (Improvisado > 2)
            {
                try
                {
                    Improvisado = ((Improvisado) / 2);
                    while (Recorrer1 != null)
                    {
                        if (Posiciones[Improvisado] - 1 == Contador)
                        {
                        Recorrer1.Dato = "---------";
                        Recorrer1.Orden = "--------";
                        Recorrer1.Orden2 = "--------";
                        }
                        Recorrer1 = Recorrer1.Enlace2;
                        Contador++;
                    }

                    while (Recorrer3 != null)
                    {
                        if (Posiciones[Improvisado - 1] - 1 == Contador1)
                        {
                            Recorrer3.Orden = (Posiciones[Improvisado+1]).ToString();
                        }
                        Recorrer3 = Recorrer3.Enlace2;
                        Contador1++;
                    }

                    while (Recorrer2 != null)
                    {
                        if (Posiciones[Improvisado + 1] - 1 == Contador2)
                        {
                            Recorrer2.Orden2 = (Posiciones[Improvisado - 1]).ToString();
                        }
                        Recorrer2 = Recorrer2.Enlace2;
                        Contador2++;
                    }
                }
                catch { }
            }

            else
            {
                MessageBox.Show("La lista al menos debe contener dos Tres datos para eliminar el dato de enmedio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void Eliminar_Final()
        {
            int Contador = 0, Contador1 =0;
            Estructuras_de_datos.Clases.Listas Recorrer = Primer;
            Estructuras_de_datos.Clases.Listas Recorrer1 = Primer;
            while (Recorrer != null)
            {
                if (Improvisado > 0)
                { 
                if (Posiciones[Improvisado-1]-1 == Contador ) {
                        Recorrer.Dato = "---------";
                        Recorrer.Orden = "--------";
                        Recorrer.Orden2 = "--------";

                        if (radioButton3.Checked == true)
                        {
                            RecorrerLista();
                            Recorrer.Orden = Posiciones[0].ToString();
                        }

                    }
                }
                Recorrer = Recorrer.Enlace2;
                Contador++; 
            }
            RecorrerLista();
                

            while (Recorrer1 != null)
            {
                if (Improvisado > 0)
                {
                    if (Posiciones[Improvisado - 1] - 1 == Contador1)
                    {
                        Recorrer1.Orden = 0.ToString();

                        if (radioButton3.Checked == true)
                        {
                            RecorrerLista();
                            Recorrer1.Orden = Posiciones[0].ToString();
                        }
                    }
                }
                Recorrer1 = Recorrer1.Enlace2;
                Contador1++;
            }
        }

        public void RecorrerLista()
        {
            int Contadora = 1;
            Improvisado = 0;
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
            Extra = null;
            Global = 0;
            Estructuras_de_datos.Clases.Listas Recorrer = Primer;
            while (Recorrer != null)
             {
                try
                {
                    if ((Recorrer.Dato == null) || (Recorrer.Dato == "---------"))
                    {
                        Recorrer.Dato = "---------";
                        Recorrer.Orden = "--------";
                        Recorrer.Orden2 = "--------";
                    }
                    else {
                        Global = Global + 1;
                    }

                    if (radioButton1.Checked == true)
                    {
                        dataGridView2.Rows.Add(Contadora, Recorrer.Dato.ToString(), Recorrer.Orden.ToString());
                        //listBox1.Text = listBox1.Text + listBox1.Items.Add("                       " + Contadora + "                       " + (Recorrer.Dato).ToString() + "                       " + (Recorrer.Orden).ToString() + "\n");
                    }
                    else if (radioButton2.Checked == true)
                    {
                        dataGridView3.Rows.Add(Contadora, Recorrer.Orden2.ToString(), Recorrer.Dato.ToString(), Recorrer.Orden.ToString());
                        //listBox1.Text = listBox1.Text + listBox1.Items.Add("                " + Contadora + "                " + (Recorrer.Orden2).ToString() + "                " + (Recorrer.Dato).ToString() + "                " + (Recorrer.Orden).ToString() + "\n");
                    }
                    else if (radioButton3.Checked == true)
                    {
                        dataGridView4.Rows.Add(Contadora, Recorrer.Dato.ToString(), Recorrer.Orden.ToString());
                        //  listBox1.Text = listBox1.Text + listBox1.Items.Add("                       " + Contadora + "                       " + (Recorrer.Dato).ToString() + "                       " + (Recorrer.Orden).ToString() + "\n");
                    }
                    
                        if (Recorrer.Dato != "---------")
                    {
                        if (Improvisado == 0)
                        {
                            Guardando_Posicion_Anterior[Improvisado] = 0;
                        }
                        else
                        {
                            Guardando_Posicion_Anterior[Improvisado] = Posiciones[Improvisado-1];
                        }
                        Posiciones[Improvisado] = Contadora;
                        Improvisado++;
                    }

                        Recorrer = Recorrer.Enlace2;
                    Contadora++;
                }
                catch {
                    Recorrer = Recorrer.Enlace2;
                    Contadora++;
                }
            }
        }


    }
    }



