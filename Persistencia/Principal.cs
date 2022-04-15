using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica;
using Newtonsoft.Json;

namespace Persistencia
{
    public sealed class Principal
    {
        private readonly static Principal _instance = new Principal();

        public static Principal Instance
        {
            get { return _instance; }
        }

        public void VerificarArchivos()
        {
            if (File.Exists(@"C:\Users\J\Desktop\Atenciones.txt"))
            {
                Logica.Principal.Instance.ActualizarAtenciones(LeerAtenciones());
            }
            else
            {
                File.Create(@"C:\Users\J\Desktop\Atenciones.txt").Close();
            }
            if (File.Exists(@"C:\Users\J\Desktop\Personas.txt"))
            {
                Logica.Principal.Instance.ActualizarPersonas(LeerPersonas());
            }
            else
            {
                File.Create(@"C:\Users\J\Desktop\Personas.txt").Close();
            }
            GuardarPersonas(Logica.Principal.Instance.ObtenerPersonas());
            GuardarAtenciones(Logica.Principal.Instance.ObtenerAtenciones());
        }

        public List<Atencion> LeerAtenciones()
        {
            using (StreamReader reader = new StreamReader(@"C:\Users\J\Desktop\Atenciones.txt"))
            {
                string contenido = reader.ReadToEnd();
                List<Atencion> nuevaLista = new List<Atencion>();
                if (contenido != "")
                {
                    nuevaLista = JsonConvert.DeserializeObject<List<Atencion>>(contenido);
                }
                return nuevaLista;
            }
        }
        public bool GuardarAtenciones(List<Atencion> atenciones)
        {
            using (StreamWriter writer = new StreamWriter(@"C:\Users\J\Desktop\Atenciones.txt", false))
            {
                writer.Write(JsonConvert.SerializeObject(atenciones));
                return true;
            }
        }

        public List<Persona> LeerPersonas()
        {
            using (StreamReader reader = new StreamReader(@"C:\Users\J\Desktop\Personas.txt"))
            {
                string contenido = reader.ReadToEnd();
                List<Persona> nuevaLista = new List<Persona>();
                if (contenido != "")
                {
                    nuevaLista = JsonConvert.DeserializeObject<List<Persona>>(contenido);
                }
                return nuevaLista;
            }
        }
        public bool GuardarPersonas(List<Persona> personas)
        {
            using (StreamWriter writer = new StreamWriter(@"C:\Users\J\Desktop\Atenciones.txt", false))
            {
                writer.Write(JsonConvert.SerializeObject(personas));
                return true;
            }
        }


    }
}
