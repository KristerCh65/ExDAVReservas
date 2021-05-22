using ExAVReservas.DTOs;
using ExAVReservas.Infraestructura;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExAVReservas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepo;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepo = clientRepository;
        }

        [HttpGet]
        public List<ClientDto> GetClients()
        {
            List<ClientDto> clientDtos = _clientRepo.GetClients().ToList();
            return clientDtos;
        }

        [HttpGet("{id}")]
        public ClientDto GetClienteId(int id)
        {
            ClientDto clientDtos = _clientRepo.GetClienteId(id);
            return clientDtos;
        }

        [HttpPut("{id}")]
        public ClientDto UpdateClient(ClientDto  client)
        {
            ClientDto clientDtos = _clientRepo.UpdateClient(client);
            return clientDtos;
        }

        [HttpDelete("{id}")]
        public ClientDto DeleteClient(ClientDto client)
        {
            ClientDto clientDtos = _clientRepo.DeleteClient(client);
            return clientDtos;
        }

        [HttpPost]
        public ClientDto AddClient(ClientDto client)
        {
            ClientDto clientDtos = _clientRepo.AddClient(client);
            return clientDtos;
        }

    }
}
