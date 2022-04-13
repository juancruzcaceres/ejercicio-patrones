using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public sealed class Principal
    {
        private readonly static Principal _instance = new Principal();

        public static Principal Instance
        {
            get { return _instance; }
        }

    }
}
