using System;
namespace EjemploGit
{
    // Abstraccion
    public abstract class Vehiculo
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }

        // 2. ENCAPSULAMIENTO
        private int _gasolina;

        // constructor
        public Vehiculo(string marca, string modelo)
        {
            Marca = marca;
            Modelo = modelo;

        }

        // Método público para modificar el estado privado (con validación)
        public void CargarGasolina(int litros)
        {
            if (litros > 0)
            {
                _gasolina += litros;
                // Console.WriteLine($"-> Llenando tanque del {Marca}. Gasolina actual: {_gasolina}L");
            }
            else
            {
                Console.WriteLine("-> Error: No puedes cargar gasolina negativa.");
            }
        }

        public void verGasolina()
        {
            Console.WriteLine($"-> Gasolina actual en el {Marca}: {_gasolina}L");
        }

        // 4. POLIMORFISMO
        public abstract void Arrancar();


    }

    // 3. HERENCIA
    public class Coche : Vehiculo
    {
        string color ;
        public Coche(string marca, string modelo, string color) : base(marca, modelo) {
            this.color = color;
        }


        public override void Arrancar()
        {
            Console.WriteLine($"[{Marca} {Modelo}] Gira la llave... ¡BRUM BRUM! (Ruido de motor V8)");
        }
    }

    // 3. HERENCIA
    public class Moto : Vehiculo
    {
        public Moto(string marca, string modelo) : base(marca, modelo) { }

        // 4. POLIMORFISMO (Parte 2: La implementación)
        public override void Arrancar()
        {
            Console.WriteLine($"[{Marca} {Modelo}] Patada al pedal... ¡RATATA-TA! (Ruido agudo)");
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Coche miCoche = new Coche("Toyota", "Corolla", "Rojo");
            Moto miMoto = new Moto("Honda", "CBR500R");

            // metodos heredades de la clase padre vehiculo
            miCoche.CargarGasolina(40);
            miMoto.CargarGasolina(10);
            miCoche.CargarGasolina(40);

            miCoche.verGasolina();
            miMoto.verGasolina();

            miCoche.Arrancar(); // Llama al método específico de Coche
            miMoto.Arrancar();  // Llama al método específico de Moto
        }
    }
}