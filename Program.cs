using System;
using System.IO;
using System.Collections.Generic;
using System.Linq; 

namespace Organizador_de_equipos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Por favor introduzca la ruta de el archivo donde estan los estudiantes");
            string filepath1 = Console.ReadLine();
            Console.WriteLine("Por favor introduzca la ruta del acrchivo donde estan los temas");
            string filepath2 = Console.ReadLine();

            List<string> estudiantes = File.ReadAllLines(filepath1).ToList();
            List<string> temas = File.ReadAllLines(filepath2).ToList();

            if (estudiantes.Count > temas.Count )
            {
                Console.WriteLine("Que hay mas estudiantes que temas y por lo tanto no se puede hacer una distribucion equitativa");
                Console.WriteLine("Por favor introduzca mas temas");
                Console.WriteLine("El programa se va a cerrar");
                Environment.Exit(0);
            }
        }
    }
}
