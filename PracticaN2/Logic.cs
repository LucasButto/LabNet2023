using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaN2
{
    public class Logic
    {
        public void DispararExcepcion()
        {
            throw new Exception("¡Esta es una excepción generada desde Logic!");
        }

        public Exception ObtenerExcepcionPersonalizada()
        {
            return new MiExcepcion("¡Esta es una excepción personalizada generada desde Logic!");
        }
    }
}
