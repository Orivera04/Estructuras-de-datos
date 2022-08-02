using Grafos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Modulo3
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void PictureBox8_Click(object sender, EventArgs e)
        {
            Grafo Formulario = new Grafos.Grafo();
            Formulario.ShowDialog();
        }

        private void LinkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {            
            Grafo Formulario = new Grafos.Grafo();
            Formulario.ShowDialog();

        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            Arboles.Arboles Formulario = new Arboles .Arboles();
            Formulario.ShowDialog();
        }
    }
}
