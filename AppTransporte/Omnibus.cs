using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTransporte
{
    internal class Omnibus : TransportePublico
    {
        public Omnibus(int pasajeros) : base(pasajeros)
        {
        }

        public override string Avanzar()
        {
            return $"Omnibus avanzando con {getPasajeros} pasajeros";
        }

        public override string Detenerse()
        {
            return "Omnibus Deteniendose";
        }
    }
}
