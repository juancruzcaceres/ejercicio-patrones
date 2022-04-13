﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica;

namespace Presentacion
{
    class Program
    {
        static void Main(string[] args)
        {

            Enfermedad enfermedad = new Enfermedad() { Tipo = 0, Costo = 999, Nombre = "Enfermedad rara" };
            List<Enfermedad> enfermedades = new List<Enfermedad>();
            enfermedades.Add(enfermedad);
            Cobertura cobertura1 = new Cobertura() { CantidadMaxDeIntegrantes = 1, CostoBase = 1000, Descripcion = "Cobertura basica", Empresa = "Sancor", Tipo = 0, Enfermedades = enfermedades };
            Persona persona1 = new Persona() { Nombre = "Juan", Apellido = "Caceres", Ciudad = "Rafaela", DNI = "42700381", IngresosNetosAnuales = 10000, Cobertura = cobertura1, FechaNacimiento = DateTime.MinValue };
            Principal.Instance.CargarCliente(persona1);

            Console.WriteLine("ingrese un DNI: ");
            string dni = Console.ReadLine();
            Console.WriteLine("Ingrese un codigo de enfermedad: ");
            int codigoEnfermedad = int.Parse(Console.ReadLine());
            Console.WriteLine(Principal.Instance.CargarAtencion(dni, codigoEnfermedad));


            Console.ReadKey();
        }
    }
}
