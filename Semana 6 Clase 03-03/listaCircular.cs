using System;
using System.IO;           
using System.Diagnostics;
using System.Text;

namespace Semana_6
{
    public class ListaCircular
    {
        private NodoDoble primero;
        private NodoDoble ultimo;

        public ListaCircular()
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

                ultimo.Siguiente = primero; // Apunta al primero para cerrar el círculo
                primero.Anterior = ultimo; // Apunta al último para cerrar el círculo
            }
            else
            {
                ultimo.Siguiente = nuevoNodo;
                nuevoNodo.Anterior = ultimo;
                ultimo = nuevoNodo;

                ultimo.Siguiente = primero; // Cerrar el círculo
                primero.Anterior = ultimo; // Cerrar el círculo
            }
        }

        public void Eliminar(int valor)
        {
            if (primero == null && ultimo == null) return;

            if (primero.Valor == valor)
            {
                primero = primero.Siguiente;
                primero.Anterior = ultimo; // Actualizar el anterior del nuevo primero
                ultimo.Siguiente = primero; // Actualizar el siguiente del último
                return;
            }

            NodoDoble actual = primero; //apuntador temporal
            while (actual.Siguiente != primero) // Recorrer hasta volver al inicio
            {
                if (actual.Siguiente.Valor == valor)
                {
                    actual.Siguiente = actual.Siguiente.Siguiente;
                    actual.Siguiente.Anterior = actual; // Actualizar el anterior del nuevo siguiente
                    if (actual.Siguiente == primero) // Si eliminamos el último nodo
                    {
                        ultimo = actual; // Actualizar el último
                    }
                    return;
                }
                actual = actual.Siguiente;
            }
            Console.WriteLine("Valor no encontrado en la lista circular.");
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

            string dotFilePath = "lista_circular.dot";
            string pngFilePath = "lista_circular.png";

            StringBuilder dot = new StringBuilder();
            dot.AppendLine("digraph ListaCircular {");
            dot.AppendLine("  rankdir=LR;"); // Orientación horizontal
            dot.AppendLine("  node [shape=box, style=filled, fillcolor=lightgray];");

            NodoDoble actual = primero;
            bool bandera = true;

            while (bandera) 
            {
                string idNodo = "nodo" + Math.Abs(actual.GetHashCode());
                dot.AppendLine($"  {idNodo} [label=\"Valor: {actual.Valor}\"];");
                if (actual.Valor == ultimo.Valor) bandera=false;
                actual = actual.Siguiente;
            }

            actual = primero;
            bandera = true;
            while (bandera)
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
                if (actual.Valor == ultimo.Valor) bandera=false;
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