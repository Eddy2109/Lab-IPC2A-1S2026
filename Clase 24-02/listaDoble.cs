using System;
namespace Clase_24_02
{
    public class ListaDoble
    {
        private NodoDoble primero;
        private NodoDoble ultimo;

        public ListaDoble()
        {
            primero = null;
            ultimo = null;
        }

        public void AgregarAlFinal(int valor)
        {
            NodoDoble nuevoNodo = new NodoDoble(valor);
            if (primero == null && ultimo == null) //lista vacía
            {
                primero = nuevoNodo;
                ultimo = nuevoNodo;
            }
            else
            {
                ultimo.Siguiente = nuevoNodo;
                nuevoNodo.Anterior = ultimo;
                ultimo = nuevoNodo;
            }
        }

        public void AgregarPorOrden(int valor)
        {
            NodoDoble nuevoNodo = new NodoDoble(valor);
            if (primero == null && ultimo == null) //lista vacía
            {
                primero = nuevoNodo;
                ultimo = nuevoNodo;
            }
            else
            {
                NodoDoble actual = primero; //apuntador temporal
                while (actual.Siguiente != null && actual.Siguiente.Valor < nuevoNodo.Valor)
                {
                    actual = actual.Siguiente;
                }
                nuevoNodo.Siguiente = actual.Siguiente;
                nuevoNodo.Anterior = actual;
                if (actual.Siguiente != null)                {
                    actual.Siguiente.Anterior = nuevoNodo;
                }
                else
                {
                    ultimo = nuevoNodo; //nuevo nodo es el último
                }
                actual.Siguiente = nuevoNodo;
            }
        }

        public void Eliminar(int valor)
        {
            if (primero == null && ultimo == null) return;

            if (primero.Valor == valor)
            {
                primero = primero.Siguiente;
                primero.Anterior = null;
                return;
            }

            NodoDoble actual = primero; //apuntador temporal
            while (actual.Siguiente != null && actual.Siguiente.Valor != valor)
            {
                actual = actual.Siguiente;
            }

            if (actual.Siguiente != null)
            {
                actual.Siguiente = actual.Siguiente.Siguiente;
                if (actual.Siguiente != null)
                {
                    actual.Siguiente.Anterior = actual;
                }
                else
                {
                    ultimo = actual; //actual es el último
                }
            }
        }

        public void VaciarLista()
        {
            primero = null;
            ultimo = null;
        }

        public void Imprimir()
        {
            NodoDoble actual = primero; //apuntador temporal
            while (actual != null)
            {
                Console.WriteLine(actual.Valor);
                actual = actual.Siguiente; 
            }
        }
    }
}