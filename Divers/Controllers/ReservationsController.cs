using AutoMapper;
using Divers.Dtos.Reservation;
using Divers.Models;
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
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _service;
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;
        public ReservationsController(IReservationService service, IRoomService roomService, IMapper mapper)
        {
            _service = service;
            _roomService = roomService;
            _mapper = mapper;
        }

        [HttpPost("check")]
        public ActionResult<bool> CheckIfRoomsAvailable(Reservation model)
        {
            //check if no reservations
            if (_service.CheckIfReservationsAreEmpty())
            {
                //check that specific room type is enough for this reservation
                int NumberOfRoomsOfThisType = _roomService.GetNumberOfRoomsOfType(model.Id);
                int RequiredRoomsNumber = _service.GetRoomsNumber(model.AdultsNumber, model.KidsNumber);
                return NumberOfRoomsOfThisType >= RequiredRoomsNumber ? Ok("Rooms are available") : StatusCode(400, "Sorry, no available rooms");
            }
            else
            {
                //check for total_rooms_number-reserved_rooms where this type and checkout<checkin of this reservation
                int FilledRoomsOfThisType = _service.GetFilledRoomsByCheckoutAndCheckInAndType(model.Id, model.CheckIn, model.CheckOut);
                int TotalNumberOfRoomsOfType = _roomService.GetNumberOfRoomsOfType(model.Id);
                int AvailableRooms = TotalNumberOfRoomsOfType - FilledRoomsOfThisType;
                int RequiredRoomsNumber = _service.GetRoomsNumber(model.AdultsNumber, model.KidsNumber);
                return AvailableRooms >= RequiredRoomsNumber ? Ok("Rooms are available") : StatusCode(400, "Sorry, no available rooms");
            }

        }

        [HttpPost("permenant/store")]
        public ActionResult<bool> storePermenantReservation(AddPermenantReservationDto reservation)
        {
            if (!ModelState.IsValid)
                return Ok("not valid model");

            var PermenantReservationToBeCreated = _mapper.Map<Reservation>(reservation);
            bool StorageStatus = _service.storePermenantReservation(PermenantReservationToBeCreated);
            return StorageStatus;
        }

        [HttpPost("cost")]
        public ActionResult<IEnumerable<Roomrate>> CalculateReservationCost(UpdateReservationDto reservation)
        {
            if (!ModelState.IsValid)
                return Ok("not valid model");

            var requiredReservationId = _service.GetReservationByToken(reservation.token);
            if (requiredReservationId < 0) return NotFound();

            var ReservationToBeUpdated = _mapper.Map<Reservation>(reservation);
            var UpdatedReservation = _service.UpdateReservation(requiredReservationId, ReservationToBeUpdated);
            
            var cost = _service.GetRoomsCost(UpdatedReservation, 75);
            return Ok(cost);
        }




    }
}
