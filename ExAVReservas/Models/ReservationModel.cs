using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExAVReservas.Models
{
    public class ReservationModel
    {
        [Key]
        public int IdReservation { get; set; }
        public DateTime DateDue { get; set; }

        public int IdClient { get; set; }
        [ForeignKey("IdCliente")]
        public ClientModel client { get; set; }

        public int IdEvent { get; set; }
        [ForeignKey("IdEvent")]
        public CategoryEventModel categoryEvent { get; set; }

        public List<ClientModel> clientList { get; set; }
        public List<CategoryEventModel> categoryList { get; set; }

    }
}
