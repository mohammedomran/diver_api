using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Divers.Dtos.Reservation
{
    public class UpdatePermenantReservationDto
    {
        [Required]
        public int AdultsNumber { get; set; }
        [Required]
        public int KidsNumber { get; set; }
        [Required]
        public int RoomId { get; set; }
        [Required]
        public DateTime CheckIn { get; set; }
        [Required]
        public DateTime CheckOut { get; set; }
        [Required]
        public string token { get; set; }
    }
}
