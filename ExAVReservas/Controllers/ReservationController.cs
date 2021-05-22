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
    public class ReservationController
    {
        private readonly IResevationRepositorycs _resevationRepository;

        public ReservationController(IResevationRepositorycs resevationRepository)
        {
            _resevationRepository = resevationRepository;
        }

        [HttpGet]
        public List<ReservationDtocs> GetReservations()
        {
            List<ReservationDtocs> reservationDto = _resevationRepository.GetReservations().ToList();
            return reservationDto;
        }

        [HttpGet("{id}")]
        public ReservationDtocs GetReservationId(int id)
        {
            ReservationDtocs reservationDto = _resevationRepository.GetReservationId(id);
            return reservationDto;
        }

        [HttpPut("{id}")]
        public ReservationDtocs UpdateReservation(ReservationDtocs reservation)
        {
            ReservationDtocs reservationDto = _resevationRepository.UpdateReservation(reservation);
            return reservationDto;
        }

        [HttpDelete("{id}")]
        public ReservationDtocs DeleteReservation(ReservationDtocs reservation)
        {
            ReservationDtocs reservationDto = _resevationRepository.DeleteReservation(reservation);
            return reservationDto;
        }

        [HttpPost]
        public ReservationDtocs AddClient(ReservationDtocs reservation)
        {
            ReservationDtocs reservationDto = _resevationRepository.AddReservation(reservation);
            return reservationDto;
        }
    }
}
