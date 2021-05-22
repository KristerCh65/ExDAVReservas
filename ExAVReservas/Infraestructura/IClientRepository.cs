using ExAVReservas.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExAVReservas.Infraestructura
{
    public interface IClientRepository
    {
        public List<ClientDto> GetClients();
        public ClientDto GetClienteId(int id);
        public ClientDto UpdateClient(ClientDto client);
        public ClientDto DeleteClient(ClientDto client);
        public ClientDto AddClient(ClientDto client);
    }
}
