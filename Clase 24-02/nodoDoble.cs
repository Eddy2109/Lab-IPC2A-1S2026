namespace Clase_24_02
{
    public class NodoDoble
    {
        public int Valor { get; set; }
        public NodoDoble Siguiente { get; set; } //apuntador al siguiente nodo
        public NodoDoble Anterior { get; set; } //apuntador al nodo anterior

        public NodoDoble(int valor)
        {
            Valor = valor;
            Siguiente = null;
            Anterior = null;
        }
    }    
}