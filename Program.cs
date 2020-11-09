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
            Random random = new Random();
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

            Console.WriteLine("Introduzca la cantidad de equipos que desea: ");
            int nroDeEquipos = Convert.ToInt32(Console.ReadLine());

            int miembroPorEquipoSinSobrante = (estudiantes.Count / nroDeEquipos);
            int temasPorEquipoSinSobrante = (temas.Count / nroDeEquipos);
            int miembroSobrantes = (estudiantes.Count % nroDeEquipos);
            int temaSobrantes = (temas.Count % nroDeEquipos);

            Console.WriteLine($"Este es el numero de integrantes que deberia tener cada equipo: {miembroPorEquipoSinSobrante}");
            Console.WriteLine($"Este es el numero de temas que deberia tener cada equipo: {temasPorEquipoSinSobrante}");
            Console.WriteLine($"Este es el numero de personas que sobran: {miembroSobrantes}");
            Console.WriteLine($"Este es el numero de temas que sobran: {temaSobrantes}");


            estudiantes = RandomizarLista(random, estudiantes);
            temas = RandomizarLista(random, temas);

            List<string> equiposDistribuidos = new List<string>();

            for (int i = 0; i < nroDeEquipos; i++)
            {
                int miembrosPorEquipoReal = miembroPorEquipoSinSobrante;
                int temasPorEquipoReal = temasPorEquipoSinSobrante;
                if(random.Next(2) == 1 && miembroSobrantes > 0)
                {
                    miembrosPorEquipoReal++;
                    miembroSobrantes--;
                }
                else if((nroDeEquipos - miembroSobrantes) == i)
                {
                    miembrosPorEquipoReal++;
                    miembroSobrantes--;
                }

                if(random.Next(2) == 1 && temaSobrantes > 0)
                {
                    temasPorEquipoReal++;
                    temaSobrantes--;
                }
                else if((nroDeEquipos - temaSobrantes) == i)
                {
                    temasPorEquipoReal++;
                    temaSobrantes--;
                }

                equiposDistribuidos.Add($"Equipos {i+1} Integrantes: {miembrosPorEquipoReal} Temas: {temasPorEquipoReal}");
                equiposDistribuidos.Add("\tNombre de los Integrantes:");
                for (int j = 0; j < miembrosPorEquipoReal; j++)
                {
                    equiposDistribuidos.Add($"\t\t{estudiantes[0]}");
                    estudiantes.RemoveAt(0);
                }
                equiposDistribuidos.Add("\tTemas: ");
                for (int k = 0; k < temasPorEquipoReal; k++)
                {
                    equiposDistribuidos.Add($"\t\t{temas[0]}");
                    temas.RemoveAt(0);
                }
            }

                  
            foreach (var item in equiposDistribuidos)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("[1] Si desea crear un documento .txt que guarde los equipos pulse 1");
            Console.WriteLine("[SALIR] Escriba cualquier otra cosa");
            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case("1"):
                    File.WriteAllLines("grupos creados.txt", equiposDistribuidos);
                    break;
                default:
                    break;
            }

        }
        static List<string> RandomizarLista (Random random, List<string> lista)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                int tempRandom = random.Next(lista.Count);
                string temp = lista[i];
                lista[i] = lista[tempRandom];
                lista[tempRandom] = temp;
            }
            return lista;
        }
    }
    
}
