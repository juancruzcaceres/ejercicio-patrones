using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Cobertura
    {
        public TipoCobertura Tipo { get; set; }
        public string Descripcion { get; set; }
        public string Empresa { get; set; }
        public int CantidadMaxDeIntegrantes { get; set; }
        public decimal CostoBase { get; set; }
        public List<Enfermedad> Enfermedades { get; set; }

        public enum TipoCobertura
        {
            Normal,
            Maxima
        }

        public decimal CalcularCosto()
        {
            if (Tipo==0)
                return CostoBase + Enfermedades.Average(x => x.Costo);
            return Enfermedades.Sum(x => x.Costo);
        }
    }
}
