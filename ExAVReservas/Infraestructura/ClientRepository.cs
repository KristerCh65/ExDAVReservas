using ExAVReservas.Data;
using ExAVReservas.DTOs;
using ExAVReservas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExAVReservas.Infraestructura
{
    public class ClientRepository : IClientRepository
    {
        public readonly ExAPVRContext _context;

        public ClientRepository( ExAPVRContext exContext)
        {
            _context = exContext;
        }

        public List<ClientDto> GetClients()
        {
            var clients = _context.clientModels.ToList();

            List<ClientDto> clientDtos = new List<ClientDto>();

            foreach (ClientModel clientes in clients)
            {
                clientDtos.Add(new ClientDto
                {
                    IdClient = clientes.IdClient,
                    Name = clientes.Name,
                    Phone = clientes.Phone,
                    Email = clientes.Email,
                    Address = clientes.Address,
                    Status = clientes.Status,
                    Age = clientes.Age
                });
            }

            return clientDtos;
        }

        public ClientDto GetClienteId(int id)
        {
            var client = _context.clientModels.FirstOrDefault(c => c.IdClient == id);

            if (client == null)
            {
                return new ClientDto
                {
                    MessageError = "Not found"
                };
            }

            return new ClientDto
            {
                IdClient = client.IdClient,
                Name = client.Name,
                Phone = client.Phone,
                Email = client.Email,
                Address = client.Address,
                Status = client.Status,
                Age = client.Age
            };
        }

        public ClientDto AddClient(ClientDto newClient)
        {
            if(newClient != null)
            {
                ClientModel client = new ClientModel
                {
                    Name = newClient.Name,
                    Phone = newClient.Phone,
                    Email = newClient.Email,
                    Address = newClient.Address,
                    Status = newClient.Status,
                    Age = newClient.Age
                };

                _context.clientModels.Add(client);
                _context.SaveChanges();
                newClient.IdClient = client.IdClient;

                return newClient;
            }

            return new ClientDto
            {
                MessageError = "Empy client"
            };
        }

        public ClientDto UpdateClient(ClientDto newClient)
        {
            var register = _context.clientModels.FirstOrDefault(c => c.IdClient == newClient.IdClient);

            if(register == null)
            {
                return new ClientDto
                {
                    MessageError = "Not Found"
                };
            }

            register.IdClient = newClient.IdClient;
            register.Name = newClient.Name;
            register.Address = newClient.Address;
            register.Status = newClient.Status;
            register.Phone = newClient.Phone;
            register.Age = newClient.Age;
            register.Email = newClient.Email;

            _context.SaveChanges();
            return newClient;
        }

        public ClientDto DeleteClient(ClientDto client)
        {
            var register = _context.clientModels.FirstOrDefault(c => c.IdClient == client.IdClient);

            if (register == null)
            {
                return new ClientDto
                {
                    MessageError = "Not Found"
                };
            }

            _context.clientModels.Remove(register);
            _context.SaveChanges();
            return client;
        }
    }
}
