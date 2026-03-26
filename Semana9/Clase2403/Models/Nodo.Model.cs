namespace Clase2403.Models
{
    public class Nodo : Dron
    {
        public Nodo Siguiente { get; set; }

        public Nodo(string nombre, int alturaMax) : base(nombre, alturaMax)
        {
            this.Siguiente = null;
        }
    }
}