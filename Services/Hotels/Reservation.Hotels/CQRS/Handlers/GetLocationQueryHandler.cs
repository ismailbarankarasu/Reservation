using Reservation.Hotels.Context;
using Reservation.Hotels.CQRS.Results;
using System.Runtime.CompilerServices;

namespace Reservation.Hotels.CQRS.Handlers
{
    public class GetLocationQueryHandler
    {
        private readonly HotelContext _context;

        public GetLocationQueryHandler(HotelContext context)
        {
            _context = context;
        }
        public List<GetLocationQueryResult> Handle() 
        {
            var values = _context.Locations.Select(x => new GetLocationQueryResult
            {
                Country = x.Country,
                Disctrict = x.Disctrict,
                LocationCity = x.LocationCity,
                LocationId = x.LocationId
            }).ToList();
            return values;
        }
    }
}
