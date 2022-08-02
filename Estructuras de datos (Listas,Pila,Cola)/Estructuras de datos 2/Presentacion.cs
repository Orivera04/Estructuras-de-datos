using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace Estructuras_de_datos
{
    public partial class Presentacion : Form
    {
        public Presentacion()
        {
            InitializeComponent();
        }

        private void Presentacion_Load(object sender, EventArgs e)
        {

        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            Listas Instancia = new Listas();
            Instancia.ShowDialog();            
        }

        private void LinkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Listas Instancia = new Listas();
            Instancia.ShowDialog();            
        }

        private void PictureBox7_Click(object sender, EventArgs e)
        {
            Pilas_Form Instancia = new Estructuras_de_datos.Pilas_Form();
            Instancia.ShowDialog();            
        }

        private void LinkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Pilas_Form Instancia = new Estructuras_de_datos.Pilas_Form();
            Instancia.ShowDialog();            
        }

        private void PictureBox8_Click(object sender, EventArgs e)
        {
            Colas_Form Instancia = new Estructuras_de_datos.Colas_Form();
            Instancia.ShowDialog();            
        }

        private void LinkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Colas_Form Instancia = new Estructuras_de_datos.Colas_Form();
            Instancia.ShowDialog();            
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {


            ProcessStartInfo Inicio = new ProcessStartInfo();

            Inicio.Arguments = "Convertidor.exe";
            // Enter the executable to run, including the complete path
            Inicio.FileName = "Convertidor.exe";
            // Do you want to show a console window?                                   

            // Run the external process & wait for it to finish
            using (Process proc = Process.Start(Inicio))
            {
                proc.WaitForExit();

            }
        }
    }
}
