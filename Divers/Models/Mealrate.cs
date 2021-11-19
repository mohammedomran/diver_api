using System;
using System.ComponentModel.DataAnnotations;

namespace Divers.Models
{
    public class Mealrate
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(3)]
        public int Rate { get; set; }
        public int MealId { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
    }
}