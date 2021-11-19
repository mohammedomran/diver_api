using System;

namespace Divers.Models
{
    public class Mealrate
    {
        public int Id { get; set; }
        public int Rate { get; set; }
        public int MealId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}