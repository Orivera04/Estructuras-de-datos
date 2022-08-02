using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructuras_de_datos.Clases
{
    public class Listas
    {
        public string Nombre;
        public string Grupo;
        public int Nota;
        public string Carnet;
        public string Dato;
        public Listas Enlace;
        public Listas Enlace2;
        public string Orden;
        public string Orden2;
        public int Posicion;

        public Listas(string Nombre, string Grupo, int Nota, string Carnet, Listas Enlace)
        {
            this.Nombre = Nombre;
            this.Grupo = Grupo;
            this.Nota = Nota;
            this.Carnet = Carnet;
            this.Enlace = Enlace;
        }

                public Listas(string Dato, Listas Enlace2, string Orden, string Orden2)
        {
            this.Dato = Dato;
            this.Enlace2 = Enlace2;
            this.Orden = Orden;
            this.Orden2 = Orden2;
        }

        public Listas(int Posicion)
        {
            this.Posicion = Posicion;
        }

        }
}
