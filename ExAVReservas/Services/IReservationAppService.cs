using ExAVReservas.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExAVReservas.Services
{
    public interface IReservationAppService
    {
        public List<ReservationDtocs> GetReservations(ReservationResponse reservation);
        public ReservationDtocs GetReservationId(ReservationResponse reservation);
        public ReservationDtocs GetReservationClietntId(ReservationResponse reservation);
        public ReservationDtocs UpdateReservation(ReservationResponse reservation);
        public ReservationDtocs DeleteReservation(ReservationResponse reservation);
        public ReservationDtocs AddReservation(ReservationResponse reservation);
    }
}
