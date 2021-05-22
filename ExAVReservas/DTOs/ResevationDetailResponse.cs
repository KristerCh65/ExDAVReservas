using ExAVReservas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExAVReservas.DTOs
{
    public class ResevationDetailResponse
    {
        public int IdDetail { get; set; }

        public int IdReseration { get; set; }

        public int IdFurniture { get; set; }

        public List<FurnitureModel> furnitureList { get; set; }
    }
}
