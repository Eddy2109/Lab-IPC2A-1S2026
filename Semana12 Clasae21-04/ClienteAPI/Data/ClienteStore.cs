using ClienteAPI.Models;

namespace ClienteAPI.Data
{
    // Esta clase actúa como un almacén de datos en memoria para los clientes
    public static class ClienteStore
    {
        public static List<Cliente> Clientes { get; set; } = new List<Cliente>();
    }
}