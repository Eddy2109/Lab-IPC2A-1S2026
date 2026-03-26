using Microsoft.AspNetCore.Mvc;
using Clase2403.Models;

namespace Clase2403.Controllers
{
    public class ListaController : Controller
    {
        static Lista sistemaDromes = new Lista();

        public IActionResult Index()
        {
            return View(sistemaDromes);
        }

        [HttpPost]
        public IActionResult Agregar(string nombre, int alturaMax)
        {
            sistemaDromes.AgregarNodo(nombre, alturaMax);
            return RedirectToAction("Index");
        }

        // retornar la cabeza de la lista para mostrar los drones
        public IActionResult MostrarDrones()
        {
            return View(sistemaDromes.GetCabeza());
        }
    }
}