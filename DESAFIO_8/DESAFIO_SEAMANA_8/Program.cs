using System;
using System.Text.RegularExpressions;

namespace ExtraerCorreosElectronicos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Solicitar mensaje al usuario
            Console.WriteLine("Ingrese el mensaje a analizar:");
            string mensaje = Console.ReadLine();

            // Extraer correos electrónicos
            List<string> correosEncontrados = ExtraerCorreosElectronicos(mensaje);

            // Extraer números de teléfono
            List<string> telefonosEncontrados = ExtraerTelefonos(mensaje);

            // Mostrar resultados
            if (correosEncontrados.Count > 0)
            {
                Console.WriteLine("\nCorreos electrónicos encontrados:");
                foreach (string correo in correosEncontrados)
                {
                    Console.WriteLine(correo);
                }
            }
            else
            {
                Console.WriteLine("\nNo se encontraron correos electrónicos en el mensaje.");
            }

            if (telefonosEncontrados.Count > 0)
            {
                Console.WriteLine("\nNúmeros de teléfono encontrados:");
                foreach (string telefono in telefonosEncontrados)
                {
                    Console.WriteLine(telefono);
                }
            }
            else
            {
                Console.WriteLine("\nNo se encontraron números de teléfono en el mensaje.");
            }
        }

        static List<string> ExtraerCorreosElectronicos(string texto)
        {
            // Expresión regular para validar direcciones de correo electrónico
            string expresionRegularCorreo = @"[\w\.-]+@[\w\.-]+\.\w{2,}";

            // Extraer correos electrónicos del texto
            List<string> correos = new List<string>();
            MatchCollection coincidenciasCorreo = Regex.Matches(texto, expresionRegularCorreo);
            foreach (Match coincidencia in coincidenciasCorreo)
            {
                correos.Add(coincidencia.Value);
            }

            return correos;
        }

        static List<string> ExtraerTelefonos(string texto)
        {
            // Expresión regular para validar números de teléfono (formato básico)
            string expresionRegularTelefono = @"[\d-+\(\)]+"; // Ejemplo: 123-456-7890, (123) 456-7890, +1 234 567 890

            // Extraer números de teléfono del texto
            List<string> telefonos = new List<string>();
            MatchCollection coincidenciasTelefono = Regex.Matches(texto, expresionRegularTelefono);
            foreach (Match coincidencia in coincidenciasTelefono)
            {
                telefonos.Add(coincidencia.Value);
            }

            return telefonos;
        }
    }
}

