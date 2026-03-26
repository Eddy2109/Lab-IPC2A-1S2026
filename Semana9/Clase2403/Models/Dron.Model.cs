namespace Clase2403.Models
{
    public class Dron
    {
        public string Nombre { get; set;}
        public bool prendido {get; set;} //false = apagdo; true = encendido

        public int posicion { get; set; } // va a cambiar (subir o bajar)

        public int alturaMaxima { get; set; } // limite

        public Dron(string nombre, int alturaMaxima)
        {
            this.Nombre = nombre;
            this.prendido = false;
            this.alturaMaxima = alturaMaxima;
        }
    }
}