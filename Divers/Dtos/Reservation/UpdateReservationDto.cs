using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Divers.Dtos.Reservation
{
    public class UpdateReservationDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string token { get; set; }
    }
}
