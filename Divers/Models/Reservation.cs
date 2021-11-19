using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Divers.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Name { get; set; } = null;
        public string Email { get; set; } = null;
        public string Country { get; set; } = null;
        public int AdultsNumber { get; set; }
        public int KidsNumber { get; set; }
        public Room Room { get; set; } = null;
        public Meal Meal { get; set; } = null;
        public int RoomId { get; set; }
        public int? MealId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public bool isCompleted { get; set; } = false;
        public string token { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
