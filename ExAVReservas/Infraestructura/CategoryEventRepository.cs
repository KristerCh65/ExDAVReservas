using ExAVReservas.Data;
using ExAVReservas.DTOs;
using ExAVReservas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExAVReservas.Infraestructura
{
    public class CategoryEventRepository : IEventRepository
    {
        public readonly ExAPVRContext _context;

        public CategoryEventRepository(ExAPVRContext exContext)
        {
            _context = exContext;
        }

        public List<CategoryEventDto> GetEvents()
        {
            var categoryEvents = _context.eventModels.ToList();

            List<CategoryEventDto> eventDtos = new List<CategoryEventDto>();

            foreach (CategoryEventModel eventModel in categoryEvents)
            {
                eventDtos.Add(new CategoryEventDto
                {
                    IdEvent = eventModel.IdEvent,
                    Description = eventModel.Description,
                    Price = eventModel.Price

                });
            }

            return eventDtos;
        }

        public CategoryEventDto GetEventId(int id)
        {
            var category = _context.eventModels.FirstOrDefault(c => c.IdEvent == id);

            if (category == null)
            {
                return new CategoryEventDto
                {
                    MessageError = "Not found"
                };
            }

            return new CategoryEventDto
            {
                IdEvent = category.IdEvent,
                Description = category.Description,
                Price = category.Price
            };
        }

        public CategoryEventDto AddEvent(CategoryEventDto newCategory)
        {
            if (newCategory != null)
            {
                CategoryEventModel categoryEvent = new CategoryEventModel
                {
                    Description = newCategory.Description,
                    Price = newCategory.Price
                };

                _context.eventModels.Add(categoryEvent);
                _context.SaveChanges();
                newCategory.IdEvent = categoryEvent.IdEvent;

                return newCategory;
            }

            return new CategoryEventDto
            {
                MessageError = "Empy Event"
            };
        }

        public CategoryEventDto UpdateEvent(CategoryEventDto categoryEvent)
        {
            var register = _context.eventModels.FirstOrDefault(c => c.IdEvent == categoryEvent.IdEvent);

            if (register == null)
            {
                return new CategoryEventDto
                {
                    MessageError = "Not Found"
                };
            }

            register.IdEvent = categoryEvent.IdEvent;
            register.Description = categoryEvent.Description;
            register.Price = categoryEvent.Price;

            _context.SaveChanges();
            return categoryEvent;
        }

        public CategoryEventDto DeleteEvent(CategoryEventDto category)
        {
            var register = _context.eventModels.FirstOrDefault(c => c.IdEvent == category.IdEvent);

            if (register == null)
            {
                return new CategoryEventDto
                {
                    MessageError = "Not Found"
                };
            }

            _context.eventModels.Remove(register);
            _context.SaveChanges();
            return category;
        }

    }
}
