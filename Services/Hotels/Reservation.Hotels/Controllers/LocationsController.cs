using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservation.Hotels.CQRS.Commands;
using Reservation.Hotels.CQRS.Handlers;

namespace Reservation.Hotels.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly CreateLocationCommandHandler _createLocationCommandHandler;
        private readonly UpdateLocationCommandHandler _updateLocationCommandHandler;
        private readonly GetByIdLocationQueryHandler _getByIdLocationQueryHandler;
        private readonly GetLocationQueryHandler _getLocationQueryHandler;
        private readonly RemoveLocationCommandHandler _removeLocationCommandHandler;

        public LocationsController(CreateLocationCommandHandler createLocationCommandHandler, UpdateLocationCommandHandler updateLocationCommandHandler, GetByIdLocationQueryHandler getByIdLocationQueryHandler, GetLocationQueryHandler getLocationQueryHandler, RemoveLocationCommandHandler removeLocationCommandHandler)
        {
            _createLocationCommandHandler = createLocationCommandHandler;
            _updateLocationCommandHandler = updateLocationCommandHandler;
            _getByIdLocationQueryHandler = getByIdLocationQueryHandler;
            _getLocationQueryHandler = getLocationQueryHandler;
            _removeLocationCommandHandler = removeLocationCommandHandler;
        }
        [HttpGet]
        public IActionResult LocationList()
        {
            var values = _getLocationQueryHandler.Handle();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateLocation(CreateCommandLocation command)
        {
            _createLocationCommandHandler.Handle(command);
            return Ok("Ekleme Başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteLocation(int id)
        {
            _removeLocationCommandHandler.Handle(new RemoveCommandLocation(id));
            return Ok("Silme Başarılı");
        }
        [HttpPut]
        public IActionResult UpdateLocation(UpdateCommandLocation command)
        {
            _updateLocationCommandHandler.Handle(command);
            return Ok("Güncelleme Başarılı");
        }
    }
}
