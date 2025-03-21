using Reservation.Hotels.Context;
using Reservation.Hotels.CQRS.Commands;

namespace Reservation.Hotels.CQRS.Handlers
{
    public class UpdateLocationCommandHandler
    {
        private readonly HotelContext _context;

        public UpdateLocationCommandHandler(HotelContext context)
        {
            _context = context;
        }
        public void Handle(UpdateCommandLocation command)
        {
            var value = _context.Locations.Find(command.LocationId);
            value.LocationCity = command.LocationCity;
            value.Disctrict = command.Disctrict;
            value.Country = command.Country;
            _context.SaveChanges();
        }
    }
}
