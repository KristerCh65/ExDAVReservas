using ExAVReservas.DTOs;
using ExAVReservas.Infraestructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExAVReservas.Services
{
    public class ReservationAppService : IReservationAppService
    {
        private readonly IResevationRepositorycs _reservationApp;
        private readonly IClientRepository _clientRepository;

        public ReservationAppService(IResevationRepositorycs appService, IClientRepository clientRepo)
        {
            _reservationApp = appService;
            _clientRepository = clientRepo;
        }

        public List<ReservationDtocs> GetReservations(ReservationResponse reservation)
        {
            List<ReservationDtocs> reservationDto = _reservationApp.GetReservations();
            return reservationDto;
        }

        public ReservationDtocs GetReservationId(ReservationResponse reservation)
        {
            ReservationDtocs reservationDto = _reservationApp.GetReservationId(reservation.IdReservation);
            return reservationDto;
        }

        public ReservationDtocs AddReservation(ReservationResponse reservation)
        {
            var Finde = reservation.DateDue.DayOfWeek.Equals('5' & '6');
            var hours = reservation.DateDue.ToString("HH:mm tt");

            ReservationDtocs clientExist = _reservationApp.GetReservationClietntId(reservation.IdClient);

            if (clientExist == null)
            {
                new ReservationDtocs
                {
                    MessageError = "Client is Required"
                };
            }

            ClientDto clientDto = _clientRepository.GetClienteId(reservation.IdClient);

            if(clientDto.Age < 21 || clientDto.Status.Equals("Mora").Equals("Cancelado") )
            {
                new ReservationDtocs
                {
                    MessageError = "Cliente no apto para reserva"
                };
            }
            

            if (reservation.IdEvent == 0)
            {
                new ReservationDtocs
                {
                    MessageError = "Category Event is Required"
                };
            }

            if (reservation.DateDue.DayOfWeek.Equals('0'))
            {
                new ReservationDtocs
                {
                    MessageError = "Not reservations on Sunday"
                };
            }

            ReservationDtocs newReserva = new ReservationDtocs
            {
                IdReservation = reservation.IdReservation,
                DateDue = reservation.DateDue,
                IdClient = reservation.IdClient,
                IdEvent = reservation.IdEvent
            };

            ReservationDtocs response = _reservationApp.AddReservation(newReserva);
            return response;        
        }

        public ReservationDtocs UpdateReservation( ReservationResponse reservation)
        {
            ReservationDtocs clientExist = _reservationApp.GetReservationClietntId(reservation.IdClient);

            if (clientExist == null)
            {
                new ReservationDtocs
                {
                    MessageError = "Client is Required"
                };
            }

            if (reservation.IdEvent == 0)
            {
                new ReservationDtocs
                {
                    MessageError = "Category Event is Required"
                };
            }

            ReservationDtocs newReserva = new ReservationDtocs
            {
                IdReservation = reservation.IdReservation,
                DateDue = reservation.DateDue,
                IdClient = reservation.IdClient,
                IdEvent = reservation.IdEvent
            };

            ReservationDtocs response = _reservationApp.UpdateReservation(newReserva);
            return response;
        }

        public ReservationDtocs GetReservationClietntId(ReservationResponse reservation)
        {
            ReservationDtocs reservationDto = _reservationApp.GetReservationClietntId(reservation.IdClient);
            return reservationDto;
        }


        public ReservationDtocs DeleteReservation(ReservationResponse reservation)
        {
            ReservationDtocs newReserva = new ReservationDtocs
            {
                IdReservation = reservation.IdReservation,
                DateDue = reservation.DateDue,
                IdClient = reservation.IdClient,
                IdEvent = reservation.IdEvent
            };

            ReservationDtocs reservationDto = _reservationApp.DeleteReservation(newReserva);
            return reservationDto;
        }
    }
}
