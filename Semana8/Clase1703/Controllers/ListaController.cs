using Microsoft.AspNetCore.Mvc;
using Clase1703.Models;

namespace Clase1703.Controllers
{
    public class ListaController : Controller
    {
        static ListaEnlazada lista = new ListaEnlazada();

        public IActionResult Index()
        {
            return View(lista);
        }

        [HttpPost]
        public IActionResult Insertar(string valor)
        {
            lista.Insertar(valor);
            return RedirectToAction("Index");
        }
    }
}