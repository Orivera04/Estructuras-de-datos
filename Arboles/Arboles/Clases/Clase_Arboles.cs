using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arboles.Clases
{
    public class Clase_Arboles
    {
        public int Dato;
        public Clase_Arboles Enlace_Izquierdo;
        public Clase_Arboles Enlace_Derecho;
        public Point Punto = new Point();
        public Clase_Arboles Padre;
        public Clase_Arboles(Clase_Arboles Nodo_Izquierdo ,Clase_Arboles Nodo_Derecho,int Dato,int X , int Y, Clase_Arboles Papa)
        {
            Enlace_Derecho = Nodo_Izquierdo;
            this.Enlace_Izquierdo = Nodo_Derecho;
            this.Dato = Dato;
            this.Punto.X = X;
            this.Punto.Y = Y;
            this.Padre = Papa;
        }                                              
    }
}
