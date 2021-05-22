using ExAVReservas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExAVReservas.DTOs
{
    public class ReservationResponse
    {
        public int IdReservation { get; set; }
        public DateTime DateDue { get; set; }
        public int IdClient { get; set; }
        public int IdEvent { get; set; }
        public List<ClientModel> clientList { get; set; }
        public List<CategoryEventModel> categoryEvents { get; set; }
    }
}
