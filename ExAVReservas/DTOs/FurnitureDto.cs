using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExAVReservas.DTOs
{
    public class FurnitureDto
    {
        public int IdFurniture { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }
        public string MessageError { get; set; }
    }
}
