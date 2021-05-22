using ExAVReservas.Data;
using ExAVReservas.DTOs;
using ExAVReservas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExAVReservas.Infraestructura
{
    public class ReservationRepository : IResevationRepositorycs
    {
        public readonly ExAPVRContext _context;

        public ReservationRepository(ExAPVRContext exContext)
        {
            _context = exContext;
        }

        public List<ReservationDtocs> GetReservations()
        {
            var reservations = _context.reservationModels.ToList();

            List<ReservationDtocs> reservationDtos = new List<ReservationDtocs>();

            foreach (ReservationModel reserva in reservations)
            {
                reservationDtos.Add(new ReservationDtocs
                {
                    IdReservation = reserva.IdReservation,
                    DateDue = reserva.DateDue,
                    IdEvent = reserva.IdEvent,
                    IdClient = reserva.IdClient

                });
            }

            return reservationDtos;
        }

        public ReservationDtocs GetReservationId(int id)
        {
            var reservation = _context.reservationModels.FirstOrDefault(c => c.IdReservation == id);

            if (reservation == null)
            {
                return new ReservationDtocs
                {
                    MessageError = "Not found"
                };
            }

            return new ReservationDtocs
            {
                IdReservation = reservation.IdReservation,
                DateDue = reservation.DateDue,
                IdClient = reservation.IdClient,
                IdEvent = reservation.IdEvent
            };
        }

        public ReservationDtocs GetReservationClietntId(int id)
        {
            var reservation = _context.reservationModels.FirstOrDefault(c => c.IdClient == id);

            if (reservation == null)
            {
                return new ReservationDtocs
                {
                    MessageError = "Not found"
                };
            }

            return new ReservationDtocs
            {
                IdReservation = reservation.IdReservation,
                DateDue = reservation.DateDue,
                IdClient = reservation.IdClient,
                IdEvent = reservation.IdEvent
            };
        }


        public ReservationDtocs AddReservation(ReservationDtocs reservation)
        {
            if (reservation != null)
            {
                ReservationModel reservationModel = new ReservationModel
                {
                    DateDue = reservation.DateDue,
                    IdClient = reservation.IdClient,
                    IdEvent = reservation.IdEvent
                };

                _context.reservationModels.Add(reservationModel);
                _context.SaveChanges();
                reservation.IdEvent = reservationModel.IdEvent;

                return reservation;
            }

            return new ReservationDtocs
            {
                MessageError = "Empy Event"
            };
        }

        public ReservationDtocs UpdateReservation(ReservationDtocs reservation)
        {
            var register = _context.reservationModels.FirstOrDefault(c => c.IdReservation == reservation.IdReservation);

            if (register == null)
            {
                return new ReservationDtocs
                {
                    MessageError = "Not Found"
                };
            }

            register.IdEvent = reservation.IdEvent;
            register.IdReservation = reservation.IdReservation;
            register.IdClient = reservation.IdClient;
            register.DateDue = reservation.DateDue;


            _context.SaveChanges();
            return reservation;
        }

        public ReservationDtocs DeleteReservation(ReservationDtocs reservation)
        {
            var register = _context.reservationModels.FirstOrDefault(c => c.IdReservation == reservation.IdReservation);

            if (register == null)
            {
                return new ReservationDtocs
                {
                    MessageError = "Not Found"
                };
            }

            _context.reservationModels.Remove(register);
            _context.SaveChanges();
            return reservation;
        }
    }
}
