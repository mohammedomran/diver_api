using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Divers.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public decimal DefaultRate { get; set; } = 75;
        public List<Roomrate> Roomrates { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
