namespace Clase_24_02
{
    public class NodoSimple
    {
        public int Valor { get; set; }
        public NodoSimple Siguiente { get; set; } //apuntador al siguiente nodo

        public NodoSimple(int valor)
        {
            Valor = valor;
            Siguiente = null;
        }
    }    
}