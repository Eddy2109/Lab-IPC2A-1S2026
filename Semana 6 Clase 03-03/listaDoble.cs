using System;
using System.IO;           
using System.Diagnostics;
using System.Text;

namespace Semana_6
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

        public void Graficar()
        {
            if (primero == null)
            {
                Console.WriteLine("La lista está vacía. No hay nada que graficar.");
                return;
            }

            string dotFilePath = "lista_doble.dot";
            string pngFilePath = "lista_doble.png";

            StringBuilder dot = new StringBuilder();
            dot.AppendLine("digraph ListaDoble {");
            dot.AppendLine("  rankdir=LR;"); // Orientación horizontal
            dot.AppendLine("  node [shape=box, style=filled, fillcolor=lightgray];");

            // Agremamos los nodos
            NodoDoble actual = primero;

            while (actual != null)
            {
                string idNodo = "nodo" + Math.Abs(actual.GetHashCode()); //nodo1, nodo2, nodo3, nodo52158652
                dot.AppendLine($"  {idNodo} [label=\"Valor: {actual.Valor}\"];");
                actual = actual.Siguiente;
            }

            // conectar los nodos
            actual = primero;
            while (actual != null)
            {
                string idActual = "nodo" + Math.Abs(actual.GetHashCode());

                if (actual.Siguiente != null)
                {
                    string idSiguiente = "nodo" + Math.Abs(actual.Siguiente.GetHashCode());
                    dot.AppendLine($"  {idActual} -> {idSiguiente} [color=blue, label=\"Sig\"];");
                }

                if (actual.Anterior != null)
                {
                    string idAnterior = "nodo" + Math.Abs(actual.Anterior.GetHashCode());
                    dot.AppendLine($"  {idActual} -> {idAnterior} [color=red, style=dashed, label=\"Ant\"];");
                }

                actual = actual.Siguiente;
            }

            dot.AppendLine("}");

            File.WriteAllText(dotFilePath, dot.ToString());

            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "dot",
                    Arguments = $"-Tpng {dotFilePath} -o {pngFilePath}",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(startInfo))
                {
                    process.WaitForExit();
                    if (process.ExitCode == 0)
                    {
                        Console.WriteLine($"¡Gráfica generada exitosamente en: {pngFilePath}!");
                        Process.Start(new ProcessStartInfo(pngFilePath) { UseShellExecute = true });
                    }
                    else
                    {
                        Console.WriteLine("Error en Graphviz: " + process.StandardError.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se pudo ejecutar Graphviz. " + ex.Message);
            }
        }

    }
}