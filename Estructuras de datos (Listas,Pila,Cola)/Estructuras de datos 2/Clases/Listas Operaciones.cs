using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructuras_de_datos_2.Clases
{
    class Listas_Operaciones
    {
        public Estructuras_de_datos_2.Clases.Listas_Datos Inicio, Fin;
        public Listas_Operaciones()
        {
            Inicio = null;
            Fin = null;
        }
        public void Insertar(int Nota, String Nombre, String Grupo, string Carnet)
        {
            Inicio = new Estructuras_de_datos_2.Clases.Listas_Datos(Nombre, Grupo, Nota, Carnet, Inicio);
            if (Fin == null)
            {
                Fin = Inicio;
            }
        }

        public void Recorrer()
        {
            Listas_Datos Recorrer = Inicio;
            Listas Instancia = new Listas();
            while(Recorrer != null)
            {               
                Instancia.DataGridView1.Rows.Add("Dwdwd");
            }
        }
    }
}
