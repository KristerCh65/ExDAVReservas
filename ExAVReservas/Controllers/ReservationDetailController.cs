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
    public class ReservationDetailController
    {
        private readonly IReservDetailRepository _reservDetailRepo;

        public ReservationDetailController(IReservDetailRepository detailRepository)
        {
            _reservDetailRepo = detailRepository;
        }

        [HttpGet]
        public List<ReservDetailDto> GetDetails()
        {
            List<ReservDetailDto> reservationDto = _reservDetailRepo.GetDetails().ToList();
            return reservationDto;
        }

        [HttpGet("{id}")]
        public ReservDetailDto GetDetailId(int id)
        {
            ReservDetailDto reservationDto = _reservDetailRepo.GetDetailId(id);
            return reservationDto;
        }

        [HttpPut("{id}")]
        public ReservDetailDto UpdateDetail(ReservDetailDto reservation)
        {
            ReservDetailDto reservationDto = _reservDetailRepo.UpdateDetail(reservation);
            return reservationDto;
        }

        [HttpDelete("{id}")]
        public ReservDetailDto DeleteDetail(ReservDetailDto reservation)
        {
            ReservDetailDto reservationDto = _reservDetailRepo.DeleteDetail(reservation);
            return reservationDto;
        }

        [HttpPost]
        public ReservDetailDto AddDetail(ReservDetailDto reservation)
        {
            ReservDetailDto reservationDto = _reservDetailRepo.AddDetail(reservation);
            return reservationDto;
        }
    }
}
