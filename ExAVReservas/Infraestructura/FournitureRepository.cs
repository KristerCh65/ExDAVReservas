using ExAVReservas.Data;
using ExAVReservas.DTOs;
using ExAVReservas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExAVReservas.Infraestructura
{
    public class FournitureRepository : IFurnitureRepository
    {
        public readonly ExAPVRContext _context;

        public FournitureRepository(ExAPVRContext exContext)
        {
            _context = exContext;
        }

        public List<FurnitureDto> GetFournitures()
        {
            var mobil = _context.furnitureModels.ToList();

            List<FurnitureDto> furnitureDtos = new List<FurnitureDto>();

            foreach (FurnitureModel furniture in mobil)
            {
                furnitureDtos.Add(new FurnitureDto
                {
                    IdFurniture = furniture.IdFurniture,
                    Description = furniture.Description,
                    IsActive = furniture.IsActive,
                    Price = furniture.Price
                    
                });
            }

            return furnitureDtos;
        }

        public FurnitureDto GetFournitureId(int id)
        {
            var furniture = _context.furnitureModels.FirstOrDefault(c => c.IdFurniture == id);

            if (furniture == null)
            {
                return new FurnitureDto
                {
                    MessageError = "Not found"
                };
            }

            return new FurnitureDto
            {
                IdFurniture = furniture.IdFurniture,
                Description = furniture.Description,
                IsActive = furniture.IsActive,
                Price = furniture.Price

            };
        }

        public FurnitureDto AddFurniture(FurnitureDto newMobi)
        {
            if (newMobi != null)
            {
                FurnitureModel furniture = new FurnitureModel
                {
                    Description = newMobi.Description,
                    IsActive = newMobi.IsActive,
                    Price = newMobi.Price
                };

                _context.furnitureModels.Add(furniture);
                _context.SaveChanges();
                newMobi.IdFurniture = furniture.IdFurniture;

                return newMobi;
            }

            return new FurnitureDto
            {
                MessageError = "Empy client"
            };
        }

        public FurnitureDto UpdateFurniture(FurnitureDto newMobi)
        {
            var register = _context.furnitureModels.FirstOrDefault(c => c.IdFurniture == newMobi.IdFurniture);

            if (register == null)
            {
                return new FurnitureDto
                {
                    MessageError = "Not Found"
                };
            }

            register.IdFurniture = newMobi.IdFurniture;
            register.Description = newMobi.Description;
            register.IsActive = newMobi.IsActive;
            register.Price = newMobi.Price;

            _context.SaveChanges();
            return newMobi;
        }

        public FurnitureDto DeleteFurniture(FurnitureDto furniture)
        {
            var register = _context.furnitureModels.FirstOrDefault(c => c.IdFurniture == furniture.IdFurniture);

            if (register == null)
            {
                return new FurnitureDto
                {
                    MessageError = "Not Found"
                };
            }

            _context.furnitureModels.Remove(register);
            _context.SaveChanges();
            return furniture;
        }
    }
}
