 using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos.Clases
{
    public class Clase_Grafo
    {
        public int Dato;
        public Point Locacion = new Point();
        public Clase_Grafo Enlace;                
        public SolidBrush Pincel = new SolidBrush(Color.Blue);
        public Clase_Grafo(int Dato , int X , int Y ,Clase_Grafo Enlace,Color Nuevo)
        {
            this.Dato = Dato;
            this.Locacion.X = X;
            this.Locacion.Y = Y;
            this.Enlace = Enlace;
            Pincel.Color = Nuevo;
        }

    }
}
