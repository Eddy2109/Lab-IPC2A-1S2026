namespace EjemploP1
{
    class Nodo : Celula
    {
        public Nodo siguiente;
        public Nodo anterior;

        public int fila { get; set; }
        public int columa { get; set; }

        public Nodo(Estado estado, int fila, int columan) : base(estado)
        {
            this.fila = fila;
            this.columa = columa;
        }

        public override void cambiarEstado()
        {
            if (estado == Estado.Sana)
            {
                estado = Estado.Contagiada;
            }
            else
            {
                estado = Estado.Sana;
            }
        }
    }
}