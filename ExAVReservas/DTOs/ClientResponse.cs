using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExAVReservas.DTOs
{
    public class ClientResponse
    {
        public int IdClient { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }
}
