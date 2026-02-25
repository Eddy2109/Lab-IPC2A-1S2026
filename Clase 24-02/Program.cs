using System;
namespace Clase_24_02
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaSimple lista1 = new ListaSimple();

            lista1.AgregarAlFinal(1);
            lista1.AgregarAlFinal(3);
            lista1.AgregarAlFinal(5);

            lista1.Imprimir();

            Console.WriteLine("Lista después de agregar al final:");
            lista1.AgregarPorOrden(4);
            lista1.AgregarPorOrden(2);

            lista1.Imprimir();

            Console.WriteLine("Eliminando 1:");
            lista1.Eliminar(1);
            lista1.Imprimir();
            Console.WriteLine("Eliminando 4:");
            lista1.Eliminar(4);

            lista1.Imprimir();

            Console.WriteLine("Vaciar lista:");
            lista1.VaciarLista();
            lista1.Imprimir();

            Console.WriteLine("Agregando al final después de vaciar:");
            lista1.AgregarAlFinal(10);
            lista1.Imprimir();


            Console.WriteLine("\nLista Doble:");
            ListaDoble lista2 = new ListaDoble();
            lista2.AgregarAlFinal(1);
            lista2.AgregarAlFinal(3);
            lista2.AgregarAlFinal(5);
            lista2.Imprimir();

            Console.WriteLine("Lista después de agregar al final:");
            lista2.AgregarPorOrden(4);
            lista2.AgregarPorOrden(2);
            lista2.Imprimir();

            Console.WriteLine("Eliminando 1:");
            lista2.Eliminar(1);
            lista2.Imprimir();
            Console.WriteLine("Eliminando 4:");
            lista2.Eliminar(4);
            lista2.Imprimir();

            Console.WriteLine("Vaciar lista:");
            lista2.VaciarLista();
            lista2.Imprimir();
            
        }
    }
}