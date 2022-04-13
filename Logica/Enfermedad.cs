using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Enfermedad
    {
        public TipoEnfermedad Tipo { get; set; }
        public string Nombre { get; set; }
        public decimal Costo { get; set; }
    }
}
