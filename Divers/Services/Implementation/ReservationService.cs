using Divers.Data;
using Divers.Models;
using Divers.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divers.Services.Implementation
{
    public class ReservationService : IReservationService
    {

        private readonly ApplicationDbContext _context;
        public ReservationService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool CheckAvailability()
        {
            throw new NotImplementedException();
        }

        public bool CheckIfReservationsAreEmpty()
        {
            var isEmpty = _context.reservations.Count()>0 ? false : true;
            return isEmpty;
        }

        public int GetFilledRoomsByCheckoutAndCheckInAndType(int roomId, DateTime checkIn, DateTime checkOut)
        {
            int roomsNumber = 0;
            var reservations = _context.reservations.Where(r => (
                (r.CheckIn < checkIn && checkIn < r.CheckOut) ||
                (r.CheckIn < checkOut && checkOut < r.CheckOut)) ||
                (checkIn<r.CheckIn && checkOut>r.CheckOut)
                && r.Room.Id == roomId);
            foreach (var reservation in reservations) {
                roomsNumber += this.GetRoomsNumber(reservation.AdultsNumber, reservation.KidsNumber);
            }
            return roomsNumber;
        }


        public int GetRoomsNumber(int adultsNumber, int kidsNumber)
        {
            int RequiredRoomsNumber = (int)Math.Ceiling((decimal)adultsNumber / 2);
            if (kidsNumber > adultsNumber && (int)Math.Ceiling((decimal)kidsNumber / 2) > RequiredRoomsNumber)
            {
                RequiredRoomsNumber += (int)Math.Ceiling((decimal)(-adultsNumber + kidsNumber) / 2);
            }
            return RequiredRoomsNumber;
        }

        public bool storePermenantReservation(Reservation model)
        {
            _context.reservations.Add(model);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            else {
                return false;
            }
        }


        public int GetReservationByToken(string token)
        {
            if (_context.reservations.FirstOrDefault(r=>r.token==token) != null)
                return _context.reservations.FirstOrDefault(r=>r.token==token).Id;

            return -1;
        }

        public bool UpdatePermenantReservation(int id, Reservation reservation)
        {
            var Reservation = _context.reservations.Find(id);
            Reservation.AdultsNumber = reservation.AdultsNumber;
            Reservation.KidsNumber = reservation.KidsNumber;
            Reservation.CheckIn = reservation.CheckIn;
            Reservation.CheckOut = reservation.CheckOut;
            Reservation.RoomId = reservation.RoomId;

            return _context.SaveChanges()>0 ? true : false;
        }


        public Reservation UpdateReservation(int id, Reservation reservation)
        {
            var Reservation = _context.reservations.Find(id);
            Reservation.Name = reservation.Name;
            Reservation.Email = reservation.Email;
            Reservation.Country = reservation.Country;
            Reservation.MealId = reservation.MealId;
            Reservation.isCompleted = true;

            _context.SaveChanges();

            return Reservation;
        }

        public decimal GetRoomsCost(Reservation reservation, decimal defaultRate)
        {
            int requiredRoomsNumber = this.GetRoomsNumber(reservation.AdultsNumber, reservation.KidsNumber);
            //get all roomrates within this interval
            var intersectedRoomRates = _context.roomrates.Where(r => (
                (r.Start < reservation.CheckIn && reservation.CheckIn < r.End) ||
                (r.Start < reservation.CheckOut && reservation.CheckOut < r.End) ||
                (r.Start > reservation.CheckIn && reservation.CheckOut > r.End)
            )).OrderBy(r=>r.Start);

            decimal RoomsCost = 0;
            int totalCountedDays = 0;
            DateTime currentCheckIn = reservation.CheckIn;

            foreach (var roomRate in intersectedRoomRates) {
                if (currentCheckIn < roomRate.Start) {
                    currentCheckIn = roomRate.Start;

                    if (reservation.CheckOut < roomRate.End) {
                        var daysWithinRate1 = (reservation.CheckOut - currentCheckIn).Days;
                        RoomsCost += daysWithinRate1 * roomRate.Rate * requiredRoomsNumber;
                        totalCountedDays += daysWithinRate1;
                        currentCheckIn = reservation.CheckOut;
                    } else {
                        var daysWithinRate2 = (roomRate.End - currentCheckIn).Days;
                        RoomsCost += daysWithinRate2 * roomRate.Rate * requiredRoomsNumber;
                        totalCountedDays += daysWithinRate2;
                        currentCheckIn = roomRate.End;
                    }
                } else {
                    if (reservation.CheckOut<roomRate.End) {
                        var daysWithinRate3 = (reservation.CheckOut - currentCheckIn).Days;
                        RoomsCost += daysWithinRate3 * roomRate.Rate * requiredRoomsNumber;
                        totalCountedDays += daysWithinRate3;
                        currentCheckIn = reservation.CheckOut;
                    } else
                    {
                        var daysWithinRate4 = (roomRate.End - currentCheckIn).Days;
                        RoomsCost += daysWithinRate4 * roomRate.Rate * requiredRoomsNumber;
                        totalCountedDays += daysWithinRate4;
                        currentCheckIn = roomRate.End;
                    }
                }
            }
            int uncountedDays = (reservation.CheckOut-reservation.CheckIn).Days - totalCountedDays;
            RoomsCost += uncountedDays*defaultRate*requiredRoomsNumber;
            return RoomsCost;
        }

        public decimal GetMealsCost(Reservation reservation, decimal defaultRate)
        {
            int DailyRequiredMealsNumber = reservation.AdultsNumber + reservation.KidsNumber;
            //get all mealrates within this interval
            var intersectedMealsRates = _context.mealrates.Where(r => (
                ((r.Start < reservation.CheckIn && reservation.CheckIn < r.End) ||
                (r.Start < reservation.CheckOut && reservation.CheckOut < r.End) ||
                (r.Start > reservation.CheckIn && reservation.CheckOut > r.End)) &&
                (r.MealId == reservation.MealId)
            )).OrderBy(r => r.Start);

            decimal MealsCost = 0;
            int totalCountedDays = 0;
            DateTime currentCheckIn = reservation.CheckIn;

            foreach (var mealRate in intersectedMealsRates)
            {
                if (currentCheckIn < mealRate.Start)
                {
                    currentCheckIn = mealRate.Start;

                    if (reservation.CheckOut < mealRate.End)
                    {
                        var daysWithinRate1 = (reservation.CheckOut - currentCheckIn).Days;
                        MealsCost += daysWithinRate1 * mealRate.Rate * DailyRequiredMealsNumber;
                        totalCountedDays += daysWithinRate1;
                        currentCheckIn = reservation.CheckOut;
                    }
                    else
                    {
                        var daysWithinRate2 = (mealRate.End - currentCheckIn).Days;
                        MealsCost += daysWithinRate2 * mealRate.Rate * DailyRequiredMealsNumber;
                        totalCountedDays += daysWithinRate2;
                        currentCheckIn = mealRate.End;
                    }
                }
                else
                {
                    if (reservation.CheckOut < mealRate.End)
                    {
                        var daysWithinRate3 = (reservation.CheckOut - currentCheckIn).Days;
                        MealsCost += daysWithinRate3 * mealRate.Rate * DailyRequiredMealsNumber;
                        totalCountedDays += daysWithinRate3;
                        currentCheckIn = reservation.CheckOut;
                    }
                    else
                    {
                        var daysWithinRate4 = (mealRate.End - currentCheckIn).Days;
                        MealsCost += daysWithinRate4 * mealRate.Rate * DailyRequiredMealsNumber;
                        totalCountedDays += daysWithinRate4;
                        currentCheckIn = mealRate.End;
                    }
                }
            }
            int uncountedDays = (reservation.CheckOut - reservation.CheckIn).Days - totalCountedDays;
            MealsCost += uncountedDays * defaultRate * DailyRequiredMealsNumber;
            return MealsCost;
        }

        public void DeleteReservaion(int id)
        {
            var reservation = _context.reservations.FirstOrDefault(r=>r.Id==id);
            _context.Remove(reservation);
            _context.SaveChanges();
        }
    }
}
