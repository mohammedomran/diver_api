using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Divers.Dtos.Reservation
{
    public class CheckRoomForReservationDto 
    {
        [Required]
        public int AdultsNumber { get; set; }
        [Required]
        public int KidsNumber { get; set; }
        [Required]
        public DateTime CheckIn { get; set; }
        [Required]
        public DateTime CheckOut { get; set; }
        [Required]
        public int Id { get; set; }
    }
}

