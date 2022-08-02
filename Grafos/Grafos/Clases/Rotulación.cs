using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos.Clases
{
    class Rotulación
    {
        public Clase_Grafo Nodo;
        public Clase_Grafo Nodo_Precedente;
        public int Distancia;
        public Rotulación Enlace;

        public Rotulación(Clase_Grafo Nodo,Clase_Grafo Nodo_Precedente,int Distancia,Rotulación Enlace)
        {
            this.Nodo = Nodo;
            this.Nodo_Precedente = Nodo_Precedente;
            this.Distancia = Distancia;
            this.Enlace = Enlace;
        }

    }
}
