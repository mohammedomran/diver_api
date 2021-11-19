using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Divers.Dtos.Reservation
{
    public class AddPermenantReservationDto
    {
        public int AdultsNumber { get; set; }
        public int KidsNumber { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string token { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
