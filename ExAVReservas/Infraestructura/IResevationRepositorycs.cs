using ExAVReservas.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExAVReservas.Infraestructura
{
    public interface IResevationRepositorycs
    {
        public List<ReservationDtocs> GetReservations();
        public ReservationDtocs GetReservationId(int id);
        public ReservationDtocs GetReservationClietntId(int id);
        public ReservationDtocs UpdateReservation(ReservationDtocs reservation);
        public ReservationDtocs DeleteReservation(ReservationDtocs reservation);
        public ReservationDtocs AddReservation(ReservationDtocs reservation);
    }
}
