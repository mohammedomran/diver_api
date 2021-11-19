using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Divers.Dtos.Reservation
{
    public class UpdateReservationDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string MealId { get; set; }
        [Required]
        public string token { get; set; }
    }
}
