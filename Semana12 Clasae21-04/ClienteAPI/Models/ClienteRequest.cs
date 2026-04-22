using System.Collections.Generic;

namespace ClienteAPI.Models
{
    // Se usa para las peticiones HTTP POST, para recibir una lista de clientes
    public class ClienteRequest
    {
        public List<Cliente> Clientes { get; set; }
    }
}