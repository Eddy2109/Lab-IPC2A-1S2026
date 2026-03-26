namespace Clase2403.Models
{
    public class Lista
    {
        public Nodo cabeza { get; set; }

        public Lista()
        {
            this.cabeza = null;
        }

        public void AgregarNodo(string nombre, int altura)
        {
            Nodo nuevoNodo = new Nodo(nombre, altura);
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
            }
            else
            {
                Nodo actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevoNodo;
            }
        }

        public Nodo GetCabeza()
        {
            return cabeza;
        }
    }
}