using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTransporte
{
    public abstract class TransportePublico
    {
        public TransportePublico(int pasajeros)
        {
            obtenerPasajeros = pasajeros;
        }

        public int obtenerPasajeros { get; set; }

        public abstract string Avanzar();

        public abstract string Detenerse();
    }
}
