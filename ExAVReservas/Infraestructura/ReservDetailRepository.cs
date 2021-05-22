using ExAVReservas.Data;
using ExAVReservas.DTOs;
using ExAVReservas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExAVReservas.Infraestructura
{
    public class ReservDetailRepository : IReservDetailRepository
    {
        public readonly ExAPVRContext _context;

        public ReservDetailRepository(ExAPVRContext exContext)
        {
            _context = exContext;
        }

        public List<ReservDetailDto> GetDetails()
        {
            var reservationDetails = _context.reservationDetails.ToList();

            List<ReservDetailDto> detailDtos = new List<ReservDetailDto>();

            foreach (ReservationDetail detail in reservationDetails)
            {
                detailDtos.Add(new ReservDetailDto
                {
                    IdDetail = detail.IdDetail,
                    IdFurniture = detail.IdFurniture,
                    IdReseration = detail.IdReseration,

                });
            }

            return detailDtos;
        }

         public ReservDetailDto GetDetailId(int id)
         {
            var detail = _context.reservationDetails.FirstOrDefault(c => c.IdDetail == id);

            if (detail == null)
            {
                return new ReservDetailDto
                {
                    MessageError = "Not found"
                };
            }

            return new ReservDetailDto
            {
                IdDetail = detail.IdDetail,
                IdFurniture = detail.IdFurniture,
                IdReseration = detail.IdReseration
            };
        }

        public ReservDetailDto AddDetail(ReservDetailDto reservDetail)
        {
            if (reservDetail != null)
            {
                ReservationDetail categoryEvent = new ReservationDetail
                {
                    IdFurniture = reservDetail.IdFurniture,
                    IdReseration = reservDetail.IdReseration
                };

                _context.reservationDetails.Add(categoryEvent);
                _context.SaveChanges();
                reservDetail.IdDetail = categoryEvent.IdDetail;

                return reservDetail;
            }

            return new ReservDetailDto
            {
                MessageError = "Empy Event"
            };
        }

        public ReservDetailDto UpdateDetail(ReservDetailDto detailDto)
        {
            var register = _context.reservationDetails.FirstOrDefault(c => c.IdDetail == detailDto.IdDetail);

            if (register == null)
            {
                return new ReservDetailDto
                {
                    MessageError = "Not Found"
                };
            }

            register.IdDetail = detailDto.IdDetail;
            register.IdFurniture = detailDto.IdFurniture;
            register.IdReseration = detailDto.IdReseration;

            _context.SaveChanges();
            return detailDto;
        }

        public ReservDetailDto DeleteDetail(ReservDetailDto detailDto)
        {
            var register = _context.reservationDetails.FirstOrDefault(c => c.IdDetail == detailDto.IdDetail);

            if (register == null)
            {
                return new ReservDetailDto
                {
                    MessageError = "Not Found"
                };
            }

            _context.reservationDetails.Remove(register);
            _context.SaveChanges();
            return detailDto;
        }


    }
}
