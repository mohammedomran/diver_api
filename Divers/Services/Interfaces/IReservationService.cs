using Divers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divers.Services.Interfaces
{
    public interface IReservationService
    {
        bool CheckAvailability();
        bool CheckIfReservationsAreEmpty();
        int GetFilledRoomsByCheckoutAndCheckInAndType(int roomId, DateTime checkIn, DateTime checkOut);
        int GetRoomsNumber(int adultsNumber, int kidsNumber);
        bool storePermenantReservation(Reservation model);
        int GetReservationByToken(string token);
        Reservation UpdateReservation(int id, Reservation reservation);
        bool UpdatePermenantReservation(int id, Reservation reservation);
        decimal GetRoomsCost(Reservation reservation, decimal defaultRate);
        decimal GetMealsCost(Reservation reservation, decimal defaultRate);
        void DeleteReservaion(int id);
    }
}
