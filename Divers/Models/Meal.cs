using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Divers.Models
{
    public class Meal
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        public List<Mealrate> Mealrates { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
