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
    public class CategoryEventController
    {
        private readonly IEventRepository _eventRepository;

        public CategoryEventController(IEventRepository category)
        {
            _eventRepository = category;
        }

        [HttpGet]
        public List<CategoryEventDto> GetEvents()
        {
            List<CategoryEventDto> categoryEvents = _eventRepository.GetEvents().ToList();
            return categoryEvents;
        }

        [HttpGet("{id}")]
        public CategoryEventDto GetEventId(int id)
        {
            CategoryEventDto categoryEvents = _eventRepository.GetEventId(id);
            return categoryEvents;
        }

        [HttpPut("{id}")]
        public CategoryEventDto UpdateEvent(CategoryEventDto eventDto)
        {
            CategoryEventDto categoryEvents = _eventRepository.UpdateEvent(eventDto);
            return categoryEvents;
        }

        [HttpDelete("{id}")]
        public CategoryEventDto DeleteEvent(CategoryEventDto eventDto)
        {
            CategoryEventDto categoryEvents = _eventRepository.DeleteEvent(eventDto);
            return categoryEvents;
        }

        [HttpPost]
        public CategoryEventDto AddEvent(CategoryEventDto eventDto)
        {
            CategoryEventDto categoryEvents = _eventRepository.AddEvent(eventDto);
            return categoryEvents;
        }
    }
}
