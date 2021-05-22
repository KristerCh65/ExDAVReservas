using ExAVReservas.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExAVReservas.Infraestructura
{
    public interface IReservDetailRepository
    {
        public List<ReservDetailDto> GetDetails();
        public ReservDetailDto GetDetailId(int id);
        public ReservDetailDto UpdateDetail(ReservDetailDto detailDto);
        public ReservDetailDto DeleteDetail(ReservDetailDto detailDto);
        public ReservDetailDto AddDetail(ReservDetailDto detailDto);
    }
}
