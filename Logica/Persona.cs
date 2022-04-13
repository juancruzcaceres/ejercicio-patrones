using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Ciudad { get; set; }
        public decimal IngresosNetosAnuales { get; set; }
        public Cobertura Cobertura { get; set; }

        public bool AccedeACobertura(Cobertura cobertura)
        {
            return cobertura.CalcularCosto() <= IngresosNetosAnuales;
        }
    }
}
