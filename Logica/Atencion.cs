using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    class Atencion
    {
        public static int ID { get; set; }
        public DateTime Fecha { get; set; }
        public Enfermedad Enfermedad { get; set; }
        public Persona Cliente { get; set; }
    }
}
