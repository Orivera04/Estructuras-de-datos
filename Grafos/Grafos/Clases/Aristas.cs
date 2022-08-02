using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos.Clases
{
    class Aristas
    {
      public  Clase_Grafo Grafo_Inicio;
      public  Clase_Grafo Grafo_Fin;
      public   Aristas Enlace;
        public int Peso;

        public Aristas(Clase_Grafo Inicio , Clase_Grafo Fin, Aristas Enlace,int Peso)
        {
            this.Grafo_Inicio = Inicio;
            this.Grafo_Fin = Fin;
            this.Enlace = Enlace;
            this.Peso = Peso;
        }

    }
}
