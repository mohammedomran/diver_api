using System;
using System.Collections.Generic;

namespace Divers.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public List<Mealrate> Mealrates { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
