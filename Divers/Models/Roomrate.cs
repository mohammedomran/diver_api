using System;
using System.ComponentModel.DataAnnotations;

namespace Divers.Models
{
    public class Roomrate
    {
        public int Id { get; set; }
        [MaxLength(3)]
        public int Rate { get; set; }
        [Required]
        public int RoomId { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
    }
}
