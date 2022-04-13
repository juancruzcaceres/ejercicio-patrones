using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Atencion
    {
        public static int ID { get; set; }
        public DateTime Fecha { get; set; }
        public Enfermedad Enfermedad { get; set; }
        public Persona Cliente { get; set; }

        public int Incrementar()
        {
            ID++;
            return ID;
        }
    }
}
