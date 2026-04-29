using Microsoft.AspNetCore.Mvc;
using Semana13.Clase28_04.Models;
using Semana13.Clase28_04.Data;
using System.Runtime.ExceptionServices;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Semana13.Clase28_04.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClientesController : ControllerBase
    {
        //Aqui van a implementar sus endpoints para manejar las operaciones CRUD de sus clientes, utilizando la estructura que hayan declarado en ClienteStore.cs
        [HttpPost] //localhot:puerto/clientes
        public IActionResult CrearCliente([FromBody] Cliente cliente)
        {
            if (cliente == null)
                return BadRequest("Cliente vacío");

            // Expresiones regulares para validar NIT, email y fecha
            if (!Regex.IsMatch(cliente.Nit, @"^\d+-[\dA-Za-z]$"))
                return BadRequest("NIT inválido");

            if (!Regex.IsMatch(cliente.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return BadRequest("Correo inválido");

            if (!Regex.IsMatch(cliente.FechaNacimiento, @"^\d{2}/\d{2}/\d{4}$"))
                return BadRequest("Fecha inválida");

            // Almacer la información en sus estructuras de datos propias
            ClienteStore.Clientes.Add(cliente);

            return Ok("Cliente guardado");
        }

        [HttpGet] //localhost:puerto/clientes
        public IActionResult ObtenerClientes()
        {   
            if(ClienteStore.Clientes.Count == 0)
                return NotFound("No hay clientes registrados");
            return Ok(ClienteStore.Clientes);
        }

        [HttpGet("xml")] //localhost:puerto/clientes/xml
        public IActionResult ObtenerXML()
        {
            if(ClienteStore.Clientes.Count == 0)
                return NotFound("No hay clientes registrados");

            XElement xmlClientes = new XElement("Clientes",
                from cliente in ClienteStore.Clientes
                select new XElement("Cliente",
                    new XElement("Nit", cliente.Nit),
                    new XElement("Nombre", cliente.Nombre),
                    new XElement("Email", cliente.Email),
                    new XElement("FechaNacimiento", cliente.FechaNacimiento)
                )
            );

            return Ok(xmlClientes.ToString());
        }
    }
}