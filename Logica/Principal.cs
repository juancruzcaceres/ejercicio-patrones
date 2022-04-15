using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Logica
{
    public sealed class Principal
    {
        private readonly static Principal _instance = new Principal();
        public static List<Atencion> Atenciones { get; set; }
        public static List<Persona> Personas { get; set; }

        public static Principal Instance
        {
            get { return _instance; }
        }

        public decimal CargarAtencion(string DNI, int CodigoEnfermedad)
        {
            if (Enum.IsDefined(typeof(TipoEnfermedad), CodigoEnfermedad))
            {
                Persona cliente = Personas.Find(x => x.DNI == DNI);
                if (cliente != null)
                {
                    Enfermedad enfermedad = cliente.Cobertura.Enfermedades.Find(x => x.Tipo == (TipoEnfermedad)CodigoEnfermedad);
                    if (enfermedad != null)
                    {
                        Atencion nuevaAtencion = new Atencion() { Cliente = cliente, Enfermedad = enfermedad, Fecha = DateTime.Today };
                        nuevaAtencion.Incrementar();
                        Atenciones.Add(nuevaAtencion);
                        
                        MailAddress to = new MailAddress("<<mail>>");
                        MailAddress from = new MailAddress("<<mail>>");
                        MailMessage mail = new MailMessage(from, to);
                        mail.Subject = "Atención cargada con exito!";
                        mail.Body = "Se cargó con exito una nueva atencion.";
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.Credentials = new NetworkCredential(
                            "<<mail>>", "<<password>>");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);

                        return enfermedad.Costo;
                    }
                }
            }
            return 0;
        }

        public void CargarCliente(Persona cliente)
        {
            Personas.Add(cliente);
        }

        public List<Persona> ObtenerPersonas()
        {
            return Personas;
        }

        public List<Atencion> ObtenerAtenciones()
        {
            return Atenciones;
        }

        public bool ActualizarPersonas(List<Persona> personas)
        {
            Personas = personas;
            return true;
        }

        public bool ActualizarAtenciones(List<Atencion> atenciones)
        {
            Atenciones = atenciones;
            return true;
        }

    }
}
