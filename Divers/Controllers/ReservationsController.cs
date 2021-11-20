using AutoMapper;
using Divers.Dtos.Reservation;
using Divers.Models;
using Divers.Services.Interfaces;
using Hangfire;
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

        [HttpGet("{token}")]
        public ActionResult<bool> checkIfReservationIsStored(string token) {
            if ((int)_service.GetReservationByToken(token) > 0)
                return Ok("reservation found");
            return NotFound("reservation not found");

        }
        [HttpPost("check")]
        public ActionResult<bool> CheckIfRoomsAvailable(Reservation model)
        {
            if(!ModelState.IsValid)
                return StatusCode(400, "Not valid model");
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
                return StatusCode(400, "not valid model");

            var PermenantReservationToBeCreated = _mapper.Map<Reservation>(reservation);
            bool StorageStatus = _service.storePermenantReservation(PermenantReservationToBeCreated);
            //this.DelayedDeleteReservation(reservation.token);
            return StorageStatus ? Ok("permenant reservation stored") : StatusCode(400, "permenant reservation not stored");
        }

        [HttpPost("permenant/update")]
        public ActionResult<bool> UpdatePermenantReservation(UpdatePermenantReservationDto reservation)
        {
            if (!ModelState.IsValid)
                return Ok("not valid model");

            var id = _service.GetReservationByToken(reservation.token);

            var PermenantReservationToBeUpdated = _mapper.Map<Reservation>(reservation);
            
            if (id < 0)
                _service.storePermenantReservation(PermenantReservationToBeUpdated);

            var UpdateStatus = _service.UpdatePermenantReservation(id, PermenantReservationToBeUpdated);
            return UpdateStatus ? Ok("permenant reservation updated") : Ok("nothing changed");
        }

        [HttpPost("cost")]
        public ActionResult<IEnumerable<Roomrate>> CalculateReservationCost(UpdateReservationDto reservation)
        {
            if (!ModelState.IsValid)
                return StatusCode(400, "Not valid model");

            var requiredReservationId = _service.GetReservationByToken(reservation.token);
            if (requiredReservationId < 0) return StatusCode(404, "Reservation not found");

            var ReservationToBeUpdated = _mapper.Map<Reservation>(reservation);
            var UpdatedReservation = _service.UpdateReservation(requiredReservationId, ReservationToBeUpdated);

            decimal roomDefaultRate = _roomService.GetDefaultRateById(UpdatedReservation.RoomId);
            decimal mealDefaultRate = _roomService.GetDefaultRateById((int)UpdatedReservation.MealId);
            decimal RoomsCost = _service.GetRoomsCost(UpdatedReservation, roomDefaultRate);
            decimal MealsCost = _service.GetMealsCost(UpdatedReservation, mealDefaultRate);

            return Ok(MealsCost+RoomsCost);
        }


        /*[HttpGet("task")]
        public ActionResult DelayedDeleteReservation(string token)
        {
            int id = _service.GetReservationByToken(token);
            var jobId = BackgroundJob.Schedule(
            () => _service.DeleteReservaion(id),
            TimeSpan.FromSeconds(120));
            return Ok("ready ??");
        }*/


    }
}
