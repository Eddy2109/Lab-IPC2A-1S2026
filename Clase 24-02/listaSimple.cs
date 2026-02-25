using System;
namespace Clase_24_02
{
    public class ListaSimple
    {
        private NodoSimple primero;

        public ListaSimple()
        {
            primero = null;
        }

        public void AgregarAlFinal(int valor)
        {
            NodoSimple nuevoNodo = new NodoSimple(valor);
            if (primero == null) //lista vacía
            {
                primero = nuevoNodo;
            }
            else
            {
                NodoSimple actual = primero; //apuntador temporal
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevoNodo;
            }
        }

        public void AgregarPorOrden(int valor)
        {
            NodoSimple nuevoNodo = new NodoSimple(valor);
            if (primero == null || primero.Valor >= nuevoNodo.Valor)
            {
                nuevoNodo.Siguiente = primero; //si la lista esta vacia nuevoNodo.Siguiente = null
                primero = nuevoNodo;
            }
            else
            {
                NodoSimple actual = primero; //apuntador temporal
                while (actual.Siguiente != null && actual.Siguiente.Valor < nuevoNodo.Valor)
                {
                    actual = actual.Siguiente;
                }
                nuevoNodo.Siguiente = actual.Siguiente;
                actual.Siguiente = nuevoNodo;
            }
        }

        public void Eliminar(int valor)
        {
            if (primero == null) return;

            if (primero.Valor == valor)
            {
                primero = primero.Siguiente;
                return;
            }

            NodoSimple actual = primero; //apuntador temporal
            while (actual.Siguiente != null && actual.Siguiente.Valor != valor)
            {
                actual = actual.Siguiente;
            }

            if (actual.Siguiente != null)
            {
                actual.Siguiente = actual.Siguiente.Siguiente;
            }
        }

        public void VaciarLista()
        {
            primero = null;
        }

        public void Imprimir()
        {
            NodoSimple actual = primero; //apuntador temporal
            while (actual != null)
            {
                Console.WriteLine(actual.Valor);
                actual = actual.Siguiente;
            }
        }
    }
}