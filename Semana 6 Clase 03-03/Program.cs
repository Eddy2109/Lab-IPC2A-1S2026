using System;
namespace Semana_6
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaDoble lista1 = new ListaDoble();
            lista1.AgregarAlFinal(1);
            lista1.AgregarAlFinal(3);
            lista1.AgregarAlFinal(5);

            lista1.Graficar();

            ListaCircular lista2 = new ListaCircular();
            lista2.AgregarAlFinal(10);
            lista2.AgregarAlFinal(20);
            lista2.AgregarAlFinal(30);

            lista2.Graficar();
        }
    }
}