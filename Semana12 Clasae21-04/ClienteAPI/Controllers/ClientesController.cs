using Microsoft.AspNetCore.Mvc;
using ClienteAPI.Models;
using ClienteAPI.Data;

namespace ClienteAPI.Controllers
{
    [ApiController]
    [Route("clientes")] //localhost:5026/clientes
    public class ClientesController : ControllerBase
    {
        [HttpPost]
        public IActionResult PostClientes(ClienteRequest request)
        {
            if (request == null || request.Clientes == null || request.Clientes.Count == 0)
            {
                return BadRequest("La lista no contiene clientes.");
            }

            foreach (var cliente in request.Clientes)
            {   
                // valido campos que no esten vacios
                if (string.IsNullOrEmpty(cliente.NIT) || string.IsNullOrEmpty(cliente.Nombre))
                {
                    return BadRequest("Cada cliente debe tener un NIT y un Nombre válidos.");
                }

                // Agregar el cliente a la lista estática
                ClienteStore.Clientes.Add(cliente);
            }

            return Ok("Clientes agregados exitosamente.");
        }

        [HttpGet]  
        public IActionResult GetClientes()
        {   
            // validar si la lista esta vacia, enviar NotFound
            if (ClienteStore.Clientes.Count == 0)
            {
                return NotFound("No hay clientes registrados.");
            }

            // Devolver la lista de clientes
            return Ok(ClienteStore.Clientes);
        }

        [HttpGet("{nit}")] //localhost:5026/clientes/{nit} 
        public IActionResult GetClienteByNIT(string nit)
        {
            var cliente = ClienteStore.Clientes.FirstOrDefault(c => c.NIT == nit);
            if (cliente == null)
            {
                return NotFound($"No se encontró un cliente con NIT: {nit}");
            }
            return Ok(cliente);
        }
    }
    
}

