using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTransporte
{
    internal class Taxi : TransportePublico
    {
        public Taxi(int pasajeros) : base(pasajeros)
        {
        }

        public override string Avanzar()
        {
            return $"Taxi avanzando con {getPasajeros} pasajeros";
        }

        public override string Detenerse()
        {
            return "Taxi Deteniendose";
        }
    }
}
