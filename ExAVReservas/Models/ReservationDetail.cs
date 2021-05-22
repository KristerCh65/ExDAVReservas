using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExAVReservas.Models
{
    public class ReservationDetail
    {
        [Key]
        public int IdDetail { get; set; }

        public int IdReseration { get; set; }
        [ForeignKey("IdReservation")]
        public ReservationModel reservation { get; set; }

        public int IdFurniture { get; set; }
        [ForeignKey("IdFurniture")]
        public FurnitureModel furniture { get; set; }

        public List<FurnitureModel> furnitureList { get; set; }
    }
}
