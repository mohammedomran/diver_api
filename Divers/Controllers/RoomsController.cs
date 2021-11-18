using Divers.Models;
using Divers.Services.Implementation;
using Divers.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {

        private readonly IRoomService _service;

        public RoomsController(IRoomService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Room>> GetRooms() {
            var rooms = _service.GetRooms();
            return Ok(rooms);
        }

    }
}
