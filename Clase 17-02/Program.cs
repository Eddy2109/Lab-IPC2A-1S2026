using System;
using System.Configuration.Assemblies;
using System.IO;

namespace Clase_17_02
{
    class Program
    {
        static void Main(string[] args)
        {
            // Manejo de Ficheros 
            EscribirFichero("archivo.txt", "Cadena nueva");

            LeerFichero("archivo.txt");

            AgregarFichero("archivo.txt", "\nNueva cadena de texto ingresada con AppendAllText");

            LeerFichero("archivo.txt");

            // Diccionario en C#
            Dictionary<int, string> listado = new Dictionary<int, string>();

            listado.Add(201801573, "Jose Isaac");
            listado.Add(202303332, "Jose Esau");
            listado.Add(202307821, "David Antonio");
            listado.Add(123456789, "usuario incorrecto");

            Console.WriteLine(listado[201801573]);

            foreach (var item in listado)
            {
                Console.WriteLine($"Carnet: {item.Key}, Nombre: {item.Value}");
            }

            listado.Remove(123456789);

            foreach (var item in listado)
            {
                Console.WriteLine($"Carnet: {item.Key}, Nombre: {item.Value}");
            }

            Console.WriteLine("Cantidad de elementos en el diccionario:");
            Console.WriteLine(listado.Count);

            //Buscar una coincidencia en el diccionario
            if (listado.TryGetValue(201801573, out string nombre))
            {
                Console.WriteLine($"El carnet existe en el diccionario. Nombre: {nombre}");
            }
            else
            {
                Console.WriteLine("El carnet no existe en el diccionario.");
            }

            listado.Clear();

            foreach (var item in listado)
            {
                Console.WriteLine($"Carnet: {item.Key}, Nombre: {item.Value}");
            }

            Console.WriteLine("------------------------------------------");

            // tuplas 
            var t1 = ("Carlos", 25, "Ingeniero");
            var t2 = (nombre: "Ana", edad: 30, profesion: "Doctora"); // manera recomendada

            Console.WriteLine($"nombre: {t1.Item1}, edad: {t1.Item2}, profesion: {t1.Item3}");
            Console.WriteLine($"nombre: {t2.nombre}, edad: {t2.edad}, profesion: {t2.profesion}");

            Console.WriteLine(t1);
            Console.WriteLine(t2);

            // repeticion de tuplas
            var t3 = t1;
            var t4 = t2;

            Console.WriteLine(t3);
            Console.WriteLine(t4.nombre);

            //buscar en tuplas
            if (t1.Item1 == "Carlos")
            {
                Console.WriteLine("La tupla t1 tiene el nombre Carlos");
            }
            else
            {
                Console.WriteLine("La tupla t1 no tiene el nombre Carlos");
            }

        }

        public static void EscribirFichero(string ruta, string texto)
        {
            File.WriteAllText(ruta, texto);
        }

        public static void LeerFichero(string ruta)
        {
            string contenido = File.ReadAllText(ruta);
            Console.WriteLine(contenido);
        }

        public static void AgregarFichero(string ruta, string texto)
        {
            File.AppendAllText(ruta, texto);
        }
    }
}