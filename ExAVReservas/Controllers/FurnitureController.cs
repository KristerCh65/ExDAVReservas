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
    public class FurnitureController
    {
        private readonly  IFurnitureRepository _furnitureRepository;

        public FurnitureController(IFurnitureRepository furniture)
        {
            _furnitureRepository = furniture;
        }

        [HttpGet]
        public List<FurnitureDto> GetFournitures()
        {
            List<FurnitureDto> furnitureDtos = _furnitureRepository.GetFournitures().ToList();
            return furnitureDtos;
        }

        [HttpGet("{id}")]
        public FurnitureDto GetFournitureId(int id)
        {
            FurnitureDto furnitureDtos = _furnitureRepository.GetFournitureId(id);
            return furnitureDtos;
        }

        [HttpPut("{id}")]
        public FurnitureDto UpdateFurniture(FurnitureDto furniture)
        {
            FurnitureDto furnitureDtos = _furnitureRepository.UpdateFurniture(furniture);
            return furnitureDtos;
        }

        [HttpDelete("{id}")]
        public FurnitureDto DeleteFurniture(FurnitureDto furniture)
        {
            FurnitureDto furnitureDtos = _furnitureRepository.DeleteFurniture(furniture);
            return furnitureDtos;
        }

        [HttpPost]
        public FurnitureDto AddFurniture(FurnitureDto furniture)
        {
            FurnitureDto furnitureDtos = _furnitureRepository.AddFurniture(furniture);
            return furnitureDtos;
        }


    }
}
