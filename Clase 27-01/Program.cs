using System;

namespace Clase_27_01
{
    class Program
    {   
        /*
        Funcion con retorno de valor
        importante : el tipo de dato de retorno debe coincidir con el tipo de dato declarado en la funcion
        */
        static int Sumar()
        {
            Console.WriteLine("Ingrese el primer número:");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el segundo número:");
            int num2 = int.Parse(Console.ReadLine());
            return num1 + num2;
        }

        /*
        Funcion sin retorno de valor
        importante : el tipo de dato void indica que la funcion no retorna ningun valor
        */
        static void Restar(int a, int b)
        {
            Console.WriteLine("El restualdo es:" + (a-b));
        }

        static void Main(string[] args)
        {
            // Imprimir en consola, aca no importa los espacios o caracteres especiales
            Console.WriteLine("Hello World!, 27/01/2026 | @");

            // // declaraciones de variables y tipos de datos
            int numero = 10;
            double numeroDecimal = 5.5;
            string texto = "Este es un texto de ejemplo.";
            bool varBooleana = false;
            char caracter = 'A';
            int? var1 = null;

            // como imprimir variables en consola de diferentes formas
            Console.WriteLine($"Número: {numero}");
            Console.WriteLine("Variable con null: " + var1);
            Console.WriteLine("multiplicacion: " + numero * 2);

            // identificadores de variables,
            // puede iniciar con un letra o un guion bajo
            // no puede iniciar con un numero o caracter especial
            int variable = 2;
            int _variable = 2;
            int VARIABLE = 2;
            // errores: int 5_variable =2;

            // condiciones, se puede agregar else if para multiples condiciones pero solo un else al final
            if (variable > 5)
            {
                Console.WriteLine("La variable es mayor que 5.");
            }
            else if (variable == 3)
            {
                Console.WriteLine("La variable es igual a 3.");
            }
            else
            {
                Console.WriteLine("La variable es menor o igual a 5.");
            }

            // switch case
            Console.WriteLine("Ingrese un valor:");
            Console.WriteLine("1. Saludar");
            Console.WriteLine("2. Sumar dos números");
            Console.WriteLine("3. Restar números");
            Console.WriteLine("4. Salir");

            // el ReadLine siempre devuelve un string y nos sirve para capturar datos por consola
            string input = Console.ReadLine(); 

            int inputInt = int.Parse(input); //conversion de string a int
            switch (inputInt)
            {
                case 1:
                    Console.WriteLine("¡Hola! Bienvenido al programa.");
                    break;
                case 2:
                    // llamado a la funcion Sumar y captura del valor retornado
                    int result = Sumar();
                    Console.WriteLine("La suma es:" + result);
                    break;
                case 3:
                    Console.WriteLine("Ingrese el primer número:");
                    int resta1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese el segundo número:");
                    int resta2 = int.Parse(Console.ReadLine());
                    // llamado a la funcion Restar, esta no devuelve un valor
                    Restar(resta1, resta2);
                    break;
                case 4:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("La variable no es ni 1 ni 2.");
                    break;
            }

            // bucles

            for(int i = 0; i<=10; i++)
            {
                Console.WriteLine(i);
            }

            int[] numeros = {1,2,3,4,5};
            foreach(int i in numeros)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("ingrese un numero");
            string input2 = Console.ReadLine();
            int num = int.Parse(input2);
            while (num < 20)
            {      
                Console.WriteLine(num);
                num++;
            }
            
        }
    }
}