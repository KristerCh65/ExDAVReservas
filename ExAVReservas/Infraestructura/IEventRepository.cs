using ExAVReservas.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExAVReservas.Infraestructura
{
    public interface IEventRepository
    {
        public List<CategoryEventDto> GetEvents();
        public CategoryEventDto GetEventId(int id);
        public CategoryEventDto UpdateEvent(CategoryEventDto eventDto);
        public CategoryEventDto DeleteEvent(CategoryEventDto eventDto);
        public CategoryEventDto AddEvent(CategoryEventDto eventDto);
    }
}
