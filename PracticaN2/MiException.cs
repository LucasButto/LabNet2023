using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaN2
{
    public class MiExcepcion : Exception
    {
        public MiExcepcion(string message) : base("¡Error personalizado! " + message) { }
    }
}
