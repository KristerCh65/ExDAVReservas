using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExAVReservas.Models
{
    public class FurnitureModel
    {
        [Key]
        public int IdFurniture { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }
    }
}
