using ExAVReservas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExAVReservas.Data
{
    public class ExAPVRContext : DbContext
    {
        public DbSet<ClientModel> clientModels { get; set; }
        public DbSet<CategoryEventModel> eventModels { get; set; }
        public DbSet<FurnitureModel> furnitureModels { get; set; }
        public DbSet<ReservationModel> reservationModels { get; set; }
        public DbSet<ReservationDetail> reservationDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTP-KCH;Database=ExDAVRes;Trusted_Connection=true;");
        }
    }
}
