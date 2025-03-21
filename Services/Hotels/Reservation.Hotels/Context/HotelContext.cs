using Microsoft.EntityFrameworkCore;
using Reservation.Hotels.Entities;

namespace Reservation.Hotels.Context
{
    public class HotelContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=1440,localhost;initial catalog=HotelReservationDb;user=sa;password=123456aA*;");
        }
        public DbSet<HotelInfo> HotelInfos{ get; set; }
        public DbSet<Location> Locations{ get; set; }
    }
}
