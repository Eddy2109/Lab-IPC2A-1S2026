namespace Clase1703.Models
{
     public class ListaEnlazada
    {
        public Nodo Cabeza { get; set; }

        public void Insertar(string valor)
        {
            Nodo nuevo = new Nodo { Valor = valor };

            if (Cabeza == null)
            {
                Cabeza = nuevo;
            }
            else
            {
                Nodo actual = Cabeza;

                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }

                actual.Siguiente = nuevo;
            }
        }
    }
}