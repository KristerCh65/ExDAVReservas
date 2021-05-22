using ExAVReservas.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExAVReservas.Infraestructura
{
    public interface IFurnitureRepository
    {
        public List<FurnitureDto> GetFournitures();
        public FurnitureDto GetFournitureId(int id);
        public FurnitureDto UpdateFurniture(FurnitureDto furniture);
        public FurnitureDto DeleteFurniture(FurnitureDto furniture);
        public FurnitureDto AddFurniture(FurnitureDto furniture);
    }
}
