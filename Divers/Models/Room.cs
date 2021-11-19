using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Divers.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        [MaxLength(3)]
        public int Quantity { get; set; }
        public decimal DefaultRate { get; set; } = 75;
        public List<Roomrate> Roomrates { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
